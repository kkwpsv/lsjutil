using System;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// Any Size Array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct AnySizeArray<T> where T : unmanaged
    {
        private T _val;

        /// <summary>
        /// Access By Index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public unsafe ref T this[int index]
        {
            get
            {
                fixed (T* ptr = &_val)
                {
                    return ref ptr[index];
                }
            }
        }

        /// <summary>
        /// To <see cref="P{T}"/>
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Ensure this is fixed.
        /// </remarks>
        public unsafe P<T> ToPtr()
        {
            fixed (T* ptr = &_val)
            {
                return (P<T>)(IntPtr)(void*)ptr;
            }
        }
    }
}
