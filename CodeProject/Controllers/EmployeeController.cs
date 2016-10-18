using CodeProject.Filters;
using CodeProject.Models;
using CodeProject.ViewModel;
using CodeProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeProject.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        [Authorize]
        public ActionResult index()
        {

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.UserName = User.Identity.Name;

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();
            
            foreach (employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary<10000)
                {
                    empViewModel.SalaryColor = "danger";
                }
                else if (emp.Salary>20000)
                {
                    empViewModel.SalaryColor = "success";
                }
                else
                {
                    empViewModel.SalaryColor = "warning";
                }
                empViewModels.Add(empViewModel);
            }

            employeeListViewModel.Employees = empViewModels;
            return View("Index", employeeListViewModel);
        }

        [AdminFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel employeeListViewModel = new CreateEmployeeViewModel();
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        [AdminFilter]
        public ActionResult SaveEmployee(employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary>0)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        return View("CreateEmployee", vm);
                    }
                    
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }

        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}