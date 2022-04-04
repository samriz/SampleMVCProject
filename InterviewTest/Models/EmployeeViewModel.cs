using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Sample.Models
{
    public class EmployeeViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string officeName { get; set; }
        public string position { get; set; }
    }
    public class EmployeeViewModels
    {
        //Employee: first name, last name, office name, position
        public List<EmployeeViewModel> Employees { get; set; }
    }
}