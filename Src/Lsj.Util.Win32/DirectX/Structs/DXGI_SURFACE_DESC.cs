using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a surface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_surface_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by the <see cref="IDXGISurface.GetDesc"/> and <see cref="IDXGIDevice.CreateSurface"/> methods.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_SURFACE_DESC
    {
        /// <summary>
        /// A value describing the surface width.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// A value describing the surface height.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// A member of the <see cref="DXGI_FORMAT"/> enumerated type that describes the surface format.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// A member of the <see cref="DXGI_SAMPLE_DESC"/> structure that describes multi-sampling parameters for the surface.
        /// </summary>
        public DXGI_SAMPLE_DESC SampleDesc;
    }
}
