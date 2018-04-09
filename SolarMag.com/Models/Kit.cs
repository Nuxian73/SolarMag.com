﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Kit : Item
    {
        public Pile Pile { get; set; }

        public virtual PanneauSolaire PanneauSolaire { get; set; }
        
        public virtual Convertisseur Convertisseur { get; set; }

        public virtual Accessoire Accessoire { get; set; }

        public Kit()
        {
            Categorie = Categories.Kit;
        }
    }
}