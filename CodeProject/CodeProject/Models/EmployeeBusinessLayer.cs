using System.Collections.Generic;
using CodeProject.DataAccessLayer;
using System.Linq;

namespace CodeProject.Models
{
    public class EmployeeBusinessLayer
    {
        public List<employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        } 

    }
}