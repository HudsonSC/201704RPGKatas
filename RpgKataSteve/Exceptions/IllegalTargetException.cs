using System;

namespace RpgKata
{
    public class IllegalTargetException : Exception
    {
        public IllegalTargetException(string message) : base(message)
        {            
        }
    }
}
