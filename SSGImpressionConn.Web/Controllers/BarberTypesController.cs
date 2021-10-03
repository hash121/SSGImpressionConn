using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSGImpressionConn.Web.DataModel;

namespace SSGImpressionConn.Web.Controllers
{
    public class BarberTypesController : Controller
    {
        private DBContextEntities db = new DBContextEntities();

        // GET: BarberTypes
        public ActionResult Index()
        {
            return View(db.BarberTypes.ToList());
        }

        // GET: BarberTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarberType barberType = db.BarberTypes.Find(id);
            if (barberType == null)
            {
                return HttpNotFound();
            }
            return View(barberType);
        }

        // GET: BarberTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BarberTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BarberType1")] BarberType barberType)
        {
            if (ModelState.IsValid)
            {
                db.BarberTypes.Add(barberType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barberType);
        }

        // GET: BarberTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarberType barberType = db.BarberTypes.Find(id);
            if (barberType == null)
            {
                return HttpNotFound();
            }
            return View(barberType);
        }

        // POST: BarberTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BarberType1")] BarberType barberType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barberType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barberType);
        }

        // GET: BarberTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarberType barberType = db.BarberTypes.Find(id);
            if (barberType == null)
            {
                return HttpNotFound();
            }
            return View(barberType);
        }

        // POST: BarberTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BarberType barberType = db.BarberTypes.Find(id);
            db.BarberTypes.Remove(barberType);
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
