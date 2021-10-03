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
    public class BarberDetailsController : Controller
    {
        private DBContextEntities db = new DBContextEntities();

        // GET: BarberDetails
        public ActionResult Index()
        {
            var barberDetails = db.BarberDetails.Include(b => b.BarberType).Include(b => b.ShopDetail);
            return View(barberDetails.ToList());
        }

        // GET: BarberDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarberDetail barberDetail = db.BarberDetails.Find(id);
            if (barberDetail == null)
            {
                return HttpNotFound();
            }
            return View(barberDetail);
        }

        // GET: BarberDetails/Create
        public ActionResult Create()
        {
            ViewBag.BarberTypeID = new SelectList(db.BarberTypes, "ID", "BarberType1");
            ViewBag.ShopDetailID = new SelectList(db.ShopDetails, "ID", "ShopName");
            return View();
        }

        // POST: BarberDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,Phone,EmailID,BarberTypeID,ShopDetailID")] BarberDetail barberDetail)
        {
            if (ModelState.IsValid)
            {
                db.BarberDetails.Add(barberDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BarberTypeID = new SelectList(db.BarberTypes, "ID", "BarberType1", barberDetail.BarberTypeID);
            ViewBag.ShopDetailID = new SelectList(db.ShopDetails, "ID", "ShopName", barberDetail.ShopDetailID);
            return View(barberDetail);
        }

        // GET: BarberDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarberDetail barberDetail = db.BarberDetails.Find(id);
            if (barberDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BarberTypeID = new SelectList(db.BarberTypes, "ID", "BarberType1", barberDetail.BarberTypeID);
            ViewBag.ShopDetailID = new SelectList(db.ShopDetails, "ID", "ShopName", barberDetail.ShopDetailID);
            return View(barberDetail);
        }

        // POST: BarberDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,Phone,EmailID,BarberTypeID,ShopDetailID")] BarberDetail barberDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barberDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BarberTypeID = new SelectList(db.BarberTypes, "ID", "BarberType1", barberDetail.BarberTypeID);
            ViewBag.ShopDetailID = new SelectList(db.ShopDetails, "ID", "ShopName", barberDetail.ShopDetailID);
            return View(barberDetail);
        }

        // GET: BarberDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarberDetail barberDetail = db.BarberDetails.Find(id);
            if (barberDetail == null)
            {
                return HttpNotFound();
            }
            return View(barberDetail);
        }

        // POST: BarberDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BarberDetail barberDetail = db.BarberDetails.Find(id);
            db.BarberDetails.Remove(barberDetail);
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
