using System;

namespace PigeonsLibrairy.Exceptions
{
    /// <summary>
    /// Exception pour les classe Service <see cref="Service"/>
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// Constructeur sans paramètre
        /// </summary>
        public ServiceException() : base() { }

        /// <summary>
        /// Constructeur avec message
        /// </summary>
        public ServiceException(string message) : base(message) { }

        /// <summary>
        /// Constructeur avec message et une inner exception
        /// </summary>
        public ServiceException(string message, Exception inner) : base(message, inner) { }
    }
}