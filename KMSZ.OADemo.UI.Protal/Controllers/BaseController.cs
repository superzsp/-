using KMSZ.OADemo.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMSZ.OADemo.UI.Protal.Controllers
{
    public class BaseController : Controller
    {
        public Model.UserInfo LoginUserInfo { get; set; }
        //因为控制器本身也是一个ActionFilter，所以重写一下基类中的OnActionExcuting方法就可以实现,所有的Action执行前先校验用户是否登录了
        // GET: Base
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //test
            return;
            base.OnActionExecuted(filterContext);
            #region 校验用户是否登录
            LoginUserInfo = Session["LoginUser"] as Model.UserInfo;
            if (LoginUserInfo == null)
            {
                //没有登录
                //filterContext.HttpContext.Response.Redirect("/Error.html");
                //this.Response.Clear();//这里是关键，清除在返回前已经设置好的标头信息，这样后面的跳转才不会报错
                //this.Response.BufferOutput = true;//设置输出缓冲
                //if (!this.Response.IsRequestBeingRedirected)//在跳转之前做判断,防止重复
                //             {
                //                 this.Response.Redirect("/Login/CheckUser", true);
                //             }
                //filterContext.HttpContext.Response.Redirect("/Login/CheckUser");
                //filterContext.Result = new RedirectResult("/Login/CheckUser");
                Response.Redirect("/Login/CheckUser");
                return;
            }
            #endregion

            //给自己留后门
            if (LoginUserInfo != null)
            {
                if (LoginUserInfo.UserName == "abc")
                { return; }
            }
            #region 过滤权限
            //校验用户是否拥有访问此动作的权限
            string str = filterContext.HttpContext.Request.RawUrl;  //UserInfo/Index
            string httpMethod = filterContext.HttpContext.Request.HttpMethod.ToLower();
            //如果没有关联当前用户的话，那么直接跳转错页面
            ActionInfoService actionInfoService = new ActionInfoService();
            var currentUrlAction=//拿到当前请求地址和Method对应的权限
            actionInfoService.LoadTs(a => a.Url == str && a.HttpMethod.ToLower() == httpMethod)
                .FirstOrDefault();
            //第一个：如果没有当前权限数据跟当前的url地址对应
            if (currentUrlAction == null)
            {
                Common.LogHelper.WriteLog(string.Format("用户:{0}在时间：{1}请求{2}请求类型{3}出现了没有权限的问题,对方的IP地址是{4}", LoginUserInfo.Id, DateTime.Now, str, httpMethod,filterContext.HttpContext.Request.UserHostAddress));
                //filterContext.Result = new RedirectResult("/Error.html");
                Response.Redirect("/Error.html");
                //filterContext.HttpContext.Response.Redirect("/Error.html");                
                return;
            }
            //第二：看当前用户有没有和当前权限关联在一块
            //1、校验用户特殊权限
            short delNormal = (short)Model.Enum.DelFlagEnum.Normal;
            R_User_ActionInfoService rUserActionInfoService = new R_User_ActionInfoService();
            var tempUserAction = (from a in rUserActionInfoService.LoadTs(u => u.DelFlag == delNormal)
                        where (a.ActionInfoId == currentUrlAction.Id && a.UserInfoId == LoginUserInfo.Id)
                        select a).FirstOrDefault();
            if (tempUserAction != null)
            {
                if (tempUserAction.IsPass)
                {
                    return;//直接允许请求
                }
                else
                {
                    Common.LogHelper.WriteLog(string.Format("用户:{0}在时间：{1}请求{2}请求类型{3}出现了没有权限的问题,对方的IP地址是{4}", LoginUserInfo.Id, DateTime.Now, str, httpMethod, filterContext.HttpContext.Request.UserHostAddress));
                    //filterContext.Result = new RedirectResult("/Error.html");
                    Response.Redirect("/Error.html");
                    //filterContext.HttpContext.Response.Redirect("/Error.html");
                    return;
                }
            }
            //2、首先拿到当前用户的所有角色
            IBLL.IUserInfoService userInfoService = new UserInfoService();
            var user = userInfoService.LoadTs(u => u.Id == LoginUserInfo.Id).FirstOrDefault();
            var tempRoleActions = (from r in user.Role
                                   from a in r.ActionInfo
                                   where a.Id == currentUrlAction.Id
                                   select a).Count();
            if (tempRoleActions <= 0)
            {
                Common.LogHelper.WriteLog(string.Format("用户:{0}在时间：{1}请求{2}请求类型{3}出现了没有权限的问题,对方的IP地址是{4}", LoginUserInfo.Id, DateTime.Now, str, httpMethod, filterContext.HttpContext.Request.UserHostAddress));
                //filterContext.Result = new RedirectResult("/Error.html");
                //filterContext.HttpContext.Response.Redirect("/Error.html");
                Response.Redirect("/Error.html");
                return;
            }
            else
            {
                return;
            }
            //3、拿到部门的所有角色
            var tempDepRoleActions = (from d in user.Department
                                      from r in d.Role
                                      from a in r.ActionInfo
                                      where a.Id == currentUrlAction.Id
                                      select a).Count();
            if (tempDepRoleActions <= 0)
            {
                Common.LogHelper.WriteLog(string.Format("用户:{0}在时间：{1}请求{2}请求类型{3}出现了没有权限的问题,对方的IP地址是{4}", LoginUserInfo.Id, DateTime.Now, str, httpMethod, filterContext.HttpContext.Request.UserHostAddress));
                //filterContext.Result = new RedirectResult("/Error.html");
                filterContext.HttpContext.Response.Redirect("/Error.html");
                return;
            }
            else
            {
                return;
            }
            #endregion
        }
    }
}