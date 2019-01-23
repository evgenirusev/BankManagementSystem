using System;

namespace BankManagementSystem.Models
{
    public class Credit
    {
        public int Id { get; set; }

        public decimal FinancialResourceAmount { get; set; }

        public decimal PercentInterest { get; set; }

        public DateTime PaymentPeriod { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
