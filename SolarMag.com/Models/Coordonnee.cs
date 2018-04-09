using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Coordonnee
    {
        public uint NoCivique { get; set; }

        public string Adresse { get; set; }

        public string Ville { get; set; }

        public string Province_Etat { get; set; }

        public string Pays { get; set; }

        public string CodePostal_ZipCode { get; set; }

        public string Telephone { get; set; }


    }
}