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
        public ActionResult MissionDetails(string missionName)
        {
            if (missionName != null)
            {
                ViewBag.Instrument = missionName;

                switch (missionName)
                {
                    case "Bolivia, Cochabamba":
                        ViewBag.President = "Mark W. Hansen";
                        ViewBag.Address = "Casilla de Correo 1375 Cochabamba, Cochabamba Bolivia 591-4-411-7207";
                        ViewBag.Language = "Spanish";
                        ViewBag.Climate = "Mild";
                        ViewBag.DominateReligion = "Catholic";
                        ViewBag.Flag = "~/img/bolivia.png";
                        break;
                    case "Louisiana, Baton Rouge":
                        ViewBag.President = "Reed H. Hansen";
                        ViewBag.Address = "12025 Justice Ave Baton Rouge LA 70816 United States";
                        ViewBag.Language = "English";
                        ViewBag.Climate = "Humid Subtropical";
                        ViewBag.DominateReligion = "Catholic";
                        ViewBag.Flag = "~/img/louisiana.png";
                        break;
                    case "Philippines, Tacloban":
                        ViewBag.President = "Wayne Maurer";
                        ViewBag.Address = "6000 Maharlika Way, Fatima Village, Leyte, Philippines";
                        ViewBag.Language = "Cebauno & Waray Waray";
                        ViewBag.Climate = "Tropical";
                        ViewBag.DominateReligion = "Catholic";
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

        public ActionResult Missions()
        {
            return View();
        }
    }
}