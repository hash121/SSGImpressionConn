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
    public class AppointmentDetailsController : Controller
    {
        private DBContextEntities db = new DBContextEntities();

        // GET: AppointmentDetails
        public ActionResult Index()
        {
            var appointmentDetails = db.AppointmentDetails.Include(a => a.BarberDetail).Include(a => a.ServiceDetail).Include(a => a.ShopDetail).Include(a => a.Status);
            ViewBag.Status = db.Status.ToList();
            return View(appointmentDetails.ToList());
        }

        // GET: AppointmentDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentDetail appointmentDetail = db.AppointmentDetails.Find(id);
            if (appointmentDetail == null)
            {
                return HttpNotFound();
            }
            return View(appointmentDetail);
        }

        // GET: AppointmentDetails/Create
        public ActionResult Create()
        {
            ViewBag.BarberDetailID = new SelectList(db.BarberDetails, "ID", "Name");
            ViewBag.ServiceDetailID = new SelectList(db.ServiceDetails, "ID", "ServiceName");
            ViewBag.ShopDetailID = new SelectList(db.ShopDetails, "ID", "ShopName");
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Status1");
            return View();
        }

        // POST: AppointmentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AppointmentID,Name,AppointmentDate,Phone,BarberDetailID,ShopDetailID,ServiceDetailID,Description,EmailID,AppointmentTime,StatusID")] AppointmentDetail appointmentDetail)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentDetails.Add(appointmentDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BarberDetailID = new SelectList(db.BarberDetails, "ID", "Name", appointmentDetail.BarberDetailID);
            ViewBag.ServiceDetailID = new SelectList(db.ServiceDetails, "ID", "ServiceName", appointmentDetail.ServiceDetailID);
            ViewBag.ShopDetailID = new SelectList(db.ShopDetails, "ID", "ShopName", appointmentDetail.ShopDetailID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Status1", appointmentDetail.StatusID);
            return View(appointmentDetail);
        }

        // GET: AppointmentDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentDetail appointmentDetail = db.AppointmentDetails.Find(id);
            if (appointmentDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BarberDetailID = new SelectList(db.BarberDetails, "ID", "Name", appointmentDetail.BarberDetailID);
            ViewBag.ServiceDetailID = new SelectList(db.ServiceDetails, "ID", "ServiceName", appointmentDetail.ServiceDetailID);
            ViewBag.ShopDetailID = new SelectList(db.ShopDetails, "ID", "ShopName", appointmentDetail.ShopDetailID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Status1", appointmentDetail.StatusID);
            return View(appointmentDetail);
        }

        // POST: AppointmentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AppointmentID,Name,AppointmentDate,Phone,BarberDetailID,ShopDetailID,ServiceDetailID,Description,EmailID,AppointmentTime,StatusID")] AppointmentDetail appointmentDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BarberDetailID = new SelectList(db.BarberDetails, "ID", "Name", appointmentDetail.BarberDetailID);
            ViewBag.ServiceDetailID = new SelectList(db.ServiceDetails, "ID", "ServiceName", appointmentDetail.ServiceDetailID);
            ViewBag.ShopDetailID = new SelectList(db.ShopDetails, "ID", "ShopName", appointmentDetail.ShopDetailID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Status1", appointmentDetail.StatusID);
            return View(appointmentDetail);
        }

        // GET: AppointmentDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentDetail appointmentDetail = db.AppointmentDetails.Find(id);
            if (appointmentDetail == null)
            {
                return HttpNotFound();
            }
            return View(appointmentDetail);
        }

        // POST: AppointmentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointmentDetail appointmentDetail = db.AppointmentDetails.Find(id);
            db.AppointmentDetails.Remove(appointmentDetail);
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
