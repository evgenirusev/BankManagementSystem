namespace BankManagementSystem.Models
{
    public class Deposit
    {
        public int Id { get; set; }

        public int DateTime { get; set; }

        public decimal Amount { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
