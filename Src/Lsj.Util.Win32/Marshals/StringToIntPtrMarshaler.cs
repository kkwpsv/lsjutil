using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// <para>Marshal <see cref="string"/> to <see cref="IntPtr"/> with Unicode</para>
    /// <para>MUST DISPOSE !!! </para>
    /// </summary>
    public class StringToIntPtrMarshaler : DisposableClass
    {
        private readonly IntPtr ptr;

        public StringToIntPtrMarshaler(string str) => ptr = Marshal.StringToHGlobalUni(str);

        public IntPtr GetPtr() => ptr;

        protected override void CleanUpUnmanagedResources() => Marshal.FreeHGlobal(ptr);
    }

}
