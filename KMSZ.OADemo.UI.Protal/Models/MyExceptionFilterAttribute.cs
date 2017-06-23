using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMSZ.OADemo.UI.Protal.Models
{
    public class MyExceptionFilterAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            //处理错误消息，跳转到一个错误页面
            Common.LogHelper.WriteLog(filterContext.Exception.ToString());
            filterContext.HttpContext.Response.Redirect("/Error.html");
           
        }
    }
}