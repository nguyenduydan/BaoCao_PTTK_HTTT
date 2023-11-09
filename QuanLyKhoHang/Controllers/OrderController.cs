using QuanLyKhoHang.Library;
using QuanLyKhoHang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Activities;

namespace QuanLyKhoHang.Controllers
{
    public class OrderController : Controller
    {
        private QLKHEntities1 db = new QLKHEntities1();
        List<DONDATHANG> order = new List<DONDATHANG>();
        // GET: Oder

        public ActionResult Index()
        {
            return View(db.DONDATHANG.ToList());
        }
        public ActionResult Add()
        {
            // mã số đơn đặt hàng tự sinh ngẫu nhiên
            var dondathang = db.DONDATHANG.ToList();
            ViewBag.dathangList = dondathang;
            // Lấy danh sách sản phẩm để sử dụng trong dropdown list
            var sanphamList = db.SANPHAM.ToList();
            ViewBag.SanPhamList = new SelectList(sanphamList, "MASP", "TENSP");

            // Lấy danh sách nhà cung cấp để sử dụng trong dropdown list
            var nhacungcapList = db.NHACUNGCAP.ToList();
            ViewBag.NhaCungCapList = new SelectList(nhacungcapList, "MA_NCCAP", "TEN_NCCAP");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DONDATHANG order, string MASP, int SOLUONG)
        {
            if (ModelState.IsValid)
            {
                // Tạo mã đơn đặt hàng duy nhất
                order.MA_DATHANG = GenerateUniqueMaDatHang();

                // Kiểm tra tính duy nhất của mã đơn đặt hàng
                while (db.DONDATHANG.Any(o => o.MA_DATHANG == order.MA_DATHANG))
                {
                    order.MA_DATHANG = GenerateUniqueMaDatHang();
                }

                // Lấy mã nhà cung cấp dựa trên loại sản phẩm
                var sanpham = db.SANPHAM.Find(MASP);
                if (sanpham != null)
                {
                    order.MA_NCCAP = sanpham.MA_NCCAP;
                }

                // Gán ngày đặt hàng là ngày hiện tại
                order.NGAY_DATHANG = DateTime.Now;

                db.DONDATHANG.Add(order);
                db.SaveChanges();

                // Tạo thông tin chi tiết đơn đặt hàng
                var thongTinDDH = new THONGTINDDH
                {
                    MA_DATHANG = order.MA_DATHANG,
                    MASP = MASP,
                    SOLUONG = SOLUONG,
                };

                db.THONGTINDDH.Add(thongTinDDH);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            var dondathang = db.DONDATHANG.ToList();
            ViewBag.dathangList = dondathang;
            // Lấy danh sách sản phẩm để sử dụng trong dropdown list
            var sanphamList = db.SANPHAM.ToList();
            ViewBag.SanPhamList = new SelectList(sanphamList, "MASP", "TENSP");

            // Lấy danh sách nhà cung cấp để sử dụng trong dropdown list
            var nhacungcapList = db.NHACUNGCAP.ToList();
            ViewBag.NhaCungCapList = new SelectList(nhacungcapList, "MA_NCCAP", "TEN_NCCAP");
            return View(order);
        }



        public JsonResult GetSanPhamByNhaCungCap(string nccapId)
        {
            var sanPhamList = db.SANPHAM.Where(s => s.MA_NCCAP == nccapId).Select(s => new
            {
                Value = s.MASP,
                Text = s.TENSP
            }).ToList();

            return Json(sanPhamList, JsonRequestBehavior.AllowGet);
        }


        // Hàm tạo mã đơn đặt hàng ngẫu nhiên
        private string GenerateUniqueMaDatHang()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string randomChar = new string(Enumerable.Repeat(chars, 1).Select(s => s[random.Next(s.Length)]).ToArray());
            string randomNumber = random.Next(1, 1000).ToString();
            string uniqueMaDatHang = randomChar + randomNumber;

            // Kiểm tra xem mã đơn đặt hàng đã tồn tại chưa
            while (db.DONDATHANG.Any(o => o.MA_DATHANG == uniqueMaDatHang))
            {
                randomChar = new string(Enumerable.Repeat(chars, 1).Select(s => s[random.Next(s.Length)]).ToArray());
                randomNumber = random.Next(1, 1000).ToString();
                uniqueMaDatHang = randomChar + randomNumber;
            }

            return uniqueMaDatHang;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(DONDATHANG orders)
        {
            if (!ModelState.IsValid)
            {
                db.DONDATHANG.RemoveRange(db.DONDATHANG); // Xóa tất cả bản ghi trong bảng DONDATHANG
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orders);
        }
    }
}