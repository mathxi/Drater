﻿using System;
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
    [Authorize]
    public class HomeController : Controller
    {
        private draterEntities db = new draterEntities();
        public ActionResult Index()
        {
            ListRetardVM lrvm = new ListRetardVM();
            return View(lrvm);
            
        }



        // GET: Home/updatevote/{idretard}/{isupvote}
        public ActionResult Updatevote(long id, int value)
        {
                Retard retard = db.Retard.Find(id);
                long idUserConnected = Int64.Parse(User.Identity.Name);

                // Query for all blogs with names starting with B

                var vote_Eleves = db.Vote_Eleve
                        .Where(v => v.idEleve == idUserConnected && v.idRetard == id)
                        .FirstOrDefault();
                string messageRetour = "";
                if (vote_Eleves != null)
                {
                    vote_Eleves.dateVote = DateTime.Now;
                    if (value > 0)
                    {
                        if (vote_Eleves.valeur == true)
                        {
                            db.Vote_Eleve.Remove(vote_Eleves);
                            messageRetour = "Vote supprimé";
                        }
                        else
                        {
                            vote_Eleves.valeur = true;
                            messageRetour = "Vote modifié";

                        }
                    }
                    else
                    {
                        if (vote_Eleves.valeur == false)
                        {
                            db.Vote_Eleve.Remove(vote_Eleves);
                            messageRetour = "Vote supprimé";
                        }
                        else
                        {
                            vote_Eleves.valeur = false;
                            messageRetour = "Vote modifié";
                        }
                    }
                    db.SaveChanges();
                    return Json(new
                    {
                        success = true,
                        message = messageRetour,
                        nbNewVotes = retard.getNbVotes()

                    },
                        JsonRequestBehavior.AllowGet);
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
                    messageRetour = "Up vote";
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
                    messageRetour = "Down vote";
                }

                db.SaveChanges();
                return Json(new
                {
                    success = true,
                    message = messageRetour,
                    nbNewVotes = retard.getNbVotes()

                },
        JsonRequestBehavior.AllowGet);
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