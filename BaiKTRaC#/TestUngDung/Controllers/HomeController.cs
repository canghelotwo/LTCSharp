using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;
using ModelEF.DAO;
using PagedList;

namespace TestUngDung.Controllers
{
    public class HomeController : Controller
    {
        private VanDoanhContext db = new VanDoanhContext();
        // GET: Admin/Home
        public ActionResult Index(int page = 1, int pagesize = 6)
        {
            //var session = (LoginModel)Session[Constrants.USER_SESSION];
            //if (session == null)
            //    return RedirectToAction("Index", "Login");
            var sp = new ProductDao();
            var model = sp.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var sp = new ProductDao();
            var model = sp.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        public ActionResult Details(int id)
        {
            var dt = db.Products.Find(id);
            return View(dt);
        }
    }
}