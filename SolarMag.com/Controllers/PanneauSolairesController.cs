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
    public class PanneauSolairesController : Controller
    {
        private SolarMagDBContext db = new SolarMagDBContext();

        // GET: PanneauSolaires
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: PanneauSolaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PanneauSolaire panneauSolaire = db.PanneauSolaires.Find(id);
            if (panneauSolaire == null)
            {
                return HttpNotFound();
            }
            return View(panneauSolaire);
        }

        // GET: PanneauSolaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PanneauSolaires/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,NoReference,Fabricant,Description,Poids,Garantie,Prix,WattsHeureJour,AmperesHeureJour,Dimensions,Composition")] PanneauSolaire panneauSolaire)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(panneauSolaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(panneauSolaire);
        }

        // GET: PanneauSolaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PanneauSolaire panneauSolaire = db.PanneauSolaires.Find(id);
            if (panneauSolaire == null)
            {
                return HttpNotFound();
            }
            return View(panneauSolaire);
        }

        // POST: PanneauSolaires/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,NoReference,Fabricant,Description,Poids,Garantie,Prix,WattsHeureJour,AmperesHeureJour,Dimensions,Composition")] PanneauSolaire panneauSolaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(panneauSolaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(panneauSolaire);
        }

        // GET: PanneauSolaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PanneauSolaire panneauSolaire = db.PanneauSolaires.Find(id);
            if (panneauSolaire == null)
            {
                return HttpNotFound();
            }
            return View(panneauSolaire);
        }

        // POST: PanneauSolaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PanneauSolaire panneauSolaire = db.PanneauSolaires.Find(id);
            db.Items.Remove(panneauSolaire);
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
