using EIP.Models.ViewModel;
using EIP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace EIP.Controllers
{
    public class HomeController : Controller
    {
        dbEIPEntities db = new dbEIPEntities();

        public ActionResult Index()
        {
            return View();
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
        public ActionResult Login()
        {
          

            return View();
        }
        public JsonResult AccPwCheck(LoginViewModel LoginVM)
        {
            var x = new
            {
                信箱 = LoginVM.信箱,
                EmployeePW = LoginVM.EmployeePW,
                記住我 = LoginVM.RememberMe
            };


            var mmb = db.個人資料.FirstOrDefault(m => m.信箱 == x.信箱 && m.EmployeePW == x.EmployeePW);
            if (mmb == null)
            {
                Response.Cookies["AutoLg"].Expires = DateTime.Now.AddDays(-1);
                return Json(new { status = "" }, JsonRequestBehavior.AllowGet);
            }

            if (mmb != null)
            {
                Response.Cookies["AutoLg"]["id"] = mmb.EmployeeID.ToString();
                Response.Cookies["AutoLg"]["Name"] = Server.UrlEncode(mmb.中文姓名);
                Response.Cookies["AutoLg"]["Auth"] = Server.UrlEncode(mmb.職稱);
                Response.Cookies["AutoLg"]["Hire"] = mmb.受雇日期;
                if (LoginVM.RememberMe)
                {
                    Response.Cookies["AutoLg"].Expires = DateTime.Now.AddDays(30);
                }
            }
            return Json(mmb, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut()
        {
            Response.Cookies["AutoLg"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Login", "Home");
        }
        [HttpGet]
        public JsonResult MyProfile()
        {
            個人資料 UserProfile = db.個人資料.Find(Convert.ToInt32(Request.Cookies["AutoLg"]["id"]));
            var mvm = new
            {
                中文姓名 = UserProfile.中文姓名,
                英文姓名 = UserProfile.英文姓名,
                性別 = UserProfile.性別,
                EmployeeID = UserProfile.EmployeeID,
                出生年月日 = UserProfile.出生年月日,
                受雇日期 = UserProfile.受雇日期,
                職稱 = UserProfile.職稱,
                部門 = UserProfile.部門,
                信箱 = UserProfile.信箱,
                電話 = UserProfile.電話,
                居住地 = UserProfile.居住地,
                婚姻狀況 = UserProfile.婚姻狀況,
                特休 = UserProfile.特休,
                薪資 = UserProfile.薪資,
                權限 = UserProfile.權限,
                狀態 = UserProfile.狀態,
            };
            return Json(mvm, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditPW(string pw)
        {
            int ID = Convert.ToInt32(Request.Cookies["AutoLg"]["id"]);
            db.個人資料.FirstOrDefault(x => x.EmployeeID == ID).EmployeePW = pw;    
            db.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult HRShow()
        {

            return View();
        }
   
      
        public JsonResult HRShowEdit()
        {
            var qqm = (from m in db.個人資料
                      orderby m.EmployeeID descending
                      select new 
                      {   
                          EmployeePW = m.EmployeePW,
                          中文姓名 = m.中文姓名,
                          英文姓名 = m.英文姓名,
                          性別 = m.性別,
                          EmployeeID = m.EmployeeID,
                          出生年月日 = m.出生年月日,
                          受雇日期 = m.受雇日期,
                          職稱 = m.職稱,
                          部門 = m.部門,
                          信箱 = m.信箱,
                          電話 = m.電話,
                          居住地 = m.居住地,
                          婚姻狀況 = m.婚姻狀況,
                          特休 = m.特休,
                          薪資 = m.薪資,
                          權限 = m.權限,
                          總比數= db.個人資料.Count()                         
                      });
            
            return Json(qqm, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]    
        public JsonResult HREditt(int id)
        {
            個人資料 EditProfile = db.個人資料.Find(id);
            var MVM = new
            {

                EmployeePW = EditProfile.EmployeePW,
                中文姓名 = EditProfile.中文姓名,
                英文姓名 = EditProfile.英文姓名,
                性別 = EditProfile.性別,
                EmployeeID = EditProfile.EmployeeID,
                出生年月日 = EditProfile.出生年月日,
                受雇日期 = EditProfile.受雇日期,
                職稱 = EditProfile.職稱,
                部門 = EditProfile.部門,
                信箱 = EditProfile.信箱,
                電話 = EditProfile.電話,
                居住地 = EditProfile.居住地,
                婚姻狀況 = EditProfile.婚姻狀況,
                特休 = EditProfile.特休,
                薪資 = EditProfile.薪資,
                權限 = EditProfile.權限,       
                狀態 =EditProfile.狀態,
            };
            return Json(MVM, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult HREdit(個人資料 mlvm)
        {
         
            個人資料 mmb = new 個人資料()
            {
                EmployeePW = mlvm.EmployeePW,
                中文姓名 = mlvm.中文姓名,
                英文姓名 = mlvm.英文姓名,
                性別 = mlvm.性別,
                EmployeeID = mlvm.EmployeeID,
                出生年月日 = mlvm.出生年月日,
                受雇日期 = mlvm.受雇日期,
                職稱 = mlvm.職稱,
                部門 = mlvm.部門,
                信箱 = mlvm.信箱,
                電話 = mlvm.電話,
                居住地 = mlvm.居住地,
                婚姻狀況 = mlvm.婚姻狀況,
                特休 = mlvm.特休,
                薪資 = mlvm.薪資,
                權限 = mlvm.權限,
                狀態 = mlvm.狀態
            };
            db.Entry<個人資料>(mmb).State = EntityState.Modified;
            db.SaveChanges();
            return Json(mmb, JsonRequestBehavior.AllowGet);

        }

        public JsonResult HRAdd(個人資料 mlvm)
        {
            個人資料 mmb = new 個人資料()
            {
                EmployeePW = mlvm.EmployeePW,
                中文姓名 = mlvm.中文姓名,
                英文姓名 = mlvm.英文姓名,
                性別 = mlvm.性別,
                EmployeeID = mlvm.EmployeeID,
                出生年月日 = mlvm.出生年月日,
                受雇日期 = mlvm.受雇日期,
                職稱 = mlvm.職稱,
                部門 = mlvm.部門,
                信箱 = mlvm.信箱,
                電話 = mlvm.電話,
                居住地 = mlvm.居住地,
                婚姻狀況 = mlvm.婚姻狀況,
                特休 = mlvm.特休,
                薪資 = mlvm.薪資,
                權限 = mlvm.權限,
                狀態=mlvm.狀態          
            };
            db.個人資料.Add(mmb);
            db.SaveChanges();
            return Json(mmb, JsonRequestBehavior.AllowGet);
        }
        public JsonResult HRDelete(int id) {
            個人資料 mlvm = db.個人資料.Find(id);
            db.個人資料.Remove(mlvm);
            //mlvm.狀態 = "不在職";
            //db.Entry<個人資料>(mlvm).State = EntityState.Modified;
            db.SaveChanges();
            return Json(mlvm, JsonRequestBehavior.AllowGet);
        }
        public JsonResult HRSearch(string name)
        {
            var mlvm = from m in db.個人資料
                       where (m.中文姓名.Contains(name))
                       orderby m.EmployeeID descending
                       select m;
            return Json(mlvm.Take(10), JsonRequestBehavior.AllowGet);
        }

        public JsonResult allalertbell(string 權限)  
        {
            var qqm = db.通知.Where(m => m.通知權限 == 權限).Select(m => new
            {
                通知類別id = m.通知類別.通知類別1,
                通知內容 = m.通知內容,
                通知權限 = m.通知權限,
                讀取狀態 = m.讀取狀態,
                流水號 = m.通知流水號
            }).OrderByDescending(m => m.流水號).ToList();
             return Json(qqm.Take(5), JsonRequestBehavior.AllowGet);
        }
        public JsonResult alertcheck(int 第幾筆訊息)
        {
            var qqm = db.通知.Find(第幾筆訊息);
            qqm.讀取狀態 = "已讀";
            db.SaveChanges();
            

            return Json(qqm, JsonRequestBehavior.AllowGet);

        }
        public string forgetpw(int 員工編號,string 信箱) {
            var mmb = db.個人資料.FirstOrDefault(m => m.信箱 == 信箱 && m.EmployeeID == 員工編號);
            Random Rdpw = new Random();
            var newpw = Rdpw.Next(1, 10).ToString() + Rdpw.Next(1, 10).ToString() + Rdpw.Next(1, 10).ToString() + Rdpw.Next(1, 10).ToString() + Rdpw.Next(1, 10).ToString() + Rdpw.Next(1, 10).ToString();
            if (mmb == null)
            {
                return "員工編號與帳號不符合!,請重新輸入！";
            }
            else {
                db.個人資料.FirstOrDefault(x => x.EmployeeID == 員工編號).EmployeePW = newpw;
            }
            db.SaveChanges();
            return newpw;
        }
        public string sendGmail(int 員工編號, string 信箱)
        {
            var mmb = db.個人資料.FirstOrDefault(m => m.信箱 == 信箱 && m.EmployeeID == 員工編號);
            Random Rdpw = new Random();

            var newpw = Rdpw.Next(1, 10).ToString() + Rdpw.Next(1, 10).ToString() + Rdpw.Next(1, 10).ToString() + Rdpw.Next(1, 10).ToString() + Rdpw.Next(1, 10).ToString() + Rdpw.Next(1, 10).ToString();

            if (mmb == null)
            {
                return "員工編號與帳號不符合!,請重新輸入！";
            }
            else {

                MailMessage mail = new MailMessage();
                //前面是發信email後面是顯示的名稱
                mail.From = new MailAddress("hu999123000@gmail.com", "人資部");
                //密碼:999123000hu
                //收信者email
                mail.To.Add(信箱);

                //設定優先權
                mail.Priority = MailPriority.Normal;

                //標題
                mail.Subject = "本信件由系統自動發送";

                //內容
                mail.Body = $"<h1>您好,{mmb.中文姓名}！</h1><p>系統已為您將您的登入密碼變更為「 {newpw} 」</p>";  

                //內容使用html
                mail.IsBodyHtml = true;

                //設定gmail的smtp (這是google的)
                SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);

                MySmtp.Port = 25;
                MySmtp.EnableSsl = true;
                //您在gmail的帳號密碼
                MySmtp.Credentials = new System.Net.NetworkCredential("hu999123000@gmail.com", "dokhyabobchypozc");
                //999123000hu
                //開啟ssl
                //MySmtp.EnableSsl = true;

                //發送郵件
                MySmtp.Send(mail);

                //放掉宣告出來的MySmtp
                MySmtp = null;

                //放掉宣告出來的mail
                mail.Dispose();
                db.個人資料.FirstOrDefault(x => x.EmployeeID == 員工編號).EmployeePW = newpw;
            }
            db.SaveChanges();
            return newpw;
        }
    }
}