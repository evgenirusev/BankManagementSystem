namespace BankManagementSystem.Common
{
    using System;

    public static class Validator
    {
        public static void ThrowIfNull(object obj, Exception exception = null)
        {
            exception = exception ?? new ArgumentNullException(nameof(obj));
            if (obj == null)
            {
                throw exception;
            }
        }
    }
}
