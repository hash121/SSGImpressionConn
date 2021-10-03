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
    public class ShopDetailsController : Controller
    {
        private DBContextEntities db = new DBContextEntities();

        // GET: ShopDetails
        public ActionResult Index()
        {
            var shopDetails = db.ShopDetails.Include(s => s.AppointmentDetails).Include(s => s.BarberDetails);
            return View(shopDetails.ToList());
        }

        // GET: ShopDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopDetail shopDetail = db.ShopDetails.Find(id);
            if (shopDetail == null)
            {
                return HttpNotFound();
            }
            return View(shopDetail);
        }

        // GET: ShopDetails/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.ShopDetails, "ID", "ShopName");
            ViewBag.ID = new SelectList(db.ShopDetails, "ID", "ShopName");
            return View();
        }

        // POST: ShopDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ShopName,Address,ZipCode,Country,State")] ShopDetail shopDetail)
        {
            if (ModelState.IsValid)
            {
                db.ShopDetails.Add(shopDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.ShopDetails, "ID", "ShopName", shopDetail.ID);
            ViewBag.ID = new SelectList(db.ShopDetails, "ID", "ShopName", shopDetail.ID);
            return View(shopDetail);
        }

        // GET: ShopDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopDetail shopDetail = db.ShopDetails.Find(id);
            if (shopDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.ShopDetails, "ID", "ShopName", shopDetail.ID);
            ViewBag.ID = new SelectList(db.ShopDetails, "ID", "ShopName", shopDetail.ID);
            return View(shopDetail);
        }

        // POST: ShopDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ShopName,Address,ZipCode,Country,State")] ShopDetail shopDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.ShopDetails, "ID", "ShopName", shopDetail.ID);
            ViewBag.ID = new SelectList(db.ShopDetails, "ID", "ShopName", shopDetail.ID);
            return View(shopDetail);
        }

        // GET: ShopDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopDetail shopDetail = db.ShopDetails.Find(id);
            if (shopDetail == null)
            {
                return HttpNotFound();
            }
            return View(shopDetail);
        }

        // POST: ShopDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShopDetail shopDetail = db.ShopDetails.Find(id);
            db.ShopDetails.Remove(shopDetail);
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
