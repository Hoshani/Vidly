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

        public ActionResult New()
        {
            List<MembershipType> membershipTypes = _context.MembershipTypes.ToList();
            CustomerFormViewModel viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                Customer customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscribedToMonthlyNewsLetter = customer.IsSubscribedToMonthlyNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            List<MembershipType> membershipTypes = _context.MembershipTypes.ToList();

            CustomerFormViewModel viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
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
        }
    }
}