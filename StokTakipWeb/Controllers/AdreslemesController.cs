using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StokTakipWeb.Models;

namespace StokTakipWeb.Controllers
{
    public class AdreslemesController : Controller
    {
        private StokDBEntities1 db = new StokDBEntities1();

        // GET: Adreslemes
        public ActionResult Index()
        {
            return View(db.Adresleme.ToList());
        }

        public ActionResult AdresRaporlama()
        {
            return View(db.Adresleme.ToList());
        }
        // GET: Adreslemes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresleme adresleme = db.Adresleme.Find(id);
            if (adresleme == null)
            {
                return HttpNotFound();
            }
            return View(adresleme);
        }

        // GET: Adreslemes/Create
        public ActionResult Create()
        {
            ViewBag.StokKodu = db.StokKart.ToList();
            return View();
        }

        // POST: Adreslemes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StokKodu,BosaltmaYontemi,GeciciKabul,Hasar,MalKabul,Yerleştirme,YüklemeBosaltmaAlani")] Adresleme adresleme)
        {
            if (ModelState.IsValid)
            {
                db.Adresleme.Add(adresleme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adresleme);
        }

        // GET: Adreslemes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresleme adresleme = db.Adresleme.Find(id);
            if (adresleme == null)
            {
                return HttpNotFound();
            }
            ViewBag.StokKodu = db.StokKart.ToList();
            return View(adresleme);
        }

        // POST: Adreslemes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StokKodu,BosaltmaYontemi,GeciciKabul,Hasar,MalKabul,Yerleştirme,YüklemeBosaltmaAlani")] Adresleme adresleme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresleme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adresleme);
        }

        // GET: Adreslemes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresleme adresleme = db.Adresleme.Find(id);
            if (adresleme == null)
            {
                return HttpNotFound();
            }
            return View(adresleme);
        }

        // POST: Adreslemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adresleme adresleme = db.Adresleme.Find(id);
            db.Adresleme.Remove(adresleme);
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
