namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the type of information provided by the Direct2D Debug Layer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_debug_level"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To receive debugging messages, you must install the Direct2D Debug Layer.
    /// </remarks>
    public enum D2D1_DEBUG_LEVEL : uint
    {
        /// <summary>
        /// Direct2D does not produce any debugging output.
        /// </summary>
        D2D1_DEBUG_LEVEL_NONE = 0,

        /// <summary>
        /// Direct2D sends error messages to the debug layer.
        /// </summary>
        D2D1_DEBUG_LEVEL_ERROR = 1,

        /// <summary>
        /// Direct2D sends error messages and warnings to the debug layer.
        /// </summary>
        D2D1_DEBUG_LEVEL_WARNING = 2,

        /// <summary>
        /// Direct2D sends error messages, warnings, and additional diagnostic information
        /// that can help improve performance to the debug layer.
        /// </summary>
        D2D1_DEBUG_LEVEL_INFORMATION = 3,

        /// <summary>
        /// 
        /// </summary>
        D2D1_DEBUG_LEVEL_FORCE_DWORD = 0xffffffff,
    }
}
