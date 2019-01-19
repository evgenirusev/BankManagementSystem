namespace BankManagementSystem.Models
{
    using System;

    public class Deposit
    {
        public int Id { get; set; }
        
        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
