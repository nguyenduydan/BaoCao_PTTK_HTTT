using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoHang.Models;

namespace QuanLyKhoHang.Controllers
{
    public class Manage_ProductController : Controller
    {
        // GET: Manage_Product
        private QLKHEntities1 db = new QLKHEntities1();
        List<SANPHAM> products = new List<SANPHAM>();
        public ActionResult Index()
        {
            return View(products);
        }

        public ActionResult Classify()
        {
            return View();
        }

        public ActionResult Search() {
            return View();
        
        }
    }
}