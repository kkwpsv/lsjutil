using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.UpdateLayeredWindowFlags;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Used by <see cref="UpdateLayeredWindowIndirect"/> to provide position, size, shape, content, and translucency information for a layered window.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-updatelayeredwindowinfo
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct UPDATELAYEREDWINDOWINFO
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// A handle to a DC for the screen.
        /// This handle is obtained by specifying NULL in this member when calling <see cref="UpdateLayeredWindowIndirect"/>.
        /// The handle is used for palette color matching when the window contents are updated.
        /// If <see cref="hdcDst"/> is <see cref="NULL"/>, the default palette is used.
        /// If <see cref="hdcSrc"/> is <see cref="NULL"/>, hdcDst must be <see cref="NULL"/>.
        /// </summary>
        public HDC hdcDst;

        /// <summary>
        /// The new screen position of the layered window.
        /// If the new position is unchanged from the current position, <see cref="pptDst"/> can be <see cref="NULL"/>.
        /// </summary>
        public IntPtr pptDst;

        /// <summary>
        /// The new size of the layered window.
        /// If the size of the window will not change, this parameter can be <see cref="NULL"/>.
        /// If <see cref="hdcSrc"/> is <see cref="NULL"/>, <see cref="psize"/> must be <see cref="NULL"/>.
        /// </summary>
        public IntPtr psize;

        /// <summary>
        /// A handle to the DC for the surface that defines the layered window.
        /// This handle can be obtained by calling the <see cref="CreateCompatibleDC"/> function.
        /// If the shape and visual context of the window will not change, <see cref="hdcSrc"/> can be <see cref="NULL"/>.
        /// </summary>
        public HDC hdcSrc;

        /// <summary>
        /// The location of the layer in the device context.
        /// If <see cref="hdcSrc"/> is <see cref="NULL"/>, <see cref="pptSrc"/> should be <see cref="NULL"/>.
        /// </summary>
        public IntPtr pptSrc;

        /// <summary>
        /// The color key to be used when composing the layered window.
        /// To generate a <see cref="COLORREF"/>, use the <see cref="RGB"/> macro.
        /// </summary>
        public COLORREF crKey;

        /// <summary>
        /// The transparency value to be used when composing the layered window.
        /// </summary>
        public IntPtr pblend;

        /// <summary>
        /// This parameter can be one of the following values.
        /// <see cref="ULW_ALPHA"/>:
        /// Use <see cref="pblend"/> as the blend function.
        /// If the display mode is 256 colors or less, the effect of this value is the same as the effect of <see cref="ULW_OPAQUE"/>.
        /// <see cref="ULW_COLORKEY"/>:
        /// Use <see cref="crKey"/> as the transparency color.
        /// <see cref="ULW_OPAQUE"/>:
        /// Draw an opaque layered window.
        /// <see cref="ULW_EX_NORESIZE"/>:
        /// Force the <see cref="UpdateLayeredWindowIndirect"/> function to fail
        /// if the current window size does not match the size specified in the <see cref="psize"/>. 
        /// If <see cref="hdcSrc"/> is <see cref="NULL"/>, <see cref="dwFlags"/> should be zero.
        /// </summary>
        public UpdateLayeredWindowFlags dwFlags;

        /// <summary>
        /// The area to be updated.
        /// This parameter can be <see cref="NULL"/>.
        /// If it is non-NULL, only the area in this rectangle is updated from the source DC.
        /// </summary>
        public IntPtr prcDirty;
    }
}
