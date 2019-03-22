namespace And.Eticaret.Core.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryID = c.Int(nullable: false),
                        Brand = c.String(),
                        Model = c.String(),
                        ImageUrl = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(nullable: false),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        UserAddressID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        TotalProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalTaxPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Status", t => t.StatusID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.UserAddresses", t => t.UserAddressID)
                .Index(t => t.UserID)
                .Index(t => t.UserAddressID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.OrderPayments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        OrderType = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bank = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                        Password = c.String(),
                        TCKN = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Title = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserAddressID", "dbo.UserAddresses");
            DropForeignKey("dbo.UserAddresses", "UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "StatusID", "dbo.Status");
            DropForeignKey("dbo.OrderProducts", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderPayments", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Baskets", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.UserAddresses", new[] { "UserID" });
            DropIndex("dbo.OrderProducts", new[] { "ProductID" });
            DropIndex("dbo.OrderProducts", new[] { "OrderID" });
            DropIndex("dbo.OrderPayments", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "StatusID" });
            DropIndex("dbo.Orders", new[] { "UserAddressID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Baskets", new[] { "ProductID" });
            DropTable("dbo.UserAddresses");
            DropTable("dbo.Users");
            DropTable("dbo.Status");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.OrderPayments");
            DropTable("dbo.Orders");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Baskets");
        }
    }
}
