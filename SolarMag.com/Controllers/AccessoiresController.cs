﻿using System;
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
    public class AccessoiresController : Controller
    {
        private SolarMagDBContext db = new SolarMagDBContext();

        // GET: Accessoires
        public ActionResult Index()
        {
            return View(db.Accessoires.ToList());
        }

        // GET: Accessoires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessoire accessoire = db.Accessoires.Find(id);
            if (accessoire == null)
            {
                return HttpNotFound();
            }
            return View(accessoire);
        }

        // GET: Accessoires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accessoires/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,NoReference,Fabricant,Description,Poids,Garantie,Prix,Amperage,Voltage,Capacite,Dimensions")] Accessoire accessoire)
        {
            if (ModelState.IsValid)
            {
                db.Accessoires.Add(accessoire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessoire);
        }

        // GET: Accessoires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessoire accessoire = db.Accessoires.Find(id);
            if (accessoire == null)
            {
                return HttpNotFound();
            }
            return View(accessoire);
        }

        // POST: Accessoires/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,NoReference,Fabricant,Description,Poids,Garantie,Prix,Amperage,Voltage,Capacite,Dimensions")] Accessoire accessoire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessoire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessoire);
        }

        // GET: Accessoires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessoire accessoire = db.Accessoires.Find(id);
            if (accessoire == null)
            {
                return HttpNotFound();
            }
            return View(accessoire);
        }

        // POST: Accessoires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessoire accessoire = db.Accessoires.Find(id);
            db.Accessoires.Remove(accessoire);
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
