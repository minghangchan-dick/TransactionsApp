using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionsApp.Models
{
    public class Transaction
    {
        public enum TransactionStatus
        {
            NORMAL,
            REPEATED
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
