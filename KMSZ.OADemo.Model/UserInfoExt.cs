using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSZ.OADemo.Model
{
   public partial  class UserInfo
    {
        public UserInfo(bool isInit)
        {
            if (isInit)
            {
                this.Init();
            }
        }
        public void Init()
        {
            this.DelFlag = (short)Enum.DelFlagEnum.Normal;
            this.SubTime =DateTime.Now;
            //this.Remark = string.Empty;
            //this.Phone = string.Empty;
            //this.Mail = string.Empty;
            //this.UserName = string.Empty;
        }
    }
}
