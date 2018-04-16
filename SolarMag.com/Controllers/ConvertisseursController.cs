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
    public class ConvertisseursController : Controller
    {
        private SolarMagDBContext db = new SolarMagDBContext();

        // GET: Convertisseurs
        public ActionResult Index()
        {
            return View(db.Convertisseurs.ToList());
        }

        // GET: Convertisseurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convertisseur convertisseur = db.Convertisseurs.Find(id);
            if (convertisseur == null)
            {
                return HttpNotFound();
            }
            return View(convertisseur);
        }

        // GET: Convertisseurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Convertisseurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,NoReference,Fabricant,Description,Poids,Garantie,Prix,Voltage,Capacite,Dimensions")] Convertisseur convertisseur)
        {
            if (ModelState.IsValid)
            {
                db.Convertisseurs.Add(convertisseur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(convertisseur);
        }

        // GET: Convertisseurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convertisseur convertisseur = db.Convertisseurs.Find(id);
            if (convertisseur == null)
            {
                return HttpNotFound();
            }
            return View(convertisseur);
        }

        // POST: Convertisseurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,NoReference,Fabricant,Description,Poids,Garantie,Prix,Voltage,Capacite,Dimensions")] Convertisseur convertisseur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(convertisseur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(convertisseur);
        }

        // GET: Convertisseurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convertisseur convertisseur = db.Convertisseurs.Find(id);
            if (convertisseur == null)
            {
                return HttpNotFound();
            }
            return View(convertisseur);
        }

        // POST: Convertisseurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Convertisseur convertisseur = db.Convertisseurs.Find(id);
            db.Convertisseurs.Remove(convertisseur);
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
