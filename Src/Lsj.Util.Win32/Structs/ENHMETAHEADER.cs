using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ENHMETAHEADER"/> structure contains enhanced-metafile data
    /// such as the dimensions of the picture stored in the enhanced metafile,
    /// the count of records in the enhanced metafile,
    /// the resolution of the device on which the picture was created, and so on.
    /// This structure is always the first record in an enhanced metafile.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-enhmetaheader"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ENHMETAHEADER
    {
        /// <summary>
        /// The record type.
        /// This member must specify the value assigned to the <see cref="EMR_HEADER"/> constant.
        /// </summary>
        public DWORD iType;

        /// <summary>
        /// The structure size, in bytes.
        /// </summary>
        public DWORD nSize;

        /// <summary>
        /// The dimensions, in device units, of the smallest rectangle
        /// that can be drawn around the picture stored in the metafile.
        /// This rectangle is supplied by graphics device interface (GDI).
        /// Its dimensions include the right and bottom edges.
        /// </summary>
        public RECTL rclBounds;

        /// <summary>
        /// The dimensions, in .01 millimeter units, of a rectangle that surrounds the picture stored in the metafile.
        /// This rectangle must be supplied by the application that creates the metafile.
        /// Its dimensions include the right and bottom edges.
        /// </summary>
        public RECTL rclFrame;

        /// <summary>
        /// A signature. This member must specify the value assigned to the ENHMETA_SIGNATURE constant.
        /// </summary>
        public DWORD dSignature;

        /// <summary>
        /// The metafile version. The current version value is 0x10000.
        /// </summary>
        public DWORD nVersion;

        /// <summary>
        /// The size of the enhanced metafile, in bytes.
        /// </summary>
        public DWORD nBytes;

        /// <summary>
        /// The number of records in the enhanced metafile.
        /// </summary>
        public DWORD nRecords;

        /// <summary>
        /// The number of handles in the enhanced-metafile handle table. (Index zero in this table is reserved.)
        /// </summary>
        public WORD nHandles;

        /// <summary>
        /// Reserved; must be zero.
        /// </summary>
        public WORD sReserved;

        /// <summary>
        /// The number of characters in the array that contains the description of the enhanced metafile's contents.
        /// This member should be set to zero if the enhanced metafile does not contain a description string.
        /// </summary>
        public DWORD nDescription;

        /// <summary>
        /// The offset from the beginning of the ENHMETAHEADER structure to the array
        /// that contains the description of the enhanced metafile's contents.
        /// This member should be set to zero if the enhanced metafile does not contain a description string.
        /// </summary>
        public DWORD offDescription;

        /// <summary>
        /// The number of entries in the enhanced metafile's palette.
        /// </summary>
        public DWORD nPalEntries;

        /// <summary>
        /// The resolution of the reference device, in pixels.
        /// </summary>
        public SIZEL szlDevice;

        /// <summary>
        /// The resolution of the reference device, in millimeters.
        /// </summary>
        public SIZEL szlMillimeters;

        /// <summary>
        /// The size of the last recorded pixel format in a metafile.
        /// If a pixel format is set in a reference DC at the start of recording,
        /// <see cref="cbPixelFormat"/> is set to the size of the <see cref="PIXELFORMATDESCRIPTOR"/>.
        /// When no pixel format is set when a metafile is recorded, this member is set to zero.
        /// If more than a single pixel format is set, the header points to the last pixel format.
        /// </summary>
        public DWORD cbPixelFormat;

        /// <summary>
        /// The offset of pixel format used when recording a metafile.
        /// If a pixel format is set in a reference DC at the start of recording or during recording,
        /// <see cref="offPixelFormat"/> is set to the offset of the <see cref="PIXELFORMATDESCRIPTOR"/> in the metafile.
        /// If no pixel format is set when a metafile is recorded, this member is set to zero.
        /// If more than a single pixel format is set, the header points to the last pixel format.
        /// </summary>
        public DWORD offPixelFormat;

        /// <summary>
        /// Indicates whether any OpenGL records are present in a metafile.
        /// <see cref="bOpenGL"/> is a simple Boolean flag
        /// that you can use to determine whether an enhanced metafile requires OpenGL handling.
        /// When a metafile contains OpenGL records, <see cref="bOpenGL"/> is <see cref="TRUE"/>; otherwise it is <see cref="FALSE"/>.
        /// </summary>
        public DWORD bOpenGL;

        /// <summary>
        /// The size of the reference device, in micrometers.
        /// </summary>
        public SIZEL szlMicrometers;
    }
}
