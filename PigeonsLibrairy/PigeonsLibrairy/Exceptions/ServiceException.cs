using System;

namespace PigeonsLibrairy.Exceptions
{
    /// <summary>
    /// Exception pour les classe Service <see cref="Service"/>
    /// </summary>
    public class ServiceException : Exception
    {
        public ServiceException() : base() { }
        public ServiceException(string message) : base(message) { }
        public ServiceException(string message, Exception inner) : base(message, inner) { }
    }
}
