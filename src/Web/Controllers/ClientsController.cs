namespace BankManagementSystem.Web.Controllers
{
    using AutoMapper;
    using BankManagementSystem.Common.BindingModels.Client;
    using BankManagementSystem.Common.Constants;
    using BankManagementSystem.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ClientsController : Controller
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public IActionResult Index()
        {
            var clients = this.clientService.GetAllClientsAsync();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.clientService.Create(model);

            return this.RedirectToAction(ActionConstants.Index, ControllerConstants.Clients);
        }
    }
}
