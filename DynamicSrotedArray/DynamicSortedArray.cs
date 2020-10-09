using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicSortedArray
{
    public sealed class DynamicSortedArray<T> : ICollection<T> where T : IComparable
    {
        #region Basic DynamicSortedArray fields, prop, constructors
        Node<T> _head;
        readonly IEnumerator<T> _enumerator;
        public event EventHandler<AddToArrayEventArgs<T>> Added;
        public event EventHandler<RemoveFromArrayEventArgs<T>> Removed;
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;
        public bool IsReadOnly => false;

        public DynamicSortedArray()
        {
            Count = 0;
        }

        public DynamicSortedArray(IEnumerator<T> enumerator) 
        {
            _enumerator = enumerator;
        }
        #endregion

        
        /// <summary>
        /// Adds a single element in collection
        /// </summary>
        public void Add(T item)
        {
            var isGreater = 0;                                  //if item == null its value is 0
            var comparerCheck = _head?.Value.CompareTo(item);  
            if (comparerCheck != null && item != null)
                 isGreater = comparerCheck <= 0 ? 1 : -1;       //if element in head is greater returns -1

            switch (isGreater)
            {
                case 1:
                {
                    var temp = _head;

                    while (temp.NextNode != null)
                    {
                        if (temp.NextNode.Value.CompareTo(item) > 0) break;
                        
                        temp = temp.NextNode;
                    }

                    if (temp.NextNode != null)
                    {
                        var nextNode = temp.NextNode;
                        temp.NextNode = new Node<T>(item) {NextNode = nextNode};

                        Added?.Invoke(this, new AddToArrayEventArgs<T>(item, $"{item} added"));
                    }
                    else
                    {
                        if (temp != null) temp.NextNode = new Node<T>(item);
                        Added?.Invoke(this, new AddToArrayEventArgs<T>(item, $"{item} added in tail"));
                    }

                    break;
                }
                case -1:
                {
                    var temp = new Node<T>(item) {NextNode = _head};

                    _head = temp;
                    Added?.Invoke(this, new AddToArrayEventArgs<T>(item, $"{item} added in head"));
                    break;
                }
                default:
                {
                    if (_head == null)
                    {
                        _head = new Node<T>(item);
                        Added?.Invoke(this, new AddToArrayEventArgs<T>(item, $"{item} added first element"));
                    }
                    else throw new ArgumentNullException();

                    break;
                }
            }

            Count++;
        }
        
        /// <summary>
        /// Adds a set of elements in collection
        /// </summary>
        /// <param name="arr"></param>
        public void Add(params T[] arr)
        {
            foreach (var item in arr)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index">An int precision number.</param>
        /// <returns> The value under this <c>index</c>. </returns>
        /// <exception cref="System.IndexOutOfRangeException"> 
        /// Thrown when <c>index</c> is out of the range. </exception>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Count - 1)
                    throw new IndexOutOfRangeException();
                else
                {
                    var temp = _head;
                    for (var i = 0; i < index; i++)
                    {
                        temp = temp.NextNode;
                    }

                    return temp.Value;
                }
            }
        }

        /// <summary>
        /// Remove all elements from collection
        /// </summary>
        public void Clear()
        {
            Count = 0;
            _head = null;
        }

        /// <summary>
        /// Check that <c>item</c> contains in collection
        /// </summary>
        /// <param name="item">Element to check</param>
        /// <returns>True if collection contains <c>item</c>, else it returns false.</returns>
        public bool Contains(T item)
        {
            var temp = _head;

            while (temp != null)
            {
                if (temp.Value.CompareTo(item) == 0) return true;
                else temp = temp.NextNode;
            }

            return false;
        }

        /// <summary>
        /// Remove <c>item</c> from collection
        /// </summary>
        /// <param name="item">Element to remove</param>
        /// <returns>True if <c>item</c> was removed, else it returns false.</returns>
        public bool Remove(T item)
        {
            var temp = new Node<T> {NextNode = _head};

            while (temp.NextNode != null)
            {
                if (temp.NextNode.Value.CompareTo(item) == 0)
                {
                    if (temp.NextNode == _head) _head = _head.NextNode;
                    else temp.NextNode = temp.NextNode.NextNode;
                    Count--;
                    
                    Removed?.Invoke(this, new RemoveFromArrayEventArgs<T>(item, $"{item} was removed"));
                    return true;
                }
                temp = temp.NextNode;
            }

            return false;
        }

        /// <summary>
        /// Copy element from <c>array</c> beginning from <c>arrayIndex</c>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new DynamicSortedArrayException("Sorted dynamic array does not support this method because it makes no sense for this type.");
        }

        /// <summary>
        /// Get <c>IEnumerator &lt;T&gt;</c> of class
        /// </summary>
        /// <returns>Returns <c>IEnumerator&lt;T&gt;</c> of class</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _enumerator ?? new ArrayEnumerator<T>(_head);
        }

        /// <summary>
        /// Get <c>IEnumerator&lt;T&gt;</c> of class
        /// </summary>
        /// <returns>Returns <c>IEnumerator&lt;T&gt;</c> of class</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
