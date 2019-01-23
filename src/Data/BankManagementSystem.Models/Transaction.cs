using BankManagementSystem.Models.Enum;
using System;

namespace BankManagementSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Price { get; set; }

        public TransactionType Type { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
