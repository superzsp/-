using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using KMSZ.OADemo.Model;
using KMSZ.OADemo.BLL;
using System.Linq.Expressions;

namespace KMSZ.OADemo.OAWebServices
{
    /// <summary>
    /// UserInfoServiceSoap 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class UserInfoServiceSoap : System.Web.Services.WebService,IBLL.IUserInfoService
    {

        /*[WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Add(int a,int b)
        {
            return a+ b;
        }*/
        UserInfoService userInfoService = new UserInfoService();

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        [WebMethod]
        public UserInfo Add(UserInfo entity)
        {
            return userInfoService.Add(entity);
        }
        [WebMethod]

        public bool Update(UserInfo entity)
        {
            return userInfoService.Update(entity);
        }
        [WebMethod]

        public bool Delete(UserInfo entity)
        {
            return userInfoService.Delete(entity);
        }
        //[WebMethod]

        public int Delete(params int[] ids)
        {
            return userInfoService.Delete(ids);
        }
       // [WebMethod]

        public IQueryable<UserInfo> LoadTs(Expression<Func<UserInfo, bool>> whereLambda)
        {
            return userInfoService.LoadTs(whereLambda);
        }
       // [WebMethod]

        public IQueryable<UserInfo> LoadTs<S>(int pageSize, int pageIndex, out int total, Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, S>> orderbyLambda, bool isAsc)
        {
            return userInfoService.LoadTs(pageSize,pageIndex,out total,whereLambda,orderbyLambda,isAsc);
        }
        [WebMethod]

        public int Savechanges()
        {
            return userInfoService.Savechanges();
        }

        public int DeleteIds(params int[] ids)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserInfo> LoadSearchData(SearchUserParam param)
        {
            throw new NotImplementedException();
        }

        public bool SetUserRole(int userId, List<int> roleIds)
        {
            throw new NotImplementedException();
        }
    }
}
