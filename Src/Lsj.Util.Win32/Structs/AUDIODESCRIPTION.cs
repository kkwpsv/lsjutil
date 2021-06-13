using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information associated with audio descriptions.
    /// This structure is used with the <see cref="SystemParametersInfo"/> function
    /// when the <see cref="SystemParametersInfoParameters.SPI_GETAUDIODESCRIPTION"/>
    /// or <see cref="SystemParametersInfoParameters.SPI_SETAUDIODESCRIPTION"/> action value is specified.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-audiodescription"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AUDIODESCRIPTION
    {
        /// <summary>
        /// The size of the structure, in bytes. The caller must set this member to <code>sizeof(AUDIODESCRIPTION)</code>.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// If this member is <see cref="TRUE"/>, audio descriptions are enabled; Otherwise, this member is <see cref="FALSE"/>.
        /// </summary>
        public BOOL Enabled;

        /// <summary>
        /// The locale identifier (LCID) of the language for the audio description. For more information, see Locales and Languages.
        /// </summary>
        public LCID Locale;
    }
}
