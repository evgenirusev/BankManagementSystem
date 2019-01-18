namespace BankManagementSystem.Web.Mapping
{
    using AutoMapper;
    using BankManagementSystem.Common.BindingModels.Card;
    using BankManagementSystem.Models;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ConfigureCreditCards();
        }

        private void ConfigureCreditCards()
        {
            this.CreateMap<CreateCreditCardBindingModel, CreditCard>();
        }
    }
}
