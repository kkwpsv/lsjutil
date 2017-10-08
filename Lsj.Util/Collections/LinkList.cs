using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lsj.Util.Collections

{
    /// <summary>
    /// LinkList
    /// </summary>
    public class LinkList<T> : LinkListNode<T>, IList<T>
    {
        /// <summary>
        /// LinkList Enumerator
        /// </summary>
        public class LinkListEnumerator : IEnumerator<T>, IEnumerator
        {
            LinkList<T> linklist;
            LinkListNode<T> current;
            int last;
            internal LinkListEnumerator(LinkList<T> linklist)
            {
                this.linklist = linklist;
                this.last = linklist.Count - 1;
            }
            /// <summary>
            /// Dispose
            /// </summary>
            public void Dispose()
            {

            }
            /// <summary>
            /// Move To Next
            /// </summary>
            public bool MoveNext()
            {
                if (current == null)
                {
                    current = linklist;
                    return true;
                }
                else
                {
                    if (current.Next != null)
                    {
                        current = current.Next;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            /// <summary>
            /// Reset
            /// </summary>
            public void Reset()
            {
                current = null;
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    return current.Value;
                }
            }
            Object IEnumerator.Current
            {
                get
                {
                    return current.Value;
                }
            }



        }
        private LinkListNode<T> child;
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.LinkList{T}"/> class.
        /// </summary>
        public LinkList()
        {
            this.child = null;
        }
        /// <summary>
        /// Get or Set the item at the specified index
        /// Random Access will be SLOW
        /// </summary>
        /// <param name="index">Index.</param>
        public T this[int index]
        {
            get
            {
                if (this.child != null)
                {
                    int i = 0;
                    var current = this.child;
                    while (i != index)
                    {
                        if (current.Next != null)
                        {
                            current = current.Next;
                            i++;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                    return current.Value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (this.child != null)
                {
                    int i = 0;
                    var current = this.child;
                    while (i != index)
                    {
                        if (current.Next != null)
                        {
                            current = current.Next;
                            i++;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                    current.Value = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        /// <summary>
        /// Count
        /// May be SLOW
        /// </summary>
        public int Count
        {
            get
            {
                int result = 0;
                if (child != null)
                {
                    result++;
                    var current = this.child;
                    while (current.Next != null)
                    {
                        result++;
                        current = current.Next;
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly => false;
        /// <summary>
        /// Add a item
        /// May be SLOW
        /// </summary>
        /// <param name="item">item</param>
        public void Add(T item)
        {
            if (this.child != null)
            {
                var current = this.child;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new LinkListNode<T>(this)
                {
                    Value = item
                };
            }
            else
            {
                this.child = new LinkListNode<T>(this)
                {
                    Value = item
                };
            }
        }
        /// <summary>
        /// Clear the list
        /// </summary>
        public void Clear()
        {
            this.child = null;
        }
        /// <summary>
        /// If contain the specified item
        /// </summary>
        /// <param name="item">item</param>
        public bool Contains(T item)
        {
            if (this.child != null)
            {
                var current = this.child;
                while (current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Copy to
        /// </summary>
        /// <param name="array">Destination Array</param>
        /// <param name="arrayIndex">Destination Array index</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            var index = arrayIndex;
            var length = array.Length;
            var current = this.child;
            while (current != null)
            {
                if (index > length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                array[index] = current.Value;
                current = current.Next;
                index++;
            }

        }
        /// <summary>
        /// Get the enumerator
        /// </summary>
        public IEnumerator<T> GetEnumerator() => new LinkListEnumerator(this);
        /// <summary>
        /// Get the index of the item
        /// </summary>
        /// <param name="item">item</param>
        public int IndexOf(T item)
        {
            var i = 0;
            if (this.child != null)
            {
                var current = this.child;
                while (current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        return i;
                    }
                    current = current.Next;
                    i++;
                }
                return -1;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// Insert the specified item at specified index
        /// May be slow
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="item">item</param>
        public void Insert(int index, T item)
        {
            var i = 0;
            if (index == 0)
            {
                this.child = new LinkListNode<T>(this)
                {
                    Value = item,
                    Next = this.child
                };
            }
            if (this.child != null)
            {
                var current = this.child;
                while (current != null)
                {
                    if (index - 1 == i)
                    {
                        var next = current.Next;
                        current.Next = new LinkListNode<T>(this)
                        {
                            Value = item,
                            Next = next
                        };

                        return;
                    }
                    current = current.Next;
                    i++;
                }
            }
            throw new ArgumentOutOfRangeException();
        }
        /// <summary>
        /// Remove first of the specified item.
        /// </summary>
        /// <param name="item">item</param>
        public bool Remove(T item)
        {
            if (this.child != null)
            {
                var prev = this.child;
                if (prev.Value.Equals(item))
                {
                    this.child = prev.Next;
                    return true;
                }
                var current = this.child.Next;
                while (current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        prev.Next = current.Next;
                        return true;
                    }
                    prev = current;
                    current = current.Next;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Removes the item at specified index.
        /// </summary>
        /// <param name="index">index</param>
        public void RemoveAt(int index)
        {
            var i = 0;
            if (this.child != null)
            {
                if (index == 0)
                {
                    this.child = this.child.Next;
                }
                var current = this.child;
                while (current != null)
                {
                    if (index - 1 == i)
                    {
                        current.Next = current.Next.Next;
                        return;
                    }
                    current = current.Next;
                    i++;
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        IEnumerator IEnumerable.GetEnumerator() => new LinkListEnumerator(this);
    }
    /// <summary>
    /// LinkList node.
    /// </summary>
    public class LinkListNode<T>
    {
        internal LinkListNode()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Collections.LinkList{T}"/> class.
        /// </summary>
        /// <param name="list">List.</param>
        public LinkListNode(LinkList<T> list)
        {
            this.List = list ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// The LinkList
        /// </summary>
        public LinkList<T> List
        {
            get;
            private set;
        }
        /// <summary>
        /// The Value
        /// </summary>
        public T Value
        {
            get;
            set;
        }
        /// <summary>
        /// Next Node
        /// </summary>
        public LinkListNode<T> Next
        {
            get;
            internal set;
        }



    }
}
