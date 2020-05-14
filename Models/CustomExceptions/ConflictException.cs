using System;

namespace Burak.Boilerplate.Models.CustomExceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
    }
}