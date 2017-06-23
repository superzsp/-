using KMSZ.OADemo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMSZ.OADemo.UI.Protal.Controllers
{
    public class LoginController : Controller
    {
        public IBLL.IUserInfoService UserInfoService { get; set; }
        // GET: Login
        public ActionResult CheckUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckUser(string LoginCode, string LoginPwd, string vCode)
        {
            //第一校验验证码
            string sessionCode = Session["ValidateCode"] == null ? string.Empty : Session["ValidateCode"].ToString();
            Session["ValidateCode"] =null;
            if (vCode != sessionCode)
            {
                //ViewData["error"] = "<script>alert('验证码错误！')</script>";
                //return View();
                return Content("验证码错误！");
            }
            Model.UserInfo user = UserInfoService.LoadTs(u=>u.UserName==LoginCode&&u.Pwd==LoginPwd).FirstOrDefault();
            if (user == null)
            {
                //ViewData["error"] = "<script>alert('用户名和密码错误！')</script>";
                //return View();
                return Content("用户名密码错误");
            }
            Session["LoginUser"] = user;
            return Content("ok");
            
            //return RedirectToAction("Index", "UserInfo");
        }
        public ActionResult VCode()
        {
            //应用的都是程序集，需要重新生成后才能用
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
            //Response.BinaryWrite();

        }
    }
}