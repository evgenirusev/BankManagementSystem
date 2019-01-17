namespace BankManagementSystem.Models
{
    public class Deposit
    {
        public int Id { get; set; }

        public int DateTime { get; set; }

        public decimal Amount { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
