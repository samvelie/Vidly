using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        public ActionResult Random()
        {
            var movies = GetMovies().ToList();

            int r = rnd.Next(movies.Count);

            var randomMovie = movies[r];

            var customers = new List<Customer>
             {
                 new Customer { Name = "Customer 1" },
                 new Customer { Name = "Customer 2" }
             };

            var viewModel = new RandomMovieViewModel
            {
                Movie = randomMovie,
                Customers = customers
            };
            
            return View(viewModel);

        }

        [Route("movies/released/{year:regex([0-9]{4})}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Id=1,
                    Name = "The Land Before Time"
                },
                new Movie
                {
                    Id=2,
                    Name = "Shrek!"
                }

            };
        }

        private static System.Random rnd = new System.Random();

    }
}