using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        List<Customer> customers = new List<Customer>
            {
                new Customer {Id = 1 ,Name = "John Smith"},
                new Customer {Id = 2 ,Name = "John Doe"},
                new Customer {Id = 3 ,Name = "Jane Doe"}

            };

        // GET: Customer
        public ActionResult Index()
        {

            RandomMovieViewModel randomMovieViewModel = new RandomMovieViewModel
            {
                Customers = customers
            };

            return View(randomMovieViewModel);
        }

        // GET: Customer/Details
        public ActionResult Details(int id)
        {
            Customer customer = customers.Find(c => c.Id == id);

            return View(customer);
        }
    }
}