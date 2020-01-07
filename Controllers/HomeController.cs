using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Drater.Models;
using Drater.ViewModel;

namespace Drater.Controllers
{
    public class HomeController : Controller
    {
        private draterEntities db = new draterEntities();
        public ActionResult Index()
        {
            ListRetardVM lrvm = new ListRetardVM();
            return View(lrvm);
        }

        // GET: Home/updatevote/{idretard}/{isupvote}
        public ActionResult Updatevote(long id,int value)
        {
            Retard retard = db.Retard.Find(id);
            int idUserConnected = 1;

            // Query for all blogs with names starting with B

            var vote_Eleves = db.Vote_Eleve
                    .Where(v => v.idEleve == idUserConnected && v.idRetard == id)
                    .FirstOrDefault();

            if (vote_Eleves != null)
            {
                vote_Eleves.dateVote = DateTime.Now;
                if (value > 0)
                {
                    vote_Eleves.valeur = true;
                }
                else
                {
                    vote_Eleves.valeur = false;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (value > 0)  
            {
                Vote_Eleve newVote_Eleves = new Vote_Eleve()
                {
                    idEleve = idUserConnected,
                    idRetard = id,
                    dateVote = DateTime.Now,
                    valeur = true

                };
                db.Vote_Eleve.Add(newVote_Eleves);
            }
            else
            {
                Vote_Eleve newVote_Eleves = new Vote_Eleve()
                {
                    idEleve = idUserConnected,
                    idRetard = id,
                    dateVote = DateTime.Now,
                    valeur = false

                };
                db.Vote_Eleve.Add(newVote_Eleves);
            }
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}