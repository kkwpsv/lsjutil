using System;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// Pointer to <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct P<T> where T : struct
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(P<T> val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator P<T>(IntPtr val) => new P<T> { _value = val };
    }
}
