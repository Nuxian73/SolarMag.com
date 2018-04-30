using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class PanierItem
    {
        public int Id { get; set; }

        [Display(Name = "Produit")]
        public virtual Item Item { get; set; }
        
        [Display(Name = "Quantité")]
        public uint Quantite { get; set; }

        public PanierItem(Item item, uint quantite)
        {
            Item = item;
            Quantite = quantite;
        }

        public PanierItem()
        {
        }
    }
}