using System;
using System.Collections.Generic;
using System.Collections;

namespace DynamicSrotedArray
{
    class ArrayEnumerator<T> : IEnumerator<T>
    {
        Node<T> head;
        bool flag = false;

        public ArrayEnumerator(Node<T> headNode)
        {
            head = headNode;
        }

        public T Current
        {
            get
            {
                if (flag)
                    throw new InvalidOperationException();

                T temp = head.Value;
                head = head.NextNode;
                return temp;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (head != null)
                return true;
            else
            {
                flag = true;
                return false;
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
