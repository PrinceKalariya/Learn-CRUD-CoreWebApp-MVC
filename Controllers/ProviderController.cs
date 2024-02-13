using Learn_CRUD_CoreWebApp_MVC.Context;
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

        public IActionResult Create()
        {
            var services = _context.Services.ToList();
            ViewBag.Services = services;
            return View();
        }
    }
}
