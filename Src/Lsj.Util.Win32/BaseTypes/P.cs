using System;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// Pointer to <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// This is not supported in method parameters when use .Net Framework
    /// </remarks>
    public struct P<T> where T : struct
    {
        private nint _value;

        /// <summary>
        /// 
        /// </summary>
        public ref T Value
        {
            get => ref UnsafePInvokeExtensions.AsStructRef<T>(_value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAs"></typeparam>
        /// <returns></returns>
        public ref TAs As<TAs>() where TAs : struct
        {
            return ref UnsafePInvokeExtensions.AsStructRef<TAs>(_value);
        }

        /// <summary>
        /// As pointer of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="TAs"></typeparam>
        /// <returns></returns>
        public P<TAs> AsP<TAs>() where TAs : struct
        {
            return new P<TAs> { _value = _value };
        }

        /// <summary>
        /// From pointer
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static P<T> FromPtr(nint value) => new P<T> { _value = value };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public unsafe ref T this[int index]
        {
            get
            {
                return ref UnsafePInvokeExtensions.AsStructRef<T>(_value + index * sizeof(nint));
            }
        }

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(P<T> val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator P<T>(nint val) => new P<T> { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PVOID(P<T> val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator P<T>(PVOID val) => new P<T> { _value = val };
    }
}
