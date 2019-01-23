using BankManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BankManagementSystem.Common.Helpers
{
    public class ClientHelper
    {
        public static async Task<Client> GetUserByUsername(string username,
            UserManager<Client> userManager)
        {
            return (await userManager.FindByNameAsync(username));
        }

        public static async Task<string> GetUserIdAsync(string username, 
            UserManager<Client> userManager)
        {
            return (await userManager.FindByNameAsync(username)).Id;
        }

        public static async Task<decimal> GetUserBalance(string username,
            UserManager<Client> userManager)
        {
            return (await userManager.FindByNameAsync(username)).Balance;
        }
    }
}
