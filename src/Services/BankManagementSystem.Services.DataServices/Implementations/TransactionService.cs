using System;
using System.Threading.Tasks;
using BankManagementSystem.Models;
using AutoMapper;
using BankManagementSystem.Data.Common.Repositories;
using BankManagementSystem.Models.Enum;
using Microsoft.AspNetCore.Identity;
using BankManagementSystem.Common.ViewModels.Transaction;
using System.Collections.Generic;
using System.Linq;

namespace BankManagementSystem.Services.DataServices.Implementations
{
    public class TransactionService : BaseService<Transaction>, ITransactionService
    {
        public TransactionService(IRepository<Transaction> repository,
            IMapper mapper,
            UserManager<Client> userManager)
            : base(repository, mapper, userManager)
        {
        }

        public async Task CreateTransactionAsync(string clientId, decimal price, TransactionType type)
        {
            var transaction = new Transaction();
            transaction.ClientId = clientId;
            transaction.Price = price;
            transaction.Type = type;
            transaction.CreatedAt = DateTime.Now;

            await this.Repository.AddAsync(transaction);
            await this.Repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TransactionViewModel>> GetAllTransactionsById(string id)
        {
            return this.Mapper.Map<IEnumerable<TransactionViewModel>>(this.Repository
                .All().Where(x => x.ClientId == id));
        }
    }
}
