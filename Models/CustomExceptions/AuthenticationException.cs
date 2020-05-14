using System;

namespace Burak.Boilerplate.Models.CustomExceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
    }
}