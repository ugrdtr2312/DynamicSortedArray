using System;

namespace DynamicSrotedArray
{ 
    [Serializable]
    public class DynamicSrotedArrayException : ArgumentException
    {
        public DynamicSrotedArrayException() { }
        public DynamicSrotedArrayException(string message) : base(message) { }
        public DynamicSrotedArrayException(string message, Exception inner) : base(message, inner) { }
        protected DynamicSrotedArrayException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
