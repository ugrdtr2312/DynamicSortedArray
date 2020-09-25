using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicSrotedArray
{
    public sealed class RemoveFromArrayEventArgs<T> : EventArgs
    {

        public T RemovedItem { get; private set; }
        public string Message { get; private set; }

        public RemoveFromArrayEventArgs(T removedItem, string message)
        {
            Message = message;
            RemovedItem = removedItem;
        }
    }
}
