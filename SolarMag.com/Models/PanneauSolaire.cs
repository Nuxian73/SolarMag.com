using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class PanneauSolaire : Item
    {
        public double WattsHeureJour { get; set; }

        public double AmperesHeureJour { get; set; }

        [StringLength(100, ErrorMessage = "Maximum 100 caractères")]
        public string Composition { get; set; }

        [StringLength(100, ErrorMessage = "Maximum 100 caractères")]
        public string Dimensions { get; set; }

        public PanneauSolaire()
        {
            this.Categorie = Categories.PanneauSolaire;
        }
    }
}