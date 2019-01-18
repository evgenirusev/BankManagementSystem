namespace BankManagementSystem.Common.Exceptions
{
    public class InvalidUserException : BankManagementSystemBaseException
    {
        private const string message = "User not found!";

        public InvalidUserException() : base(message)
        {
        }
    }
}
