 
using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.IBLL
{   
	
		public partial interface IActionInfoService:IBaseService<ActionInfo>
		{
		}
	
		public partial interface IDemoService:IBaseService<Demo>
		{
		}
	
		public partial interface IDepartmentService:IBaseService<Department>
		{
		}
	
		public partial interface IMenuInfoService:IBaseService<MenuInfo>
		{
		}
	
		public partial interface IR_User_ActionInfoService:IBaseService<R_User_ActionInfo>
		{
		}
	
		public partial interface IRoleService:IBaseService<Role>
		{
		}
	
		public partial interface IUserInfoService:IBaseService<UserInfo>
		{
		}
	
		public partial interface IUserInfoMetaService:IBaseService<UserInfoMeta>
		{
		}
	
		public partial interface IWorkTimeService:IBaseService<WorkTime>
		{
		}
}	