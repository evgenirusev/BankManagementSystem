using BankManagementSystem.Common.CustomeAttributes;
using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.Common.BindingModels.Withdraw
{
    public class WithdrawBindingModel
    {
        public decimal CurrentClientBalance { get; set; }

        [Required]
        [Range(10.00, 10000.00)]
        [AmountLessThan("CurrentClientBalance", ErrorMessage = "Invalid Withdraw Amount")]
        public decimal WithdrawAmount { get; set; }
    }
}
