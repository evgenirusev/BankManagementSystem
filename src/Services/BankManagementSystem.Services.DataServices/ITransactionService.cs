namespace BankManagementSystem.Services.DataServices
{
    using BankManagementSystem.Common.ViewModels.Transaction;
    using BankManagementSystem.Models.Enum;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITransactionService
    {
        Task CreateTransactionAsync(string clientId, decimal price, TransactionType type);

        Task<IEnumerable<TransactionViewModel>> GetAllTransactionsById(string id);
    }
}
