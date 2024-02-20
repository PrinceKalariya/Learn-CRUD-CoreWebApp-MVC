using Learn_CRUD_CoreWebApp_MVC.Context;
using Learn_CRUD_CoreWebApp_MVC.Models;
using Learn_CRUD_CoreWebApp_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learn_CRUD_CoreWebApp_MVC.Controllers
{
    public class ProviderController : Controller
    {
        private ProviderDbContext _context;

        public ProviderController(ProviderDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var provider = _context.Providers.Include(p => p.ProviderServices).ThenInclude(s => s.Services).ToList();

            return provider != null ? View( provider ) : View();
        }

        public IActionResult Create()
        {
            var services = _context.Services.ToList();
            ViewBag.Services = services;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProviderFormViewModel providerFormViewModel)
        {
            if (ModelState.IsValid)
            {
                var provider = new Provider()
                {
                    FullName = providerFormViewModel.FullName,
                    DateOfRegistration = providerFormViewModel.DateOfRegistration,
                    IsActive = providerFormViewModel.IsActive
                };

                _context.Add(provider);

                foreach (var service in providerFormViewModel.ProviderServices)
                {
                    var providerService = new ProviderServices()
                    {
                        ProviderId = provider.ProviderId,
                        ServiceId = service,
                    };

                    provider.ProviderServices.Add(providerService);
                }

                _context.SaveChanges();

            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var services = _context.Services.ToList();
            ViewBag.Services = services;

            var providers = _context.Providers.Include(p => p.ProviderServices).ThenInclude(s => s.Services).FirstOrDefault(a => a.ProviderId == id);
            ViewBag.Details = providers;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProviderFormViewModel providerFormViewModel)
        {

            if (ModelState.IsValid)
            {

                var provider = _context.Providers.Include(p => p.ProviderServices).ThenInclude(s => s.Services).FirstOrDefault(a => a.ProviderId == id);

                if(provider != null)
                {
                    provider.FullName = providerFormViewModel.FullName;
                    provider.DateOfRegistration = providerFormViewModel.DateOfRegistration;
                    provider.IsActive = providerFormViewModel.IsActive;
                };
                
                _context.Update(provider);
                _context.SaveChanges();

                var serviceList = _context.ProviderServices.Where(p => p.ProviderId == id).ToList();
                _context.RemoveRange(serviceList);
                _context.SaveChanges();

                foreach (var service in providerFormViewModel.ProviderServices)
                {
                    var providerService = new ProviderServices()
                    {
                        ProviderId = provider.ProviderId,
                        ServiceId = service,
                    };

                    provider.ProviderServices.Add(providerService);
                }

                _context.SaveChanges();

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var provider = _context.Providers.Include(p => p.ProviderServices).ThenInclude(s => s.Services).FirstOrDefault(x => x.ProviderId == id);

                _context.RemoveRange(provider.ProviderServices);
                _context.Remove(provider);

                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
