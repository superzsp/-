using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.DAL
{
    public class EFDbContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            //return new DataModelContainer();
            //先去内存线程数据槽理去拿数据，如果有数据直接返回，如果没有则创建一个EF上下文，然后放到数据槽里面去，返回数据
            DbContext db = (DbContext)CallContext.GetData("DbContext");
            if (db == null)
            {
                db = new DataModelContainer();
                CallContext.SetData("DbContext",db);
            }
            return db;
        }
    }
}
