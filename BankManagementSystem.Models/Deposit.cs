using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem.Models
{
    class Deposit
    {
        public int Id { get; set; }

        public int DateTime { get; set; }

        public decimal Amount { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
