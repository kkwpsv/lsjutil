using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// LGRPID
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct LGRPID
    {
        /// <summary>
        /// LGRPID_WESTERN_EUROPE
        /// </summary>
        public static readonly LGRPID LGRPID_WESTERN_EUROPE = 0x0001;

        /// <summary>
        /// LGRPID_CENTRAL_EUROPE
        /// </summary>
        public static readonly LGRPID LGRPID_CENTRAL_EUROPE = 0x0002;

        /// <summary>
        /// LGRPID_BALTIC
        /// </summary>
        public static readonly LGRPID LGRPID_BALTIC = 0x0003;

        /// <summary>
        /// LGRPID_GREEK
        /// </summary>
        public static readonly LGRPID LGRPID_GREEK = 0x0004;

        /// <summary>
        /// LGRPID_CYRILLIC
        /// </summary>
        public static readonly LGRPID LGRPID_CYRILLIC = 0x0005;

        /// <summary>
        /// LGRPID_TURKIC
        /// </summary>
        public static readonly LGRPID LGRPID_TURKIC = 0x0006;

        /// <summary>
        /// LGRPID_TURKISH
        /// </summary>
        public static readonly LGRPID LGRPID_TURKISH = 0x0006;

        /// <summary>
        /// LGRPID_JAPANESE
        /// </summary>
        public static readonly LGRPID LGRPID_JAPANESE = 0x0007;

        /// <summary>
        /// LGRPID_KOREAN
        /// </summary>
        public static readonly LGRPID LGRPID_KOREAN = 0x0008;

        /// <summary>
        /// LGRPID_TRADITIONAL_CHINESE
        /// </summary>
        public static readonly LGRPID LGRPID_TRADITIONAL_CHINESE = 0x0009;

        /// <summary>
        /// LGRPID_SIMPLIFIED_CHINESE
        /// </summary>
        public static readonly LGRPID LGRPID_SIMPLIFIED_CHINESE = 0x000a;

        /// <summary>
        /// LGRPID_THAI
        /// </summary>
        public static readonly LGRPID LGRPID_THAI = 0x000b;

        /// <summary>
        /// LGRPID_HEBREW
        /// </summary>
        public static readonly LGRPID LGRPID_HEBREW = 0x000c;

        /// <summary>
        /// LGRPID_ARABIC
        /// </summary>
        public static readonly LGRPID LGRPID_ARABIC = 0x000d;

        /// <summary>
        /// LGRPID_VIETNAMESE
        /// </summary>
        public static readonly LGRPID LGRPID_VIETNAMESE = 0x000e;

        /// <summary>
        /// LGRPID_INDIC
        /// </summary>
        public static readonly LGRPID LGRPID_INDIC = 0x000f;

        /// <summary>
        /// LGRPID_GEORGIAN
        /// </summary>
        public static readonly LGRPID LGRPID_GEORGIAN = 0x0010;

        /// <summary>
        /// LGRPID_ARMENIAN
        /// </summary>
        public static readonly LGRPID LGRPID_ARMENIAN = 0x0011;

        [FieldOffset(0)]
        private uint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(LGRPID val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LGRPID(uint val) => new LGRPID { _value = val };
    }
}
