namespace BankManagementSystem.Models
{
    using System;

    public class CreditCard
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string CVV { get; set; }

        public DateTime DateRegistered { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
