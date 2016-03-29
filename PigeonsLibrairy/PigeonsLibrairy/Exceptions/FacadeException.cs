using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Exceptions
{
    public class FacadeException : Exception
    {
        public FacadeException() { }
        public FacadeException(string message) : base(message) { }
        public FacadeException(string message, Exception inner) : base(message, inner) { }
    }
}
