using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.WindowClassStyles;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="ChoosePixelFormat"/> function attempts to match an appropriate pixel format
        /// supported by a device context to a given pixel format specification.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-choosepixelformat"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies the device context that the function examines to determine the best match
        /// for the pixel format descriptor pointed to by <paramref name="ppfd"/>.
        /// </param>
        /// <param name="ppfd">
        /// <para>
        /// Pointer to a <see cref="PIXELFORMATDESCRIPTOR"/> structure that specifies the requested pixel format.
        /// In this context, the members of the <see cref="PIXELFORMATDESCRIPTOR"/> structure
        /// that <paramref name="ppfd"/> points to are used as follows:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.nSize"/>
        /// </term>
        /// <term>
        /// Specifies the size of the <see cref="PIXELFORMATDESCRIPTOR"/> data structure.
        /// Set this member to <c>sizeof(PIXELFORMATDESCRIPTOR)</c>.
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.nVersion"/>
        /// </term>
        /// <term>
        /// Specifies the version number of the <see cref="PIXELFORMATDESCRIPTOR"/> data structure.
        /// Set this member to 1.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.dwFlags"/>
        /// </term>
        /// <term>
        /// A set of bit flags that specify properties of the pixel buffer.
        /// You can combine the following bit flag constants by using bitwise-OR.
        /// If any of the following flags are set,
        /// the <see cref="ChoosePixelFormat"/> function attempts to match pixel formats that also have that flag or flags set.
        /// Otherwise, <see cref="ChoosePixelFormat"/> ignores that flag in the pixel formats:
        /// <see cref="PFD_DRAW_TO_WINDOW"/>, <see cref="PFD_DRAW_TO_BITMAP"/>, <see cref="PFD_SUPPORT_GDI"/>, <see cref="PFD_SUPPORT_OPENGL"/>
        /// If any of the following flags are set,
        /// <see cref="ChoosePixelFormat"/> attempts to match pixel formats that also have that flag or flags set.
        /// Otherwise, it attempts to match pixel formats without that flag set:
        /// <see cref="PFD_DOUBLEBUFFER"/> <see cref="PFD_STEREO"/>
        /// If the following flag is set, the function ignores the <see cref="PFD_DOUBLEBUFFER"/> flag
        /// in the pixel formats: <see cref="PFD_DOUBLEBUFFER_DONTCARE"/>
        /// If the following flag is set, the function ignores the <see cref="PFD_STEREO"/> flag 
        /// in the pixel formats: <see cref="PFD_STEREO_DONTCARE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.iPixelType"/>
        /// </term>
        /// <term>
        /// Specifies the type of pixel format for the function to consider:
        /// <see cref="PFD_TYPE_RGBA"/>, <see cref="PFD_TYPE_COLORINDEX"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cColorBits"/>
        /// </term>
        /// <term>
        /// Zero or greater.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cRedBits"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cRedShift"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cGreenBits"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cGreenShift"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cBlueBits"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cBlueShift"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cAlphaBits"/>
        /// </term>
        /// <term>
        /// Zero or greater.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cAlphaShift"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cAccumBits"/>
        /// </term>
        /// <term>
        /// Zero or greater.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cAccumRedBits"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cAccumGreenBits"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cAccumBlueBits"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cAccumAlphaBits"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cDepthBits"/>
        /// </term>
        /// <term>
        /// Zero or greater.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cStencilBits"/>
        /// </term>
        /// <term>
        /// Zero or greater.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.cAuxBuffers"/>
        /// </term>
        /// <term>
        /// Zero or greater.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.iLayerType"/>
        /// </term>
        /// <term>
        /// Specifies one of the following layer type values:
        /// <see cref="PFD_MAIN_PLANE"/>, <see cref="PFD_OVERLAY_PLANE"/>, <see cref="PFD_UNDERLAY_PLANE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.bReserved"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.dwLayerMask"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.dwVisibleMask"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PIXELFORMATDESCRIPTOR.dwDamageMask"/>
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a pixel format index (one-based)
        /// that is the closest match to the given pixel format descriptor.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// You must ensure that the pixel format matched by the <see cref="ChoosePixelFormat"/> function satisfies your requirements.
        /// For example, if you request a pixel format with a 24-bit RGB color buffer
        /// but the device context offers only 8-bit RGB color buffers,
        /// the function returns a pixel format with an 8-bit RGB color buffer.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChoosePixelFormat", ExactSpelling = true, SetLastError = true)]
        public static extern int ChoosePixelFormat([In] HDC hdc, [In] in PIXELFORMATDESCRIPTOR ppfd);

        /// <summary>
        /// <para>
        /// The <see cref="DescribePixelFormat"/> function obtains information about the pixel format
        /// identified by <paramref name="iPixelFormat"/> of the device associated with <paramref name="hdc"/>.
        /// The function sets the members of the <see cref="PIXELFORMATDESCRIPTOR"/> structur
        /// e pointed to by <paramref name="ppfd"/> with that pixel format data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-describepixelformat"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies the device context.
        /// </param>
        /// <param name="iPixelFormat">
        /// Index that specifies the pixel format.
        /// The pixel formats that a device context supports are identified by positive one-based integer indexes.
        /// </param>
        /// <param name="nBytes">
        /// The size, in bytes, of the structure pointed to by <paramref name="ppfd"/>.
        /// The <see cref="DescribePixelFormat"/> function stores no more than <paramref name="nBytes"/> bytes of data to that structure.
        /// Set this value to <c>sizeof(PIXELFORMATDESCRIPTOR)</c>.
        /// </param>
        /// <param name="ppfd">
        /// Pointer to a <see cref="PIXELFORMATDESCRIPTOR"/> structure whose members the function sets with pixel format data.
        /// The function stores the number of bytes copied to the structure
        /// in the structure's <see cref="PIXELFORMATDESCRIPTOR.nSize"/> member.
        /// If, upon entry, <paramref name="ppfd"/> is <see cref="NullRef{PIXELFORMATDESCRIPTOR}"/>,
        /// the function writes no data to the structure.
        /// This is useful when you only want to obtain the maximum pixel format index of a device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the maximum pixel format index of the device context.
        /// In addition, the function sets the members of the <see cref="PIXELFORMATDESCRIPTOR"/> structure
        /// pointed to by <paramref name="ppfd"/> according to the specified pixel format.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DescribePixelFormat", ExactSpelling = true, SetLastError = true)]
        public static extern int DescribePixelFormat([In] HDC hdc, [In] int iPixelFormat,
            [In] uint nBytes, [Out] out PIXELFORMATDESCRIPTOR ppfd);

        /// <summary>
        /// <para>
        /// The <see cref="GetEnhMetaFilePixelFormat"/> function retrieves pixel format information for an enhanced metafile.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getenhmetafilepixelformat"/>
        /// </para>
        /// </summary>
        /// <param name="hemf">
        /// Identifies the enhanced metafile.
        /// </param>
        /// <param name="cbBuffer">
        /// Specifies the size, in bytes, of the buffer into which the pixel format information is copied.
        /// </param>
        /// <param name="ppfd">
        /// Pointer to a <see cref="PIXELFORMATDESCRIPTOR"/> structure that contains the logical pixel format specification.
        /// The metafile uses this structure to record the logical pixel format specification.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds and finds a pixel format, the return value is the size of the metafile's pixel format.
        /// </para>
        /// <para>
        /// If no pixel format is present, the return value is zero.
        /// </para>
        /// <para>
        /// If an error occurs and the function fails, the return value is <see cref="GDI_ERROR"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When an enhanced metafile specifies a pixel format in its <see cref="ENHMETAHEADER"/> structure
        /// and the pixel format fits in the buffer, the pixel format information is copied into <paramref name="ppfd"/>.
        /// When <paramref name="cbBuffer"/> is too small to contain the pixel format of the metafile
        /// , the pixel format is not copied to the buffer.
        /// In either case, the function returns the size of the metafile's pixel format.
        /// </para>
        /// <para>
        /// For information on metafile recording and other operations, see Enhanced Metafile Operations.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnhMetaFilePixelFormat", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetEnhMetaFilePixelFormat([In] HENHMETAFILE hemf, [In] UINT cbBuffer,
            [Out] out PIXELFORMATDESCRIPTOR ppfd);

        /// <summary>
        /// <para>
        /// The <see cref="GetPixelFormat"/> function obtains the index of the currently selected pixel format of the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getpixelformat"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies the device context of the currently selected pixel format index returned by the function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the currently selected pixel format index of the specified device context.
        /// This is a positive, one-based index value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPixelFormat", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetPixelFormat([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="SetPixelFormat"/> function sets the pixel format of the specified device context
        /// to the format specified by the <paramref name="format"/> index.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setpixelformat"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies the device context whose pixel format the function attempts to set.
        /// </param>
        /// <param name="format">
        /// Index that identifies the pixel format to set.
        /// The various pixel formats supported by a device context are identified by one-based indexes.
        /// </param>
        /// <param name="ppfd">
        /// Pointer to a <see cref="PIXELFORMATDESCRIPTOR"/> structure that contains the logical pixel format specification.
        /// The system's metafile component uses this structure to record the logical pixel format specification.
        /// The structure has no other effect upon the behavior of the <see cref="SetPixelFormat"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="hdc"/> references a window,
        /// calling the <see cref="SetPixelFormat"/> function also changes the pixel format of the window.
        /// Setting the pixel format of a window more than once can lead to significant complications
        /// for the Window Manager and for multithread applications, so it is not allowed.
        /// An application can only set the pixel format of a window one time.
        /// Once a window's pixel format is set, it cannot be changed.
        /// </para>
        /// <para>
        /// You should select a pixel format in the device context before calling the <see cref="wglCreateContext"/> function.
        /// The <see cref="wglCreateContext"/> function creates a rendering context
        /// for drawing on the device in the selected pixel format of the device context.
        /// </para>
        /// <para>
        /// An OpenGL window has its own pixel format.
        /// Because of this, only device contexts retrieved for the client area of an OpenGL window are allowed to draw into the window.
        /// As a result, an OpenGL window should be created with the <see cref="WS_CLIPCHILDREN"/> and <see cref="WS_CLIPSIBLINGS"/> styles.
        /// Additionally, the window class attribute should not include the <see cref="CS_PARENTDC"/> style.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPixelFormat", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetPixelFormat([In] HDC hdc, [In] int format, [In] in PIXELFORMATDESCRIPTOR ppfd);

        /// <summary>
        /// <para>
        /// The <see cref="SwapBuffers"/> function exchanges the front and back buffers
        /// if the current pixel format for the window referenced by the specified device context includes a back buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-swapbuffers"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// Specifies a device context.
        /// If the current pixel format for the window referenced by this device context includes a back buffer,
        /// the function exchanges the front and back buffers.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the current pixel format for the window referenced by the device context does not include a back buffer,
        /// this call has no effect and the content of the back buffer is undefined when the function returns.
        /// </para>
        /// <para>
        /// With multithread applications, flush the drawing commands in any other threads
        /// drawing to the same window before calling <see cref="SwapBuffers"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SwapBuffers", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SwapBuffers([In] HDC unnamedParam1);
    }
}
