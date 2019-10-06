namespace AlfaSample.Data.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ANewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        CompanyName = c.String(nullable: false, maxLength: 128),
                        City = c.String(),
                        Address = c.String(),
                        Contract = c.String(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        ContactPerson = c.String(),
                        ContractDateStart = c.DateTime(nullable: false),
                        ContractDateEnd = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyName);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceNumber = c.String(nullable: false, maxLength: 128),
                        CompanyName = c.String(nullable: false, maxLength: 128),
                        InvoiceDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Charge = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Units = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.InvoiceNumber, t.CompanyName });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Invoices");
            DropTable("dbo.Clients");
        }
    }
}
