using ATM.DataAccess.Entities;
using System.Data.Entity;

namespace ATM.DataAccess
{
    public class ATMContext : DbContext
    {
        public ATMContext() : base("name=ATMContext")
        {
        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Operation> Operations { get; set; }
    }
}
