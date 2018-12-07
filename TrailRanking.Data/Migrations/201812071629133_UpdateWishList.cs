namespace TrailRanking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWishList : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WishList", "TrailName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WishList", "TrailName", c => c.String(nullable: false));
        }
    }
}
