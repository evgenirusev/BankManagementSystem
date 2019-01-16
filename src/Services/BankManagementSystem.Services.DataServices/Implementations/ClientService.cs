namespace BankManagementSystem.Services.Implementations
{
    using AutoMapper;
    using BankManagementSystem.Common.BindingModels.Client;
    using BankManagementSystem.Data.Common.Repositories;
    using BankManagementSystem.Models;
    using BankManagementSystem.Services.DataServices;
    using System.Threading.Tasks;

    public class ClientService : BaseService<Client>, IClientService
    {
        public ClientService(IRepository<Client> repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }

        public async Task<int> Create(CreateClientBindingModel model)
        {
            var client = this.Mapper.Map<Client>(model);

            await this.Repository.AddAsync(client);
            await this.Repository.SaveChangesAsync();

            return client.Id;
        }
    }
}
