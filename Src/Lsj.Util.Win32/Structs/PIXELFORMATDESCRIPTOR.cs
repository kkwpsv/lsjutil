using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="PIXELFORMATDESCRIPTOR"/> structure describes the pixel format of a drawing surface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-pixelformatdescriptor"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Please notice carefully, as documented above,
    /// that certain pixel format properties are not supported in the current generic implementation.
    /// The generic implementation is the Microsoft GDI software implementation of OpenGL.
    /// Hardware manufacturers may enhance parts of OpenGL,
    /// and may support some pixel format properties not supported by the generic implementation.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PIXELFORMATDESCRIPTOR
    {
        /// <summary>
        /// Specifies the size of this data structure.
        /// This value should be set to <c>sizeof(PIXELFORMATDESCRIPTOR</c>.
        /// </summary>
        public WORD nSize;

        /// <summary>
        /// Specifies the version of this data structure.
        /// This value should be set to 1.
        /// </summary>
        public WORD nVersion;

        /// <summary>
        /// <para>
        /// A set of bit flags that specify properties of the pixel buffer.
        /// The properties are generally not mutually exclusive;
        /// you can set any combination of bit flags, with the exceptions noted.
        /// The following bit flag constants are defined.
        /// </para>
        /// <para>
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
        /// <para>
        /// <see cref="PFD_DRAW_TO_WINDOW"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// The buffer can draw to a window or device surface.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_DRAW_TO_BITMAP"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// The buffer can draw to a memory bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_SUPPORT_GDI"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// The buffer supports GDI drawing.
        /// This flag and <see cref="PFD_DOUBLEBUFFER"/> are mutually exclusive in the current generic implementation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_SUPPORT_OPENGL"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// The buffer supports OpenGL drawing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_GENERIC_ACCELERATED"/>
        /// </para>
        /// <para>
        /// 0x00001000
        /// </para>
        /// </term>
        /// <term>
        /// The pixel format is supported by a device driver that accelerates the generic implementation.
        /// If this flag is clear and the <see cref="PFD_GENERIC_FORMAT"/> flag is set,
        /// the pixel format is supported by the generic implementation only.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_GENERIC_FORMAT"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// The pixel format is supported by the GDI software implementation,
        /// which is also known as the generic implementation.
        /// If this bit is clear, the pixel format is supported by a device driver or hardware.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_NEED_PALETTE"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// The buffer uses RGBA pixels on a palette-managed device.
        /// A logical palette is required to achieve the best results for this pixel type.
        /// Colors in the palette should be specified according to the values of the <see cref="cRedBits"/>,
        /// <see cref="cRedShift"/>, <see cref="cGreenBits"/>, <see cref="cGreenShift"/>,
        /// <see cref="cBlueBits"/>, and <see cref="cBlueShift"/> members.
        /// The palette should be created and realized in the device context before calling <see cref="wglMakeCurrent"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_NEED_SYSTEM_PALETTE"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Defined in the pixel format descriptors of hardware that supports one hardware palette in 256-color mode only.
        /// For such systems to use hardware acceleration,
        /// the hardware palette must be in a fixed order (for example, 3-3-2)
        /// when in RGBA mode or must match the logical palette when in color-index mode.
        /// When this flag is set, you must call <see cref="SetSystemPaletteUse"/> in your program
        /// to force a one-to-one mapping of the logical palette and the system palette.
        /// If your OpenGL hardware supports multiple hardware palettes
        /// and the device driver can allocate spare hardware palettes for OpenGL, this flag is typically clear.
        /// </para>
        /// <para>
        /// This flag is not set in the generic pixel formats.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_DOUBLEBUFFER"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The buffer is double-buffered.
        /// This flag and <see cref="PFD_SUPPORT_GDI"/> are mutually exclusive in the current generic implementation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_STEREO"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// The buffer is stereoscopic.
        /// This flag is not supported in the current generic implementation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_SWAP_LAYER_BUFFERS"/>
        /// </para>
        /// <para>
        /// 0x00000800
        /// </para>
        /// </term>
        /// <term>
        /// Indicates whether a device can swap individual layer planes with pixel formats
        /// that include double-buffered overlay or underlay planes.
        /// Otherwise all layer planes are swapped together as a group.
        /// When this flag is set, <see cref="wglSwapLayerBuffers"/> is supported.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// You can specify the following bit flags when calling <see cref="ChoosePixelFormat"/>.
        /// </para>
        /// <para>
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
        /// <para>
        /// <see cref="PFD_DEPTH_DONTCARE"/>
        /// </para>
        /// <para>
        /// 0x20000000
        /// </para>
        /// </term>
        /// <term>
        /// The requested pixel format can either have or not have a depth buffer.
        /// To select a pixel format without a depth buffer, you must specify this flag.
        /// The requested pixel format can be with or without a depth buffer.
        /// Otherwise, only pixel formats with a depth buffer are considered.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_DOUBLEBUFFER_DONTCARE"/>
        /// </para>
        /// <para>
        /// 0x40000000
        /// </para>
        /// </term>
        /// <term>
        /// The requested pixel format can be either single- or double-buffered.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_STEREO_DONTCARE"/>
        /// </para>
        /// <para>
        /// 0x80000000
        /// </para>
        /// </term>
        /// <term>
        /// The requested pixel format can be either monoscopic or stereoscopic.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// With the <see cref="glAddSwapHintRectWIN"/> extension function,
        /// two new flags are included for the <see cref="PIXELFORMATDESCRIPTOR"/> pixel format structure.
        /// </para>
        /// <para>
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
        /// <para>
        /// <see cref="PFD_SWAP_COPY"/>
        /// </para>
        /// <para>
        /// 0x00000400
        /// </para>
        /// </term>
        /// <term>
        /// Specifies the content of the back buffer in the double-buffered main color plane following a buffer swap.
        /// Swapping the color buffers causes the content of the back buffer to be copied to the front buffer.
        /// The content of the back buffer is not affected by the swap.
        /// <see cref="PFD_SWAP_COPY"/> is a hint only and might not be provided by a driver.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_SWAP_EXCHANGE"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// Specifies the content of the back buffer in the double-buffered main color plane following a buffer swap.
        /// Swapping the color buffers causes the exchange of the back buffer's content with the front buffer's content.
        /// Following the swap, the back buffer's content contains the front buffer's content before the swap.
        /// <see cref="PFD_SWAP_EXCHANGE"/> is a hint only and might not be provided by a driver.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public DWORD dwFlags;

        /// <summary>
        /// <para>
        /// Specifies the type of pixel data.
        /// The following types are defined.
        /// </para>
        /// <para>
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
        /// <para>
        /// <see cref="PFD_TYPE_RGBA"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// RGBA pixels.
        /// Each pixel has four components in this order: red, green, blue, and alpha.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PFD_TYPE_COLORINDEX"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Color-index pixels.
        /// Each pixel uses a color-index value.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BYTE iPixelType;

        /// <summary>
        /// Specifies the number of color bitplanes in each color buffer.
        /// For RGBA pixel types, it is the size of the color buffer, excluding the alpha bitplanes.
        /// For color-index pixels, it is the size of the color-index buffer.
        /// </summary>
        public BYTE cColorBits;

        /// <summary>
        /// Specifies the number of red bitplanes in each RGBA color buffer.
        /// </summary>
        public BYTE cRedBits;

        /// <summary>
        /// Specifies the shift count for red bitplanes in each RGBA color buffer.
        /// </summary>
        public BYTE cRedShift;

        /// <summary>
        /// Specifies the number of green bitplanes in each RGBA color buffer.
        /// </summary>
        public BYTE cGreenBits;

        /// <summary>
        /// Specifies the shift count for green bitplanes in each RGBA color buffer.
        /// </summary>
        public BYTE cGreenShift;

        /// <summary>
        /// Specifies the number of blue bitplanes in each RGBA color buffer.
        /// </summary>
        public BYTE cBlueBits;

        /// <summary>
        /// Specifies the shift count for blue bitplanes in each RGBA color buffer.
        /// </summary>
        public BYTE cBlueShift;

        /// <summary>
        /// Specifies the number of alpha bitplanes in each RGBA color buffer.
        /// Alpha bitplanes are not supported.
        /// </summary>
        public BYTE cAlphaBits;

        /// <summary>
        /// Specifies the shift count for alpha bitplanes in each RGBA color buffer.
        /// Alpha bitplanes are not supported.
        /// </summary>
        public BYTE cAlphaShift;

        /// <summary>
        /// Specifies the total number of bitplanes in the accumulation buffer.
        /// </summary>
        public BYTE cAccumBits;

        /// <summary>
        /// Specifies the number of red bitplanes in the accumulation buffer.
        /// </summary>
        public BYTE cAccumRedBits;

        /// <summary>
        /// Specifies the number of green bitplanes in the accumulation buffer.
        /// </summary>
        public BYTE cAccumGreenBits;

        /// <summary>
        /// Specifies the number of blue bitplanes in the accumulation buffer.
        /// </summary>
        public BYTE cAccumBlueBits;

        /// <summary>
        /// Specifies the number of alpha bitplanes in the accumulation buffer.
        /// </summary>
        public BYTE cAccumAlphaBits;

        /// <summary>
        /// Specifies the depth of the depth (z-axis) buffer.
        /// </summary>
        public BYTE cDepthBits;

        /// <summary>
        /// Specifies the depth of the stencil buffer.
        /// </summary>
        public BYTE cStencilBits;

        /// <summary>
        /// Specifies the number of auxiliary buffers.
        /// Auxiliary buffers are not supported.
        /// </summary>
        public BYTE cAuxBuffers;

        /// <summary>
        /// Ignored.
        /// Earlier implementations of OpenGL used this member, but it is no longer used.
        /// </summary>
        public BYTE iLayerType;

        /// <summary>
        /// Specifies the number of overlay and underlay planes.
        /// Bits 0 through 3 specify up to 15 overlay planes and bits 4 through 7 specify up to 15 underlay planes.
        /// </summary>
        public BYTE bReserved;

        /// <summary>
        /// Ignored.
        /// Earlier implementations of OpenGL used this member, but it is no longer used.
        /// </summary>
        public DWORD dwLayerMask;

        /// <summary>
        /// Specifies the transparent color or index of an underlay plane.
        /// When the pixel type is RGBA, <see cref="dwVisibleMask"/> is a transparent RGB color value.
        /// When the pixel type is color index, it is a transparent index value.
        /// </summary>
        public DWORD dwVisibleMask;

        /// <summary>
        /// Ignored.
        /// Earlier implementations of OpenGL used this member, but it is no longer used.
        /// </summary>
        public DWORD dwDamageMask;
    }
}
