namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_items",
                c => new
                    {
                        cln_item_id = c.Int(nullable: false, identity: true),
                        cln_item_description = c.String(),
                        cln_item_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.cln_item_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_items");
        }
    }
}
