using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicSortedArray
{
    class ArrayEnumerator<T> : IEnumerator<T>
    {
        Node<T> _head;
        bool _flag;

        public ArrayEnumerator(Node<T> headNode)
        {
            _head = headNode;
        }

        public T Current
        {
            get
            {
                if (_flag)
                    throw new InvalidOperationException();

                var temp = _head.Value;
                _head = _head.NextNode;
                return temp;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (_head != null)
                return true;
            _flag = true;
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
