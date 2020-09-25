using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicSrotedArray
{
    public sealed class DynamicSortedArray<T> : IEnumerable<T>, ICollection<T> where T : IComparable
    {
        #region Basic DynamicSortedArray fields, prop, constructors
        Node<T> head;
        IEnumerator<T> Enumerator;
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
            Enumerator = enumerator;
        }
        #endregion

        
        /// <summary>
        /// Adds a single element in collection
        /// </summary>
        public void Add(T item)
        {
            int isGreater = 0;                                  //if item == null its value is 0
            int? comparerCheck = head?.Value?.CompareTo(item);  
            if (comparerCheck != null && item != null)
                 isGreater = comparerCheck <= 0 ? 1 : -1;       //if element in head is greater returns -1

            if (isGreater == 1)
            {
                Node<T> temp = head;

                while (temp.NextNode != null)
                {
                    if (temp?.NextNode?.Value?.CompareTo(item) > 0 == true) break;
                    else temp = temp.NextNode;
                }

                if (temp.NextNode != null)
                {
                    Node<T> nextNode = temp.NextNode;
                    temp.NextNode = new Node<T>(item);

                    temp.NextNode.NextNode = nextNode;
                    Added?.Invoke(this, new AddToArrayEventArgs<T>(item, $"{item} added"));
                }
                else
                {
                    temp.NextNode = new Node<T>(item);
                    Added?.Invoke(this, new AddToArrayEventArgs<T>(item, $"{item} added in tail"));
                }

            }
            else if (isGreater == -1)
            {
                Node<T> temp = new Node<T>(item);
                temp.NextNode = head;

                head = temp;
                Added?.Invoke(this, new AddToArrayEventArgs<T>(item, $"{item} added in head"));
            }
            else 
            {
                if (head == null)
                {
                    head = new Node<T>(item);
                    Added?.Invoke(this, new AddToArrayEventArgs<T>(item, $"{item} added first element"));
                }
                else throw new ArgumentNullException();
            }

            Count++;
        }
        
        /// <summary>
        /// Adds a set of elements in collection
        /// </summary>
        /// <param name="arr"></param>
        public void Add(params T[] arr)
        {
            foreach (T item in arr)
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
                    Node<T> temp = head;

                    for (int i = 0; i < index; i++)
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
            head = null;
        }

        /// <summary>
        /// Check that <c>item</c> contains in collection
        /// </summary>
        /// <param name="item">Element to check</param>
        /// <returns>True if collection contains <c>item</c>, else it returns false.</returns>
        public bool Contains(T item)
        {
            Node<T> temp = head;

            while (temp != null)
            {
                if (temp.Value.CompareTo(item) == 0) return true;
                else temp = temp.NextNode;
            }

            return false;
        }

        /// <summary>
        /// Remowe <c>item</c> from collection
        /// </summary>
        /// <param name="item">Element to remove</param>
        /// <returns>True if <c>item</c> was removed, else it returns false.</returns>
        public bool Remove(T item)
        {
            Node<T> temp = new Node<T>();
            temp.NextNode = head;

            while (temp.NextNode != null)
            {
                if (temp.NextNode.Value.CompareTo(item) == 0)
                {
                    if (temp.NextNode == head) head = head.NextNode;
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
        /// Copy element from <c>array</c> begining from <c>arrayIndex</c>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new DynamicSrotedArrayException("Sorted dynamic array does not support this method because it makes no sense for this type.");
        }

        /// <summary>
        /// Get <c>IEnumerator<T></c> of class
        /// </summary>
        /// <returns>Returns <c>IEnumerator<T></c> of class</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Enumerator != null ? Enumerator : new ArrayEnumerator<T>(head);
        }

        /// <summary>
        /// Get <c>IEnumerator<T></c> of class
        /// </summary>
        /// <returns>Returns <c>IEnumerator<T></c> of class</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
