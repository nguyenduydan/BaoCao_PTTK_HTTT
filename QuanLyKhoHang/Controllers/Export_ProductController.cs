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
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            // Tính toán số lượng mục bắt đầu và kết thúc
            int start = (page - 1) * pageSize;
            int end = page * pageSize;

            // Truy vấn dữ liệu từ cơ sở dữ liệu
            var products = db.SANPHAM.Where(p => p.TRANGTHAI == 2 || p.TRANGTHAI == 0).OrderBy(p => p.MASP).Skip(start).Take(pageSize).ToList();

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

        public ActionResult Update(int page = 1, int pageSize = 10)
        {
            // Tính toán số lượng mục bắt đầu và kết thúc
            int start = (page - 1) * pageSize;
            int end = page * pageSize;

            // Truy vấn dữ liệu từ cơ sở dữ liệu
            var products = db.SANPHAM.Where(p => p.TRANGTHAI == 0).OrderBy(p => p.MASP).Skip(start).Take(pageSize).ToList();

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
            return RedirectToAction("Update");
        }

        //test
        [HttpPost]
        public ActionResult ChangeStatus(string productId, int status)
        {
            var product = db.SANPHAM.FirstOrDefault(p => p.MASP == productId);
            if (product != null)
            {
                byte newStatus = (byte)status; // Chuyển đổi giá trị int sang byte
                product.TRANGTHAI = newStatus; // Gán giá trị đã chuyển đổi
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}