namespace BankManagementSystem.Services.Implementations
{
    using BankManagementSystem.Models;
    using BankManagementSystem.Web.Data;
    using System;

    public class ClientService : IClientService
    {
        private readonly BankManagementSystemDbContext db;

        public ClientService(BankManagementSystemDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string email, DateTime birthDate, decimal balance)
        {
            var client = new Client()
            {
                Name = name,
                Email = email,
                BirthDate = birthDate,
                Balance = balance
            };

            this.db.Clients.Add(client);
            this.db.SaveChanges();
        }
    }
}
