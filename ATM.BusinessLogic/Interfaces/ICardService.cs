using ATM.BusinessLogic.Models;

namespace ATM.BusinessLogic.Interfaces
{
    public interface ICardService
    {
        CardModel GetCardByNum(string cardNum);

        void WithdrawMoney(string cardNum, decimal cashAmount);

        string CardNumWithDashes(string cardNum);
    }
}