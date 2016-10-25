using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MissionSite.Controllers
{
    public class MissionController : Controller
    {
        // GET: Mission
        public ActionResult Index(string missionName)
        {
            if (missionName != null)
            {
                ViewBag.Instrument = missionName;

                switch (missionName)
                {
                    case "Bolivia, Cochabamba":
                        ViewBag.President = "";
                        ViewBag.Address = "";
                        ViewBag.Language = "";
                        ViewBag.Climate = "";
                        ViewBag.DominateReligion = "";
                        ViewBag.Flag = "";
                        break;
                    case "Louisiana, Baton Rouge":
                        ViewBag.President = "";
                        ViewBag.Address = "";
                        ViewBag.Language = "";
                        ViewBag.Climate = "";
                        ViewBag.DominateReligion = "";
                        ViewBag.Flag = "";
                        break;
                    case "Philippines, Tacloban":
                        ViewBag.President = "";
                        ViewBag.Address = "";
                        ViewBag.Language = "";
                        ViewBag.Climate = "";
                        ViewBag.DominateReligion = "";
                        ViewBag.Flag = "";
                        break;
                    case "Colorado, Fort Collins":
                        ViewBag.President = "";
                        ViewBag.Address = "";
                        ViewBag.Language = "";
                        ViewBag.Climate = "";
                        ViewBag.DominateReligion = "";
                        ViewBag.Flag = "";
                        break;
                }
                return View();
            }
            else
            {
                return RedirectToAction("Missions", "Home");
            }
        }
    }
}