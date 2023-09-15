using System.Transactions;

namespace TransactionsApp.Models
{
    public class TransactionResponseDto
    {
        public TransactionResponseDto(Transaction transaction)
        {
            Id = transaction.Id;
            Amount = transaction.Amount;
            Date = transaction.Date;
            Status = transaction.Status.ToString();
        }

        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
