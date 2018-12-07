namespace TrailRanking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrailUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trail", "EquipmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Trail", "EquipmentId");
            AddForeignKey("dbo.Trail", "EquipmentId", "dbo.Equipment", "EquipmentId", cascadeDelete: true);
            DropColumn("dbo.Trail", "Equipment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trail", "Equipment", c => c.String(nullable: false));
            DropForeignKey("dbo.Trail", "EquipmentId", "dbo.Equipment");
            DropIndex("dbo.Trail", new[] { "EquipmentId" });
            DropColumn("dbo.Trail", "EquipmentId");
        }
    }
}
