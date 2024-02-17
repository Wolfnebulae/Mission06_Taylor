using DateMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DateMe.Controllers
{
    public class HomeController : Controller
    {
        private DatingApplicationContext _context;

        public HomeController(DatingApplicationContext temp) 
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DatingApplication()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DatingApplication(Application response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }
    }
}
