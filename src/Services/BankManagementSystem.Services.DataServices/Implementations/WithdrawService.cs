using AutoMapper;
using BankManagementSystem.Common;
using BankManagementSystem.Data.Common.Repositories;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using System;   
using System.Threading.Tasks;

namespace BankManagementSystem.Services.DataServices.Implementations
{
    public class WithdrawService : BaseService<Client>, IWithdrawService
    {
        public WithdrawService(IRepository<Client> repository, 
            IMapper mapper, UserManager<Client> userManager) 
            : base(repository, mapper, userManager)
        {
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

            await this.Repository.SaveChangesAsync();
        }
    }
}
