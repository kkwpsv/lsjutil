using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="CreateBitmap"/> function creates a bitmap with the specified width, height, and color format (color planes and bits-per-pixel).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createbitmap
        /// </para>
        /// </summary>
        /// <param name="nWidth">
        /// The bitmap width, in pixels.
        /// </param>
        /// <param name="nHeight">
        /// The bitmap height, in pixels.
        /// </param>
        /// <param name="nPlanes">
        /// The number of color planes used by the device.
        /// </param>
        /// <param name="nBitCount">
        /// The number of bits required to identify the color of a single pixel.
        /// </param>
        /// <param name="lpBits">
        /// A pointer to an array of color data used to set the colors in a rectangle of pixels.
        /// Each scan line in the rectangle must be word aligned (scan lines that are not word aligned must be padded with zeros).
        /// If this parameter is <see cref="NULL"/>, the contents of the new bitmap is undefined.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a bitmap.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// This function can return the following value.
        /// <see cref="ERROR_INVALID_BITMAP"/>: The calculated size of the bitmap is less than zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateBitmap"/> function creates a device-dependent bitmap.
        /// After a bitmap is created, it can be selected into a device context by calling the <see cref="SelectObject"/> function.
        /// However, the bitmap can only be selected into a device context if the bitmap and the DC have the same format.
        /// The <see cref="CreateBitmap"/> function can be used to create color bitmaps.
        /// However, for performance reasons applications should use <see cref="CreateBitmap"/> to create monochrome bitmaps
        /// and <see cref="CreateCompatibleBitmap"/> to create color bitmaps.
        /// Whenever a color bitmap returned from <see cref="CreateBitmap"/> is selected into a device context,
        /// the system checks that the bitmap matches the format of the device context it is being selected into.
        /// Because <see cref="CreateCompatibleBitmap"/> takes a device context, it returns a bitmap that has the same format as the specified device context.
        /// Thus, subsequent calls to <see cref="SelectObject"/> are faster with a color bitmap from <see cref="CreateCompatibleBitmap"/>
        /// than with a color bitmap returned from <see cref="CreateBitmap"/>.
        /// If the bitmap is monochrome, zeros represent the foreground color and ones represent the background color for the destination device context.
        /// If an application sets the nWidth or nHeight parameters to zero, <see cref="CreateBitmap"/> returns the handle to a 1-by-1 pixel, monochrome bitmap.
        /// When you no longer need the bitmap, call the <see cref="DeleteObject"/> function to delete it.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleBitmap", SetLastError = true)]
        public static extern HBITMAP CreateBitmap([In]int nWidth, [In]int nHeight, [In]UINT nPlanes, [In]UINT nBitCount, [In]IntPtr lpBits);
    }
}
