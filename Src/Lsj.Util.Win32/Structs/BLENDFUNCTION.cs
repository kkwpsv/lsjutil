using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="BLENDFUNCTION"/> structure controls blending by specifying the blending functions for source and destination bitmaps.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-_blendfunction
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BLENDFUNCTION
    {
        /// <summary>
        /// AC_SRC_OVER
        /// </summary>
        public static readonly byte AC_SRC_OVER = 0;

        /// <summary>
        /// This flag is set when the bitmap has an Alpha channel (that is, per-pixel alpha)
        /// Note that the APIs use premultiplied alpha, which means that the red, green and blue channel values in the bitmap
        /// must be premultiplied with the alpha channel value. 
        /// For example, if the alpha channel value is x, the red, green and blue channels must be multiplied by x and
        /// divided by 0xff prior to the call.
        /// </summary>
        public static readonly byte AC_SRC_ALPHA = 1;


        /// <summary>
        /// The source blend operation. 
        /// Currently, the only source and destination blend operation that has been defined is <see cref="AC_SRC_OVER"/>.
        /// For details, see the following Remarks section.
        /// </summary>
        public byte BlendOp;

        /// <summary>
        /// Must be zero.
        /// </summary>
        public byte BlendFlags;

        /// <summary>
        /// Specifies an alpha transparency value to be used on the entire source bitmap.
        /// The <see cref="SourceConstantAlpha"/> value is combined with any per-pixel alpha values in the source bitmap.
        /// If you set <see cref="SourceConstantAlpha"/> to 0, it is assumed that your image is transparent. 
        /// Set the <see cref="SourceConstantAlpha"/> value to 255 (opaque) when you only want to use per-pixel alpha values.
        /// </summary>
        public byte SourceConstantAlpha;

        /// <summary>
        /// This member controls the way the source and destination bitmaps are interpreted.
        /// <see cref="AlphaFormat"/> has value of <see cref="AC_SRC_ALPHA"/>
        /// </summary>
        public byte AlphaFormat;
    }


}
