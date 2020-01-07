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
    public class ClassesController : Controller
    {
        private draterEntities db = new draterEntities();

        // GET: Classes
        public ActionResult Index()
        {
            return View(db.Classe.ToList());
        }

        // GET: Classes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db.Classe.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,libelle,promo")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                db.Classe.Add(classe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classe);
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db.Classe.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // POST: Classes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,libelle,promo")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classe);
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classe classe = db.Classe.Find(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            return View(classe);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Classe classe = db.Classe.Find(id);
            db.Classe.Remove(classe);
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
