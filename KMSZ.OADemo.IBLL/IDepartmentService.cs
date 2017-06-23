
using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.IBLL
{
    public partial interface IDepartmentService : IBaseService<Department>
    {
        int DeleteIds(params int[] ids);
    }
}
