using System;

namespace STensor.Exceptions
{
    public class ShapeMismatchException : Exception
    {
        public ShapeMismatchException() : base()
        {
        }

        public ShapeMismatchException(string? messege) : base(messege)
        {
        }

        public ShapeMismatchException(string? messege, Exception? innerException) : base(messege, innerException)
        {
        }
    }
}
