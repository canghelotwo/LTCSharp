﻿using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDao();
                var result = user.login(login.UserName, Encryptor.EncryptorMD5(login.PassWord));
                if (result == 1)
                {
                    //ModelState.AddModelError("", "Đăng Nhập Thành Công");
                    Session.Add(Constants.USER_SESSION, login);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng Nhập Thất Bại");
                }
            }
            return View("Index");
        }
    }
}