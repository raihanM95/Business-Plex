namespace BusinessPlex.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesCustomerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesCustomers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        LoyaltyPoint = c.Int(nullable: false),
                        PayableAmounth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesCustomers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.SalesCustomers", new[] { "CustomerId" });
            DropTable("dbo.SalesCustomers");
        }
    }
}
