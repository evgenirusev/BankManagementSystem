namespace BankManagementSystem.Common.BindingModels.Credit
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCreditBindingModel
    {
        [Range(10, 50000)]
        public decimal FinancialResourceAmount { get; set; }

        [Range(0, 100)]
        public decimal PercentInterest { get; set; }

        [Range(0, 10)]
        public int PaymentPeriodYears { get; set; }
    }
}
