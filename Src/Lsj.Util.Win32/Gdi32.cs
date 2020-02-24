using Lsj.Util.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Gdi32.dll
    /// </summary>
    public static class Gdi32
    {
        /// <summary>
        /// HGDI_ERROR
        /// </summary>
        public static readonly IntPtr HGDI_ERROR = new IntPtr(-1);

        /// <summary>
        /// <para>
        /// The <see cref="CreateCompatibleBitmap"/> function creates a bitmap compatible with the device that is associated with the specified device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createcompatiblebitmap
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to a device context.</param>
        /// <param name="nWidth">The bitmap width, in pixels.</param>
        /// <param name="nHeight">The bitmap height, in pixels.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the compatible bitmap (DDB).
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleBitmap", SetLastError = true)]
        public static extern IntPtr CreateCompatibleBitmap([In]IntPtr hdc, [In]int nWidth, [In]int nHeight);

        /// <summary>
        /// <para>
        /// The <see cref="CreateCompatibleDC"/> function creates a memory device context (DC) compatible with the specified device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createcompatibledc
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to an existing DC. If this handle is NULL, the function creates a memory DC compatible with the application's current screen.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a memory DC.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC([In]IntPtr hdc);

        /// <summary>
        /// <para>
        /// The <see cref="CreateSolidBrush"/> function creates a logical brush that has the specified solid color.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createsolidbrush
        /// </para>
        /// </summary>
        /// <param name="color">
        /// The color of the brush. To create a COLORREF color value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies a logical brush.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the HBRUSH object, call the <see cref="DeleteObject"/> function to delete it.
        /// A solid brush is a bitmap that the system uses to paint the interiors of filled shapes.
        /// After an application creates a brush by calling <see cref="CreateSolidBrush"/>,
        /// it can select that brush into any device context by calling the <see cref="SelectObject"/> function.
        /// To paint with a system color brush, an application should use <see cref="GetSysColorBrush"/> (nIndex)
        /// instead of <see cref="CreateSolidBrush"/>(<see cref="GetSysColor"/>(nIndex)),
        /// because <see cref="GetSysColorBrush"/> returns a cached brush instead of allocating a new one.
        /// ICM: No color management is done at brush creation.
        /// However, color management is performed when the brush is selected into an ICM-enabled device context.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateSolidBrush", SetLastError = true)]
        public static extern IntPtr CreateSolidBrush([In]uint color);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteDC"/> function deletes the specified device context (DC).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-deletedc
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteDC", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC([In]IntPtr hdc);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteObject"/> function deletes a logical pen, brush, font, bitmap, region, or palette, 
        /// freeing all system resources associated with the object.
        /// After the object is deleted, the specified handle is no longer valid.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-deleteobject
        /// </para>
        /// </summary>
        /// <param name="hObject">A handle to a logical pen, brush, font, bitmap, region, or palette.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the specified handle is not valid or is currently selected into a DC, the return value is <see langword="false"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteObject", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In]IntPtr hObject);

        /// <summary>
        /// <para>
        /// The <see cref="GetDeviceCaps"/> function retrieves device-specific information for the specified device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getdevicecaps
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="nIndex">The item to be returned.</param>
        /// <returns>
        /// The return value specifies the value of the desired item.
        /// When <paramref name="nIndex"/> is <see cref="DeviceCapIndexes.BITSPIXEL"/> and the device has 15bpp or 16bpp, the return value is 16.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDeviceCaps", SetLastError = true)]
        public static extern int GetDeviceCaps([In]IntPtr hdc, [In]DeviceCapIndexes nIndex);

        /// <summary>
        /// <para>
        /// The <see cref="SelectObject"/> function selects an object into the specified device context (DC).
        /// The new object replaces the previous object of the same type.
        /// </para> 
        /// <para>
        ///  From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-selectobject
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="hgdiobj">A handle to the object to be selected.</param>
        /// <returns>
        /// If the selected object is not a region and the function succeeds, the return value is a handle to the object being replaced.
        /// If the selected object is a region and the function succeeds, 
        /// the return value is one of the following values: <see cref="RegionFlags.SIMPLEREGION"/>, <see cref="RegionFlags.COMPLEXREGION"/>,
        /// <see cref="RegionFlags.NULLREGION" />
        /// If an error occurs and the selected object is not a region, the return value is <see cref="IntPtr.Zero"/>.
        /// Otherwise, it is <see cref="HGDI_ERROR"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectObject", SetLastError = true)]
        public static extern IntPtr SelectObject([In]IntPtr hdc, [In]IntPtr hgdiobj);
    }
}
