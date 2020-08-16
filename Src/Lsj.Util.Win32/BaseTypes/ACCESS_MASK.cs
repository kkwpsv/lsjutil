using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// The <see cref="ACCESS_MASK"/> data type is a <see cref="DWORD"/> value that defines standard, specific, and generic rights.
    /// These rights are used in access control entries (ACEs) and are the primary means of specifying the requested or granted access to an object.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/secauthz/access-mask
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct ACCESS_MASK
    {
        /// <summary>
        /// AccessSystemAcl access type
        /// </summary>
        public static readonly ACCESS_MASK ACCESS_SYSTEM_SECURITY = new ACCESS_MASK { _value = 0x01000000 };

        /// <summary>
        /// MaximumAllowed access type
        /// </summary>
        public static readonly ACCESS_MASK MAXIMUM_ALLOWED = new ACCESS_MASK { _value = 0x02000000 };

        [FieldOffset(0)]
        private uint _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ACCESS_MASK operator |(ACCESS_MASK x, ACCESS_MASK y) => x._value | y._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ACCESS_MASK operator &(ACCESS_MASK x, ACCESS_MASK y) => x._value & y._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static ACCESS_MASK operator ^(ACCESS_MASK x, ACCESS_MASK y) => x._value ^ y._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static ACCESS_MASK operator ~(ACCESS_MASK x) => ~x._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(ACCESS_MASK val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ACCESS_MASK(uint val) => new ACCESS_MASK { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ACCESS_MASK(GenericAccessRights val) => new ACCESS_MASK { _value = (uint)val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ACCESS_MASK(StandardAccessRights val) => new ACCESS_MASK { _value = (uint)val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ACCESS_MASK(DesktopAccessRights val) => new ACCESS_MASK { _value = (uint)val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ACCESS_MASK(FileAccessRights val) => new ACCESS_MASK { _value = (uint)val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ACCESS_MASK(FileMapAccessRights val) => new ACCESS_MASK { _value = (uint)val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ACCESS_MASK(SynchronizationObjectAccessRights val) => new ACCESS_MASK { _value = (uint)val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ACCESS_MASK(ProcessAccessRights val) => new ACCESS_MASK { _value = (uint)val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ACCESS_MASK(ThreadAccessRights val) => new ACCESS_MASK { _value = (uint)val };
    }
}
