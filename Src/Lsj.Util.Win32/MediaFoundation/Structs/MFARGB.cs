using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.MediaFoundation.Structs
{
    /// <summary>
    /// <para>
    /// Describes an ARGB color value.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/ns-mfobjects-mfargb"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MFARGB
    {
        /// <summary>
        /// Blue value.
        /// </summary>
        public BYTE rgbBlue;

        /// <summary>
        /// Green value.
        /// </summary>
        public BYTE rgbGreen;

        /// <summary>
        /// Red value.
        /// </summary>
        public BYTE rgbRed;

        /// <summary>
        /// Alpha value.
        /// </summary>
        public BYTE rgbAlpha;
    }
}
