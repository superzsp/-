using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.IDAL
{
    public partial interface IDbSession
    {
       // IDAL.IRoleDal RoleDal { get; }
       // IDAL.IUserInfoDal UserInfoDal { get; }
        int saveChanges();
    }
}
