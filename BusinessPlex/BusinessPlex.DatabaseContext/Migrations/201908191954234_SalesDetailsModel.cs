namespace BusinessPlex.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesDetailsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesCustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SalesCustomers", t => t.SalesCustomerId, cascadeDelete: true)
                .Index(t => t.SalesCustomerId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesDetails", "SalesCustomerId", "dbo.SalesCustomers");
            DropForeignKey("dbo.SalesDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.SalesDetails", new[] { "ProductId" });
            DropIndex("dbo.SalesDetails", new[] { "SalesCustomerId" });
            DropTable("dbo.SalesDetails");
        }
    }
}
