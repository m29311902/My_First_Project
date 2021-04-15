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
    public class projectControlController : Controller
    {
        // GET: projectControl
        //public ActionResult Index()
        //{
        //    return View();
        //}



        dbEIPEntities db = new dbEIPEntities();



        public ActionResult pjView()
        {
            return View();
        }



        //---------- T E S T -----------------
        public void getCr8formVal(pjProject val)
        {
            var x = new pjProject
            {
                pjName = val.pjName,
                pjIntroduction = val.pjIntroduction,
                pjManager = val.pjManager,
                pjClient = val.pjClient,
                pjBudget = val.pjBudget,
                pjMemberCount = val.pjMemberCount,
                pj結束日期 = val.pj結束日期,
                pj開始日期 = val.pj開始日期,
                pj預估時間 = val.pj預估時間,
                pjManagerId = val.pjManagerId,
                pj初審結果 = val.pj初審結果,
                pj審核階段 = val.pj審核階段,
            };
            db.pjProject.Add(x);
            db.SaveChanges();
        }
        public JsonResult getPjProjectData()
        {
            var data = from m in db.pjProject
                       orderby m.pjId descending
                       select new

                       {
                           pjManager = m.pjManager,
                           pjId = m.pjId,
                           pjName = m.pjName,
                           pj審核階段 = m.pj審核階段,
                           pj初審結果 = m.pj初審結果,
                           pj複審結果 = m.pj複審結果,
                           pjMemberCount = m.pjMemberCount,
                           pjIntroduction = m.pjIntroduction,
                           pj結案 = m.pj結案
                       };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getPjProjectData結案排序()
        {
            var data = from m in db.pjProject
                       orderby m.pj結案=="是"
                       select new

                       {
                           pjManager = m.pjManager,
                           pjId = m.pjId,
                           pjName = m.pjName,
                           pj審核階段 = m.pj審核階段,
                           pj初審結果 = m.pj初審結果,
                           pj複審結果 = m.pj複審結果,
                           pjMemberCount = m.pjMemberCount,
                           pjIntroduction = m.pjIntroduction,
                           pj結案 = m.pj結案
                       };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult getPjProjectData最新三筆()
        {
            var data = from m in db.pjProject
                       orderby m.pjId descending
                       select new
                       {
                           pjManager = m.pjManager,
                           pjId = m.pjId,
                           pjName = m.pjName,
                           pj審核階段 = m.pj審核階段,
                           pj初審結果 = m.pj初審結果,
                           pjMemberCount = m.pjMemberCount,
                           pjIntroduction = m.pjIntroduction,
                           pj結案 = m.pj結案
                       };
            //var data = db.pjProject.Select(m => new
            //{
            //    pjManager = m.pjManager,
            //    pjId = m.pjId,
            //    pjName = m.pjName,
            //    pj審核階段 = m.pj審核階段,
            //    pj初審結果 = m.pj初審結果,
            //    pjMemberCount = m.pjMemberCount,
            //    pjIntroduction = m.pjIntroduction,
            //    pj結案 = m.pj結案
            //});
            return Json(data.Take(3), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getPjTeamDataFromId(int id)
        {
            var teamData = from cc in db.pjTeam
                    where cc.pjId == id
                    orderby cc.pjId descending
                    select cc;
            //var team = t.Where(s => s.pjId == d.pjId);
            return Json(teamData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getPjTeamDataFromId個人(int id,string name)
        {
            var teamData = from cc in db.pjTeam
                           where cc.pjMemberName == name && cc.pjId == id
                           || cc.pjProject.pjManager == name && cc.pjId == id

                           orderby cc.pjId descending
                           select new
                           {
                               pjTeamId = cc.pjTeamId,
                               pjId = cc.pjId,
                               pjMemberId = cc.pjMemberId,
                               pjMemberName = cc.pjMemberName,
                               pjTarget = cc.pjTarget,
                               pjMember部門 = cc.pjMember部門,
                               pjTask = cc.pjTask,
                               pjFixedDuration = cc.pjFixedDuration,
                               pjTaskStartDate = cc.pjTaskStartDate,
                               pjTaskEndDate = cc.pjTaskEndDate,
                               pjName = cc.pjProject.pjName,
                               pjManager = cc.pjProject.pjManager,
                           };
            //var team = t.Where(s => s.pjId == d.pjId);
            return Json(teamData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getPjProjectDataFromId(int id)
        {
            var d = db.pjProject.FirstOrDefault(m => m.pjId == id);            
            var getPjProjectDataFromId = new
            {
                pjId = d.pjId,
                pjName = d.pjName,
                pjManager = d.pjManager,
                pjBudget = d.pjBudget,
                pjIntroduction = d.pjIntroduction,
                pjMemberCount = d.pjMemberCount,
                pjClient = d.pjClient,
                pj初審結果 = d.pj初審結果,
                pj複審結果 = d.pj複審結果,
                pj開始日期 = d.pj開始日期,
                pj結束日期 = d.pj結束日期,
                pjManagerId = d.pjManagerId,
                pj預估時間 = d.pj預估時間,
                pj審核階段 = d.pj審核階段,             
            };
            return Json(getPjProjectDataFromId, JsonRequestBehavior.AllowGet);
        }
        public void savePreview2FormData(pjTeam formdata)
        {
            db.pjTeam.Add(formdata);
            db.SaveChanges();
        }
        //public void pj審核結果儲存(pjProject data)
        //{
        //    //db.Entry<pjProject>(data).State = EntityState.Modified; //整筆資料全部覆寫
        //    //db.SaveChanges();
        //}
        public JsonResult pj專案列表()
        {
            var pj專案列表Data = from x in db.pjProject
                             where x.pj初審結果 == "通過" && x.pj複審結果 == "通過"
                             orderby x.pjId descending
                             //select new {
                             //    pjId = x.pjId,
                             //    pjName = x.pjName,
                             //    pjIntroduction = x.pjIntroduction,
                             //    pjManager = x.pjManager,
                             //};
                             select x;

                             
            return Json(pj專案列表Data, JsonRequestBehavior.AllowGet);
        }
        public void pj專案規劃(pjTeam formdata)
        {
            var x = db.pjTeam.FirstOrDefault(m => m.pjTeamId == formdata.pjTeamId);
            //db.Entry<pjTeam>(x).State = EntityState.Modified;
            x.pjMember部門 = formdata.pjMember部門;
            x.pjTask = formdata.pjTask;
            x.pjTaskStartDate = formdata.pjTaskStartDate;
            x.pjTaskEndDate = formdata.pjTaskEndDate;
            x.pjFixedDuration = formdata.pjFixedDuration;
            db.SaveChanges();
        }
        public JsonResult pj所有規劃內容()
        {
            //var pj所有規劃內容1 = db.pjTeam.Select(m => new
            //{
            //    pjTeamId = m.pjTeamId,
            //    pjId = m.pjId,
            //    pjMemberName = m.pjMemberName,
            //    pjTarget = m.pjTarget,
            //    pjMember部門 = m.pjMember部門,
            //    pjTask = m.pjTask,
            //    pjFixedDuration = m.pjFixedDuration,
            //    pjTaskStartDate = m.pjTaskStartDate,
            //    pjTaskEndDate = m.pjTaskEndDate,
            //    pjName = m.pjProject.pjName,
            //});

            var pj所有規劃內容 = from m in db.pjTeam
                           orderby m.pjTeamId descending
                           select new
                           {
                               pjTeamId = m.pjTeamId,
                               pjId = m.pjId,
                               pjMemberName = m.pjMemberName,
                               pjTarget = m.pjTarget,
                               pjMember部門 = m.pjMember部門,
                               pjTask = m.pjTask,
                               pjFixedDuration = m.pjFixedDuration,
                               pjTaskStartDate = m.pjTaskStartDate,
                               pjTaskEndDate = m.pjTaskEndDate,
                               pjName = m.pjProject.pjName,
                           };

            return Json(pj所有規劃內容, JsonRequestBehavior.AllowGet);
        }
        public void pj進度回報單(pjReport data)
        {
            var x = new pjReport
            {
                pjId = data.pjId,
                pjReportDate = data.pjReportDate,
                pjReportContent = data.pjReportContent,
                pjIssuelog = data.pjIssuelog,
                pjMemberId = data.pjMemberId,
                pjMemberName = data.pjMemberName,
            };
            db.pjReport.Add(x);
            db.SaveChanges();
        }
        public JsonResult pj篩選出自己的專案(int id,string name)
        {
            //var pjTeamData = from m in db.pjTeam
            //         where m.pjMemberName == name && m.pjProject.pj初審結果 =="通過" && m.pjProject.pj複審結果 == "通過"
            //         || m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjManager == name
            //                 select new{
            //             pjId = m.pjProject.pjId,
            //             pjName = m.pjProject.pjName,
            //             pjManager = m.pjProject.pjManager,
            //             pjIntroduction = m.pjProject.pjIntroduction,
            //         };           

            var pjTeamData = db.pjTeam.Where(m => m.pjMemberName == name && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" || m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjManager == name)
                .Select(n => new
                {
                    pjId = n.pjProject.pjId,
                    pjName = n.pjProject.pjName,
                    pjManager = n.pjProject.pjManager,
                    pjIntroduction = n.pjProject.pjIntroduction,
                    pj結案 = n.pjProject.pj結案,
                    pjTarget = n.pjTarget,
                }).Distinct(); //刪除重複的相同資料
            return Json(pjTeamData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj主管讀取進度回報單(int id)
        {
            var reportData = from m in db.pjReport
                             where m.pjId == id
                             orderby m.pjDayReportId descending
                             select new
            {
                pjId = m.pjId,
                pjName = m.pjProject.pjName,
                pjMemberId = m.pjMemberId,
                pjMemberName = m.pjMemberName,
                pjReportDate = m.pjReportDate,
                pjReportContent = m.pjReportContent,
                pjIssuelog = m.pjIssuelog,
            };
            return Json(reportData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj主管讀取進度回報單take10(int id)
        {
            var reportData = from m in db.pjReport
                             where m.pjId == id
                             orderby m.pjDayReportId descending
                             select new
                             {
                                 pjId = m.pjId,
                                 pjName = m.pjProject.pjName,
                                 pjMemberId = m.pjMemberId,
                                 pjMemberName = m.pjMemberName,
                                 pjReportDate = m.pjReportDate,
                                 pjReportContent = m.pjReportContent,
                                 pjIssuelog = m.pjIssuelog,
                             };
            return Json(reportData.Take(10), JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj成員讀取包含自己的進度回報單(int id,string name)
        {
            var reportData = from m in db.pjReport
                             where m.pjMemberName==name && m.pjProject.pjId==id
                             orderby m.pjDayReportId descending
                             select new
                             {
                                 pjId = m.pjId,
                                 pjName = m.pjProject.pjName,
                                 pjMemberId = m.pjMemberId,
                                 pjMemberName = m.pjMemberName,
                                 pjReportDate = m.pjReportDate,
                                 pjReportContent = m.pjReportContent,
                                 pjIssuelog = m.pjIssuelog,
                             };
            return Json(reportData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj主管讀取未分類進度回報單()
        {
            //var reportData = db.pjReport.Select(m => new
            var reportData = from m in db.pjReport
                             orderby m.pjDayReportId descending
                             select new
            {
                pjId = m.pjId,
                pjName = m.pjProject.pjName,
                pjMemberId = m.pjMemberId,
                pjMemberName = m.pjMemberName,
                pjReportDate = m.pjReportDate,
                pjReportContent = m.pjReportContent,
                pjIssuelog = m.pjIssuelog,
            };
            return Json(reportData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj主管搜尋專案列表(string searchVal)
        {
            var data = from m in db.pjProject
                    where m.pj初審結果=="通過"&& m.pj複審結果 == "通過" && m.pjName.Contains(searchVal) || m.pj初審結果 == "通過" && m.pj複審結果 == "通過" && m.pjManager.Contains(searchVal) || m.pj初審結果 == "通過" && m.pj複審結果 == "通過" && m.pjIntroduction.Contains(searchVal)
                    orderby m.pjId
                       select m;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj成員搜尋專案列表(string searchVal,pjTeam data)
        {
            var pjTeamData = from m in db.pjTeam
                             where m.pjMemberName == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjName.Contains(searchVal)
                             || m.pjMemberName == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjManager.Contains(searchVal)
                             || m.pjMemberName == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjIntroduction.Contains(searchVal)
                             || m.pjMemberName == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjManager.Contains(searchVal)

                             || m.pjProject.pjManager == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjName.Contains(searchVal)
                             || m.pjProject.pjManager == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjManager.Contains(searchVal)
                             || m.pjProject.pjManager == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjIntroduction.Contains(searchVal)
                             || m.pjProject.pjManager == data.pjMemberName && m.pjProject.pj初審結果 == "通過" && m.pjProject.pj複審結果 == "通過" && m.pjProject.pjManager.Contains(searchVal)
                             select new
                             {
                                 pjId = m.pjProject.pjId,
                                 pjName = m.pjProject.pjName,
                                 pjManager = m.pjProject.pjManager,
                                 pjIntroduction = m.pjProject.pjIntroduction,
                             };
            return Json(pjTeamData, JsonRequestBehavior.AllowGet);
        }
        public void pj會議記錄表save(pjMeeting data)
        {
            var pjMeetingData = new pjMeeting
            {
                pjId = data.pjId,
                pjMeetingDate = data.pjMeetingDate,
                pjContent = data.pjContent,
                pjMemo = data.pjMemo,
            };
            db.pjMeeting.Add(pjMeetingData);
            db.SaveChanges();
        }
        public JsonResult pjGetAll會議記錄()
        {
            //var pjGetAll會議記錄 = from a in db.pjMeeting
            //                   select a;
            //var pjGetAll會議記錄1 = db.pjMeeting.Select(m => new {
            //    pjId = m.pjId,
            //    pjMeetingDate = m.pjMeetingDate,
            //    pjContent = m.pjContent,
            //    pjMemo = m.pjMemo,
            //    pjName = m.pjProject.pjName,
            //    pjManager = m.pjProject.pjManager,
            //    pjMeetingId = m.pjMeetingId,
            //});

            var pjGetAll會議記錄 = from m in db.pjMeeting
                               orderby m.pjMeetingDate descending
                               select new
                               {
                                   pjId = m.pjId,
                                   pjMeetingDate = m.pjMeetingDate,
                                   pjContent = m.pjContent,
                                   pjMemo = m.pjMemo,
                                   pjName = m.pjProject.pjName,
                                   pjManager = m.pjProject.pjManager,
                                   pjMeetingId = m.pjMeetingId,
                               };
            return Json(pjGetAll會議記錄, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj找單筆會議資料(int id)
        {
            var x = db.pjMeeting.FirstOrDefault(m => m.pjMeetingId == id);
            var pjMeeting單筆資料 = new
            {
                pjContent = x.pjContent,
            };
            return Json(pjMeeting單筆資料, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pjFindAll會議記錄ById(int id)
        {
            var data = from d in db.pjMeeting
                       where d.pjId == id
                       orderby d.pjMeetingId descending
                       select new
                       {
                           pjId = d.pjId,
                           pjMeetingDate = d.pjMeetingDate,
                           pjContent = d.pjContent,
                           pjMemo = d.pjMemo,
                           pjName = d.pjProject.pjName,
                           pjManager = d.pjProject.pjManager,
                       };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult pj搜尋單筆會議(int id)
        {
            var pj搜尋單筆會議 = from x in db.pjMeeting
                           where x.pjId == id
                           orderby x.pjMeetingId descending
                           select new
                           {
                               pjId = x.pjId,
                               pjMeetingDate = x.pjMeetingDate,
                               pjMeetingId = x.pjMeetingId,
                               pjContent = x.pjContent,
                               pjMemo = x.pjMemo,
                               pjName = x.pjProject.pjName,
                               pjManager = x.pjProject.pjManager,                               
                           };
            return Json(pj搜尋單筆會議, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj搜尋單筆會議take10(int id)
        {
            var pj搜尋單筆會議 = from x in db.pjMeeting
                           where x.pjId == id
                           orderby x.pjMeetingId descending
                           select new
                           {
                               pjId = x.pjId,
                               pjMeetingDate = x.pjMeetingDate,
                               pjMeetingId = x.pjMeetingId,
                               pjContent = x.pjContent,
                               pjMemo = x.pjMemo,
                               pjName = x.pjProject.pjName,
                               pjManager = x.pjProject.pjManager,
                           };
            return Json(pj搜尋單筆會議.Take(10), JsonRequestBehavior.AllowGet);
        }
        public JsonResult pj找此專案的會議紀錄(int id)
        {
            var pj找此專案的會議紀錄 = from m in db.pjMeeting
                              where m.pjId == id
                              orderby m.pjMeetingId descending
                              select new
                              {
                                  pjId = m.pjId,
                                  pjMeetingDate = m.pjMeetingDate,
                                  pjMeetingId = m.pjMeetingId,
                                  pjMemo = m.pjMemo,
                                  pjContent = m.pjContent,
                                  pjManager = m.pjProject.pjManager,
                                  pjName = m.pjProject.pjName
                              };
            return Json(pj找此專案的會議紀錄, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pjSearch進度回報紀錄FrormVal(string val)
        {
            var pjSearch進度回報紀錄FrormVal = db.pjReport.Where(m => m.pjMemberName.Contains(val) || m.pjReportDate.Contains(val) || m.pjProject.pjName.Contains(val))
                .Select(n => new
                {
                    pjMemberId = n.pjMemberId,
                    pjDayReportId = n.pjDayReportId,
                    pjId = n.pjId,
                    pjIssuelog = n.pjIssuelog,
                    pjMemberName = n.pjMemberName,
                    pjReportContent = n.pjReportContent,
                    pjTask = n.pjTask,
                    pjReportDate = n.pjReportDate,
                    pjName = n.pjProject.pjName,
                });
            return Json(pjSearch進度回報紀錄FrormVal, JsonRequestBehavior.AllowGet);
        }
        public JsonResult pjShow結案()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }







        //-------------------------------------------------------------------------------------------------------






        public JsonResult getMainData1(int id)
        {
            var pjMainData1 = db.pjProject.FirstOrDefault(m => m.pjId == id);

            var qPjData = new
            {
                pjId = pjMainData1.pjId,
                pjName = pjMainData1.pjName,
                pjManager = pjMainData1.pjManager,
                pjMemberCount = pjMainData1.pjMemberCount,
            };
            return Json(qPjData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getteamData1(int id)
        {
            var qPjData =
                 from m in db.pjTeam
                 where m.pjId == id
                 select new


                 {
                     pjId = m.pjId,
                     pjMemberName = m.pjMemberName,
                     pjMember部門 = m.pjMember部門,
                     pjTarget = m.pjTarget,

                 };
            return Json(qPjData, JsonRequestBehavior.AllowGet);
        }
        public void pj專案結案(int id,string value)
        {
            var x = db.pjProject.FirstOrDefault(m => m.pjId == id);
            x.pj結案 = value;
            db.SaveChanges();
        }




        //---------- T E S T -----------------



        //總表


        //總表

        public JsonResult getPjProjectDatat2()
        {
            var pjm = from m in db.pjProject
                      where m.pj複審結果 == "不通過" || m.pj複審結果 == "待審核" && m.pj審核階段 == "複審"
                      orderby m.pjId descending
                      select new
                      {
                          pjId = m.pjId,
                          pjName = m.pjName,
                          pj審核階段 = m.pj審核階段,
                          pj初審結果 = m.pj初審結果,
                          pj複審結果 = m.pj複審結果,

                          pjMemberCount = m.pjMemberCount,
                          pjManager = m.pjManager,
                      };
            return Json(pjm, JsonRequestBehavior.AllowGet);
        }
        //複審審核

        //初審審核
        public JsonResult getPjProjectDatat3()
        {
            var pjm = from m in db.pjProject
                      where m.pj初審結果 == "不通過" || m.pj初審結果 == "待審核" && m.pj審核階段 == "初審"
                      orderby m.pjId descending
                      select new
                      {
                          pjId = m.pjId,
                          pjName = m.pjName,
                          pj審核階段 = m.pj審核階段,
                          pj初審結果 = m.pj初審結果,
                          pjMemberCount = m.pjMemberCount,
                          pjManager = m.pjManager,
                      };
            return Json(pjm, JsonRequestBehavior.AllowGet);
        }
        //初審審核

        //初審審核
        public JsonResult getPjProjectDatat4()
        {
            var pjm = from m in db.pjProject
                      where m.pj初審結果 == "通過" && m.pj審核階段 == "初審"
                      orderby m.pjId descending
                      select new
                      {
                          pjId = m.pjId,
                          pjName = m.pjName,
                          pj審核階段 = m.pj審核階段,
                          pj初審結果 = m.pj初審結果,
                          pjMemberCount = m.pjMemberCount,
                          pjManager = m.pjManager,
                      };
            return Json(pjm, JsonRequestBehavior.AllowGet);
        }
        //初審審核






        public void getPjProjectDataFromIdto2(int id)
        {
            var d = db.pjProject.FirstOrDefault(m => m.pjId == id);
            {
                d.pj審核階段 = "複審";
                d.pj複審結果 = "待審核";
                d.pj結案 = "否";
            }
            db.SaveChanges();
        }




        public void pj審核結果儲存(pjProject data)
        {
            db.Entry<pjProject>(data).State = EntityState.Modified; //整筆資料全部覆寫
            db.SaveChanges();
        }

        public void pj審核意見(pjAdvice ad)
        {
            var a = new pjAdvice

            {
                pjId = ad.pjId,
                pj意見內容 = ad.pj意見內容,
                pj審核階段 = ad.pj審核階段,
            };


            db.pjAdvice.Add(a);
            db.SaveChanges();
        }


        public JsonResult getPjProjectDataFromId初審意見(int id)
        {
            var d = db.pjProject.FirstOrDefault(m => m.pjId == id);
            var k = db.pjAdvice.FirstOrDefault(n => n.pjId == id);
            var getPjProjectDataFromId = new
            {
                pjId = d.pjId,
                pjName = d.pjName,
                pjManager = d.pjManager,
                pjBudget = d.pjBudget,
                pjIntroduction = d.pjIntroduction,
                pjMemberCount = d.pjMemberCount,
                pjClient = d.pjClient,
                pj初審結果 = d.pj初審結果,
                pj複審結果 = d.pj複審結果,
                pj開始日期 = d.pj開始日期,
                pj結束日期 = d.pj結束日期,
                pjManagerId = d.pjManagerId,
                pj預估時間 = d.pj預估時間,
                pj審核階段 = d.pj審核階段,
                pj意見內容 = k.pj意見內容,
            };
            return Json(getPjProjectDataFromId, JsonRequestBehavior.AllowGet);
        }


        public JsonResult getPjProjectDataFromId複審意見(int id)
        {
            var d = db.pjProject.FirstOrDefault(m => m.pjId == id);
            var k = db.pjAdvice.FirstOrDefault(n => n.pj審核階段 == "複審" && n.pjId == id);
            var getPjProjectDataFromId = new
            {
                pjId = d.pjId,
                pjName = d.pjName,
                pjManager = d.pjManager,
                pjBudget = d.pjBudget,
                pjIntroduction = d.pjIntroduction,
                pjMemberCount = d.pjMemberCount,
                pjClient = d.pjClient,
                pj初審結果 = d.pj初審結果,
                pj複審結果 = d.pj複審結果,
                pj開始日期 = d.pj開始日期,
                pj結束日期 = d.pj結束日期,
                pjManagerId = d.pjManagerId,
                pj預估時間 = d.pj預估時間,
                pj審核階段 = d.pj審核階段,
                pj意見內容 = k.pj意見內容,
            };
            return Json(getPjProjectDataFromId, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getPjProjectDataFromId列表詳細(int id)
        {
            var d = db.pjProject.FirstOrDefault(m => m.pjId == id);

            var getPjProjectDataFromId = new
            {
                pjId = d.pjId,
                pjName = d.pjName,
                pjManager = d.pjManager,
                pjBudget = d.pjBudget,
                pjIntroduction = d.pjIntroduction,
                pjMemberCount = d.pjMemberCount,
                pjClient = d.pjClient,
                pj初審結果 = d.pj初審結果,
                pj複審結果 = d.pj複審結果,
                pj開始日期 = d.pj開始日期,
                pj結束日期 = d.pj結束日期,
                pjManagerId = d.pjManagerId,
                pj預估時間 = d.pj預估時間,
                pj審核階段 = d.pj審核階段,

            };
            return Json(getPjProjectDataFromId, JsonRequestBehavior.AllowGet);
        }


    }
}
  