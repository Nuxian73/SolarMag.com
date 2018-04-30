namespace SolarMag.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PanierItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PanierItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PanierItems", "Item_Id", "dbo.Items");
            DropIndex("dbo.PanierItems", new[] { "Item_Id" });
            DropTable("dbo.PanierItems");
        }
    }
}
