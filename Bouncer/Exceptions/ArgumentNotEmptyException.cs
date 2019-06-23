using System;

namespace BrutalHack.Bouncer.Exceptions
{
    public class ArgumentNotEmptyException : ArgumentException
    {
        public ArgumentNotEmptyException() : base("Collection must be empty.")
        {
        }
    }
}