namespace BankManagementSystem.Web.Controllers
{
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

        public async Task<IActionResult> Index()
        {
            var clients = await this.clientService.GetAllClientsAsync();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(CreateClientBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    await this.clientService.Create(model);

        //    return this.RedirectToAction(ActionConstants.Index, ControllerConstants.Clients);
        //}
    }
}
