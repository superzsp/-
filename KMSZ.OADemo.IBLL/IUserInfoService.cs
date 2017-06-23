using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.IBLL
{
    public partial interface IUserInfoService : IBaseService<UserInfo>
    {
        string Name { get; set; }
        int DeleteIds(params int[] ids);
        IQueryable<UserInfo> LoadSearchData(Model.SearchUserParam param);
        bool SetUserRole(int userId, List<int> roleIds);
    }
}
