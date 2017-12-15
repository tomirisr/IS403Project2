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
    public class UserMissionQuestionsController : Controller
    {
        //this controller takes care of the user questions submitted to the website
        private AzureContext db = new AzureContext();

        // GET: UserMissionQuestions
        public ActionResult Index()
        {
            return View(db.UserMissionQuestions.ToList());
        }

        // GET: UserMissionQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMissionQuestion userMissionQuestion = db.UserMissionQuestions.Find(id);
            if (userMissionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(userMissionQuestion);
        }

        // GET: UserMissionQuestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserMissionQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MissionQuestionID,MissionID,MissionName,MissionPresident,MissionAddress,MissionCity,MissionCountry,DominantReligion,Flag,MissionLanguage,MissionClimate,UserID,UserFirstName,UserLastName,UserEmail,UserPassword,Question,Ansswer")] UserMissionQuestion userMissionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.UserMissionQuestions.Add(userMissionQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userMissionQuestion);
        }

        // GET: UserMissionQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMissionQuestion userMissionQuestion = db.UserMissionQuestions.Find(id);
            if (userMissionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(userMissionQuestion);
        }

        // POST: UserMissionQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MissionQuestionID,MissionID,MissionName,MissionPresident,MissionAddress,MissionCity,MissionCountry,DominantReligion,Flag,MissionLanguage,MissionClimate,UserID,UserFirstName,UserLastName,UserEmail,UserPassword,Question,Ansswer")] UserMissionQuestion userMissionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userMissionQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userMissionQuestion);
        }

        // GET: UserMissionQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMissionQuestion userMissionQuestion = db.UserMissionQuestions.Find(id);
            if (userMissionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(userMissionQuestion);
        }

        // POST: UserMissionQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMissionQuestion userMissionQuestion = db.UserMissionQuestions.Find(id);
            db.UserMissionQuestions.Remove(userMissionQuestion);
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
        public ActionResult QuestionPage(int id)
        {
            //thwe quesry below will return all the data from all three tables and the we will choose which ones we want to show in our view
            IEnumerable<UserMissionQuestion> JoinedTable = db.Database.SqlQuery<UserMissionQuestion>(
               @" SELECT *
FROM Mission INNER JOIN MissionQuestion
                ON Mission.MissionId = MissionQuestion.MissionId
                    INNER JOIN WebUser
                        ON MissionQuestion.UserId = WebUser.UserId
WHERE Mission.MissionId =" + id);
            return View(JoinedTable);
        }
    }
}
