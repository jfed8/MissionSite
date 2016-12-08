using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MissionSite.Models;
using MissionSite.DAL;
using System.Threading.Tasks;
using System.Net;
using System.Data.Entity;

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

        // GET: MissionQuestions/Edit/5
        public ActionResult Edit(int? questionid)
        {
            if (questionid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestion.Find(questionid);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestions);
        }

        // POST: MissionQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MissionQuestionID,MissionID,UserID,Question,Answer")] MissionQuestions missionQuestions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missionQuestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FAQ", "Mission", new { missionID = missionQuestions.MissionID });
            }
            return View(missionQuestions);
        }
    }
}