namespace BankManagementSystem.Services
{
    using BankManagementSystem.Common.BindingModels.Client;
    using BankManagementSystem.Web.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClientService
    {
        Task<int> Create(CreateClientBindingModel model);

        Task<IEnumerable<AllClientsViewModel>> GetAllClientsAsync();
    }
}
