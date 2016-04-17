using System;

namespace PigeonsLibrairy.Exceptions
{
    /// <summary>
    /// Exception pour les classe Controller <see cref="Controller"/>
    /// </summary>
    public class ControllerException : Exception
    {
        /// <summary>
        /// Constructeur sans paramètre
        /// </summary>
        public ControllerException() : base() { }

        /// <summary>
        /// Constructeur avec message
        /// </summary>
        public ControllerException(string message) : base(message) { }

        /// <summary>
        /// Constructeur avec message et inner exception
        /// </summary>
        public ControllerException(string message, Exception inner) : base(message, inner) { }
    }
}