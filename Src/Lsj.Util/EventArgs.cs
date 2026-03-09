using System;

namespace Lsj.Util
{
    /// <summary>
    /// EventArgs with value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventArgs<T> : EventArgs
    {
        /// <summary>
        /// Value
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public EventArgs(T value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static EventArgs<T> FromValue(T value) => new EventArgs<T>(value);
    }
}
