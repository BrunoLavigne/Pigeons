using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Exceptions
{
    public class DAOException : Exception
    {
        public DAOException() : base() { }
        public DAOException(string message) : base(message) { }
        public DAOException(string message, Exception inner) : base(message, inner) { }
    }
}
