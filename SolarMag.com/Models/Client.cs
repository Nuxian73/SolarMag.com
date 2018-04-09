using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolarMag.com.Models
{
    public class Client : Compte
    {
        public uint NoClient { get; set; }

        //facturation livraison
        public string NoFacture { get; set; }
        public string BonLivraison { get; set; }

        //Panier

        public virtual Panier Panier { get; set; }




        //Commandes

       

    
        public virtual List<Commande> Commandes { get; set; }

        //Liste de coordonnées pour expédition
        public List<Coordonnee> ListeCoordonnee { get; set; }

        public Client()
        {
           
            this.Commandes = new List<Commande>();
        }
    }
}