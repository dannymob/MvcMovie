using CodeProject.Filters;
using CodeProject.Models;
using CodeProject.ViewModel;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace CodeProject.Controllers
{
    public class BulkUploadController : Controller
    {
        [AdminFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        [AdminFilter]
        public ActionResult Upload(FileUploadViewModel model)
        {
            List<employee> employees = GetEmployees(model);
            EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
            bal.UploadEmployees(employees);
            return RedirectToAction("Index", "Employee");
        }

        private List<employee> GetEmployees(FileUploadViewModel model)
        {
            List<employee> employees = new List<employee>();
            StreamReader csvreader = new StreamReader(model.fileUpload.InputStream);
            csvreader.ReadLine();
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                var values = line.Split(',');
                employee e = new employee();
                e.FirstName = values[0];
                e.LastName = values[1];
                e.Salary = int.Parse(values[2]);
                employees.Add(e);
            }

            return employees;
        }
    }
}