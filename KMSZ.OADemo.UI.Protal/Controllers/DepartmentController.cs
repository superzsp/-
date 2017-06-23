using KMSZ.OADemo.BLL;
using KMSZ.OADemo.IBLL;
using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMSZ.OADemo.UI.Protal.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public IBLL.IDepartmentService departmentService { get; set; } //=new DepartmentService();//{ get; set; }//
        public ActionResult Index()
        {
            return View();
        }
        
        #region 显示表格数据集
        public ActionResult GetDepartment(string SName, string SMail)
        {
            //拿到前台发过来的当前页和页大小
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int total = 0;
            short delNormal = (short)Model.Enum.DelFlagEnum.Normal;
            //拿到当前页数据
            var dpList= departmentService.LoadTs(pageSize, pageIndex, out total, d => d.DelFlag==delNormal, d => d.Id, true);
            //进行过滤查询

            /*
            Model.SearchUserParam userParam = new SearchUserParam();
            userParam.PageSize = pageSize;
            userParam.PageIndex = pageIndex;
            userParam.SMail = SMail;
            userParam.SName = SName;
            var pageData = departmentService.LoadSearchData(userParam);
            */
            //把数据封装成easyui表格用的数据{total:10,rows[]}
            //解决序列成json的时候因为导航属性而导致的循环依赖问题
            var data = new
            {
                total = total,
                rows = (from d in dpList
                        select
                        new { d.Id,d.DepName,d.DelFlag,d.DepMasterId,d.DepNo,d.SubTime,d.SubBy }).ToList()
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 添加
        public ActionResult Add(Department department)
        {
            department.DelFlag = (short)Model.Enum.DelFlagEnum.Normal;
            department.IsLeaf = true;
            department.Lever = 0;
            //department.ParentId = 0;
            department.SubBy = 0;
            department.SubTime = DateTime.Now;
            department.TreePath = string.Empty;
           

            departmentService.Add(department);
            if (departmentService.Savechanges() > 0)
            {
                return Content("ok");
            }
            else
            {
                return Content("添加失败");
            }
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
            if (departmentService.DeleteIds(idDelete.ToArray()) > 0)
            {
                return Content("ok");
            }
            return Content("");
        }
        #endregion
        #region 修改
        public ActionResult EditDep(int id)
        {
            ViewData.Model = departmentService.LoadTs(u => u.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult EditDep(Department dep)
        {
            //dep.Init();
            departmentService.Update(dep);
            if (departmentService.Savechanges() > 0)
            {
                return Content("ok");
            }
            return Content("修改失败");
        }
        #endregion
        #region 加载数据
        public ActionResult GetTreeDepNodes()
        {
            short delNormal = (short)Model.Enum.DelFlagEnum.Normal;
            var allDep = from d in departmentService.LoadTs(u => u.DelFlag == delNormal)
                         select new { CategoryId = d.Id, ParentId = d.ParentId, Name = d.DepName };
            return Json(allDep, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}