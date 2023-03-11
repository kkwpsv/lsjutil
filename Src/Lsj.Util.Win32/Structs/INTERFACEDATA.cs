using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes the object's properties and methods.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleauto/ns-oleauto-interfacedata"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct INTERFACEDATA
    {
        /// <summary>
        /// An array of <see cref="METHODDATA"/> structures.
        /// </summary>
        public P<METHODDATA> pmethdata;

        /// <summary>
        /// The count of members.
        /// </summary>
        public UINT cMembers;
    }
}
