using CodeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeProject.Controllers
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return this.CustomerName + "|" + this.Address;
        }
    }

    public class TestController : Controller
    {

        public Customer GetCustomer()
        {
            Customer c = new Customer();
            c.CustomerName = "John Doh";
            c.Address = "Area 51";
            return c;
            
        }

        public string GetString()
        {
            return "Hello World is old now. It&rsquo;s time for wassup bro ;)"; 
        }

        public ActionResult GetView()
        {
            Employee emp = new Employee();
            emp.FirstName = "Jesus";
            emp.LastName = "Miguel";
            emp.Salary = 20000;

            //ViewBag.Employee = emp;
            //ViewData["Employee"] = emp;
            return View("MyView", emp);
        }

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
    }
}