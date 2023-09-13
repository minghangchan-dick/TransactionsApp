using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionsApp.Data;
using TransactionsApp.Interface;
using TransactionsApp.Models;
using TransactionsApp.Services;

namespace TransactionsApp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionContext _context;
        private readonly EventService _eventService;

        public TransactionController(TransactionContext context, IEventService eventSerivce)
        {
            _context = context;
            _eventService = (EventService)eventSerivce;
            _eventService.TransactionRaised += HandleTransactionEvent;
        }

        private void HandleTransactionEvent(object? sender, TransactionEventArgs e)
        {
            _eventService.HandleTransactionEvent(e.Transaction);
        }

        // GET: /Transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            if (_context.Transaction == null)
            {
                return NotFound();
            }
            return await _context.Transaction.ToListAsync();
        }

        // POST: /Transaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            RaiseTransactionEvent(transaction);

            return Ok();
        }

        private void RaiseTransactionEvent(Transaction transaction)
        {
            _eventService.RaiseTransactionEvent(transaction);
        }
    }
}
