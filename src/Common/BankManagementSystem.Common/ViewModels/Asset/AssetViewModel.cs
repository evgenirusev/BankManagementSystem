namespace BankManagementSystem.Common.ViewModels.Asset
{
    using BankManagementSystem.Models.Enum;
    using System;

    public class AssetViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal MonetaryValue { get; set; }

        public DateTime CreatedAt { get; set; }

        public AssetCategories AssetCategory { get; set; }
    }
}
