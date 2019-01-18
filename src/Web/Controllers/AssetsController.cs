namespace BankManagementSystem.Web.Controllers
{
    using AutoMapper;
    using BankManagementSystem.Common.Constants;
    using BankManagementSystem.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AssetsController : Controller
    {
        private readonly IClientService clientService;

        public AssetsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task<IActionResult> Create()
        {
            var clients = await this.clientService.GetAllClientNamesAsync();
            return View();
        }
    }
}
