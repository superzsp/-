using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.Model
{
    public class BaseQueryParam
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }

    }
}
