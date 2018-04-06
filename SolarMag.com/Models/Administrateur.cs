using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Administrateur : Compte
    {
        public int NoEmploye { get; set; }

        public string Titre { get; set; }

        public string PosteTel { get; set; }

        public Administrateur()
        {
        }
    }
}