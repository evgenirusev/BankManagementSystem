namespace BankManagementSystem.Common.ViewModels.Asset
{
    using BankManagementSystem.Common.BindingModels.Asset;
    using Microsoft.AspNetCore.Identity;

    public class PurchaseAssetDto
    {
        public decimal CurrentClientBalance { get; set; }

        public AssetViewModel ViewModel { get; set; }

        public PurchaseAssetBindingModel BindingModel { get; set; }
    }
}
