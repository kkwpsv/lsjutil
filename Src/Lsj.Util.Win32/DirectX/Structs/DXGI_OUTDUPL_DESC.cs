using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DXGI_OUTDUPL_DESC"/> structure describes the dimension of the output and the surface that contains the desktop image.
    /// The format of the desktop image is always <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_outdupl_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by <see cref="IDXGIOutputDuplication.GetDesc"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_OUTDUPL_DESC
    {
        /// <summary>
        /// A <see cref="DXGI_MODE_DESC"/> structure that describes the display mode of the duplicated output.
        /// </summary>
        public DXGI_MODE_DESC ModeDesc;

        /// <summary>
        /// A member of the <see cref="DXGI_MODE_ROTATION"/> enumerated type that describes how the duplicated output rotates an image.
        /// </summary>
        public DXGI_MODE_ROTATION Rotation;

        /// <summary>
        /// Specifies whether the resource that contains the desktop image is already located in system memory.
        /// <see cref="TRUE"/> if the resource is in system memory; otherwise, <see cref="FALSE"/>.
        /// If this value is <see cref="TRUE"/> and the application requires CPU access,
        /// it can use the <see cref="IDXGIOutputDuplication.MapDesktopSurface"/> and <see cref="IDXGIOutputDuplication.UnMapDesktopSurface"/> methods
        /// to avoid copying the data into a staging buffer.
        /// </summary>
        public BOOL DesktopImageInSystemMemory;
    }
}
