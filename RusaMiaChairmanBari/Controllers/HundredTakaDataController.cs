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
    public class HundredTakaDataController : Controller
    {

        private RusaMiaBariDBEntities db = new RusaMiaBariDBEntities();

        // GET: HundredTakaData
        
        public ActionResult Index()
        {
            return View(db.C100TakaData.ToList());
        }

        // GET: HundredTakaData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C100TakaData c100TakaData = db.C100TakaData.Find(id);
            if (c100TakaData == null)
            {
                return HttpNotFound();
            }
            return View(c100TakaData);
        }

        // GET: HundredTakaData/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HundredTakaData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "id,Name,FatherName,TotalMonth,Amount,NameOfPaidMonth,PaymentDate")] C100TakaData c100TakaData)
        {
            if (ModelState.IsValid)
            {
                db.C100TakaData.Add(c100TakaData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(c100TakaData);
        }

        // GET: HundredTakaData/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C100TakaData c100TakaData = db.C100TakaData.Find(id);
            if (c100TakaData == null)
            {
                return HttpNotFound();
            }
            return View(c100TakaData);
        }

        // POST: HundredTakaData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "id,Name,FatherName,TotalMonth,Amount,NameOfPaidMonth,PaymentDate")] C100TakaData c100TakaData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c100TakaData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c100TakaData);
        }

        // GET: HundredTakaData/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C100TakaData c100TakaData = db.C100TakaData.Find(id);
            if (c100TakaData == null)
            {
                return HttpNotFound();
            }
            return View(c100TakaData);
        }

        // POST: HundredTakaData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            C100TakaData c100TakaData = db.C100TakaData.Find(id);
            db.C100TakaData.Remove(c100TakaData);
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
