using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="HIGHCONTRAST"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-highcontrastw"/>
    /// </para>
    /// </summary>
    public enum HIGHCONTRASTFlags : uint
    {
        /// <summary>
        /// The high contrast feature is on.
        /// </summary>
        HCF_HIGHCONTRASTON = 0x00000001,

        /// <summary>
        /// The high contrast feature is available.
        /// </summary>
        HCF_AVAILABLE = 0x00000002,

        /// <summary>
        /// The user can turn the high contrast feature on and off by simultaneously pressing the left ALT, left SHIFT, and PRINT SCREEN keys.
        /// </summary>
        HCF_HOTKEYACTIVE = 0x00000004,

        /// <summary>
        /// A confirmation dialog appears when the high contrast feature is activated by using the hot key.
        /// </summary>
        HCF_CONFIRMHOTKEY = 0x00000008,

        /// <summary>
        /// A siren is played when the user turns the high contrast feature on or off by using the hot key.
        /// </summary>
        HCF_HOTKEYSOUND = 0x00000010,

        /// <summary>
        /// A visual indicator is displayed when the high contrast feature is on. This value is not currently used and is ignored.
        /// </summary>
        HCF_INDICATOR = 0x00000020,

        /// <summary>
        /// The hot key associated with the high contrast feature can be enabled. An application can retrieve this value, but cannot set it.
        /// </summary>
        HCF_HOTKEYAVAILABLE = 0x00000040,
    }
}
