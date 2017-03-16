using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// 顺序表
    /// </summary>
    public class SeqList<T> : IList<T>
    {
        /// <summary>
        /// 顺序表Enumerator
        /// </summary>
        public class SeqListEnumerator : IEnumerator<T>, IEnumerator
        {
            SeqList<T> seqlist;
            int position;
            internal SeqListEnumerator(SeqList<T> seqlist)
            {
                this.seqlist = seqlist;
                this.position = -1;
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
                if (position < seqlist.last)
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
                    return seqlist.elem[position];
                }
            }
            Object IEnumerator.Current
            {
                get
                {
                    return seqlist.elem[position];
                }
            }



        }



        T[] elem;
        int last;
        int maxsize = 10;
        /// <summary>
        /// 初始化一个<see cref="SeqList{T}"/>实例
        /// </summary>
        public SeqList()
        {
            this.elem = new T[maxsize];
            last = -1;
        }
        /// <summary>
        /// 添加元素到顺序表中
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            ChekIfNeedEnlargeAndDoEnlarge();
            elem[++last] = value;
        }
        /// <summary>
        /// 清空顺序表
        /// </summary>
        public void Clear()
        {
            this.elem = new T[maxsize];
            last = -1;
        }
        /// <summary>
        /// 返回顺序表是否包含该元素
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            for (int i = 0; i <= last; i++)
            {
                if (elem[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 将顺序表中的元素复制到数组中
        /// </summary>
        /// <param name="value">目标数组</param>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        public void CopyTo(T[] value, int offset) => Buffer.BlockCopy(elem, 0, value, offset, last + 1);
        /// <summary>
        /// 顺序表中的元素数
        /// </summary>
        /// <returns></returns>
        public int Count => last + 1;
        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly => false;
        /// <summary>
        /// 从顺序表中删除指定元素的第一个匹配项
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            for (int i = 0; i <= last; i++)
            {
                if (elem[i].Equals(value))
                {
                    Buffer.BlockCopy(elem, i + 1, elem, i, last - i);
                    last--;
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 返回指定元素的索引
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(T value)
        {
            for (int i = 0; i <= last; i++)
            {
                if (elem[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 在指定位置插入元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, T value)
        {
            if (index == last + 1)
            {
                Add(value);
                return;
            }
            if (index < 0 || index > last)
            {
                throw new ArgumentOutOfRangeException();
            }
            ChekIfNeedEnlargeAndDoEnlarge();
            Buffer.BlockCopy(elem, index, elem, index + 1, last - index + 1);
            elem[index] = value;
            last++;
        }
        /// <summary>
        /// 删除指定位置的元素
        /// </summary>
        /// <param name="i"></param>
        public void RemoveAt(int i)
        {
            if (i < 0 || i > last)
            {
                throw new ArgumentOutOfRangeException();
            }
            Buffer.BlockCopy(elem, i + 1, elem, i, last - i);
            last--;
        }
        /// <summary>
        /// 获取或指定索引处的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > last)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return elem[index];
            }
            set
            {
                if (index < 0 || index > last)
                {
                    throw new ArgumentOutOfRangeException();
                }
                elem[index] = value;
            }

        }



        /// <summary>
        /// 返回枚举器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => new SeqListEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => new SeqListEnumerator(this);

        /// <summary>
        /// 收缩内存占用至实际内容大小
        /// </summary>
        public void TrimExcess()
        {
            var newelem = new T[last + 1];
            Buffer.BlockCopy(elem, 0, newelem, 0, last + 1);
            maxsize = last + 1;
            this.elem = newelem;
        }


        private void ChekIfNeedEnlargeAndDoEnlarge()
        {
            if (this.last + 1 == maxsize)
            {
                Enlarge();
            }
        }
        private void Enlarge()
        {
            T[] newelem;
            if (maxsize == int.MaxValue)
            {
                throw new OutOfMemoryException();
            }
            else if (maxsize <= int.MaxValue / 2)
            {
                newelem = new T[2 * maxsize];
                maxsize *= 2;
            }
            else
            {
                newelem = new T[int.MaxValue];
                maxsize = int.MaxValue;
            }
            Buffer.BlockCopy(elem, 0, newelem, 0, last + 1);
            this.elem = newelem;
        }



    }
}
