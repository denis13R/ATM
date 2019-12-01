using System;

namespace ATM.BusinessLogic.Interfaces
{
    public interface IOperationService
    {
        void NoteOperation(int cardId, string cardNum, string operationCode, 
            decimal withdrewMoneyAmount, DateTime dateTime);
    }
}
