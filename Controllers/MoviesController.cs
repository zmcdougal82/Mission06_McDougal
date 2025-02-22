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

        // GET: Add Movie
        public IActionResult AddMovie()
        {
            return View();
        }

        // POST: Add Movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);  // Return the form with validation errors
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Edit Movie
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Edit Movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            _context.Movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Delete Movie
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Delete Movie
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
