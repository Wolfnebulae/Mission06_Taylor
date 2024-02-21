using DateMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DateMe.Controllers
{
    public class HomeController : Controller
    {
        private MovieApplicationContext _context;

        public HomeController(MovieApplicationContext temp) 
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
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.Category)
                .ToList();
            return View("DatingApplication", new Application());
        }

        [HttpPost]
        public IActionResult DatingApplication(Application response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.Category)
                .ToList();
                return View(response);
            }
        }

        public IActionResult ViewMovies()
        {
            var movieList = _context.Movies.Include("Category").ToList();

            return View(movieList);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Application recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.Category)
                .ToList();
            return View("DatingApplication", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Application updatedInfo) 
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("ViewMovies");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Application recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Application movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("ViewMovies");
        }
    }
}
