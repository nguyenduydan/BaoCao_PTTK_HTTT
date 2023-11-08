using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manage;
using QuanLyKhoHang.Views.Import_Product;
using QuanLyKhoHang.Models;
using QuanLyKhoHang.Library;
using System.Data.Entity;

namespace QuanLyKhoHang.Controllers
{
    public class Import_ProductController : Controller
    {
        List<SANPHAM> sanPhamList = new List<SANPHAM>();
        private QLKHEntities1 db = new QLKHEntities1();

        // GET: Import_Product
        public ActionResult Add()
        {
            ViewBag.listncc = new SelectList(db.NHACUNGCAP, "MA_NCCAP", "TEN_NCCAP");

            // Lấy danh sách sản phẩm từ TempData (nếu đã có)
            List<SANPHAM> sanPhamList = TempData["SanPhamList"] as List<SANPHAM>;
            if (sanPhamList == null)
            {
                sanPhamList = new List<SANPHAM>();
                TempData["SanPhamList"] = sanPhamList;
            }

            ViewBag.sanPhamList = sanPhamList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SANPHAM sanpham)
        {
            if (ModelState.IsValid)
            {
                // Thời gian tạo
                sanpham.NGAYTAO = DateTime.Now;
                // Thời gian cập nhật
                sanpham.NGAYCAPNHAT = DateTime.Now;
                sanpham.TENTOMTAT = Xstring.Str_Slug(sanpham.TENSP);
                sanpham.TRANGTHAI = 1;

                NHACUNGCAP ncc = db.NHACUNGCAP.Where(x => x.MA_NCCAP == sanpham.MA_NCCAP).FirstOrDefault();
                if (ncc != null)
                {
                    sanpham.LOAISP = ncc.LOAISP; // Đảm bảo LOAISP của sản phẩm là LOAISP của nhà cung cấp
                    KEHANG kehang = db.KEHANG.FirstOrDefault(x => x.LOAISP == ncc.LOAISP);
                    if (kehang != null)
                    {
                        sanpham.MA_KEHANG = kehang.MA_KEHANG; // Đặt MA_KEHANG của sản phẩm bằng MA_KEHANG của kệ hàng có cùng LOAISP
                    }
                }

                // Lấy danh sách sản phẩm từ TempData
                List<SANPHAM> sanPhamList = TempData["SanPhamList"] as List<SANPHAM>;
                if (sanPhamList == null)
                {
                    sanPhamList = new List<SANPHAM>();
                }
                // Kiểm tra trùng mã sản phẩm
                if (sanPhamList.Any(sp => sp.MASP == sanpham.MASP) || db.SANPHAM.Any(sp => sp.MASP == sanpham.MASP))
                {
                    ModelState.AddModelError("MASP", "Mã sản phẩm đã có.");
                    ViewBag.listncc = new SelectList(db.NHACUNGCAP, "MA_NCCAP", "TEN_NCCAP");
                    ViewBag.sanPhamList = sanPhamList;
                    return View(sanpham);
                }
                sanPhamList.Add(sanpham); // Thêm sản phẩm mới vào danh sách
                TempData["SanPhamList"] = sanPhamList; // Cập nhật danh sách sản phẩm trong TempData

                ViewBag.listncc = new SelectList(db.NHACUNGCAP, "MA_NCCAP", "TEN_NCCAP");
                ViewBag.sanPhamList = sanPhamList;
            }
            else
            {
                TempData["ErrorMessage"] = "Quên nhập dữ liệu rồi kìa!!";
                return View(sanpham);
            }
            db.SANPHAM.Add(sanpham);
            db.SaveChanges();
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
            }
            else
            {
                TempData["ErrorMessage"] = "Quên nhập dữ liệu rồi kìa!!";
                return View(ncc);
            }
            db.NHACUNGCAP.Add(ncc);
            db.SaveChanges();
            return View(ncc);
        }

        public ActionResult EditNCC(string id)
        {
            // Tìm nhà cung cấp dựa trên ID trong cơ sở dữ liệu
            var ncc = db.NHACUNGCAP.Find(id);

            if (ncc == null)
            {
                return HttpNotFound(); // Hoặc thực hiện xử lý khi không tìm thấy nhà cung cấp
            }

            return View(ncc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNCC(NHACUNGCAP ncc)
        {
            if (ModelState.IsValid)
            {
                // Cập nhật thông tin nhà cung cấp trong cơ sở dữ liệu
                db.Entry(ncc).State = EntityState.Modified;
                ncc.NGAYCAPNHAT = DateTime.Now; // Cập nhật ngày cập nhật

                db.SaveChanges();
                return RedirectToAction("NCC");
            }

            return View(ncc);
        }

        //Xóa nhà cung cấp
        public ActionResult DeleteNCC(string id)
        {
            var ncc = db.NHACUNGCAP.Find(id);

            if (ncc == null)
            {
                return HttpNotFound();
            }
            bool hasAssociatedProducts = db.SANPHAM.Any(sp => sp.MA_NCCAP == id);

            if (hasAssociatedProducts)
            {
                ModelState.AddModelError("", "Không thể xóa nhà cung cấp vì nhà cung cấp đang liên kết với bảng sản phẩm.");
                return RedirectToAction("NCC");
            }
            db.NHACUNGCAP.Remove(ncc);
            db.SaveChanges();

            return RedirectToAction("NCC");
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

    }
}