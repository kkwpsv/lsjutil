using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.LANGID;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A locale identifier.
    /// For more information, see Locale Identifiers.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/winprog/windows-data-types"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct LCID
    {
        /// <summary>
        /// <para>
        /// Creates a locale identifier from a language identifier and a sort order identifier.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/nf-winnt-makelcid"/>
        /// </para>
        /// </summary>
        /// <param name="lgid">
        /// Language identifier.
        /// This identifier is a combination of a primary language identifier and a sublanguage identifier
        /// and is usually created by using the <see cref="MAKELANGID"/> macro.
        /// </param>
        /// <param name="srtid">
        /// Sort order identifier.
        /// </param>
        /// <returns></returns>
        public static LCID MAKELCID(WORD lgid, WORD srtid) => (uint)((srtid) << 16) | (lgid);

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
        /// LOCALE_IMEASURE
        /// </summary>
        public static readonly LCID LOCALE_IMEASURE = new LCID { _value = 0x0000000D };

        /// <summary>
        /// LOCALE_INVARIANT
        /// </summary>
        public static readonly LCID LOCALE_INVARIANT = new LCID { _value = 0x007f };

        /// <summary>
        /// LOCALE_SSHORTDATE
        /// </summary>
        public static readonly LCID LOCALE_SSHORTDATE = new LCID { _value = 0x0000001F };

        /// <summary>
        /// LOCALE_STIMEFORMAT
        /// </summary>
        public static readonly LCID LOCALE_STIMEFORMAT = new LCID { _value = 0x00001003 };

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
