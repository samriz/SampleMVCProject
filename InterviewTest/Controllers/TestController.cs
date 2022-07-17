using MVC_Sample.Classes;
using MVC_Sample.Models;
using Newtonsoft.Json;
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
        PaginationManager pm;
        EmployeeManager em;
        public TestController()
        {
            pm = new PaginationManager();
            em = new EmployeeManager();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> FormPage(Applicant applicant)
        {
            InterviewTestEntities CompanyEntities = new InterviewTestEntities();

            var applicants = CompanyEntities.Applicants;

            if (!ModelState.IsValid) return View();

            Task applicantAdder = Task.Run(() =>
            {
                //server-side validation
                try
                {
                    //insert valid applicant into applicants collection i.e. "Applicant" table in DB
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

        [HttpGet]
        public async Task<ActionResult> PaginationPage()
        {
            EmployeeViewModels evm = new EmployeeViewModels
            {
                //Employee: first name, last name, office name, position
                Employees = await pm.GetPaginateListAsync(1)
            };
            return View(evm);
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

        [HttpPost]
        public string GetPageList(int pageNumber)
        {
            EmployeeViewModels evm = new EmployeeViewModels
            {
                //Employee: first name, last name, office name, position
                Employees = pm.GetPaginateList(pageNumber)
            };

            return JsonConvert.SerializeObject(evm.Employees.ToArray());
        }

        [HttpPost]
        public string GetAllEmployees()
        {
            EmployeeViewModels evm = new EmployeeViewModels
            {
                //Employee: first name, last name, office name, position
                Employees = em.getEmployees()
            };
            return JsonConvert.SerializeObject(evm.Employees.ToArray());
        }
    }
}