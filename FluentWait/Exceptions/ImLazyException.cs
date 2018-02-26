using System;
using System.Runtime.Serialization;

namespace FluentWait
{
    [Serializable]
    internal class ImLazyException : Exception
    {
        public ImLazyException()
        {
        }

        public ImLazyException(string message) : base(message)
        {
        }

        public ImLazyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImLazyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}