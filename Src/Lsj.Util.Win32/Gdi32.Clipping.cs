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
        /// The <see cref="SelectClipRgn"/> function selects a region as the current clipping region for the specified device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-selectcliprgn
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// A handle to the region to be selected.
        /// </param>
        /// <returns>
        /// The return value specifies the region's complexity and can be one of the following values.
        /// <see cref="NULLREGION"/>: Region is empty.
        /// <see cref="SIMPLEREGION"/>: Region is a single rectangle.
        /// <see cref="COMPLEXREGION"/>: Region is more than one rectangle.
        /// <see cref="ERROR"/>: An error occurred. (The previous clipping region is unaffected.)
        /// </returns>
        /// <remarks>
        /// Only a copy of the selected region is used. The region itself can be selected for any number of other device contexts or it can be deleted.
        /// The <see cref="SelectClipRgn"/> function assumes that the coordinates for a region are specified in device units.
        /// To remove a device-context's clipping region, specify a <see cref="NULL"/> region handle.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectClipRgn", SetLastError = true)]
        public static extern int SelectClipRgn([In]HDC hdc, [In]HRGN hrgn);
    }
}
