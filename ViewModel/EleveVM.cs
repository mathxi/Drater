using Drater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drater.ViewModel
{
    public class EleveVM
    {
        private draterEntities db = new draterEntities();
        private List<Classe> listeClasse;
        private Eleve eleve;

        public List<Classe> Classes { get => listeClasse; set => listeClasse = value; }
        public Eleve unEleve { get => eleve; set => eleve = value; }
    }
}