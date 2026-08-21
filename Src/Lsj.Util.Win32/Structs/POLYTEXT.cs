using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ExtTextOutOptions;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="POLYTEXT"/> structure describes how the <see cref="PolyTextOut"/> function should draw a string of text.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-polytextw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct POLYTEXT
    {
        /// <summary>
        /// The horizontal reference point for the string. The string is aligned to this point using the current text-alignment mode.
        /// </summary>
        public int x;

        /// <summary>
        /// The vertical reference point for the string. The string is aligned to this point using the current text-alignment mode.
        /// </summary>
        public int y;

        /// <summary>
        /// The length of the string pointed to by lpstr.
        /// </summary>
        public UINT n;

        /// <summary>
        /// Pointer to a string of text to be drawn by the <see cref="PolyTextOut"/> function.
        /// This string need not be null-terminated, since n specifies the length of the string.
        /// </summary>
        public nint lpstr;

        /// <summary>
        /// <para>
        /// Specifies whether the string is to be opaque or clipped and whether the string is accompanied by an array of character-width values.
        /// This member can be one or more of the following values.
        /// </para>
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
        /// <see cref="ETO_OPAQUE"/>
        /// </term>
        /// <term>
        /// The rectangle for each string is to be opaqued with the current background color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ETO_CLIPPED"/>
        /// </term>
        /// <term>
        /// Each string is to be clipped to its specified rectangle.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public ExtTextOutOptions uiFlags;

        /// <summary>
        /// A rectangle structure that contains the dimensions of the opaquing or clipping rectangle.
        /// This member is ignored if neither of the <see cref="ETO_OPAQUE"/>
        /// nor the <see cref="ETO_CLIPPED"/> value is specified for the <see cref="uiFlags"/> member.
        /// </summary>
        public RECT rcl;

        /// <summary>
        /// Pointer to an array containing the width value for each character in the string.
        /// </summary>
        public P<int> pdx;
    }
}
