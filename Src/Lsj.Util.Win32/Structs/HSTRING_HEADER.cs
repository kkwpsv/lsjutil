using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents a header for an <see cref="HSTRING"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/hstring/ns-hstring-hstring_header"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HSTRING_HEADER
    {
        private IntPtr _padding1;

        private long _padding2;

        private long _padding3;
    }
}
