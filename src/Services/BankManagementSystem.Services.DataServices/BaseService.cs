namespace BankManagementSystem.Services.DataServices
{
    using AutoMapper;
    using BankManagementSystem.Common;
    using BankManagementSystem.Common.Exceptions;
    using BankManagementSystem.Data.Common.Repositories;
    using BankManagementSystem.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public abstract class BaseService<T> where T : class
    {
        protected BaseService(IRepository<T> repository, 
            IMapper mapper,
            UserManager<Client> userManager)
        {
            this.Mapper = mapper;
            this.Repository = repository;
            this.UserManager = userManager;
        }

        protected IMapper Mapper { get; private set; }

        protected IRepository<T> Repository { get; private set; }

        protected UserManager<Client> UserManager { get; private set; }

        protected async Task<Client> GetUserByNamedAsync(string name)
        {
            var client = await this.UserManager.FindByNameAsync(name);

            Validator.ThrowIfNull(client, new InvalidUserException());

            return client;
        }
    }
}
