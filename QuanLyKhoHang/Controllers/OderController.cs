using QuanLyKhoHang.Library;
using QuanLyKhoHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKhoHang.Controllers
{
    public class OderController : Controller
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
            ViewBag.listsp = new SelectList(db.SANPHAM, "MASP", "TENSP");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DONDATHANG order)
        {
            if (ModelState.IsValid)
            {
                // Lấy thông tin sản phẩm từ bảng SANPHAM
                SANPHAM sp = db.SANPHAM.FirstOrDefault(x => x.MASP == order.MASP);
                DONDATHANG od = db.DONDATHANG.FirstOrDefault(x => x.MA_DATHANG == order.MA_DATHANG);
                if (sp != null)
                {
                    if (od != null)
                    {
                        order.MA_DATHANG = order.MA_DATHANG + 1;
                    }
                    else
                    {
                        order.MA_DATHANG = "1";
                    }
                    // Sản phẩm tồn tại
                    order.NGAY_DATHANG = DateTime.Now;
                    order.MA_NCCAP = sp.MA_NCCAP;
                    order.TEN_SP = sp.TENSP;
                    db.DONDATHANG.Add(order);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    // Sản phẩm không tồn tại
                    ModelState.AddModelError("","Sản phẩm không hợp lệ");
                }
            }

            ViewBag.listsp = new SelectList(db.SANPHAM, "MASP", "TENSP");
            return View(order);
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