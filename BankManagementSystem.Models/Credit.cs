using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem.Models
{
    class Credit
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public decimal PercentInterest { get; set; }
    }
}
