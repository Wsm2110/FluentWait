using System;
using System.Runtime.Serialization;

namespace FluentWait
{
    [Serializable]
    internal class TestFailedException : Exception
    {
        public TestFailedException()
        {
        }

        public TestFailedException(string message) : base(message)
        {
        }

        public TestFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TestFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}