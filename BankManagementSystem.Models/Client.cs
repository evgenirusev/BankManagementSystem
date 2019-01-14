using System.Collections.Generic;

namespace BankManagementSystem.Models
{
    class Client
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

        public decimal Balance { get; set; }

        public ICollection<Asset> Assets { get; set; }

        public ICollection<Credit> Credits { get; set; }

        public ICollection<CreditCard> CreditCards { get; set; }

        public ICollection<Deposit> Deposits { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
