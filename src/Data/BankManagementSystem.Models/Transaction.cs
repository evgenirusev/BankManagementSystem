namespace BankManagementSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int DateTime { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
