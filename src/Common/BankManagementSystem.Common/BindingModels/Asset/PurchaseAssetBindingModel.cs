using BankManagementSystem.Common.CustomeAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankManagementSystem.Common.BindingModels.Asset
{
    public class PurchaseAssetBindingModel
    {
        [Required]
        public int AssetId { get; set; }

        [Required]
        public decimal CurrentClientBalance { get; set; }

        [Required]
        [AmountLessThan("CurrentClientBalance", ErrorMessage = "Inadequate funds, consider making a deposit.")]
        public decimal AssetPrice { get; set; }
    }
}
