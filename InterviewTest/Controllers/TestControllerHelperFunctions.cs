using MVC_Sample.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_Sample.Controllers
{
    public partial class TestController : Controller
    {
        public async Task<List<EmployeeViewModel>> PaginationAsync()
        {
            InterviewTestEntities interviewTestEntities = new InterviewTestEntities();
            IEnumerable<Employee> employees = interviewTestEntities.Employees;
            IEnumerable<Office> offices = interviewTestEntities.Offices;
            IEnumerable<Position> positions = interviewTestEntities.Positions;
            
            List<EmployeeViewModel> paginateList = new List<EmployeeViewModel>();

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
                var q = p.Paginate(employeesAndTheirOfficesAndPositions, 1);

                //convert LINQ query IEnumerable to a List and iterate over it
                foreach(var item in q.ToList())
                {
                    //add new object to p2bList and assign each object properties to that of employeesAndTheirOfficesAndPositions
                    paginateList.Add(new EmployeeViewModel() 
                    {
                        firstName = item.firstName,
                        lastName = item.lastName,
                        officeName = item.officeName,
                        position = item.position
                    });
                }
            });
            await execute;
            return paginateList;
        }

        public async Task<ActionResult> PaginateWithoutLINQAsync()
        {
            InterviewTestEntities interviewTestEntities = new InterviewTestEntities();
            IEnumerable<Employee> employees = interviewTestEntities.Employees;
            IEnumerable<Office> offices = interviewTestEntities.Offices;
            IEnumerable<Position> positions = interviewTestEntities.Positions;

            string connectionString = @"metadata=res://*/Models.InterviewTestEntities.csdl|res://*/Models.InterviewTestEntities.ssdl|res://*/Models.InterviewTestEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\InterviewTest.mdf;integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            //create SQL connection
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //SQL query
            string query = @"select Employee.firstName, Employee.lastName, Office.officeName, Position.position from Employee inner join Office on Employee.officeId = Office.id inner join Position on Position.id = Employee.positionId";

            //build command that will execute SQL query
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            //open connection prior to executing command
            sqlConnection.Open();

            //execute command
            int numberOfRowsAffected = await sqlCommand.ExecuteNonQueryAsync();
            if(numberOfRowsAffected > 0)
            {

            }
            return View();
        }
    }
}