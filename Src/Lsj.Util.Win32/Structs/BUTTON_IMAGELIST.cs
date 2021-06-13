using System;
using System.Runtime.InteropServices;
using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about an image list that is used with a button control.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/ns-commctrl-button_imagelist"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BUTTON_IMAGELIST
    {
        /// <summary>
        /// BCCL_NOGLYPH
        /// </summary>
        public static readonly IntPtr BCCL_NOGLYPH = (IntPtr)(-1);

        /// <summary>
        /// A handle to the image list.
        /// The provider retains ownership of the image list and is ultimately responsible for its disposal.
        /// Under Windows Vista, you can pass <see cref="BCCL_NOGLYPH"/> in this parameter to indicate that no glyph should be displayed.
        /// </summary>
        public IntPtr himl;

        /// <summary>
        /// A RECT that specifies the margin around the icon.
        /// </summary>
        public RECT margin;

        /// <summary>
        /// A UINT that specifies the alignment to use.
        /// </summary>
        public BUTTON_IMAGELISTAligns uAlign;
    }
}
