
using KMSZ.OADemo.DAL;
using KMSZ.OADemo.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.DalFactory
{
    /// <summary>
    /// DbSession本质就是一个简单工厂，就是这么一个简单工厂，但从抽象意义上来说，它就是整个数据库访问层的统一入口
    /// 因为拿到了DbSession就能够拿到整个数据库访问层所有的dal
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class DbSession:IDbSession
    {
        /*public IUserInfoDal UserInfoDal {
            get
            {
                return new UserInfoEFDal();
            }
        }
        public IRoleDal RoleDal {
            get
            {
                return new RoleDal();
            }
        }*/
        public int saveChanges()
        {
            //只需要调用当前线程内部上下文SaveChange就完事了
            DbContext dbContext = EFDbContextFactory.GetCurrentDbContext();
            return dbContext.SaveChanges();
        }
    }
}
