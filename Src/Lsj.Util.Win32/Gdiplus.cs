﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;

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
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipCreateFromHDC", ExactSpelling = true, SetLastError = true)]
        public static extern GpStatus GdipCreateFromHDC([In] HDC hdc, [Out] out IntPtr graphics);

        /// <summary>
        /// Releases resources used by the Image object.
        /// </summary>
        /// <param name="image">Image object.</param>
        /// <returns></returns>
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipDisposeImage", ExactSpelling = true, SetLastError = true)]
        public static extern GpStatus GdipDisposeImage([In] IntPtr image);

        /// <summary>
        /// Draws an image at a specified location.
        /// </summary>
        /// <param name="graphics">Graphics object.</param>
        /// <param name="image">Image object.</param>
        /// <param name="x">X postion.</param>
        /// <param name="y">Y position.</param>
        /// <returns></returns>
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipDrawImage", ExactSpelling = true, SetLastError = true)]
        public static extern GpStatus GdipDrawImage([In] IntPtr graphics, [In] IntPtr image, [In] float x, [In] float y);

        /// <summary>
        /// Draws an image at a specified location.
        /// </summary>
        /// <param name="graphics">Graphics object.</param>
        /// <param name="image">Image object.</param>
        /// <param name="x">X postion.</param>
        /// <param name="y">Y position.</param>
        /// <returns></returns>
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipDrawImageI", ExactSpelling = true, SetLastError = true)]
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
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipDrawImageRect", ExactSpelling = true, SetLastError = true)]
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
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipDrawImageRectI", ExactSpelling = true, SetLastError = true)]
        public static extern GpStatus GdipDrawImageRectI([In] IntPtr graphics, [In] IntPtr image, [In] int x, [In] int y, [In] int width, [In] int height);

        /// <summary>
        /// Creates an Image object based on a file. This flat function does not use ICM.
        /// <param name="filename">Image file name.</param>
        /// <param name="image">Image object.</param>
        /// <returns>
        /// </returns>
        /// </summary>
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdipLoadImageFromFile", ExactSpelling = true, SetLastError = true)]
        public static extern GpStatus GdipLoadImageFromFile([In][MarshalAs(UnmanagedType.LPWStr)] string filename, [Out] out IntPtr image);

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
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiplusShutdown", ExactSpelling = true, SetLastError = true)]
        public static extern void GdiplusShutdown([In] ULONG_PTR token);

        /// <summary>
        /// <para>
        /// The <see cref="GdiplusStartup"/> function initializes Windows GDI+.
        /// Call <see cref="GdiplusStartup"/> before making any other GDI+ calls, and call <see cref="GdiplusShutdown"/> when you have finished using GDI+.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/gdiplusinit/nf-gdiplusinit-gdiplusstartup"/>
        /// </para>
        /// </summary>
        /// <param name="token">
        /// Pointer to a ULONG_PTR that receives a token. Pass the token to <see cref="GdiplusShutdown"/> when you have finished using GDI+.
        /// </param>
        /// <param name="input">
        /// Pointer to a <see cref="GdiplusStartupInput"/>  structure that contains the GDI+ version, a pointer to a debug callback function,
        /// a Boolean value that specifies whether to suppress the background thread,
        /// and a Boolean value that specifies whether to suppress external image codecs.
        /// </param>
        /// <param name="output"></param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="GpStatus.Ok"/>.
        /// If the function fails, it returns one of the other elements of the <see cref="GpStatus"/> enumeration.
        /// </returns>
        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiplusStartup", ExactSpelling = true, SetLastError = true)]
        public static extern GpStatus GdiplusStartup([Out] out ULONG_PTR token, [In] ref GdiplusStartupInput input, [Out] out GdiplusStartupOutput output);
    }
}
