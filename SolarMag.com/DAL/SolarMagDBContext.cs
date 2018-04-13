using SolarMag.com.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SolarMag.com.DAL
{
    public class SolarMagDBContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<Pile> Piles { get; set; }

        public DbSet<PanneauSolaire> PanneauSolaires { get; set; }

        public DbSet<Accessoire> Accessoires { get; set; }

        public DbSet<Convertisseur> Convertisseurs { get; set; }

        public DbSet<Kit> Kits { get; set; }

        public DbSet<Panier> Paniers { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Commande> Commandes { get; set; }

        public DbSet<Coordonnee> Coordonnees { get; set; }

        public DbSet<Compte> Comptes { get; set; }

        public DbSet<Administrateur> Administrateurs { get; set; }
    }
}