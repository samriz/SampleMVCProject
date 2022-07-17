using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MVC_Sample.Models;

namespace MVC_Sample.Classes
{
    public class EmployeeManager
    {
        readonly InterviewTestEntities interviewTestEntities = new InterviewTestEntities();
        readonly IEnumerable<Employee> employees;
        readonly IEnumerable<Office> offices;
        readonly IEnumerable<Position> positions;
        //readonly List<EmployeeViewModel> employeeList;
        public EmployeeManager()
        {
            employees = interviewTestEntities.Employees;
            offices = interviewTestEntities.Offices;
            positions = interviewTestEntities.Positions;
            //employeeList = new List<EmployeeViewModel>();
        }

        public List<EmployeeViewModel> getEmployees()
        {
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            var query =

                from employee in employees
                join office in offices on employee.officeId equals office.id
                join position in positions on employee.positionId equals position.id
                select new
                {
                    employee.firstName,
                    employee.lastName,
                    office.officeName,
                    position.position
                };
            foreach (var employee in query.ToList())
            {
                //add new object to p2bList and assign each object properties to that of employeesAndTheirOfficesAndPositions
                employeeList.Add(new EmployeeViewModel()
                {
                    firstName = employee.firstName,
                    lastName = employee.lastName,
                    officeName = employee.officeName,
                    position = employee.position
                });
            }
            return employeeList;
        }
    }
}