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
       
       [Display(Name = "No. Facture")]
       
        public string NoFacture { get; set; }

        [Display(Name = "No. Produit")]
         public string NoProduit { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Quantité")]

        public int Quantite{ get; set; }

        
       






    }
}