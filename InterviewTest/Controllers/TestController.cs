using InterviewTest.Models;
using System;
using System.Collections.Generic;
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
            Applicant form = new Applicant();
            return View();
        }

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