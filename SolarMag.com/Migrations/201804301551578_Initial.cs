namespace SolarMag.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Commandes", "Comptes_Id", "dbo.Comptes");
            DropIndex("dbo.Commandes", new[] { "Comptes_Id" });
            AddColumn("dbo.Commandes", "PanierVendu", c => c.String());
            AddColumn("dbo.Commandes", "DateDeLaCommande", c => c.DateTime(nullable: false));
            AddColumn("dbo.PanierItems", "Panier_Id", c => c.Int());
            CreateIndex("dbo.PanierItems", "Panier_Id");
            AddForeignKey("dbo.PanierItems", "Panier_Id", "dbo.Paniers", "Id");
            DropColumn("dbo.Comptes", "NoFacture");
            DropColumn("dbo.Comptes", "BonLivraison");
            DropColumn("dbo.Commandes", "DateCommande");
            DropColumn("dbo.Commandes", "Comptes_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Commandes", "Comptes_Id", c => c.Int());
            AddColumn("dbo.Commandes", "DateCommande", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comptes", "BonLivraison", c => c.String());
            AddColumn("dbo.Comptes", "NoFacture", c => c.String());
            DropForeignKey("dbo.PanierItems", "Panier_Id", "dbo.Paniers");
            DropIndex("dbo.PanierItems", new[] { "Panier_Id" });
            DropColumn("dbo.PanierItems", "Panier_Id");
            DropColumn("dbo.Commandes", "DateDeLaCommande");
            DropColumn("dbo.Commandes", "PanierVendu");
            CreateIndex("dbo.Commandes", "Comptes_Id");
            AddForeignKey("dbo.Commandes", "Comptes_Id", "dbo.Comptes", "Id");
        }
    }
}
