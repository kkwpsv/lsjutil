using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information associated with audio descriptions.
    /// This structure is used with the <see cref="SystemParametersInfo"/> function
    /// when the <see cref="SystemParametersInfoParameters.SPI_GETAUDIODESCRIPTION"/>
    /// or <see cref="SystemParametersInfoParameters.SPI_SETAUDIODESCRIPTION"/> action value is specified.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AUDIODESCRIPTION
    {
        /// <summary>
        /// The size of the structure, in bytes. The caller must set this member to <code>sizeof(AUDIODESCRIPTION)</code>.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// If this member is <see langword="true"/>, audio descriptions are enabled; Otherwise, this member is <see langword="false"/>.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool Enabled;

        /// <summary>
        /// The locale identifier (LCID) of the language for the audio description. For more information, see Locales and Languages.
        /// </summary>
        public uint Locale;
    }
}
