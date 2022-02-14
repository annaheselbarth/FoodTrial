namespace FoodTrial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medicine", "TrialId", "dbo.Trial");
            DropIndex("dbo.Medicine", new[] { "TrialId" });
            AlterColumn("dbo.Medicine", "TrialId", c => c.Int());
            CreateIndex("dbo.Medicine", "TrialId");
            AddForeignKey("dbo.Medicine", "TrialId", "dbo.Trial", "TrialId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicine", "TrialId", "dbo.Trial");
            DropIndex("dbo.Medicine", new[] { "TrialId" });
            AlterColumn("dbo.Medicine", "TrialId", c => c.Int(nullable: false));
            CreateIndex("dbo.Medicine", "TrialId");
            AddForeignKey("dbo.Medicine", "TrialId", "dbo.Trial", "TrialId", cascadeDelete: true);
        }
    }
}
