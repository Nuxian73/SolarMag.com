using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Client : Compte
    {
        public int NoClient { get; set; }

        

        public string NoFacture { get; set; }
        public string BonLivraison { get; set; }


        public virtual Panier Panier { get; set; }

        public virtual List<Commande> Commandes { get; set; }

        public Client()
        {
            this.Panier = new Panier();
            this.Commandes = new List<Commande>();
        }
    }
}