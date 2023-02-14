using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DIBSECTION"/> structure contains information about a DIB created by calling the <see cref="CreateDIBSection"/> function.
    /// A <see cref="DIBSECTION"/> structure includes information about the bitmap's dimensions, color format, color masks,
    /// optional file mapping object, and optional bit values storage offset.
    /// An application can obtain a filled-in <see cref="DIBSECTION"/> structure for a given DIB by calling the <see cref="GetObject"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-dibsection"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DIBSECTION
    {
        /// <summary>
        /// A <see cref="BITMAP"/> data structure that contains information about the DIB: its type, its dimensions,
        /// its color capacities, and a pointer to its bit values.
        /// </summary>
        public BITMAP dsBm;

        /// <summary>
        /// A <see cref="BITMAPINFOHEADER"/> structure that contains information about the color format of the DIB.
        /// </summary>
        public BITMAPINFOHEADER dsBmih;

        /// <summary>
        /// Specifies three color masks for the DIB.
        /// This field is only valid when the <see cref="BITMAPINFOHEADER.biBitCount"/> member of the <see cref="BITMAPINFOHEADER"/> structure
        /// has a value greater than 8.
        /// Each color mask indicates the bits that are used to encode one of the three color channels (red, green, and blue).
        /// </summary>
        public ByValDWORDArrayStructForSize3 dsBitfields;

        /// <summary>
        /// Contains a handle to the file mapping object that the <see cref="CreateDIBSection"/> function used to create the DIB.
        /// If <see cref="CreateDIBSection"/> was called with a <see cref="NULL"/> value for its hSection parameter,
        /// causing the system to allocate memory for the bitmap, the <see cref="dshSection"/> member will be <see cref="NULL"/>.
        /// </summary>
        public HANDLE dshSection;

        /// <summary>
        /// The offset to the bitmap's bit values within the file mapping object referenced by <see cref="dshSection"/>.
        /// If <see cref="dshSection"/> is <see cref="NULL"/>, the <see cref="dsOffset"/> value has no meaning.
        /// </summary>
        public DWORD dsOffset;
    }
}
