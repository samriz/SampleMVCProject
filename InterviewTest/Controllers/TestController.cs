using InterviewTest.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
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
            var applicants = interviewTestEntities.Applicants;
            if (!ModelState.IsValid)
            {
                return View();
            }
            int entriessaved = 0;
            try
            {
                applicants.Add(applicant);
                entriessaved = interviewTestEntities.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                ViewBag.MyMessage(e.Message);
            }
            return View();
        }

        public ActionResult PartTwoA()
        {
            return View();
        }
       
        public ActionResult PartTwoB()
        {
            //InterviewTestEntities interviewTestEntities = new InterviewTestEntities();
            //IEnumerable<Employee> employees = interviewTestEntities.Employees;
            //IEnumerable<Office> offices = interviewTestEntities.Offices;
            //IEnumerable<Position> positions = interviewTestEntities.Positions;

            ////linq
            //var q = from employee in employees.Take(100) select employee;         
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