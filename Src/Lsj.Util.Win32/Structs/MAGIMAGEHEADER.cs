using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes an image format.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/magnification/ns-magnification-magimageheader"/>
    /// </para>
    /// </summary>
    [Obsolete("The MAGIMAGEHEADER structure is deprecated in Windows 7 and later, and should not be used in new applications. " +
        "There is no alternate functionality.")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MAGIMAGEHEADER
    {
        /// <summary>
        /// The width of the image.
        /// </summary>
        public UINT width;

        /// <summary>
        /// The height of the image.
        /// </summary>
        public UINT height;

        /// <summary>
        /// A WICPixelFormatGUID (declared in wincodec.h) that specifies the pixel format of the image.
        /// For a list of available pixel formats, see the Native Pixel Formats topic.
        /// </summary>
        public GUID format;

        /// <summary>
        /// The stride, or number of bytes in a row of the image.
        /// </summary>
        public UINT stride;

        /// <summary>
        /// The offset of the start of the image data from the beginning of the file.
        /// </summary>
        public UINT offset;

        /// <summary>
        /// The size of the data.
        /// </summary>
        public SIZE_T cbSize;
    }
}
