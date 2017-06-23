using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KMSZ.OADemo.UI.Protal
{
    public class MvcApplication : Spring.Web.Mvc.SpringMvcApplication// System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ReadLogAndWriteLog();

            //配置log4net日志
            log4net.Config.XmlConfigurator.Configure();
        }

        private void ReadLogAndWriteLog()
        {
           /* ThreadPool.QueueUserWorkItem(s =>
            {
                while (true)
                {
                    string str = Common.LogHelper.LogTextQueue.Dequeue();
                    Console.WriteLine(str);//写进日志
                    Thread.Sleep(300);
                }
            });*/
         }
        /*protected void Application_Error()
{ }*/
    }
}
