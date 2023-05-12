using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.DirectX.Enums.D3DUSAGE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a surface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dsurface-desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DSURFACE_DESC
    {
        /// <summary>
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, describing the surface format.
        /// </summary>
        public D3DFORMAT Format;

        /// <summary>
        /// Member of the <see cref="D3DRESOURCETYPE"/> enumerated type, identifying this resource as a surface.
        /// </summary>
        public D3DRESOURCETYPE Type;

        /// <summary>
        /// Either the <see cref="D3DUSAGE_DEPTHSTENCIL"/> or <see cref="D3DUSAGE_RENDERTARGET"/> values.
        /// For more information, see <see cref="D3DUSAGE"/>.
        /// </summary>
        public DWORD Usage;

        /// <summary>
        /// Member of the <see cref="D3DPOOL"/> enumerated type, specifying the class of memory allocated for this surface.
        /// </summary>
        public D3DPOOL Pool;

        /// <summary>
        /// Member of the <see cref="D3DMULTISAMPLE_TYPE"/> enumerated type, specifying the levels of full-scene multisampling supported by the surface.
        /// </summary>
        public D3DMULTISAMPLE_TYPE MultiSampleType;

        /// <summary>
        /// Quality level.
        /// The valid range is between zero and one less than the level returned by pQualityLevels used by <see cref="IDirect3D9.CheckDeviceMultiSampleType"/>.
        /// Passing a larger value returns the error, <see cref="D3DERR_INVALIDCALL"/>.
        /// The <see cref="MultiSampleQuality"/> values of paired render targets, depth stencil surfaces and the MultiSample type must all match.
        /// </summary>
        public DWORD MultiSampleQuality;

        /// <summary>
        /// Width of the surface, in pixels.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// Height of the surface, in pixels.
        /// </summary>
        public UINT Height;
    }
}
