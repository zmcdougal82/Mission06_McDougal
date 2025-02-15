using Microsoft.AspNetCore.Mvc;
using Mission06_McDougal.Models;

namespace Mission06_McDougal.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // Display all movies
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        // Show the form to add a new movie
        public IActionResult AddMovie()
        {
            return View();
        }

        // Process the submitted movie form
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
    }
}