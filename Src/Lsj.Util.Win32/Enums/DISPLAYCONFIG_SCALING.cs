using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_SCALING"/> enumeration specifies the scaling transformation
    /// applied to content displayed on a video present network (VidPN) present path.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ne-wingdi-displayconfig_scaling"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For more information about scaling, see Scaling the Desktop Image.
    /// </remarks>
    public enum DISPLAYCONFIG_SCALING
    {
        /// <summary>
        /// Indicates the identity transformation; the source content is presented with no change.
        /// This transformation is available only if the path's source mode has the same spatial resolution as the path's target mode.
        /// </summary>
        DISPLAYCONFIG_SCALING_IDENTITY = 1,

        /// <summary>
        /// Indicates the centering transformation; the source content is presented unscaled,
        /// centered with respect to the spatial resolution of the target mode.
        /// </summary>
        DISPLAYCONFIG_SCALING_CENTERED = 2,

        /// <summary>
        /// Indicates the content is scaled to fit the path's target.
        /// </summary>
        DISPLAYCONFIG_SCALING_STRETCHED = 3,

        /// <summary>
        /// Indicates the aspect-ratio centering transformation.
        /// </summary>
        DISPLAYCONFIG_SCALING_ASPECTRATIOCENTEREDMAX = 4,

        /// <summary>
        /// Indicates that the caller requests a custom scaling
        /// that the caller cannot describe with any of the other DISPLAYCONFIG_SCALING_XXX values.
        /// Only a hardware vendor's value-add application should use <see cref="DISPLAYCONFIG_SCALING_CUSTOM"/>,
        /// because the value-add application might require a private interface to the driver.
        /// The application can then use <see cref="DISPLAYCONFIG_SCALING_CUSTOM"/> to indicate additional context
        /// for the driver for the custom value on the specified path.
        /// </summary>
        DISPLAYCONFIG_SCALING_CUSTOM = 5,

        /// <summary>
        /// Indicates that the caller does not have any preference for the scaling.
        /// The <see cref="SetDisplayConfig"/> function will use the scaling value that was last saved in the database for the path.
        /// If such a scaling value does not exist, <see cref="SetDisplayConfig"/> will use the default scaling for the computer.
        /// For example, stretched (<see cref="DISPLAYCONFIG_SCALING_STRETCHED"/>) for tablet computers
        /// and aspect-ratio centered (<see cref="DISPLAYCONFIG_SCALING_ASPECTRATIOCENTEREDMAX"/>) for non-tablet computers.
        /// </summary>
        DISPLAYCONFIG_SCALING_PREFERRED = 128,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits. You should not use this value.
        /// </summary>
        DISPLAYCONFIG_SCALING_FORCE_UINT32 = unchecked((int)0xFFFFFFFF),
    }
}
