using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAPISimple.Models;

namespace TestAPISimple.Controllers
{
    public class RecruiterController : Controller
    {
        BAL bal = new BAL();
        
        // GET: Recruiter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Recruiter recruiter)
        {
            string response = bal.RecruiterRegister(recruiter);

            //return Json(response, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Login", "Recruiter");

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Recruiter recruiter)
        {
            string response = bal.RecruiterLogin(recruiter.RecruiterEmail, recruiter.RecruiterPassword);


            //return Json(response, JsonRequestBehavior.AllowGet);
            return RedirectToAction("ListRecruitments", "Recruitment");
        }

        
    }
}