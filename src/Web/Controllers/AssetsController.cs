using BankManagementSystem.Models.Enum;
using System.Threading.Tasks;
using BankManagementSystem.Common.BindingModels.Asset;
using BankManagementSystem.Common.Constants;
using BankManagementSystem.Common.Helpers;
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

        public AssetsController(IAssetService assetService,
            UserManager<Client> userManager)
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

        [HttpGet]
        public async Task<IActionResult> Purchase(int id, PurchaseAssetDto DTO)
        {
            await this.PopulateDTOAsync(DTO, id);
            return View(DTO);
        }

        [HttpPost("Assets/Purchase/{id:int}")]
        public async Task<IActionResult> PurchaseConfirm(int id, PurchaseAssetDto DTO)
        {
            if (!this.ModelState.IsValid)
            {
                await this.PopulateDTOAsync(DTO, id);
                return this.View(ViewNameConstants.Purchase, DTO);
            }

            await this.assetService.PurchaseAssetAsync(DTO.BindingModel, this.User.Identity.Name);

            string clientId = await ClientHelper.
                GetUserIdAsync(this.User.Identity.Name, this.userManager);
            
            return this.RedirectToAction(ActionConstants.Success, ControllerConstants.Assets);
        }

        public IActionResult Success()
        {
            return View();
        }

        private async Task<PurchaseAssetDto> PopulateDTOAsync(PurchaseAssetDto DTO, int id)
        {
            var viewModel = await this.assetService.FindById(id);
            DTO.ViewModel = viewModel;
            DTO.CurrentClientBalance = 
                await ClientHelper.GetUserBalance(this.User.Identity.Name, this.userManager);
            return DTO;
        }
    }
}