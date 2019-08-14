namespace BusinessPlex.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseSupplierModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseSuppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseSuppliers", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.PurchaseSuppliers", new[] { "SupplierId" });
            DropTable("dbo.PurchaseSuppliers");
        }
    }
}
