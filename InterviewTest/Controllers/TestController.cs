using InterviewTest.Models;
using System;
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

        

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SaveFormData()
        //{
        //    Applicant applicant = new Applicant();
        //    applicant.firstName = HttpContext.Request.Form["firstName"].ToString();
        //    applicant.middleName = HttpContext.Request.Form["middleName"].ToString();
        //    applicant.lastName = HttpContext.Request.Form["lastName"].ToString();
        //    applicant.positionID = Convert.ToInt32(HttpContext.Request.Form["positionId"]);
        //    applicant.comments = HttpContext.Request.Form["comments"].ToString();
        //    applicant.isRemote = Convert.ToBoolean(HttpContext.Request.Form["remote"]);
        //    SaveToDatabase(ref applicant);
        //    return View();
        //}

        //private void SaveToDatabase(ref Applicant applicant)
        //{
            
        //    SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\srizv\OneDrive\Documents\interview-test\InterviewTest\App_Data\InterviewTest.mdf;Integrated Security=True;Connect Timeout=30");
        //    string query = "INSERT INTO Applicant(firstName, middleName, lastName, positionId, comments, remote) values ('"  + applicant.firstName + "','" + applicant.middleName + "','" + applicant.lastName + "','" + applicant.positionID + "','" + applicant.comments + "','" + applicant.isRemote + "')";
            
        //    SqlCommand cmd = new SqlCommand(query, sqlConnection);
        //    sqlConnection.Open();
        //    //int i = cmd.ExecuteNonQuery();
        //    sqlConnection.Close();
        //}

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveFormData(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                string constr = ConfigurationManager.ConnectionStrings[@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\srizv\OneDrive\Documents\interview-test\InterviewTest\App_Data\InterviewTest.mdf;Integrated Security=True;Connect Timeout=30"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "INSERT INTO Applicant(firstName, middleName, lastName, positionId, comments, remote) VALUES(@firstName, @middleName, lastName, positionId, comments, remote)";
                    query += " SELECT SCOPE_IDENTITY()";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@firstName", applicant.firstName);
                        cmd.Parameters.AddWithValue("@middleName", applicant.middleName);
                        cmd.Parameters.AddWithValue("@lastName", applicant.lastName);
                        cmd.Parameters.AddWithValue("@positionId", applicant.positionID);
                        cmd.Parameters.AddWithValue("@comments", applicant.comments);
                        cmd.Parameters.AddWithValue("@remote", applicant.isRemote);
                        con.Close();
                    }
                }
            }
            ModelState.Clear();
            return View();
        }*/

        public ActionResult PartTwoA()
        {
            return View();
        }

        public ActionResult PartTwoB()
        {
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