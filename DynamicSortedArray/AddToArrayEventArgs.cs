using System;

namespace DynamicSortedArray
{
    public sealed class AddToArrayEventArgs<T> : EventArgs
    {
        public T AddedItem { get; }
        public string Message { get; }

        public AddToArrayEventArgs(T addedItem, string message)
        {
            Message = message;
            AddedItem = addedItem;
        }
    }
}
