using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the screen orientation preference for a desktop app process.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-orientation_preference"/>
    /// </para>
    /// </summary>
    public enum ORIENTATION_PREFERENCE
    {
        /// <summary>
        /// The process has no device orientation preferences.
        /// The system may choose any available setting.
        /// </summary>
        ORIENTATION_PREFERENCE_NONE = 0x0,

        /// <summary>
        /// The process represents a desktop app that can be used in landscape mode.
        /// </summary>
        ORIENTATION_PREFERENCE_LANDSCAPE = 0x1,

        /// <summary>
        /// The process represents a desktop app that can be used in portrait mode.
        /// </summary>
        ORIENTATION_PREFERENCE_PORTRAIT = 0x2,

        /// <summary>
        /// The process represents a desktop app that can be used in flipped landscape mode.
        /// </summary>
        ORIENTATION_PREFERENCE_LANDSCAPE_FLIPPED = 0x4,

        /// <summary>
        /// The process represents a desktop app that can be used in flipped portrait mode.
        /// </summary>
        ORIENTATION_PREFERENCE_PORTRAIT_FLIPPED = 0x8
    }
}
