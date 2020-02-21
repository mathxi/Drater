
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Drater.Models;
using System.Data.Entity;

namespace Drater.Controllers
{
    public class ApiController : Controller
    {
        private draterEntities db = new draterEntities();
        private List<Retard> retards;
        // GET: Api
        public ActionResult Index(string Titre)
        {
            retards = db.Retard.Include(o => o.Eleve).Where(r => r.titre.Contains(Titre)).ToList();
            foreach (var retard in retards)
            {
                retard.nbVotes = retard.getNbVotes();
            }
            return Json(retards, JsonRequestBehavior.AllowGet);
        }
    }
}
