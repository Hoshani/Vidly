using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        // page with string (with layout)
        public ActionResult Random()
        {

            string movies = "Bees,Shrek,Batman,Superman,Ironman";
            string[] randomMovies = movies.Split(',');
            Random rnd = new Random();
            int index = rnd.Next(0,randomMovies.Count());
            string name = randomMovies[index];

            Movie movie = new Movie() { Name = name };

            return View(movie);
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