namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAddingItemsSuppliers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "JoinDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "JoinDate");
        }
    }
}
