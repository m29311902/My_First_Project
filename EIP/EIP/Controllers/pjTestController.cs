using EIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIP.Controllers
{
    public class pjTestController : Controller
    {
        // GET: pjTest
        public ActionResult Index()
        {
            return View();
        }

        dbEIPEntities db = new dbEIPEntities();
        public string addPj總表(pj總表 data)
        {
           
            db.pj總表.Add(data);
            db.SaveChanges();
            return "ok";

        }

        public string createPj(pj建立 data)
        {

            db.pj建立.Add(data);
            db.SaveChanges();
            return "ok";

        }



        public ActionResult show()
        {
            return View();
        }

        public JsonResult getData()
        {
            //pj總表 a = new pj總表();
            //CreatePj b = new CreatePj();

            //條件篩選find
            var x = db.pj總表.Select(a=>new
            {
                name = a.pjName,
          
            });
            return Json(x, JsonRequestBehavior.AllowGet);
        }
    }

   
}