using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Accessoire : Item
    {
        public decimal Amperage { get; set; }

        public decimal Voltage { get; set; }

        public decimal Capacite { get; set; }

        public decimal Dimensions { get; set; }

        public Accessoire()
        {
            this.Categorie = Categories.Accessoire;
        }
    }
}