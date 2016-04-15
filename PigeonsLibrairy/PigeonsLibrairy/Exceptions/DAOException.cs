using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Exceptions
{
    /// <summary>
    /// Exception pour les classe DAO <see cref="DAO"/>
    /// </summary>
    public class DAOException : Exception
    {
        /// <summary>
        /// Constructeur sans paramètre
        /// </summary>
        public DAOException() : base() { }

        /// <summary>
        /// Constructeur avec un message
        /// </summary>
        public DAOException(string message) : base(message) { }

        /// <summary>
        /// Constructeur avec un message et une exception
        /// </summary>
        public DAOException(string message, Exception inner) : base(message, inner) { }
    }
}