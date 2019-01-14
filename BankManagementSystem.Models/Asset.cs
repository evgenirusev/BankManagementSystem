using BankManagementSystem.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem.Models
{
    class Asset
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public AssetCategories AssetCategory { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
