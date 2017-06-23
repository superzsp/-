using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMSZ.OADemo.UI.Protal.Controllers
{
    public class RoleController : BaseController
    {
        public IBLL.IRoleService roleService { get; set; }
        public IBLL.IUserInfoService userInfoService { get; set; }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }
        #region 加载角色信息
        public ActionResult LoadRoles()
        {
            //拿到前台发过来的当前页和页大小
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int total = 0;
            short delNormal = (short)Model.Enum.DelFlagEnum.Normal;
            //拿到当前页数据
            var dpList = roleService.LoadTs(pageSize, pageIndex, out total, d => d.DelFlag == delNormal, d => d.Id, true);
            //进行过滤查询
            var allUsers = userInfoService.LoadTs(u => u.DelFlag == delNormal);
            var joinData = from r in dpList
                               //当前页角色的集合
                           join u in allUsers on r.SubBy equals u.Id
                           select new { r.RoleName, r.Id, r.SubTime, u.UserName, r.SubBy };
            /*var tempData2=from r in dpList
                          from u in allUsers
                          where u.Id==r.SubBy
                          select new { r.RoleName,r.Id,r.SubTime,u.UserName};*/
            //把数据封装成easyui表格用的数据{total:10,rows[]}
            //解决序列成json的时候因为导航属性而导致的循环依赖问题
            var data = new
            {
                total = total,
                rows = (from d in dpList
                        select
                        new { d.Id, d.RoleName, d.DelFlag, d.SubTime, d.SubBy }).ToList()
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 添加
        public ActionResult Add(Model.Role role)
        {
            role.DelFlag = (short)Model.Enum.DelFlagEnum.Normal;
            role.SubBy = 0;// this.LoginUserInso.Id;
            role.SubTime = DateTime.Now;
            roleService.Add(role);
            roleService.Savechanges();
            return Content("ok");
        }
        #endregion
        #region 批量删除
        public ActionResult DeleteIds(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return Content("非法删除");
            }
            //ids:1,3,4
            string[] idsStrs = ids.Split(',');
            List<int> idDelete = new List<int>();

            foreach (var idStr in idsStrs)
            {
                int deleteId = int.Parse(idStr);
                idDelete.Add(deleteId);
            }
            if (roleService.DeleteIds(idDelete.ToArray()) > 0)
            {
                return Content("ok");
            }
            return Content("");
        }
        #endregion
        #region
        public ActionResult Edit(int id)
        {
            ViewData.Model = roleService.LoadTs(r => r.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Role role)
        {
            roleService.Update(role);
            if (roleService.Savechanges() > 0)
            {
                return Content("ok");
            }
            return Content("修改失败");
        }
        #endregion
    }
}