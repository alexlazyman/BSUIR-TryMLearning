using System;

namespace TryMLearning.Persistence.Interface
{
    public interface ITransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}