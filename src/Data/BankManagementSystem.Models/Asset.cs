namespace BankManagementSystem.Models
{
    using BankManagementSystem.Models.Enum;

    public class Asset
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public AssetCategories AssetCategory { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
