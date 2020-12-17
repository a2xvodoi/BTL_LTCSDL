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
    public class DonHangsController : Controller
    {
        private anTuongFsDB db = new anTuongFsDB();

        // GET: Admin/DonHangs
        public ActionResult Index(int? page, string order)
        {
            ViewBag.sort = order;
            var dh = db.DonHangs.Select(h => h).OrderBy(h => h.MaDH);
            int pageSize = 5;
            int pageNumber = page ?? 1;
            if (order == "descname")
            {
                dh = dh.OrderByDescending(h => h.NgayDatHang);
            }
            else
            {
                dh = dh.OrderBy(h => h.NgayDatHang);
            }
            return View(dh.ToPagedList(pageNumber, pageSize));

        }
        public PartialViewResult _CTDHDetails(int id)
        {
            if (id == null)
            {
                var ct = db.CTDonHangs.OrderBy(c => c.DonHang.NgayDatHang);
                id = ct.FirstOrDefault().DonHang.MaDH;
            }
            List<CTDonHang> cTDonHang = (List<CTDonHang>)db.CTDonHangs.Where(c => c.MaDH.Equals(id)).Select(c => c);
            if (cTDonHang == null)
            {
                return HttpNotFoundResult();
            }
            return PartialView(cTDonHang);
        }

        private PartialViewResult HttpNotFoundResult()
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: Admin/DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,NgayDatHang,NguoiNhan,DiaChiNhan")] DonHang donHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(donHang).State = EntityState.Modified;
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
                
            }
            catch (Exception ex)
            {
                ViewBag.er = "Lỗi nhập dữ liệu!" + ex.Message;
                return View(donHang);
                
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
