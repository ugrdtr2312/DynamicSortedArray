using System;

namespace DynamicSrotedArray
{
    public sealed class AddToArrayEventArgs<T> : EventArgs
    {
        public T AddedItem { get; private set; }
        public string Message { get; private set; }

        public AddToArrayEventArgs(T addedItem, string message)
        {
            Message = message;
            AddedItem = addedItem;
        }
    }
}
