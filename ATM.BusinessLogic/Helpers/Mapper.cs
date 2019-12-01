using ATM.BusinessLogic.Models;
using ATM.DataAccess.Entities;

namespace ATM.BusinessLogic.Helpers
{
    public static class Mapper
    {
        public static Card ToCard(CardModel cardModel)
        {
            return new Card
            {
                CardId = cardModel.CardId,
                CardNum = cardModel.CardNum,
                PinCode = cardModel.PinCode,
                Balance = cardModel.Balance,
                IsActive = cardModel.IsActive

            };
        }

        public static CardModel ToCardModel(Card card)
        {
            if(card == null)
            {
                return null;
            }
            return new CardModel
            {
                CardId = card.CardId,
                CardNum = card.CardNum,
                PinCode = card.PinCode,
                Balance = card.Balance,
                IsActive = card.IsActive
            };
        }

        public static Operation ToOperation(OperationModel operationModel)
        {
            return new Operation
            {
                OperationId = operationModel.OperationId,
                CardId = operationModel.CardId,
                CardNum = operationModel.CardNum,
                OperationCode = operationModel.OperationCode,
                WithdrewMoneyAmount = operationModel.WithdrewMoneyAmount,
                OperationDateTime = operationModel.OperationDateTime
            };
        }

        public static OperationModel ToOperationModel(Operation operation)
        {
            return new OperationModel
            {
                OperationId = operation.OperationId,
                CardId = operation.CardId,
                CardNum = operation.CardNum,
                OperationCode = operation.OperationCode,
                WithdrewMoneyAmount = operation.WithdrewMoneyAmount,
                OperationDateTime = operation.OperationDateTime
            };
        }
    }
}
