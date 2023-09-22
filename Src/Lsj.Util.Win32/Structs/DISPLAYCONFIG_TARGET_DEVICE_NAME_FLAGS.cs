using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS"/> structure contains information about a target device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-displayconfig_target_device_name_flags"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS
    {
        /// <summary>
        /// A member in the union that <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS"/> contains
        /// that can hold a 32-bit value that identifies information about the device.
        /// </summary>
        public UINT32 value;

        /// <summary>
        /// A <see cref="UINT32"/> value that indicates that the string in the <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME.monitorFriendlyDeviceName"/> member
        /// of the <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME"/> structure was constructed
        /// from the manufacture identification string in the extended display identification data (EDID).
        /// Setting this member is equivalent to setting the first bit of the 32-bit value member (0x00000001).
        /// </summary>
#pragma warning disable IDE1006
        public UINT32 friendlyNameFromEdid
#pragma warning restore IDE1006
        {
            get => value & 0x1;
            set => this.value = (value & 0xFFFFFFE) | (value & 0x1);
        }

        /// <summary>
        /// A <see cref="UINT32"/> value that indicates that the target is forced with no detectable monitor attached
        /// and the <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME.monitorFriendlyDeviceName"/> member
        /// of the <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME"/> structure is a NULL-terminated empty string.
        /// Setting this member is equivalent to setting the second bit of the 32-bit value member (0x00000002).
        /// </summary>
#pragma warning disable IDE1006
        public UINT32 friendlyNameForced
#pragma warning restore IDE1006
        {
            get => (value >> 1) & 0x1;
            set => this.value = (value & 0xFFFFFFD) | ((value & 0x1) << 1);
        }

        /// <summary>
        /// A <see cref="UINT32"/> value that indicates that the <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME.edidManufactureId"/>
        /// and <see cref="DISPLAYCONFIG_TARGET_DEVICE_NAME.edidProductCodeId"/> members of the DISPLAYCONFIG_TARGET_DEVICE_NAME structure are valid and were obtained from the EDID.
        /// </summary>
#pragma warning disable IDE1006
        public UINT32 edidIdsValid
#pragma warning restore IDE1006
        {
            get => (value >> 2) & 0x1;
            set => this.value = (value & 0xFFFFFFB) | ((value & 0x1) << 2);
        }

        /// <summary>
        /// This member is reserved and should be set to zero.
        /// Setting this member to zero is equivalent to setting the remaining 29 bits (0xFFFFFFF8) of the 32-bit value member to zeros.
        /// </summary>
#pragma warning disable IDE1006
        public UINT32 reserved
#pragma warning restore IDE1006
        {
            get => value >> 3;
            set => this.value = (value & 0x7) | (value << 3);
        }
    }
}
