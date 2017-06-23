using KMSZ.OADemo.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMSZ.OADemo.AutoFac.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public IUserInfoService userInfoService;
        public IRoleService roleService;

    }
}