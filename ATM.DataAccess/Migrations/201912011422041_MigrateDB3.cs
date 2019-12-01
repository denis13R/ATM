namespace ATM.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cards", new[] { "CardNum" });
            AlterColumn("dbo.Cards", "CardNum", c => c.String(maxLength: 16, fixedLength: true, unicode: false));
            AlterColumn("dbo.Cards", "PinCode", c => c.String(maxLength: 4, fixedLength: true, unicode: false));
            CreateIndex("dbo.Cards", "CardNum");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cards", new[] { "CardNum" });
            AlterColumn("dbo.Cards", "PinCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Cards", "CardNum", c => c.String(maxLength: 20, unicode: false));
            CreateIndex("dbo.Cards", "CardNum");
        }
    }
}
