namespace BankManagementSystem.Web.Controllers
{
    using BankManagementSystem.Common.BindingModels.Card;
    using BankManagementSystem.Common.Constants;
    using BankManagementSystem.Services.DataServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Authorize]
    public class CreditCardsController : Controller
    {
        private readonly ICreditCardService creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            this.creditCardService = creditCardService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCreditCardBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.creditCardService.Create(model, this.User.Identity.Name);
            
            return this.RedirectToAction(ActionConstants.Index, ControllerConstants.CreditCards);
        }

        public IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}
