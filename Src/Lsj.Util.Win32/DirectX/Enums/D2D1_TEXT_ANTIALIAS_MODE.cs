namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes the antialiasing mode used for drawing text.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_text_antialias_mode"/>
    /// </para>
    /// </summary>
    public enum D2D1_TEXT_ANTIALIAS_MODE : uint
    {
        /// <summary>
        /// Use the system default. See Remarks.
        /// </summary>
        D2D1_TEXT_ANTIALIAS_MODE_DEFAULT = 0,

        /// <summary>
        /// Use ClearType antialiasing.
        /// </summary>
        D2D1_TEXT_ANTIALIAS_MODE_CLEARTYPE = 1,

        /// <summary>
        /// Use grayscale antialiasing.
        /// </summary>
        D2D1_TEXT_ANTIALIAS_MODE_GRAYSCALE = 2,

        /// <summary>
        /// Do not use antialiasing.
        /// </summary>
        D2D1_TEXT_ANTIALIAS_MODE_ALIASED = 3,

        /// <summary>
        /// 
        /// </summary>
        D2D1_TEXT_ANTIALIAS_MODE_FORCE_DWORD = 0xffffffff
    }
}
