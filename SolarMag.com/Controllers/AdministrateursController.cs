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
    public class AdministrateursController : Controller
    {
        private SolarMagDBContext db = new SolarMagDBContext();

        // GET: Administrateurs
        public ActionResult Index()
        {
            return View(db.Comptes.ToList());
        }

        // GET: Administrateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrateur administrateur = db.Administrateurs.Find(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        // GET: Administrateurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,NoEmploye,Titre,PosteTel")] Administrateur administrateur)
        {
            if (ModelState.IsValid)
            {
                db.Comptes.Add(administrateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrateur);
        }

        // GET: Administrateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrateur administrateur = db.Administrateurs.Find(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        // POST: Administrateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,NoEmploye,Titre,PosteTel")] Administrateur administrateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrateur);
        }

        // GET: Administrateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrateur administrateur = db.Administrateurs.Find(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        // POST: Administrateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrateur administrateur = db.Administrateurs.Find(id);
            db.Comptes.Remove(administrateur);
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
