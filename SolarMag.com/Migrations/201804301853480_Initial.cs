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
                        NoReference = c.String(nullable: false, maxLength: 40),
                        Fabricant = c.String(nullable: false, maxLength: 40),
                        Description = c.String(maxLength: 200),
                        Poids = c.Double(nullable: false),
                        Garantie = c.String(maxLength: 40),
                        Prix = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantiteStock = c.Int(nullable: false),
                        Amperage = c.Double(),
                        Voltage = c.Double(),
                        Capacite = c.Double(),
                        Dimensions = c.String(maxLength: 100),
                        Voltage1 = c.Double(),
                        Capacite1 = c.Double(),
                        Dimensions1 = c.String(maxLength: 100),
                        WattsHeureJour = c.Double(),
                        AmperesHeureJour = c.Double(),
                        Composition = c.String(maxLength: 100),
                        Dimensions2 = c.String(maxLength: 100),
                        Amperage1 = c.Double(),
                        Voltage2 = c.Double(),
                        Capacite2 = c.Double(),
                        Composition1 = c.String(maxLength: 100),
                        Dimensions3 = c.String(maxLength: 100),
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
                        ClientId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Panier_Id = c.Int(),
                        Coordonnee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paniers", t => t.Panier_Id)
                .ForeignKey("dbo.Coordonnees", t => t.Coordonnee_Id)
                .Index(t => t.Panier_Id)
                .Index(t => t.Coordonnee_Id);
            
            CreateTable(
                "dbo.Coordonnees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoCivique = c.Int(nullable: false),
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
                        PanierVendu = c.String(),
                        DateDeLaCommande = c.DateTime(nullable: false),
                        Coordonnee = c.String(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comptes", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Paniers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PanierItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantite = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        Panier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.Paniers", t => t.Panier_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.Panier_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comptes", "Coordonnee_Id", "dbo.Coordonnees");
            DropForeignKey("dbo.Comptes", "Panier_Id", "dbo.Paniers");
            DropForeignKey("dbo.PanierItems", "Panier_Id", "dbo.Paniers");
            DropForeignKey("dbo.PanierItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Pile_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "PanneauSolaire_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Convertisseur_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Accessoire_Id", "dbo.Items");
            DropForeignKey("dbo.Coordonnees", "Client_Id", "dbo.Comptes");
            DropForeignKey("dbo.Commandes", "Client_Id", "dbo.Comptes");
            DropIndex("dbo.PanierItems", new[] { "Panier_Id" });
            DropIndex("dbo.PanierItems", new[] { "Item_Id" });
            DropIndex("dbo.Commandes", new[] { "Client_Id" });
            DropIndex("dbo.Coordonnees", new[] { "Client_Id" });
            DropIndex("dbo.Comptes", new[] { "Coordonnee_Id" });
            DropIndex("dbo.Comptes", new[] { "Panier_Id" });
            DropIndex("dbo.Items", new[] { "Pile_Id" });
            DropIndex("dbo.Items", new[] { "PanneauSolaire_Id" });
            DropIndex("dbo.Items", new[] { "Convertisseur_Id" });
            DropIndex("dbo.Items", new[] { "Accessoire_Id" });
            DropTable("dbo.PanierItems");
            DropTable("dbo.Paniers");
            DropTable("dbo.Commandes");
            DropTable("dbo.Coordonnees");
            DropTable("dbo.Comptes");
            DropTable("dbo.Items");
        }
    }
}
