using System;

namespace BankManagementSystem.Common.ViewModels.Credit
{
    public class CreditViewModel
    {
        public decimal FinancialResourceAmount { get; set; }

        public decimal PercentInterest { get; set; }

        public DateTime PaymentPeriod { get; set; }
    }
}
