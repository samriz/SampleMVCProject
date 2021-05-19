using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Sample.Models
{
    public class PaginationModel
    {
        //Employee: first name, last name, office name, position
        public List<EmployeeViewModel> Employees { get; set; }
    }
}