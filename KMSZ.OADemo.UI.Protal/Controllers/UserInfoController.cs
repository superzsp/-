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
    public class UserInfoController : BaseController
    {
        public IUserInfoService userInfoService{ get; set; }//new UserInfoService();//
        public IRoleService roleService { get; set; }//new UserInfoService();//
        public IActionInfoService actionInfoService { get; set; }//new UserInfoService();//
        public IR_User_ActionInfoService r_User_ActionInfoService { get; set; }//new UserInfoService();//
        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult ShowUsers()
        {
            return View();
        }
        public ActionResult GetAllUserInfos(string SName,string SMail)
        {
            //拿到前台发过来的当前页和页大小
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int total = 0;
            short delNormal = (short)Model.Enum.DelFlagEnum.Normal;
            //拿到当前页数据
            //var pageData= userInfoService.LoadTs(pageSize, pageIndex, out total, u => u.DelFlag==delNormal, u => u.Id, true);
            //进行过滤查询
            
                        Model.SearchUserParam userParam = new SearchUserParam();
                        userParam.PageSize = pageSize;
                        userParam.PageIndex = pageIndex;
                        userParam.SMail = SMail;
                        userParam.SName = SName;
                        var pageData= userInfoService.LoadSearchData(userParam);
             
            //把数据封装成easyui表格用的数据{total:10,rows[]}
            //解决序列成json的时候因为导航属性而导致的循环依赖问题
            var data = new
            {
                total = userParam.Total,
                rows = (from u in pageData
                        select
                        new { u.Id,u.UserName,u.DelFlag,u.Mail,u.Phone,u.SubTime,u.SubBy }).ToList()
            };
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        #region 添加
        public ActionResult Add(UserInfo userInfo)
        {
            userInfo.Init();
            //var user = new UserInfo(true);
            userInfoService.Add(userInfo);
            if (userInfoService.Savechanges() > 0)
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
            if (userInfoService.DeleteIds(idDelete.ToArray()) > 0)
            {
                return Content("ok");
            }
            return Content("");
        }
        #endregion
        #region 修改
        public ActionResult EditUser(int id)
        {
            ViewData.Model = userInfoService.LoadTs(u => u.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult EditUser(UserInfo userInfo)
        {
            userInfo.Init();
            userInfoService.Update(userInfo);
            if (userInfoService.Savechanges() > 0)
            {
                return Content("ok");
            }
            return Content("修改失败");
        }
        #endregion
        #region old
        // GET: UserInfo
        public ActionResult ShowError()
        {
            throw new Exception("demo exception");
        }
        public ActionResult Index()
        {
            //int total = 0;
            //ViewData.Model = userInfoService.LoadTs(10,1,out total,u=>true,u=>u.Id,true).AsEnumerable();
            ViewData.Model = userInfoService.LoadTs(u => true).AsEnumerable();
            return View();
        }
        // GET: UserInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: UserInfo/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: UserInfo/Create
        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            try
            {
                userInfo.DelFlag = 0;
                // userInfo.Mail = string.Empty;
                // userInfo.Phone = string.Empty;
                // userInfo.Remark = string.Empty;
                // userInfo.SubBy = "1";
                userInfo.SubTime = DateTime.Now;
                userInfoService.Add(userInfo);
                userInfoService.Savechanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Common.LogHelper.WriteLog(ex.ToString());
                return View();
            }
        }

        // GET: UserInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion
        #region 设置角色
        public ActionResult SetRole(int id)
        {
            var del = (short)Model.Enum.DelFlagEnum.Normal;
            ViewBag.AllRoles = roleService.LoadTs(u => u.DelFlag ==del).ToList();
            var user = userInfoService.LoadTs(u => u.Id == id).FirstOrDefault();
            ViewData.Model = user;
            ViewBag.ExistRoleIDs = (from r in user.Role
                                   select r.Id).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult SetRole()
        {
            int userId = int.Parse(Request["hidUserId"]);
            List<int> checkedRoleIds = new List<int>();
            foreach (var key in Request.Form.AllKeys)
            {
                if (key.StartsWith("CKB_"))
                {
                    checkedRoleIds.Add(int.Parse(key.Replace("CKB_", "")));
                }
            }
            //调用业务逻辑层，保存用户和角色的关联
            userInfoService.SetUserRole(userId,checkedRoleIds);
            return Content("ok");
        }
        #endregion
        #region 设置用户的特殊权限
        public ActionResult SetAction(int id)
        {
            short delNormal = (short)Model.Enum.DelFlagEnum.Normal;
            ViewData.Model = userInfoService.LoadTs(u => u.Id == id).FirstOrDefault();
            //后台往前台输出所有权限
            ViewBag.AllActionInfos = actionInfoService.LoadTs(a => a.DelFlag == delNormal).ToList();
            ViewBag.ExistUserActions = r_User_ActionInfoService.LoadTs(r => r.DelFlag == delNormal && r.UserInfoId == id).ToList();
            return View();
        }
        public ActionResult SetUserActionPass(R_User_ActionInfo userAction)
        {
            var item = r_User_ActionInfoService.LoadTs(r => r.UserInfoId == userAction.UserInfoId && r.ActionInfoId == userAction.ActionInfoId).FirstOrDefault();
            if (item == null)
            {
                userAction.DelFlag = 0;
                r_User_ActionInfoService.Add(userAction);
                r_User_ActionInfoService.Savechanges();
            }
            else
            {
                item.IsPass = userAction.IsPass;
                item.DelFlag = (short)Model.Enum.DelFlagEnum.Normal;
                r_User_ActionInfoService.Savechanges();
            }
            return Content("ok");
        }
        public ActionResult RemoveUserActionPass(int UserInfoId,int ActionInfoId)
        {
            var item = r_User_ActionInfoService.LoadTs(r => r.UserInfoId == UserInfoId && r.ActionInfoId == ActionInfoId).FirstOrDefault();
            if (item != null)
            {
                item.DelFlag = (short)Model.Enum.DelFlagEnum.Deleted;
                r_User_ActionInfoService.Savechanges();
            }
            return Content("ok");
        }
        #endregion
    }
}
