using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Convertisseur : Item
    {
        public decimal Voltage { get; set; }

        public decimal Capacite { get; set; }

        public decimal Dimensions { get; set; }

        public Convertisseur()
        {
            Categorie = Categories.Convertiseur;
        }
    }
}