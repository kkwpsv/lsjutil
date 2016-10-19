using Lsj.Util.Logs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// 安全字典
    /// 访问不存在值不会抛出异常
    /// </summary>
    /// <typeparam name="TKey">Key Type</typeparam>
    /// <typeparam name="TValue">Value Type</typeparam>
    public class SafeDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> ,IDictionary<TKey,TValue>
    {
        object m_lock = new object();
        Dictionary<TKey, TValue> m_Dictionary;
        bool IsMultiThreadSafety = false;

        /// <summary>
        /// 键
        /// </summary>
        public ICollection<TKey> Keys => m_Dictionary.Keys;
        /// <summary>
        /// 值
        /// </summary>
        public ICollection<TValue> Values => m_Dictionary.Values;
        /// <summary>
        /// 初始化一个非多线程安全的<see cref="SafeDictionary{TKey, TValue}"/>实例
        /// </summary>
        public SafeDictionary() : this(false)
        {
        }
        /// <summary>
        /// 初始化一个<see cref="SafeDictionary{TKey, TValue}"/>实例
        /// </summary>
        /// <param name="IsMultiThreadSafety">是否多线程安全</param>
        public SafeDictionary(bool IsMultiThreadSafety) : this(new Dictionary<TKey, TValue>(), IsMultiThreadSafety)
        {
        }
        /// <summary>
        /// 初始化一个<see cref="SafeDictionary{TKey, TValue}"/>实例
        /// </summary>
        /// <param name="src">Source Dicitionay</param>
        public SafeDictionary(Dictionary<TKey, TValue> src) : this(src, false)
        {
        }
        /// <summary>
        /// 初始化一个<see cref="SafeDictionary{TKey, TValue}"/>实例
        /// </summary>
        /// <param name="src">源<see cref="Dictionary{TKey, TValue}"/></param>
        /// <param name="IsMultiThreadSafety">是否多线程安全/param>
        public SafeDictionary(Dictionary<TKey, TValue> src, bool IsMultiThreadSafety)
        {
            if (src == null)
                throw new ArgumentNullException();
            this.m_Dictionary = src;
            this.IsMultiThreadSafety = IsMultiThreadSafety;
        }
        /// <summary>
        /// 空值
        /// </summary>
        /// <returns></returns>
        public virtual TValue NullValue
        {
            get
            {
                return default(TValue);
            }
        }
        /// <summary>
        /// 包含的键值对数目
        /// </summary>
        public int Count => this.m_Dictionary.Count;
        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// 获取或设置与指定的键相关联的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public TValue this[TKey key]
        {
            get
            {
                return Contain(key) ? m_Dictionary[key] : NullValue;
            }
            set
            {
                Set(key, value);
            }
        }
        /// <summary>
        /// 将指定的键值对添加到字典中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            if (Contain(key))
            {
                LogProvider.Default.Debug("Add Same Key : " + key.ToString());
            }
            Set(key, value);
        }
        /// <summary>
        /// 将指定的键和值添加到字典中
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);
        /// <summary>
        /// 从字典中删除指定键值
        /// </summary>
        /// <param name="key"></param>
        public bool Remove(TKey key)
        {
            if (Contain(key))
            {
                Del(key);
                return true;
            }
            else
            {
                LogProvider.Default.Debug("The Key doesn't Exist : " + key.ToString());
                return false;
            }
        }
        /// <summary>
        /// 移除所指定的键值对
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (Contain(item.Key) && this[item.Key].Equals(item.Value))
            {
                Del(item.Key);
                return true;
            }
            else
            {
                LogProvider.Default.Debug("The Key doesn't Exist : " + item.Key.ToString());
                return false;
            }
        }
        /// <summary>
        /// 移除所有的键和值
        /// </summary>
        public void Clear()
        {
            Clr();
        }


        /// <summary>
        /// 将所有元素复制到一个<see cref="KeyValuePair<TKey, TValue>[]"/>中
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {

            ((IDictionary<TKey, TValue>)this.m_Dictionary).CopyTo(array, arrayIndex);
        }




        /// <summary>
        /// 是否包含指定的键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key)
        {
            return Contain(key);
        }
        /// <summary>
        /// 是否包含指定的键值对
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<TKey, TValue> item) => this.Contain(item.Key) && this[item.Key].Equals(item.Value);
        /// <summary>
        /// 获取与指定的键相关联的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            var flag = Contain(key);
            value = flag ? m_Dictionary[key] : NullValue;
            return flag;
        }


        /// <summary>
        /// 返回枚举器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return m_Dictionary.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// 转换成<see cref="Dictionary{TKey, TValue}"/>
        /// </summary>
        /// <returns></returns>
        public Dictionary<TKey, TValue> ToDictionary()
        {
            var x = new Dictionary<TKey, TValue>();
            foreach (var a in this)
            {
                x.Add(a.Key,a.Value);
            }
            return x;
        }


        internal TValue GetWithoutCheck(TKey key) => m_Dictionary[key];


        void Lock()
        {
            if (IsMultiThreadSafety)
            {
                Monitor.Enter(m_lock);
            }
        }
        void Unlock()
        {
            if (IsMultiThreadSafety)
            {
                Monitor.Exit(m_lock);
            }
        }
        void Set(TKey key, TValue value)
        {
            try
            {
                Lock();
                m_Dictionary[key] = value;
            }
            catch (Exception e)
            {
                LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }
        bool Contain(TKey key)
        {
            if (key == null)
            {
                LogProvider.Default.Warn("Check if contain null key");
                return false;
            }
            bool result = false;
            try
            {
                Lock();
                result = m_Dictionary.ContainsKey(key);
            }
            catch (Exception e)
            {
                LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
            return result;
        }
        void Clr()
        {
            try
            {
                Lock();
                m_Dictionary.Clear();
            }
            catch (Exception e)
            {
                LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }
        void Del(TKey key)
        {
            try
            {
                Lock();
                m_Dictionary.Remove(key);
            }
            catch (Exception e)
            {
                LogProvider.Default.Error(e);
                throw;
            }
            finally
            {
                Unlock();
            }
        }

    }
}
