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
        int SetActionRole(int actionId, List<int> roleIds);
    }
}
