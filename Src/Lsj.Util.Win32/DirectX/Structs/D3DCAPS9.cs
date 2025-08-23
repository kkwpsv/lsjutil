using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3DBLEND;
using static Lsj.Util.Win32.DirectX.Enums.D3DCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DCURSORCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DDEVCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DFORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DFVFCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DLINECAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DPBLENDCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRASTERCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENT;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRIMCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DPSHADECAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DPTADDRESSCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DPTEXTURECAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DPTFILTERCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DSAMPLERSTATETYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DSHADEMODE;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXOPCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTUREFILTERTYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTUREOP;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTUREADDRESS;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTURETRANSFORMFLAGS;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents the capabilities of the hardware exposed through the Direct3D object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9caps/ns-d3d9caps-d3dcaps9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="MaxTextureBlendStages"/> and <see cref="MaxSimultaneousTextures"/> members might seem similar,
    /// but they contain different information.
    /// The <see cref="MaxTextureBlendStages"/> member contains
    /// the total number of texture-blending stages supported by the current device, 
    /// and the <see cref="MaxSimultaneousTextures"/> member describes how many of those stages
    /// can have textures bound to them by using the <see cref="IDirect3DDevice9.SetTexture"/> method.
    /// </para>
    /// <para>
    /// When the driver fills this structure, it can set values for execute-buffer capabilities,
    /// even when the interface being used to retrieve the capabilities (such as <see cref="IDirect3DDevice9"/>) does not support execute buffers.
    /// </para>
    /// <para>
    /// In general, performance problems may occur if you use a texture and then modify it during a scene.
    /// Ensure that no texture used in the current <see cref="IDirect3DDevice9.BeginScene"/>
    /// and <see cref="IDirect3DDevice9.EndScene"/> block is evicted unless absolutely necessary.
    /// In the case of extremely high texture usage within a scene, the results are undefined.
    /// This occurs when you modify a texture that you have used in the scene and there is no spare texture memory available.
    /// For such systems, the contents of the z-buffer become invalid at <see cref="IDirect3DDevice9.EndScene"/>.
    /// Applications should not call <see cref="IDirect3DDevice9.UpdateSurface"/> to or from the back buffer
    /// on this type of hardware inside a <see cref="IDirect3DDevice9.BeginScene"/>/<see cref="IDirect3DDevice9.EndScene"/> pair.
    /// In addition, applications should not try to access the z-buffer
    /// if the <see cref="D3DPRASTERCAPS_ZBUFFERLESSHSR"/> capability flag is set.
    /// Finally, applications should not lock the back buffer
    /// or the z-buffer inside a <see cref="IDirect3DDevice9.BeginScene"/>/<see cref="IDirect3DDevice9.EndScene"/> pair.
    /// </para>
    /// <para>
    /// The following flags concerning mipmapped textures are not supported in Direct3D 9.
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="D3DPTFILTERCAPS_LINEAR"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3DPTFILTERCAPS_LINEARMIPLINEAR"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3DPTFILTERCAPS_LINEARMIPNEAREST"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3DPTFILTERCAPS_MIPNEAREST"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3DPTFILTERCAPS_NEAREST"/>
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DCAPS9
    {
        /// <summary>
        /// Member of the <see cref="D3DDEVTYPE"/> enumerated type, which identifies what type of resources are used for processing vertices.
        /// </summary>
        public D3DDEVTYPE DeviceType;

        /// <summary>
        /// Adapter on which this Direct3D device was created.
        /// This ordinal is valid only to pass to methods of the <see cref="IDirect3D9"/> interface that created this Direct3D device.
        /// The <see cref="IDirect3D9"/> interface can always be retrieved by calling <see cref="IDirect3DDevice9.GetDirect3D"/>.
        /// </summary>
        public UINT AdapterOrdinal;

        /// <summary>
        /// <para>
        /// The following driver-specific capability.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DCAPS_READ_SCANLINE"/>
        /// </term>
        /// <term>
        /// Display hardware is capable of returning the current scan line.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DCAPS_OVERLAY"/>
        /// </term>
        /// <term>
        /// <para>
        /// The display driver supports an overlay DDI that allows for verification of overlay capabilities.
        /// For more information about the overlay DDI, see Overlay DDI.
        /// </para>
        /// <para>
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// </para>
        /// <para>
        /// This flag is available in Direct3D 9Ex only.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public D3DCAPS Caps;

        /// <summary>
        /// Driver-specific capabilities identified in <see cref="D3DCAPS2"/>.
        /// </summary>
        public D3DCAPS2 Caps2;

        /// <summary>
        /// Driver-specific capabilities identified in <see cref="D3DCAPS3"/>.
        /// </summary>
        public D3DCAPS3 Caps3;

        /// <summary>
        /// <para>
        /// Bit mask of values representing what presentation swap intervals are available.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DPRESENT_INTERVAL_IMMEDIATE"/>
        /// </term>
        /// <term>
        /// The driver supports an immediate presentation swap interval.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRESENT_INTERVAL_ONE"/>
        /// </term>
        /// <term>
        /// The driver supports a presentation swap interval of every screen refresh.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRESENT_INTERVAL_TWO"/>
        /// </term>
        /// <term>
        /// The driver supports a presentation swap interval of every second screen refresh.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRESENT_INTERVAL_THREE"/>
        /// </term>
        /// <term>
        /// The driver supports a presentation swap interval of every third screen refresh.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRESENT_INTERVAL_FOUR"/>
        /// </term>
        /// <term>
        /// The driver supports a presentation swap interval of every fourth screen refresh.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public DWORD PresentationIntervals;

        /// <summary>
        /// <para>
        /// Bit mask indicating what hardware support is available for cursors.
        /// Direct3D 9 does not define alpha-blending cursor capabilities.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DCURSORCAPS_COLOR"/>
        /// </term>
        /// <term>
        /// A full-color cursor is supported in hardware.
        /// Specifically, this flag indicates that the driver supports at least a hardware color cursor
        /// in high-resolution modes (with scan lines greater than or equal to 400).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DCURSORCAPS_LOWRES"/>
        /// </term>
        /// <term>
        /// A full-color cursor is supported in hardware.
        /// Specifically, this flag indicates that the driver supports a hardware color cursor
        /// in both high-resolution and low-resolution modes (with scan lines less than 400).
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public D3DCURSORCAPS CursorCaps;

        /// <summary>
        /// <para>
        /// Flags identifying the capabilities of the device.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_CANBLTSYSTONONLOCAL"/>
        /// </term>
        /// <term>
        /// Device supports blits from system-memory textures to nonlocal video-memory textures.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_CANRENDERAFTERFLIP"/>
        /// </term>
        /// <term>
        /// Device can queue rendering commands after a page flip.
        /// Applications do not change their behavior if this flag is set;
        /// this capability means that the device is relatively fast.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_DRAWPRIMITIVES2"/>
        /// </term>
        /// <term>
        /// Device can support at least a DirectX 5-compliant driver.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_DRAWPRIMITIVES2EX"/>
        /// </term>
        /// <term>
        /// Device can support at least a DirectX 7-compliant driver.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_DRAWPRIMTLVERTEX"/>
        /// </term>
        /// <term>
        /// Device exports an <see cref="IDirect3DDevice9.DrawPrimitive"/>-aware hal.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_EXECUTESYSTEMMEMORY"/>
        /// </term>
        /// <term>
        /// Device can use execute buffers from system memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_EXECUTEVIDEOMEMORY"/>
        /// </term>
        /// <term>
        /// Device can use execute buffers from video memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_HWRASTERIZATION"/>
        /// </term>
        /// <term>
        /// Device has hardware acceleration for scene rasterization.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_HWTRANSFORMANDLIGHT"/>
        /// </term>
        /// <term>
        /// Device can support transformation and lighting in hardware.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_NPATCHES"/>
        /// </term>
        /// <term>
        /// Device supports N patches.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_PUREDEVICE"/>
        /// </term>
        /// <term>
        /// Device can support rasterization, transform, lighting, and shading in hardware.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_QUINTICRTPATCHES"/>
        /// </term>
        /// <term>
        /// Device supports quintic Bézier curves and B-splines.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_RTPATCHES"/>
        /// </term>
        /// <term>
        /// Device supports rectangular and triangular patches.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_RTPATCHHANDLEZERO"/>
        /// </term>
        /// <term>
        /// When this device capability is set, the hardware architecture does not require caching of any information,
        /// and uncached patches (handle zero) will be drawn as efficiently as cached ones.
        /// Note that setting <see cref="D3DDEVCAPS_RTPATCHHANDLEZERO"/> does not mean that a patch with handle zero can be drawn.
        /// A handle-zero patch can always be drawn whether this cap is set or not.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_SEPARATETEXTUREMEMORIES"/>
        /// </term>
        /// <term>
        /// Device is texturing from separate memory pools.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_TEXTURENONLOCALVIDMEM"/>
        /// </term>
        /// <term>
        /// Device can retrieve textures from non-local video memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_TEXTURESYSTEMMEMORY"/>
        /// </term>
        /// <term>
        /// Device can retrieve textures from system memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_TEXTUREVIDEOMEMORY"/>
        /// </term>
        /// <term>
        /// Device can retrieve textures from device memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_TLVERTEXSYSTEMMEMORY"/>
        /// </term>
        /// <term>
        /// Device can use buffers from system memory for transformed and lit vertices.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DDEVCAPS_TLVERTEXVIDEOMEMORY"/>
        /// </term>
        /// <term>
        /// Device can use buffers from video memory for transformed and lit vertices.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public D3DDEVCAPS DevCaps;

        /// <summary>
        /// Miscellaneous driver primitive capabilities.
        /// See <see cref="D3DPMISCCAPS"/>.
        /// </summary>
        public DWORD PrimitiveMiscCaps;

        /// <summary>
        /// <para>
        /// Information on raster-drawing capabilities.
        /// This member can be one or more of the following flags.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_ANISOTROPY"/>
        /// </term>
        /// <term>
        /// Device supports anisotropic filtering.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_COLORPERSPECTIVE"/>
        /// </term>
        /// <term>
        /// Device iterates colors perspective correctly.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_DITHER"/>
        /// </term>
        /// <term>
        /// Device can dither to improve color resolution.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_DEPTHBIAS"/>
        /// </term>
        /// <term>
        /// Device supports legacy depth bias.
        /// For true depth bias, see <see cref="D3DPRASTERCAPS_SLOPESCALEDEPTHBIAS"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_FOGRANGE"/>
        /// </term>
        /// <term>
        /// Device supports range-based fog.
        /// In range-based fog, the distance of an object from the viewer is used to compute fog effects,
        /// not the depth of the object (that is, the z-coordinate) in the scene.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_FOGTABLE"/>
        /// </term>
        /// <term>
        /// Device calculates the fog value by referring to a lookup table containing fog values that are indexed to the depth of a given pixel.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_FOGVERTEX"/>
        /// </term>
        /// <term>
        /// Device calculates the fog value during the lighting operation and interpolates the fog value during rasterization.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_MIPMAPLODBIAS"/>
        /// </term>
        /// <term>
        /// Device supports level-of-detail bias adjustments.
        /// These bias adjustments enable an application to make a mipmap appear crisper or less sharp than it normally would.
        /// For more information about level-of-detail bias in mipmaps, see <see cref="D3DSAMP_MIPMAPLODBIAS"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_MULTISAMPLE_TOGGLE"/>
        /// </term>
        /// <term>
        /// Device supports toggling multisampling on and off between <see cref="IDirect3DDevice9.BeginScene"/>
        /// and <see cref="IDirect3DDevice9.EndScene"/> (using <see cref="D3DRS_MULTISAMPLEANTIALIAS"/>).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_SCISSORTEST"/>
        /// </term>
        /// <term>
        /// Device supports scissor test. See Scissor Test (Direct3D 9).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_SLOPESCALEDEPTHBIAS"/>
        /// </term>
        /// <term>
        /// Device performs true slope-scale based depth bias.
        /// This is in contrast to the legacy style depth bias.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_WBUFFER"/>
        /// </term>
        /// <term>
        /// Device supports depth buffering using w.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_WFOG"/>
        /// </term>
        /// <term>
        /// Device supports w-based fog.
        /// W-based fog is used when a perspective projection matrix is specified,
        /// but affine projections still use z-based fog.
        /// The system considers a projection matrix that contains a nonzero value
        /// in the [3][4] element to be a perspective projection matrix.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_ZBUFFERLESSHSR"/>
        /// </term>
        /// <term>
        /// <para>
        /// Device can perform hidden-surface removal (HSR) without requiring the application
        /// to sort polygons and without requiring the allocation of a depth-buffer.
        /// This leaves more video memory for textures.
        /// The method used to perform HSR is hardware-dependent and is transparent to the application.
        /// </para>
        /// <para>
        /// Z-bufferless HSR is performed if no depth-buffer surface is associated with
        /// the rendering-target surface and the depth-buffer comparison test is enabled
        /// (that is, when the state value associated with the <see cref="D3DRS_ZENABLE"/> enumeration constant is set to <see cref="TRUE"/>).
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_ZFOG"/>
        /// </term>
        /// <term>
        /// Device supports z-based fog.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPRASTERCAPS_ZTEST"/>
        /// </term>
        /// <term>
        /// Device can perform z-test operations. This effectively renders a primitive and indicates whether any z pixels have been rendered.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public D3DPRASTERCAPS RasterCaps;

        /// <summary>
        /// <para>
        /// Z-buffer comparison capabilities.
        /// This member can be one or more of the following flags.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DPCMPCAPS_ALWAYS"/>
        /// </term>
        /// <term>
        /// Always pass the z-test.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPCMPCAPS_EQUAL"/>
        /// </term>
        /// <term>
        /// Pass the z-test if the new z equals the current z.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPCMPCAPS_GREATER"/>
        /// </term>
        /// <term>
        /// Pass the z-test if the new z is greater than the current z.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPCMPCAPS_GREATEREQUAL"/>
        /// </term>
        /// <term>
        /// Pass the z-test if the new z is greater than or equal to the current z.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPCMPCAPS_LESS"/>
        /// </term>
        /// <term>
        /// Pass the z-test if the new z is less than the current z.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPCMPCAPS_LESSEQUAL"/>
        /// </term>
        /// <term>
        /// Pass the z-test if the new z is less than or equal to the current z.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPCMPCAPS_NEVER"/>
        /// </term>
        /// <term>
        /// Always fail the z-test.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPCMPCAPS_NOTEQUAL"/>
        /// </term>
        /// <term>
        /// Pass the z-test if the new z does not equal the current z.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public D3DPRIMCAPS ZCmpCaps;

        /// <summary>
        /// <para>
        /// Source-blending capabilities.
        /// This member can be one or more of the following flags.
        /// (The RGBA values of the source and destination are indicated by the subscripts s and d.)
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_BLENDFACTOR"/>
        /// </term>
        /// <term>
        /// The driver supports both <see cref="D3DBLEND_BLENDFACTOR"/> and <see cref="D3DBLEND_INVBLENDFACTOR"/>.
        /// See <see cref="D3DBLEND"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_BOTHINVSRCALPHA"/>
        /// </term>
        /// <term>
        /// Source blend factor is (1 - Aₛ, 1 - Aₛ, 1 - Aₛ, 1 - Aₛ) and destination blend factor is (Aₛ, Aₛ, Aₛ, Aₛ);
        /// the destination blend selection is overridden.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_BOTHSRCALPHA"/>
        /// </term>
        /// <term>
        /// The driver supports the <see cref="D3DBLEND_BOTHSRCALPHA"/> blend mode.
        /// (This blend mode is obsolete. For more information, see <see cref="D3DBLEND"/>.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_DESTALPHA"/>
        /// </term>
        /// <term>
        /// Blend factor is (A, A, A, A).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_DESTCOLOR"/>
        /// </term>
        /// <term>
        /// Blend factor is (R, G, B, A).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_INVDESTALPHA"/>
        /// </term>
        /// <term>
        /// Blend factor is (1 - A, 1 - A, 1 - A, 1 - A).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_INVDESTCOLOR"/>
        /// </term>
        /// <term>
        /// Blend factor is (1 - R, 1 - G, 1 - B, 1 - A).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_INVSRCALPHA"/>
        /// </term>
        /// <term>
        /// Blend factor is (1 - Aₛ, 1 - Aₛ, 1 - Aₛ, 1 - Aₛ).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_INVSRCCOLOR"/>
        /// </term>
        /// <term>
        /// Blend factor is (1 - Rₛ, 1 - Gₛ, 1 - Bₛ, 1 - Aₛ).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_INVSRCCOLOR2"/>
        /// </term>
        /// <term>
        /// <para>
        /// Blend factor is (1 - PSOutColor[1], 1 - PSOutColor[1], 1 - PSOutColor[1], not used)).
        /// See Render Target Blending. 
        /// </para>
        /// <para>
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// </para>
        /// <para>
        /// This flag is available in Direct3D 9Ex only.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_ONE"/>
        /// </term>
        /// <term>
        /// Blend factor is (1, 1, 1, 1).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_SRCALPHA"/>
        /// </term>
        /// <term>
        /// Blend factor is (Aₛ, Aₛ, Aₛ, Aₛ).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_SRCALPHASAT"/>
        /// </term>
        /// <term>
        /// Blend factor is (f, f, f, 1); f = min(Aₛ, 1 - A).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_SRCCOLOR"/>
        /// </term>
        /// <term>
        /// Blend factor is (Rₛ, Gₛ, Bₛ, Aₛ).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_SRCCOLOR2"/>
        /// </term>
        /// <term>
        /// <para>
        /// Blend factor is (PSOutColor[1], PSOutColor[1], PSOutColor[1], not used).
        /// See Render Target Blending.
        /// </para>
        /// <para>
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// </para>
        /// <para>
        /// This flag is available in Direct3D 9Ex only.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPBLENDCAPS_ZERO"/>
        /// </term>
        /// <term>
        /// Blend factor is (0, 0, 0, 0).
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public D3DPBLENDCAPS SrcBlendCaps;

        /// <summary>
        /// Destination-blending capabilities.
        /// This member can be the same capabilities that are defined for the <see cref="SrcBlendCaps"/> member.
        /// </summary>
        public DWORD DestBlendCaps;

        /// <summary>
        /// Alpha-test comparison capabilities.
        /// This member can include the same capability flags defined for the <see cref="ZCmpCaps"/> member.
        /// If this member contains only the <see cref="D3DPCMPCAPS_ALWAYS"/> capability or only the <see cref="D3DPCMPCAPS_NEVER"/> capability,
        /// the driver does not support alpha tests.
        /// Otherwise, the flags identify the individual comparisons that are supported for alpha testing.
        /// </summary>
        public DWORD AlphaCmpCaps;

        /// <summary>
        /// <para>
        /// Shading operations capabilities.
        /// It is assumed, in general, that if a device supports a given command at all,
        /// it supports the <see cref="D3DSHADE_FLAT"/> mode (as specified in the <see cref="D3DSHADEMODE"/> enumerated type).
        /// This flag specifies whether the driver can also support Gouraud shading and whether alpha color components are supported.
        /// When alpha components are not supported, the alpha value of colors generated is implicitly 255.
        /// This is the maximum possible alpha (that is, the alpha component is at full intensity).
        /// </para>
        /// <para>
        /// The color, specular highlights, fog, and alpha interpolants of a triangle each have capability flags
        /// that an application can use to find out how they are implemented by the device driver.
        /// </para>
        /// <para>
        /// This member can be one or more of the following flags.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DPSHADECAPS_ALPHAGOURAUDBLEND"/>
        /// </term>
        /// <term>
        /// Device can support an alpha component for Gouraud-blended transparency
        /// (the <see cref="D3DSHADE_GOURAUD"/> state for the <see cref="D3DSHADEMODE"/> enumerated type).
        /// In this mode, the alpha color component of a primitive is provided at vertices
        /// and interpolated across a face along with the other color components.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPSHADECAPS_COLORGOURAUDRGB"/>
        /// </term>
        /// <term>
        /// Device can support colored Gouraud shading.
        /// In this mode, the per-vertex color components (red, green, and blue) are interpolated across a triangle face.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPSHADECAPS_FOGGOURAUD"/>
        /// </term>
        /// <term>
        /// Device can support fog in the Gouraud shading mode.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPSHADECAPS_SPECULARGOURAUDRGB"/>
        /// </term>
        /// <term>
        /// Device supports Gouraud shading of specular highlights.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public D3DPSHADECAPS ShadeCaps;

        /// <summary>
        /// <para>
        /// Miscellaneous texture-mapping capabilities.
        /// This member can be one or more of the following flags.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_ALPHA"/>
        /// </term>
        /// <term>
        /// Alpha in texture pixels is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_ALPHAPALETTE"/>
        /// </term>
        /// <term>
        /// Device can draw alpha from texture palettes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_CUBEMAP"/>
        /// </term>
        /// <term>
        /// Supports cube textures.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_CUBEMAP_POW2"/>
        /// </term>
        /// <term>
        /// Device requires that cube texture maps have dimensions specified as powers of two.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_MIPCUBEMAP"/>
        /// </term>
        /// <term>
        /// Device supports mipmapped cube textures.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_MIPMAP"/>
        /// </term>
        /// <term>
        /// Device supports mipmapped textures.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_MIPVOLUMEMAP"/>
        /// </term>
        /// <term>
        /// Device supports mipmapped volume textures.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_NONPOW2CONDITIONAL"/>
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="D3DPTEXTURECAPS_POW2"/> is also set,
        /// conditionally supports the use of 2D textures with dimensions that are not powers of two.
        /// A device that exposes this capability can use such a texture if all of the following requirements are met.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The texture addressing mode for the texture stage is set to <see cref="D3DTADDRESS_CLAMP"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Texture wrapping for the texture stage is disabled (D3DRS_WRAP n set to 0).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mipmapping is not in use (use magnification filter only).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Texture formats must not be <see cref="D3DFMT_DXT1"/> through <see cref="D3DFMT_DXT5"/>.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// If this flag is not set, and <see cref="D3DPTEXTURECAPS_POW2"/> is also not set,
        /// then unconditional support is provided for 2D textures with dimensions that are not powers of two.
        /// </para>
        /// <para>
        /// A texture that is not a power of two cannot be set at a stage that will be read based on a shader computation
        /// (such as the bem - ps and texm3x3 - ps instructions in pixel shaders versions 1_0 to 1_3).
        /// For example, these textures can be used to store bumps that will be fed into texture reads,
        /// but not the environment maps that are used in texbem - ps, texbeml - ps, and texm3x3spec - ps.
        /// This means that a texture with dimensions that are not powers of two cannot be addressed
        /// or sampled using texture coordinates computed within the shader.
        /// This type of operation is known as a dependent read and cannot be performed on these types of textures.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_NOPROJECTEDBUMPENV"/>
        /// </term>
        /// <term>
        /// Device does not support a projected bump-environment lookup operation in programmable and fixed function shaders.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_PERSPECTIVE"/>
        /// </term>
        /// <term>
        /// Perspective correction texturing is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_POW2"/>
        /// </term>
        /// <term>
        /// <para>
        /// If <see cref="D3DPTEXTURECAPS_NONPOW2CONDITIONAL"/> is not set,
        /// all textures must have widths and heights specified as powers of two.
        /// This requirement does not apply to either cube textures or volume textures.
        /// </para>
        /// <para>
        /// If <see cref="D3DPTEXTURECAPS_NONPOW2CONDITIONAL"/> is also set,
        /// conditionally supports the use of 2D textures with dimensions that are not powers of two.
        /// See <see cref="D3DPTEXTURECAPS_NONPOW2CONDITIONAL"/> description.
        /// </para>
        /// <para>
        /// If this flag is not set, and <see cref="D3DPTEXTURECAPS_NONPOW2CONDITIONAL"/> is also not set,
        /// then unconditional support is provided for 2D textures with dimensions that are not powers of two.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_PROJECTED"/>
        /// </term>
        /// <term>
        /// Supports the <see cref="D3DTTFF_PROJECTED"/> texture transformation flag.
        /// When applied, the device divides transformed texture coordinates by the last texture coordinate.
        /// If this capability is present, then the projective divide occurs per pixel.
        /// If this capability is not present, but the projective divide needs to occur anyway,
        /// then it is performed on a per-vertex basis by the Direct3D runtime.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_SQUAREONLY"/>
        /// </term>
        /// <term>
        /// All textures must be square.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_TEXREPEATNOTSCALEDBYSIZE"/>
        /// </term>
        /// <term>
        /// Texture indices are not scaled by the texture size prior to interpolation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_VOLUMEMAP"/>
        /// </term>
        /// <term>
        /// Device supports volume textures.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTEXTURECAPS_VOLUMEMAP_POW2"/>
        /// </term>
        /// <term>
        /// Device requires that volume texture maps have dimensions specified as powers of two.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public D3DPTEXTURECAPS TextureCaps;

        /// <summary>
        /// Texture-filtering capabilities for a texture.
        /// Per-stage filtering capabilities reflect which filtering modes are supported for texture stages when performing multiple-texture blending.
        /// This member can be any combination of the per-stage texture-filtering flags defined in <see cref="D3DPTFILTERCAPS"/>.
        /// </summary>
        public D3DPTFILTERCAPS TextureFilterCaps;

        /// <summary>
        /// Texture-filtering capabilities for a cube texture.
        /// Per-stage filtering capabilities reflect which filtering modes are supported for texture stages when performing multiple-texture blending.
        /// This member can be any combination of the per-stage texture-filtering flags defined in <see cref="D3DPTFILTERCAPS"/>.
        /// </summary>
        public D3DPTFILTERCAPS CubeTextureFilterCaps;

        /// <summary>
        /// Texture-filtering capabilities for a volume texture.
        /// Per-stage filtering capabilities reflect which filtering modes are supported for texture stages when performing multiple-texture blending.
        /// This member can be any combination of the per-stage texture-filtering flags defined in <see cref="D3DPTFILTERCAPS"/>.
        /// </summary>
        public D3DPTFILTERCAPS VolumeTextureFilterCaps;

        /// <summary>
        /// <para>
        /// Texture-addressing capabilities for texture objects.
        /// This member can be one or more of the following flags.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DPTADDRESSCAPS_BORDER"/>
        /// </term>
        /// <term>
        /// Device supports setting coordinates outside the range [0.0, 1.0] to the border color,
        /// as specified by the <see cref="D3DSAMP_BORDERCOLOR"/> texture-stage state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTADDRESSCAPS_CLAMP"/>
        /// </term>
        /// <term>
        /// Device can clamp textures to addresses.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTADDRESSCAPS_INDEPENDENTUV"/>
        /// </term>
        /// <term>
        /// Device can separate the texture-addressing modes of the u and v coordinates of the texture.
        /// This ability corresponds to the <see cref="D3DSAMP_ADDRESSU"/> and <see cref="D3DSAMP_ADDRESSV"/> render-state values.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTADDRESSCAPS_MIRROR"/>
        /// </term>
        /// <term>
        /// Device can mirror textures to addresses.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTADDRESSCAPS_MIRRORONCE"/>
        /// </term>
        /// <term>
        /// Device can take the absolute value of the texture coordinate (thus, mirroring around 0) and then clamp to the maximum value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTADDRESSCAPS_WRAP"/>
        /// </term>
        /// <term>
        /// Device can wrap textures to addresses.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public D3DPTADDRESSCAPS TextureAddressCaps;

        /// <summary>
        /// Texture-addressing capabilities for a volume texture.
        /// This member can be one or more of the flags defined for the <see cref="TextureAddressCaps"/> member.
        /// </summary>
        public D3DPTADDRESSCAPS VolumeTextureAddressCaps;

        /// <summary>
        /// <para>
        /// Defines the capabilities for line-drawing primitives.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DLINECAPS_ALPHACMP"/>
        /// </term>
        /// <term>
        /// Supports alpha-test comparisons.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DLINECAPS_ANTIALIAS"/>
        /// </term>
        /// <term>
        /// Antialiased lines are supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DLINECAPS_BLEND"/>
        /// </term>
        /// <term>
        /// Supports source-blending.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DLINECAPS_FOG"/>
        /// </term>
        /// <term>
        /// Supports fog.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DLINECAPS_TEXTURE"/>
        /// </term>
        /// <term>
        /// Supports texture-mapping.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DLINECAPS_ZTEST"/>
        /// </term>
        /// <term>
        /// Supports z-buffer comparisons.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public D3DLINECAPS LineCaps;

        /// <summary>
        /// Maximum texture width for this device.
        /// </summary>
        public DWORD MaxTextureWidth;

        /// <summary>
        /// Maximum texture height for this device.
        /// </summary>
        public DWORD MaxTextureHeight;

        /// <summary>
        /// Maximum value for any of the three dimensions (width, height, and depth) of a volume texture.
        /// </summary>
        public DWORD MaxVolumeExtent;

        /// <summary>
        /// <para>
        /// This number represents the maximum range of the integer bits of the post-normalized texture coordinates.
        /// A texture coordinate is stored as a 32-bit signed integer
        /// using 27 bits to store the integer part and 5 bits for the floating point fraction.
        /// The maximum integer index, 2²⁷, is used to determine the maximum texture coordinate,
        /// depending on how the hardware does texture-coordinate scaling.
        /// </para>
        /// <para>
        /// Some hardware reports the cap <see cref="D3DPTEXTURECAPS_TEXREPEATNOTSCALEDBYSIZE"/>.
        /// For this case, the device defers scaling texture coordinates by the texture size
        /// until after interpolation and application of the texture address mode,
        /// so the number of times a texture can be wrapped is given by the integer value in <see cref="MaxTextureRepeat"/>.
        /// </para>
        /// <para>
        /// Less desirably, on some hardware <see cref="D3DPTEXTURECAPS_TEXREPEATNOTSCALEDBYSIZE"/> is not set
        /// and the device scales the texture coordinates by the texture size (using the highest level of detail) prior to interpolation.
        /// This limits the number of times a texture can be wrapped to <see cref="MaxTextureRepeat"/> / texture size.
        /// </para>
        /// <para>
        /// For example, assume that <see cref="MaxTextureRepeat"/> is equal to 32k and the size of the texture is 4k.
        /// If the hardware sets <see cref="D3DPTEXTURECAPS_TEXREPEATNOTSCALEDBYSIZE"/>,
        /// then the number of times a texture can be wrapped is equal to <see cref="MaxTextureRepeat"/>,
        /// which is 32k in this example.
        /// Otherwise, the number of times a texture can be wrapped
        /// is equal to <see cref="MaxTextureRepeat"/> divided by texture size, which is 32k/4k in this example.
        /// </para>
        /// </summary>
        public DWORD MaxTextureRepeat;

        /// <summary>
        /// Maximum texture aspect ratio supported by the hardware, typically a power of 2.
        /// </summary>
        public DWORD MaxTextureAspectRatio;

        /// <summary>
        /// Maximum valid value for the <see cref="D3DSAMP_MAXANISOTROPY"/> texture-stage state.
        /// </summary>
        public DWORD MaxAnisotropy;

        /// <summary>
        /// Maximum W-based depth value that the device supports.
        /// </summary>
        public float MaxVertexW;

        /// <summary>
        /// Screen-space coordinate of the guard-band clipping region.
        /// Coordinates inside this rectangle but outside the viewport rectangle are automatically clipped.
        /// </summary>
        public float GuardBandLeft;

        /// <summary>
        /// Screen-space coordinate of the guard-band clipping region.
        /// Coordinates inside this rectangle but outside the viewport rectangle are automatically clipped.
        /// </summary>
        public float GuardBandTop;

        /// <summary>
        /// Screen-space coordinate of the guard-band clipping region.
        /// Coordinates inside this rectangle but outside the viewport rectangle are automatically clipped.
        /// </summary>
        public float GuardBandRight;

        /// <summary>
        /// Screen-space coordinate of the guard-band clipping region.
        /// Coordinates inside this rectangle but outside the viewport rectangle are automatically clipped.
        /// </summary>
        public float GuardBandBottom;

        /// <summary>
        /// Number of pixels to adjust the extents rectangle outward to accommodate antialiasing kernels.
        /// </summary>
        public float ExtentsAdjust;

        /// <summary>
        /// <para>
        /// Flags specifying supported stencil-buffer operations.
        /// Stencil operations are assumed to be valid for all three stencil-buffer operation render states
        /// (<see cref="D3DRS_STENCILFAIL"/>, <see cref="D3DRS_STENCILPASS"/>, and <see cref="D3DRS_STENCILZFAIL"/>).
        /// </para>
        /// <para>
        /// For more information, see <see cref="D3DSTENCILCAPS"/>.
        /// </para>
        /// </summary>
        public D3DSTENCILCAPS StencilCaps;

        /// <summary>
        /// <para>
        /// Flexible vertex format capabilities.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DFVFCAPS_DONOTSTRIPELEMENTS"/>
        /// </term>
        /// <term>
        /// It is preferable that vertex elements not be stripped.
        /// That is, if the vertex format contains elements that are not used with the current render states,
        /// there is no need to regenerate the vertices.
        /// If this capability flag is not present, stripping extraneous elements from the vertex format provides better performance.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DFVFCAPS_PSIZE"/>
        /// </term>
        /// <term>
        /// Point size is determined by either the render state or the vertex data.
        /// If an FVF is used, point size can come from point size data in the vertex declaration.
        /// Otherwise, point size is determined by the render state <see cref="D3DRS_POINTSIZE"/>.
        /// If the application provides point size in both (the render state and the vertex declaration),
        /// the vertex data overrides the render-state data.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DFVFCAPS_TEXCOORDCOUNTMASK"/>
        /// </term>
        /// <term>
        /// Masks the low <see cref="WORD"/> of <see cref="FVFCaps"/>.
        /// These bits, cast to the <see cref="WORD"/> data type,
        /// describe the total number of texture coordinate sets that the device can simultaneously use for multiple texture blending.
        /// (You can use up to eight texture coordinate sets for any vertex,
        /// but the device can blend using only the specified number of texture coordinate sets.)
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public D3DFVFCAPS FVFCaps;

        /// <summary>
        /// <para>
        /// Combination of flags describing the texture operations supported by this device.
        /// The following flags are defined.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_ADD"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_ADD"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_ADDSIGNED"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_ADDSIGNED"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_ADDSIGNED2X"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_ADDSIGNED2X"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_ADDSMOOTH"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_ADDSMOOTH"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_BLENDCURRENTALPHA"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_BLENDCURRENTALPHA"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_BLENDDIFFUSEALPHA"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_BLENDDIFFUSEALPHA"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_BLENDFACTORALPHA"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_BLENDFACTORALPHA"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_BLENDTEXTUREALPHA"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_BLENDTEXTUREALPHA"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_BLENDTEXTUREALPHAPM"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_BLENDTEXTUREALPHAPM"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_BUMPENVMAP"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_BUMPENVMAP"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_BUMPENVMAPLUMINANCE"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_BUMPENVMAPLUMINANCE"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_DISABLE"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_DISABLE"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_DOTPRODUCT3"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_DOTPRODUCT3"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_LERP"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_LERP"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_MODULATE"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_MODULATE"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_MODULATE2X"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_MODULATE2X"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_MODULATE4X"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_MODULATE4X"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_MODULATEALPHA_ADDCOLOR"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_MODULATEALPHA_ADDCOLOR"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_MODULATECOLOR_ADDALPHA"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_MODULATECOLOR_ADDALPHA"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_MODULATEINVALPHA_ADDCOLOR"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_MODULATEINVALPHA_ADDCOLOR"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_MODULATEINVCOLOR_ADDALPHA"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_MODULATEINVCOLOR_ADDALPHA"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_MULTIPLYADD"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_MULTIPLYADD"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_PREMODULATE"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_PREMODULATE"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_SELECTARG1"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_SELECTARG1"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_SELECTARG2"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_SELECTARG2"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DTEXOPCAPS_SUBTRACT"/>
        /// </term>
        /// <term>
        /// The <see cref="D3DTOP_SUBTRACT"/> texture-blending operation is supported.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public D3DTEXOPCAPS TextureOpCaps;

        /// <summary>
        /// Maximum number of texture-blending stages supported in the fixed function pipeline.
        /// This value is the number of blenders available.
        /// In the programmable pixel pipeline, this corresponds to the number of unique texture registers used by pixel shader instructions.
        /// </summary>
        public DWORD MaxTextureBlendStages;

        /// <summary>
        /// <para>
        /// Maximum number of textures that can be simultaneously bound to the fixed-function pipeline sampler stages.
        /// If the same texture is bound to two sampler stages, it counts as two textures.
        /// </para>
        /// <para>
        /// This value has no meaning in the programmable pipeline
        /// where the number of sampler stages is determined by each pixel shader version.
        /// Each pixel shader version also determines the number of texture declaration instructions.
        /// See Pixel Shaders.
        /// </para>
        /// </summary>
        public DWORD MaxSimultaneousTextures;

        /// <summary>
        /// Vertex processing capabilities.
        /// For a given physical device, this capability might vary across Direct3D devices
        /// depending on the parameters supplied to <see cref="IDirect3D9.CreateDevice"/>.
        /// See <see cref="D3DVTXPCAPS"/>.
        /// </summary>
        public D3DVTXPCAPS VertexProcessingCaps;

        /// <summary>
        /// Maximum number of lights that can be active simultaneously.
        /// For a given physical device, this capability might vary across Direct3D devices
        /// depending on the parameters supplied to <see cref="IDirect3D9.CreateDevice"/>.
        /// </summary>
        public DWORD MaxActiveLights;

        /// <summary>
        /// Maximum number of user-defined clipping planes supported.
        /// This member can be 0.
        /// For a given physical device, this capability may vary across Direct3D devices
        /// depending on the parameters supplied to <see cref="IDirect3D9.CreateDevice"/>.
        /// </summary>
        public DWORD MaxUserClipPlanes;

        /// <summary>
        /// Maximum number of matrices that this device can apply when performing multimatrix vertex blending.
        /// For a given physical device, this capability may vary across Direct3D devices
        /// depending on the parameters supplied to <see cref="IDirect3D9.CreateDevice"/>.
        /// </summary>
        public DWORD MaxVertexBlendMatrices;

        /// <summary>
        /// <para>
        /// <see cref="DWORD"/> value that specifies the maximum matrix index that can be indexed into using the per-vertex indices.
        /// The number of matrices is <see cref="MaxVertexBlendMatrixIndex"/> + 1, which is the size of the matrix palette.
        /// If normals are present in the vertex data that needs to be blended for lighting,
        /// then the number of matrices is half the number specified by this capability flag.
        /// If <see cref="MaxVertexBlendMatrixIndex"/> is set to zero, the driver does not support indexed vertex blending.
        /// If this value is not zero then the valid range of indices is zero through <see cref="MaxVertexBlendMatrixIndex"/>.
        /// </para>
        /// <para>
        /// A zero value for <see cref="MaxVertexBlendMatrixIndex"/> indicates that the driver does not support indexed matrices.
        /// </para>
        /// <para>
        /// When software vertex processing is used,
        /// 256 matrices could be used for indexed vertex blending, with or without normal blending.
        /// </para>
        /// <para>
        /// For a given physical device, this capability may vary across Direct3D devices
        /// depending on the parameters supplied to <see cref="IDirect3D9.CreateDevice"/>.
        /// </para>
        /// </summary>
        public DWORD MaxVertexBlendMatrixIndex;

        /// <summary>
        /// Maximum size of a point primitive.
        /// If set to 1.0f then device does not support point size control.
        /// The range is greater than or equal to 1.0f.
        /// </summary>
        public float MaxPointSize;

        /// <summary>
        /// <para>
        /// Maximum number of primitives for each <see cref="IDirect3DDevice9.DrawPrimitive"/> call.
        /// There are two cases:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If <see cref="MaxPrimitiveCount"/> is not equal to 0xffff,
        /// you can draw at most <see cref="MaxPrimitiveCount"/> primitives with each draw call.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// However, if <see cref="MaxPrimitiveCount"/> equals 0xffff,
        /// you can still draw at most <see cref="MaxPrimitiveCount"/> primitive,
        /// but you may also use no more than <see cref="MaxPrimitiveCount"/> unique vertices
        /// (since each primitive can potentially use three different vertices).
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public DWORD MaxPrimitiveCount;

        /// <summary>
        /// Maximum size of indices supported for hardware vertex processing.
        /// It is possible to create 32-bit index buffers;
        /// however, you will not be able to render with the index buffer unless this value is greater than 0x0000FFFF.
        /// </summary>
        public DWORD MaxVertexIndex;

        /// <summary>
        /// Maximum number of concurrent data streams for <see cref="IDirect3DDevice9.SetStreamSource"/>.
        /// The valid range is 1 to 16.
        /// Note that if this value is 0, then the driver is not a Direct3D 9 driver.
        /// </summary>
        public DWORD MaxStreams;

        /// <summary>
        /// Maximum stride for <see cref="IDirect3DDevice9.SetStreamSource"/>.
        /// </summary>
        public DWORD MaxStreamStride;

        /// <summary>
        /// Two numbers that represent the vertex shader main and sub versions.
        /// For more information about the instructions supported for each vertex shader version,
        /// see Version 1_x, Version 2_0, Version 2_0 Extended, or Version 3_0.
        /// </summary>
        public DWORD VertexShaderVersion;

        /// <summary>
        /// The number of vertex shader Vertex Shader Registers that are reserved for constants.
        /// </summary>
        public DWORD MaxVertexShaderConst;

        /// <summary>
        /// Two numbers that represent the pixel shader main and sub versions.
        /// For more information about the instructions supported for each pixel shader version,
        /// see Version 1_x, Version 2_0, Version 2_0 Extended, or Version 3_0.
        /// </summary>
        public DWORD PixelShaderVersion;

        /// <summary>
        /// Maximum value of pixel shader arithmetic component.
        /// This value indicates the internal range of values supported for pixel color blending operations.
        /// Within the range that they report to, implementations must allow data to pass through pixel processing unmodified (unclamped).
        /// Normally, the value of this member is an absolute value.
        /// For example, a 1.0 indicates that the range is -1.0 to 1, and an 8.0 indicates that the range is -8.0 to 8.0.
        /// The value must be >= 1.0 for any hardware that supports pixel shaders.
        /// </summary>
        public float PixelShader1xMaxValue;

        /// <summary>
        /// Device driver capabilities for adaptive tessellation.
        /// For more information, see <see cref="D3DDEVCAPS2"/>
        /// </summary>
        public D3DDEVCAPS2 DevCaps2;

        /// <summary>
        /// TBD
        /// </summary>
        public float MaxNpatchTessellationLevel;

        /// <summary>
        /// TBD
        /// </summary>
        public DWORD Reserved5;

        /// <summary>
        /// <para>
        /// This number indicates which device is the master for this subordinate.
        /// This number is taken from the same space as the adapter values.
        /// </para>
        /// <para>
        /// For multihead support, one head will be denoted the master head,
        /// and all other heads on the same card will be denoted subordinate heads.
        /// If more than one multihead adapter is present in a system,
        /// the master and its subordinates from one multihead adapter are called a group.
        /// </para>
        /// </summary>
        public UINT MasterAdapterOrdinal;

        /// <summary>
        /// This number indicates the order in which heads are referenced by the API.
        /// The value for the master adapter is always 0.
        /// These values do not correspond to the adapter ordinals.
        /// They apply only to heads within a group.
        /// </summary>
        public UINT AdapterOrdinalInGroup;

        /// <summary>
        /// This number indicates the order in which heads are referenced by the API.
        /// The value for the master adapter is always 0.
        /// These values do not correspond to the adapter ordinals.
        /// They apply only to heads within a group.
        /// </summary>
        public UINT NumberOfAdaptersInGroup;

        /// <summary>
        /// A combination of one or more data types contained in a vertex declaration.
        /// See D3DDTCAPS.
        /// </summary>
        public DWORD DeclTypes;

        /// <summary>
        /// Number of simultaneous render targets.
        /// This number must be at least one.
        /// </summary>
        public DWORD NumSimultaneousRTs;

        /// <summary>
        /// <para>
        /// Combination of constants that describe the operations supported by <see cref="IDirect3DDevice9.StretchRect"/>.
        /// The flags that may be set in this field are:
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Constant
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="D3DPTFILTERCAPS_MINFPOINT"/>
        /// </term>
        /// <term>
        /// Device supports point-sample filtering for minifying rectangles.
        /// This filter type is requested by calling <see cref="IDirect3DDevice9.StretchRect"/> using <see cref="D3DTEXF_POINT"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTFILTERCAPS_MAGFPOINT"/>
        /// </term>
        /// <term>
        /// Device supports point-sample filtering for magnifying rectangles
        /// This filter type is requested by calling <see cref="IDirect3DDevice9.StretchRect"/> using <see cref="D3DTEXF_POINT"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTFILTERCAPS_MINFLINEAR"/>
        /// </term>
        /// <term>
        /// Device supports bilinear interpolation filtering for minifying rectangles.
        /// This filter type is requested by calling <see cref="IDirect3DDevice9.StretchRect"/> using <see cref="D3DTEXF_LINEAR"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DPTFILTERCAPS_MAGFLINEAR"/>
        /// </term>
        /// <term>
        /// Device supports bilinear interpolation filtering for magnifying rectangles.
        /// This filter type is requested by calling <see cref="IDirect3DDevice9.StretchRect"/> using <see cref="D3DTEXF_LINEAR"/>.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// For more information, see <see cref="D3DTEXTUREFILTERTYPE"/> and <see cref="D3DTEXTUREFILTERTYPE"/>.
        /// </para>
        /// </summary>
        public D3DPTFILTERCAPS StretchRectFilterCaps;

        /// <summary>
        /// Device supports vertex shader version 2_0 extended capability.
        /// See <see cref="D3DVSHADERCAPS2_0"/>.
        /// </summary>
        public D3DVSHADERCAPS2_0 VS20Caps;

        /// <summary>
        /// Device supports pixel shader version 2_0 extended capability.
        /// See <see cref="D3DPSHADERCAPS2_0"/>.
        /// </summary>
        public D3DPSHADERCAPS2_0 PS20Caps;

        /// <summary>
        /// Device supports vertex shader texture filter capability.
        /// See <see cref="D3DPTFILTERCAPS"/>.
        /// </summary>
        public D3DPTFILTERCAPS VertexTextureFilterCaps;

        /// <summary>
        /// Maximum number of vertex shader instructions that can be run when using flow control.
        /// The maximum number of instructions that can be programmed is <see cref="MaxVertexShader30InstructionSlots"/>.
        /// </summary>
        public DWORD MaxVShaderInstructionsExecuted;

        /// <summary>
        /// Maximum number of pixel shader instructions that can be run when using flow control.
        /// The maximum number of instructions that can be programmed is <see cref="MaxPixelShader30InstructionSlots"/>.
        /// </summary>
        public DWORD MaxPShaderInstructionsExecuted;

        /// <summary>
        /// Maximum number of vertex shader instruction slots supported.
        /// The maximum value that can be set on this cap is 32768.
        /// Devices that support vs_3_0 are required to support at least 512 instruction slots.
        /// </summary>
        public DWORD MaxVertexShader30InstructionSlots;

        /// <summary>
        /// Maximum number of pixel shader instruction slots supported.
        /// The maximum value that can be set on this cap is 32768.
        /// Devices that support ps_3_0 are required to support at least 512 instruction slots.
        /// </summary>
        public DWORD MaxPixelShader30InstructionSlots;
    }
}
