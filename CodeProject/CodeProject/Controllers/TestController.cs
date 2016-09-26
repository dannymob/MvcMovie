using CodeProject.Models;
using CodeProject.ViewModel;
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

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();
            
            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary>15000)
                {
                    empViewModel.SalaryColor = "yellow";
                } else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            employeeListViewModel.UserName = "Admin";
            
            //Employee emp = new Employee();
            //emp.FirstName = "Jesus";
            //emp.LastName = "Miguel";
            //emp.Salary = 20000;

            //EmployeeViewModel vmEmp = new EmployeeViewModel();
            //vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
            //vmEmp.Salary = emp.Salary.ToString("C");
            //if (emp.Salary>15000)
            //{
            //    vmEmp.SalaryColor = "yellow";
            //} else
            //{
            //    vmEmp.SalaryColor = "green";
            //}

            //vmEmp.UserName = "Admin";
            //ViewBag.Employee = emp;
            //ViewData["Employee"] = emp;
            return View("MyView", employeeListViewModel);
        }

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
    }
}