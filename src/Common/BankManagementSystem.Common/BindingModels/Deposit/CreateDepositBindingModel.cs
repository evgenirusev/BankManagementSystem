namespace BankManagementSystem.Common.BindingModels.Deposit
{
    public class CreateDepositBindingModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int CreditCardId { get; set; }
    }
}
