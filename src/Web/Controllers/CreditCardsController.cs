namespace BankManagementSystem.Web.Controllers
{
    using BankManagementSystem.Common.BindingModels.CreditCard;
    using BankManagementSystem.Common.Constants;
    using BankManagementSystem.Common.Helpers;
    using BankManagementSystem.Models;
    using BankManagementSystem.Services.DataServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize]
    public class CreditCardsController : Controller
    {
        private ICreditCardService creditCardService;
        private UserManager<Client> userManager;

        public CreditCardsController(ICreditCardService creditCardService, UserManager<Client> userManager)
        {
            this.creditCardService = creditCardService;
            this.userManager = userManager;
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

        public async Task<IActionResult> Index()
        {
            string clientId = await ClientHelper.GetUserIdAsync(this.User.Identity.Name, this.userManager);
            var creditCards = await this.creditCardService.GetAllCreditCardsAsync(clientId);
            return View(creditCards);
        }
    }
}
