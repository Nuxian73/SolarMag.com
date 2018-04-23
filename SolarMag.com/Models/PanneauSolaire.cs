using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class PanneauSolaire : Item
    {
        [Display(Name = "Watts/heure (de jour)")]
        [Range(0, 1000000, ErrorMessage = "Valeur de 0 à 1000000,00")]
        public double WattsHeureJour { get; set; }

        [Display(Name = "Ampères/heure (de jour)")]
        [Range(0, 1000000, ErrorMessage = "Valeur de 0 à 1000000,00")]
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