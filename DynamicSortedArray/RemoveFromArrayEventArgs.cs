using System;

namespace DynamicSortedArray
{
    public sealed class RemoveFromArrayEventArgs<T> : EventArgs
    {

        public T RemovedItem { get; }
        public string Message { get; }

        public RemoveFromArrayEventArgs(T removedItem, string message)
        {
            Message = message;
            RemovedItem = removedItem;
        }
    }
}
