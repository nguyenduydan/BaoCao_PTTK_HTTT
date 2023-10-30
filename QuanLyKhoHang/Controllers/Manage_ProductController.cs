using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manage;
using QuanLyKhoHang.Models;

namespace QuanLyKhoHang.Controllers
{
    public class Manage_ProductController : Controller
    {
        // GET: Manage_Product
        private QLKHEntities1 db = new QLKHEntities1();
        List<SANPHAM> products = new List<SANPHAM>();
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

        // PHÂN LOẠI HÀNG HÓA
        public ActionResult Classify()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Classify(string sortingOption)
        {
            if (sortingOption == "name")
            {
                List<SANPHAM> sortedProducts = GetProductsSortedByName();
                return View("Classify", sortedProducts);
            }
            else
            {
                ViewBag.Products = null;
            }

            return View("Classify");
        }
        public List<SANPHAM> GetProductsSortedByName()
        {
            using (var dbContext = new QLKHEntities1()) 
            {
                // Thực hiện truy vấn để lấy danh sách sản phẩm theo tên
                var products = dbContext.SANPHAM.OrderBy(p => p.TENSP).ToList();
                return products;
            }
        }

        public ActionResult Search() {
            return View();
        
        }
    }
}