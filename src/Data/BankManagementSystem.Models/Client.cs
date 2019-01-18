namespace BankManagementSystem.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class Client : IdentityUser
    {
        public Client()
        {
            this.Assets = new List<Asset>();
            this.Credits = new List<Credit>();
            this.CreditCards = new List<CreditCard>();
            this.Deposits = new List<Deposit>();
            this.Transactions = new List<Transaction>();
        }

        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<Asset> Assets { get; set; }

        public ICollection<Credit> Credits { get; set; }

        public ICollection<CreditCard> CreditCards { get; set; }

        public ICollection<Deposit> Deposits { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
