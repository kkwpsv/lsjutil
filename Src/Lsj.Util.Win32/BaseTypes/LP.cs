using System;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// Pointer to <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct LP<T> where T : struct
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(LP<T> val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LP<T>(IntPtr val) => new LP<T> { _value = val };
    }
}
