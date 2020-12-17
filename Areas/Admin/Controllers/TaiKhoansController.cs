using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using layout.Models;
using PagedList;

namespace layout.Areas.Admin.Controllers
{
    public class TaiKhoansController : Controller
    {
        private anTuongFsDB db = new anTuongFsDB();

        // GET: Admin/TaiKhoans
        public ActionResult Index(int? page, string order)
        {
            ViewBag.sort = order;
            var tk = db.TaiKhoans.Select(h => h).OrderBy(h => h.MaTK);
            int pageSize = 5;
            int pageNumber = page ?? 1;
            if (order == "descname")
            {
                tk = tk.OrderByDescending(h => h.tenKH);
            }
            else
            {
                tk = tk.OrderBy(h => h.tenKH);
            }
            return View(tk.ToPagedList(pageNumber, pageSize));
        }
        // GET: Admin/TaiKhoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTK,tenDangNhap,MatKhau,tenKH,SoDienThoai,Email,Tinh,Huyen,DiaChi,TrangThai")] TaiKhoan taiKhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(taiKhoan).State = EntityState.Modified;
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
                
            }
            catch (Exception ex)
            {
                ViewBag.er = "Lỗi nhập dữ liệu!" + ex.Message;
                return View(taiKhoan);
               
            }
        }
        public ActionResult Lockout(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            db.TaiKhoans.Find(id).TrangThai = "Khóa";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/TaiKhoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            try
            {
                db.TaiKhoans.Remove(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.er = "Không thể xóa tài khoản này!" + ex.Message;
                return View(taiKhoan);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
