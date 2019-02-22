namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_orders",
                c => new
                    {
                        cln_order_id = c.Int(nullable: false, identity: true),
                        cln_order_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.cln_order_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_orders");
        }
    }
}
