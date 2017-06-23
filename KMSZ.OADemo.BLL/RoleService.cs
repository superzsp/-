using KMSZ.OADemo.IBLL;
using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.BLL
{
    public partial class RoleService : BaseService<Role>,IRoleService
    {
        public int DeleteIds(params int[] ids) {
            foreach (var id in ids)
            {
                var user = DbSession.RoleDal.LoadTs(u => u.Id == id).FirstOrDefault();
                user.DelFlag = (short)Model.Enum.DelFlagEnum.Deleted;
            }
            return DbSession.saveChanges();
        }
    }
}
