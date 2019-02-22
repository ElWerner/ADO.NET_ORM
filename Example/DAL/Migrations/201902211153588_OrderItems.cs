namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_order_items",
                c => new
                    {
                        cln_item_id = c.Int(nullable: false),
                        cln_order_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.cln_item_id, t.cln_order_id })
                .ForeignKey("dbo.tbl_orders", t => t.cln_order_id, cascadeDelete: true)
                .ForeignKey("dbo.tbl_items", t => t.cln_item_id, cascadeDelete: true)
                .Index(t => t.cln_item_id)
                .Index(t => t.cln_order_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_order_items", "cln_item_id", "dbo.tbl_items");
            DropForeignKey("dbo.tbl_order_items", "cln_order_id", "dbo.tbl_orders");
            DropIndex("dbo.tbl_order_items", new[] { "cln_order_id" });
            DropIndex("dbo.tbl_order_items", new[] { "cln_item_id" });
            DropTable("dbo.tbl_order_items");
        }
    }
}
