 

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
   public partial class DbSession:IDbSession
   {
	
		public IActionInfoDal ActionInfoDal {
            get
            {
                return new ActionInfoDal();
            }
        }
	
		public IDemoDal DemoDal {
            get
            {
                return new DemoDal();
            }
        }
	
		public IDepartmentDal DepartmentDal {
            get
            {
                return new DepartmentDal();
            }
        }
	
		public IMenuInfoDal MenuInfoDal {
            get
            {
                return new MenuInfoDal();
            }
        }
	
		public IR_User_ActionInfoDal R_User_ActionInfoDal {
            get
            {
                return new R_User_ActionInfoDal();
            }
        }
	
		public IRoleDal RoleDal {
            get
            {
                return new RoleDal();
            }
        }
	
		public IUserInfoDal UserInfoDal {
            get
            {
                return new UserInfoDal();
            }
        }
	
		public IUserInfoMetaDal UserInfoMetaDal {
            get
            {
                return new UserInfoMetaDal();
            }
        }
	
		public IWorkTimeDal WorkTimeDal {
            get
            {
                return new WorkTimeDal();
            }
        }
}	
}