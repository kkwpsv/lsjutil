using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines an item identifier.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shtypes/ns-shtypes-shitemid"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHITEMID
    {
        /// <summary>
        /// The size of identifier, in bytes, including <see cref="cb"/> itself.
        /// </summary>
        public SHORT cb;

        /// <summary>
        /// A variable-length item identifier.
        /// </summary>
        public BYTE abID;
    }
}
