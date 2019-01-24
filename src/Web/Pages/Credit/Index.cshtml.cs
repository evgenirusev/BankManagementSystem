namespace BankManagementSystem.Web.Pages.Credit
{
    using BankManagementSystem.Common.Helpers;
    using BankManagementSystem.Common.ViewModels.Credit;
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
        private ICreditService creditService;
        private UserManager<Client> userManager;

        public IndexModel(ICreditService creditService, UserManager<Client> userManager)
        {
            this.creditService = creditService;
            this.userManager = userManager;
        }

        public List<CreditViewModel> ViewModels { get; set; }

        public async Task OnGetAsync()
        {
            await this.InitViewModels();
        }

        private async Task InitViewModels()
        {
            string id = (await ClientHelper
                .GetUserByUsername(this.User.Identity.Name, this.userManager)).Id;
            this.ViewModels = (await this.creditService.GetAllCreditsById(id)).ToList();
        }
    }
}