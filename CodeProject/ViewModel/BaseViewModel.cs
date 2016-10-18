using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeProject.ViewModel
{
    public class BaseViewModel
    {
        public string UserName { get; set; }

        public int Year = DateTime.Now.Year;
        public string CompanyName = "The Twins";
    }
}