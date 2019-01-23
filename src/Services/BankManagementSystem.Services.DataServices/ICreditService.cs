using BankManagementSystem.Common.BindingModels.Credit;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.DataServices
{
    public interface ICreditService
    {
        Task Create(CreateCreditBindingModel model, string username);
    }
}
