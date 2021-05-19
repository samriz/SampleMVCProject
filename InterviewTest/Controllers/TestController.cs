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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> FormPage(Applicant applicant)
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
        public async Task<ActionResult> PaginationPage()
        {
            PaginationModel paginationModel = new PaginationModel
            {
                //Employee: first name, last name, office name, position
                Employees = await PaginationAsync()
            };
            return View(paginationModel);
        }
        public ActionResult Index() { return View(); }
        public ActionResult FormPage() { return View(); }
        public ActionResult PartTwoA() { return View(); }
        [HandleError(View = "PartThreeError")]
        public ActionResult PartThree()
        {
            List<City> cities = CityHelper.Populate();
            return View(cities);
        }
    }
}