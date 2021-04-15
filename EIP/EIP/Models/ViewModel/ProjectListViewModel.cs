using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class ProjectListViewModel
    {
        public int 專案編號 { get; set; }

        public string 專案名稱 { get; set; }

        public string 負責人 { get; set; }

        public string 專案建立日期 { get; set; }

        public string 預算 { get; set; }

        public string 實際成本 { get; set; }

        public string 淨利 { get; set; }

        public int 初審審核結果 { get; set; }

        public int 複審審核結果 { get; set; }
        public int 終審審核結果 { get; set; }
        public int 審核階段 { get; set; }

        public string 初審審核意見 { get; set; }

        public string 複審審核意見 { get; set; }
        public string 終審審核意見 { get; set; }
        public int 廠商投標金額 { get; set; }
        public string 專案工作項目 { get; set; }
        public string 專案個人工作 { get; set; }
        public int 專案人數 { get; set; }
        public int 開始時間 { get; set; }
        public int 結束時間 { get; set; }
        public string 工作內容 { get; set; }
        public int 工作時間 { get; set; }
        public string 專案內容 { get; set; }


        public int 員工編號 { get; set; }




        public string 專案團隊 { get; set; }
    }
}