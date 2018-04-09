using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Kit : Item
    {
        public Pile Pile { get; set; }

        public PanneauSolaire PanneauSolaire { get; set; }
        
        public Convertisseur Convertisseur { get; set; }

        public Accessoire Accessoire { get; set; }

        public Kit()
        {
            Categorie = Categories.Kit;
        }
    }
}