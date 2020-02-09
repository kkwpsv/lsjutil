using System;

namespace Lsj.Util
{
    /// <summary>
    /// <see cref="System.Runtime.InteropServices.Marshal"/> Extensions
    /// </summary>
    public static class MarshalExtensions
    {
        /// <summary>
        /// Size Of
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int SizeOf<T>() => System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));

        /// <summary>
        /// Marshal <paramref name="val"/> to a unmanaged memory block,
        /// which was alloced by <see cref="System.Runtime.InteropServices.Marshal.AllocHGlobal(int)"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns>The <see cref="IntPtr"/> to the unmanaged memory block. </returns>
        public static IntPtr StructureToPtr<T>(T val)
        {
            var result = System.Runtime.InteropServices.Marshal.AllocHGlobal(SizeOf<T>());
            System.Runtime.InteropServices.Marshal.StructureToPtr(val, result, false);
            return result;
        }
    }
}
