using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manage;
using QuanLyKhoHang.Views.Import_Product;
using QuanLyKhoHang.Models;
using QuanLyKhoHang.Library;

namespace QuanLyKhoHang.Controllers
{
    public class Import_ProductController : Controller
    {
        private QLKHEntities1 db = new QLKHEntities1();
        // GET: Import_Product
        //Hiển thị trang index
        public ActionResult Index(int pg = 1)
        {

            List<SANPHAM> products = db.SANPHAM.ToList();
            
            const int pageSize = 14;
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

        public ActionResult Add()
        {
            ViewBag.listncc = new SelectList(db.NHACUNGCAP, "MA_NCCAP", "TEN_NCCAP");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SANPHAM sanpham)
        {
            if (ModelState.IsValid)
            {
                //thời gian tạo
                sanpham.NGAYTAO = DateTime.Now;
                //thời gian cập nhật
                sanpham.NGAYCAPNHAT = DateTime.Now;
                sanpham.TENTOMTAT = Xstring.Str_Slug(sanpham.TENSP);
                //thêm loại sp của nhà cung cấp vào trong sản phẩm
                NHACUNGCAP nhacungcap = db.NHACUNGCAP.FirstOrDefault(x => x.MA_NCCAP == sanpham.MA_NCCAP);
                if (nhacungcap != null)
                {
                    sanpham.LOAISP = nhacungcap.LOAISP;
                }
                db.SANPHAM.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.listncc = new SelectList(db.NHACUNGCAP, "MA_NCCAP", "TEN_NCCAP");
            return View(sanpham);
        }
        public ActionResult Update() 
        {
            return View();
        }
    }
}