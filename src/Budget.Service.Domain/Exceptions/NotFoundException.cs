using System;

namespace Budget.Service.Domain.Exceptions
{
    /// <summary>
    /// Исключение поиска
    /// </summary>
    public class NotFoundException: Exception
    {
        public NotFoundException() : base()
        { }
        public NotFoundException(string message) : base(message)
        { }
        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
