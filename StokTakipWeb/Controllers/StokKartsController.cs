using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StokTakipWeb.Models;

namespace StokTakipWeb.Controllers
{
    public class StokKartsController : Controller
    {
        private StokDBEntities1 db = new StokDBEntities1();

        // GET: StokKarts
        public ActionResult Index()
        {
            return View(db.StokKart.Where(x=>x.Durum == true).ToList());
        }
        public ActionResult Raporlama()
        {
            return View(db.StokKart.ToList());
        }

        // GET: StokKarts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StokKart stokKart = db.StokKart.Find(id);
            if (stokKart == null)
            {
                return HttpNotFound();
            }
            return View(stokKart);
        }

        // GET: StokKarts/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: StokKarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StokKodu,OzelKod,Ad,GenelAd,StokTipi,AlışFiyat,SatışFiyat,Kdv,Adet,Barkod,Durum")] StokKart stokKart)
        {
            if (ModelState.IsValid)
            {
                db.StokKart.Add(stokKart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stokKart);
        }

        // GET: StokKarts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StokKart stokKart = db.StokKart.Find(id);
            if (stokKart == null)
            {
                return HttpNotFound();
            }
            return View(stokKart);
        }

        // POST: StokKarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StokKodu,OzelKod,Ad,GenelAd,StokTipi,AlışFiyat,SatışFiyat,Kdv,Adet,Barkod,Durum")] StokKart stokKart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stokKart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stokKart);
        }

        // GET: StokKarts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StokKart stokKart = db.StokKart.Find(id);
            if (stokKart == null)
            {
                return HttpNotFound();
            }
            return View(stokKart);
        }

        // POST: StokKarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StokKart stokKart = db.StokKart.Find(id);
            stokKart.Durum = false;
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
