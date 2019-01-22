using BankManagementSystem.Common.CustomeAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankManagementSystem.Common.BindingModels.Asset
{
    public class PurchaseAssetBindingModel
    {
        public int AssetId { get; set; }

        public decimal CurrentClientBalance { get; set; }

        [Required]
        [AmountLessThan("CurrentClientBalance", ErrorMessage = "Inadequate funds, consider making a deposit.")]
        public decimal AssetPrice { get; set; }
    }
}
