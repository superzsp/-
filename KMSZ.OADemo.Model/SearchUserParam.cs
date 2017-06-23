using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.Model
{
    public class SearchUserParam:BaseQueryParam
    {
        public string SName { get; set; }
        public string  SMail { get; set; }
    }
}
