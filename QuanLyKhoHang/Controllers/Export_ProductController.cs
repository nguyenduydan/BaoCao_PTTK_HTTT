using Manage;
using QuanLyKhoHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKhoHang.Controllers
{
    public class Export_ProductController : Controller
    {
        private QLKHEntities1 db = new QLKHEntities1();
        // GET: Import_Product
        //Hiển thị trang index
        public ActionResult Index(int pg = 1)
        {
            List<SANPHAM> products = db.SANPHAM.ToList();

            const int pageSize = 10;
            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = products.Count();
            var pages = new Pages(recsCount, pg, pageSize);
            int recSkip = pg - 1 * pageSize;
            var data = products.Skip(recSkip).Take(pageSize).ToList();

            this.ViewBag.pages = pages;
            return View(data);
        }

        public ActionResult Update(int pg = 1)
        {
            List<SANPHAM> products = db.SANPHAM.ToList();

            const int pageSize = 10;
            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = products.Count();
            var pages = new Pages(recsCount, pg, pageSize);
            int recSkip = pg - 1 * pageSize;
            var data = products.Skip(recSkip).Take(pageSize).ToList();

            this.ViewBag.pages = pages;
            return View(data);
        }
        [HttpPost]
        public ActionResult ExportSelectedItems(List<int> selectedIds)
        {
            if (selectedIds != null && selectedIds.Any())
            {
                foreach (var id in selectedIds)
                {
                    var idString = id.ToString();
                    var product = db.SANPHAM.Find(idString);
                    if (product != null)
                    {
                        db.SANPHAM.Remove(product);
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //test

    }
}