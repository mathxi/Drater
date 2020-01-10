using Drater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Drater.Controllers
{
    public class ConnexionController : Controller
    {
        private draterEntities db = new draterEntities();
        [System.ComponentModel.Browsable(false)]
        public bool IsPostBack { get; }
        // GET: Connexion
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }


        }

        [HttpPost]
        public ActionResult Index(string Pseudo, string MDP)
        {
            Models.Eleve eleve = null;
            if (Pseudo != null && MDP != null)
            {
                eleve = db.Eleve.Where(p => p.pseudo == Pseudo && p.mdp == MDP).FirstOrDefault();  
            }

           
            if (eleve != null)
            {
                FormsAuthentication.SetAuthCookie(Convert.ToString(eleve.id), true);

                return RedirectToAction("Index","Home");
            }
            
                ViewBag.ConnexionErreur = "Connexion echouée !";
                
            
                return View();



        }

        public ActionResult Disconect()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Connexion");
        }
    }

        
}
