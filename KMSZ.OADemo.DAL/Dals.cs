 
using KMSZ.OADemo.IDAL;
using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.DAL
{
   
	
	public partial class ActionInfoDal:BaseDal<ActionInfo>,IActionInfoDal
    {
    }
	
	public partial class DemoDal:BaseDal<Demo>,IDemoDal
    {
    }
	
	public partial class DepartmentDal:BaseDal<Department>,IDepartmentDal
    {
    }
	
	public partial class MenuInfoDal:BaseDal<MenuInfo>,IMenuInfoDal
    {
    }
	
	public partial class R_User_ActionInfoDal:BaseDal<R_User_ActionInfo>,IR_User_ActionInfoDal
    {
    }
	
	public partial class RoleDal:BaseDal<Role>,IRoleDal
    {
    }
	
	public partial class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
    {
    }
	
	public partial class UserInfoMetaDal:BaseDal<UserInfoMeta>,IUserInfoMetaDal
    {
    }
	
	public partial class WorkTimeDal:BaseDal<WorkTime>,IWorkTimeDal
    {
    }
	
}