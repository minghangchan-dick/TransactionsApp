using TransactionsApp.Models;

namespace TransactionsApp.Interface
{
    public interface IEventService
    {
        public event EventHandler<TransactionEventArgs> TransactionRaised;
        public void RaiseTransactionEvent(Transaction transaction);
        public void HandleTransactionEvent(Transaction transaction);
    }
}
