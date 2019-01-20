using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementSystem.Common.BindingModels.Asset;
using BankManagementSystem.Common.Constants;
using BankManagementSystem.Services.DataServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Web.Controllers
{
    [Authorize]
    public class AssetsController : Controller
    {
        private IAssetService assetService;

        public AssetsController(IAssetService assetService)
        {
            this.assetService = assetService;
        }

        public IActionResult Index()
        {
            return View();
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
    }
}