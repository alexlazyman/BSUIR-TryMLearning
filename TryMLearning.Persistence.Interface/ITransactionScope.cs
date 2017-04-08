namespace TryMLearning.Persistence.Interface
{
    public interface ITransactionScope
    {
        ITransaction Begin();
    }
}