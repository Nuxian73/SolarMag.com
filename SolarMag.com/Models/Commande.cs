using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SolarMag.com.Models
{
    public class Commande
    {
        public uint Id { get; set; }

        public string NoPanier { get; set; }


        [Display(Name = "No. Facture")]
        public string NoFacture { get; set; }

        [Display(Name = "No. Produit")]
        public string NoProduit { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Quantité")]
        public int Quantite{ get; set; }

        [Display(Name = "Items")]
        public virtual Item Item { get; set; }

        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "La valeur décimale est de 2 chiffres après le point")]
        [Range(0, 5, ErrorMessage = "La valeur maximun est 5 chiffres")]
        public decimal Prix { get;  }


        public virtual Compte Comptes { get; set; }

    }
}