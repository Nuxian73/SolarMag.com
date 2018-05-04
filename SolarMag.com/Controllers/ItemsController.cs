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
    public class ItemsController : Controller
    {
        private SolarMagDBContext db = new SolarMagDBContext();

        // GET: Items
        public ActionResult Index()
        {
            string Choix = Request.Form.Get("CategorieList");

            Item.Categories? CategorieChoisie = null;

            if (!String.IsNullOrEmpty(Choix))
            {
                CategorieChoisie = (Item.Categories)int.Parse(Choix);
            }
            List<Item> abcd = db.Items.ToList();
            return View(abcd.Where(c => !CategorieChoisie.HasValue || c.Categorie == CategorieChoisie));
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.ClientList = db.Clients.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create(int? ValeurSelectionnee)
        {
            if (ValeurSelectionnee != null)
            {
                string NomControleur = "";
                switch ((Item.Categories)ValeurSelectionnee)
                {
                    case Item.Categories.Accessoire:
                        NomControleur = "Accessoires";
                        break;
                    case Item.Categories.Convertiseur:
                        NomControleur = "Convertiseurs";
                        break;
                    case Item.Categories.Kit:
                        NomControleur = "Kits";
                        break;
                    case Item.Categories.PanneauSolaire:
                        NomControleur = "PanneauSolaires";
                        break;
                    case Item.Categories.Pile:
                        NomControleur = "Piles";
                        break;
                }
                return RedirectToAction("Create", NomControleur);
            }
            return View();
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,NoReference,Fabricant,Description,Poids,Garantie,Prix")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
