using BankManagementSystem.Common.BindingModels.Asset;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.DataServices
{
    public interface IAssetService
    {
        Task<int> Create(CreateAssetBindingModel model, string username);
    }
}
