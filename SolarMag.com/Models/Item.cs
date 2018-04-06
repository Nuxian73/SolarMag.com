using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Description { get; set; }

        public int Quantite { get; set; }

        public decimal Prix { get; set; }

        public Item()
        {
        }
    }
}