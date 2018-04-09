using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SolarMag.com.Models
{
    public class Commande
    {
        public int Id { get; set; }

        public string NoPanier { get; set; }


        [Display(Name = "No. Facture")]
        public string NoFacture { get; set; }

        [Display(Name = "No. Produit")]
        public string NoProduit { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Quantité")]
        public int Quantite{ get; set; }


        public virtual Item Items { get; set; }
        public virtual Compte Comptes { get; set; }

    }
}