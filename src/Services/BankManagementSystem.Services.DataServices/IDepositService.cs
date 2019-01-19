using BankManagementSystem.Common.BindingModels.Deposit;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.DataServices
{
    public interface IDepositService
    {
        Task CreateDepositAsync(CreateDepositBindingModel model, string username);
    }
}
