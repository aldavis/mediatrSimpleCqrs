namespace application.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AllowedDiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId, name: "IX_Customer_Id");
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        OrderId = c.Int(),
                        ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId, name: "IX_Order_Id")
                .Index(t => t.ProductId, name: "IX_Product_Id");
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartNumber = c.String(),
                        Description = c.String(),
                        CurrentInventoryCount = c.Int(nullable: false),
                        InventoryReorderThreshold = c.Int(nullable: false),
                        OnOrderCount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", "IX_Product_Id");
            DropIndex("dbo.OrderItems", "IX_Order_Id");
            DropIndex("dbo.Orders", "IX_Customer_Id");
            DropTable("dbo.Products");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
