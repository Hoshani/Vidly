using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        /*
         * ViewModel is a model specifically built for a specific view
         */
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}