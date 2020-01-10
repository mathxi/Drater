using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Drater.Models;

namespace Drater.Controllers
{
    [Authorize]
    public class ElevesController : Controller
    {
        private draterEntities db = new draterEntities();

        // GET: Eleves
        public ActionResult Index()
        {
            var eleve = db.Eleve.Include(e => e.Classe);
            return View(eleve.ToList());
        }

        // GET: Eleves/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleve.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // GET: Eleves/Create
        public ActionResult Create()
        {
            ViewBag.idClasse = new SelectList(db.Classe, "id", "libelle");
            return View();
        }

        // POST: Eleves/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pseudo,mail,mdp,idClasse")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Eleve.Add(eleve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idClasse = new SelectList(db.Classe, "id", "libelle", eleve.idClasse);
            return View(eleve);
        }

        // GET: Eleves/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleve.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClasse = new SelectList(db.Classe, "id", "libelle", eleve.idClasse);
            return View(eleve);
        }

        // POST: Eleves/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pseudo,mail,mdp,idClasse")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eleve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClasse = new SelectList(db.Classe, "id", "libelle", eleve.idClasse);
            return View(eleve);
        }

        // GET: Eleves/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleve.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // POST: Eleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Eleve eleve = db.Eleve.Find(id);
            db.Eleve.Remove(eleve);
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
