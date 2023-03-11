using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DUSAGE;
using static Lsj.Util.Win32.DirectX.Enums.D3DFORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DPOOL;
using Lsj.Util.Win32.DirectX.Enums;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DDevice9Ex"/> interface to render primitives,
    /// create resources, work with system-level variables, adjust gamma ramp levels, work with palettes, and create shaders.
    /// The <see cref="IDirect3DDevice9Ex"/> interface derives from the <see cref="IDirect3DDevice9"/> interface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9/nn-d3d9-idirect3ddevice9ex"/>
    /// </para>
    /// </summary>
    public unsafe struct IDirect3DDevice9Ex
    {
        IntPtr* _vTable;

        /// <summary>
        /// Copy a text string to one surface using an alphabet of glyphs on another surface.
        /// Composition is done by the GPU using bitwise operations.
        /// </summary>
        /// <param name="pSrc">
        /// A pointer to a source surface (prepared by IDirect3DSurface9) that supplies the alphabet glyphs.
        /// This surface must be created with the <see cref="D3DUSAGE_TEXTAPI"/> flag.
        /// </param>
        /// <param name="pDst">
        /// A pointer to the destination surface (prepared by <see cref="IDirect3DSurface9"/>) that receives the glyph data.
        /// The surface must be part of a texture.
        /// </param>
        /// <param name="pSrcRectDescs">
        /// A pointer to a vertex buffer (see <see cref="IDirect3DVertexBuffer9"/>) containing rectangles (see <see cref="D3DCOMPOSERECTDESC"/>)
        /// that enclose the desired glyphs in the source surface.
        /// </param>
        /// <param name="NumRects">
        /// The number of rectangles or glyphs that are used in the operation.
        /// The number applies to both the source and destination surfaces.
        /// The range is 0 to <see cref="D3DCOMPOSERECTS_MAXNUMRECTS"/>.
        /// </param>
        /// <param name="pDstRectDescs">
        /// A pointer to a vertex buffer (see <see cref="IDirect3DVertexBuffer9"/>) containing rectangles (see <see cref="D3DCOMPOSERECTDESTINATION"/>)
        /// that describe the destination to which the indicated glyph from the source surface will be copied.
        /// </param>
        /// <param name="Operation">
        /// Specifies how to combine the source and destination surfaces.
        /// See <see cref="D3DCOMPOSERECTSOP"/>.
        /// </param>
        /// <param name="Xoffset">
        /// A value added to the x coordinates of all destination rectangles.
        /// This value can be negative, which may cause the glyph to be rejected or clipped if the result is beyond the bounds of the surface.
        /// </param>
        /// <param name="Yoffset">
        /// A value added to the y coordinates of all destination rectangles.
        /// This value can be negative, which may cause the glyph to be rejected or clipped if the result is beyond the bounds of the surface.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// </returns>
        /// <remarks>
        /// Glyphs from a one-bit source surface are put together into another one-bit texture surface with this method.
        /// The destination surface can then be used as the source for a normal texturing operation
        /// that will filter and scale the strings of text onto some other non-monochrome surface.
        /// This method has several constraints (which are similar to <see cref="IDirect3DDevice9.StretchRect"/>):
        /// Surfaces cannot be locked.
        /// The source and destination surfaces cannot be the same surface.
        /// The source and destination surfaces must be created with the <see cref="D3DFMT_A1"/> format.
        /// The source surface and both vertex buffers must be created with the <see cref="D3DPOOL_DEFAULT"/> flag.
        /// The destination surface must be created with either the <see cref="D3DPOOL_DEFAULT"/> or <see cref="D3DPOOL_SYSTEMMEM"/> flags.
        /// The source rectangles must be within the source surface.
        /// The method is not recorded in state blocks.
        /// </remarks>
        public HRESULT ComposeRects([In] in IDirect3DSurface9 pSrc, [In] in IDirect3DSurface9 pDst, [In] in IDirect3DVertexBuffer9 pSrcRectDescs,
            [In] UINT NumRects, [In] in IDirect3DVertexBuffer9 pDstRectDescs, [In] D3DCOMPOSERECTSOP Operation, [In] int Xoffset, [In] int Yoffset)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IDirect3DSurface9, in IDirect3DSurface9, in IDirect3DVertexBuffer9,
                    UINT, in IDirect3DVertexBuffer9, D3DCOMPOSERECTSOP, int, int, HRESULT>)_vTable[121])
                    (thisPtr, pSrc, pDst, pSrcRectDescs, NumRects, pDstRectDescs, Operation, Xoffset, Yoffset);
            }
        }

        /// <summary>
        /// Reports the current cooperative-level status of the Direct3D device for a windowed or full-screen application.
        /// </summary>
        /// <param name="hDestinationWindow">
        /// The destination window handle to check for occlusion.
        /// When this parameter is <see cref="NULL"/>, <see cref="S_PRESENT_OCCLUDED"/> is returned when another device has fullscreen ownership.
        /// When the window handle is not <see cref="NULL"/>, window's client area is checked for occlusion.
        /// A window is occluded if any part of it is obscured by another application.
        /// </param>
        /// <returns>
        /// Possible return values include: <see cref="D3D_OK"/>, <see cref="D3DERR_DEVICELOST"/>, <see cref="D3DERR_DEVICEHUNG"/>,
        /// <see cref="D3DERR_DEVICEREMOVED"/>, or <see cref="D3DERR_OUTOFVIDEOMEMORY"/> (see D3DERR),
        /// or <see cref="S_PRESENT_MODE_CHANGED"/>, or <see cref="S_PRESENT_OCCLUDED"/> (see S_PRESENT).
        /// </returns>
        /// <remarks>
        /// This method replaces <see cref="IDirect3DDevice9.TestCooperativeLevel"/>, which always returns <see cref="S_OK"/> in Direct3D 9Ex applications.
        /// We recommend not to call <see cref="CheckDeviceState"/> every frame.
        /// Instead, call <see cref="CheckDeviceState"/> only if the <see cref="PresentEx"/> method returns a failure code.
        /// See Lost Device Behavior Changes for more information about lost, hung, and removed devices.
        /// </remarks>
        public HRESULT CheckDeviceState([In] HWND hDestinationWindow)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, HRESULT>)_vTable[129])(thisPtr, hDestinationWindow);
            }
        }
    }
}
