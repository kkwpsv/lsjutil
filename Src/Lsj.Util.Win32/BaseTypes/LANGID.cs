using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A language identifier.
    /// For more information, see Language Identifiers.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct LANGID
    {
        /// <summary>
        /// <para>
        /// Creates a language identifier from a primary language identifier and a sublanguage identifier.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nf-winnt-makelangid"/>
        /// </para>
        /// </summary>
        /// <param name="p">
        /// Primary language identifier.
        /// This identifier can be a predefined value or a value for a user-defined primary language.
        /// For a user-defined language, the identifier is a value in the range 0x0200 to 0x03FF.
        /// All other values are reserved for operating system use.
        /// For more information, see Language Identifier Constants and Strings.
        /// </param>
        /// <param name="s">
        /// Sublanguage identifier.
        /// This parameter can be a predefined sublanguage identifier or a user-defined sublanguage.
        /// For a user-defined sublanguage, the identifier is a value in the range 0x20 to 0x3F.
        /// All other values are reserved for operating system use.
        /// For more information, see Language Identifier Constants and Strings.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The following table shows combinations of <paramref name="p"/> and <paramref name="s"/> that have special meaning.
        /// REMARKS
        /// Primary language identifier	Sublanguage identifier  	                Meaning
        /// <see cref="LANG_NEUTRAL"/>	<see cref="SUBLANG_NEUTRAL"/>	            Language neutral
        /// <see cref="LANG_NEUTRAL"/>	<see cref="SUBLANG_DEFAULT"/>	            User default language
        /// <see cref="LANG_NEUTRAL"/>	<see cref="SUBLANG_SYS_DEFAULT"/>	        System default language
        /// <see cref="LANG_NEUTRAL"/>	<see cref="SUBLANG_CUSTOM_DEFAULT"/>	    Windows Vista and later: Default custom locale
        /// <see cref="LANG_NEUTRAL"/>	<see cref="SUBLANG_CUSTOM_UNSPECIFIED"/>	Windows Vista and later: Unspecified custom locale
        /// <see cref="LANG_NEUTRAL"/>	<see cref="SUBLANG_UI_CUSTOM_DEFAULT"/>	    Windows Vista and later: Default custom Multilingual User Interface locale
        /// </remarks>
        public static LANGID MAKELANGID(WORD p, WORD s) => (ushort)((s << 10) | p);


        /// <summary>
        /// LANG_NEUTRAL
        /// </summary>
        public const ushort LANG_NEUTRAL = 0x00;

        /// <summary>
        /// SUBLANG_NEUTRAL
        /// </summary>
        public const ushort SUBLANG_NEUTRAL = 0x00;

        /// <summary>
        /// SUBLANG_DEFAULT
        /// </summary>
        public const ushort SUBLANG_DEFAULT = 0x01;

        /// <summary>
        /// SUBLANG_SYS_DEFAULT
        /// </summary>
        public const ushort SUBLANG_SYS_DEFAULT = 0x02;

        /// <summary>
        /// SUBLANG_CUSTOM_DEFAULT
        /// </summary>
        public const ushort SUBLANG_CUSTOM_DEFAULT = 0x03;

        /// <summary>
        /// SUBLANG_CUSTOM_UNSPECIFIED
        /// </summary>
        public const ushort SUBLANG_CUSTOM_UNSPECIFIED = 0x04;

        /// <summary>
        /// SUBLANG_UI_CUSTOM_DEFAULT
        /// </summary>
        public const ushort SUBLANG_UI_CUSTOM_DEFAULT = 0x05;


        [FieldOffset(0)]
        private ushort _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ushort(LANGID val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LANGID(ushort val) => new LANGID { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator short(LANGID val) => unchecked((short)val._value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LANGID(short val) => new LANGID { _value = unchecked((ushort)val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(LANGID val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(LANGID val) => val._value;
    }
}
