namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="LogicalColorSpace"/> Enumeration specifies the type of color space.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-wmf/eb4bbd50-b3ce-4917-895c-be31f214797f"/>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-wmf/3c289fe1-c42e-42f6-b125-4b5fc49a2b20"/>
    /// </para>
    /// </summary>
    public enum LogicalColorSpace : uint
    {
        /// <summary>
        /// Color values are calibrated red green blue (RGB) values.
        /// </summary>
        LCS_CALIBRATED_RGB = 0x00000000,

        /// <summary>
        /// The value is an encoding of the ASCII characters "sRGB", and it indicates that the color values are sRGB values.
        /// </summary>
        LCS_sRGB = 0x73524742,

        /// <summary>
        /// The value is an encoding of the ASCII characters "Win", including the trailing space,
        /// and it indicates that the color values are Windows default color space values.
        /// </summary>
        LCS_WINDOWS_COLOR_SPACE = 0x57696E20,

        /// <summary>
        /// The value consists of the string "LINK" from the Windows character set (code page 1252).
        /// It indicates that the color profile MUST be linked with the DIB Object.
        /// </summary>
        PROFILE_LINKED = 0x4C494E4B,

        /// <summary>
        /// The value consists of the string "MBED" from the Windows character set (code page 1252).
        /// It indicates that the color profile MUST be embedded in the DIB Object.
        /// </summary>
        PROFILE_EMBEDDED = 0x4D424544,
    }
}
