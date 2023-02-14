using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the calling convention used by a member function described in the <see cref="METHODDATA"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ne-oaidl-callconv"/>
    /// </para>
    /// </summary>
    public enum CALLCONV
    {
        /// <summary>
        /// 
        /// </summary>
        CC_FASTCALL = 0,

        /// <summary>
        /// 
        /// </summary>
        CC_CDECL = 1,

        /// <summary>
        /// 
        /// </summary>
        CC_MSCPASCAL,

        /// <summary>
        /// 
        /// </summary>
        CC_PASCAL,

        /// <summary>
        /// 
        /// </summary>
        CC_MACPASCAL,

        /// <summary>
        /// 
        /// </summary>
        CC_STDCALL,

        /// <summary>
        /// 
        /// </summary>
        CC_FPFASTCALL,

        /// <summary>
        /// 
        /// </summary>
        CC_SYSCALL,

        /// <summary>
        /// 
        /// </summary>
        CC_MPWCDECL,

        /// <summary>
        /// 
        /// </summary>
        CC_MPWPASCAL,

        /// <summary>
        /// 
        /// </summary>
        CC_MAX
    }
}
