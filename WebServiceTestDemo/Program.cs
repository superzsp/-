using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            OAServices.UserInfoServiceSoapSoapClient client = new OAServices.UserInfoServiceSoapSoapClient();
            Console.Write(client.Add(5,6));
            Console.ReadKey();
        }
    }
}
