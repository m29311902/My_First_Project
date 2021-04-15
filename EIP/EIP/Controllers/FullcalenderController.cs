using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EIP.Models;
using EIP.Models.ViewModel;
using EIP.Models.GenericRepository;


namespace EIP.Controllers
{
    public class FullcalenderController : Controller
    {
        dbEIPEntities db = new dbEIPEntities();
        EIPRepository<行事曆> fc = new EIPRepository<行事曆>();
        // GET: Fullcalender
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Fullcalender()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (dbEIPEntities db = new dbEIPEntities())
            {
                var events = db.行事曆.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(行事曆 e)
        {
            var status = false;
            using (dbEIPEntities db = new dbEIPEntities())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = db.行事曆.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    db.行事曆.Add(e);
                }

                db.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (dbEIPEntities dc = new dbEIPEntities())
            {
                var v = dc.行事曆.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.行事曆.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}
