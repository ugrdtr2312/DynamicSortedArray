using System;

namespace DynamicSortedArray
{ 
    [Serializable]
    public class DynamicSortedArrayException : ArgumentException
    {
        public DynamicSortedArrayException() { }
        public DynamicSortedArrayException(string message) : base(message) { }
        public DynamicSortedArrayException(string message, Exception inner) : base(message, inner) { }
        protected DynamicSortedArrayException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
