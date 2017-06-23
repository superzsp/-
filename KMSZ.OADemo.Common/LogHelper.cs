using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.Common
{
    public class LogHelper
    {
        public static Queue<string> LogTextQueue = new Queue<string>();
        public static void WriteLog(string txt)
        {
            ILog log = log4net.LogManager.GetLogger("log4netlogger");
            log.Error(txt);
            /*
            //List,Queue,Stact都是线程安全的
            LogTextQueue.Enqueue(txt);

            //每次new的是否是同一个应用地址
            string str = "aaaa";
            //去掉并发的问题，仍然没有解决性能问题
            lock(str)
            {   //有可能写入到数据库、文本文件、通过webservice存到另一个地方，直接放在当前内存中
                using (StreamWriter sw = new StreamWriter(@"e:\d\a.txt", true, Encoding.Default))
                {
                }
            }*/
            //同一时间文件只能被一个线程访问
            Console.WriteLine(txt);
        }
    }
}
