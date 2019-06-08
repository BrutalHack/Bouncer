using System;

namespace BrutalHack.Contracts.Exceptions
{
    public class ArgumentEmptyException : ArgumentException
    {
        public ArgumentEmptyException() : base("Collection must not be empty.")
        {
        }
    }
}