namespace BankManagementSystem.Services
{
    using BankManagementSystem.Common.BindingModels.Client;
    using System;
    using System.Threading.Tasks;

    public interface IClientService
    {
        Task<int> Create(CreateClientBindingModel model);
    }
}
