using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project2.DAL;
using Project2.Models;

namespace Project2.Controllers
{
    [Authorize]
    public class MissionQuestionsController : Controller
    {
        private AzureContext db = new AzureContext();

        // MissionQuestions default view
        public ActionResult Index()
        {
            return View(db.MissionQuestions.ToList());
        }

        // GET: MissionQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestion missionQuestion = db.MissionQuestions.Find(id);
            if (missionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestion);
        }

        // GET: MissionQuestions/Create
        public ActionResult Create(int MissionID)
        {
            IEnumerable<MissionQuestion> MaxID = db.Database.SqlQuery<MissionQuestion>(
                @"Select *
                    FROM MissionQuestion"
                );

            MissionQuestion CreateQuestion = new MissionQuestion();
            CreateQuestion.MissionQuestionID = MaxID.Count() + 1;
            CreateQuestion.MissionID = MissionID;
            
            return View(CreateQuestion);
        }

        // POST: MissionQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MissionQuestionID,MissionID,UserID,Question,Ansswer")] MissionQuestion missionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.MissionQuestions.Add(missionQuestion);
                db.SaveChanges();
                return RedirectToAction("QuestionPage", "UserMissionQuestions", new { id = missionQuestion.MissionID });
            }

            return View(missionQuestion);
        }

        // GET: MissionQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestion missionQuestion = db.MissionQuestions.Find(id);
            if (missionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestion);
        }

        // POST: MissionQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MissionQuestionID,MissionID,UserID,Question,Ansswer")] MissionQuestion missionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missionQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QuestionPage","UserMissionQuestions", new { id = missionQuestion.MissionID });
            }
            return View(missionQuestion);
        }

        // GET: MissionQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestion missionQuestion = db.MissionQuestions.Find(id);
            if (missionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestion);
        }

        // POST: MissionQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MissionQuestion missionQuestion = db.MissionQuestions.Find(id);
            db.MissionQuestions.Remove(missionQuestion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [Authorize]
        public ActionResult MissionFAQ(int id)
        {
            Mission mission = db.Missions.Find(id);
            return View(mission);
        }
    }
}
