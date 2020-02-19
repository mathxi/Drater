using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Drater.Models;

namespace Drater.ViewModel
{
    public class ListRetardVM
    {
        private draterEntities db = new draterEntities();
        private List<Retard> retards;
        private Eleve eleve;

        public List<Retard> Retards { get => retards; set => retards = value; }
        public Eleve Eleve { get => eleve; set => eleve = value; }

        public ListRetardVM()
        {
            int id = 1;
            retards = db.Retard.Include(r => r.Eleve).ToList();
            eleve = db.Eleve.Find(id);
        }
        public ListRetardVM(string Titre)
        {
            int id = 1;
            retards = db.Retard.Include(r => r.Eleve).Where(r => r.titre.Contains(Titre)).ToList();
            eleve = db.Eleve.Find(id);
        }


    }
}