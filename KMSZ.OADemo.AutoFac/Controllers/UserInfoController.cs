using KMSZ.OADemo.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMSZ.OADemo.AutoFac.Controllers
{
    public class UserInfoController :BaseController
    {
        public UserInfoController(
            IUserInfoService userInfoService,
            IRoleService roleService
            )
        {
            base.userInfoService = userInfoService;
            base.roleService = roleService;
        }

        // GET: UserInfo
        public ActionResult Index()
        {
            ViewData.Model = userInfoService.LoadTs(u => true).AsEnumerable();
            return View();
        }
    }
}