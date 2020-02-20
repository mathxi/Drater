using Drater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drater.ViewModel
{
    public class CreateRetardVM
    {
        private draterEntities db = new draterEntities();

        private Tags tags;
        private Retard retard;

        public Tags Tags { get => tags; set => tags = value; }
        public Retard Retard { get => retard; set => retard = value; }

        public CreateRetardVM()
        {
        }




    }
}