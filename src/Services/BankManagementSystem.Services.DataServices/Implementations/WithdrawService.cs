using AutoMapper;
using BankManagementSystem.Common;
using BankManagementSystem.Data.Common.Repositories;
using BankManagementSystem.Models;
using BankManagementSystem.Models.Enum;
using Microsoft.AspNetCore.Identity;
using System;   
using System.Threading.Tasks;

namespace BankManagementSystem.Services.DataServices.Implementations
{
    public class WithdrawService : BaseService<Client>, IWithdrawService
    {
        ITransactionService transactionService;

        public WithdrawService(IRepository<Client> repository, 
            IMapper mapper, UserManager<Client> userManager,
            ITransactionService transactionService) 
            : base(repository, mapper, userManager)
        {
            this.transactionService = transactionService;
        }

        public async Task WithdrawFundsAsync(decimal amount, string username)
        {
            Validator.ThrowIfNull(username);

            if (amount <= 0)
            {
                throw new ArgumentNullException();
            }

            var client = await this.GetUserByNamedAsync(username);
            
            client.Balance -= amount;

            await this.transactionService
                .CreateTransactionAsync(client.Id, amount, TransactionType.Withdraw);

            await this.Repository.SaveChangesAsync();
        }
    }
}
