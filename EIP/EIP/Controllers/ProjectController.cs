using EIP.Models;
using EIP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EIP.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project

        dbEIPEntities dbEIP = new dbEIPEntities();



        public ActionResult Index()
        {
            return View();
        }


        public ActionResult EmpIndex()
        {



            return View();
        }


        public JsonResult PJShowEdit()
        {
            var pjm = dbEIP.pj總表.Select(a => new
            {
                pjName = a.pjName,
                pjCreateId = a.pjCreateId,
                pjId = a.pjId,
                pjManager = a.pjManager,
                pjBudget = a.pj建立.pjBudget,
                pj初審意見 = a.pj建立.pj初審意見,
                pj初審狀態 = a.pj建立.pj審核狀態,
                pj成員數 = a.pj建立.pj成員數,

                pj簡介 = a.pj建立.pj簡介,
                pj贊助商 = a.pj建立.pj客戶,
                pj複審意見 = a.pj建立.pj複審意見


            });


            return Json(pjm, JsonRequestBehavior.AllowGet);
        }



        public JsonResult PJShowEdit初審未通過()
        {
            var pjm = dbEIP.pj總表.Select(a => new
            {
                pjName = a.pjName,
                pjCreateId = a.pjCreateId,
                pjId = a.pjId,
                pjManager = a.pjManager,
                pjBudget = a.pj建立.pjBudget,
                pj初審意見 = a.pj建立.pj初審意見,
                pj初審狀態 = a.pj建立.pj審核狀態,
                pj成員數 = a.pj建立.pj成員數,

                pj簡介 = a.pj建立.pj簡介,
                pj贊助商 = a.pj建立.pj客戶,
                pj複審意見 = a.pj建立.pj複審意見


            });


            return Json(pjm, JsonRequestBehavior.AllowGet);
        }



        public JsonResult PJShowEdit初審通過()
        {
            
            var pjm = dbEIP.pj總表.Select(a => new
            {
                pjName = a.pjName,
                pjCreateId = a.pjCreateId,
                pjId = a.pjId,
                pjManager = a.pjManager,
                pjBudget = a.pj建立.pjBudget,
                pj初審意見 = a.pj建立.pj初審意見,
                pj初審狀態 = a.pj建立.pj審核狀態,
                pj成員數 = a.pj建立.pj成員數,

                pj簡介 = a.pj建立.pj簡介,
                pj贊助商 = a.pj建立.pj客戶,
                pj複審意見 = a.pj建立.pj複審意見


            });


            return Json(pjm, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PJShowEdit複審未通過()
        {
            var pjm = dbEIP.pj總表.Select(a => new
            {
                pjName = a.pjName,
                pjCreateId = a.pjCreateId,
                pjId = a.pjId,
                pjManager = a.pjManager,
                pjBudget = a.pj建立.pjBudget,
                pj初審意見 = a.pj建立.pj初審意見,
                pj初審狀態 = a.pj建立.pj審核狀態,
                pj成員數 = a.pj建立.pj成員數,

                pj簡介 = a.pj建立.pj簡介,
                pj贊助商 = a.pj建立.pj客戶,
                pj複審意見 = a.pj建立.pj複審意見


            });


            return Json(pjm, JsonRequestBehavior.AllowGet);
        }


        public JsonResult PJShowEdit複審通過()
        {
            var pjm = dbEIP.pj總表.Select(a => new
            {
                pjName = a.pjName,
                pjCreateId = a.pjCreateId,
                pjId = a.pjId,
                pjManager = a.pjManager,
                pjBudget = a.pj建立.pjBudget,
                pj初審意見 = a.pj建立.pj初審意見,
                pj初審狀態 = a.pj建立.pj審核狀態,
                pj成員數 = a.pj建立.pj成員數,

                pj簡介 = a.pj建立.pj簡介,
                pj贊助商 = a.pj建立.pj客戶,
                pj複審意見 = a.pj建立.pj複審意見


            });


            return Json(pjm, JsonRequestBehavior.AllowGet);
        }





        [HttpGet]
        public JsonResult PJEditDetail(int id)
        {
            var PLV = dbEIP.pj總表.FirstOrDefault(m => m.pjId == id);
            var kp = dbEIP.pj建立.FirstOrDefault(n => n.pjCreateId == PLV.pjCreateId);
            var team = dbEIP.pj團隊.FirstOrDefault(t => t.pjId == id);
            var pa = new
            {
                pjName = PLV.pjName,
                pjCreateId = PLV.pjCreateId,
                pjId = PLV.pjId,
                pjManager = PLV.pjManager,
                pjBudget = kp.pjBudget,
                pj初審意見 = kp.pj初審意見,
                pj審核狀態 = kp.pj審核狀態,
                pj簡介 = kp.pj簡介,
                pj成員數 = kp.pj成員數,
                pj客戶 = kp.pj客戶,
                pj工作項目1 = team.pj工作項目1,
                pj工作項目2 = team.pj工作項目2,
                pj工作項目3 = team.pj工作項目3,
                pj工作項目4 = team.pj工作項目4,
                pj工作項目5 = team.pj工作項目5,
                pj工作項目6 = team.pj工作項目6,
                pj工作項目7 = team.pj工作項目7,
                pj成員1 = team.pj成員1,
                pj成員2 = team.pj成員2,
                pj成員3 = team.pj成員3,
                pj成員4 = team.pj成員4,
                pj成員5 = team.pj成員5,
                pj成員6 = team.pj成員6,
                pj成員7 = team.pj成員7,
                tpjId = team.pjId,
            };



            return Json(pa, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult PJEditDetail建立(string id)
        {
            var PL = dbEIP.pj建立.FirstOrDefault(m => m.pjCreateId == id);
            var pb = new
            {

                pjBudget = PL.pjBudget,
                pj初審意見 = PL.pj初審意見,
                pj審核狀態 = PL.pj審核狀態,
                pj簡介 = PL.pj簡介,
                pj成員數 = PL.pj成員數,
                pj客戶 = PL.pj客戶,
            };



            return Json(pb, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]

        public JsonResult PJEditDetail(pj總表 PJet)
        {


            var epj = new pj總表()
            {
                pjId = PJet.pjId,
                pjName = PJet.pjName,
                pjManager = PJet.pjManager,
                pjCreateId = PJet.pjCreateId,
                

            };


            dbEIP.Entry(epj).State = EntityState.Modified;
            dbEIP.SaveChanges();
            return Json(epj, JsonRequestBehavior.AllowGet);


        }
         [HttpPost]
        public JsonResult PJEditDetail建立(pj建立 Pc)
        {


            var epc = new pj建立()
            {

                pj初審意見 = Pc.pj初審意見,
                pj審核狀態 = Pc.pj審核狀態,
                pjCreateId = Pc.pjCreateId,
                pj客戶 = Pc.pj客戶,
                pj成員數 = Pc.pj成員數,
                pj簡介 = Pc.pj簡介,
                pjBudget = Pc.pjBudget,
                pj複審意見 = Pc.pj複審意見,






            };


            dbEIP.Entry(epc).State = EntityState.Modified;
            dbEIP.SaveChanges();
            return Json(epc, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public JsonResult PJEditDetail團隊(pj團隊 Pt)
        {


            var ept = new pj團隊()
            {

                pjId = Pt.pjId,
                pj工作項目1 = Pt.pj工作項目1,
                pj工作項目2 = Pt.pj工作項目2,
                pj工作項目3 = Pt.pj工作項目3,
                pj工作項目4 = Pt.pj工作項目4,
                pj工作項目5 = Pt.pj工作項目5,
                pj工作項目6 = Pt.pj工作項目6,
                pj工作項目7 = Pt.pj工作項目7,
                pj成員1 = Pt.pj成員1,
                pj成員2 = Pt.pj成員2,
                pj成員3 = Pt.pj成員3,
                pj成員4 = Pt.pj成員4,
                pj成員5 = Pt.pj成員5,
                pj成員6 = Pt.pj成員6,
                pj成員7 = Pt.pj成員7,
               






            };


            dbEIP.Entry(ept).State = EntityState.Modified;
            dbEIP.SaveChanges();
            return Json(ept, JsonRequestBehavior.AllowGet);


        }


        public string addPj總表(pj總表 data)
        {

            dbEIP.pj總表.Add(data);
            dbEIP.SaveChanges();
            return "ok";

        }

        public string createPj(pj建立 data)
        {

            dbEIP.pj建立.Add(data);
            dbEIP.SaveChanges();
            return "ok";

        }




        public string tosecond(pj團隊 data)
        {

            dbEIP.pj團隊.Add(data);
            dbEIP.SaveChanges();
            return "ok";

        }



        [HttpGet]
        public JsonResult PJgetemp(int id)
        {
            var PLV = dbEIP.個人資料.Select(a => new
            {
                pj成員1 = a.EmployeeID,
                pj成員2 = a.EmployeeID,
                pj成員3 = a.EmployeeID,
                pj成員4 = a.EmployeeID,
                pj成員5 = a.EmployeeID,
                pj成員6 = a.EmployeeID,
                pj成員7 = a.EmployeeID,


            });



            return Json(PLV, JsonRequestBehavior.AllowGet);
        }











    }
}