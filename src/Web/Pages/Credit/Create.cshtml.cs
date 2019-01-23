namespace BankManagementSystem.Web.Pages.Credit
{
    using BankManagementSystem.Common.BindingModels.Credit;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Threading.Tasks;

    [Authorize]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateCreditBindingModel Input { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            // TODO: Persist
            return null;
        }
    }
}
