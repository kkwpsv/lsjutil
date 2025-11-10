using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.MediaFoundation.Structs
{
    /// <summary>
    /// <para>
    /// Defines a normalized rectangle, which is used to specify sub-rectangles in a video rectangle.
    /// When a rectangle N is normalized relative to some other rectangle R, it means the following:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// The coordinate (0.0, 0.0) on N is mapped to the upper-left corner of R.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The coordinate (1.0, 1.0) on N is mapped to the lower-right corner of R.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Any coordinates of N that fall outside the range [0...1] are mapped to positions outside the rectangle R.
    /// A normalized rectangle can be used to specify a region within a video rectangle
    /// without knowing the resolution or even the aspect ratio of the video.
    /// For example, the upper-left quadrant is defined as {0.0, 0.0, 0.5, 0.5}.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfcaptureengine/ns-mfcaptureengine-mfvideonormalizedrect"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MFVideoNormalizedRect
    {
        /// <summary>
        /// X-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public float left;

        /// <summary>
        /// Y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public float top;

        /// <summary>
        /// X-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public float right;

        /// <summary>
        /// Y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public float bottom;
    }
}
