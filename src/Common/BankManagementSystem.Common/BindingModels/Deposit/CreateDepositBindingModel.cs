namespace BankManagementSystem.Common.BindingModels.Deposit
{
    using System.ComponentModel.DataAnnotations;

    public class CreateDepositBindingModel
    {
        public int Id { get; set; }

        // TODO: Develop constants
        [Required]
        [Range(10.00, 10000.00)]
        public decimal Amount { get; set; }

        [Required]
        public int CreditCardId { get; set; }
    }
}
