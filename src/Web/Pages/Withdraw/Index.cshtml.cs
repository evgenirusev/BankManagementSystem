namespace BankManagementSystem.Web.Pages.Withdraw
{
    using BankManagementSystem.Common.BindingModels.Withdraw;
    using BankManagementSystem.Common.Constants;
    using BankManagementSystem.Services.DataServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Threading.Tasks;

    [Authorize]
    public class IndexModel : PageModel
    {
        private IWithdrawService withdrawService;

        public IndexModel(IWithdrawService withdrawService)
        {
            this.withdrawService = withdrawService;
        }

        [BindProperty]
        public WithdrawBindingModel Input{ get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            await this.withdrawService.WithdrawFundsAsync(this.Input.WithdrawAmount, this.User.Identity.Name);
            return this.RedirectToPage(PageConstants.WithdrawSuccess);
        }
    }
}