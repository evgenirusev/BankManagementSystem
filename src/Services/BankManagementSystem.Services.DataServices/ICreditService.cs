using BankManagementSystem.Common.BindingModels.Credit;
using BankManagementSystem.Common.ViewModels.Credit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.DataServices
{
    public interface ICreditService
    {
        Task Create(CreateCreditBindingModel model, string username);

        Task<IEnumerable<CreditViewModel>> GetAllCreditsById(string clientId);
    }
}
