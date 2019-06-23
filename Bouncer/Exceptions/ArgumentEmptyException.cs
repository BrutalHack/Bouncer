using System;

namespace BrutalHack.Bouncer.Exceptions
{
    public class ArgumentEmptyException : ArgumentException
    {
        public ArgumentEmptyException(string paramName) : base("Value must not be empty.", paramName)
        {
        }
        
        public ArgumentEmptyException() : base("Value must not be empty.")
        {
        }
    }
}