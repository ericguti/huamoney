using HuaMoney.Models;
using Microsoft.AspNetCore.Mvc;

namespace HuaMoney.Interfaces
{
    public interface ITransactionService
    {
        Task<List<Transaction>> Find();
        Task<int> Create(Transaction transaction);
    }
}
