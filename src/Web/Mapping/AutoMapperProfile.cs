namespace BankManagementSystem.Web.Mapping
{
    using AutoMapper;
    using BankManagementSystem.Common.BindingModels.Asset;
    using BankManagementSystem.Common.BindingModels.CreditCard;
    using BankManagementSystem.Common.BindingModels.Deposit;
    using BankManagementSystem.Common.ViewModels.Asset;
    using BankManagementSystem.Common.ViewModels.Credit;
    using BankManagementSystem.Common.ViewModels.CreditCard;
    using BankManagementSystem.Common.ViewModels.Transaction;
    using BankManagementSystem.Models;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ConfigureCreditCards();
            ConfigureDeposits();
            ConfigureAssets();
            ConfigureTransactions();
            ConfigureCredits();
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

        private void ConfigureAssets()
        {
            this.CreateMap<CreateAssetBindingModel, Asset>();
            this.CreateMap<Asset, AssetViewModel>();
            this.CreateMap<AssetViewModel, Asset>();
        }

        private void ConfigureTransactions()
        {
            this.CreateMap<Transaction, TransactionViewModel>();
        }

        private void ConfigureCredits()
        {
            this.CreateMap<Credit, CreditViewModel>();
        }
    }
}
