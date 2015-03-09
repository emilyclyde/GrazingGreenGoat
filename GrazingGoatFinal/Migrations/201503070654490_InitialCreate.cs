namespace GrazingGoatFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerFirst = c.String(nullable: false, maxLength: 50),
                        CustomerLast = c.String(nullable: false, maxLength: 50),
                        CustomerAddress = c.String(),
                        CustomerEmail = c.String(),
                        Goat_ID = c.Int(),
                        Lot_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Goat", t => t.Goat_ID)
                .ForeignKey("dbo.Lot", t => t.Lot_ID)
                .Index(t => t.Goat_ID)
                .Index(t => t.Lot_ID);
            
            CreateTable(
                "dbo.Goat",
                c => new
                    {
                        GoatID = c.Int(nullable: false, identity: true),
                        GoatName = c.String(),
                        GoatColor = c.String(),
                        GoatType = c.String(),
                        GoatGender = c.String(),
                        Lot_ID = c.Int(),
                    })
                .PrimaryKey(t => t.GoatID)
                .ForeignKey("dbo.Lot", t => t.Lot_ID)
                .Index(t => t.Lot_ID);
            
            CreateTable(
                "dbo.Lot",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GoatID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        GoatName = c.String(nullable: false, maxLength: 50),
                        CustomerFirst = c.String(nullable: false, maxLength: 50),
                        CustomerLast = c.String(nullable: false, maxLength: 50),
                        LotAddress = c.String(nullable: false, maxLength: 50),
                        LotDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pasture",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GoatID = c.Int(nullable: false),
                        Field = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Goat", t => t.GoatID, cascadeDelete: true)
                .Index(t => t.GoatID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "Lot_ID", "dbo.Lot");
            DropForeignKey("dbo.Customer", "Goat_ID", "dbo.Goat");
            DropForeignKey("dbo.Pasture", "GoatID", "dbo.Goat");
            DropForeignKey("dbo.Goat", "Lot_ID", "dbo.Lot");
            DropIndex("dbo.Pasture", new[] { "GoatID" });
            DropIndex("dbo.Goat", new[] { "Lot_ID" });
            DropIndex("dbo.Customer", new[] { "Lot_ID" });
            DropIndex("dbo.Customer", new[] { "Goat_ID" });
            DropTable("dbo.Pasture");
            DropTable("dbo.Lot");
            DropTable("dbo.Goat");
            DropTable("dbo.Customer");
        }
    }
}
