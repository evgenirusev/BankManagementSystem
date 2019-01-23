namespace BankManagementSystem.Web.Pages.Transaction
{
    using BankManagementSystem.Common.Helpers;
    using BankManagementSystem.Common.ViewModels.Transaction;
    using BankManagementSystem.Models;
    using BankManagementSystem.Services.DataServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize]
    public class IndexModel : PageModel
    {
        ITransactionService transactionService;
        UserManager<Client> userManager;

        public IndexModel(ITransactionService transactionService, UserManager<Client> userManager)
        {
            this.transactionService = transactionService;
            this.userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            await InitViewModels();
        }

        public List<TransactionViewModel> TransactionViewModels { get; set; }

        private async Task InitViewModels()
        {
            string id = (await ClientHelper
                .GetUserByUsername(this.User.Identity.Name, this.userManager)).Id;
            this.TransactionViewModels = (await transactionService.GetAllTransactionsById(id)).ToList();
        }
    }
}
