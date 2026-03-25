using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes how a render target behaves when it presents its content.
    /// This enumeration allows a bitwise combination of its member values.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_present_options"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D2D1_PRESENT_OPTIONS : uint
    {
        /// <summary>
        /// The render target waits until the display refreshes to present and discards the frame upon presenting.
        /// </summary>
        D2D1_PRESENT_OPTIONS_NONE = 0x00000000,

        /// <summary>
        /// The render target does not discard the frame upon presenting.
        /// </summary>
        D2D1_PRESENT_OPTIONS_RETAIN_CONTENTS = 0x00000001,

        /// <summary>
        /// The render target does not wait until the display refreshes to present.
        /// </summary>
        D2D1_PRESENT_OPTIONS_IMMEDIATELY = 0x00000002,

        /// <summary>
        /// 
        /// </summary>
        D2D1_PRESENT_OPTIONS_FORCE_DWORD = 0xffffffff
    }
}
