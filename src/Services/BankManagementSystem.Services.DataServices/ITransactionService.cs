namespace BankManagementSystem.Services.DataServices
{
    using BankManagementSystem.Models.Enum;
    using System.Threading.Tasks;

    public interface ITransactionService
    {
        Task CreateTransactionAsync(string clientId, decimal price, TransactionType type);
    }
}
