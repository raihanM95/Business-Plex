namespace BusinessPlex.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseSupplier_DataAnnotationAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseSuppliers", "InvoiceNo", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseSuppliers", "InvoiceNo", c => c.String(nullable: false));
        }
    }
}
