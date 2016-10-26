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
                ViewBag.Name = missionName;

                switch (missionName)
                {
                    case "Bolivia, Cochabamba":
                        ViewBag.President = "Mark W. Hansen";
                        ViewBag.Address = "Casilla de Correo 1375 \nCochabamba, Cochabamba \nBolivia 591-4-411-7207";
                        ViewBag.Language = "Spanish";
                        ViewBag.Climate = "Mild";
                        ViewBag.DominateReligion = "Catholic";
                        ViewBag.Flag = "../../img/bolivia.png";
                        break;
                    case "Louisiana, Baton Rouge":
                        ViewBag.President = "Reed H. Hansen";
                        ViewBag.Address = "12025 Justice Ave \nBaton Rouge, LA 70816 \nUnited States";
                        ViewBag.Language = "English";
                        ViewBag.Climate = "Humid Subtropical";
                        ViewBag.DominateReligion = "Catholic";
                        ViewBag.Flag = "~/img/louisiana.png";
                        break;
                    case "Philippines, Tacloban":
                        ViewBag.President = "Wayne Maurer";
                        ViewBag.Address = "6000 Maharlika Way \nFatima Village, Leyte \nPhilippines";
                        ViewBag.Language = "Cebauno & Waray Waray";
                        ViewBag.Climate = "Tropical";
                        ViewBag.DominateReligion = "Catholic";
                        ViewBag.Flag = "../img/philippinesFlag.png";
                        break;
                    case "Colorado, Fort Collins":
                        ViewBag.President = "Sean S. McMurray";
                        ViewBag.Address = "Colorado Fort Collins Mission \n500 Hillspire Dr \nWindsor CO 80550 \nUnited States";
                        ViewBag.Language = "English";
                        ViewBag.Climate = "Mild";
                        ViewBag.DominateReligion = "Catholic";
                        ViewBag.Flag = "~/img/coloradoFlag.png";
                        break;
                }
                return View();
            }
            else
            {
                return RedirectToAction("Missions", "Mission");
            }
        }

        public ActionResult Missions()
        {
            return View();
        }
    }
}