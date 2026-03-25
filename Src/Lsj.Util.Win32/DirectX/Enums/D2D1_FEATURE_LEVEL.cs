namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes the minimum DirectX support required for hardware rendering by a render target.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_feature_level"/>
    /// </para>
    /// </summary>
    public enum D2D1_FEATURE_LEVEL : uint
    {
        /// <summary>
        /// Direct2D determines whether the video card provides adequate hardware rendering support.
        /// </summary>
        D2D1_FEATURE_LEVEL_DEFAULT = 0,

        /// <summary>
        /// The video card must support DirectX 9.
        /// </summary>
        D2D1_FEATURE_LEVEL_9,

        /// <summary>
        /// The video card must support DirectX 10.
        /// </summary>
        D2D1_FEATURE_LEVEL_10,

        /// <summary>
        /// 
        /// </summary>
        D2D1_FEATURE_LEVEL_FORCE_DWORD = 0xffffffff
    }
}
