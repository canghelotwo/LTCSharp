using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        //GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create(string user)
        {
            var dao = new UserDao();
            var result = dao.Find(user);
            if (result != null)
                return View(result);
            return View();
        }


        [HttpPost]
        public ActionResult Create(UserAccount model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var pass = Encryptor.EncryptorMD5(model.PassWord);
                model.PassWord = pass;
                string result;
                // Tìm tên đăng nhập có trùng không
                //Nếu  trùng thì trả về trang Create

                result = dao.Insert(model);

                if (!string.IsNullOrEmpty(result))
                {
                    //ModelState.AddModelError("Cập nhật người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    //SetAlert("Cập nhật người dùng không thành công", "error");
                    ModelState.AddModelError("", "Tạo người dùng không thành công");
                }
            }
            return View();
        }


        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var dao = new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}