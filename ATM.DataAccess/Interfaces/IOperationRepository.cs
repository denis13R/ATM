using ATM.DataAccess.Entities;

namespace ATM.DataAccess.Interfaces
{
    public interface IOperationRepository
    {
        void NoteOperation(Operation operation);
    }
}
