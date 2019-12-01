namespace ATM.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        CardNum = c.String(),
                        PinCode = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CardId);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        OperationId = c.Int(nullable: false, identity: true),
                        CardId = c.Int(nullable: false),
                        CardNum = c.String(),
                        OperationCode = c.String(),
                        WithdrewMoneyAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperationDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OperationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Operations");
            DropTable("dbo.Cards");
        }
    }
}
