using EIP.Models;
using EIP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EIP.Controllers
{
    public class MeetingRoomController : Controller
    {
        // GET: MeetingRoom

        dbEIPEntities db = new dbEIPEntities();
        public ActionResult MeetingRoomBookingSearch()
        {
            return View();
        }

        public JsonResult GetBooking()
        {
            var events = db.MeetingRoomBooking.ToList();
            //Console.WriteLine(events);
            return Json(events, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckBooking(string MeetingRoomName, DateTime BookingStartTime, DateTime BookingEndTime)
        {
            //var checkdouble = $"{MeetingRoomName} \r\n {BookingStartTime} \r\n {BookingEndTime}";
            //var startDay = BookingStartTime.Date;
            //var startHour = BookingStartTime.ToString("HH");
            //var startMinute = BookingStartTime.ToString("mm");

            //var endDay = BookingEndTime.Date;
            //public ActionResult CheckBooking()
            var status = false;

            var step1 = db.MeetingRoomBooking.Where(b => b.MeetingRoomName == MeetingRoomName && b.BookingStartTime <= BookingStartTime && b.BookingEndTime >= BookingStartTime).Select(b => new { id = b.BookingId, });
            var step2 = db.MeetingRoomBooking.Where(b => b.MeetingRoomName == MeetingRoomName && b.BookingEndTime >= BookingEndTime && b.BookingStartTime <= BookingEndTime).Select(b => new { id = b.BookingId, });
            var step3 = db.MeetingRoomBooking.Where(b => b.MeetingRoomName == MeetingRoomName && b.BookingStartTime <= BookingStartTime && b.BookingStartTime >= BookingEndTime).Select(b => new { id = b.BookingId, });
            var step4 = db.MeetingRoomBooking.Where(b => b.MeetingRoomName == MeetingRoomName && b.BookingEndTime >= BookingStartTime && b.BookingEndTime <= BookingEndTime).Select(b => new { id = b.BookingId, });
            //var checkdouble = $"{step1} \r\n {step2} \r\n {step3} \r\n {step4}";
            if (step1.Count() > 0 || step2.Count() > 0 || step3.Count() > 0 || step4.Count() > 0)
            {
                status = true;
                return Json(status, JsonRequestBehavior.AllowGet);
            }
            else
            {
                status = false;
                return Json(status, JsonRequestBehavior.AllowGet);
            }
            //return Json(checkdouble, JsonRequestBehavior.AllowGet);
        }
        public JsonResult checkBoxStatus(string Room)
        {
            var bb = db.MeetingRoomBooking.Where(a => a.MeetingRoomName == Room).Select(editevent => new
            {
                BookingId=editevent.BookingId,
                MeetingRoomName = editevent.MeetingRoomName,
                MeetingRemark = editevent.MeetingRemark,
                BookingStartTime = editevent.BookingStartTime,
                BookingEndTime = editevent.BookingEndTime,
                isAllday = editevent.IsAllDay,
                MeetingSubject = editevent.MeetingSubject,
                EmployeeID = editevent.EmployeeID,
                中文姓名 = editevent.中文姓名,
                MeetingAttentee = editevent.MeetingAttentee,            
            });
           
            return Json(bb, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveEvent(MeetingRoomBooking e)
        {
            var status = false;

            if (e.BookingId > 0)
            {
                var v = db.MeetingRoomBooking.Where(a => a.BookingId == e.BookingId).FirstOrDefault();
                if (v != null)
                {
                    v.EmployeeID = e.EmployeeID;
                    v.中文姓名 = e.中文姓名;
                    v.MeetingRoomName = e.MeetingRoomName;
                    v.MeetingSubject = e.MeetingSubject;
                    v.BookingStartTime = e.BookingStartTime;
                    v.BookingEndTime = e.BookingEndTime;
                    v.MeetingAttentee = e.MeetingAttentee;
                    v.MeetingRemark = e.MeetingRemark;
                    v.IsAllDay = e.IsAllDay;
                }
            }
            else { db.MeetingRoomBooking.Add(e); }
            db.SaveChanges();
            status = true;
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            var v = db.MeetingRoomBooking.Where(a => a.BookingId == eventID).FirstOrDefault();
            if (v != null)
            {
                db.MeetingRoomBooking.Remove(v);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }       
    }
}