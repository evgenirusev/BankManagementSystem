using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem.Models
{
    class CreditCard
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
