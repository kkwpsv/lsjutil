using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DIBColorTableIdentifiers;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="EMRALPHABLEND"/> structure contains members for the <see cref="AlphaBlend"/> enhanced metafile record.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-emralphablend"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is to be used during metafile playback.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct EMRALPHABLEND
    {
        /// <summary>
        /// The base structure for all record types.
        /// </summary>
        public EMR emr;

        /// <summary>
        /// Bounding rectangle, in device units.
        /// </summary>
        public RECTL rclBounds;

        /// <summary>
        /// The x coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </summary>
        public LONG xDest;

        /// <summary>
        /// The y coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </summary>
        public LONG yDest;

        /// <summary>
        /// Logical width of the destination rectangle.
        /// </summary>
        public LONG cxDest;

        /// <summary>
        /// Logical height of the destination rectangle.
        /// </summary>
        public LONG cyDest;

        /// <summary>
        /// Stores the <see cref="BLENDFUNCTION"/> structure.
        /// </summary>
        public DWORD dwRop;

        /// <summary>
        /// Logical x coordinate of the upper-left corner of the source rectangle.
        /// </summary>
        public LONG xSrc;

        /// <summary>
        /// Logical y coordinate of the upper-left corner of the source rectangle.
        /// </summary>
        public LONG ySrc;

        /// <summary>
        /// World-space to page-space transformation of the source device context.
        /// </summary>
        public XFORM xformSrc;

        /// <summary>
        /// Background color (the RGB value) of the source device context.
        /// To make a <see cref="COLORREF"/> value, use the <see cref="RGB"/> macro.
        /// </summary>
        public COLORREF crBkColorSrc;

        /// <summary>
        /// Source bitmap information color table usage (<see cref="DIB_RGB_COLORS"/>).
        /// </summary>
        public DWORD iUsageSrc;

        /// <summary>
        /// Offset to the source <see cref="BITMAPINFO"/> structure.
        /// </summary>
        public DWORD offBmiSrc;

        /// <summary>
        /// Size of the source <see cref="BITMAPINFO"/> structure.
        /// </summary>
        public DWORD cbBmiSrc;

        /// <summary>
        /// Offset to the source bitmap bits.
        /// </summary>
        public DWORD offBitsSrc;

        /// <summary>
        /// Size of the source bitmap bits.
        /// </summary>
        public DWORD cbBitsSrc;

        /// <summary>
        /// Width of source rectangle in logical units.
        /// </summary>
        public LONG cxSrc;

        /// <summary>
        /// Height of the source rectangle in logical units.
        /// </summary>
        public LONG cySrc;
    }
}
