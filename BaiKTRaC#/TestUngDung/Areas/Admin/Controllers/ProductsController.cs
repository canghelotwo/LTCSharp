using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        private VanDoanhContext db = new VanDoanhContext();
        // GET: Admin/Products
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var sp = new ProductDao();
            var model = sp.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }



        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var sp = new ProductDao();
            var model = sp.ListWhereAll(searchString, page, pagesize);
            
            @ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        public void SetViewBag(string user)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "CategoryID", "Name", user);
        }


        [HttpGet]
        public ActionResult Create(string user)
        {
            var dao = new ProductDao();
            SetViewBag(user);
            var result = dao.Find(user);
            if (result != null)
                return View(result);
            return View();
        }
        //[HttpGet]
        //public ActionResult Detail(string sp)
        //{
        //    var dao = new ProductDao();
        //    var result = dao.Find(sp);
        //    if (result != null)
        //        return View(result);
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product model, HttpPostedFileBase image)
        {
            try
            {
                var dao = new ProductDao();
                string result;
                image = Request.Files["ImageData"];
                if (image != null && image.ContentLength > 0)
                {
                    model.Image = new byte[image.ContentLength]; // image stored-in binary formate
                    image.InputStream.Read(model.Image, 0, image.ContentLength);
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    string urlImage = Server.MapPath("~/Assets/Image/" + fileName);
                    image.SaveAs(urlImage);
                }
                result = dao.Insert(model);

                if (result != null)
                {
                    SetAlert("Thêm sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    SetAlert("Thêm sản phẩm không thành công", "error");
                }
                SetViewBag(model.CategoryID);
                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

            }
            return View(model);
        }


        [HttpDelete]
        public ActionResult Delete(string productid)
        {
            var dao = new ProductDao().Delete(productid);
            return RedirectToAction("Index");
        }
    }
}