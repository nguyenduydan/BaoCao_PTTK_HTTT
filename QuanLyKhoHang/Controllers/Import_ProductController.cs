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
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            /// Tính toán số lượng mục bắt đầu và kết thúc
            int start = (page - 1) * pageSize;
            int end = page * pageSize;

            // Truy vấn dữ liệu từ cơ sở dữ liệu
            var products = db.SANPHAM.OrderBy(p => p.MASP).Skip(start).Take(pageSize).ToList();

            // Tính toán số trang dựa trên tổng số mục và số mục trên mỗi trang
            int totalItems = db.SANPHAM.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Truyền dữ liệu phân trang và thông tin trang đến giao diện người dùng
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = totalItems;
            ViewBag.TotalPages = totalPages;


            return View(products);
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
                sanpham.STATUS = 1;
                db.SANPHAM.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.listncc = new SelectList(db.NHACUNGCAP, "MA_NCCAP", "TEN_NCCAP");
            return View(sanpham);
        }

        public ActionResult AddNCC()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNCC(NHACUNGCAP ncc)
        {
            if (ModelState.IsValid)
            {
                db.NHACUNGCAP.Add(ncc);
                db.SaveChanges();
                return RedirectToAction("Add");
            }
            return View(ncc);
        }

        //Nhà cung cấp
        public ActionResult NCC(int page = 1, int pageSize = 10)
        {
            // Tính toán số lượng mục bắt đầu và kết thúc
            int start = (page - 1) * pageSize;
            int end = page * pageSize;

            // Truy vấn dữ liệu từ cơ sở dữ liệu
            var ncc = db.NHACUNGCAP.OrderBy(p => p.MA_NCCAP).Skip(start).Take(pageSize).ToList();

            // Tính toán số trang dựa trên tổng số mục và số mục trên mỗi trang
            int totalItems = db.SANPHAM.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Truyền dữ liệu phân trang và thông tin trang đến giao diện người dùng
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = totalItems;
            ViewBag.TotalPages = totalPages;

            return View(ncc);
        }

        //bill
        public ActionResult Bill()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bill(DONTHANHTOAN bill)
        {
            
            if (ModelState.IsValid)
            {
                bill.NGAYTHANHTOAN = DateTime.Now;
                db.DONTHANHTOAN.Add(bill);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View(bill);
        }
    }
}