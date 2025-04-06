using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Msimg32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="BLENDFUNCTION"/> structure controls blending by specifying the blending functions for source and destination bitmaps.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-blendfunction"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// When the <see cref="AlphaFormat"/> member is <see cref="AC_SRC_ALPHA"/>, the source bitmap must be 32 bpp.
    /// If it is not, the <see cref="AlphaBlend"/> function will fail.
    /// </para>
    /// <para>
    /// When the <see cref="BlendOp"/> member is <see cref="AC_SRC_OVER"/>,
    /// the source bitmap is placed over the destination bitmap based on the alpha values of the source pixels.
    /// </para>
    /// <para>
    /// If the source bitmap has no per-pixel alpha value (that is, <see cref="AC_SRC_ALPHA"/> is not set),
    /// the <see cref="SourceConstantAlpha"/> value determines the blend of the source and destination bitmaps, as shown in the following table.
    /// Note that SCA is used for <see cref="SourceConstantAlpha"/> here.
    /// Also, SCA is divided by 255 because it has a value that ranges from 0 to 255.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// </listheader>
    /// <item>
    /// <term>
    /// Dst.Red
    /// </term>
    /// <term>
    /// = Src.Red * (SCA/255.0)
    /// </term>
    /// <term>
    /// + Dst.Red * (1.0 - (SCA/255.0))
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Dst.Green
    /// </term>
    /// <term>
    /// = Src.Green * (SCA/255.0)
    /// </term>
    /// <term>
    /// + Dst.Green * (1.0 - (SCA/255.0))
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Dst.Blue
    /// </term>
    /// <term>
    /// = Src.Blue * (SCA/255.0)
    /// </term>
    /// <term>
    /// + Dst.Blue * (1.0 - (SCA/255.0))
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// If the destination bitmap has an alpha channel, then the blend is as follows.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// </listheader>
    /// <item>
    /// <term>
    /// Dst.Alpha
    /// </term>
    /// <term>
    /// = Src.Alpha * (SCA/255.0)
    /// </term>
    /// <term>
    /// + Dst.Alpha * (1.0 - (SCA/255.0))
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// If the source bitmap does not use <see cref="SourceConstantAlpha"/> (that is, it equals 0xFF),
    /// the per-pixel alpha determines the blend of the source and destination bitmaps, as shown in the following table.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// </listheader>
    /// <item>
    /// <term>
    /// Dst.Red
    /// </term>
    /// <term>
    /// = Src.Red
    /// </term>
    /// <term>
    /// + (1 - Src.Alpha) * Dst.Red
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Dst.Green
    /// </term>
    /// <term>
    /// = Src.Green
    /// </term>
    /// <term>
    /// + (1 - Src.Alpha) * Dst.Green
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Dst.Blue
    /// </term>
    /// <term>
    /// = Src.Blue
    /// </term>
    /// <term>
    /// + (1 - Src.Alpha) * Dst.Blue
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// If the destination bitmap has an alpha channel, then the blend is as follows.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// </listheader>
    /// <item>
    /// <term>
    /// Dest.alpha
    /// </term>
    /// <term>
    /// = Src.Alpha
    /// </term>
    /// <term>
    /// + (1 - SrcAlpha) * Dst.Alpha
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// If the source has both the <see cref="SourceConstantAlpha"/> (that is, it is not 0xFF) and per-pixel alpha,
    /// the source is pre-multiplied by the <see cref="SourceConstantAlpha"/> and then the blend is based on the per-pixel alpha.
    /// The following tables show this. Note that <see cref="SourceConstantAlpha"/> is divided by 255 because it has a value that ranges from 0 to 255.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// </listheader>
    /// <item>
    /// <term>
    /// Src.Red
    /// </term>
    /// <term>
    /// = Src.Red
    /// </term>
    /// <term>
    /// * SourceConstantAlpha / 255.0;
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Src.Green
    /// </term>
    /// <term>
    /// = Src.Green
    /// </term>
    /// <term>
    /// * SourceConstantAlpha / 255.0;
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Src.Blue
    /// </term>
    /// <term>
    /// = Src.Blue
    /// </term>
    /// <term>
    /// * SourceConstantAlpha / 255.0;
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Src.Alpha
    /// </term>
    /// <term>
    /// = Src.Alpha
    /// </term>
    /// <term>
    /// * SourceConstantAlpha / 255.0;
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Dst.Red
    /// </term>
    /// <term>
    /// = Src.Red
    /// </term>
    /// <term>
    /// + (1 - Src.Alpha) * Dst.Red
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Dst.Green
    /// </term>
    /// <term>
    /// = Src.Green
    /// </term>
    /// <term>
    /// + (1 - Src.Alpha) * Dst.Green
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Dst.Blue
    /// </term>
    /// <term>
    /// = Src.Blue
    /// </term>
    /// <term>
    /// + (1 - Src.Alpha) * Dst.Blue
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Dst.Alpha
    /// </term>
    /// <term>
    /// = Src.Alpha
    /// </term>
    /// <term>
    /// + (1 - Src.Alpha) * Dst.Alpha
    /// </term>
    /// </item>
    /// </list>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BLENDFUNCTION
    {
        /// <summary>
        /// The source blend operation. 
        /// Currently, the only source and destination blend operation that has been defined is <see cref="AC_SRC_OVER"/>.
        /// For details, see the following Remarks section.
        /// </summary>
        public BYTE BlendOp;

        /// <summary>
        /// Must be zero.
        /// </summary>
        public BYTE BlendFlags;

        /// <summary>
        /// Specifies an alpha transparency value to be used on the entire source bitmap.
        /// The <see cref="SourceConstantAlpha"/> value is combined with any per-pixel alpha values in the source bitmap.
        /// If you set <see cref="SourceConstantAlpha"/> to 0, it is assumed that your image is transparent. 
        /// Set the <see cref="SourceConstantAlpha"/> value to 255 (opaque) when you only want to use per-pixel alpha values.
        /// </summary>
        public BYTE SourceConstantAlpha;

        /// <summary>
        /// <para>
        /// This member controls the way the source and destination bitmaps are interpreted.
        /// <see cref="AlphaFormat"/> has the following value.
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="AC_SRC_ALPHA"/>
        /// </term>
        /// <term>
        /// This flag is set when the bitmap has an Alpha channel (that is, per-pixel alpha).
        /// Note that the APIs use premultiplied alpha,
        /// which means that the red, green and blue channel values in the bitmap must be premultiplied with the alpha channel value.
        /// For example, if the alpha channel value is x, the red, green and blue channels must be multiplied by x and divided by 0xff prior to the call.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BYTE AlphaFormat;
    }


}
