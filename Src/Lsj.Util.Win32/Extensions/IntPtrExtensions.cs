using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Extensions
{
    public static class IntPtrExtensions
    {
        public static int SafeToInt32(this IntPtr ptr) => IntPtr.Size == 8 ? (int)(ptr.ToInt64()) : ptr.ToInt32();
        public static uint SafeToUInt32(this IntPtr ptr) => unchecked((uint)ptr.SafeToInt32());
    }
}
