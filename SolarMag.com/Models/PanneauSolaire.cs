using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class PanneauSolaire : Item
    {
        public decimal WattsHeureJour { get; set; }

        public decimal AmperesHeureJour { get; set; }

        public decimal Dimensions { get; set; }

        public string Composition { get; set; }
    }
}