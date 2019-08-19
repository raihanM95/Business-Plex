namespace BusinessPlex.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase_SomeDataTypeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseDetails", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PurchaseDetails", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PurchaseDetails", "MRP", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PurchaseSuppliers", "InvoiceNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseSuppliers", "InvoiceNo", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseDetails", "MRP", c => c.Double(nullable: false));
            AlterColumn("dbo.PurchaseDetails", "TotalPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.PurchaseDetails", "UnitPrice", c => c.Double(nullable: false));
        }
    }
}
