namespace ATM.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ATM.DataAccess.ATMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ATM.DataAccess.ATMContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Cards.AddOrUpdate(
                new Entities.Card {
                    CardId = 1,
                    CardNum = "1111111111111111",
                    PinCode = "1111",
                    Balance = 5000.23M,
                    IsActive = true
                },
                new Entities.Card {
                    CardId = 2,
                    CardNum = "2222222222222222",
                    PinCode = "2222",
                    Balance = 3000M,
                    IsActive = false
                },
                new Entities.Card {
                    CardId = 3,
                    CardNum = "3333333333333333",
                    PinCode = "3333",
                    Balance = 1234.70M,
                    IsActive = true
                }
            );
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
