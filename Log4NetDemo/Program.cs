using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //如果使用log4net,应用程序一开始就要进行初始化配置
            log4net.Config.XmlConfigurator.Configure();
            //如果后面传来的字符串是一样的话，那么返回的log对象就是相同的
            ILog log = log4net.LogManager.GetLogger("hello");
            log.Debug("Shitle");
            log.Fatal("50....");
        }
    }
}
