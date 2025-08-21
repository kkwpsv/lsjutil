using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D3DDECLTYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DQUERYTYPE;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// Constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// <para>
        /// No error occurred.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3D_OK = S_OK;

        /// <summary>
        /// D3D11_REQ_CONSTANT_BUFFER_ELEMENT_COUNT
        /// </summary>
        public const uint D3D11_REQ_CONSTANT_BUFFER_ELEMENT_COUNT = 4096;

        /// <summary>
        /// <para>
        /// Specifies the primary display adapter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dadapter-default"/>
        /// </para>
        /// </summary>
        public const uint D3DADAPTER_DEFAULT = 0;

        /// <summary>
        /// <para>
        /// Specifies the maximum number of rectangles used in composing glyphs in <see cref="IDirect3DDevice9Ex.ComposeRects"/>.
        /// Maximum number of rectangle glyphs to compose together in a text string.
        /// See <see cref="IDirect3DDevice9Ex.ComposeRects"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcomposerects-maxnumrects"/>
        /// </para>
        /// </summary>
        public const uint D3DCOMPOSERECTS_MAXNUMRECTS = 0xFFFF;

        /// <summary>
        /// <para>
        /// Maximum height of a monochrome texture convolution filter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dconvolutionmono"/>
        /// </para>
        /// </summary>
        public const uint D3DCONVOLUTIONMONO_MAXHEIGHT = 7;

        /// <summary>
        /// <para>
        /// Maximum width of a monochrome texture convolution filter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dconvolutionmono"/>
        /// </para>
        /// </summary>
        public const uint D3DCONVOLUTIONMONO_MAXWIDTH = 7;

        /// <summary>
        /// D3DCURSOR_IMMEDIATE_UPDATE
        /// </summary>
        public const uint D3DCURSOR_IMMEDIATE_UPDATE = 0x00000001;

        /// <summary>
        /// <para>
        /// Initialize the last vertex element in a vertex declaration array.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddecl-end"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// This is used to initialize the last vertex element in a vertex declaration array.
        /// </remarks>
        public static readonly D3DVERTEXELEMENT9 D3DDECL_END = new D3DVERTEXELEMENT9
        {
            Stream = 0xFF,
            Offset = 0,
            Type = D3DDECLTYPE_UNUSED,
            Method = 0,
            Usage = 0,
            UsageIndex = 0,
        };

        /// <summary>
        /// D3DDMAPSAMPLER
        /// </summary>
        public const uint D3DDMAPSAMPLER = 256;

        /// <summary>
        /// <para>
        /// Microsoft Windows Hardware Quality Labs (WHQL) driver testing.
        /// This is a time-consuming test requiring a one-second or two-second time penalty.
        /// This constant is used by the <see cref="D3DADAPTER_IDENTIFIER9.WHQLLevel"/> member of <see cref="D3DADAPTER_IDENTIFIER9"/>.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// <see cref="D3DENUM_WHQL_LEVEL"/> is deprecated for Direct3D9Ex running on Windows Vista,
        /// Windows Server 2008, Windows 7, and Windows Server 2008 R2(or more current operating system).
        /// Any of these operating systems return 1 for the WHQL level without checking the status of the driver.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3denum"/>
        /// </para>
        /// </summary>
        public const uint D3DENUM_WHQL_LEVEL = 0x00000002;

        /// <summary>
        /// <para>
        /// This macro creates a value used by <see cref="IDirect3DQuery9.Issue"/> to issue a query begin.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dissue-begin"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <see cref="D3DISSUE_BEGIN"/> is valid for the following query type.
        /// <see cref="D3DQUERYTYPE_OCCLUSION"/>
        /// </remarks>
        public const uint D3DISSUE_BEGIN = 1 << 1;

        /// <summary>
        /// <para>
        /// This macro creates a value used by <see cref="IDirect3DQuery9.Issue"/> to issue a query end.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dissue-begin"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <see cref="D3DISSUE_END"/> is valid for the following query type.
        /// <see cref="D3DQUERYTYPE_VCACHE"/>, <see cref="D3DQUERYTYPE_RESOURCEMANAGER"/>, <see cref="D3DQUERYTYPE_VERTEXSTATS"/>,
        /// <see cref="D3DQUERYTYPE_EVENT"/>, <see cref="D3DQUERYTYPE_OCCLUSION"/>
        /// </remarks>
        public const uint D3DISSUE_END = 1 << 0;

        /// <summary>
        /// <para>
        /// This macro creates the value passed to <see cref="IDirect3DQuery9.GetData"/> to flush query data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dgetdata-flush"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// For more information about using queries, see Queries (Direct3D 9).
        /// </remarks>
        public const uint D3DGETDATA_FLUSH = 1 << 0;

        /// <summary>
        /// <para>
        /// This is a success code. However, the autogeneration of mipmaps is not supported for this format.
        /// This means that resource creation will succeed but the mipmap levels will not be automatically generated.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3DOK_NOAUTOGEN = 0x0876086f;

        /// <summary>
        /// D3DPRESENT_BACK_BUFFERS_MAX
        /// </summary>
        public const uint D3DPRESENT_BACK_BUFFERS_MAX = 3;

        /// <summary>
        /// D3DPRESENT_BACK_BUFFERS_MAX_EX
        /// </summary>
        public const uint D3DPRESENT_BACK_BUFFERS_MAX_EX = 30;

        /// <summary>
        /// D3DPV_DONOTCOPYDATA
        /// </summary>
        public const uint D3DPV_DONOTCOPYDATA = 1 << 0;

        /// <summary>
        /// D3DRENDERSTATE_WRAPBIAS
        /// </summary>
        public const uint D3DRENDERSTATE_WRAPBIAS = 128U;

        /// <summary>
        /// D3DSGR_NO_CALIBRATION
        /// </summary>
        public const uint D3DSGR_NO_CALIBRATION = 0x00000000;

        /// <summary>
        /// D3DSGR_CALIBRATE
        /// </summary>
        public const uint D3DSGR_CALIBRATE = 0x00000001;

        /// <summary>
        /// D3DSPD_IUNKNOWN
        /// </summary>
        public const uint D3DSPD_IUNKNOWN = 0x00000001;

        /// <summary>
        /// D3DSTREAMSOURCE_INDEXEDDATA
        /// </summary>
        public const uint D3DSTREAMSOURCE_INDEXEDDATA = 1 << 30;

        /// <summary>
        /// D3DSTREAMSOURCE_INSTANCEDATA
        /// </summary>
        public const uint D3DSTREAMSOURCE_INSTANCEDATA = (uint)2 << 30;

        /// <summary>
        /// <para>
        /// Maps indices in the range 0 through 255 to the corresponding transform states.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dts-worldmatrix"/>
        /// </para>
        /// </summary>
        /// <param name="index">
        /// An index value in the range 0 through 255.
        /// </param>
        /// <returns>
        /// The <see cref="D3DTRANSFORMSTATETYPE"/> that maps to the given <paramref name="index"/>.
        /// </returns>
        /// <remarks>
        /// Transform states in the range 256 through 511 are reserved to store up to 256 matrices that can be indexed using 8-bit indices.
        /// </remarks>
        public static D3DTRANSFORMSTATETYPE D3DTS_WORLDMATRIX(int index) => (D3DTRANSFORMSTATETYPE)(index + 256);

        /// <summary>
        /// <para>
        /// Identifies the transformation matrix being set as the world transformation matrix.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dts-world"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// A <see cref="D3DTRANSFORMSTATETYPE"/> equivalent to D3DTS_WORLDMATRIX(0).
        /// This macro is provided to facilitate porting existing applications to Direct3D 9.
        /// </remarks>
        public const D3DTRANSFORMSTATETYPE D3DTS_WORLD = (D3DTRANSFORMSTATETYPE)256;

        /// <summary>
        /// D3DWRAPCOORD_0
        /// </summary>
        public const uint D3DWRAPCOORD_0 = 0x00000001;

        /// <summary>
        /// D3DWRAPCOORD_1
        /// </summary>
        public const uint D3DWRAPCOORD_1 = 0x00000002;

        /// <summary>
        /// D3DWRAPCOORD_2
        /// </summary>
        public const uint D3DWRAPCOORD_2 = 0x00000004;

        /// <summary>
        /// D3DWRAPCOORD_3
        /// </summary>
        public const uint D3DWRAPCOORD_3 = 0x00000008;

        /// <summary>
        /// D3DWRAP_U
        /// </summary>
        public const uint D3DWRAP_U = 0x00000001;

        /// <summary>
        /// D3DWRAP_V
        /// </summary>
        public const uint D3DWRAP_V = 0x00000002;

        /// <summary>
        /// D3DWRAP_W
        /// </summary>
        public const uint D3DWRAP_W = 0x00000004;

        /// <summary>
        /// IID_IDXGIFactory
        /// </summary>
        public static readonly IID IID_IDXGIFactory = new Guid("7b7166ec-21c7-44ae-b21a-c9ae321ae369");
    }
}
