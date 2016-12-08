using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MissionSite.Models;
using MissionSite.DAL;
using System.Threading.Tasks;
using System.Net;

namespace MissionSite.Controllers
{
    public class MissionController : Controller
    {
        private MissionaryContext db = new MissionaryContext();

        // GET: Mission
        public ActionResult MissionDetails(string missionID)
        {
            if (missionID != null)
            {
                IEnumerable<Missions> SelectedMission =
                db.Database.SqlQuery<Missions>(
                "Select MissionID, MissionName, MissionPresident, MissionStreet1, " +
                "MissionStreet2, MissionCountryCode, MissionLanguage, MissionClimate, " +
                "MissionReligion, MissionFlag " +
                "FROM Missions " +
                "WHERE MissionID = " + missionID);
                return View(SelectedMission);
            }
            else
            {
                return RedirectToAction("Missions", "Mission");
            }
        }

        public ActionResult Missions()
        {
            return View(db.Mission.ToList());
        }

        [Authorize]
        public ActionResult FAQ(string missionID)
        {
            // Do something to get the information on the questions.
            if (missionID != null)
            {
                IEnumerable<MissionQuestions> Questions =
                db.Database.SqlQuery<MissionQuestions>(
                "Select MissionQuestionID, MissionID, UserID, Question, Answer " +
                "FROM MissionQuestions " +
                "WHERE MissionID = '" + missionID + "'");
                return View(Questions);
            }
            else
            {
                return RedirectToAction("Missions", "Mission");
            }

        }

        [HttpGet]
        public ActionResult Edit(int? questionid)
        {
            if (questionid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions question = db.MissionQuestion.Find(questionid);
            
            if(question ==null)
            {
                return HttpNotFound();
            }

            return View(question);
        }

        [HttpPost]
        public ActionResult Edit(MissionQuestions model)
        {
            return RedirectToAction("FAQ", "Mission", new { missionID = @model.MissionID });
        }
    }
}