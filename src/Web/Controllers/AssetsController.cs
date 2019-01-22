using System;
using System.Threading.Tasks;
using BankManagementSystem.Common.BindingModels.Asset;
using BankManagementSystem.Common.Constants;
using BankManagementSystem.Common.ViewModels.Asset;
using BankManagementSystem.Models;
using BankManagementSystem.Services.DataServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Web.Controllers
{
    [Authorize]
    public class AssetsController : Controller
    {
        private IAssetService assetService;
        UserManager<Client> userManager;

        public AssetsController(IAssetService assetService, UserManager<Client> userManager)
        {
            this.assetService = assetService;
            this.userManager = userManager;
        }

        [Authorize(Roles = RolesConstants.Administrator)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAssetBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.assetService.Create(model, this.User.Identity.Name);

            return this.RedirectToAction(ActionConstants.Index, ControllerConstants.Assets);
        }

        public async Task<IActionResult> Index()
        {
            var assets = (await this.assetService.GetAllAssetsAsync());
            return View(assets);
        }
        
        public async Task<IActionResult> Purchase(int id, PurchaseAssetDto dto)
        {
            var viewModel = await this.assetService.FindById(id);
            dto.ViewModel = viewModel;
            dto.CurrentClientBalance = 
                (await this.userManager.FindByNameAsync(this.User.Identity.Name)).Balance;
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> PurchaseConfirm(int id, PurchaseAssetDto dto)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View(dto);
            }

            await this.assetService.PurchaseAssetAsync(dto.BindingModel, this.User.Identity.Name);
            // TODO: Impelent me :)

            return this.RedirectToAction(ActionConstants.Success, ControllerConstants.Assets);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}