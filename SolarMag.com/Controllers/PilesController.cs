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
    public class PilesController : Controller
    {
        private SolarMagDBContext db = new SolarMagDBContext();

        // GET: Piles
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: Piles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pile pile = db.Items.Find(id);
            if (pile == null)
            {
                return HttpNotFound();
            }
            return View(pile);
        }

        // GET: Piles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Piles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,NoReference,Fabricant,Description,Poids,Garantie,Prix,Amperage,Voltage,Capacite,Dimensions")] Pile pile)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(pile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pile);
        }

        // GET: Piles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pile pile = db.Items.Find(id);
            if (pile == null)
            {
                return HttpNotFound();
            }
            return View(pile);
        }

        // POST: Piles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,NoReference,Fabricant,Description,Poids,Garantie,Prix,Amperage,Voltage,Capacite,Dimensions")] Pile pile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pile);
        }

        // GET: Piles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pile pile = db.Items.Find(id);
            if (pile == null)
            {
                return HttpNotFound();
            }
            return View(pile);
        }

        // POST: Piles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pile pile = db.Items.Find(id);
            db.Items.Remove(pile);
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
