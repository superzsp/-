using KMSZ.OADemo.IBLL;
using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.BLL
{
    public partial class ActionInfoService : BaseService<ActionInfo>, IActionInfoService
    {
        public int SetActionRole(int actionId, List<int> roleIds)
        {
            var action = DbSession.ActionInfoDal.LoadTs(u => u.Id == actionId).FirstOrDefault();
            action.Role.Clear();
            foreach (var roleId in roleIds)
            {
                var role = DbSession.RoleDal.LoadTs(r => r.Id == roleId).FirstOrDefault();
                action.Role.Add(role);
            }
            return this.Savechanges();
        }

    }
}
