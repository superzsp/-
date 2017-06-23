 
using KMSZ.OADemo.DAL;
using KMSZ.OADemo.DalFactory;
using KMSZ.OADemo.IBLL;
using KMSZ.OADemo.IDAL;
using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.BLL
{
	
	 public partial class ActionInfoService : BaseService<ActionInfo>,IActionInfoService
		{
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.ActionInfoDal;
        }
		}
		
	
	 public partial class DemoService : BaseService<Demo>,IDemoService
		{
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.DemoDal;
        }
		}
		
	
	 public partial class DepartmentService : BaseService<Department>,IDepartmentService
		{
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.DepartmentDal;
        }
		}
		
	
	 public partial class MenuInfoService : BaseService<MenuInfo>,IMenuInfoService
		{
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.MenuInfoDal;
        }
		}
		
	
	 public partial class R_User_ActionInfoService : BaseService<R_User_ActionInfo>,IR_User_ActionInfoService
		{
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.R_User_ActionInfoDal;
        }
		}
		
	
	 public partial class RoleService : BaseService<Role>,IRoleService
		{
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.RoleDal;
        }
		}
		
	
	 public partial class UserInfoService : BaseService<UserInfo>,IUserInfoService
		{
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.UserInfoDal;
        }
		}
		
	
	 public partial class UserInfoMetaService : BaseService<UserInfoMeta>,IUserInfoMetaService
		{
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.UserInfoMetaDal;
        }
		}
		
	
	 public partial class WorkTimeService : BaseService<WorkTime>,IWorkTimeService
		{
		public override void SetCurrentDal()
        {
            CurrentDal = DbSession.WorkTimeDal;
        }
		}
		
}	