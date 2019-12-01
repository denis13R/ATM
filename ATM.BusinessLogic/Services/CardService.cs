using ATM.BusinessLogic.Helpers;
using ATM.BusinessLogic.Interfaces;
using ATM.BusinessLogic.Models;
using ATM.DataAccess.Interfaces;

namespace ATM.BusinessLogic.Services
{
    public class CardService : ICardService
    {
        private ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public CardModel GetCardByNum(string cardNum)
        {
            return Mapper.ToCardModel(_cardRepository.GetCardByNum(cardNum));
        }

        public void WithdrawMoney(string cardNum, decimal cashAmount)
        {
            var oldBalance = _cardRepository.GetBalance(cardNum);
            var newBalance = oldBalance - cashAmount;
            _cardRepository.SetBalance(cardNum, newBalance);
        }

        public string CardNumWithDashes(string cardNum)
        {
            string cardNumWithDashes = cardNum.Insert(4, "-");
            int[] ind = { 9, 14 };
            foreach (int i in ind)
            {
                cardNumWithDashes = cardNumWithDashes.Insert(i, "-");
            }
            return cardNumWithDashes;
        }
    }
}