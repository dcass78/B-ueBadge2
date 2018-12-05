namespace TrailRanking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WishList",
                c => new
                    {
                        WishListId = c.Int(nullable: false, identity: true),
                        Trail = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.WishListId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WishList");
        }
    }
}
