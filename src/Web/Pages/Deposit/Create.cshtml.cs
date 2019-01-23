namespace BankManagementSystem.Web.Pages.Deposit
{
    using BankManagementSystem.Common.BindingModels.Deposit;
    using BankManagementSystem.Common.Constants;
    using BankManagementSystem.Common.ViewModels.CreditCard;
    using BankManagementSystem.Models;
    using BankManagementSystem.Services.DataServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize]
    public class CreateModel : PageModel
    {
        private IDepositService depositService;
        private ICreditCardService creditCardService;
        private UserManager<Client> userManager;

        public CreateModel(IDepositService depositService,
            ICreditCardService creditCardService,
            UserManager<Client> userManager)
        {
            this.depositService = depositService;
            this.creditCardService = creditCardService;
            this.userManager = userManager;
            this.CreditCardItems = new List<SelectListItem>();
        }

        [BindProperty]
        public CreateDepositBindingModel Input { get; set; }

        public List<SelectListItem> CreditCardItems { get; set; }

        public async Task OnGetAsync()
        {
            Client user = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            var cardsFromDb = (await this.creditCardService.GetAllCreditCardsAsync(user.Id));

            foreach (CreditCardViewModel creditCard in cardsFromDb)
            {
                this.CreditCardItems.Add(
                    new SelectListItem {
                        Value = creditCard.Id.ToString(),
                        Text = String.Format("Card Number: {0}", creditCard.Number)
                    }
                    );
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            await this.depositService.CreateDepositAsync(this.Input, this.User.Identity.Name);

            return this.RedirectToPage(PageConstants.DepositSuccess);
        }
    }
}
