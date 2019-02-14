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
        public List<Movie> movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "Bees" },
                new Movie {Id = 2, Name = "Shrek" },
                new Movie {Id = 3, Name = "BatMan" },
                new Movie {Id = 4, Name = "IronMan" },
                new Movie {Id = 5, Name = "SpiderMan" },
                new Movie {Id = 6, Name = "AntMan" },
                new Movie {Id = 7, Name = "SuperMan" }
            };

        // GET: Movies
        public ActionResult Index()
        {
            MovieViewModel movieViewModel = new MovieViewModel
            {
                Movies = movies
            };

            return View(movieViewModel);
        }

        // GET: Movies/Details
        public ActionResult Details(int id)
        {
            return View(movies[id]);
        }

        // GET: Movies/Random
        // page with string (with layout)
        // this is the clean way to push data to a view
        public ActionResult Random()
        {
            string name = GetARandomMovieName();

            Movie movie = new Movie() { Name = name };

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

            Movie movie = new Movie() { Name = name };
            List<Customer> customers = new List<Customer>
            {
                new Customer{Name = "customer 1"},
                new Customer{Name = "customer 2"},
                new Customer{Name = "customer 3"}
            };

            RandomMovieViewModel randomMovieViewModel = new RandomMovieViewModel()
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


            Movie movie = new Movie() { Name = name };

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

            Movie movie = new Movie() { Name = name };

            // issues:
            // Hardcoding strings
            // casting issues
            ViewData["Movie"] = movie;

            return View();
        }

        private string GetARandomMovieName()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, movies.Count());
            string name = movies[index].Name;
            return name;
        }

        // GET: Movies/Edit/1
        // GET: Movies/Edit?id=1
        // testing a parameter (follows the conventional route {controller}/{action}/{id})
        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
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
            return RedirectToAction("Index", "Home", new { page = "1", somethingElse = "someString" });
        }
    }
}