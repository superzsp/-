using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMSZ.OADemo.UI.Protal.Controllers
{
    public class ActionInfoController : BaseController
    {
        public IBLL.IActionInfoService actionInfoService { get; set; }
        public IBLL.IRoleService roleService { get; set; }
        // GET: ActionInfo
        public ActionResult Index()
        {
            return View();
        }
        #region 加载权限
        public ActionResult LoadActionInfos()
        {
            //拿到前台发过来的当前页和页大小
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int total = 0;
            short delNormal = (short)Model.Enum.DelFlagEnum.Normal;
            //拿到当前页数据
            var dpList = actionInfoService.LoadTs(pageSize, pageIndex, out total, d => d.DelFlag == delNormal, d => d.Id, true);
            //解决序列成json的时候因为导航属性而导致的循环依赖问题
            var data = new
            {
                total = total,
                rows =from a in dpList
                      select new { a.Id,a.ActionName,a.HttpMethod,a.Remark,a.Url,a.SubTime,a.SubBy,a.Controller,a.ActionMethod}
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 添加
        public ActionResult Add(ActionInfo actionInfo)
        {
            actionInfo.ActionMethod = string.Empty;
            actionInfo.Controller = string.Empty;
            actionInfo.SubBy = 1;
            actionInfo.SubTime = DateTime.Now;
            actionInfo.DelFlag = (short)Model.Enum.DelFlagEnum.Normal;
            actionInfoService.Add(actionInfo);
            actionInfoService.Savechanges();
            return Content("ok");
        }
        #endregion
        #region 修改
        public ActionResult Edit(int id)
        {
            return View(actionInfoService.LoadTs(a=>a.Id==id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(ActionInfo actionInfo)
        {
            actionInfoService.Update(actionInfo);
            actionInfoService.Savechanges();
            return Content("ok");
        }
        #endregion
        #region  设置角色
        public ActionResult SetRole(int id)
        {
            short delFlag = (short)Model.Enum.DelFlagEnum.Normal;
            var actionInfo = actionInfoService.LoadTs(a => a.Id == id).FirstOrDefault();
            ViewBag.AllRoles =roleService.LoadTs(r=>r.DelFlag==delFlag).ToList();
            ViewBag.ExistRoleIds = (from r in actionInfo.Role
                                     select r.Id).ToList();
            return View(actionInfo);
        }
        [HttpPost]
        public ActionResult SetRole()
        {
            int actionId = int.Parse(Request["hidActionId"]);
            List<int> checkedRoleIds = new List<int>();
            foreach (var key in Request.Form.AllKeys)
            {
                if (key.StartsWith("CKB_"))
                {
                    checkedRoleIds.Add(int.Parse(key.Replace("CKB_", "")));
                }
            }
            //调用业务逻辑层，保存用户和角色的关联
            actionInfoService.SetActionRole(actionId, checkedRoleIds);
            return Content("ok");
        }
        #endregion
    }
}