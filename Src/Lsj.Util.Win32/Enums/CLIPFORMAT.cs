using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The clipboard formats defined by the system are called standard clipboard formats.
    /// These clipboard formats are described in the following table.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/dataxchg/standard-clipboard-formats
    /// </para>
    /// </summary>
    public enum CLIPFORMAT
    {
        /// <summary>
        /// Text format.
        /// Each line ends with a carriage return/linefeed (CR-LF) combination.
        /// A null character signals the end of the data.
        /// Use this format for ANSI text.
        /// </summary>
        CF_TEXT = 1,

        /// <summary>
        /// A handle to a bitmap (HBITMAP).
        /// </summary>
        CF_BITMAP = 2,

        /// <summary>
        /// Handle to a metafile picture format as defined by the <see cref="METAFILEPICT"/> structure.
        /// When passing a <see cref="CF_METAFILEPICT"/> handle by means of DDE,
        /// the application responsible for deleting hMem should also free the metafile referred to by the <see cref="CF_METAFILEPICT"/> handle.
        /// </summary>
        CF_METAFILEPICT = 3,

        /// <summary>
        /// Microsoft Symbolic Link (SYLK) format.
        /// </summary>
        CF_SYLK = 4,

        /// <summary>
        /// Software Arts' Data Interchange Format.
        /// </summary>
        CF_DIF = 5,

        /// <summary>
        /// Tagged-image file format.
        /// </summary>
        CF_TIFF = 6,

        /// <summary>
        /// Text format containing characters in the OEM character set.
        /// Each line ends with a carriage return/linefeed (CR-LF) combination.
        /// A null character signals the end of the data.
        /// </summary>
        CF_OEMTEXT = 7,

        /// <summary>
        /// A memory object containing a <see cref="BITMAPINFO"/> structure followed by the bitmap bits.
        /// </summary>
        CF_DIB = 8,

        /// <summary>
        /// Handle to a color palette.
        /// Whenever an application places data in the clipboard that depends on or assumes a color palette,
        /// it should place the palette on the clipboard as well.
        /// If the clipboard contains data in the <see cref="CF_PALETTE"/> (logical color palette) format,
        /// the application should use the <see cref="SelectPalette"/> and <see cref="RealizePalette"/> functions
        /// to realize (compare) any other data in the clipboard against that logical palette.
        /// When displaying clipboard data, the clipboard always uses as its current palette any object
        /// on the clipboard that is in the <see cref="CF_PALETTE"/> format.
        /// </summary>
        CF_PALETTE = 9,

        /// <summary>
        /// Data for the pen extensions to the Microsoft Windows for Pen Computing.
        /// </summary>
        CF_PENDATA = 10,

        /// <summary>
        /// Represents audio data more complex than can be represented in a <see cref="CF_WAVE"/> standard wave format.
        /// </summary>
        CF_RIFF = 11,

        /// <summary>
        /// Represents audio data in one of the standard wave formats, such as 11 kHz or 22 kHz PCM.
        /// </summary>
        CF_WAVE = 12,

        /// <summary>
        /// Unicode text format.
        /// Each line ends with a carriage return/linefeed (CR-LF) combination.
        /// A null character signals the end of the data.
        /// </summary>
        CF_UNICODETEXT = 13,

        /// <summary>
        /// A handle to an enhanced metafile (<see cref="HENHMETAFILE"/>).
        /// </summary>
        CF_ENHMETAFILE = 14,

        /// <summary>
        /// A handle to type <see cref="HDROP"/> that identifies a list of files.
        /// An application can retrieve information about the files by passing the handle to the <see cref="DragQueryFile"/> function.
        /// </summary>
        CF_HDROP = 15,

        /// <summary>
        /// The data is a handle to the locale identifier associated with text in the clipboard.
        /// When you close the clipboard, if it contains <see cref="CF_TEXT"/> data but no <see cref="CF_LOCALE"/> data,
        /// the system automatically sets the <see cref="CF_LOCALE"/> format to the current input language.
        /// You can use the <see cref="CF_LOCALE"/> format to associate a different locale with the clipboard text.
        /// An application that pastes text from the clipboard can retrieve this format to determine which character set was used to generate the text.
        /// Note that the clipboard does not support plain text in multiple character sets.
        /// To achieve this, use a formatted text data type such as RTF instead.
        /// The system uses the code page associated with <see cref="CF_LOCALE"/> to implicitly
        /// convert from <see cref="CF_TEXT"/> to <see cref="CF_UNICODETEXT"/>.
        /// Therefore, the correct code page table is used for the conversion.
        /// </summary>
        CF_LOCALE = 16,

        /// <summary>
        /// A memory object containing a <see cref="BITMAPV5HEADER"/> structure followed by the bitmap color space information and the bitmap bits.
        /// </summary>
        CF_DIBV5 = 17,
        CF_MAX = 18,

        /// <summary>
        /// Bitmap display format associated with a private format.
        /// The hMem parameter must be a handle to data that can be displayed in bitmap format in lieu of the privately formatted data.
        /// </summary>
        CF_DSPBITMAP = 0x0082,

        /// <summary>
        /// Enhanced metafile display format associated with a private format.
        /// The hMem parameter must be a handle to data that can be displayed in enhanced metafile format in lieu of the privately formatted data.
        /// </summary>
        CF_DSPENHMETAFILE = 0x008E,

        /// <summary>
        /// Metafile-picture display format associated with a private format.
        /// The hMem parameter must be a handle to data that can be displayed in metafile-picture format in lieu of the privately formatted data.
        /// </summary>
        CF_DSPMETAFILEPICT = 0x0083,

        /// <summary>
        /// Text display format associated with a private format.
        /// The hMem parameter must be a handle to data that can be displayed in text format in lieu of the privately formatted data.
        /// </summary>
        CF_DSPTEXT = 0x0081,

        /// <summary>
        /// Start of a range of integer values for application-defined GDI object clipboard formats.
        /// The end of the range is <see cref="CF_GDIOBJLAST"/>.
        /// Handles associated with clipboard formats in this range are not automatically deleted
        /// using the <see cref="GlobalFree"/> function when the clipboard is emptied.
        /// Also, when using values in this range, the hMem parameter is not a handle to a GDI object,
        /// but is a handle allocated by the <see cref="GlobalAlloc"/> function with the <see cref="GMEM_MOVEABLE"/> flag.
        /// </summary>
        CF_GDIOBJFIRST = 0x0300,

        /// <summary>
        /// See CF_GDIOBJFIRST.
        /// </summary>
        CF_GDIOBJLAST = 0x03FF,

        /// <summary>
        /// Owner-display format.
        /// The clipboard owner must display and update the clipboard viewer window, and receive the <see cref="WM_ASKCBFORMATNAME"/>,
        /// <see cref="WM_HSCROLLCLIPBOARD"/>, <see cref="WM_PAINTCLIPBOARD"/>,
        /// <see cref="WM_SIZECLIPBOARD"/>, and <see cref="WM_VSCROLLCLIPBOARD"/> messages.
        /// The hMem parameter must be NULL.
        /// </summary>
        CF_OWNERDISPLAY = 0x0080,

        /// <summary>
        /// Start of a range of integer values for private clipboard formats.
        /// The range ends with <see cref="CF_PRIVATELAST"/>.
        /// Handles associated with private clipboard formats are not freed automatically;
        /// the clipboard owner must free such handles, typically in response to the <see cref="WM_DESTROYCLIPBOARD"/> message.
        /// </summary>
        CF_PRIVATEFIRST = 0x0200,

        /// <summary>
        /// See <see cref="CF_PRIVATEFIRST"/>.
        /// </summary>
        CF_PRIVATELAST = 0x02FF,
    }
}
