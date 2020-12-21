using System;
using System.Runtime.Serialization;

namespace Library.Files
{
    public class InvalidFileFormatException : Exception
    {
        public InvalidFileFormatException()
        {
        }

        public InvalidFileFormatException(string message) : base(message)
        {
        }

        public InvalidFileFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidFileFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}