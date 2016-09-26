using System.Collections.Generic;

namespace CodeProject.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp = new Employee();
            emp.FirstName = "Mr.";
            emp.LastName = "Smith";
            emp.Salary = 14000;
            employees.Add(emp);
            return  employees ;
        } 

    }
}