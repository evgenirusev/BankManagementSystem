namespace BankManagementSystem.Services
{
    using System;

    public interface IClientService
    {
        void Create(string name, string email, DateTime dateTime, decimal balance);
    }
}
