using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Pile : Item
    {
        public decimal Amperage { get; set; }

        public decimal Voltage { get; set; }
        
        public decimal Capacite { get; set; }

        public decimal Dimensions { get; set; }

        public Pile()
        {
            Categorie = Categories.Pile;
        }
    }
}