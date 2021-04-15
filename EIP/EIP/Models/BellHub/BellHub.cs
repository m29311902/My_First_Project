using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EIP.Models.BellHub
{
    [HubName("bell")]
    public class BellHub : Hub
    {
        dbEIPEntities db = new dbEIPEntities();
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        public void SendGroup(int 類別, string 職稱, string message,string[] 權限) //對特定群組發送通知  
        {
            foreach(var x in 權限)
            { 
            var 通知 = new 通知
            {
                通知類別id = 類別,
                通知內容 = message,
                讀取狀態 = "未讀",
                通知權限= x.ToString()
            };
            db.通知.Add(通知);
            db.SaveChanges();
            }
            var 通知類別轉換 = db.通知類別.FirstOrDefault(m => m.通知類別id == 類別);

            if (職稱 == "員工")
            {
                Clients.Group("員工").sendlv1(通知類別轉換.通知類別1, message,權限[3]);
                Clients.Group("人事").sendlv2(通知類別轉換.通知類別1, message, 權限[2]);
                Clients.Group("主管").sendlv3(通知類別轉換.通知類別1, message, 權限[1]);
                Clients.Group("總經理").sendtop(通知類別轉換.通知類別1, message, 權限[0]);//sendtop=前端的function(自定義)
            }
            if (職稱 == "人事")
            {
                Clients.Group("人事").sendlv2(通知類別轉換.通知類別1, message,權限[2]);
                Clients.Group("主管").sendlv3(通知類別轉換.通知類別1, message,權限[1]);
                Clients.Group("總經理").snedlvtop(通知類別轉換.通知類別1, message, 權限[0]); //sendtop=前端的function(自定義)
            }
            if(職稱 == "主管")
            {
                Clients.Group("主管").sendtop(通知類別轉換.通知類別1, message, 權限[1]);
                Clients.Group("總經理").sendtop(通知類別轉換.通知類別1, message, 權限[0]);
            }
        }
        public void Setgroup(int id)  //設定特定群組
        {
           var connectedID = db.個人資料.FirstOrDefault(c => c.EmployeeID == id);
            var 發送職稱 = connectedID.職稱;
            if (發送職稱 == "員工")
            {
                Groups.Add(Context.ConnectionId, "員工");
            }
            if (發送職稱 == "人事")
            {
                Groups.Add(Context.ConnectionId,"人事");
            }
            if (發送職稱 == "主管")
            {
                Groups.Add(Context.ConnectionId, "主管");
            }
            if (發送職稱 == "總經理")
            {
                Groups.Add(Context.ConnectionId, "總經理");
            }
        }
        //public void forgetpwreq(int EmpID ,string EmpEmail )
        //{
        //    var mmb = db.個人資料.FirstOrDefault(m => m.信箱 == EmpEmail && m.EmployeeID == EmpID);
        //    if (mmb == null)
        //    {
        //        Clients.All.chpw("員工編號與帳號不符合!,請重新輸入！");
        //    }
        //    else
        //    {
        //        db.個人資料.FirstOrDefault(x => x.EmployeeID == EmpID).EmployeePW = "123456";            
        //        db.SaveChanges();
        //         Clients.All.chpw("密碼已重置為123456!,請於登入後,盡速修改個人登入密碼！");

        //    }
        //}
    }
}