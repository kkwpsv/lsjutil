using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// 链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkList<T> : LinkListNode<T>,IList<T>
    {
        private LinkListNode<T> child;

        public LinkList()
        {
            this.child = null;
        }

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
                    while(i!=index)
                    {
                        if(current.Next!=null)
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

        public int Count
        {
            get
            {
                int result = 0;
                if(child)
                return result;
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkListNode<T>
    {
        internal LinkListNode(LinkList<T> list)
        {
            this.List = list;
        }
        public LinkList<T> List
        {
            get;
            private set;
        }
        /// <summary>
        /// 值
        /// </summary>
        public T Value
        {
            get;
            set;
        }
        public LinkListNode<T> Next
        {
            get;
            privat set;
        }



    }
}
