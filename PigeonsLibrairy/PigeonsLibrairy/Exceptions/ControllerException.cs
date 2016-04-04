using System;

namespace PigeonsLibrairy.Exceptions
{
    /// <summary>
    /// Exception pour les classe Controller <see cref="Controller"/>
    /// </summary>
    public class ControllerException : Exception
    {
        public ControllerException() : base() { }
        public ControllerException(string message) : base(message) { }
        public ControllerException(string message, Exception inner) : base(message, inner) { }
    }
}
