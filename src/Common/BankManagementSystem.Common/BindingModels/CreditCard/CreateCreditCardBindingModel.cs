namespace BankManagementSystem.Common.BindingModels.CreditCard
{
    using BankManagementSystem.Common.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateCreditCardBindingModel
    {
        [Required]
        [StringLength(16, MinimumLength = 12)]
        [Display(Name = AttributeDisplayNameConstants.CardNumber)]
        public string Number { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 3)]
        [Display(Name = AttributeDisplayNameConstants.CVV)]
        public string CVV { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }
    }
}
