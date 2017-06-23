using KMSZ.OADemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMSZ.OADemo.UI.Protal.Controllers
{
    public class MenuController : Controller
    {
        IBLL.IMenuInfoService menuInfoService { get; set; }
        IBLL.IActionInfoService actionInfoService { get; set; }
        short delNormal = (short)Model.Enum.DelFlagEnum.Normal;
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadMenu()
        {
            //拿到前台发过来的当前页和页大小
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int total = 0;
            //拿到当前页数据
            var dpList = menuInfoService.LoadTs(pageSize, pageIndex, out total, d => d.DelFlag == delNormal, d => d.Id, true);
            var allActions = actionInfoService.LoadTs(a => a.DelFlag == delNormal);
            //解决序列成json的时候因为导航属性而导致的循环依赖问题
            var data = new
            {
                total = total,
                rows = from a in dpList
                       from ac in allActions
                       where a.ActionInfoId == ac.Id
                       select new { a.Id, a.MenuName, a.Remark, a.Sort, a.IconUrl, a.SubTime, a.SubBy, a.IsVisable, a.ActionInfoId,ac.ActionName,ac.Url,a.DialogHeight,a.DialogWidth }
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UploadMenu()
        {
            if (Request.Files["iconImg"] != null)
            {
                string imagePath = "/Upload/Images";
                var requestFile = Request.Files["iconImg"];
                string fileName = imagePath + Guid.NewGuid().ToString() + requestFile.FileName;
                requestFile.SaveAs(Server.MapPath(fileName));
                return Content(fileName);
            }
            return Content("");
        }
        public ActionResult Add(MenuInfo menuInfo)
        {
            menuInfo.DelFlag = delNormal;
            menuInfo.SubBy = 1;
            menuInfo.SubTime = DateTime.Now;
            menuInfo.DialogHeight = 500;
            menuInfo.DialogWidth = 500;
            menuInfo.IsVisable = true;
            menuInfo.ParentId = 1;
            menuInfoService.Add(menuInfo);
            menuInfoService.Savechanges();
            return Content("ok");
        }
    }
}