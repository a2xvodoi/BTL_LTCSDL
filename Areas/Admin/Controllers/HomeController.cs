using layout.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace layout.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        anTuongFsDB db = new anTuongFsDB();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["maAd"] != null)
            {
                return View();
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string tenDangNhapAd, string matKhauAd)
        {
            if (ModelState.IsValid)
            {
                var user = db.TaiKhoans.Where(u => u.tenDangNhap.Equals(tenDangNhapAd) && u.MatKhau.Equals(matKhauAd)).ToList();
                
                if (user.Count() !=0)
                {
                    if (user.FirstOrDefault().MaGP == 3)
                    {
                        ViewBag.roles = "Bạn không có quyền đăng nhập vào  Admin";
                        return View();
                    }
                    Session["tendn"] = user.FirstOrDefault().tenDangNhap;
                    Session["maAd"] = user.FirstOrDefault().MatKhau;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.er = "Đăng nhập không thành công!";
                }
            }
            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }
        public ActionResult AtvLog()
        {
            return View();
        }
        public ActionResult PhanQuyen()
        {
            return View();
        }
    }
}