using System;
using System.Threading.Tasks;
using AutoMapper;
using BankManagementSystem.Common;
using BankManagementSystem.Common.BindingModels.Deposit;
using BankManagementSystem.Data.Common.Repositories;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace BankManagementSystem.Services.DataServices.Implementations
{
    public class DepositService : BaseService<Deposit>, IDepositService
    {
        public DepositService(IRepository<Deposit> repository,
            IMapper mapper,
            UserManager<Client> userManager)
            : base(repository, mapper, userManager)
        {
        }

        public async Task CreateDepositAsync(CreateDepositBindingModel model, string username)
        {
            Validator.ThrowIfNull(model);

            var client = await this.GetUserByNamedAsync(username);

            var deposit = this.Mapper.Map<Deposit>(model);
            deposit.ClientId = client.Id;
            deposit.CreatedAt = DateTime.Now;

            await this.Repository.AddAsync(deposit);
            await this.Repository.SaveChangesAsync();
        }
    }
}
