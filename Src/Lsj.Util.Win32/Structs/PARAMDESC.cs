using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information needed for transferring a structure element, parameter, or function return value between processes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-paramdesc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PARAMDESC
    {
        /// <summary>
        /// The default value for the parameter,
        /// if <see cref="PARAMFLAG_FHASDEFAULT"/> is specified in <see cref="wParamFlags"/>.
        /// </summary>
        public IntPtr pparamdescex;

        /// <summary>
        /// The parameter flags.
        /// See <see cref="PARAMFLAG"/> Constants.
        /// </summary>
        public USHORT wParamFlags;
    }
}
