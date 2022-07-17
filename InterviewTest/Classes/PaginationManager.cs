using MVC_Sample.Classes;
using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVC_Sample.Controllers
{
    //[System.Web.Script.Services.ScriptService]
    public class PaginationManager
    {
        readonly InterviewTestEntities interviewTestEntities = new InterviewTestEntities();
        readonly IEnumerable<Employee> employees;
        readonly IEnumerable<Office> offices;
        readonly IEnumerable<Position> positions;
        readonly List<EmployeeViewModel> paginateList;

        public PaginationManager()
        {
            employees = interviewTestEntities.Employees;
            offices = interviewTestEntities.Offices;
            positions = interviewTestEntities.Positions;
            paginateList = new List<EmployeeViewModel>();
        }

        public List<EmployeeViewModel> GetPaginateList(int pageNumber)
        {
            paginateList.Clear();
            var employeesAndTheirOfficesAndPositions =

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

            Pagination p = new Pagination(employeesAndTheirOfficesAndPositions.Count(), 100);
            p.SetNumberOfPages();

            //use pagination here
            var q = p.Paginate(employeesAndTheirOfficesAndPositions, pageNumber);

            //convert LINQ query IEnumerable to a List and iterate over it
            foreach (var item in q.ToList())
            {
                //add new object to p2bList and assign each object properties to that of employeesAndTheirOfficesAndPositions
                this.paginateList.Add(new EmployeeViewModel()
                {
                    firstName = item.firstName,
                    lastName = item.lastName,
                    officeName = item.officeName,
                    position = item.position
                });
            }
            return this.paginateList;
        }

        public async Task<List<EmployeeViewModel>> GetPaginateListAsync(int pageNumber)
        {
            paginateList.Clear();

            Task execute = Task.Run(() =>
            {
                var employeesAndTheirOfficesAndPositions =

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

                Pagination p = new Pagination(employeesAndTheirOfficesAndPositions.Count(), 100);
                p.SetNumberOfPages();

                //use pagination here
                var q = p.Paginate(employeesAndTheirOfficesAndPositions, pageNumber);

                //convert LINQ query IEnumerable to a List and iterate over it
                foreach (var item in q.ToList())
                {
                    //add new object to p2bList and assign each object properties to that of employeesAndTheirOfficesAndPositions
                    this.paginateList.Add(new EmployeeViewModel()
                    {
                        firstName = item.firstName,
                        lastName = item.lastName,
                        officeName = item.officeName,
                        position = item.position
                    });
                }
            });
            await execute;
            return this.paginateList;
        }
    }
}