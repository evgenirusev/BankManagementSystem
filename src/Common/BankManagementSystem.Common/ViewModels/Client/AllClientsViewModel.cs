namespace BankManagementSystem.Common.ViewModels.Client
{
    using System;

    public class AllClientsViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public decimal Balance { get; set; }
    }
}
