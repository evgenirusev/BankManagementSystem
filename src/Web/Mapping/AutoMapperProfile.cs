namespace BankManagementSystem.Web.Mapping
{
    using AutoMapper;
    using BankManagementSystem.Common.BindingModels.CreditCard;
    using BankManagementSystem.Common.BindingModels.Deposit;
    using BankManagementSystem.Common.ViewModels.CreditCard;
    using BankManagementSystem.Models;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ConfigureCreditCards();
            ConfigureDeposits();
        }

        private void ConfigureCreditCards()
        {
            this.CreateMap<CreateCreditCardBindingModel, CreditCard>();
            this.CreateMap<CreditCard, CreditCardViewModel>();
        }

        private void ConfigureDeposits()
        {
            this.CreateMap<CreateDepositBindingModel, Deposit>();
        }
    }
}
