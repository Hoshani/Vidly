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
    }
}