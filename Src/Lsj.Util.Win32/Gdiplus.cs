using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.GpStatus;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// <para>
    /// Gdiplus.dll
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdiplus/-gdiplus-flatapi-flat"/>
    /// </para>
    /// </summary>
    public static class Gdiplus
    {
        /// <summary>
        /// Creates a Graphics object that is associated with a specified device context.
        /// </summary>
        /// <param name="hdc">Device context.</param>
        /// <param name="graphics">Graphics object.</param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipCreateFromHDC", ExactSpelling = true)]
        public static extern GpStatus GdipCreateFromHDC([In] HDC hdc, [Out] out IntPtr graphics);

        /// <summary>
        /// Releases resources used by the Image object.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipDisposeImage", ExactSpelling = true)]
        public static extern GpStatus GdipDisposeImage([In] IntPtr image);

        /// <summary>
        /// Draws an image at a specified location.
        /// </summary>
        /// <param name="graphics">Graphics object.</param>
        /// <param name="image">Image object.</param>
        /// <param name="x">X postion.</param>
        /// <param name="y">Y position.</param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipDrawImage", ExactSpelling = true)]
        public static extern GpStatus GdipDrawImage([In] IntPtr graphics, [In] IntPtr image, [In] float x, [In] float y);

        /// <summary>
        /// Draws an image at a specified location.
        /// </summary>
        /// <param name="graphics">Graphics object.</param>
        /// <param name="image">Image object.</param>
        /// <param name="x">X postion.</param>
        /// <param name="y">Y position.</param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipDrawImageI", ExactSpelling = true)]
        public static extern GpStatus GdipDrawImageI([In] IntPtr graphics, [In] IntPtr image, [In] int x, [In] int y);

        /// <summary>
        /// Draws an image.
        /// </summary>
        /// <param name="graphics">Graphics object.</param>
        /// <param name="image">Image object.</param>
        /// <param name="x">X postion.</param>
        /// <param name="y">Y position.</param>
        /// <param name="height">Height.</param>
        /// <param name="width">Width.</param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipDrawImageRect", ExactSpelling = true)]
        public static extern GpStatus GdipDrawImageRect([In] IntPtr graphics, [In] IntPtr image, [In] float x, [In] float y, [In] float width, [In] float height);

        /// <summary>
        /// Draws an image.
        /// </summary>
        /// <param name="graphics">Graphics object.</param>
        /// <param name="image">Image object.</param>
        /// <param name="x">X postion.</param>
        /// <param name="y">Y position.</param>
        /// <param name="height">Height.</param>
        /// <param name="width">Width.</param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipDrawImageRectI", ExactSpelling = true)]
        public static extern GpStatus GdipDrawImageRectI([In] IntPtr graphics, [In] IntPtr image, [In] int x, [In] int y, [In] int width, [In] int height);

        /// <summary>
        /// Creates an Image object based on a file. This flat function does not use ICM.
        /// <param name="filename">Image file name.</param>
        /// <param name="image">Image object.</param>
        /// <returns>
        /// </returns>
        /// </summary>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipLoadImageFromFile", ExactSpelling = true)]
        public static extern GpStatus GdipLoadImageFromFile([In] LPCWSTR filename, [Out] out IntPtr image);

        /// <summary>
        /// <para>
        /// The <see cref="GdiplusShutdown"/> function cleans up resources used by Windows GDI+.
        /// Each call to <see cref="GdiplusStartup"/> should be paired with a call to <see cref="GdiplusShutdown"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/gdiplusinit/nf-gdiplusinit-gdiplusshutdown"/>
        /// </para>
        /// </summary>
        /// <param name="token">
        /// Token returned by a previous call to <see cref="GdiplusStartup"/>.
        /// </param>
        /// <remarks>
        /// <para>
        /// You must call <see cref="GdiplusStartup"/> before you create any GDI+ objects,
        /// and you must delete all of your GDI+ objects (or have them go out of scope) before you call <see cref="GdiplusShutdown"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For Windows 7 and earlier, if GDI+ can't create a font family,
        /// it substitutes the generic Sans Serif family and client-side caches the pointer for the generic family.
        /// Because calls to <see cref="GdiplusStartup"/> and <see cref="GdiplusShutdown"/> are not aware of this caching,
        /// the operating system retains the pointer for the generic family object past the object's lifetime,
        /// which causes the operating system to crash.
        /// For Windows 8 and later, GDI+ returns a sentinel value for the generic family object
        /// that remains constant across calls to <see cref="GdiplusStartup"/> and <see cref="GdiplusShutdown"/>
        /// so the operating system doesn't retain the pointer for the generic family object past the object's lifetime.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiplusShutdown", ExactSpelling = true)]
        public static extern void GdiplusShutdown([In] ULONG_PTR token);

        /// <summary>
        /// <para>
        /// The <see cref="GdiplusStartup"/> function initializes Windows GDI+.
        /// Call <see cref="GdiplusStartup"/> before making any other GDI+ calls,
        /// and call <see cref="GdiplusShutdown"/> when you have finished using GDI+.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/gdiplusinit/nf-gdiplusinit-gdiplusstartup"/>
        /// </para>
        /// </summary>
        /// <param name="token">
        /// Pointer to a <see cref="ULONG_PTR"/> that receives a token.
        /// Pass the token to <see cref="GdiplusShutdown"/> when you have finished using GDI+.
        /// </param>
        /// <param name="input">
        /// Pointer to a <see cref="GdiplusStartupInput"/> structure that contains the GDI+ version, a pointer to a debug callback function,
        /// a Boolean value that specifies whether to suppress the background thread,
        /// and a Boolean value that specifies whether to suppress external image codecs.
        /// </param>
        /// <param name="output"></param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns <see cref="Ok"/>, which is an element of the Status enumeration.
        /// </para>
        /// <para>
        /// If the function fails, it returns one of the other elements of the Status enumeration.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// You must call <see cref="GdiplusStartup"/> before you create any GDI+ objects,
        /// and you must delete all of your GDI+ objects (or have them go out of scope) before you call <see cref="GdiplusShutdown"/>.
        /// </para>
        /// <para>
        /// You can call <see cref="GdiplusStartup"/> on one thread and call <see cref="GdiplusShutdown"/> on another thread
        /// as long as you delete all of your GDI+ objects (or have them go out of scope) before you call <see cref="GdiplusShutdown"/>.
        /// </para>
        /// <para>
        /// Do not call <see cref="GdiplusStartup"/> or <see cref="GdiplusShutdown"/> in DllMain or in any function that is called by DllMain.
        /// If you want to create a DLL that uses GDI+, you should use one of the following techniques to initialize GDI+:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Require your clients to call <see cref="GdiplusStartup"/> before they call the functions in your DLL
        /// and to call <see cref="GdiplusShutdown"/> when they have finished using your DLL.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Export your own startup function that calls <see cref="GdiplusStartup"/>
        /// and your own shutdown function that calls <see cref="GdiplusShutdown"/>.
        /// Require your clients to call your startup function before they call other functions in your DLL
        /// and to call your shutdown function when they have finished using your DLL.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call <see cref="GdiplusStartup"/> and <see cref="GdiplusShutdown"/> in each of your functions that make GDI+ calls.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Warning
        /// </para>
        /// <para>
        /// For info about how to use dynamic data exchange (DDE) with GDI+, see Special CWinApp Services.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiplusStartup", ExactSpelling = true)]
        public static extern GpStatus GdiplusStartup([Out] out ULONG_PTR token, [In] in GdiplusStartupInput input, [Out] out GdiplusStartupOutput output);
    }
}
