using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.StandardAccessRights;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// The <see cref="ACCESS_MASK"/> data type is a <see cref="DWORD"/> value that defines standard, specific, and generic rights.
    /// These rights are used in access control entries (ACEs) and are the primary means of specifying the requested or granted access to an object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/secauthz/access-mask"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The bits in this value are allocated as follows.
    /// </para>
    /// <para>
    /// The bits in this value are allocated as follows.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Bits
    /// </term>
    /// <term>
    /// Meaning
    /// </term>
    /// </listheader>
    /// <term>
    /// 0 15
    /// </term>
    /// <term>
    /// Specific rights. Contains the access mask specific to the object type associated with the mask.
    /// </term>
    /// <item>
    /// <term>
    /// 16 23
    /// </term>
    /// <term>
    /// Standard rights. Contains the object's standard access rights.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 24
    /// </term>
    /// <term>
    /// Access system security (<see cref="ACCESS_SYSTEM_SECURITY"/>). It is used to indicate access to a  (SACL).
    /// This type of access requires the calling process to have the <see cref="SE_SECURITY_NAME"/> (Manage auditing and security log) privilege.
    /// If this flag is set in the access mask of an audit access ACE (successful or unsuccessful access), the SACL access will be audited.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 25
    /// </term>
    /// <term>
    /// Maximum allowed (<see cref="MAXIMUM_ALLOWED"/>).
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 26 27
    /// </term>
    /// <term>
    /// Reserved.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 28
    /// </term>
    /// <term>
    /// Generic all (<see cref="GENERIC_ALL"/>).
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 29
    /// </term>
    /// <term>
    /// Generic execute (<see cref="GENERIC_EXECUTE"/>).
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 30
    /// </term>
    /// <term>
    /// Generic write (<see cref="GENERIC_WRITE"/>).
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 31
    /// </term>
    /// <term>
    /// Generic read (<see cref="GENERIC_READ"/>).
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// Standard rights bits, 16 to 23, contain the object's standard access rights and can be a combination of the following predefined flags.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Bit
    /// </term>
    /// <term>
    /// Flag
    /// </term>
    /// <term>
    /// Meaning
    /// </term>
    /// </listheader>
    /// <term>
    /// 16
    /// </term>
    /// <term>
    /// <see cref="DELETE"/>
    /// </term>
    /// <term>
    /// Delete access.
    /// </term>
    /// <item>
    /// <term>
    /// 17
    /// </term>
    /// <term>
    /// <see cref="READ_CONTROL"/>
    /// </term>
    /// <term>
    /// Read access to the owner, group, and  (DACL) of the security descriptor.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 18
    /// </term>
    /// <term>
    /// <see cref="WRITE_DAC"/>
    /// </term>
    /// <term>
    /// Write access to the DACL.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 19
    /// </term>
    /// <term>
    /// <see cref="WRITE_OWNER"/>
    /// </term>
    /// <term>
    /// Write access to owner.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// 20
    /// </term>
    /// <term>
    /// <see cref="SYNCHRONIZE"/>
    /// </term>
    /// <term>
    /// Synchronize access.
    /// </term>
    /// </item>
    /// </list>
    /// </remarks>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ACCESS_MASK(TokenAccessRights val) => new ACCESS_MASK { _value = (uint)val };
    }
}
