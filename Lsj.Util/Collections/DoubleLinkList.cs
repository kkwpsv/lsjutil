using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// 双向链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleLinkList<T> : DoubleLinkListNode<T>, IList<T>
    {
        /// <summary>
        /// 链表Enumerator
        /// </summary>
        public class DoubleLinkListEnumerator : IEnumerator<T>, IEnumerator
        {
            DoubleLinkList<T> linklist;
            DoubleLinkListNode<T> current;
            int last;
            internal DoubleLinkListEnumerator(DoubleLinkList<T> linklist)
            {
                this.linklist = linklist;
                this.last = linklist.Count - 1;
            }
            /// <summary>
            /// 
            /// </summary>
            public void Dispose()
            {

            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
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
            /// 
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
        private DoubleLinkListNode<T> child;
        /// <summary>
        /// 初始化一个<see cref="LinkList{T}"/>实例
        /// </summary>
        public DoubleLinkList()
        {
            this.child = null;
        }
        /// <summary>
        /// 获取或设定指定索引处的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
        /// 链表中的元素数
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
        /// 是否只读
        /// </summary>
        public bool IsReadOnly => false;
        /// <summary>
        /// 向链表最后添加一个元素
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (this.child != null)
            {
                var current = this.child;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new DoubleLinkListNode<T>(this)
                {
                    Value = item,
                    Prev = current
                };
            }
            else
            {
                this.child = new DoubleLinkListNode<T>(this)
                {
                    Value = item,
                    Prev = this
                };
            }
        }
        /// <summary>
        /// 清空链表
        /// </summary>
        public void Clear()
        {
            this.child = null;
        }
        /// <summary>
        /// 返回链表中是否包含该元素
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
        /// 将链表中的元素复制到一个数组中
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
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
        /// 返回枚举器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => new DoubleLinkListEnumerator(this);
        /// <summary>
        /// 返回指定元素的索引
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
        /// 在指定位置插入一个元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            var i = 0;
            if (index == 0)
            {
                this.child = new DoubleLinkListNode<T>(this)
                {
                    Value = item,
                    Next = this.child
                };
                if (this.child.Next != null)
                {
                    this.child.Next.Prev = this.child;
                }
            }
            if (this.child != null)
            {
                var current = this.child;
                while (current != null)
                {
                    if (index - 1 == i)
                    {
                        var next = current.Next;
                        current.Next = new DoubleLinkListNode<T>(this)
                        {
                            Value = item,
                            Next = next,
                            Prev = current
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
        /// 删除指定元素的第一个匹配
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            if (this.child != null)
            {
                if (this.child.Value.Equals(item))
                {
                    this.child = this.child.Next;
                    this.child.Prev = this;
                    return true;
                }
                var current = this.child.Next;
                while (current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
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
        /// 删除指定位置的元素
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            var i = 0;
            if (this.child != null)
            {
                if (index == 0)
                {
                    this.child = this.child.Next;
                    if (this.child != null)
                    {
                        this.child.Prev = this;
                    }
                }
                var current = this.child;
                while (current != null)
                {
                    if (index - 1 == i)
                    {
                        current.Next = current.Next.Next;
                        current.Next.Prev = current;
                        return;
                    }
                    current = current.Next;
                    i++;
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        IEnumerator IEnumerable.GetEnumerator() => new DoubleLinkListEnumerator(this);
    }
    /// <summary>
    /// 双向链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleLinkListNode<T>
    {
        internal DoubleLinkListNode()
        {
        }
        /// <summary>
        /// 初始化一个<see cref="DoubleLinkListNode{T}"/>实例
        /// </summary>
        /// <param name="list"></param>
        public DoubleLinkListNode(DoubleLinkList<T> list)
        {
            this.List = list ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// 该节点所在的链表
        /// </summary>
        public DoubleLinkList<T> List
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
        /// <summary>
        /// 下一个节点
        /// </summary>
        public DoubleLinkListNode<T> Next
        {
            get;
            internal set;
        }
        /// <summary>
        /// 上一个节点
        /// </summary>
        public DoubleLinkListNode<T> Prev
        {
            get;
            internal set;
        }



    }
}
