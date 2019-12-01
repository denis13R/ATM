using ATM.DataAccess.Entities;
using ATM.DataAccess.Interfaces;
using System.Linq;

namespace ATM.DataAccess.Repositories
{
    public class CardRepository : ICardRepository
    {
        private ATMContext _context;

        public CardRepository(ATMContext context)
        {
            _context = context;
        }

        public Card GetCardByNum(string cardNum)
        {
            return _context.Cards.FirstOrDefault(x => x.CardNum == cardNum);
        }

        public decimal GetBalance(string cardNum)
        {
            return _context.Cards.FirstOrDefault(x => x.CardNum == cardNum).Balance;
        }

        public void SetBalance(string cardNum, decimal newBalance)
        {
            var card = GetCardByNum(cardNum);
            card.Balance = newBalance;
            _context.SaveChanges();
        }
    }
}