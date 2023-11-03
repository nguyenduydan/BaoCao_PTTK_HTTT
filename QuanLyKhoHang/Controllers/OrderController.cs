using QuanLyKhoHang.Library;
using QuanLyKhoHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(THONGTINDDH order)
        {
            if (ModelState.IsValid)
            {
                db.THONGTINDDH.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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