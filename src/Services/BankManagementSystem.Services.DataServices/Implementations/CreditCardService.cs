using System.Threading.Tasks;
using AutoMapper;
using BankManagementSystem.Common;
using BankManagementSystem.Common.BindingModels.Card;
using BankManagementSystem.Data.Common.Repositories;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace BankManagementSystem.Services.DataServices.Implementations
{
    class CreditCardService : BaseService<CreditCard>, ICreditCardService
    {
        public CreditCardService(IRepository<CreditCard> repository, 
            IMapper mapper, 
            UserManager<Client> userManager) 
            : base(repository, mapper, userManager)
        {
        }

        public async Task<int> Create(CreateCreditCardBindingModel model, string username)
        {
            Validator.ThrowIfNull(model);

            var client = await this.GetUserByNamedAsync(username);

            var creditCard = this.Mapper.Map<CreditCard>(model);
            creditCard.ClientId = client.Id;

            await this.Repository.AddAsync(creditCard);
            await this.Repository.SaveChangesAsync();

            return creditCard.Id;
        }
    }
}
