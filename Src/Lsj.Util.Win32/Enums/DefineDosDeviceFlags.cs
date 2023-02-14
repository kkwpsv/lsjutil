using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="DefineDosDevice"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-definedosdevicew"/>
    /// </para>
    /// </summary>
    public enum DefineDosDeviceFlags : uint
    {
        /// <summary>
        /// Uses the lpTargetPath string as is.
        /// Otherwise, it is converted from an MS-DOS path to a path.
        /// </summary>
        DDD_RAW_TARGET_PATH = 0x00000001,

        /// <summary>
        /// Removes the specified definition for the specified device.
        /// To determine which definition to remove, the function walks the list of mappings for the device,
        /// looking for a match of lpTargetPath against a prefix of each mapping associated with this device.
        /// The first mapping that matches is the one removed, and then the function returns.
        /// If lpTargetPath is NULL or a pointer to a NULL string, the function will remove the first mapping associated with the device and pop the most recent one pushed. If there is nothing left to pop, the device name will be removed.
        /// If this value is not specified, the string pointed to by the lpTargetPath parameter will become the new mapping for this device.
        /// </summary>
        DDD_REMOVE_DEFINITION = 0x00000002,

        /// <summary>
        /// If this value is specified along with <see cref="DDD_REMOVE_DEFINITION"/>,
        /// the function will use an exact match to determine which mapping to remove.
        /// Use this value to ensure that you do not delete something that you did not define.
        /// </summary>
        DDD_EXACT_MATCH_ON_REMOVE = 0x00000004,

        /// <summary>
        /// Do not broadcast the <see cref="WM_SETTINGCHANGE"/> message.
        /// By default, this message is broadcast to notify the shell and applications of the change.
        /// </summary>
        DDD_NO_BROADCAST_SYSTEM = 0x00000008,
    }
}
