namespace TicketDesk.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerDomainAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        Location = c.String(nullable: false, maxLength: 20),
                        MeterNumber = c.String(),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            AddColumn("dbo.Tickets", "IfPower", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "IfFire", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "IfLossOfLife", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "Customer_CustomerId", c => c.Int());
            CreateIndex("dbo.Tickets", "Customer_CustomerId");
            AddForeignKey("dbo.Tickets", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            DropColumn("dbo.Tickets", "AffectsCustomer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "AffectsCustomer", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Tickets", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Tickets", new[] { "Customer_CustomerId" });
            DropColumn("dbo.Tickets", "Customer_CustomerId");
            DropColumn("dbo.Tickets", "IfLossOfLife");
            DropColumn("dbo.Tickets", "IfFire");
            DropColumn("dbo.Tickets", "IfPower");
            DropTable("dbo.Customers");
        }
    }
}
