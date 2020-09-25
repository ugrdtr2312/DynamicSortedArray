using System;

namespace DynamicSrotedArray
{
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> NextNode { get; set; }

        public Node()
        {

        }

        public Node(T data)
        {
            Value = data;
        }
    }
}
