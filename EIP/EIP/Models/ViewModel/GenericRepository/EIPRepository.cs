using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EIP.Models;
using EIP.Models.ViewModel;

namespace EIP.Models.GenericRepository
{

    // 實作的方法

    public class EIPRepository<Table> : IRepository<Table> where Table : class
    {
        dbEIPEntities db = null;  // 底層為DbContext
        DbSet<Table> dbTable = null;  // EntityFramework 的屬性

        public EIPRepository()
        {
            db = new dbEIPEntities(); // 建立StoreDBEntities的實體

            dbTable = db.Set<Table>();
        }
        public IEnumerable<Table> GetAll() // 抓全部資料
        {
            return dbTable;
        }
        public void Create(Table _entity)
        {
            dbTable.Add(_entity);      // 新增資料
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            dbTable.Remove(GetByID(ID));    // 刪除指定的單筆資料
            db.SaveChanges();
        }

        public Table GetByID(int ID)
        {
            return dbTable.Find(ID);      // 讀取指定的資料
        }

        public void Update(Table _entity)
        {
            db.Entry<Table>(_entity).State = EntityState.Modified;   //  修改單筆資料
            db.SaveChanges();
        }
    }
}