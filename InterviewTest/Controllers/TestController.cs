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

        [HttpGet]
        public async Task<ActionResult> PartTwoB()
        {
            //ActionResult ar = await UsingLINQAsync();
            //return ar;
            List<PartTwoBModel> p2bList = await UsingLINQAsync();
            return View(p2bList);
        }

        [HandleError(View = "PartThreeError")]
        public ActionResult PartThree()
        {
            List<City> cities = CityHelper.Populate();
            return View(cities);
        }
    }
}