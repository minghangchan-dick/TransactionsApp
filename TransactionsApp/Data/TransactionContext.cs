using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransactionsApp.Models;

namespace TransactionsApp.Data
{
    public class TransactionContext : DbContext
    {
        public TransactionContext (DbContextOptions<TransactionContext> options)
            : base(options)
        {
        }

        public DbSet<TransactionsApp.Models.Transaction> Transaction { get; set; } = default!;
    }
}
