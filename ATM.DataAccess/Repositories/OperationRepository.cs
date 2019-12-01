using ATM.DataAccess.Entities;
using ATM.DataAccess.Interfaces;

namespace ATM.DataAccess.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private ATMContext _context;

        public OperationRepository(ATMContext context)
        {
            _context = context;
        }

        public void NoteOperation(Operation operation)
        {
            _context.Operations.Add(operation);
            _context.SaveChanges();
        }
    }
}
