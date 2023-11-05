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
                sanpham.TRANGTHAI = 1;
                NHACUNGCAP ncc = db.NHACUNGCAP.Where(x => x.MA_NCCAP == sanpham.MA_NCCAP).FirstOrDefault();
                KEHANG kehang = db.KEHANG.FirstOrDefault(x => x.LOAISP == sanpham.LOAISP);
                if (ncc != null)
                {
                    sanpham.LOAISP = ncc.LOAISP;
                }
                if (kehang != null)
                {
                    sanpham.MA_KEHANG = kehang.MA_KEHANG;
                }    
                db.SANPHAM.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Add");
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
                ncc.NGAYTAO = DateTime.Now;
                ncc.NGAYCAPNHAT = DateTime.Now;
                db.NHACUNGCAP.Add(ncc);
                db.SaveChanges();
                return RedirectToAction("Add");
            }
            return View(ncc);
        }

        // Kệ hàng
        public ActionResult Kehang()
        {
            var keHangList = db.KEHANG.ToList();            // Lấy danh sách kệ hàng từ cơ sở dữ liệu
            ViewBag.KeHangList = keHangList;                // Đưa danh sách vào ViewBag để truyền sang View
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kehang(KEHANG kh)
        {
            if (ModelState.IsValid)
            {
                db.KEHANG.Add(kh);
                db.SaveChanges();

                var keHangList = db.KEHANG.ToList();        // Lấy lại danh sách kệ hàng từ cơ sở dữ liệu sau khi thêm mới
                ViewBag.KeHangList = keHangList;            // Đưa danh sách vào ViewBag để truyền sang View
                return RedirectToAction("Kehang");
            }
            return View(kh);
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