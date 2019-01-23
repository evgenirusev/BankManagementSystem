using BankManagementSystem.Common.BindingModels.CreditCard;
using BankManagementSystem.Common.ViewModels.CreditCard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.DataServices
{
    public interface ICreditCardService
    {
        Task<int> Create(CreateCreditCardBindingModel model, string username);

        Task<IEnumerable<CreditCardViewModel>> GetAllCreditCardsAsync(string id);
    }
}
