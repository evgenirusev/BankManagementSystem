namespace BankManagementSystem.Services.DataServices.Implementations
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using BankManagementSystem.Common.BindingModels.Credit;
    using BankManagementSystem.Common.Helpers;
    using BankManagementSystem.Data.Common.Repositories;
    using BankManagementSystem.Models;
    using Microsoft.AspNetCore.Identity;

    public class CreditService : BaseService<Credit>, ICreditService
    {
        public CreditService(IRepository<Credit> repository,
            IMapper mapper, UserManager<Client> userManager) 
            : base(repository, mapper, userManager)
        {
        }

        public async Task Create(CreateCreditBindingModel model, string username)
        {
            Credit credit = new Credit();
            credit.Client = await ClientHelper.GetUserByUsername(username, this.UserManager);
            credit.FinancialResourceAmount = model.FinancialResourceAmount;
            credit.PercentInterest = model.PercentInterest;
            credit.PaymentPeriod = DateTime.Now.AddYears(model.PaymentPeriodYears);

            await this.Repository.AddAsync(credit);
            await this.Repository.SaveChangesAsync();
        }
    }
}
