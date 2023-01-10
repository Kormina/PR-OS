using heat.Data;
using heat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using HeatClassLibrary;

namespace heat.Controllers
{
    public class RegistrController : Controller
    {
        private readonly ILogger<RegistrController> _logger;
        private readonly ApplicationContext _context;

        public RegistrController(ILogger<RegistrController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }


        public IActionResult Index(HeatIn input)
        {
            if (!string.IsNullOrEmpty(input.Email))
            {

                var user = new User
                {
                    Email = input.Email,
                    Password = input.Password,
                    
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}