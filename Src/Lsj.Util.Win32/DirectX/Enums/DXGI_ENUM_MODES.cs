using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Options for enumerating display modes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-enum-modes"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These flag options are used in <see cref="IDXGIOutput.GetDisplayModeList"/> to enumerate display modes.
    /// These flag options are also used in <see cref="IDXGIOutput1.GetDisplayModeList1"/> to enumerate display modes.
    /// </remarks>
    [Flags]
    public enum DXGI_ENUM_MODES : uint
    {
        /// <summary>
        /// Include interlaced modes.
        /// </summary>
        DXGI_ENUM_MODES_INTERLACED = 1,

        /// <summary>
        /// Include stretched-scaling modes.
        /// </summary>
        DXGI_ENUM_MODES_SCALING = 2,

        /// <summary>
        /// Include stereo modes.
        /// Direct3D 11: This enumeration value is supported starting with Windows 8.
        /// </summary>
        DXGI_ENUM_MODES_STEREO = 4,

        /// <summary>
        /// Include stereo modes that are hidden because the user has disabled stereo.
        /// Control panel applications can use this option to show stereo capabilities
        /// that have been disabled as part of a user interface that enables and disables stereo.
        /// Direct3D 11: This enumeration value is supported starting with Windows 8.
        /// </summary>
        DXGI_ENUM_MODES_DISABLED_STEREO = 8,
    }
}
