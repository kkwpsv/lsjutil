namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Disp Invoke Flags
    /// </summary>
    public enum DispInvokeFlags : ushort
    {
        /// <summary>
        /// DISPATCH_METHOD
        /// </summary>
        DISPATCH_METHOD = 0x1,

        /// <summary>
        /// DISPATCH_PROPERTYGET
        /// </summary>
        DISPATCH_PROPERTYGET = 0x2,

        /// <summary>
        /// DISPATCH_PROPERTYPUT
        /// </summary>
        DISPATCH_PROPERTYPUT = 0x4,

        /// <summary>
        /// DISPATCH_PROPERTYPUTREF
        /// </summary>
        DISPATCH_PROPERTYPUTREF = 0x8,
    }
}
