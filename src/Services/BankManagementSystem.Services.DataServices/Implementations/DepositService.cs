using System;
using System.Threading.Tasks;
using AutoMapper;
using BankManagementSystem.Common;
using BankManagementSystem.Common.BindingModels.Deposit;
using BankManagementSystem.Data.Common.Repositories;
using BankManagementSystem.Models;
using BankManagementSystem.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace BankManagementSystem.Services.DataServices.Implementations
{
    public class DepositService : BaseService<Deposit>, IDepositService
    {
        ITransactionService transactionService;

        public DepositService(IRepository<Deposit> repository,
            IMapper mapper,
            UserManager<Client> userManager,
            ITransactionService transactionService)
            : base(repository, mapper, userManager)
        {
            this.transactionService = transactionService;
        }

        public async Task CreateDepositAsync(CreateDepositBindingModel model, string username)
        {
            Validator.ThrowIfNull(model);
            Validator.ThrowIfNull(username);

            if (model.Amount < 0)
            {
                throw new ArgumentNullException();
            }

            var client = await this.GetUserByNamedAsync(username);

            var deposit = this.Mapper.Map<Deposit>(model);
            deposit.ClientId = client.Id;
            deposit.CreatedAt = DateTime.Now;

            client.Balance += model.Amount;

            await this.transactionService.CreateTransactionAsync(client.Id, 
                model.Amount,
                TransactionType.Deposit);

            await this.Repository.AddAsync(deposit);
            await this.Repository.SaveChangesAsync();
        }
    }
}
