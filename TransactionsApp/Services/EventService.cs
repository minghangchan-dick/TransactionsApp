using Microsoft.EntityFrameworkCore;
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
            var _t = from t in _context.Transaction
                    where EF.Functions.DateDiffSecond(t.Date, transaction.Date) <= 30 && transaction.Amount == t.Amount
                    select t;
            var is_repeated = _t.Any();

            transaction.Status = is_repeated ? Transaction.TransactionStatus.REPEATED : Transaction.TransactionStatus.NORMAL;

            _context.Transaction.Add(transaction);
            _context.SaveChanges();
        }
    }
}
