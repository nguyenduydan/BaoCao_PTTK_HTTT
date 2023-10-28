using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manage;
using QuanLyKhoHang.Views.Import_Product;
using QuanLyKhoHang.Models;


namespace QuanLyKhoHang.Controllers
{

    
    public class Import_ProductController : Controller
    {
        private QLKHEntities1 db = new QLKHEntities1();
        // GET: Import_Product
        public ActionResult Index(int pg = 1)
        {
            List<SANPHAM> products = db.SANPHAM.ToList();

            const int pageSize = 10;
            if(pg < 1)
            {
                pg = 1;
            }

            int recsCount = products.Count();
            var pages = new Pages (recsCount,pg,pageSize);
            int recSkip = pg - 1 * pageSize;
            var data = products.Skip(recSkip).Take(pageSize).ToList();

            this.ViewBag.pages = pages;
            return View(data);
        }
        
        public ActionResult Add() { 
            return View();
        }

        public ActionResult Update() {
            return View();
        }
    }
}