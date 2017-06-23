using Autofac;
using Autofac.Integration.Mvc;
using KMSZ.OADemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace KMSZ.OADemo.AutoFac.App_Start
{
    public class AutoFacConfig
    {
        public static void RegisterFac()
        {
            var builder = new ContainerBuilder();
            var ass = Assembly.Load("KMSZ.OADemo.AutoFac");
            builder.RegisterControllers(ass);

           // builder.RegisterGeneric(typeof(BaseDal<>))
           //     .InstancePerRequest();
            //将网站控制器与BLL关联
            //builder.RegisterAssemblyTypes(Assembly.Load("KMSZJK.WEB.BLL")).InstancePerRequest();
            builder.RegisterTypes(Assembly.Load("KMSZ.OADemo.BLL").GetTypes()).AsImplementedInterfaces();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}