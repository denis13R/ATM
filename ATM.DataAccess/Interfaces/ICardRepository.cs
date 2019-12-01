using ATM.DataAccess.Entities;

namespace ATM.DataAccess.Interfaces
{
    public interface ICardRepository
    {
        Card GetCardByNum(string cardNum);

        decimal GetBalance(string cardNum);

        void SetBalance(string cardNum, decimal newBalance);
    }
}