using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;


namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        // override of dispose method to clean the controller on exit
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ViewResult Index()
        {
            return View(GetCustomers());
        }

        // GET: Customer/Details
        public ActionResult Details(int id)
        {
            Customer customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            return View(customer);
        }

        private List<Customer> GetCustomers()
        {
            List<Customer> customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return customers;
            //new List<Customer>
            //{
            //    new Customer {Id = 1 ,Name = "John Smith"},
            //    new Customer {Id = 2 ,Name = "John Doe"},
            //    new Customer {Id = 3 ,Name = "Jane Doe"}
            //
            //};
        }
    }
}