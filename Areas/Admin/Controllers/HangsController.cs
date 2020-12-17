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
    public class HangsController : Controller
    {
        private anTuongFsDB db = new anTuongFsDB();

        // GET: Admin/Hangs
        public ActionResult Index(int? page, string order)
        {
            ViewBag.sort = order;
            var hangs = db.Hangs.Select(h => h).OrderBy(h => h.MaH);
            int pageSize = 5;
            int pageNumber = page ?? 1;
            if (order == "descname")
            {
                hangs = hangs.OrderByDescending(h => h.TenH);
            }
            else
            {
                hangs = hangs.OrderBy(h => h.TenH);
            }
            return View(hangs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Hangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // GET: Admin/Hangs/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM");
            return View();
        }

        // POST: Admin/Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaH,AnhChup,TenH,GiaBan,KichCo,MauSac,SLBan,MaDM")] Hang hang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string extName = System.IO.Path.GetExtension(f.FileName);
                        List<String> imgExtension = new List<string>
                        {
                            "jpg",
                            "png",
                            "jpeg"
                        };
                        if (imgExtension.Contains(extName))
                        {
                            string UpPath = Server.MapPath("~/wwwroot/IMAGES/" + FileName);
                            f.SaveAs(UpPath);
                            hang.AnhChup = FileName;
                        }
                    }
                    db.Hangs.Add(hang);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.er = "Lỗi nhập dữ liệu!" + ex.Message;
                ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM", hang.MaDM);
                return View(hang);
            }
        }

        // GET: Admin/Hangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM", hang.MaDM);
            return View(hang);
        }

        // POST: Admin/Hangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaH,AnhChup,TenH,GiaBan,KichCo,MauSac,SLBan,MaDM")] Hang hang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string extName = System.IO.Path.GetExtension(f.FileName);
                        List<String> imgExtension = new List<string>
                        {
                            "jpg",
                            "png",
                            "jpeg"
                        };
                        if (imgExtension.Contains(extName))
                        {
                            string UpPath = Server.MapPath("~/wwwroot/IMAGES/" + FileName);
                            f.SaveAs(UpPath);
                            hang.AnhChup = FileName;
                        }
                    }
                    db.Entry(hang).State = EntityState.Modified;
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ex = "Lỗi nhập dữ liệu!" + ex.Message;
                ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM", hang.MaDM);
                return View(hang);
            }
        }

        // GET: Admin/Hangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang hang = db.Hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // POST: Admin/Hangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hang hang = db.Hangs.Find(id);
            try
            {
                db.Hangs.Remove(hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.er = "Không thể xóa trường này!" + ex.Message;
                return View(hang);
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
