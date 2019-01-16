namespace BankManagementSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Client
    {
        public Client()
        {
            this.Assets = new List<Asset>();
            this.Credits = new List<Credit>();
            this.CreditCards = new List<CreditCard>();
            this.Deposits = new List<Deposit>();
            this.Transactions = new List<Transaction>();
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Asset> Assets { get; set; }

        public ICollection<Credit> Credits { get; set; }

        public ICollection<CreditCard> CreditCards { get; set; }

        public ICollection<Deposit> Deposits { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
