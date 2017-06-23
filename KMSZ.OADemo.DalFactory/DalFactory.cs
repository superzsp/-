using KMSZ.OADemo.DAL;
using KMSZ.OADemo.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.DalFactory
{
   public partial  class DalSimpleFactory
    {
        /*public static IDAL.IUserInfoDal GetUserInfoDal()
        {
            //如果直接new的话那必须改变代码才能切换不同数据库访问层
            //非常希望做到：只改变配置就能创建出实例来，也就是改变数据库访问层的实现
            //return GetInstences("KMSZ.OADemo.DAL", "KMSZ.OADemo.DAL." + "UserInfoEFDal") as IUserInfoDal;
            return new UserInfoEFDal();
        }
        public static IDAL.IRoleDal GetRoleDal()
        {
            return new RoleDal(); 
        }*/
        public static object GetInstences(string assemblyName, string typeName)
        {
            return Assembly.Load(assemblyName).CreateInstance(typeName);
        }
    }
}
