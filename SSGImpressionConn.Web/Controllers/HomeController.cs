using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using SSGImpressionConn.Web.DataModel;

namespace SSGImpressionConn.Web.Controllers
{
    public class HomeController : Controller
    {
        private DBContextEntities db = new DBContextEntities();
        public ActionResult Index()
        {
            var appointmentDetails = db.AppointmentDetails.Include(a => a.BarberDetail).Include(x=>x.AppointService).Include(a => a.ServiceDetail).Include(a => a.ShopDetail).Include(a => a.Status);
            ViewBag.SelectedList = db.AppointServices.ToList();
            
            return View(appointmentDetails.Take(15).OrderByDescending(x=>x.ID).ToList());
        }

        public ActionResult Appointment()
        {
            AppointmentDetail appointmentDetail = new AppointmentDetail();
            appointmentDetail.serviceDetails = db.ServiceDetails.ToList();
            var dta = DateTime.Now.Date;
            ViewBag.AppointDetailID = db.AppointmentDetails.Where(x => x.AppointmentDate == dta && x.SlotStatus == false).ToList();
            ViewBag.TimeSlotID = db.TimeSlots.ToList();
            ViewBag.BarberDetailID = new SelectList(db.BarberDetails, "ID", "Name");
            ViewBag.ServiceDetailID = db.ServiceDetails.ToList();
            return View(appointmentDetail);
        }

        [HttpPost]
        public ActionResult Appointment(AppointmentDetail appointmentDetail)
        {
            try
            {
                
                appointmentDetail.AppointmentDate = appointmentDetail.AppointmentDate.Date;
                appointmentDetail.StatusID = 2;
                var timeSlot = db.TimeSlots.FirstOrDefault(x => x.Value == appointmentDetail.AppointTime);
                appointmentDetail.TimeSlotID = timeSlot.ID;
                appointmentDetail.SlotStatus = false;
                appointmentDetail.AppointmentTime  = TimeSpan.Zero;
                var time = db.TimeSlots.FirstOrDefault(x => x.ID == appointmentDetail.TimeSlotID).Time;
                var barber = db.BarberDetails.FirstOrDefault(x => x.ID == appointmentDetail.BarberDetailID).Name;
                var shop = db.ShopDetails.FirstOrDefault(x => x.ID == appointmentDetail.ShopDetailID).State;

                
                Color mycolor = ColorTranslator.FromHtml("Red");
                ConsoleColor currentBackground = Console.BackgroundColor;
                string emailId = "sharma.harsh19994@gmail.com";

                string hells = string.Format("<span style='color:red'>" + emailId + "</span>");
                
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress("mail2rahuls@gmail.com");
                // Recipient e-mail address.
                Msg.To.Add("sharma.harsh19994@gmail.com");
                Msg.Subject = hells;
                Msg.Body = "Name : " + appointmentDetail.Name + "\n" +
                           "Date : " + appointmentDetail.AppointmentDate + "\n" +
                           "Time : " + time + "\n" + 
                           "Barber:" + barber + "\n"+
                           "Service:"+ shop + "\n"+
                           "Shop:"+ shop;
                // your remote SMTP server IP.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("sharma.harsh19994@gmail.com", "Hashonfire1");
                smtp.EnableSsl = true;
                smtp.Send(Msg);


            appointmentDetail.AppointmentID = "1";
            db.AppointmentDetails.Add(appointmentDetail);
            db.SaveChanges();

            AppointService appointService = new AppointService();
            appointService.ApointServiceIDs = string.Join(",", appointmentDetail.selectedArrayID);
                if (appointmentDetail.ID > 0)
                {
                    appointService.AppoinmentID = appointmentDetail.ID;
                }
                db.AppointServices.Add(appointService);
            db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}