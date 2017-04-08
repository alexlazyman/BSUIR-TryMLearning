using TryMLearning.Persistence.Interface;

namespace TryMLearning.Persistence
{
    public class TransactionScope : ITransactionScope
    {
        private readonly TryMLearningDbContext _tryMLearningDbContext;

        public TransactionScope(TryMLearningDbContext tryMLearningDbContext)
        {
            _tryMLearningDbContext = tryMLearningDbContext;
        }

        public ITransaction Begin()
        {
            var dbContextTransaction = _tryMLearningDbContext.Database.BeginTransaction();

            return new Transaction(dbContextTransaction);
        }
    }
}