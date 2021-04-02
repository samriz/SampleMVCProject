using InterviewTest.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewTest.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartOne()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PartOne(Applicant applicant)
        {
            InterviewTestEntities interviewTestEntities = new InterviewTestEntities();
            IQueryable<Applicant> applicants = interviewTestEntities.Applicants;

            interviewTestEntities.Applicants.Add(applicant);
            interviewTestEntities.SaveChangesAsync();
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SaveFormData()
        //{
        //    Applicant applicant = new Applicant();
        //    applicant.firstName = HttpContext.Request.Form["firstName"].ToString();
        //    applicant.middleName = HttpContext.Request.Form["middleName"].ToString();
        //    applicant.lastName = HttpContext.Request.Form["lastName"].ToString();
        //    applicant.positionId = Convert.ToInt32(HttpContext.Request.Form["positionId"]);
        //    applicant.comments = HttpContext.Request.Form["comments"].ToString();
        //    applicant.remote = Convert.ToBoolean(HttpContext.Request.Form["remote"]);
        //    SaveToDatabase(ref applicant);
        //    return View();
        //}

        //private void SaveToDatabase(ref Applicant applicant)
        //{

        //    SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\srizv\OneDrive\Documents\interview-test\InterviewTest\App_Data\InterviewTest.mdf;Integrated Security=True;Connect Timeout=30");
        //    string query = "INSERT INTO Applicant(firstName, middleName, lastName, positionId, comments, remote) values ('" + applicant.firstName + "','" + applicant.middleName + "','" + applicant.lastName + "','" + applicant.positionId + "','" + applicant.comments + "','" + applicant.remote + "')";

        //    SqlCommand cmd = new SqlCommand(query, sqlConnection);
        //    sqlConnection.Open();
        //    //int i = cmd.ExecuteNonQuery();
        //    sqlConnection.Close();
        //}

        public ActionResult PartTwoA()
        {
            return View();
        }

        
        public ActionResult PartTwoB()
        {
            InterviewTestEntities interviewTestEntities = new InterviewTestEntities();
            IEnumerable<Employee> employees = interviewTestEntities.Employees;
            IEnumerable<Office> offices = interviewTestEntities.Offices;
            IEnumerable<Position> positions = interviewTestEntities.Positions;

            var q = from employee in employees.Take(100) select employee;


            //use LINQ
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