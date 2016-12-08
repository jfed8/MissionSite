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
            if(missionID == "1")
            {
                ViewBag.Latitude = -17.413977;
                ViewBag.Longitude = -66.165321;
            }
            else if(missionID == "2")
            {
                ViewBag.Latitude = 30.451089;
                ViewBag.Longitude = -91.126355;
            }
            else if(missionID == "3")
            {
                ViewBag.Latitude = 11.2543;
                ViewBag.Longitude = 124.9617;
            }
            else
            {
                ViewBag.Latitude = 40.585258;
                ViewBag.Longitude = -105.084419;
            }
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
                //Find mission name to display in breadcrumbe
                int id = Convert.ToInt32(missionID);
                Missions mission = db.Mission.Find(id);
                ViewBag.MissionName = mission.MissionName;
                ViewBag.MissionNumber = mission.MissionID;

                //Queries the database for the list of questions for specified mission
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

            Missions mission = db.Mission.Find(missionQuestions.MissionID);
                ViewBag.MissionName = mission.MissionName;
                ViewBag.MissionNumber = mission.MissionID;

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

        // GET: MissionQuestions/AddQuestion/5
        public ActionResult AddQuestion(int? missionid, int? userid)
        {
            

            ViewBag.Mission = missionid;
            ViewBag.User = userid;
            if (missionid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions newMissionQuestions = new MissionQuestions();
            if (newMissionQuestions == null)
            {
                return HttpNotFound();
            }
            //Find Mission name and id for breadcrumb navigation
            Missions mission = db.Mission.Find(missionid);
            ViewBag.MissionName = mission.MissionName;
            ViewBag.MissionNumber = mission.MissionID;

            return View(newMissionQuestions);
        }

        // POST: MissionQuestions/AddQuestion/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuestion(MissionQuestions missionQuestions, int missionid, int userid)
        {
            missionQuestions.MissionID = missionid;
            missionQuestions.UserID = userid;
            if (ModelState.IsValid)
            {
                db.MissionQuestion.Add(missionQuestions);
                db.SaveChanges();
                return RedirectToAction("FAQ", "Mission", new { missionID = missionQuestions.MissionID });
            }
            return View(missionQuestions);
        }
    }
}