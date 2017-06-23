using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMSZ.OADemo.UI.Protal.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public IBLL.IUserInfoService userInfoService { get; set; }
        public IBLL.IRoleService roleService { get; set; }
        public IBLL.IActionInfoService actionInfoService { get; set; }
        public IBLL.IR_User_ActionInfoService r_User_ActionInfoService { get; set; }
        public IBLL.IMenuInfoService menuInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadMenu()
        {
            short del = (short)Model.Enum.DelFlagEnum.Normal;            
            int id = (Session["LoginUser"] as Model.UserInfo).Id;

            //返回当前用户的菜单数据
            //加载用户所有角色,拿到所有角色权限
            var user = userInfoService.LoadTs(u => u.Id == id).FirstOrDefault();
            //拿到所有角色权限的ID
            var allRoleActionsIds =(from r in user.Role
                                 from a in r.ActionInfo
                                 where a.DelFlag==del&&r.DelFlag==del
                                 select a.Id).ToList();
            //拿到当前用户所有的允许的特殊权限
            var allUserActionIsPass = from r in user.R_User_ActionInfo
                                      where r.IsPass == true
                                      select r.ActionInfoId;
            //合并起来的所有允许项
            allRoleActionsIds.AddRange(allUserActionIsPass);
            //去掉不允许的
            var allNotPassUserActions = (from r in user.R_User_ActionInfo
                                         where r.IsPass == false
                                         select r.ActionInfoId).ToList();
            var result =(from a in allRoleActionsIds
                         where !allNotPassUserActions.Contains(a)
                         select a).ToList();
            //拿到当前用户所有的权限Id
            result =result.Distinct().ToList();
            //用权限跟Menu表进行join查询就行
            var allMenus = menuInfoService.LoadTs(m => true);
            var allActions = actionInfoService.LoadTs(a => true);
            var allMenuData = from m in allMenus
                              from a in allActions
                              where result.Contains(m.ActionInfoId)
                              where a.Id==m.ActionInfoId
                              select new { icon=m.IconUrl,title=m.MenuName,url=a.Url};
            return Json(allMenuData.ToList(), JsonRequestBehavior.AllowGet);
            //return Content("ok");
            //{ icon: '../../Content/Images/3DSMAX.png', title: '菜单管理', url: '/Menu/Index' },
                
        }
    }
}