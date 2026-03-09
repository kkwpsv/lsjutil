using Lsj.Util.Win32.BaseTypes;

namespace Lsj.Util.Win32.MediaFoundation
{
    /// <summary>
    /// Constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// MF_API_VERSION
        /// </summary>
        public const int MF_API_VERSION = 0x0070;

        /// <summary>
        /// MF_CAPTURE_ENGINE_FIRST_SOURCE_AUDIO_STREAM
        /// </summary>
        public const uint MF_CAPTURE_ENGINE_FIRST_SOURCE_AUDIO_STREAM = 0xFFFFFFFD;

        /// <summary>
        /// MF_CAPTURE_ENGINE_FIRST_SOURCE_PHOTO_STREAM
        /// </summary>
        public const uint MF_CAPTURE_ENGINE_FIRST_SOURCE_PHOTO_STREAM = 0xFFFFFFFB;

        /// <summary>
        /// MF_CAPTURE_ENGINE_FIRST_SOURCE_VIDEO_STREAM
        /// </summary>
        public const uint MF_CAPTURE_ENGINE_FIRST_SOURCE_VIDEO_STREAM = 0xFFFFFFFC;

        /// <summary>
        /// MF_E_NO_MORE_TYPES
        /// </summary>
        public static readonly HRESULT MF_E_NO_MORE_TYPES = (uint)0xC00D36B9;

        /// <summary>
        /// MF_SDK_VERSION
        /// </summary>
        public const int MF_SDK_VERSION = 0x0002;

        /// <summary>
        /// MF_SOURCE_READER_ALL_STREAMS
        /// </summary>
        public const uint MF_SOURCE_READER_ALL_STREAMS = 0xFFFFFFFE;

        /// <summary>
        /// MF_SOURCE_READER_CURRENT_TYPE_INDEX
        /// </summary>
        public const uint MF_SOURCE_READER_CURRENT_TYPE_INDEX = 0xFFFFFFFF;

        /// <summary>
        /// MF_SOURCE_READER_FIRST_AUDIO_STREAM
        /// </summary>
        public const uint MF_SOURCE_READER_FIRST_AUDIO_STREAM = 0xFFFFFFFD;

        /// <summary>
        /// MF_SOURCE_READER_FIRST_VIDEO_STREAM
        /// </summary>
        public const uint MF_SOURCE_READER_FIRST_VIDEO_STREAM = 0xFFFFFFFC;

        /// <summary>
        /// MF_SOURCE_READER_MEDIASOURCE
        /// </summary>
        public const uint MF_SOURCE_READER_MEDIASOURCE = 0xFFFFFFFF;

        /// <summary>
        /// MF_VERSION
        /// </summary>
        public const uint MF_VERSION = MF_SDK_VERSION << 16 | MF_API_VERSION;
    }
}
