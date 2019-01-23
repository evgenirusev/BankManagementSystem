namespace BankManagementSystem.Common.ViewModels.Transaction
{
    using BankManagementSystem.Models.Enum;
    using System;

    public class TransactionViewModel
    {
        public DateTime CreatedAt { get; set; }

        public decimal Price { get; set; }

        public TransactionType Type { get; set; }
    }
}
