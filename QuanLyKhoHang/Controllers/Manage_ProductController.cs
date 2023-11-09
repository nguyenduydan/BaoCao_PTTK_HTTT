using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Manage;
using QuanLyKhoHang.Library;
using QuanLyKhoHang.Models;

namespace QuanLyKhoHang.Controllers
{
    public class Manage_ProductController : Controller
    {
        // GET: Manage_Product
        private QLKHEntities1 db = new QLKHEntities1();
        List<SANPHAM> products = new List<SANPHAM>();
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            // Tính toán số lượng mục bắt đầu và kết thúc
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
        [HttpPost]
        public ActionResult Update(string updateButton)
        {
            if (ModelState.IsValid && updateButton != null)
            {
                var products = db.SANPHAM.ToList();

                foreach (var product in products)
                {
                    if (product.NGAYHETHAN.HasValue)
                    {
                        TimeSpan remainingDays = product.NGAYHETHAN.Value - DateTime.Now;
                        int daysRemaining = (int)remainingDays.TotalDays;

                        if (daysRemaining < 10)
                        {
                            // Cập nhật trạng thái status về 2
                            product.TRANGTHAI = 2;
                        }
                        db.Entry(product).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            ViewBag.listncc = new SelectList(db.NHACUNGCAP, "MA_NCCAP", "TEN_NCCAP");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sp = db.SANPHAM.FirstOrDefault(m => m.MASP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SANPHAM sanpham)
        {
            if (ModelState.IsValid)
            {
                sanpham.NGAYCAPNHAT = DateTime.Now;
                sanpham.TENTOMTAT = Xstring.Str_Slug(sanpham.TENSP);
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.listncc = new SelectList(db.NHACUNGCAP, "MA_NCCAP", "TEN_NCCAP");
            return View(sanpham);
        }
        //
        public ActionResult Classify(int page = 1, int pageSize = 10)
        {
            // Tính toán số lượng mục bắt đầu và kết thúc
            int start = (page - 1) * pageSize;
            int end = page * pageSize;

            // Truy vấn dữ liệu từ cơ sở dữ liệu
            var products = db.SANPHAM.OrderBy(p => p.MASP).Skip(start).Take(pageSize).ToList();

            // Tính toán số trang dựa trên tổng số mục và số mục trên mỗi trang
            int totalItems = db.SANPHAM.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var uniqueTypes = db.SANPHAM.Select(p => p.NHACUNGCAP.LOAISP).Distinct().ToList();
            // Truyền dữ liệu phân trang và thông tin trang đến giao diện người dùng
            ViewBag.UniqueTypes = uniqueTypes;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = totalItems;
            ViewBag.TotalPages = totalPages;
            return View(products);
        }

        [HttpPost]
        public ActionResult Classify(string sortingOption)
        {
            var allProducts = db.SANPHAM.ToList();

            if (sortingOption != null && sortingOption != "default")
            {
                allProducts = db.SANPHAM.Where(p => p.NHACUNGCAP.LOAISP == sortingOption).ToList();
            }

            var uniqueTypes = db.SANPHAM.Select(p => p.NHACUNGCAP.LOAISP).Distinct().ToList();
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
            var searchType = Request.Form["SearchType"].ToString();
            var product = from m in db.SANPHAM
                          where m.TRANGTHAI != 0
                          select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                if (searchType == "tensp")
                {
                    product = product.Where(s => s.TENSP.Contains(searchString));
                }
                else if (searchType == "loaihang")
                {
                    product = product.Where(s => s.NHACUNGCAP.LOAISP.Contains(searchString));
                }
                else if (searchType == "tennhacc")
                {
                    product = product.Where(s => s.NHACUNGCAP.TEN_NCCAP.Contains(searchString));
                }
                else
                {
                    ViewBag.Message = "Loại tra cứu không hợp lệ";
                }
            }
            else
            {
                ViewBag.Message = "Không tìm thấy sản phẩm";
            }
            // Lưu trữ thông tin tìm kiếm trong TempData
            TempData["SearchString"] = searchString;
            TempData["SearchType"] = searchType;
            return View(product);
        }

        public ActionResult Export_Product(string ProductId)
        {
            var sanpham = db.SANPHAM.FirstOrDefault(p => p.MASP == ProductId);
            sanpham.TRANGTHAI = 0;
            db.SaveChanges();
            var product = from m in db.SANPHAM
                          where m.TRANGTHAI != 0
                          select m;
            // Lấy thông tin tìm kiếm từ TempData
            var searchString = TempData["SearchString"]?.ToString();
            var searchType = TempData["SearchType"]?.ToString();
            if (!string.IsNullOrEmpty(searchString))
            {
                if (searchType == "tensp")
                {
                    product = product.Where(s => s.TENSP.Contains(searchString));
                }
                else if (searchType == "loaihang")
                {
                    product = product.Where(s => s.NHACUNGCAP.LOAISP.Contains(searchString));
                }
                else if (searchType == "tennhacc")
                {
                    product = product.Where(s => s.NHACUNGCAP.TEN_NCCAP.Contains(searchString));
                }
                else
                {
                    ViewBag.Message = "Loại tra cứu không hợp lệ";
                }
            }
            else
            {
                ViewBag.Message = "Không tìm thấy sản phẩm";
            }
            return View("Search", product);
        }

        //Báo cáo
        public string MABC()
        {
            string baocao = $"{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}";
            return baocao;
        }

        public ActionResult Report(string a = "")
        {
            string ma = MABC();
            if (db.BANBAOCAO.Where(p => p.MA_BAOCAO == ma).ToList().Count() == 0)
            {
                //Nhập dữ liệu cho banbaocao
                BANBAOCAO bANBAOCAO = new BANBAOCAO();
                bANBAOCAO.MA_BAOCAO = ma;
                bANBAOCAO.NGAYBAOCAO = DateTime.Now;
                db.BANBAOCAO.Add(bANBAOCAO);
                db.SaveChanges();
                var list = db.SANPHAM.Where(p => p.TRANGTHAI == 2).ToList();
                for (int i = 0; i < list.Count(); i++)
                {
                    //nhập dữ liệu cho bảng thongtinbaocao
                    THONGTINBAOCAO tHONGTINBAOCAO = new THONGTINBAOCAO();
                    tHONGTINBAOCAO.MASP = list[i].MASP;
                    tHONGTINBAOCAO.SOLUONG = list[i].SOLUONG;
                    tHONGTINBAOCAO.TENSP = list[i].TENSP;
                    tHONGTINBAOCAO.MA_BAOCAO = ma;
                    db.THONGTINBAOCAO.Add(tHONGTINBAOCAO);
                    db.SaveChanges();
                }
                return View(db.THONGTINBAOCAO.Where(p => p.MA_BAOCAO == ma).ToList());

            }
            else return View(db.THONGTINBAOCAO.Where(p => p.MA_BAOCAO == ma).ToList());
        }
        public ActionResult Thongke()
        {
            string ma = MABC();
            var dataFromDatabase = db.THONGTINBAOCAO.ToList();
            var result = dataFromDatabase.Where(p => p.MA_BAOCAO == ma).Select(item => new object[] { item.TENSP, item.SOLUONG }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}


