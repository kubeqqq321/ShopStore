using Newtonsoft.Json;
using ShopStore.DATABASE;
using ShopStore.EntityDB;
using ShopStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopStore.Controllers
{
    public class AdminController : Controller
    {
        public DatabaseUnitOfWork _unitOfWork = new DatabaseUnitOfWork();



        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }

        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var catergory = _unitOfWork.GetDatabaseInstance<Tbl_Category>().GetAllRecords();
            foreach (var item in catergory)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return list;
        }

        //Connection for category table
        public  ActionResult Categories()
        {                                
            List<Tbl_Category> allCategories = _unitOfWork.GetDatabaseInstance<Tbl_Category>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
            return View(allCategories);
        }

        public ActionResult Category()
        {
            return View(_unitOfWork.GetDatabaseInstance<Tbl_Category>().GetCategory());
        }


        public ActionResult CategoryAdd()
        {
            //ViewBag.CategoryList = GetCategory();
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Tbl_Category tbl_cat)
        {
            _unitOfWork.GetDatabaseInstance<Tbl_Category>().Add(tbl_cat);
            return RedirectToAction("Categories");
        }

        public ActionResult CategoryEdit(int categoryId)
        {
            return View(_unitOfWork.GetDatabaseInstance<Tbl_Category>().GetFirstorDefault(categoryId));
        }
        [HttpPost]
        public ActionResult CategoryEdit(Tbl_Category tbl_cat)
        {
            _unitOfWork.GetDatabaseInstance<Tbl_Category>().Update(tbl_cat);
            return RedirectToAction("Categories");   // odpowłanie do Categories wyżej
        }


        //Dodawanie Produktów edycja usuwanie---------------------------------------------------- 

        public ActionResult Product()
        {
            return View(_unitOfWork.GetDatabaseInstance<Tbl_Product>().GetProduct());
        }


        public ActionResult ProductEdit(int productId)
        {
            ViewBag.CategoryList = GetCategory();
            return View(_unitOfWork.GetDatabaseInstance<Tbl_Product>().GetFirstorDefault(productId));
        }

        [HttpPost]
        public ActionResult ProductEdit(Tbl_Product tbl_prd , HttpPostedFileBase file)
        {
            string picture = null;
            if (file != null)
            {
                picture = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/DatabaseProductImage/"), picture);

                //file is upladed
                file.SaveAs(path);
            }

            tbl_prd.ProductImage = picture != null ? picture : tbl_prd.ProductImage;
            tbl_prd.ModifiedDate = DateTime.Now;
            _unitOfWork.GetDatabaseInstance<Tbl_Product>().Update(tbl_prd);
            return RedirectToAction("Product");   // odpowłanie do product wyżej
        }



        public ActionResult ProductAdd()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Tbl_Product tbl_prd, HttpPostedFileBase file)
        {
            string picture = null;
            if (file != null)
            {
                picture = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/DatabaseProductImage/"), picture);

                //file is upladed
                file.SaveAs(path);
            }

            tbl_prd.ProductImage = picture;
            tbl_prd.CreatedDate = DateTime.Now;
            _unitOfWork.GetDatabaseInstance<Tbl_Product>().Add(tbl_prd);
            return RedirectToAction("Product");   // odpowłanie do product wyżej
        }

        public ActionResult WillBeInFuture()
        {
            return View();
        }

    }
}