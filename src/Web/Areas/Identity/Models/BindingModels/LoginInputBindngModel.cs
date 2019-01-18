namespace BankManagementSystem.Web.Areas.Identity.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginInputBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
