using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Models.GenericRepository
{ 
    // 定義方法格式
    interface IRepository<Table>
    {
        IEnumerable<Table> GetAll();
        void Create(Table _entity);
        void Update(Table _entity);
        Table GetByID(int ID);
        void Delete(int ID);
    }
}
