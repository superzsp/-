 
using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.IDAL
{
   
	
	public partial interface IActionInfoDal:IBaseDal<ActionInfo>
    {
    }
	
	public partial interface IDemoDal:IBaseDal<Demo>
    {
    }
	
	public partial interface IDepartmentDal:IBaseDal<Department>
    {
    }
	
	public partial interface IMenuInfoDal:IBaseDal<MenuInfo>
    {
    }
	
	public partial interface IR_User_ActionInfoDal:IBaseDal<R_User_ActionInfo>
    {
    }
	
	public partial interface IRoleDal:IBaseDal<Role>
    {
    }
	
	public partial interface IUserInfoDal:IBaseDal<UserInfo>
    {
    }
	
	public partial interface IUserInfoMetaDal:IBaseDal<UserInfoMeta>
    {
    }
	
	public partial interface IWorkTimeDal:IBaseDal<WorkTime>
    {
    }
	
}