using HuaMoney.Interfaces;
using HuaMoney.Models;
using HuaMoney.ViewModels.Transaction;
using Microsoft.EntityFrameworkCore;

namespace HuaMoney.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly HuaMoneyContext _context;

        public TransactionService(HuaMoneyContext context) { 
            _context = context;
        }

        public async Task<List<Transaction>> Find()
        {
            var items = await _context.Transactions
                                        .AsNoTracking()
                                        .ToListAsync();

            return items;
        }

        public async Task<int> Create(Transaction transaction)
        {
            _context.Add(transaction);

            return await _context.SaveChangesAsync();
        }
    }
}
