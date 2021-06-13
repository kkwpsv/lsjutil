using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// The <see cref="SECURITY_INFORMATION"/> data type identifies the object-related security information being set or queried.
    /// This security information includes:
    /// The owner of an object
    /// The primary group of an object
    /// The discretionary access control list (DACL) of an object
    /// The system access control list (SACL) of an object
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/secauthz/security-information"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct SECURITY_INFORMATION
    {
        [FieldOffset(0)]
        private uint _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(SECURITY_INFORMATION val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator SECURITY_INFORMATION(uint val) => new SECURITY_INFORMATION { _value = val };
    }
}
