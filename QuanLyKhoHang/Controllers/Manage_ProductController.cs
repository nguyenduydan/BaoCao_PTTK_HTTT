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
        //Đưa sản phẩm qua hàng tồn
        public ActionResult Del(string productId)
        {
            // Lấy thông tin sản phẩm cần xóa từ bảng "Sản phẩm"
            var sanPham = db.SANPHAM.Find(productId);

            if (sanPham != null)
            {
                // Tạo một bản ghi mới trong bảng "Hàng tồn" với thông tin từ sản phẩm cần xóa
                var hangTon = new HANGTON
                {
                    MASP = sanPham.MASP,
                    MA_HANGTON = sanPham.MASP + "_" + sanPham.TENTOMTAT,
                    NGAYHETHAN = sanPham.NGAYHETHAN,
                    SOLUONG = sanPham.SOLUONG,
                    // Copy các thuộc tính khác từ sản phẩm nếu cần thiết
                };

                // Thêm bản ghi mới vào bảng "Hàng tồn"
                db.HANGTON.Add(hangTon);
                db.SaveChanges();

                // Xóa sản phẩm từ bảng "Sản phẩm"
                db.SANPHAM.Remove(sanPham);
                db.SaveChanges();

                // Các xử lý khác sau khi xóa thành công
            }

            // Redirect hoặc trả về kết quả tương ứng
            return RedirectToAction("Search");
        }
    }
    
}


