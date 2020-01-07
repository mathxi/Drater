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
    public class Vote_EleveController : Controller
    {
        private draterEntities db = new draterEntities();

        // GET: Vote_Eleve
        public ActionResult Index()
        {
            var vote_Eleve = db.Vote_Eleve.Include(v => v.Eleve).Include(v => v.Retard);
            return View(vote_Eleve.ToList());
        }

        // GET: Vote_Eleve/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote_Eleve vote_Eleve = db.Vote_Eleve.Find(id);
            if (vote_Eleve == null)
            {
                return HttpNotFound();
            }
            return View(vote_Eleve);
        }

        // GET: Vote_Eleve/Create
        public ActionResult Create()
        {
            ViewBag.idEleve = new SelectList(db.Eleve, "id", "pseudo");
            ViewBag.idRetard = new SelectList(db.Retard, "id", "titre");
            return View();
        }

        // POST: Vote_Eleve/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idEleve,idRetard,dateVote,valeur")] Vote_Eleve vote_Eleve)
        {
            if (ModelState.IsValid)
            {
                db.Vote_Eleve.Add(vote_Eleve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEleve = new SelectList(db.Eleve, "id", "pseudo", vote_Eleve.idEleve);
            ViewBag.idRetard = new SelectList(db.Retard, "id", "titre", vote_Eleve.idRetard);
            return View(vote_Eleve);
        }

        // GET: Vote_Eleve/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote_Eleve vote_Eleve = db.Vote_Eleve.Find(id);
            if (vote_Eleve == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEleve = new SelectList(db.Eleve, "id", "pseudo", vote_Eleve.idEleve);
            ViewBag.idRetard = new SelectList(db.Retard, "id", "titre", vote_Eleve.idRetard);
            return View(vote_Eleve);
        }

        // POST: Vote_Eleve/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idEleve,idRetard,dateVote,valeur")] Vote_Eleve vote_Eleve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vote_Eleve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEleve = new SelectList(db.Eleve, "id", "pseudo", vote_Eleve.idEleve);
            ViewBag.idRetard = new SelectList(db.Retard, "id", "titre", vote_Eleve.idRetard);
            return View(vote_Eleve);
        }

        // GET: Vote_Eleve/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vote_Eleve vote_Eleve = db.Vote_Eleve.Find(id);
            if (vote_Eleve == null)
            {
                return HttpNotFound();
            }
            return View(vote_Eleve);
        }

        // POST: Vote_Eleve/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Vote_Eleve vote_Eleve = db.Vote_Eleve.Find(id);
            db.Vote_Eleve.Remove(vote_Eleve);
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
