namespace Data_Access_Layer__DAL_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "type_Id", "dbo.types");
            DropIndex("dbo.Orders", new[] { "type_Id" });
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        img = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        price = c.Int(nullable: false),
                        discount = c.Int(nullable: false),
                        img = c.String(),
                        category_Id = c.Int(),
                        order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.category_Id)
                .ForeignKey("dbo.Orders", t => t.order_Id)
                .Index(t => t.category_Id)
                .Index(t => t.order_Id);
            
            AddColumn("dbo.Orders", "totalPrice", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "price");
            DropColumn("dbo.Orders", "stock");
            DropColumn("dbo.Orders", "img");
            DropColumn("dbo.Orders", "type_Id");
            DropTable("dbo.types");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "type_Id", c => c.Int());
            AddColumn("dbo.Orders", "img", c => c.String());
            AddColumn("dbo.Orders", "stock", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "price", c => c.Int(nullable: false));
            DropForeignKey("dbo.products", "order_Id", "dbo.Orders");
            DropForeignKey("dbo.products", "category_Id", "dbo.Categories");
            DropIndex("dbo.products", new[] { "order_Id" });
            DropIndex("dbo.products", new[] { "category_Id" });
            DropColumn("dbo.Orders", "totalPrice");
            DropTable("dbo.products");
            DropTable("dbo.Categories");
            CreateIndex("dbo.Orders", "type_Id");
            AddForeignKey("dbo.Orders", "type_Id", "dbo.types", "Id");
        }
    }
}
