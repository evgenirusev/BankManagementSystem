﻿namespace BankManagementSystem.Services
{
    using BankManagementSystem.Common.BindingModels.Client;
    using BankManagementSystem.Common.ViewModels.Client;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClientService
    {
        Task<string> Create(CreateClientBindingModel model);

        Task<IEnumerable<AllClientsViewModel>> GetAllClientsAsync();

        Task<IEnumerable<AllClientNamesViewModel>> GetAllClientNamesAsync();
    }
}