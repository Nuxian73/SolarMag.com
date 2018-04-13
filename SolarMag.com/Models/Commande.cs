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


        // no ligne,liste no item,nom item, prix Unitaire,quantité,prix total/ligne
        public Dictionary<uint, Tuple<List<string>>> PanierVendu { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de Commande")]
        public System.DateTime DateCommande { get; set; }


        public string Coordonnee { get; set; }


        public virtual Compte Comptes { get; set; }

        public Commande()
            {
            }
    }
}