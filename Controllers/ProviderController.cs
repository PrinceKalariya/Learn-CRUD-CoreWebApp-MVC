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

        public async Task<IActionResult> Index()
        {
            return View();
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
            if(ModelState.IsValid)
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
    }
}
