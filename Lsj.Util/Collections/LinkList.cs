﻿using System;
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
    public class LinkList<T> : LinkListNode<T>, IList<T>
    {
        /// <summary>
        /// 顺序表Enumerator
        /// </summary>
        public class LinkListEnumerator : IEnumerator<T>, IEnumerator
        {
            LinkList<T> linklist;
            int position;
            int last;
            internal LinkListEnumerator(LinkList<T> linklist)
            {
                this.linklist = linklist;
                this.position = -1;
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
                if (position < last)
                {
                    position++;
                    return true;
                }
                return false;
            }
            /// <summary>
            /// 
            /// </summary>
            public void Reset()
            {
                position = -1;
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    return linklist[position];
                }
            }
            Object IEnumerator.Current
            {
                get
                {
                    return linklist[position];
                }
            }



        }
        private LinkListNode<T> child;
        /// <summary>
        /// 初始化一个<see cref="LinkList{T}"/>实例
        /// </summary>
        public LinkList()
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
        public IEnumerator<T> GetEnumerator() => new LinkListEnumerator(this);
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
                this.child = new LinkListNode<T>
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
        /// 删除指定元素的第一个匹配
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
        /// 删除指定位置的元素
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            var i = 0;
            if (index == 0)
            {
                this.child = this.child.Next;
            }
            if (this.child != null)
            {
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
    /// 链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkListNode<T>
    {
        internal LinkListNode()
        {
            throw new InvalidOperationException();
        }
        /// <summary>
        /// 初始化一个<see cref="LinkListNode{T}"/>实例
        /// </summary>
        /// <param name="list"></param>
        public LinkListNode(LinkList<T> list)
        {
            this.List = list ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// 该节点所在的链表
        /// </summary>
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
        /// <summary>
        /// 下一个节点
        /// </summary>
        public LinkListNode<T> Next
        {
            get;
            internal set;
        }



    }
}
