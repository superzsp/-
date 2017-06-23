 

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
   public partial class DalSimpleFactory
   {
	
		public static IDAL.IActionInfoDal GetActionInfoDal()
        {
            return new ActionInfoDal(); 
        }
	
		public static IDAL.IDemoDal GetDemoDal()
        {
            return new DemoDal(); 
        }
	
		public static IDAL.IDepartmentDal GetDepartmentDal()
        {
            return new DepartmentDal(); 
        }
	
		public static IDAL.IMenuInfoDal GetMenuInfoDal()
        {
            return new MenuInfoDal(); 
        }
	
		public static IDAL.IR_User_ActionInfoDal GetR_User_ActionInfoDal()
        {
            return new R_User_ActionInfoDal(); 
        }
	
		public static IDAL.IRoleDal GetRoleDal()
        {
            return new RoleDal(); 
        }
	
		public static IDAL.IUserInfoDal GetUserInfoDal()
        {
            return new UserInfoDal(); 
        }
	
		public static IDAL.IUserInfoMetaDal GetUserInfoMetaDal()
        {
            return new UserInfoMetaDal(); 
        }
	
		public static IDAL.IWorkTimeDal GetWorkTimeDal()
        {
            return new WorkTimeDal(); 
        }
}	
}