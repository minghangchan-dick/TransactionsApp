namespace TransactionsApp.Models
{
    public class TransactionEventArgs : EventArgs
    {
        public TransactionEventArgs(Transaction transaction)
        {
            Transaction = transaction;
        }

        public Transaction Transaction { get; set; }
    }
}
