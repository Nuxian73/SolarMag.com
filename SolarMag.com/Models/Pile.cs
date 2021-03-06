﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Pile : Item
    {
        [Range(0, 1000000, ErrorMessage = "Valeur de 0 à 1000000,00")]
        public double Amperage { get; set; }

        [Range(0, 1000000, ErrorMessage = "Valeur de 0 à 1000000,00")]
        public double Voltage { get; set; }

        [Range(0, 1000000, ErrorMessage = "Valeur de 0 à 1000000,00")]
        public double Capacite { get; set; }

        [StringLength(100, ErrorMessage = "Maximum 100 caractères")]
        public string Composition { get; set; }

        [StringLength(100, ErrorMessage = "Maximum 100 caractères")]
        public string Dimensions { get; set; }

        public Pile()
        {
            this.Categorie = Categories.Pile;
        }
    }
}