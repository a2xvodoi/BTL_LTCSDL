using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using layout.Models;

namespace layout.Areas.Admin.Controllers
{
    public class CTDonHangsController : Controller
    {
        private anTuongFsDB db = new anTuongFsDB();

        // GET: Admin/CTDonHangs
        public ActionResult Index()
        {
            var cTDonHangs = db.CTDonHangs.Include(c => c.DonHang).Include(c => c.Hang);
            return View(cTDonHangs.ToList());
        }

        // GET: Admin/CTDonHangs/Details/5
        public ActionResult Details(int? id, int? idc)
        {
            if (id == null || idc == null)
            {
                var ct = db.CTDonHangs.OrderBy(c => c.DonHang.NgayDatHang);
                id = ct.FirstOrDefault().Hang.MaH;
                idc = ct.FirstOrDefault().DonHang.MaDH;
                
            }
            CTDonHang cTDonHang = db.CTDonHangs.Find(id,idc);
            if (cTDonHang == null)
            {
                return HttpNotFound();
            }
            return View(cTDonHang);
        }

        // GET: Admin/CTDonHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "NguoiNhan");
            ViewBag.MaH = new SelectList(db.Hangs, "MaH", "AnhChup");
            return View();
        }

        // POST: Admin/CTDonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaH,MaDH,SoLuong")] CTDonHang cTDonHang)
        {
            if (ModelState.IsValid)
            {
                db.CTDonHangs.Add(cTDonHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "NguoiNhan", cTDonHang.MaDH);
            ViewBag.MaH = new SelectList(db.Hangs, "MaH", "AnhChup", cTDonHang.MaH);
            return View(cTDonHang);
        }

        // GET: Admin/CTDonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cTDonHang = db.CTDonHangs.SingleOrDefault(c => c.MaDH == id);
            if (cTDonHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "NguoiNhan", cTDonHang.MaDH);
            ViewBag.MaH = new SelectList(db.Hangs, "MaH", "AnhChup", cTDonHang.MaH);
            return View(cTDonHang);
        }

        // POST: Admin/CTDonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaH,MaDH,SoLuong")] CTDonHang cTDonHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTDonHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "NguoiNhan", cTDonHang.MaDH);
            ViewBag.MaH = new SelectList(db.Hangs, "MaH", "AnhChup", cTDonHang.MaH);
            return View(cTDonHang);
        }

        // GET: Admin/CTDonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDonHang cTDonHang = db.CTDonHangs.Find(id);
            if (cTDonHang == null)
            {
                return HttpNotFound();
            }
            return View(cTDonHang);
        }

        // POST: Admin/CTDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTDonHang cTDonHang = db.CTDonHangs.Find(id);
            db.CTDonHangs.Remove(cTDonHang);
            db.SaveChanges();
            return RedirectToAction("Index");
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
