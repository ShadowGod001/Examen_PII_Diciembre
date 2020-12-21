
using System;
using System.Runtime.Serialization;

namespace Library.Characters
{
    [Serializable]
    public class RemoveItemException : Exception
    {
        public RemoveItemException()
        {
        }

        public RemoveItemException(string message) : base(message)
        {
        }

        public RemoveItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RemoveItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}