using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RusaMiaChairmanBari.Models;

namespace RusaMiaChairmanBari.Controllers
{
    [Authorize]
    public class FiftyTakaDataController : Controller
    {
        private RusaMiaBariDBEntities db = new RusaMiaBariDBEntities();
        
        // GET: FiftyTakaData
        public ActionResult Index(string searchName)
        {
            var projects = from pr in db.C50TakaData select pr;

            if (!String.IsNullOrEmpty(searchName))
            {
                projects = projects.Where(c => c.Name.Contains(searchName));
            }

            return View(projects);
        }


        // GET: FiftyTakaData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C50TakaData c50TakaData = db.C50TakaData.Find(id);
            if (c50TakaData == null)
            {
                return HttpNotFound();
            }
            return View(c50TakaData);
        }

        // GET: FiftyTakaData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FiftyTakaData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,FatherName,Month,Amount")] C50TakaData c50TakaData)
        {
            //if (ModelState.IsValid)
            //{
            //    db.C50TakaData.Add(c50TakaData);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            if (ModelState.IsValid)
            {
                db.C50TakaData.Add(c50TakaData);
                db.SaveChanges();
                ViewBag.SuccessMsg = "successfully added";
                return RedirectToAction("Index");
            }

            return View(c50TakaData);
        }

        // GET: FiftyTakaData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C50TakaData c50TakaData = db.C50TakaData.Find(id);
            if (c50TakaData == null)
            {
                return HttpNotFound();
            }
            return View(c50TakaData);
        }

        // POST: FiftyTakaData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,FatherName,Month,Amount")] C50TakaData c50TakaData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c50TakaData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c50TakaData);
        }

        // GET: FiftyTakaData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C50TakaData c50TakaData = db.C50TakaData.Find(id);
            if (c50TakaData == null)
            {
                return HttpNotFound();
            }
            return View(c50TakaData);
        }

        // POST: FiftyTakaData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            C50TakaData c50TakaData = db.C50TakaData.Find(id);
            db.C50TakaData.Remove(c50TakaData);
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
    }
}
