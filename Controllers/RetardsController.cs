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
    public class RetardsController : Controller
    {
        private draterEntities db = new draterEntities();
        // GET: Retards
        public ActionResult Index()
        {
            
            long idEleve = Convert.ToInt64(User.Identity.Name);
            var retard = db.Retard
                    .Where(v => v.idEleve == idEleve);
            return View(retard.ToList());
            
        }

        // GET: Retards/Details/5
        public ActionResult Details(long? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retard retard = db.Retard.Find(id);
            if (retard == null)
            {
                return HttpNotFound();
            }
            return View(retard);
            
        }

        // GET: Retards/Create
        public ActionResult Create()
        {
            
            ViewBag.idEleve = new SelectList(db.Eleve, "id", "pseudo");
            return View();
            
        }

        // POST: Retards/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Create([Bind(Include = "id,titre,description,idEleve,pj")] Retard retard)
        {
           
            if (ModelState.IsValid)
            {
                retard.idEleve = Convert.ToInt64(User.Identity.Name);
                db.Retard.Add(retard);
                db.SaveChanges();
                Response.Redirect("/Home");
            }
            else
            {

            }

            ViewBag.idEleve = new SelectList(db.Eleve, "id", "pseudo", retard.idEleve); 
        }

        // GET: Retards/Edit/5
        public ActionResult Edit(long? id)
    {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retard retard = db.Retard.Find(id);
            if (retard == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEleve = new SelectList(db.Eleve, "id", "pseudo", retard.idEleve);
            return View(retard);
        }
        

        // POST: Retards/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titre,description,idEleve,pj")] Retard retard)
    {
            if (ModelState.IsValid)
            {
                db.Entry(retard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEleve = new SelectList(db.Eleve, "id", "pseudo", retard.idEleve);
            return View(retard);
        }

        // GET: Retards/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retard retard = db.Retard.Find(id);
            if (retard == null)
            {
                return HttpNotFound();
            }
            return View(retard);
        }

        // POST: Retards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
           
            Retard retard = db.Retard.Find(id);
            db.Retard.Remove(retard);
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
