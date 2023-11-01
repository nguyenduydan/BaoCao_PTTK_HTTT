using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

            const int pageSize = 14;
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
        //update
        public ActionResult Update()
        {
            return View();
        }

        //
        public ActionResult Classify()
        {
            var uniqueTypes = db.SANPHAM.Select(p => p.LOAISP).Distinct().ToList();

            ViewBag.UniqueTypes = uniqueTypes;
            return View(db.SANPHAM.ToList());
        }

        [HttpPost]
        public ActionResult Classify(string sortingOption)
        {
            var allProducts = db.SANPHAM.ToList();

            if (sortingOption != null && sortingOption != "default")
            {
                allProducts = db.SANPHAM.Where(p => p.LOAISP == sortingOption).ToList();
            }

            var uniqueTypes = db.SANPHAM.Select(p => p.LOAISP).Distinct().ToList();
            ViewBag.UniqueTypes = uniqueTypes;

            return View(allProducts);
        }
        // Search
        public ActionResult Search()
        {
            List<SANPHAM> products = db.SANPHAM.ToList();
            return View(products);
        }
        [HttpPost]
        public ActionResult Search(string searchString)
        {
            var product = from m in db.SANPHAM
                          select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.TENSP.Contains(searchString));
            }
            else
            {
                ViewBag.Message = "Không tìm thấy sản phẩm";
                return View(products);
            }
            return View(product);
        }
        [HttpPost]
        // Đưa sản phẩm qua hàng tồn
        public ActionResult Del(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Search");
            }

            var product = db.SANPHAM.FirstOrDefault(p => p.MASP == id);

            if (product != null)
            {
                var hangton = new HANGTON
                {
                    MASP = product.MASP,
                    MA_HANGTON = product.MASP + "_" + product.TENTOMTAT,
                    SOLUONG = product.SOLUONG,
                    NGAYHETHAN = product.NGAYHETHAN
                    // Sao chép các trường thông tin khác của sản phẩm
                };
                db.HANGTON.Add(hangton);
                db.SaveChanges();
            }

            return RedirectToAction("Search");
        }


        //Hàng tồn
        public ActionResult CheckProduct(int pg = 1)
        {
            List<HANGTON> products = db.HANGTON.ToList();

            const int pageSize = 14;
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

        //Báo cáo
        public ActionResult Report()
        {
            List<HANGTON> products = db.HANGTON.ToList();

            return View(products);
        }
    }
    
}


