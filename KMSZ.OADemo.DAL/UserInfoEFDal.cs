using KMSZ.OADemo.IDAL;
using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.DAL
{
    public partial class UserInfoEFDal:BaseDal<UserInfo>,IUserInfoDal
    {
        //单元测试：能够极大的提高开发效率
        //可以通过单元测试进行项目的进度控制
        //单元测试其实是另外一种设计
        //单元测试是非常好第三方的学习工具
        //单元测试可以进行辅助我们进行压力测试
       
    }
}
