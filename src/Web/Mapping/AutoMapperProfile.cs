namespace BankManagementSystem.Web.Mapping
{
    using AutoMapper;
    using BankManagementSystem.Common.BindingModels.Client;
    using BankManagementSystem.Models;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ConfigureClients();
        }

        private void ConfigureClients()
        {
            this.CreateMap <CreateClientBindingModel, Client>();
        }
    }
}
