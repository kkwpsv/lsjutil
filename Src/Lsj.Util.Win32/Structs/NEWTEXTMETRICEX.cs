using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="NEWTEXTMETRICEX"/> structure contains information about a physical font.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-newtextmetricexw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NEWTEXTMETRICEX
    {
        /// <summary>
        /// A NEWTEXTMETRIC structure.
        /// </summary>
        public NEWTEXTMETRIC ntmTm;

        /// <summary>
        /// A FONTSIGNATURE structure indicating the coverage of the font.
        /// </summary>
        public FONTSIGNATURE ntmFontSig;
    }
}
