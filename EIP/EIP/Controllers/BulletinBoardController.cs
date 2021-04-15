using EIP.Models;
using EIP.Models.GenericRepository;
using EIP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIP.Controllers
{
    public class BulletinBoardController : Controller
    {
        dbEIPEntities db = new dbEIPEntities();
        EIPRepository<佈告欄> er = new EIPRepository<佈告欄>();
        EIPRepository<打卡系統> sr = new EIPRepository<打卡系統>();
        // GET: BulletinBoard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BulletinBoard()
        {
            return View();
        }


        // 佈告欄總表
        public JsonResult BulletinBoardList()
        {
            var 佈告欄 = from b in db.佈告欄
                        orderby b.佈告欄ID descending
                        select new
                        {
                            佈告欄ID = b.佈告欄ID,
                            EmployeeID = b.EmployeeID,
                            中文姓名 = b.中文姓名,
                            佈告欄標題 = b.佈告欄標題,
                            佈告欄內容 = b.佈告欄內容,
                            發布日期 = b.發布日期,
                            訊息重要度=b.訊息重要度
                        };
            return Json(佈告欄, JsonRequestBehavior.AllowGet);
        }

        // 訊息強度高的佈告欄總表
        public JsonResult MessegeHighBulletinBoardList()
        {
            var mhbb = from b in db.佈告欄
                     where b.訊息重要度=="1"
                     orderby b.佈告欄ID descending
                     select b;
            return Json(mhbb.ToList().Take(3), JsonRequestBehavior.AllowGet);
        }

        // 新增佈告欄
        public JsonResult CreateBulletinBoard(BulletinBoardViewModel CBB)
        {
            佈告欄 BB = new 佈告欄()
            {
                EmployeeID = Convert.ToInt32(Request.Cookies["AutoLg"]["id"]),
                中文姓名 = Server.UrlDecode(Request.Cookies["AutoLg"]["Name"]),
                佈告欄標題 = CBB.佈告欄標題,
                佈告欄內容 = CBB.佈告欄內容,
                發布日期 = CBB.發布日期,
                訊息重要度 = CBB.訊息重要度
            };
            er.Create(BB);
            return Json(BB, JsonRequestBehavior.AllowGet);
        }


        // 搜尋指定佈告欄

        [HttpGet]
        public JsonResult SearchOneBulletinBoard(int id)
        {
            佈告欄 sobb = db.佈告欄.FirstOrDefault(m=>m.佈告欄ID==id);
            BulletinBoardViewModel bb = new BulletinBoardViewModel
            {
                佈告欄ID = sobb.佈告欄ID,
                EmployeeID = sobb.EmployeeID,
                中文姓名 = sobb.中文姓名,
                佈告欄標題 = sobb.佈告欄標題,
                佈告欄內容 = sobb.佈告欄內容,
                發布日期 = sobb.發布日期,
                訊息重要度 = sobb.訊息重要度
            };
            return Json(bb, JsonRequestBehavior.AllowGet);
        }

        // 修改佈告欄

        [HttpPost]
        public JsonResult BulletinBoardEdit(BulletinBoardViewModel bbvm)
        {
            佈告欄 bb = new 佈告欄()
            {
                佈告欄ID = bbvm.佈告欄ID,
                EmployeeID = bbvm.EmployeeID,
                中文姓名 = bbvm.中文姓名,
                佈告欄標題 = bbvm.佈告欄標題,
                佈告欄內容 = bbvm.佈告欄內容,
                發布日期 = bbvm.發布日期,
                訊息重要度 = bbvm.訊息重要度
            };
            er.Update(bb);
            return Json(bb, JsonRequestBehavior.AllowGet);
        }


        // 刪除佈告欄

        [HttpGet]
        public JsonResult BulletinBoardDelete(int id)
        {
            佈告欄 bb = db.佈告欄.Find(id);
            er.Delete(id);
            return Json(bb, JsonRequestBehavior.AllowGet);
        }


        // 搜尋佈告欄
        public JsonResult BulletinBoardSearch(string name)
        {
            var bb = from b in db.佈告欄
                     where (b.中文姓名.Contains(name))
                     orderby b.佈告欄ID descending
                     select b;
            return Json(bb.ToList().Take(10), JsonRequestBehavior.AllowGet);
        }

        // ---------------------------以下Fullcalendar方法----------------------------//

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
            using (dbEIPEntities db = new dbEIPEntities())
            {
                var v = db.行事曆.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    db.行事曆.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        // ---------------------------以下Fullcalendar打卡系統方法----------------------------//

        public JsonResult SignInShow()
        {
            var x = Request.Cookies["AutoLg"]["id"];
            var c = db.個人資料.FirstOrDefault(m => m.EmployeeID.ToString() == x);
            var events = db.打卡系統.Where(m => m.中文姓名.ToString() == c.中文姓名);
            if (events.Count() != 0)
            {
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data ="", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult SignInSave()
        {
            var 員工編號 = Convert.ToInt32(Request.Cookies["AutoLg"]["id"]);
            var 中文姓名 = Server.UrlDecode(Request.Cookies["AutoLg"]["Name"]);
            var 現在日期 = DateTime.Now.Date;
            var 現在時間 = DateTime.Now;
            using (dbEIPEntities db = new dbEIPEntities())
            {
                打卡系統 v = new 打卡系統();
                var v1 = db.打卡系統.Where(a => a.員工編號 == 員工編號 && a.打卡日期 == 現在日期).FirstOrDefault();
                if (v1 == null)
                {
                    v.員工編號 = 員工編號;
                    v.上班打卡時間 = 現在時間;
                    v.打卡日期 = DateTime.Now.Date;
                    v.中文姓名 = 中文姓名;
                    v.ThemeColor = "gray";
                    sr.Create(v);
                }
                else
                {
                    v1.員工編號 = 員工編號;
                    v1.打卡日期 = DateTime.Now.Date;
                    v1.中文姓名 = 中文姓名;
                    v1.下班打卡時間 = 現在時間;
                    if (v1.上班打卡時間 < 現在時間 && v1.下班打卡時間 > 現在時間)
                    {
                        v1.ThemeColor = "green";
                    }
                    else
                    {
                        v1.ThemeColor = "red";
                    }
                    sr.Update(v1);
                }
            }
            return Json("",JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SignInDemoSave()
        {
            var 員工編號 = Convert.ToInt32(Request.Cookies["AutoLg"]["id"]);
            var 中文姓名 = Server.UrlDecode(Request.Cookies["AutoLg"]["Name"]);
            var 現在日期 = new DateTime(2021, 4, 15);
            var 模擬上班打卡時間 = new DateTime(2021, 4, 15, 8, 30, 0);
            var 模擬下班打卡時間 = new DateTime(2021, 4, 15, 18, 30, 0);
            using (dbEIPEntities db = new dbEIPEntities())
            {
                打卡系統 v = new 打卡系統();
                var v1 = db.打卡系統.Where(a => a.員工編號 == 員工編號 && a.打卡日期 == 現在日期).FirstOrDefault();
                if (v1 == null)
                {
                    v.員工編號 = 員工編號;
                    v.上班打卡時間 = 模擬上班打卡時間;
                    v.打卡日期 = new DateTime(2021, 4, 15);
                    v.中文姓名 = 中文姓名;
                    v.ThemeColor = "gray";
                    sr.Create(v);
                }
                else
                {
                    v1.員工編號 = 員工編號;
                    v1.打卡日期 = new DateTime(2021, 4, 15);
                    v1.中文姓名 = 中文姓名;
                    v1.下班打卡時間 = 模擬下班打卡時間;
                    v1.ThemeColor = "green";
                    sr.Update(v1);
                }
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}