 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.IDAL
{
   public partial interface IDbSession
	{
	
	IDAL.IActionInfoDal ActionInfoDal { get; }
	
	IDAL.IDemoDal DemoDal { get; }
	
	IDAL.IDepartmentDal DepartmentDal { get; }
	
	IDAL.IMenuInfoDal MenuInfoDal { get; }
	
	IDAL.IR_User_ActionInfoDal R_User_ActionInfoDal { get; }
	
	IDAL.IRoleDal RoleDal { get; }
	
	IDAL.IUserInfoDal UserInfoDal { get; }
	
	IDAL.IUserInfoMetaDal UserInfoMetaDal { get; }
	
	IDAL.IWorkTimeDal WorkTimeDal { get; }
}	
}