using HuaMoney.Interfaces;
using HuaMoney.Models;
using Microsoft.AspNetCore.Mvc;

namespace HuaMoney.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult New()
        {
            var vm = new Transaction();
            vm.Recipient = "Hi";

            return View("Edit", vm);
        }

        public async Task<int> Save(Transaction transaction)
        {
            return await _transactionService.Create(transaction);
        }
    }
}
