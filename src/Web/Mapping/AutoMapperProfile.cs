namespace BankManagementSystem.Web.Mapping
{
    using AutoMapper;
    using BankManagementSystem.Common.BindingModels.Client;
    using BankManagementSystem.Models;
    using BankManagementSystem.Web.ViewModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ConfigureClients();
        }

        private void ConfigureClients()
        {
            this.CreateMap<CreateClientBindingModel, Client>();
            this.CreateMap<Client, AllClientsViewModel>();
        }
    }
}
