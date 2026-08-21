using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// LOADPARMS32
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOADPARMS32
    {
        /// <summary>
        /// address of environment strings
        /// </summary>
        public nint lpEnvAddress;

        /// <summary>
        /// address of command line
        /// </summary>
        public nint lpCmdLine;

        /// <summary>
        /// how to show new program
        /// </summary>
        public nint lpCmdShow;

        /// <summary>
        /// must be zero
        /// </summary>
        public DWORD dwReserved;
    }
}
