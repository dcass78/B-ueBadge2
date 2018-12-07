namespace TrailRanking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TalesUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WishList", "TrailName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WishList", "TrailName");
        }
    }
}
