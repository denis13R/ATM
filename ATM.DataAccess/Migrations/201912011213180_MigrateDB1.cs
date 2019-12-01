namespace ATM.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cards", "CardNum", c => c.String(maxLength: 50, unicode: false));
            CreateIndex("dbo.Cards", "CardNum");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cards", new[] { "CardNum" });
            AlterColumn("dbo.Cards", "CardNum", c => c.String());
        }
    }
}
