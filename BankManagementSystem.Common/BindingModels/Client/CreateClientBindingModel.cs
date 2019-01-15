namespace BankManagementSystem.Common.BindingModels.Client
{
    using BankManagementSystem.Common.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    class CreateClientBindingModel
    {
        [Required]
        [StringLength(ModelLenghtConstants.NameMaxLength, MinimumLength = ModelLenghtConstants.NameMinLength)]
        [Display(Name = AttributeDisplayNameConstants.Name)]
        public string Name { get; set; }

        [Required]
        [StringLength(ModelLenghtConstants.NameMaxLength, MinimumLength = ModelLenghtConstants.NameMinLength)]
        [Display(Name = AttributeDisplayNameConstants.Email)]
        public string Email { get; set; }

        [Required]
        [StringLength(ModelLenghtConstants.NameMaxLength, MinimumLength = ModelLenghtConstants.NameMinLength)]
        [Display(Name = AttributeDisplayNameConstants.BirthDate)]
        public DateTime BirthDate { get; set; }
        
        [Display(Name = AttributeDisplayNameConstants.Balance)]
        public decimal Balance { get; set; }
    }
}
