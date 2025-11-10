namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Defines error status codes for the Media Engine.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/ne-mfmediaengine-mf_media_engine_err"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The values greater than zero correspond to error codes defined for the <c>MediaError</c> object in HTML5.
    /// </remarks>
    public enum MF_MEDIA_ENGINE_ERR
    {
        /// <summary>
        /// No error.
        /// </summary>
        MF_MEDIA_ENGINE_ERR_NOERROR = 0,

        /// <summary>
        /// The process of fetching the media resource was stopped at the user's request.
        /// </summary>
        MF_MEDIA_ENGINE_ERR_ABORTED = 1,

        /// <summary>
        /// A network error occurred while fetching the media resource.
        /// </summary>
        MF_MEDIA_ENGINE_ERR_NETWORK = 2,

        /// <summary>
        /// An error occurred while decoding the media resource.
        /// </summary>
        MF_MEDIA_ENGINE_ERR_DECODE = 3,

        /// <summary>
        /// The media resource is not supported.
        /// </summary>
        MF_MEDIA_ENGINE_ERR_SRC_NOT_SUPPORTED = 4,

        /// <summary>
        /// <para>
        /// An error occurred while encrypting the media resource.
        /// </para>
        /// <para>
        /// Supported in Windows 8.1 and later.
        /// </para>
        /// </summary>
        MF_MEDIA_ENGINE_ERR_ENCRYPTED = 5
    }
}
