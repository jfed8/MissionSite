using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MissionSite.DAL;
using MissionSite.Models;

namespace MissionSite.Controllers
{
    public class HomeController : Controller
    {

        private MissionaryContext db = new MissionaryContext();

        public ActionResult Index()
        {
            return View(db.Mission.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            List<SelectListItem> subjects = new List<SelectListItem>();
            subjects.Add(new SelectListItem { Text = "Missionary Life", Value = "0" });
            subjects.Add(new SelectListItem { Text = "Teaching", Value = "1" });
            subjects.Add(new SelectListItem { Text = "Companions", Value = "3" });
            subjects.Add(new SelectListItem { Text = "Culture", Value = "4" });
            subjects.Add(new SelectListItem { Text = "Choose a Subject", Value = "5", Selected = true });
            ViewBag.subjectNames = subjects;
      
            return View();
        }

    }
}