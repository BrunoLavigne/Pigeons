using System;

namespace PigeonsLibrairy.Exceptions
{
    public class ControllerException : Exception
    {
        public ControllerException() { }
        public ControllerException(string message) : base(message) { }
        public ControllerException(string message, Exception inner) : base(message, inner) { }
    }
}
