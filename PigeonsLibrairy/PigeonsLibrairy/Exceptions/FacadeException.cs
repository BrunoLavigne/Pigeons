using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Exceptions
{
    /// <summary>
    /// Exception pour les classe Facade <see cref="Facade"/>
    /// </summary>
    public class FacadeException : Exception
    {
        /// <summary>
        /// Constructeur sans paramètre
        /// </summary>
        public FacadeException() : base() { }

        /// <summary>
        /// Constructeur avec message
        /// </summary>
        public FacadeException(string message) : base(message) { }

        /// <summary>
        /// Constructeur avec message et inner exception
        /// </summary>
        public FacadeException(string message, Exception inner) : base(message, inner) { }
    }
}