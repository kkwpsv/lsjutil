using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.MappingModes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines the metafile picture format used for exchanging metafile data through the clipboard.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-metafilepict
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct METAFILEPICT
    {
        /// <summary>
        /// The mapping mode in which the picture is drawn.
        /// </summary>
        public MappingModes mm;

        /// <summary>
        /// The size of the metafile picture for all modes except the <see cref="MM_ISOTROPIC"/> and <see cref="MM_ANISOTROPIC"/> modes.
        /// (For more information about these modes, see the <see cref="yExt"/> member.)
        /// The x-extent specifies the width of the rectangle within which the picture is drawn.
        /// The coordinates are in units that correspond to the mapping mode.
        /// </summary>
        public LONG xExt;

        /// <summary>
        /// The size of the metafile picture for all modes except the <see cref="MM_ISOTROPIC"/> and <see cref="MM_ANISOTROPIC"/> modes.
        /// The y-extent specifies the height of the rectangle within which the picture is drawn.
        /// The coordinates are in units that correspond to the mapping mode.
        /// For <see cref="MM_ISOTROPIC"/> and <see cref="MM_ANISOTROPIC"/> modes, which can be scaled,
        /// the <see cref="xExt"/> and <see cref="yExt"/> members contain an optional suggested size in <see cref="MM_HIMETRIC"/> units.
        /// For <see cref="MM_ANISOTROPIC"/> pictures, <see cref="xExt"/> and <see cref="yExt"/> can be zero when no suggested size is supplied.
        /// For <see cref="MM_ISOTROPIC"/> pictures, an aspect ratio must be supplied even when no suggested size is given.
        /// (If a suggested size is given, the aspect ratio is implied by the size.)
        /// To give an aspect ratio without implying a suggested size, set <see cref="xExt"/> and <see cref="yExt"/> to negative values
        /// whose ratio is the appropriate aspect ratio.
        /// The magnitude of the negative xExt and yExt values is ignored; only the ratio is used.
        /// </summary>
        public LONG yExt;

        /// <summary>
        /// A handle to a memory metafile.
        /// </summary>
        public HMETAFILE hMF;
    }
}
