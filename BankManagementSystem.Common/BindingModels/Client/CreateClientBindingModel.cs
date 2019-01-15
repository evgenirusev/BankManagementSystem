namespace BankManagementSystem.Common.BindingModels.Client
{
    using BankManagementSystem.Common.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateClientBindingModel
    {
        [Required]
        [StringLength(ModelLenghtConstants.NameMaxLength, MinimumLength = ModelLenghtConstants.NameMinLength)]
        [Display(Name = AttributeDisplayNameConstants.Name)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(ModelLenghtConstants.NameMaxLength, MinimumLength = ModelLenghtConstants.NameMinLength)]
        [Display(Name = AttributeDisplayNameConstants.Email)]
        public string Email { get; set; }

        [Required]
        [Display(Name = AttributeDisplayNameConstants.BirthDate)]
        public DateTime BirthDate { get; set; }
        
        [Display(Name = AttributeDisplayNameConstants.Balance)]
        [Range(0, Double.MaxValue)]
        public decimal Balance { get; set; }
    }
}
