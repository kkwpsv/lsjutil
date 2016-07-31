using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// 多线程安全List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MultiThreadSafeList<T>:IList<T>
    {
        List<T> m_list;
        object m_lock = new object();
        /// <summary>
        /// 初始化一个<see cref="MultiThreadSafeList{T}"/>实例
        /// </summary>
        public MultiThreadSafeList()
        {
            m_list = new List<T>();
        }
        /// <summary>
        /// 初始化一个<see cref="MultiThreadSafeList{T}"/>实例
        /// <param name="src">源List</param>
        /// </summary>
        public MultiThreadSafeList(List<T> src)
        {
            m_list = src;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return m_list[index];
            }

            set
            {
                try
                {
                    Lock();
                    m_list[index] = value;
                }
                catch (Exception e)
                {
                    Logs.LogProvider.Default.Error(e);
                    throw;
                }
                finally
                {
                    Unlock();
                }
            }
        }

        /// <summary>
        /// 包含的元素数
        /// </summary>
        public int Count
        {
            get
            {
                return m_list.Count;
            }
        }
        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            try
            {
                Lock();
                m_list.Add(item);
            }
            catch (Exception e)
            {
                Logs.LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }
        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            try
            {
                Lock();
                m_list.Clear();
            }
            catch (Exception e)
            {
                Logs.LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }
        /// <summary>
        /// 是否包含特定值
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return m_list.Contains(item);
        }
        /// <summary>
        ///  复制到一维数组中，从目标数组的指定索引位置开始放置。
        /// </summary>
        /// <param name="array">目标数组</param>
        /// <param name="arrayIndex">开始索引</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            m_list.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return m_list.GetEnumerator();
        }
        /// <summary>
        /// 搜索指定的对象的索引
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            return m_list.IndexOf(item);
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            try
            {
                Lock();
                m_list.Insert(index, item);
            }
            catch (Exception e)
            {
                Logs.LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }           
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="item"></param>
        public bool Remove(T item)
        {
            var result = false;
            try
            {
                Lock();
                result = m_list.Remove(item);             
            }
            catch (Exception e)
            {
                Logs.LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();             
            }
            return result;
        }
        /// <summary>
        /// 删除指定索引的元素
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            try
            {
                Lock();
                m_list.RemoveAt(index);
            }
            catch (Exception e)
            {
                Logs.LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }           
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_list.GetEnumerator();
        }




        void Lock()
        {
            Monitor.Enter(m_lock);
        }
        void Unlock()
        {
            Monitor.Exit(m_lock);
        }

    }
    
}
