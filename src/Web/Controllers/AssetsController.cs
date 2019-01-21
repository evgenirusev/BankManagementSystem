using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementSystem.Common.BindingModels.Asset;
using BankManagementSystem.Common.Constants;
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

        public async Task<IActionResult> Purchase()
        {
            throw new NotImplementedException();
        }
    }
}