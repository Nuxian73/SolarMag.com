﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Compte
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public Coordonnee Coordonnee { get; set; }

        public Compte()
        {
        }
    }
}