namespace BankManagementSystem.Models
{
    using BankManagementSystem.Models.Enum;
    using System;

    public class Asset
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal MonetaryValue { get; set; }

        public DateTime CreatedAt { get; set; }

        public AssetCategories AssetCategory { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
