using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KMSZ.OADemo.DAL;
using KMSZ.OADemo.Model;

namespace KMSZ.OADemo.UnitTest
{
    [TestClass]
    public class UserInfoEFDalUnitTest
    {
        [TestMethod]
        public void AddTest()
        {
            //调用一下要测试的方法，考虑：边界值，正确值，错误值
            UserInfoEFDal userInfoDal = new UserInfoEFDal();
            UserInfo userInfo = new UserInfo();
            userInfo.Pwd = "12345";
            userInfo.UserName = "tiger1";
            userInfoDal.Add(userInfo);
            Assert.AreEqual(true,userInfo.Id>0);//断言两个参数相等
        }
        [TestMethod]
        public void LoadPageData()
        {
          /*  //调用一下要测试的方法，考虑：边界值，正确值，错误值
            UserInfoEFDal userInfoDal = new UserInfoEFDal();
            int total = 0;
            var data = userInfoDal.LoadUserInfos(2, 1,out total, u => u.Id < 100, u => u.Id, true);
            Assert.AreEqual(true, total > 0);
            //自己做单元测试必须创建测试数据，测试完成后必须清理完数据*/
        }

    }
}
