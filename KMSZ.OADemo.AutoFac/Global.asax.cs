using Autofac;
using Autofac.Integration.Mvc;
using KMSZ.OADemo.AutoFac.App_Start;
using KMSZ.OADemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KMSZ.OADemo.AutoFac
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoFacConfig.RegisterFac();            
        }
    }
}
