namespace BankManagementSystem.Services.Implementations
{
    using BankManagementSystem.Data.Common.Repositories;
    using BankManagementSystem.Models;
    using BankManagementSystem.Web.Data;
    using System;
    using System.Threading.Tasks;

    public class ClientService : IClientService
    {
        private readonly IRepository<Client> cliensRepository;

        public ClientService(IRepository<Client> cliensRepository)
        {
            this.cliensRepository = cliensRepository;
        }

        public async Task<int> Create(string name, string email, DateTime birthDate, decimal balance)
        {
            var client = new Client()
            {
                Name = name,
                Email = email,
                BirthDate = birthDate,
                Balance = balance
            };

            await this.cliensRepository.AddAsync(client);
            await this.cliensRepository.SaveChangesAsync();

            return client.Id;
        }
    }
}
