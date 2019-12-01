using ATM.BusinessLogic.Helpers;
using ATM.BusinessLogic.Interfaces;
using ATM.BusinessLogic.Models;
using ATM.DataAccess.Interfaces;
using System;

namespace ATM.BusinessLogic.Services
{
    public class OperationService : IOperationService
    {
        private IOperationRepository _operationRepository;

        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public void NoteOperation(int cardId, string cardNum, string operationCode,
            decimal withdrewMoneyAmount, DateTime dateTime)
        {
            OperationModel operationModel = new OperationModel()
            {
                CardId = cardId,
                CardNum = cardNum,
                OperationCode = operationCode,
                WithdrewMoneyAmount = withdrewMoneyAmount,
                OperationDateTime = dateTime
            };
            _operationRepository.NoteOperation(Mapper.ToOperation(operationModel));
        }
    }
}
