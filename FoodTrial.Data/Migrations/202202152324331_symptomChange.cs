namespace FoodTrial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class symptomChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trial", "Symptoms");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trial", "Symptoms", c => c.Int(nullable: false));
        }
    }
}
