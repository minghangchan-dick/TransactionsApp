using TransactionsApp.Data;
using TransactionsApp.Interface;
using TransactionsApp.Models;

namespace TransactionsApp.Services
{
    public class EventService : IEventService
    {
        private readonly ILogger _logger;
        private readonly TransactionContext _context;
        public event EventHandler<TransactionEventArgs> TransactionRaised;

        public EventService(ILogger<EventService> logger, TransactionContext context)
        {
            _context = context;
            _logger = logger;
        }

        public void RaiseTransactionEvent(Transaction transaction)
        {
            TransactionRaised?.Invoke(this, new TransactionEventArgs(transaction));
        }

        public void HandleTransactionEvent(Transaction transaction)
        {
            try
            {
                _context.Transaction.Add(transaction);
                transaction.Status = _context.SaveChanges() > 0? "SUCCESS": "FAILED";
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                transaction.Status = "FAILED";
            }

            _context.Transaction.Update(transaction);
            _context.SaveChanges();
        }

       
    }
}
