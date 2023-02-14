using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the arguments passed to a method or property.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-dispparams"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPPARAMS
    {
        /// <summary>
        /// An array of arguments.
        /// </summary>
        public IntPtr rgvarg;

        /// <summary>
        /// The dispatch IDs of the named arguments.
        /// </summary>
        public IntPtr rgdispidNamedArgs;

        /// <summary>
        /// The number of arguments.
        /// </summary>
        public UINT cArgs;

        /// <summary>
        /// The number of named arguments.
        /// </summary>
        public UINT cNamedArgs;
    }
}
