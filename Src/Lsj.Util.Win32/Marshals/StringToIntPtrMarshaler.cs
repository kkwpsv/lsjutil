using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// <para>Marshal <see cref="string"/> to <see cref="IntPtr"/> with Unicode</para>
    /// <para>MUST DISPOSE!!!</para>
    /// </summary>
    public class StringToIntPtrMarshaler : DisposableClass
    {
        private readonly IntPtr ptr;

        /// <summary>
        /// StringToIntPtrMarshaler
        /// </summary>
        /// <param name="str"></param>
        public StringToIntPtrMarshaler(string str) => ptr = Marshal.StringToHGlobalUni(str);

        /// <summary>
        /// Get the IntPtr
        /// </summary>
        /// <returns></returns>
        public IntPtr GetPtr() => ptr;

        /// <summary>
        /// 
        /// </summary>
        protected override void CleanUpUnmanagedResources() => Marshal.FreeHGlobal(ptr);
    }

}
