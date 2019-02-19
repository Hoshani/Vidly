using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public string Title { get; set; }

        public List<MovieGenre> MovieGenres { get; set; }

        public Movie Movie { get; set; }
    }
}