using System;
using System.Data.Entity;
using TryMLearning.Persistence.Interface;

namespace TryMLearning.Persistence
{
    public class Transaction : ITransaction
    {
        private readonly DbContextTransaction _dbContextTransaction;
        private bool _isDisposed;

        public Transaction(DbContextTransaction dbContextTransaction)
        {
            _dbContextTransaction = dbContextTransaction;
        }

        public void Commit()
        {
            _dbContextTransaction.Commit();
        }

        public void Rollback()
        {
            _dbContextTransaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _isDisposed)
                return;

            _dbContextTransaction.Dispose();

            _isDisposed = true;
        }
    }
}