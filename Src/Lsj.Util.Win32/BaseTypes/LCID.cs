using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A locale identifier. For more information, see Locale Identifiers.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/winprog/windows-data-types
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct LCID
    {
        /// <summary>
        /// LOCALE_CUSTOM_DEFAULT
        /// </summary>
        public static readonly LCID LOCALE_CUSTOM_DEFAULT = new LCID { _value = 0x0c00 };

        /// <summary>
        /// LOCALE_CUSTOM_UI_DEFAULT
        /// </summary>
        public static readonly LCID LOCALE_CUSTOM_UI_DEFAULT = new LCID { _value = 0x1400 };

        /// <summary>
        /// LOCALE_CUSTOM_UNSPECIFIED
        /// </summary>
        public static readonly LCID LOCALE_CUSTOM_UNSPECIFIED = new LCID { _value = 0x1000 };

        /// <summary>
        /// LOCALE_INVARIANT
        /// </summary>
        public static readonly LCID LOCALE_INVARIANT = new LCID { _value = 0x007f };

        /// <summary>
        /// LOCALE_SYSTEM_DEFAULT
        /// </summary>
        public static readonly LCID LOCALE_SYSTEM_DEFAULT = new LCID { _value = 0x0800 };

        /// <summary>
        /// LOCALE_USER_DEFAULT
        /// </summary>
        public static readonly LCID LOCALE_USER_DEFAULT = new LCID { _value = 0x0400 };

        [FieldOffset(0)]
        private uint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(LCID val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LCID(uint val) => new LCID { _value = val };
    }
}
