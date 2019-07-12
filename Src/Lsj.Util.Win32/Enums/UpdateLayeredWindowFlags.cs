using System;
using System.Collections.Generic;
using System.Text;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="UpdateLayeredWindow"/> flags.
    /// <para>
    /// From: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-updatelayeredwindow
    /// </para>
    /// </summary>
    public enum UpdateLayeredWindowFlags : uint
    {
        /// <summary>
        /// Use pblend as the blend function. If the display mode is 256 colors or less, the effect of this value is the same as the effect of <see cref="ULW_OPAQUE"/>.
        /// </summary>
        ULW_ALPHA = 2,

        /// <summary>
        /// Use crKey as the transparency color.
        /// </summary>
        ULW_COLORKEY = 1,

        /// <summary>
        /// Draw an opaque layered window.
        /// </summary>
        ULW_OPAQUE = 4,

        /// <summary>
        /// Force the UpdateLayeredWindowIndirect function to fail if the current window size does not match the size specified in the psize.
        /// </summary>
        ULW_EX_NORESIZE = 8,
    }
}
