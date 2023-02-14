namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Represents the trust level of an activatable class.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/inspectable/ne-inspectable-trustlevel"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Classes can be activated depending on the trust level of the caller and the trust classification of the activatable class.
    /// RegisteredTrustLevel is an alias for this enumeration.
    /// </remarks>
    public enum TrustLevel
    {
        /// <summary>
        /// The component has access to resources that are not protected.
        /// </summary>
        BaseTrust,

        /// <summary>
        /// The component has access to resources requested in the app manifest and approved by the user.
        /// </summary>
        PartialTrust,

        /// <summary>
        /// The component requires the full privileges of the user.
        /// </summary>
        FullTrust
    }
}
