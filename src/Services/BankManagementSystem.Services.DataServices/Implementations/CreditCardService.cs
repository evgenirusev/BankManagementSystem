namespace BankManagementSystem.Services.DataServices.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BankManagementSystem.Common;
    using BankManagementSystem.Common.BindingModels.CreditCard;
    using BankManagementSystem.Common.ViewModels.CreditCard;
    using BankManagementSystem.Data.Common.Repositories;
    using BankManagementSystem.Models;
    using Microsoft.AspNetCore.Identity;

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
            creditCard.DateRegistered = DateTime.Now;

            await this.Repository.AddAsync(creditCard);
            await this.Repository.SaveChangesAsync();

            return creditCard.Id;
        }

        public async Task<IEnumerable<CreditCardViewModel>> GetAllCreditCardsAsync(string id)
        {
            return this.Mapper.Map<IEnumerable<CreditCardViewModel>>(
                this.Repository.All().Where(x => x.ClientId == id));
        }
    }
}
