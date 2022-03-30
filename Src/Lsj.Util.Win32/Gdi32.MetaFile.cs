using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The EnhMetaFileProc function is an application-defined callback function used with the <see cref="EnumEnhMetaFile"/> function.
        /// The <see cref="ENHMFENUMPROC"/> type defines a pointer to this callback function.
        /// EnhMetaFileProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/en-us/previous-versions/dd162606(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// Handle to the device context passed to <see cref="EnumEnhMetaFile"/>.
        /// </param>
        /// <param name="lpHTable">
        /// Pointer to a <see cref="HANDLETABLE"/> structure representing the table of handles
        /// associated with the graphics objects (pens, brushes, and so on) in the metafile.
        /// The first entry contains the enhanced-metafile handle.
        /// </param>
        /// <param name="lpEMFR">
        /// Pointer to one of the records in the metafile.
        /// This record should not be modified.
        /// (If modification is necessary, it should be performed on a copy of the record.)
        /// </param>
        /// <param name="nObj">
        /// Specifies the number of objects with associated handles in the handle table.
        /// </param>
        /// <param name="lpData">
        /// Pointer to optional data.
        /// </param>
        /// <returns>
        /// This function must return a nonzero value to continue enumeration; to stop enumeration, it must return zero.
        /// </returns>
        /// <remarks>
        /// An application must register the callback function by passing its address to the <see cref="EnumEnhMetaFile"/> function.
        /// </remarks>
        public delegate int Enhmfenumproc([In] HDC hDC, [In] in HANDLETABLE lpHTable, [In] in ENHMETARECORD lpEMFR, [In] int nObj, [In] LPARAM lpData);

        /// <summary>
        /// <para>
        /// The EnumMetaFileProc function is an application-defined callback function that processes Windows-format metafile records.
        /// This function is called by the <see cref="EnumMetaFile"/> function.
        /// The <see cref="MFENUMPROC"/> type defines a pointer to this callback function.
        /// EnumMetaFileProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/previous-versions/dd162630(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// </param>
        /// <param name="lpHTable">
        /// </param>
        /// <param name="lpMFR">
        /// </param>
        /// <param name="nObj">
        /// Specifies the number of objects with associated handles in the handle table.
        /// </param>
        /// <param name="param">
        /// </param>
        /// <returns>
        /// This function must return a nonzero value to continue enumeration; to stop enumeration, it must return zero.
        /// </returns>
        /// <remarks>
        /// An application must register the callback function by passing its address to the <see cref="EnumMetaFile"/> function.
        /// EnumMetaFileProc is a placeholder for the application-supplied function name.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is EnhMetaFileProc.")]
        public delegate int Mfenumproc([In] HDC hDC, [MarshalAs(UnmanagedType.LPArray)][In] HGDIOBJ[] lpHTable,
            [In] in METARECORD lpMFR, [In] int nObj, [In] LPARAM param);


        /// <summary>
        /// <para>
        /// The <see cref="CreateMetaFile"/> function creates a device context for a Windows-format metafile.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createmetafilew"/>
        /// </para>
        /// </summary>
        /// <param name="pszFile">
        /// A pointer to the file name for the Windows-format metafile to be created.
        /// If this parameter is <see langword="null"/>, the Windows-format metafile is memory based and its contents are lost
        /// when it is deleted by using the <see cref="DeleteMetaFile"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the device context for the Windows-format metafile.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// Where text arguments must use Unicode characters, use the <see cref="CreateMetaFile"/> function as a wide-character function.
        /// Where text arguments must use characters from the Windows character set, use this function as an ANSI function.
        /// <see cref="CreateMetaFile"/> is a Windows-format metafile function.
        /// This function supports only 16-bit Windows-based applications, which are listed in Windows-Format Metafiles.
        /// It does not record or play back GDI functions such as <see cref="PolyBezier"/>, which were not part of 16-bit Windows.
        /// The device context created by this function can be used to record GDI output functions in a Windows-format metafile.
        /// It cannot be used with GDI query functions such as <see cref="GetTextColor"/>.
        /// When the device context is used with a GDI output function, the return value of that function
        /// becomes <see cref="TRUE"/> if the function is recorded and <see cref="FALSE"/> otherwise.
        /// When an object is selected by using the <see cref="SelectObject"/> function, only a copy of the object is recorded.
        /// The object still belongs to the application.
        /// To create a scalable Windows-format metafile, record the graphics output in the <see cref="MM_ANISOTROPIC"/> mapping mode.
        /// The file cannot contain functions that modify the viewport origin and extents,
        /// nor can it contain device-dependent functions such as the <see cref="SelectClipRgn"/> function.
        /// Once created, the Windows metafile can be scaled and rendered to any output device-format
        /// by defining the viewport origin and extents of the picture before playing it.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is CreateEnhMetaFile.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateMetaFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HDC CreateMetaFile([In] string pszFile);

        /// <summary>
        /// <para>
        /// The <see cref="CloseEnhMetaFile"/> function closes an enhanced-metafile device context
        /// and returns a handle that identifies an enhanced-format metafile.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-closeenhmetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to an enhanced-metafile device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to an enhanced metafile.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// An application can use the enhanced-metafile handle returned
        /// by the <see cref="CloseEnhMetaFile"/> function to perform the following tasks:
        /// Display a picture stored in an enhanced metafile
        /// Create copies of the enhanced metafile
        /// Enumerate, edit, or copy individual records in the enhanced metafile
        /// Retrieve an optional description of the metafile contents from the enhanced-metafile header
        /// Retrieve a copy of the enhanced-metafile header
        /// Retrieve a binary copy of the enhanced metafile
        /// Enumerate the colors in the optional palette
        /// Convert an enhanced-format metafile into a Windows-format metafile
        /// When the application no longer needs the enhanced metafile handle,
        /// it should release the handle by calling the <see cref="DeleteEnhMetaFile"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseEnhMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern HENHMETAFILE CloseEnhMetaFile([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="CloseMetaFile"/> function closes a metafile device context and returns a handle that identifies a Windows-format metafile.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-closemetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a metafile device context used to create a Windows-format metafile.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a Windows-format metafile.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// To convert a Windows-format metafile into a new enhanced-format metafile, use the <see cref="SetWinMetaFileBits"/> function.
        /// When an application no longer needs the Windows-format metafile handle,
        /// it should delete the handle by calling the <see cref="DeleteMetaFile"/> function.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is CloseEnhMetaFile.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern HMETAFILE CloseMetaFile([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="CopyEnhMetaFile"/> function copies the contents of an enhanced-format metafile to a specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-copyenhmetafilew"/>
        /// </para>
        /// </summary>
        /// <param name="hEnh">
        /// A handle to the enhanced metafile to be copied.
        /// </param>
        /// <param name="lpFileName">
        /// A pointer to the name of the destination file.
        /// If this parameter is <see cref="NULL"/>, the source metafile is copied to memory.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the copy of the enhanced metafile.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// Where text arguments must use Unicode characters, use the <see cref="CopyEnhMetaFile"/> function as a wide-character function.
        /// Where text arguments must use characters from the Windows character set, use this function as an ANSI function.
        /// Applications can use metafiles stored in memory for temporary operations.
        /// When the application no longer needs the enhanced-metafile handle,
        /// it should delete the handle by calling the <see cref="DeleteEnhMetaFile"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyEnhMetaFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HENHMETAFILE CopyEnhMetaFile([In] HENHMETAFILE hEnh, [In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// The <see cref="CopyMetaFile"/> function copies the content of a Windows-format metafile to the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-copymetafilew"/>
        /// </para>
        /// </summary>
        /// <param name="arg1">
        /// A handle to the source Windows-format metafile.
        /// </param>
        /// <param name="arg2">
        /// A pointer to the name of the destination file.
        /// If this parameter is <see langword="null"/>, the source metafile is copied to memory.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the copy of the Windows-format metafile.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// Where text arguments must use Unicode characters, use this function as a wide-character function.
        /// Where text arguments must use characters from the Windows character set, use this function as an ANSI function.
        /// When the application no longer needs the Windows-format metafile handle,
        /// it should delete the handle by calling the <see cref="DeleteMetaFile"/> function.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is CopyEnhMetaFile.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyMetaFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HMETAFILE CopyMetaFile([In] HMETAFILE arg1, [In] LPWSTR arg2);

        /// <summary>
        /// <para>
        /// The <see cref="CreateEnhMetaFile"/> function creates a device context for an enhanced-format metafile.
        /// This device context can be used to store a device-independent picture.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createenhmetafilew"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a reference device for the enhanced metafile.
        /// This parameter can be <see cref="NULL"/>; for more information, see Remarks.
        /// </param>
        /// <param name="lpFilename">
        /// A pointer to the file name for the enhanced metafile to be created.
        /// If this parameter is <see cref="NULL"/>, the enhanced metafile is memory based and its contents are lost
        /// when it is deleted by using the <see cref="DeleteEnhMetaFile"/> function.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that specifies the dimensions (in .01-millimeter units)
        /// of the picture to be stored in the enhanced metafile.
        /// </param>
        /// <param name="lpDesc">
        /// A pointer to a string that specifies the name of the application
        /// that created the picture, as well as the picture's title.
        /// This parameter can be <see cref="NULL"/>; for more information, see Remarks.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the device context for the enhanced metafile.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// Where text arguments must use Unicode characters, use the <see cref="CreateEnhMetaFile"/> function as a wide-character function.
        /// Where text arguments must use characters from the Windows character set, use this function as an ANSI function.
        /// The system uses the reference device identified by the <paramref name="hdc"/> parameter to record the resolution
        /// and units of the device on which a picture originally appeared.
        /// If the <paramref name="hdc"/> parameter is <see cref="NULL"/>, it uses the current display device for reference.
        /// The <see cref="RECT.left"/> and <see cref="RECT.top"/> members of the <see cref="RECT"/> structure
        /// pointed to by the <paramref name="lprc"/> parameter must be less than the <see cref="RECT.right"/>
        /// and <see cref="RECT.bottom"/> members, respectively.
        /// Points along the edges of the rectangle are included in the picture.
        /// If <paramref name="lprc"/> is <see cref="NullRef{RECT}"/>, the graphics device interface (GDI)
        /// computes the dimensions of the smallest rectangle that surrounds the picture drawn by the application.
        /// The <paramref name="lprc"/> parameter should be provided where possible.
        /// The string pointed to by the <paramref name="lpDesc"/> parameter must contain a null character
        /// between the application name and the picture name and must terminate with two null characters,
        /// for example, "XYZ Graphics Editor\0Bald Eagle\0\0", where \0 represents the null character.
        /// If <paramref name="lpDesc"/> is <see cref="NULL"/>, there is no corresponding entry in the enhanced-metafile header.
        /// Applications use the device context created by this function to store a graphics picture in an enhanced metafile.
        /// The handle identifying this device context can be passed to any GDI function.
        /// After an application stores a picture in an enhanced metafile,
        /// it can display the picture on any output device by calling the <see cref="PlayEnhMetaFile"/> function.
        /// When displaying the picture, the system uses the rectangle pointed to by the <paramref name="lprc"/> parameter
        /// and the resolution data from the reference device to position and scale the picture.
        /// The device context returned by this function contains the same default attributes associated with any new device context.
        /// Applications must use the <see cref="GetWinMetaFileBits"/> function to convert an enhanced metafile to the older Windows metafile format.
        /// The file name for the enhanced metafile should use the .emf extension.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEnhMetaFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HDC CreateEnhMetaFile([In] HDC hdc, [In] LPCWSTR lpFilename, [In] in RECT lprc, [In] LPCWSTR lpDesc);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteEnhMetaFile"/> function deletes an enhanced-format metafile or an enhanced-format metafile handle.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-deleteenhmetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hmf">
        /// A handle to an enhanced metafile.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// If the hemf parameter identifies an enhanced metafile stored in memory, the <see cref="DeleteEnhMetaFile"/> function deletes the metafile.
        /// If hemf identifies a metafile stored on a disk, the function deletes the metafile handle but does not destroy the actual metafile.
        /// An application can retrieve the file by calling the <see cref="GetEnhMetaFile"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteEnhMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteEnhMetaFile([In] HENHMETAFILE hmf);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteMetaFile"/> function deletes a Windows-format metafile or Windows-format metafile handle.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-deletemetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hmf">
        /// A handle to a Windows-format metafile.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// If the metafile identified by the <paramref name="hmf"/> parameter is stored in memory (rather than on a disk),
        /// its content is lost when it is deleted by using the <see cref="DeleteMetaFile"/> function.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            " The corresponding function for an enhanced-format metafile is DeleteEnhMetaFile.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteMetaFile([In] HMETAFILE hmf);

        /// <summary>
        /// <para>
        /// The <see cref="EnumEnhMetaFile"/> function enumerates the records within an enhanced-format metafile
        /// by retrieving each record and passing it to the specified callback function.
        /// The application-supplied callback function processes each record as required.
        /// The enumeration continues until the last record is processed or when the callback function returns zero.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-enumenhmetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// This handle is passed to the callback function.
        /// </param>
        /// <param name="hmf">
        /// A handle to an enhanced metafile.
        /// </param>
        /// <param name="proc">
        /// A pointer to the application-supplied callback function.
        /// For more information, see the EnhMetaFileProc function.
        /// </param>
        /// <param name="param">
        /// A pointer to optional callback-function data.
        /// </param>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that specifies the coordinates,
        /// in logical units, of the picture's upper-left and lower-right corners.
        /// </param>
        /// <returns>
        /// If the callback function successfully enumerates all the records in the enhanced metafile, the return value is <see cref="TRUE"/>.
        /// If the callback function does not successfully enumerate all the records in the enhanced metafile,
        /// the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Points along the edge of the rectangle pointed to by the <paramref name="lpRect"/> parameter are included in the picture.
        /// If the <paramref name="hdc"/> parameter is <see cref="NULL"/>, the system ignores <paramref name="lpRect"/>.
        /// If the callback function calls the <see cref="PlayEnhMetaFileRecord"/> function, hdc must identify a valid device context.
        /// The system uses the device context's transformation and mapping mode
        /// to transform the picture displayed by the <see cref="PlayEnhMetaFileRecord"/> function.
        /// You can use the <see cref="EnumEnhMetaFile"/> function to embed one enhanced-metafile within another.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumEnhMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumEnhMetaFile([In] HDC hdc, [In] HENHMETAFILE hmf, [In] ENHMFENUMPROC proc,
            [In] LPVOID param, [In] in RECT lpRect);

        /// <summary>
        /// <para>
        /// The <see cref="EnumMetaFile"/> function enumerates the records within a Windows-format metafile by retrieving each record
        /// and passing it to the specified callback function.
        /// The application-supplied callback function processes each record as required.
        /// The enumeration continues until the last record is processed or when the callback function returns zero.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-enummetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a device context.
        /// This handle is passed to the callback function.
        /// </param>
        /// <param name="hmf">
        /// Handle to a Windows-format metafile.
        /// </param>
        /// <param name="proc">
        /// Pointer to an application-supplied callback function.
        /// For more information, see <see cref="MFENUMPROC"/>.
        /// </param>
        /// <param name="param">
        /// Pointer to optional data.
        /// </param>
        /// <returns>
        /// If the callback function successfully enumerates all the records in the Windows-format metafile, the return value is <see cref="TRUE"/>.
        /// If the callback function does not successfully enumerate all the records in the Windows-format metafile, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// To convert a Windows-format metafile into an enhanced-format metafile, use the <see cref="SetWinMetaFileBits"/> function.
        /// You can use the <see cref="EnumMetaFile"/> function to embed one Windows-format metafile within another.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is EnumEnhMetaFile.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumMetaFile([In] HDC hdc, [In] HMETAFILE hmf, [In] MFENUMPROC proc, [In] LPARAM param);

        /// <summary>
        /// <para>
        /// The <see cref="GetMetaFile"/> function creates a handle that identifies the metafile stored in the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getmetafilew"/>
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// A pointer to a null-terminated string that specifies the name of a metafile.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the metafile.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// This function is not implemented in the Win32 API.
        /// It is provided for compatibility with 16-bit versions of Windows.
        /// In Win32 applications, use the <see cref="GetEnhMetaFile"/> function.
        /// </remarks>
        [Obsolete("GetMetaFile is no longer available for use as of Windows 2000. Instead, use GetEnhMetaFile.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMetaFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HMETAFILE GetMetaFile([MarshalAs(UnmanagedType.LPWStr)][In] string lpName);

        /// <summary>
        /// <para>
        /// The <see cref="GetEnhMetaFile"/> function creates a handle that identifies the enhanced-format metafile stored in the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getenhmetafilew"/>
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// A pointer to a null-terminated string that specifies the name of an enhanced metafile.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the enhanced metafile.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When the application no longer needs an enhanced-metafile handle,
        /// it should delete the handle by calling the <see cref="DeleteEnhMetaFile"/> function.
        /// A Windows-format metafile must be converted to the enhanced format before it can be processed by the <see cref="GetEnhMetaFile"/> function.
        /// To convert the file, use the <see cref="SetWinMetaFileBits"/> function.
        /// Where text arguments must use Unicode characters, use this function as a wide-character function.
        /// Where text arguments must use characters from the Windows character set, use this function as an ANSI function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnhMetaFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HENHMETAFILE GetEnhMetaFile([MarshalAs(UnmanagedType.LPWStr)][In] string lpName);

        /// <summary>
        /// <para>
        /// The <see cref="PlayMetaFile"/> function displays the picture stored in the given Windows-format metafile on the specified device.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-playmetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a device context.
        /// </param>
        /// <param name="hmf">
        /// Handle to a Windows-format metafile.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// To convert a Windows-format metafile into an enhanced format metafile, use the <see cref="SetWinMetaFileBits"/> function.
        /// A Windows-format metafile can be played multiple times.
        /// A Windows-format metafile can be embedded in a second Windows-format metafile by calling the <see cref="PlayMetaFile"/> function
        /// and playing the source metafile into the device context for the target metafile.
        /// Any object created but not deleted in the Windows-format metafile is deleted by this function.
        /// To stop this function, an application can call the <see cref="CancelDC"/> function from another thread to terminate the operation.
        /// In this case, the function returns <see cref="FALSE"/>.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is PlayEnhMetaFile.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PlayMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PlayMetaFile([In] HDC hdc, [In] HMETAFILE hmf);

        /// <summary>
        /// <para>
        /// The <see cref="PlayMetaFileRecord"/> function plays a Windows-format metafile record
        /// by executing the graphics device interface (GDI) function contained within that record.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-playmetafilerecord"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="lpHandleTable">
        /// A pointer to a HANDLETABLE structure representing the table of handles to GDI objects used when playing the metafile.
        /// HANDLETABLE is a array of <see cref="HGDIOBJ"/>.
        /// </param>
        /// <param name="lpMR">
        /// A pointer to the Windows-format metafile record.
        /// </param>
        /// <param name="noObjs">
        /// The number of handles in the handle table.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// To convert a Windows-format metafile into an enhanced-format metafile, use the <see cref="SetWinMetaFileBits"/> function.
        /// An application typically uses <see cref="PlayMetaFileRecord"/> in conjunction with the <see cref="EnumMetaFile"/> function
        /// to process and play a Windows-format metafile one record at a time.
        /// The <paramref name="lpHandleTable"/> and <paramref name="noObjs"/> parameters must be identical to those
        /// passed to the <see cref="MFENUMPROC"/> callback procedure by <see cref="EnumMetaFile"/>.
        /// If the <see cref="PlayMetaFileRecord"/> function does not recognize a record, it ignores the record and returns <see cref="TRUE"/>.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is PlayEnhMetaFileRecord.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PlayMetaFileRecord", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PlayMetaFileRecord([In] HDC hdc, [MarshalAs(UnmanagedType.LPArray)][In] HGDIOBJ[] lpHandleTable,
            [In] in METARECORD lpMR, [In] UINT noObjs);

        /// <summary>
        /// <para>
        /// The <see cref="SetWinMetaFileBits"/> function converts a metafile from the older Windows format
        /// to the new enhanced format and stores the new metafile in memory.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setwinmetafilebits"/>
        /// </para>
        /// </summary>
        /// <param name="nSize">
        /// The size, in bytes, of the buffer that contains the Windows-format metafile.
        /// </param>
        /// <param name="lpMeta16Data">
        /// A pointer to a buffer that contains the Windows-format metafile data.
        /// (It is assumed that the data was obtained by using the <see cref="GetMetaFileBitsEx"/> or <see cref="GetWinMetaFileBits"/> function.)
        /// </param>
        /// <param name="hdcRef">
        /// A handle to a reference device context.
        /// </param>
        /// <param name="lpMFP">
        /// A pointer to a <see cref="METAFILEPICT"/> structure that contains the suggested size of the metafile picture and the mapping mode
        /// that was used when the picture was created.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a memory-based enhanced metafile.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// Windows uses the reference device context's resolution data and the data in the <see cref="METAFILEPICT"/> structure to scale a picture.
        /// If the <paramref name="hdcRef"/> parameter is <see cref="NULL"/>, the system uses resolution data for the current output device.
        /// If the <paramref name="lpMFP"/> parameter is <see cref="NULL"/>, the system uses the <see cref="MM_ANISOTROPIC"/> mapping mode
        /// to scale the picture so that it fits the entire device surface.
        /// The <see cref="METAFILEPICT.hMF"/> member of the <see cref="METAFILEPICT"/> structure is not used.
        /// When the application no longer needs the enhanced metafile handle, it should delete it by calling the <see cref="DeleteEnhMetaFile"/> function.
        /// The handle returned by this function can be used with other enhanced-metafile functions.
        /// If the reference device context is not identical to the device in which the metafile was originally created,
        /// some GDI functions that use device units may not draw the picture correctly.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWinMetaFileBits", ExactSpelling = true, SetLastError = true)]
        public static extern HENHMETAFILE SetWinMetaFileBits([In] UINT nSize, [In] IntPtr lpMeta16Data, [In] HDC hdcRef, [In] in METAFILEPICT lpMFP);
    }
}
