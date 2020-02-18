using Drater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drater.ViewModel
{
    public class Top100VM
    {
        private draterEntities db = new draterEntities();
        List<Vote_Eleve> VoteEleve = new List<Vote_Eleve>();
        public List<Retard> Listetop100Retard = new List<Retard>();
       
        private Eleve eleve;
        public Eleve Eleve { get => eleve; set => eleve = value; }
        // GET: Retards/Top100/id
        public Top100VM()
        {
            int id = 1;
            eleve = db.Eleve.Find(id);

            VoteEleve = db.Vote_Eleve.ToList();
            Dictionary<long, int> dicoVote = new Dictionary<long, int>();
            foreach (Vote_Eleve element in VoteEleve)
            {
                if (!dicoVote.ContainsKey(element.idRetard))
                {
                    if (element.valeur)
                    {
                        dicoVote[element.idRetard] = 1;
                    }
                    else
                    {
                        dicoVote[element.idRetard] = -1;
                    }
                }
                else
                {
                    if (element.valeur)
                    {
                        dicoVote[element.idRetard] = 1;
                    }
                    else
                    {
                        dicoVote[element.idRetard] = -1;
                    }
                }
            }
           
            if (VoteEleve.Count < 100)
            {
                for (int i = 0; i < VoteEleve.Count(); i++)
                {
                    Nullable<int> valeurMax = null;
                    Nullable<long> LidDuRetard = null;
                    if (dicoVote.Count() > 0)
                    {
                        foreach (KeyValuePair<long, int> valeur in dicoVote)
                        {
                            if (valeurMax == null)
                            {
                                valeurMax = valeur.Value;
                                LidDuRetard = valeur.Key;
                            }
                            else if (valeur.Value >= valeurMax)
                            {
                                valeurMax = valeur.Value;
                                LidDuRetard = valeur.Key;

                            }


                        }

                        Listetop100Retard.Add(db.Retard.Find(LidDuRetard));
                        if(LidDuRetard != null)
                        {
                           
                            dicoVote.Remove((long)LidDuRetard);

                        }
                    }

                }
            }
            else
            {
                for (int i = 0; i < 100; i++)
                {
                    Nullable<int> valeurMax = null;
                    Nullable<long> LidDuRetard = null;
                    if (dicoVote.Count() > 0)
                    {
                        foreach (KeyValuePair<long, int> valeur in dicoVote)
                        {
                            if (valeurMax == null)
                            {
                                valeurMax = valeur.Value;
                                LidDuRetard = valeur.Key;
                            }
                            else if (valeur.Value >= valeurMax)
                            {
                                valeurMax = valeur.Value;
                                LidDuRetard = valeur.Key;

                            }


                        }
                        Listetop100Retard.Add(db.Retard.Find(LidDuRetard));
                        if (LidDuRetard != null)
                        {

                            dicoVote.Remove((long)LidDuRetard);

                        }
                    }

                }
            }
        }
    }
}