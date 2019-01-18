namespace BankManagementSystem.Common.Exceptions
{
    using System;

    public abstract class BankManagementSystemBaseException : Exception
    {
        protected BankManagementSystemBaseException(string message)
            : base(message)
        {
        }
    }
}