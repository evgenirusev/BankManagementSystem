using System.Threading.Tasks;

namespace BankManagementSystem.Services.DataServices
{
    public interface IWithdrawService
    {
        Task WithdrawFundsAsync(decimal amount, string username);
    }
}
