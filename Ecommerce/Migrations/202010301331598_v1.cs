namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        basketItemId = c.Int(nullable: false, identity: true),
                        productQuantity = c.Int(nullable: false),
                        totalPrice = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                        basketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.basketItemId)
                .ForeignKey("dbo.Baskets", t => t.basketId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId)
                .Index(t => t.basketId);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        basketId = c.Int(nullable: false, identity: true),
                        totalPrice = c.Int(nullable: false),
                        userId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.basketId)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        shipAdress = c.String(),
                        totalPrice = c.Int(nullable: false),
                        paymentType = c.String(),
                        userId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.orderId)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        orderDetailId = c.Int(nullable: false, identity: true),
                        unitPrice = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        orderId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.orderDetailId)
                .ForeignKey("dbo.Orders", t => t.orderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.orderId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        unitPrice = c.Int(nullable: false),
                        stockQuantity = c.Int(nullable: false),
                        categoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.Categories", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        parentCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.categoryId)
                .ForeignKey("dbo.Categories", t => t.parentCategoryId)
                .Index(t => t.parentCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "productId", "dbo.Products");
            DropForeignKey("dbo.BasketItems", "basketId", "dbo.Baskets");
            DropForeignKey("dbo.Baskets", "userId", "dbo.Users");
            DropForeignKey("dbo.Orders", "userId", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "productId", "dbo.Products");
            DropForeignKey("dbo.Products", "categoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "parentCategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "orderId", "dbo.Orders");
            DropIndex("dbo.Categories", new[] { "parentCategoryId" });
            DropIndex("dbo.Products", new[] { "categoryId" });
            DropIndex("dbo.OrderDetails", new[] { "productId" });
            DropIndex("dbo.OrderDetails", new[] { "orderId" });
            DropIndex("dbo.Orders", new[] { "userId" });
            DropIndex("dbo.Baskets", new[] { "userId" });
            DropIndex("dbo.BasketItems", new[] { "basketId" });
            DropIndex("dbo.BasketItems", new[] { "productId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}
