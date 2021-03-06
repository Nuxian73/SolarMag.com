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
    public class PaniersController : Controller
    {
        private SolarMagDBContext db = new SolarMagDBContext();

        // GET: Paniers
        public ActionResult Index()
        {
            return View(db.Paniers.ToList());
        }

        // GET: Paniers/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Panier panier = db.Paniers.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            Client c = db.Clients.Where(ClientDb => ClientDb.Panier.Id == id).FirstOrDefault();
            ViewBag.ClientChoisi = c;
            return View(panier);
        }

        // GET: Paniers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paniers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Panier panier)
        {
            if (ModelState.IsValid)
            {
                db.Paniers.Add(panier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(panier);
        }

        // GET: Paniers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Panier panier = db.Paniers.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            return View(panier);
        }

        // POST: Paniers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Panier panier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(panier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(panier);
        }

        // GET: Paniers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Panier panier = db.Paniers.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            return View(panier);
        }

        // POST: Paniers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Panier panier = db.Paniers.Find(id);
            db.Paniers.Remove(panier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Ajouter(int ItemId)
        {

           Item ItemChoisi=db.Items.Find(ItemId);



            string Choix = Request.Form.Get("ClientSelectList");

            Client ClientChoisi = null;

           if (!String.IsNullOrEmpty(Choix))
            {
                ClientChoisi = db.Clients.Find(int.Parse(Choix));
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int quantite = 1;

            Panier PanierClient = db.Paniers.Find(ClientChoisi.Panier.Id);

            PanierItem i = PanierClient.PanierItems.Find(PanierItem => PanierItem.Item.Id == ItemId);

            if (i == null)
            {

                PanierItem panierItem = new PanierItem(ItemChoisi, 1);
                PanierClient.PanierItems.Add(panierItem);
                //db.Paniers.Add(PanierClient);

            }
            else
                i.Quantite = (i.Quantite + 1);

           // TryUpdateModel(PanierClient);
            db.Entry(PanierClient).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Details",new {id=ClientChoisi.Panier.Id });
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
