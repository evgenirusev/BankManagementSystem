using BankManagementSystem.Common.BindingModels.Card;
using BankManagementSystem.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.DataServices
{
    public interface ICreditCardService
    {
        Task<int> Create(CreateCreditCardBindingModel model, string username);

        Task<IEnumerable<CreditCardViewModel>> GetAllCreditCardsAsync();
    }
}
