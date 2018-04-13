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
    public class CoordonneesController : Controller
    {
        private SolarMagDBContext db = new SolarMagDBContext();

        // GET: Coordonnees
        public ActionResult Index()
        {
            return View(db.Coordonnees.ToList());
        }

        // GET: Coordonnees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coordonnee coordonnee = db.Coordonnees.Find(id);
            if (coordonnee == null)
            {
                return HttpNotFound();
            }
            return View(coordonnee);
        }

        // GET: Coordonnees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coordonnees/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Adresse,Ville,Province_Etat,Pays,CodePostal_ZipCode,Telephone")] Coordonnee coordonnee)
        {
            if (ModelState.IsValid)
            {
                db.Coordonnees.Add(coordonnee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coordonnee);
        }

        // GET: Coordonnees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coordonnee coordonnee = db.Coordonnees.Find(id);
            if (coordonnee == null)
            {
                return HttpNotFound();
            }
            return View(coordonnee);
        }

        // POST: Coordonnees/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adresse,Ville,Province_Etat,Pays,CodePostal_ZipCode,Telephone")] Coordonnee coordonnee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coordonnee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coordonnee);
        }

        // GET: Coordonnees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coordonnee coordonnee = db.Coordonnees.Find(id);
            if (coordonnee == null)
            {
                return HttpNotFound();
            }
            return View(coordonnee);
        }

        // POST: Coordonnees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coordonnee coordonnee = db.Coordonnees.Find(id);
            db.Coordonnees.Remove(coordonnee);
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
