using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Favc.Models;
using Favc.ViewModel;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Favc.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
      
            return View(movies);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            var viewmodel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres
            };
            return View("MovieForm",viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
          /*  if (!ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel
                {
                   Movie = movie,
                   Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewmodel);
            }*/

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();
           
           
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var movie = new Movie();
            movie.ReleaseDate = new DateTime();
            movie.NumberInStock = 0;
            var viewmodel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = genres
            };

            return View("MovieForm", viewmodel);
        }
    }
}