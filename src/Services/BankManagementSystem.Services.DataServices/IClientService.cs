namespace BankManagementSystem.Services
{
    using System;
    using System.Threading.Tasks;

    public interface IClientService
    {
        Task<int> Create(string name, string email, DateTime dateTime, decimal balance);
    }
}
