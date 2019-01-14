using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem.Models
{
    class Transaction
    {
        public int Id { get; set; }

        public int DateTime { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
