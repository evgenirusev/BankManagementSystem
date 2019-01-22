using BankManagementSystem.Common.BindingModels.Asset;
using BankManagementSystem.Common.ViewModels.Asset;
using BankManagementSystem.Common.ViewModels.CreditCard;
using BankManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.DataServices
{
    public interface IAssetService
    {
        Task<int> Create(CreateAssetBindingModel model, string username);

        Task<IEnumerable<AssetViewModel>> GetAllAssetsAsync();

        Task<AssetViewModel> FindById(int id);

        Task PurchaseAssetAsync(PurchaseAssetBindingModel model, string username);
    }
}
