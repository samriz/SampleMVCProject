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
    public class TestController : Controller
    {
        public ActionResult Index(){return View();}

        public ActionResult PartOne(){return View();}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PartOne(Applicant applicant)
        {
            InterviewTestEntities interviewTestEntities = new InterviewTestEntities();
            var applicants = interviewTestEntities.Applicants;
            if (!ModelState.IsValid) return View();
            
            Task applicantAdder = Task.Run(() =>
            {
                try
                {
                    applicants.Add(applicant);
                }
                catch (DbEntityValidationException e)
                {
                    ViewBag.MyMessage(e.Message);
                }
            });
            await applicantAdder;
            return View();
        }

        public ActionResult PartTwoA() {return View();}

        //public ActionResult PartTwoB()
        //{
        //    return View();
        //}

        public async Task<ActionResult> PartTwoB()
        {
            //ActionResult ar = await NotLINQAsync();
            ActionResult ar = await UsingLINQAsync();
            return ar;
        }

        public async Task<ActionResult> UsingLINQAsync()
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
                //convert LINQ query IEnumerable to a List and iterate over it
                foreach(var item in employeesAndTheirOfficesAndPositions.ToList())
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
            return View(p2bList);
        }

        public async Task<ActionResult> NotLINQAsync()
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

        [HandleError(View = "PartThreeError")]
        public ActionResult PartThree()
        {
            List<City> cities = CityHelper.Populate();
            return View(cities);
        }
    }
}