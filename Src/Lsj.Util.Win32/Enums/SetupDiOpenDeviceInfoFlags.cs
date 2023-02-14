using static Lsj.Util.Win32.SetupAPI;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="SetupDiOpenDeviceInfo"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdevsw"/>
    /// </para>
    /// </summary>
    public enum SetupDiOpenDeviceInfoFlags : uint
    {
        /// <summary>
        /// If this flag is specified, the resulting device information element inherits the class driver list,
        /// if any, associated with the device information set.
        /// In addition, if there is a selected driver for the device information set,
        /// that same driver is selected for the new device information element.
        /// If the device information element was already present, its class driver list, if any, is replaced with the inherited list.
        /// </summary>
        DIOD_INHERIT_CLASSDRVS = 0x00000002,

        /// <summary>
        /// If this flag is specified and the device had been marked for pending removal,
        /// the operating system cancels the pending removal.
        /// </summary>
        DIOD_CANCEL_REMOVE = 0x0000000,
    }
}
