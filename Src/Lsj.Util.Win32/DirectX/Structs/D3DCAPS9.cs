using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3DBLEND;
using static Lsj.Util.Win32.DirectX.Enums.D3DCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DCURSORCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DDEVCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DFORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DFVFCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DLINECAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DPBLENDCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRASTERCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRIMCAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

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
    /// The <see cref="MaxTextureBlendStages"/> and <see cref="MaxSimultaneousTextures"/> members might seem similar, but they contain different information.
    /// The <see cref="MaxTextureBlendStages"/> member contains the total number of texture-blending stages supported by the current device,
    /// and the <see cref="MaxSimultaneousTextures"/> member describes how many of those stages can have textures
    /// bound to them by using the <see cref="IDirect3DDevice9.SetTexture"/> method.
    /// When the driver fills this structure, it can set values for execute-buffer capabilities, even when the interface being used
    /// to retrieve the capabilities (such as <see cref="IDirect3DDevice9"/>) does not support execute buffers.
    /// In general, performance problems may occur if you use a texture and then modify it during a scene.
    /// Ensure that no texture used in the current <see cref="IDirect3DDevice9.BeginScene"/>
    /// and <see cref="IDirect3DDevice9.EndScene"/> block is evicted unless absolutely necessary.
    /// In the case of extremely high texture usage within a scene, the results are undefined.
    /// This occurs when you modify a texture that you have used in the scene and there is no spare texture memory available.
    /// For such systems, the contents of the z-buffer become invalid at <see cref="IDirect3DDevice9.EndScene"/>.
    /// Applications should not call <see cref="IDirect3DDevice9.UpdateSurface"/> to or from the back buffer
    /// on this type of hardware inside a <see cref="IDirect3DDevice9.BeginScene"/>/<see cref="IDirect3DDevice9.EndScene"/> pair.
    /// In addition, applications should not try to access the z-buffer if the <see cref="D3DPRASTERCAPS_ZBUFFERLESSHSR"/> capability flag is set.
    /// Finally, applications should not lock the back buffer or the z-buffer
    /// inside a <see cref="IDirect3DDevice9.BeginScene"/>/<see cref="IDirect3DDevice9.EndScene"/> pair.
    /// The following flags concerning mipmapped textures are not supported in Direct3D 9.
    /// <see cref="D3DPTFILTERCAPS_LINEAR"/>, <see cref="D3DPTFILTERCAPS_LINEARMIPLINEAR"/>,
    /// <see cref="D3DPTFILTERCAPS_LINEARMIPNEAREST"/>, <see cref="D3DPTFILTERCAPS_MIPNEAREST"/>,
    /// <see cref="D3DPTFILTERCAPS_NEAREST"/>
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
        /// The following driver-specific capability.
        /// <see cref="D3DCAPS_READ_SCANLINE"/>:
        /// Display hardware is capable of returning the current scan line.
        /// <see cref="D3DCAPS_OVERLAY"/>:
        /// The display driver supports an overlay DDI that allows for verification of overlay capabilities.
        /// For more information about the overlay DDI, see Overlay DDI.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
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
        /// Bit mask of values representing what presentation swap intervals are available.
        /// <see cref="D3DPRESENT_INTERVAL_IMMEDIATE"/>: The driver supports an immediate presentation swap interval.
        /// <see cref="D3DPRESENT_INTERVAL_ONE"/>: The driver supports a presentation swap interval of every screen refresh.
        /// <see cref="D3DPRESENT_INTERVAL_TWO"/>: The driver supports a presentation swap interval of every second screen refresh.
        /// <see cref="D3DPRESENT_INTERVAL_THREE"/>: The driver supports a presentation swap interval of every third screen refresh.
        /// <see cref="D3DPRESENT_INTERVAL_FOUR"/>: The driver supports a presentation swap interval of every fourth screen refresh.
        /// </summary>
        public DWORD PresentationIntervals;

        /// <summary>
        /// Bit mask indicating what hardware support is available for cursors.
        /// Direct3D 9 does not define alpha-blending cursor capabilities.
        /// <see cref="D3DCURSORCAPS_COLOR"/>:
        /// A full-color cursor is supported in hardware.
        /// Specifically, this flag indicates that the driver supports at least a hardware color cursor in high-resolution modes
        /// (with scan lines greater than or equal to 400).
        /// <see cref="D3DCURSORCAPS_LOWRES"/>:
        /// A full-color cursor is supported in hardware.
        /// Specifically, this flag indicates that the driver supports a hardware color cursor in both high-resolution and low-resolution modes
        /// (with scan lines less than 400).
        /// </summary>
        public D3DCURSORCAPS CursorCaps;

        /// <summary>
        /// Flags identifying the capabilities of the device.
        /// <see cref="D3DDEVCAPS_CANBLTSYSTONONLOCAL"/>:
        /// Device supports blits from system-memory textures to nonlocal video-memory textures.
        /// <see cref="D3DDEVCAPS_CANRENDERAFTERFLIP"/>:
        /// Device can queue rendering commands after a page flip.
        /// Applications do not change their behavior if this flag is set; this capability means that the device is relatively fast.
        /// <see cref="D3DDEVCAPS_DRAWPRIMITIVES2"/>:
        /// Device can support at least a DirectX 5-compliant driver.
        /// <see cref="D3DDEVCAPS_DRAWPRIMITIVES2EX"/>:
        /// Device can support at least a DirectX 7-compliant driver.
        /// <see cref="D3DDEVCAPS_DRAWPRIMTLVERTEX"/>:
        /// Device exports an <see cref="IDirect3DDevice9.DrawPrimitive"/>-aware hal.
        /// <see cref="D3DDEVCAPS_EXECUTESYSTEMMEMORY"/>:
        /// Device can use execute buffers from system memory.
        /// <see cref="D3DDEVCAPS_EXECUTEVIDEOMEMORY"/>:
        /// Device can use execute buffers from video memory.
        /// <see cref="D3DDEVCAPS_HWRASTERIZATION"/>:
        /// Device has hardware acceleration for scene rasterization.
        /// <see cref="D3DDEVCAPS_HWTRANSFORMANDLIGHT"/>:
        /// Device can support transformation and lighting in hardware.
        /// <see cref="D3DDEVCAPS_NPATCHES"/>:
        /// Device supports N patches.
        /// <see cref="D3DDEVCAPS_PUREDEVICE"/>:
        /// Device can support rasterization, transform, lighting, and shading in hardware.
        /// <see cref="D3DDEVCAPS_QUINTICRTPATCHES"/>:
        /// Device supports quintic Bézier curves and B-splines.
        /// <see cref="D3DDEVCAPS_RTPATCHES"/>:
        /// Device supports rectangular and triangular patches.
        /// <see cref="D3DDEVCAPS_RTPATCHHANDLEZERO"/>:
        /// When this device capability is set, the hardware architecture does not require caching of any information,
        /// and uncached patches (handle zero) will be drawn as efficiently as cached ones.
        /// Note that setting <see cref="D3DDEVCAPS_RTPATCHHANDLEZERO"/> does not mean that a patch with handle zero can be drawn.
        /// A handle-zero patch can always be drawn whether this cap is set or not.
        /// <see cref="D3DDEVCAPS_SEPARATETEXTUREMEMORIES"/>:
        /// Device is texturing from separate memory pools.
        /// <see cref="D3DDEVCAPS_TEXTURENONLOCALVIDMEM"/>:
        /// Device can retrieve textures from non-local video memory.
        /// <see cref="D3DDEVCAPS_TEXTURESYSTEMMEMORY"/>:
        /// Device can retrieve textures from system memory.
        /// <see cref="D3DDEVCAPS_TEXTUREVIDEOMEMORY"/>:
        /// Device can retrieve textures from device memory.
        /// <see cref="D3DDEVCAPS_TLVERTEXSYSTEMMEMORY"/>:
        /// Device can use buffers from system memory for transformed and lit vertices.
        /// <see cref="D3DDEVCAPS_TLVERTEXVIDEOMEMORY"/>:
        /// Device can use buffers from video memory for transformed and lit vertices.
        /// </summary>
        public D3DDEVCAPS DevCaps;

        /// <summary>
        /// Miscellaneous driver primitive capabilities.
        /// See <see cref="D3DPMISCCAPS"/>.
        /// </summary>
        public DWORD PrimitiveMiscCaps;

        /// <summary>
        /// Information on raster-drawing capabilities. This member can be one or more of the following flags.
        /// <see cref="D3DPRASTERCAPS_ANISOTROPY"/>:
        /// Device supports anisotropic filtering.
        /// <see cref="D3DPRASTERCAPS_COLORPERSPECTIVE"/>:
        /// Device iterates colors perspective correctly.
        /// <see cref="D3DPRASTERCAPS_DITHER"/>:
        /// Device can dither to improve color resolution.
        /// <see cref="D3DPRASTERCAPS_DEPTHBIAS"/>:
        /// Device supports legacy depth bias.
        /// For true depth bias, see <see cref="D3DPRASTERCAPS_SLOPESCALEDEPTHBIAS"/>.
        /// <see cref="D3DPRASTERCAPS_FOGRANGE"/>:
        /// Device supports range-based fog. In range-based fog, the distance of an object from the viewer is used to compute fog effects,
        /// not the depth of the object (that is, the z-coordinate) in the scene.
        /// <see cref="D3DPRASTERCAPS_FOGTABLE"/>:
        /// Device calculates the fog value by referring to a lookup table containing fog values that are indexed to the depth of a given pixel.
        /// <see cref="D3DPRASTERCAPS_FOGVERTEX"/>:
        /// Device calculates the fog value during the lighting operation and interpolates the fog value during rasterization.
        /// <see cref="D3DPRASTERCAPS_MIPMAPLODBIAS"/>:
        /// Device supports level-of-detail bias adjustments.
        /// These bias adjustments enable an application to make a mipmap appear crisper or less sharp than it normally would.
        /// For more information about level-of-detail bias in mipmaps, see <see cref="D3DSAMP_MIPMAPLODBIAS"/>.
        /// <see cref="D3DPRASTERCAPS_MULTISAMPLE_TOGGLE"/>:
        /// Device supports toggling multisampling on and off between <see cref="IDirect3DDevice9.BeginScene"/>
        /// and <see cref="IDirect3DDevice9.EndScene"/> (using <see cref="D3DRS_MULTISAMPLEANTIALIAS"/>).
        /// <see cref="D3DPRASTERCAPS_SCISSORTEST"/>:
        /// Device supports scissor test. See Scissor Test (Direct3D 9).
        /// <see cref="D3DPRASTERCAPS_SLOPESCALEDEPTHBIAS"/>:
        /// Device performs true slope-scale based depth bias. This is in contrast to the legacy style depth bias.
        /// <see cref="D3DPRASTERCAPS_WBUFFER"/>:
        /// Device supports depth buffering using w.
        /// <see cref="D3DPRASTERCAPS_WFOG"/>:
        /// Device supports w-based fog. W-based fog is used when a perspective projection matrix is specified, but affine projections still use z-based fog.
        /// The system considers a projection matrix that contains a nonzero value in the [3][4] element to be a perspective projection matrix.
        /// <see cref="D3DPRASTERCAPS_ZBUFFERLESSHSR"/>:
        /// Device can perform hidden-surface removal (HSR) without requiring the application
        /// to sort polygons and without requiring the allocation of a depth-buffer.
        /// This leaves more video memory for textures.
        /// The method used to perform HSR is hardware-dependent and is transparent to the application.
        /// Z-bufferless HSR is performed if no depth-buffer surface is associated with the rendering-target surface
        /// and the depth-buffer comparison test is enabled
        /// (that is, when the state value associated with the <see cref="D3DRS_ZENABLE"/> enumeration constant is set to <see cref="TRUE"/>).
        /// <see cref="D3DPRASTERCAPS_ZFOG"/>:
        /// Device supports z-based fog.
        /// <see cref="D3DPRASTERCAPS_ZTEST"/>:
        /// Device can perform z-test operations.
        /// This effectively renders a primitive and indicates whether any z pixels have been rendered.
        /// </summary>
        public D3DPRASTERCAPS RasterCaps;

        /// <summary>
        /// Z-buffer comparison capabilities.
        /// This member can be one or more of the following flags.
        /// <see cref="D3DPCMPCAPS_ALWAYS"/>:
        /// Always pass the z-test.
        /// <see cref="D3DPCMPCAPS_EQUAL"/>:
        /// Pass the z-test if the new z equals the current z.
        /// <see cref="D3DPCMPCAPS_GREATER"/>:
        /// Pass the z-test if the new z is greater than the current z.
        /// <see cref="D3DPCMPCAPS_GREATEREQUAL"/>:
        /// Pass the z-test if the new z is greater than or equal to the current z.
        /// <see cref="D3DPCMPCAPS_LESS"/>:
        /// ass the z-test if the new z is less than the current z.
        /// <see cref="D3DPCMPCAPS_LESSEQUAL"/>:
        /// Pass the z-test if the new z is less than or equal to the current z.
        /// <see cref="D3DPCMPCAPS_NEVER"/>:
        /// Always fail the z-test.
        /// <see cref="D3DPCMPCAPS_NOTEQUAL"/>:
        /// Pass the z-test if the new z does not equal the current z.
        /// </summary>
        public D3DPRIMCAPS ZCmpCaps;

        /// <summary>
        /// Source-blending capabilities.
        /// This member can be one or more of the following flags. (The RGBA values of the source and destination are indicated by the subscripts s and d.)
        /// <see cref="D3DPBLENDCAPS_BLENDFACTOR"/>:
        /// The driver supports both <see cref="D3DBLEND_BLENDFACTOR"/> and <see cref="D3DBLEND_INVBLENDFACTOR"/>.
        /// See <see cref="D3DBLEND"/>.
        /// <see cref="D3DPBLENDCAPS_BOTHINVSRCALPHA"/>:
        /// Source blend factor is (1 - Aₛ, 1 - Aₛ, 1 - Aₛ, 1 - Aₛ) and destination blend factor is (Aₛ, Aₛ, Aₛ, Aₛ); the destination blend selection is overridden.
        /// <see cref="D3DPBLENDCAPS_BOTHSRCALPHA"/>:
        /// The driver supports the <see cref="D3DBLEND_BOTHSRCALPHA"/> blend mode.
        /// (This blend mode is obsolete. For more information, see <see cref="D3DBLEND"/>.)
        /// <see cref="D3DPBLENDCAPS_DESTALPHA"/>:
        /// Blend factor is (Ad, Ad, Ad, Ad).
        /// <see cref="D3DPBLENDCAPS_DESTCOLOR"/>:
        /// Blend factor is (Rd, Gd, Bd, Ad).
        /// <see cref="D3DPBLENDCAPS_INVDESTALPHA"/>:
        /// Blend factor is (1 - Ad, 1 - Ad, 1 - Ad, 1 - Ad).
        /// <see cref="D3DPBLENDCAPS_INVDESTCOLOR"/>:
        /// Blend factor is (1 - Rd, 1 - Gd, 1 - Bd, 1 - Ad).
        /// <see cref="D3DPBLENDCAPS_INVSRCALPHA"/>:
        /// Blend factor is (1 - Aₛ, 1 - Aₛ, 1 - Aₛ, 1 - Aₛ).
        /// <see cref="D3DPBLENDCAPS_INVSRCCOLOR"/>:
        /// Blend factor is (1 - Rₛ, 1 - Gₛ, 1 - Bₛ, 1 - Aₛ).
        /// <see cref="D3DPBLENDCAPS_INVSRCCOLOR2"/>:
        /// Blend factor is (1 - PSOutColor[1] r, 1 - PSOutColor[1] g, 1 - PSOutColor[1] b, not used)). See Render Target Blending.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// <see cref="D3DPBLENDCAPS_ONE"/>:
        /// Blend factor is (1, 1, 1, 1).
        /// <see cref="D3DPBLENDCAPS_SRCALPHA"/>:
        /// Blend factor is (Aₛ, Aₛ, Aₛ, Aₛ).
        /// <see cref="D3DPBLENDCAPS_SRCALPHASAT"/>:
        /// Blend factor is (f, f, f, 1); f = min(Aₛ, 1 - Ad).
        /// <see cref="D3DPBLENDCAPS_SRCCOLOR"/>:
        /// Blend factor is (Rₛ, Gₛ, Bₛ, Aₛ).
        /// <see cref="D3DPBLENDCAPS_SRCCOLOR2"/>:
        /// Blend factor is (PSOutColor[1]r, PSOutColor[1]g, PSOutColor[1]b, not used). See Render Target Blending.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// <see cref="D3DPBLENDCAPS_ZERO"/>:
        /// Blend factor is (0, 0, 0, 0).
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
        /// Shading operations capabilities.
        /// It is assumed, in general, that if a device supports a given command at all,
        /// it supports the <see cref="D3DSHADE_FLAT"/> mode (as specified in the <see cref="D3DSHADEMODE"/> enumerated type).
        /// This flag specifies whether the driver can also support Gouraud shading and whether alpha color components are supported.
        /// When alpha components are not supported, the alpha value of colors generated is implicitly 255.
        /// This is the maximum possible alpha (that is, the alpha component is at full intensity).
        /// The color, specular highlights, fog, and alpha interpolants of a triangle each have capability flags
        /// that an application can use to find out how they are implemented by the device driver.
        /// This member can be one or more of the following flags.
        /// <see cref="D3DPSHADECAPS_ALPHAGOURAUDBLEND"/>:
        /// Device can support an alpha component for Gouraud-blended transparency
        /// (the <see cref="D3DSHADE_GOURAUD"/> state for the <see cref="D3DSHADEMODE"/> enumerated type).
        /// In this mode, the alpha color component of a primitive is provided at vertices and interpolated across a face along with the other color components.
        /// <see cref="D3DPSHADECAPS_COLORGOURAUDRGB"/>:
        /// Device can support colored Gouraud shading.
        /// In this mode, the per-vertex color components (red, green, and blue) are interpolated across a triangle face.
        /// <see cref="D3DPSHADECAPS_FOGGOURAUD"/>:
        /// Device can support fog in the Gouraud shading mode.
        /// <see cref="D3DPSHADECAPS_SPECULARGOURAUDRGB"/>:
        /// Device supports Gouraud shading of specular highlights.
        /// </summary>
        public DWORD ShadeCaps;

        /// <summary>
        /// Miscellaneous texture-mapping capabilities.
        /// This member can be one or more of the following flags.
        /// <see cref="D3DPTEXTURECAPS_ALPHA"/>:
        /// Alpha in texture pixels is supported.
        /// <see cref="D3DPTEXTURECAPS_ALPHAPALETTE"/>:
        /// Device can draw alpha from texture palettes
        /// <see cref="D3DPTEXTURECAPS_CUBEMAP"/>:
        /// Supports cube textures.
        /// <see cref="D3DPTEXTURECAPS_CUBEMAP_POW2"/>:
        /// Device requires that cube texture maps have dimensions specified as powers of two.
        /// <see cref="D3DPTEXTURECAPS_MIPCUBEMAP"/>:
        /// Device supports mipmapped cube textures.
        /// <see cref="D3DPTEXTURECAPS_MIPMAP"/>:
        /// Device supports mipmapped textures.
        /// <see cref="D3DPTEXTURECAPS_MIPVOLUMEMAP"/>:
        /// Device supports mipmapped volume textures.
        /// <see cref="D3DPTEXTURECAPS_NONPOW2CONDITIONAL"/>:
        /// <see cref="D3DPTEXTURECAPS_POW2"/> is also set, conditionally supports the use of 2D textures with dimensions that are not powers of two.
        /// A device that exposes this capability can use such a texture if all of the following requirements are met.
        /// The texture addressing mode for the texture stage is set to D3DTADDRESS_CLAMP.
        /// Texture wrapping for the texture stage is disabled (D3DRS_WRAP n set to 0).
        /// Mipmapping is not in use (use magnification filter only).
        /// Texture formats must not be <see cref="D3DFMT_DXT1"/> through <see cref="D3DFMT_DXT5"/>.
        /// If this flag is not set, and <see cref="D3DPTEXTURECAPS_POW2"/> is also not set,
        /// then unconditional support is provided for 2D textures with dimensions that are not powers of two.
        /// A texture that is not a power of two cannot be set at a stage that will be read based on a shader computation
        /// (such as the bem - ps and texm3x3 - ps instructions in pixel shaders versions 1_0 to 1_3).
        /// For example, these textures can be used to store bumps that will be fed into texture reads,
        /// but not the environment maps that are used in texbem - ps, texbeml - ps, and texm3x3spec - ps.
        /// This means that a texture with dimensions that are not powers of two cannot be addressed or sampled using texture coordinates computed within the shader.
        /// This type of operation is known as a dependent read and cannot be performed on these types of textures.
        /// <see cref="D3DPTEXTURECAPS_NOPROJECTEDBUMPENV"/>:
        /// Device does not support a projected bump-environment lookup operation in programmable and fixed function shaders.
        /// <see cref="D3DPTEXTURECAPS_PERSPECTIVE"/>:
        /// Perspective correction texturing is supported.
        /// <see cref="D3DPTEXTURECAPS_POW2"/>:
        /// If <see cref="D3DPTEXTURECAPS_NONPOW2CONDITIONAL"/> is not set, all textures must have widths and heights specified as powers of two.
        /// This requirement does not apply to either cube textures or volume textures.
        /// If <see cref="D3DPTEXTURECAPS_NONPOW2CONDITIONAL"/> is also set, conditionally supports the use of 2D textures with dimensions that are not powers of two.
        /// See <see cref="D3DPTEXTURECAPS_NONPOW2CONDITIONAL"/> description.If this flag is not set,
        /// and <see cref="D3DPTEXTURECAPS_NONPOW2CONDITIONAL"/> is also not set,
        /// then unconditional support is provided for 2D textures with dimensions that are not powers of two.
        /// <see cref="D3DPTEXTURECAPS_PROJECTED"/>:
        /// Supports the <see cref="D3DTTFF_PROJECTED"/> texture transformation flag.
        /// When applied, the device divides transformed texture coordinates by the last texture coordinate.
        /// If this capability is present, then the projective divide occurs per pixel.
        /// If this capability is not present, but the projective divide needs to occur anyway,
        /// then it is performed on a per-vertex basis by the Direct3D runtime.
        /// <see cref="D3DPTEXTURECAPS_SQUAREONLY"/>:
        /// All textures must be square.
        /// <see cref="D3DPTEXTURECAPS_TEXREPEATNOTSCALEDBYSIZE"/>:
        /// Texture indices are not scaled by the texture size prior to interpolation.
        /// <see cref="D3DPTEXTURECAPS_VOLUMEMAP"/>:
        /// Device supports volume textures.
        /// <see cref="D3DPTEXTURECAPS_VOLUMEMAP_POW2"/>:
        /// Device requires that volume texture maps have dimensions specified as powers of two.
        /// </summary>
        public DWORD TextureCaps;

        /// <summary>
        /// Texture-filtering capabilities for a texture.
        /// Per-stage filtering capabilities reflect which filtering modes are supported for texture stages when performing multiple-texture blending.
        /// This member can be any combination of the per-stage texture-filtering flags defined in <see cref="D3DPTFILTERCAPS"/>.
        /// </summary>
        public DWORD TextureFilterCaps;

        /// <summary>
        /// Texture-filtering capabilities for a cube texture.
        /// Per-stage filtering capabilities reflect which filtering modes are supported for texture stages when performing multiple-texture blending.
        /// This member can be any combination of the per-stage texture-filtering flags defined in <see cref="D3DPTFILTERCAPS"/>.
        /// </summary>
        public DWORD CubeTextureFilterCaps;

        /// <summary>
        /// Texture-filtering capabilities for a volume texture.
        /// Per-stage filtering capabilities reflect which filtering modes are supported for texture stages when performing multiple-texture blending.
        /// This member can be any combination of the per-stage texture-filtering flags defined in <see cref="D3DPTFILTERCAPS"/>.
        /// </summary>
        public DWORD VolumeTextureFilterCaps;

        /// <summary>
        /// Texture-addressing capabilities for texture objects.
        /// This member can be one or more of the following flags.
        /// <see cref="D3DPTADDRESSCAPS_BORDER"/>:
        /// Device supports setting coordinates outside the range [0.0, 1.0] to the border color,
        /// as specified by the <see cref="D3DSAMP_BORDERCOLOR"/> texture-stage state.
        /// <see cref="D3DPTADDRESSCAPS_CLAMP"/>:
        /// Device can clamp textures to addresses.
        /// <see cref="D3DPTADDRESSCAPS_INDEPENDENTUV"/>:
        /// Device can separate the texture-addressing modes of the u and v coordinates of the texture.
        /// This ability corresponds to the <see cref="D3DSAMP_ADDRESSU"/> and <see cref="D3DSAMP_ADDRESSV"/> render-state values.
        /// <see cref="D3DPTADDRESSCAPS_MIRROR"/>:
        /// Device can mirror textures to addresses.
        /// <see cref="D3DPTADDRESSCAPS_MIRRORONCE"/>:
        /// Device can take the absolute value of the texture coordinate (thus, mirroring around 0) and then clamp to the maximum value.
        /// <see cref="D3DPTADDRESSCAPS_WRAP"/>:
        /// Device can wrap textures to addresses.
        /// </summary>
        public DWORD TextureAddressCaps;

        /// <summary>
        /// Texture-addressing capabilities for a volume texture.
        /// This member can be one or more of the flags defined for the <see cref="TextureAddressCaps"/> member.
        /// </summary>
        public DWORD VolumeTextureAddressCaps;

        /// <summary>
        /// Defines the capabilities for line-drawing primitives.
        /// <see cref="D3DLINECAPS_ALPHACMP"/>:
        /// Supports alpha-test comparisons.
        /// <see cref="D3DLINECAPS_ANTIALIAS"/>:
        /// Antialiased lines are supported.
        /// <see cref="D3DLINECAPS_BLEND"/>:
        /// Supports source-blending.
        /// <see cref="D3DLINECAPS_FOG"/>:
        /// Supports fog.
        /// <see cref="D3DLINECAPS_TEXTURE"/>:
        /// Supports texture-mapping.
        /// <see cref="D3DLINECAPS_ZTEST"/>:
        /// Supports z-buffer comparisons.
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
        /// This number represents the maximum range of the integer bits of the post-normalized texture coordinates.
        /// A texture coordinate is stored as a 32-bit signed integer using 27 bits to store the integer part and 5 bits for the floating point fraction.
        /// The maximum integer index, 2²⁷, is used to determine the maximum texture coordinate, depending on how the hardware does texture-coordinate scaling.
        /// Some hardware reports the cap <see cref="D3DPTEXTURECAPS_TEXREPEATNOTSCALEDBYSIZE"/>.
        /// For this case, the device defers scaling texture coordinates by the texture size until after interpolation and application of the texture address mode,
        /// so the number of times a texture can be wrapped is given by the integer value in <see cref="MaxTextureRepeat"/>.
        /// Less desirably, on some hardware <see cref="D3DPTEXTURECAPS_TEXREPEATNOTSCALEDBYSIZE"/> is not set
        /// and the device scales the texture coordinates by the texture size (using the highest level of detail) prior to interpolation.
        /// This limits the number of times a texture can be wrapped to <see cref="MaxTextureRepeat"/> / texture size.
        /// For example, assume that <see cref="MaxTextureRepeat"/> is equal to 32k and the size of the texture is 4k.
        /// If the hardware sets <see cref="D3DPTEXTURECAPS_TEXREPEATNOTSCALEDBYSIZE"/>, then the number of times a texture can be wrapped
        /// is equal to <see cref="MaxTextureRepeat"/>, which is 32k in this example.
        /// Otherwise, the number of times a texture can be wrapped is equal to <see cref="MaxTextureRepeat"/> divided by texture size, which is 32k/4k in this example.
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
        /// Flags specifying supported stencil-buffer operations.
        /// Stencil operations are assumed to be valid for all three stencil-buffer operation render states
        /// (<see cref="D3DRS_STENCILFAIL"/>, <see cref="D3DRS_STENCILPASS"/>, and <see cref="D3DRS_STENCILZFAIL"/>).
        /// For more information, see <see cref="D3DSTENCILCAPS"/>.
        /// </summary>
        public DWORD StencilCaps;

        /// <summary>
        /// Flexible vertex format capabilities.
        /// <see cref="D3DFVFCAPS_DONOTSTRIPELEMENTS"/>:
        /// It is preferable that vertex elements not be stripped.
        /// That is, if the vertex format contains elements that are not used with the current render states, there is no need to regenerate the vertices.
        /// If this capability flag is not present, stripping extraneous elements from the vertex format provides better performance.
        /// <see cref="D3DFVFCAPS_PSIZE"/>:
        /// Point size is determined by either the render state or the vertex data.
        /// If an FVF is used, point size can come from point size data in the vertex declaration.
        /// Otherwise, point size is determined by the render state <see cref="D3DRS_POINTSIZE"/>.
        /// If the application provides point size in both (the render state and the vertex declaration), the vertex data overrides the render-state data.
        /// <see cref="D3DFVFCAPS_TEXCOORDCOUNTMASK"/>:
        /// Masks the low WORD of <see cref="FVFCaps"/>.
        /// These bits, cast to the WORD data type, describe the total number of texture coordinate sets
        /// that the device can simultaneously use for multiple texture blending.
        /// (You can use up to eight texture coordinate sets for any vertex,
        /// but the device can blend using only the specified number of texture coordinate sets.)
        /// </summary>
        public D3DFVFCAPS FVFCaps;

        /// <summary>
        /// Combination of flags describing the texture operations supported by this device.
        /// The following flags are defined.
        /// <see cref="D3DTEXOPCAPS_ADD"/>:
        /// The <see cref="D3DTOP_ADD"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_ADDSIGNED"/>:
        /// The <see cref="D3DTOP_ADDSIGNED"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_ADDSIGNED2X"/>:
        /// The <see cref="D3DTOP_ADDSIGNED2X"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_ADDSMOOTH"/>:
        /// The <see cref="D3DTOP_ADDSMOOTH"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_BLENDCURRENTALPHA"/>:
        /// The <see cref="D3DTOP_BLENDCURRENTALPHA"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_BLENDDIFFUSEALPHA"/>:
        /// The <see cref="D3DTOP_BLENDDIFFUSEALPHA"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_BLENDFACTORALPHA"/>:
        /// The <see cref="D3DTOP_BLENDFACTORALPHA"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_BLENDTEXTUREALPHA"/>:
        /// The <see cref="D3DTOP_BLENDTEXTUREALPHA"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_BLENDTEXTUREALPHAPM"/>:
        /// The <see cref="D3DTOP_BLENDTEXTUREALPHAPM"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_BUMPENVMAP"/>:
        /// The <see cref="D3DTOP_BUMPENVMAP"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_BUMPENVMAPLUMINANCE"/>:
        /// The <see cref="D3DTOP_BUMPENVMAPLUMINANCE"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_DISABLE"/>:
        /// The <see cref="D3DTOP_DISABLE"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_DOTPRODUCT3"/>:
        /// The <see cref="D3DTOP_DOTPRODUCT3"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_LERP"/>:
        /// The <see cref="D3DTOP_LERP"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_MODULATE"/>:
        /// The <see cref="D3DTOP_MODULATE"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_MODULATE2X"/>:
        /// The <see cref="D3DTOP_MODULATE2X"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_MODULATE4X"/>:
        /// The <see cref="D3DTOP_MODULATE4X"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_MODULATEALPHA_ADDCOLOR"/>:
        /// The <see cref="D3DTOP_MODULATEALPHA_ADDCOLOR"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_MODULATECOLOR_ADDALPHA"/>:
        /// The <see cref="D3DTOP_MODULATECOLOR_ADDALPHA"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_MODULATEINVALPHA_ADDCOLOR"/>:
        /// The <see cref="D3DTOP_MODULATEINVALPHA_ADDCOLOR"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_MODULATEINVCOLOR_ADDALPHA"/>:
        /// The <see cref="D3DTOP_MODULATEINVCOLOR_ADDALPHA"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_MULTIPLYADD"/>:
        /// The <see cref="D3DTOP_MULTIPLYADD"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_PREMODULATE"/>:
        /// The <see cref="D3DTOP_PREMODULATE"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_SELECTARG1"/>:
        /// The <see cref="D3DTOP_SELECTARG1"/> texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_SELECTARG2"/>:
        /// The D3DTOP_SELECTARG2 texture-blending operation is supported.
        /// <see cref="D3DTEXOPCAPS_SUBTRACT"/>:
        /// The D3DTOP_SUBTRACT texture-blending operation is supported.
        /// </summary>
        public DWORD TextureOpCaps;

        /// <summary>
        /// Maximum number of texture-blending stages supported in the fixed function pipeline.
        /// This value is the number of blenders available.
        /// In the programmable pixel pipeline, this corresponds to the number of unique texture registers used by pixel shader instructions.
        /// </summary>
        public DWORD MaxTextureBlendStages;

        /// <summary>
        /// Maximum number of textures that can be simultaneously bound to the fixed-function pipeline sampler stages.
        /// If the same texture is bound to two sampler stages, it counts as two textures.
        /// This value has no meaning in the programmable pipeline where the number of sampler stages is determined by each pixel shader version.
        /// Each pixel shader version also determines the number of texture declaration instructions.
        /// See Pixel Shaders.
        /// </summary>
        public DWORD MaxSimultaneousTextures;

        /// <summary>
        /// This value has no meaning in the programmable pipeline
        /// where the number of sampler stages is determined by each pixel shader version.
        /// Each pixel shader version also determines the number of texture declaration instructions.
        /// See Pixel Shaders.
        /// </summary>
        public DWORD VertexProcessingCaps;

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
        /// DWORD value that specifies the maximum matrix index that can be indexed into using the per-vertex indices.
        /// The number of matrices is <see cref="MaxVertexBlendMatrixIndex"/> + 1, which is the size of the matrix palette.
        /// If normals are present in the vertex data that needs to be blended for lighting,
        /// then the number of matrices is half the number specified by this capability flag.
        /// If <see cref="MaxVertexBlendMatrixIndex"/> is set to zero, the driver does not support indexed vertex blending.
        /// If this value is not zero then the valid range of indices is zero through <see cref="MaxVertexBlendMatrixIndex"/>.
        /// A zero value for <see cref="MaxVertexBlendMatrixIndex"/> indicates that the driver does not support indexed matrices.
        /// When software vertex processing is used, 256 matrices could be used for indexed vertex blending, with or without normal blending.
        /// For a given physical device, this capability may vary across Direct3D devices
        /// depending on the parameters supplied to <see cref="IDirect3D9.CreateDevice"/>.
        /// </summary>
        public DWORD MaxVertexBlendMatrixIndex;

        /// <summary>
        /// Maximum size of a point primitive.
        /// If set to 1.0f then device does not support point size control.
        /// The range is greater than or equal to 1.0f.
        /// </summary>
        public float MaxPointSize;

        /// <summary>
        /// Maximum number of primitives for each <see cref="IDirect3DDevice9.DrawPrimitive"/> call.
        /// There are two cases:
        /// If <see cref="MaxPrimitiveCount"/> is not equal to 0xffff, you can draw at most <see cref="MaxPrimitiveCount"/> primitives with each draw call.
        /// However, if <see cref="MaxPrimitiveCount"/> equals 0xffff, you can still draw at most <see cref="MaxPrimitiveCount"/> primitive,
        /// but you may also use no more than <see cref="MaxPrimitiveCount"/> unique vertices (since each primitive can potentially use three different vertices).
        /// </summary>
        public DWORD MaxPrimitiveCount;

        /// <summary>
        /// Maximum size of indices supported for hardware vertex processing.
        /// It is possible to create 32-bit index buffers; however, you will not be able to render with the index buffer unless this value is greater than 0x0000FFFF.
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
        /// This number indicates which device is the master for this subordinate.
        /// This number is taken from the same space as the adapter values.
        /// For multihead support, one head will be denoted the master head, and all other heads on the same card will be denoted subordinate heads.
        /// If more than one multihead adapter is present in a system, the master and its subordinates from one multihead adapter are called a group.
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
        /// Combination of constants that describe the operations supported by <see cref="IDirect3DDevice9.StretchRect"/>.
        /// The flags that may be set in this field are:
        /// <see cref="D3DPTFILTERCAPS_MINFPOINT"/>:
        /// Device supports point-sample filtering for minifying rectangles.
        /// This filter type is requested by calling <see cref="IDirect3DDevice9.StretchRect"/> using <see cref="D3DTEXF_POINT"/>.
        /// <see cref="D3DPTFILTERCAPS_MAGFPOINT"/>:
        /// Device supports point-sample filtering for magnifying rectangles.
        /// This filter type is requested by calling <see cref="IDirect3DDevice9.StretchRect"/> using <see cref="D3DTEXF_POINT"/>.
        /// <see cref="D3DPTFILTERCAPS_MINFLINEAR"/>:
        /// Device supports bilinear interpolation filtering for minifying rectangles.
        /// This filter type is requested by calling <see cref="IDirect3DDevice9.StretchRect"/> using <see cref="D3DTEXF_LINEAR"/>.
        /// <see cref="D3DPTFILTERCAPS_MAGFLINEAR"/>:
        /// Device supports bilinear interpolation filtering for magnifying rectangles.
        /// This filter type is requested by calling <see cref="IDirect3DDevice9.StretchRect"/> using <see cref="D3DTEXF_LINEAR"/>.
        /// For more information, see <see cref="D3DTEXTUREFILTERTYPE"/> and <see cref="D3DTEXTUREFILTERTYPE"/>.
        /// </summary>
        public DWORD StretchRectFilterCaps;

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
        public DWORD VertexTextureFilterCaps;

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
