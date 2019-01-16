namespace BankManagementSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using BankManagementSystem.Common.BindingModels.Client;
    using BankManagementSystem.Common.Constants;
    using BankManagementSystem.Services;

    public class ClientsController : Controller
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateClientBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.clientService.Create(model.Name, model.Email, model.BirthDate, model.Balance);

            return this.RedirectToAction(ActionConstants.Index, ControllerConstants.Clients);
        }

    }
}
