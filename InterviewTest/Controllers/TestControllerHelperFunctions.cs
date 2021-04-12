using InterviewTest.Models;
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

namespace InterviewTest.Controllers
{
    public partial class TestController : Controller
    {
        private static readonly int recordsPerPage = 100;
        private int pageNumber = 1;
        private double overallNumberOfRowsInTable;
        private int numberOfPages;


        public async Task<ActionResult> NextPage()
        {
            ActionResult ar;
            if (pageNumber < numberOfPages)
            {
                ++pageNumber;
                ar = await PartTwoB();
                return ar;
            }
            else
            {
                ar = await PartTwoB();
                return ar;
            }
        }

        public async Task<ActionResult> PreviousPage()
        {
            ActionResult ar;
            if (pageNumber > 0)
            {
                --pageNumber;
                ar = await PartTwoB();
                return ar;
            }
            else
            {
                ar = await PartTwoB();
                return ar;
            }
        }

        //public void NextPage() 
        //{
        //    if (pageNumber < numberOfPages) 
        //    { 
        //        ++pageNumber; 
        //    }
        //    else
        //    {
        //        return;
        //    }    
        //}

        //public void PreviousPage() 
        //{
        //    if (pageNumber > 0)
        //    {
        //        --pageNumber;
        //    }
        //    else 
        //    {
        //        return;
        //    }
        //}

        //returns maximum number of pages allowed in table based on number of rows in each page
        public void SetNumberOfPages()
        {
            double n = overallNumberOfRowsInTable / recordsPerPage;
            int maxNumberOfPages = 0;
            if (overallNumberOfRowsInTable % recordsPerPage > 0)
            {
                maxNumberOfPages = (int)n;
                ++maxNumberOfPages;
            }
            numberOfPages = maxNumberOfPages;
        }

        public async Task<List<PartTwoBModel>> SolvePartTwoBWithLINQAsync()
        {
            InterviewTestEntities interviewTestEntities = new InterviewTestEntities();
            IEnumerable<Employee> employees = interviewTestEntities.Employees;
            IEnumerable<Office> offices = interviewTestEntities.Offices;
            IEnumerable<Position> positions = interviewTestEntities.Positions;
            
            List<PartTwoBModel> p2bList = new List<PartTwoBModel>();

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

                overallNumberOfRowsInTable = employeesAndTheirOfficesAndPositions.Count();
                SetNumberOfPages();

                //use pagination here
                var q = Paginate(employeesAndTheirOfficesAndPositions, pageNumber);

                //convert LINQ query IEnumerable to a List and iterate over it
                foreach(var item in q.ToList())
                {
                    //add new object to p2bList and assign each object properties to that of employeesAndTheirOfficesAndPositions
                    p2bList.Add(new PartTwoBModel() 
                    {
                        firstName = item.firstName,
                        lastName = item.lastName,
                        officeName = item.officeName,
                        position = item.position
                    });
                }
            });
            await execute;
            return p2bList;
        }

        private IEnumerable<dynamic> Paginate(IEnumerable<dynamic> queryList, int pageNumber)
        {
            var lastNameContraintQuery = from item in queryList orderby item.lastName select item;

            //page 1: 1-100
            //page 2: 101-200
            //page 3: 201-300
            var page = lastNameContraintQuery.Skip((pageNumber*recordsPerPage)-100).Take(recordsPerPage);
            return page;
        }

        public async Task<ActionResult> SolvePartTwoBWithoutLINQAsync()
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