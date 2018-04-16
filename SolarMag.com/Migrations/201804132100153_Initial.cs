namespace SolarMag.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 40),
                        NoReference = c.String(),
                        Fabricant = c.String(),
                        Description = c.String(),
                        Poids = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Garantie = c.String(),
                        Prix = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amperage = c.Decimal(precision: 18, scale: 2),
                        Voltage = c.Decimal(precision: 18, scale: 2),
                        Capacite = c.Decimal(precision: 18, scale: 2),
                        Dimensions = c.Decimal(precision: 18, scale: 2),
                        Voltage1 = c.Decimal(precision: 18, scale: 2),
                        Capacite1 = c.Decimal(precision: 18, scale: 2),
                        Dimensions1 = c.Decimal(precision: 18, scale: 2),
                        WattsHeureJour = c.Decimal(precision: 18, scale: 2),
                        AmperesHeureJour = c.Decimal(precision: 18, scale: 2),
                        Dimensions2 = c.Decimal(precision: 18, scale: 2),
                        Composition = c.String(),
                        Amperage1 = c.Decimal(precision: 18, scale: 2),
                        Voltage2 = c.Decimal(precision: 18, scale: 2),
                        Capacite2 = c.Decimal(precision: 18, scale: 2),
                        Dimensions3 = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Accessoire_Id = c.Int(),
                        Convertisseur_Id = c.Int(),
                        PanneauSolaire_Id = c.Int(),
                        Pile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Accessoire_Id)
                .ForeignKey("dbo.Items", t => t.Convertisseur_Id)
                .ForeignKey("dbo.Items", t => t.PanneauSolaire_Id)
                .ForeignKey("dbo.Items", t => t.Pile_Id)
                .Index(t => t.Accessoire_Id)
                .Index(t => t.Convertisseur_Id)
                .Index(t => t.PanneauSolaire_Id)
                .Index(t => t.Pile_Id);
            
            CreateTable(
                "dbo.Comptes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        NoEmploye = c.Int(),
                        Titre = c.String(),
                        PosteTel = c.String(),
                        NoFacture = c.String(),
                        BonLivraison = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Coordonnee_Id = c.Int(),
                        Panier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coordonnees", t => t.Coordonnee_Id)
                .ForeignKey("dbo.Paniers", t => t.Panier_Id)
                .Index(t => t.Coordonnee_Id)
                .Index(t => t.Panier_Id);
            
            CreateTable(
                "dbo.Coordonnees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adresse = c.String(),
                        Ville = c.String(),
                        Province_Etat = c.String(),
                        Pays = c.String(),
                        CodePostal_ZipCode = c.String(),
                        Telephone = c.String(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comptes", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCommande = c.DateTime(nullable: false),
                        Coordonnee = c.String(),
                        Comptes_Id = c.Int(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comptes", t => t.Comptes_Id)
                .ForeignKey("dbo.Comptes", t => t.Client_Id)
                .Index(t => t.Comptes_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Paniers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Pile_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "PanneauSolaire_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Convertisseur_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Accessoire_Id", "dbo.Items");
            DropForeignKey("dbo.Comptes", "Panier_Id", "dbo.Paniers");
            DropForeignKey("dbo.Coordonnees", "Client_Id", "dbo.Comptes");
            DropForeignKey("dbo.Commandes", "Client_Id", "dbo.Comptes");
            DropForeignKey("dbo.Commandes", "Comptes_Id", "dbo.Comptes");
            DropForeignKey("dbo.Comptes", "Coordonnee_Id", "dbo.Coordonnees");
            DropIndex("dbo.Commandes", new[] { "Client_Id" });
            DropIndex("dbo.Commandes", new[] { "Comptes_Id" });
            DropIndex("dbo.Coordonnees", new[] { "Client_Id" });
            DropIndex("dbo.Comptes", new[] { "Panier_Id" });
            DropIndex("dbo.Comptes", new[] { "Coordonnee_Id" });
            DropIndex("dbo.Items", new[] { "Pile_Id" });
            DropIndex("dbo.Items", new[] { "PanneauSolaire_Id" });
            DropIndex("dbo.Items", new[] { "Convertisseur_Id" });
            DropIndex("dbo.Items", new[] { "Accessoire_Id" });
            DropTable("dbo.Paniers");
            DropTable("dbo.Commandes");
            DropTable("dbo.Coordonnees");
            DropTable("dbo.Comptes");
            DropTable("dbo.Items");
        }
    }
}
