using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the type of DXGI adapter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/ne-dxgi-dxgi_adapter_flag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="DXGI_ADAPTER_FLAG"/> enumerated type is used by the <see cref="DXGI_ADAPTER_DESC1.Flags"/> member
    /// of the <see cref="DXGI_ADAPTER_DESC1"/> or <see cref="DXGI_ADAPTER_DESC2"/> structure to identify the type of DXGI adapter.
    /// </remarks>
    [Flags]
    public enum DXGI_ADAPTER_FLAG
    {
        /// <summary>
        /// Specifies no flags.
        /// </summary>
        DXGI_ADAPTER_FLAG_NONE = 0,

        /// <summary>
        /// Value always set to 0.
        /// This flag is reserved.
        /// </summary>
        DXGI_ADAPTER_FLAG_REMOTE = 1,

        /// <summary>
        /// Specifies a software adapter.
        /// For more info about this flag, see new info in Windows 8 about enumerating adapters.
        /// Direct3D 11:
        /// This enumeration value is supported starting with Windows 8.
        /// </summary>
        DXGI_ADAPTER_FLAG_SOFTWARE = 2,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        DXGI_ADAPTER_FLAG_FORCE_DWORD = unchecked((int)0xffffffff),
    }
}
