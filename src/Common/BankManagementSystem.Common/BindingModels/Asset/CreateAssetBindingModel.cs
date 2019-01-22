using BankManagementSystem.Common.Constants;
using BankManagementSystem.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.Common.BindingModels.Asset
{
    public class CreateAssetBindingModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = AttributeDisplayNameConstants.AssetName)]
        public string Name { get; set; }

        [Required]
        [Range(10.00, 50000)]
        public decimal MonetaryValue { get; set; }

        [Required]
        public AssetCategories AssetCategory { get; set; }
    }
}
