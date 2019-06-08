using System;

namespace BrutalHack.Contracts.Exceptions
{
    public class ArgumentNotEmptyException : ArgumentException
    {
        public ArgumentNotEmptyException() : base("Collection must be empty.")
        {
        }
    }
}