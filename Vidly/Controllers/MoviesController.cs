using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        private List<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.MovieGenre).ToList();
        }

        public ActionResult New()
        {
            MovieFormViewModel viewModel = new MovieFormViewModel
            {
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        // GET: Movies/Edit/1
        // GET: Movies/Edit?id=1
        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            MovieFormViewModel viewModel = new MovieFormViewModel(movie)
            {
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                MovieFormViewModel viewModel = new MovieFormViewModel(movie)
                {
                    MovieGenres = _context.MovieGenres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                Movie movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.MovieGenreId = movie.MovieGenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        // GET: Movies
        public ActionResult Index()
        {
            return View(GetMovies());
        }

        // GET: Movies/Details
        public ActionResult Details(int id)
        {
            return View(GetMovies()[id - 1]);
        }

        // GET: Movies/Random
        // page with string (with layout)
        // this is the clean way to push data to a view
        public ActionResult Random()
        {
            string name = GetARandomMovieName();

            Movie movie = new Movie {Name = name};

            // you don't have to manually add it here if using only one model
            // View() will take care of it
            //ViewResult viewResult = new ViewResult();
            //viewResult.ViewData.Model = movie;

            return View(movie);
        }

        // GET: Movies/Random
        // page with string (with layout)
        // this is the clean way to push data to a view
        // from multiple models to one view
        public ActionResult RandomViewModel()
        {
            string name = GetARandomMovieName();

            Movie movie = new Movie {Name = name};
            var customers = new List<Customer>
            {
                new Customer {Name = "customer 1"},
                new Customer {Name = "customer 2"},
                new Customer {Name = "customer 3"}
            };

            RandomMovieViewModel randomMovieViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(randomMovieViewModel);
        }

        // GET: Movies/Random
        // page with string (with layout)
        // this is the ugly way (using ViewBag)
        public ActionResult RandomUgly()
        {
            string name = GetARandomMovieName();


            Movie movie = new Movie {Name = name};

            // issues:
            // lacks compile time safety
            // casting issues
            ViewBag.Movie = movie;

            return View();
        }

        // GET: Movies/Random
        // page with string (with layout)
        // this is the dirty way to push data to a view (using ViewData)
        public ActionResult RandomDirty()
        {
            string name = GetARandomMovieName();

            Movie movie = new Movie {Name = name};

            // issues:
            // Hardcoding strings
            // casting issues
            ViewData["Movie"] = movie;

            return View();
        }

        private string GetARandomMovieName()
        {
            Random rnd = new Random();
            var movies = GetMovies();
            int index = rnd.Next(0, movies.Count());
            string name = movies[index].Name;
            return name;
        }


        // GET: Movies
        // GET: Movies/Index
        // GET: Movies/Index?pageindex=1&sortby=name
        // testing parameters
        [Route("Movies/Index/{pageIndex}/{sortBy}")]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageIndex = {0}, SortBy = {1}", pageIndex, sortBy));
        }

        // GET: Movies/released/2014/04  << year and month
        // this has a custom route indicated in app_start>>RouteConfig.cs file
        public ActionResult ByReleaseDate(string year, string month)
        {
            return Content(year + "/" + month);
        }

        // GET: Movies/released/2014   << year only
        // this is another way to have a custom route but inside the controller file
        // note: you should have added 'route.MapMvcAttributeRoutes();' inside app_start>>RouteConfig.cs file
        // adding constraint of range helps you transfer between older and newer version 
        // (supposing you switched views for only newly added movies in this case)
        // for more https://blogs.msdn.microsoft.com/webdev/2013/10/17/attribute-routing-in-asp-net-mvc-5/
        [Route("movies/released/{year:regex(\\d{4}):range(2000,2020)}")]
        public ActionResult ByReleaseYear(string year)
        {
            return Content("Release Year is " + year);
        }

        // GET: Movies/HelloWorld
        // page with string (no layout)
        public ActionResult HelloWorld()
        {
            return Content("Hello World");
        }

        // GET: Movies/Http404
        // returns HTTP 404
        public ActionResult Http404()
        {
            return HttpNotFound();
        }

        // GET: Movies/Empty
        // returns empty page
        public ActionResult Empty()
        {
            return new EmptyResult();
        }

        // GET: Movies/Redirect
        // redirect !!
        public ActionResult Redirect()
        {
            return RedirectToAction("Index", "Home", new {page = "1", somethingElse = "someString"});
        }
    }
}