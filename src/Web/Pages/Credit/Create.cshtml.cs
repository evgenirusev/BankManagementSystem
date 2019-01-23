namespace BankManagementSystem.Web.Pages.Credit
{
    using BankManagementSystem.Common.BindingModels.Credit;
    using BankManagementSystem.Common.Constants;
    using BankManagementSystem.Services.DataServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Threading.Tasks;

    [Authorize]
    public class CreateModel : PageModel
    {
        private ICreditService creditService;

        public CreateModel(ICreditService creditService)
        {
            this.creditService = creditService;
        }

        [BindProperty]
        public CreateCreditBindingModel Input { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            await this.creditService.Create(Input, this.User.Identity.Name);

            return this.RedirectToPage(PageConstants.CreditSuccess);
        }
    }
}
