using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SolarMag.com.DAL;
using SolarMag.com.Models;

namespace SolarMag.com.Controllers
{
    public class KitsController : Controller
    {
        private SolarMagDBContext db = new SolarMagDBContext();

        // GET: Kits
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: Kits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kit kit = db.Items.Find(id);
            if (kit == null)
            {
                return HttpNotFound();
            }
            return View(kit);
        }

        // GET: Kits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kits/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,NoReference,Fabricant,Description,Poids,Garantie,Prix")] Kit kit)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(kit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kit);
        }

        // GET: Kits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kit kit = db.Items.Find(id);
            if (kit == null)
            {
                return HttpNotFound();
            }
            return View(kit);
        }

        // POST: Kits/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,NoReference,Fabricant,Description,Poids,Garantie,Prix")] Kit kit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kit);
        }

        // GET: Kits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kit kit = db.Items.Find(id);
            if (kit == null)
            {
                return HttpNotFound();
            }
            return View(kit);
        }

        // POST: Kits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kit kit = db.Items.Find(id);
            db.Items.Remove(kit);
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
