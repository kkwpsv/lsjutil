using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.GdiComments;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.Enums.RegionFlags;
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
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/dd162606(v=vs.85)"/>
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
        public delegate int EnhMetaFileProc([In] HDC hDC, [In] in HANDLETABLE lpHTable, [In] in ENHMETARECORD lpEMFR, [In] int nObj, [In] LPARAM lpData);

        /// <summary>
        /// <para>
        /// The <see cref="EnumMetaFileProc"/> function is an application-defined callback function that processes Windows-format metafile records.
        /// This function is called by the <see cref="EnumMetaFile"/> function.
        /// The <see cref="MFENUMPROC"/> type defines a pointer to this callback function.
        /// <see cref="EnumMetaFileProc"/> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/dd162630(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// Handle to the device context passed to <see cref="EnumMetaFile"/>.
        /// </param>
        /// <param name="lpHTable">
        /// Pointer to a table of handles associated with the graphics objects (pens, brushes, and so on) in the metafile.
        /// </param>
        /// <param name="lpMFR">
        /// Pointer to one of the records in the metafile. This record should not be modified.
        /// (If modification is necessary, it should be performed on a copy of the record.)
        /// </param>
        /// <param name="nObj">
        /// Specifies the number of objects with associated handles in the handle table.
        /// </param>
        /// <param name="param">
        /// Pointer to optional data.
        /// </param>
        /// <returns>
        /// This function must return a nonzero value to continue enumeration; to stop enumeration, it must return zero.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application must register the callback function by passing its address to the <see cref="EnumMetaFile"/> function.
        /// </para>
        /// <para>
        /// <see cref="EnumMetaFileProc"/> is a placeholder for the application-supplied function name.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is EnhMetaFileProc.")]
        public delegate int EnumMetaFileProc([In] HDC hDC, [In] HGDIOBJ[] lpHTable, [In] in METARECORD lpMFR, [In] int nObj, [In] LPARAM param);


        /// <summary>
        /// <para>
        /// The <see cref="CloseEnhMetaFile"/> function closes an enhanced-metafile device context
        /// and returns a handle that identifies an enhanced-format metafile.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-closeenhmetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to an enhanced-metafile device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to an enhanced metafile.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application can use the enhanced-metafile handle
        /// returned by the <see cref="CloseEnhMetaFile"/> function to perform the following tasks:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Display a picture stored in an enhanced metafile
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Create copies of the enhanced metafile
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Enumerate, edit, or copy individual records in the enhanced metafile
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Retrieve an optional description of the metafile contents from the enhanced-metafile header
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Retrieve a copy of the enhanced-metafile header
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Retrieve a binary copy of the enhanced metafile
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Enumerate the colors in the optional palette
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Convert an enhanced-format metafile into a Windows-format metafile
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When the application no longer needs the enhanced metafile handle,
        /// it should release the handle by calling the <see cref="DeleteEnhMetaFile"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseEnhMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern HENHMETAFILE CloseEnhMetaFile([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="CloseMetaFile"/> function closes a metafile device context
        /// and returns a handle that identifies a Windows-format metafile.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-closemetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a metafile device context used to create a Windows-format metafile.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to a Windows-format metafile.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To convert a Windows-format metafile into a new enhanced-format metafile, use the <see cref="SetWinMetaFileBits"/> function.
        /// </para>
        /// <para>
        /// When an application no longer needs the Windows-format metafile handle,
        /// it should delete the handle by calling the <see cref="DeleteMetaFile"/> function.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is CloseEnhMetaFile.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern HMETAFILE CloseMetaFile([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="CopyEnhMetaFile"/> function copies the contents of an enhanced-format metafile to a specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-copyenhmetafilew"/>
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
        /// <para>
        /// If the function succeeds, the return value is a handle to the copy of the enhanced metafile.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Where text arguments must use Unicode characters, use the <see cref="CopyEnhMetaFile"/> function as a wide-character function.
        /// Where text arguments must use characters from the Windows character set, use this function as an ANSI function.
        /// </para>
        /// <para>
        /// Applications can use metafiles stored in memory for temporary operations.
        /// </para>
        /// <para>
        /// When the application no longer needs the enhanced-metafile handle,
        /// it should delete the handle by calling the <see cref="DeleteEnhMetaFile"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyEnhMetaFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HENHMETAFILE CopyEnhMetaFile([In] HENHMETAFILE hEnh, [In] LPCWSTR lpFileName);

        /// <summary>
        /// <para>
        /// The <see cref="CopyMetaFile"/> function copies the content of a Windows-format metafile to the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-copymetafilew"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the source Windows-format metafile.
        /// </param>
        /// <param name="unnamedParam2">
        /// A pointer to the name of the destination file.
        /// If this parameter is <see cref="NULL"/>, the source metafile is copied to memory.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the copy of the Windows-format metafile.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Where text arguments must use Unicode characters, use this function as a wide-character function.
        /// Where text arguments must use characters from the Windows character set, use this function as an ANSI function.
        /// </para>
        /// <para>
        /// When the application no longer needs the Windows-format metafile handle,
        /// it should delete the handle by calling the <see cref="DeleteMetaFile"/> function.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is CopyEnhMetaFile.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyMetaFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HMETAFILE CopyMetaFile([In] HMETAFILE unnamedParam1, [In] LPCWSTR unnamedParam2);

        /// <summary>
        /// <para>
        /// The <see cref="CreateEnhMetaFile"/> function creates a device context for an enhanced-format metafile.
        /// This device context can be used to store a device-independent picture.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createenhmetafilew"/>
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
        /// <para>
        /// If the function succeeds, the return value is a handle to the device context for the enhanced metafile.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Where text arguments must use Unicode characters, use the <see cref="CreateEnhMetaFile"/> function as a wide-character function.
        /// Where text arguments must use characters from the Windows character set, use this function as an ANSI function.
        /// </para>
        /// <para>
        /// The system uses the reference device identified by the <paramref name="hdc"/> parameter
        /// to record the resolution and units of the device on which a picture originally appeared.
        /// If the <paramref name="hdc"/> parameter is <see cref="NULL"/>, it uses the current display device for reference.
        /// </para>
        /// <para>
        /// The <see cref="RECT.left"/> and <see cref="RECT.top"/> members of the <see cref="RECT"/> structure
        /// pointed to by the <paramref name="lprc"/> parameter must be less than
        /// the <see cref="RECT.right"/> and <see cref="RECT.bottom"/> members, respectively.
        /// Points along the edges of the rectangle are included in the picture.
        /// If <paramref name="lprc"/> is <see cref="NULL"/>, the graphics device interface (GDI) computes the dimensions
        /// of the smallest rectangle that surrounds the picture drawn by the application.
        /// The <paramref name="lprc"/> parameter should be provided where possible.
        /// </para>
        /// <para>
        /// The string pointed to by the <paramref name="lpDesc"/> parameter must contain a null character
        /// between the application name and the picture name and must terminate with two null characters,
        /// for example, "XYZ Graphics Editor\0Bald Eagle\0\0", where \0 represents the null character.
        /// If <paramref name="lpDesc"/> is <see cref="NULL"/>, there is no corresponding entry in the enhanced-metafile header.
        /// </para>
        /// <para>
        /// Applications use the device context created by this function to store a graphics picture in an enhanced metafile.
        /// The handle identifying this device context can be passed to any GDI function.
        /// </para>
        /// <para>
        /// After an application stores a picture in an enhanced metafile,
        /// it can display the picture on any output device by calling the <see cref="PlayEnhMetaFile"/> function.
        /// When displaying the picture, the system uses the rectangle pointed to by the <paramref name="lprc"/> parameter
        /// and the resolution data from the reference device to position and scale the picture.
        /// </para>
        /// <para>
        /// The device context returned by this function contains the same default attributes associated with any new device context.
        /// </para>
        /// <para>
        /// Applications must use the <see cref="GetWinMetaFileBits"/> function
        /// to convert an enhanced metafile to the older Windows metafile format.
        /// </para>
        /// <para>
        /// The file name for the enhanced metafile should use the <c>.emf</c> extension.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEnhMetaFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HDC CreateEnhMetaFile([In] HDC hdc, [In] LPCWSTR lpFilename, [In] in RECT lprc, [In] LPCWSTR lpDesc);

        /// <summary>
        /// <para>
        /// The <see cref="CreateMetaFile"/> function creates a device context for a Windows-format metafile.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createmetafilew"/>
        /// </para>
        /// </summary>
        /// <param name="pszFile">
        /// A pointer to the file name for the Windows-format metafile to be created.
        /// If this parameter is <see cref="NULL"/>, the Windows-format metafile is memory based
        /// and its contents are lost when it is deleted by using the <see cref="DeleteMetaFile"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the device context for the Windows-format metafile.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Where text arguments must use Unicode characters, use the <see cref="CreateMetaFile"/> function as a wide-character function.
        /// Where text arguments must use characters from the Windows character set, use this function as an ANSI function.
        /// </para>
        /// <para>
        /// <see cref="CreateMetaFile"/> is a Windows-format metafile function.
        /// This function supports only 16-bit Windows-based applications, which are listed in Windows-Format Metafiles.
        /// It does not record or play back GDI functions such as <see cref="PolyBezier"/>, which were not part of 16-bit Windows.
        /// </para>
        /// <para>
        /// The device context created by this function can be used to record GDI output functions in a Windows-format metafile.
        /// It cannot be used with GDI query functions such as <see cref="GetTextColor"/>.
        /// When the device context is used with a GDI output function,
        /// the return value of that function becomes <see cref="TRUE"/> if the function is recorded and <see cref="FALSE"/> otherwise.
        /// When an object is selected by using the <see cref="SelectObject"/> function, only a copy of the object is recorded.
        /// The object still belongs to the application.
        /// </para>
        /// <para>
        /// To create a scalable Windows-format metafile, record the graphics output in the <see cref="MM_ANISOTROPIC"/> mapping mode.
        /// The file cannot contain functions that modify the viewport origin and extents,
        /// nor can it contain device-dependent functions such as the <see cref="SelectClipRgn"/> function.
        /// Once created, the Windows metafile can be scaled and rendered to any output device-format
        /// by defining the viewport origin and extents of the picture before playing it.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is CreateEnhMetaFile.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateMetaFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HDC CreateMetaFile([In] LPCWSTR pszFile);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteEnhMetaFile"/> function deletes an enhanced-format metafile or an enhanced-format metafile handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deleteenhmetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hmf">
        /// A handle to an enhanced metafile.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If the <paramref name="hmf"/> parameter identifies an enhanced metafile stored in memory,
        /// the <see cref="DeleteEnhMetaFile"/> function deletes the metafile.
        /// If <paramref name="hmf"/> identifies a metafile stored on a disk,
        /// the function deletes the metafile handle but does not destroy the actual metafile.
        /// An application can retrieve the file by calling the <see cref="GetEnhMetaFile"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteEnhMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteEnhMetaFile([In] HENHMETAFILE hmf);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteMetaFile"/> function deletes a Windows-format metafile or Windows-format metafile handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deletemetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hmf">
        /// A handle to a Windows-format metafile.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If the metafile identified by the <paramref name="hmf"/> parameter is stored in memory (rather than on a disk),
        /// its content is lost when it is deleted by using the <see cref="DeleteMetaFile"/> function.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            " The corresponding function for an enhanced-format metafile is DeleteEnhMetaFile.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enumenhmetafile"/>
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
        /// <para>
        /// If the callback function successfully enumerates all the records in the enhanced metafile, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the callback function does not successfully enumerate all the records in the enhanced metafile, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Points along the edge of the rectangle pointed to by the <paramref name="lpRect"/> parameter are included in the picture.
        /// If the <paramref name="hdc"/> parameter is <see cref="NULL"/>, the system ignores <paramref name="lpRect"/>.
        /// </para>
        /// <para>
        /// If the callback function calls the <see cref="PlayEnhMetaFileRecord"/> function,
        /// <paramref name="hdc"/> must identify a valid device context.
        /// The system uses the device context's transformation and mapping mode
        /// to transform the picture displayed by the <see cref="PlayEnhMetaFileRecord"/> function.
        /// </para>
        /// <para>
        /// You can use the <see cref="EnumEnhMetaFile"/> function to embed one enhanced-metafile within another.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enummetafile"/>
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
        /// <para>
        /// If the callback function successfully enumerates all the records in the Windows-format metafile, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the callback function does not successfully enumerate all the records in the Windows-format metafile, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To convert a Windows-format metafile into an enhanced-format metafile, use the <see cref="SetWinMetaFileBits"/> function.
        /// </para>
        /// <para>
        /// You can use the <see cref="EnumMetaFile"/> function to embed one Windows-format metafile within another.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is EnumEnhMetaFile.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumMetaFile([In] HDC hdc, [In] HMETAFILE hmf, [In] MFENUMPROC proc, [In] LPARAM param);

        /// <summary>
        /// <para>
        /// The <see cref="GdiComment"/> function copies a comment from a buffer into a specified enhanced-format metafile.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdicomment"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to an enhanced-metafile device context.
        /// </param>
        /// <param name="nSize">
        /// The length of the comment buffer, in bytes.
        /// </param>
        /// <param name="lpData">
        /// A pointer to the buffer that contains the comment.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A comment can include any kind of private information, for example, the source of a picture and the date it was created.
        /// A comment should begin with an application signature, followed by the data.
        /// </para>
        /// <para>
        /// Comments should not contain application-specific or position-specific data.
        /// Position-specific data specifies the location of a record,
        /// and it should not be included because one metafile may be embedded within another metafile.
        /// </para>
        /// <para>
        /// A public comment is a comment that begins with the comment signature identifier <see cref="GDICOMMENT_IDENTIFIER"/>.
        /// The following public comments are defined.
        /// </para>
        /// <list type="table">
        /// <item>
        /// <term>
        /// <see cref="GDICOMMENT_WINDOWS_METAFILE"/>
        /// </term>
        /// <term>
        /// The <see cref="GDICOMMENT_WINDOWS_METAFILE"/> public comment contains a Windows-format metafile
        /// that is equivalent to an enhanced-format metafile.
        /// This comment is written only by the <see cref="SetWinMetaFileBits"/> function.
        /// The comment record, if given, follows the <see cref="ENHMETAHEADER"/> metafile record.
        /// The comment has the following form:
        /// </term>
        /// </item>
        /// </list>
        /// <code>
        /// DWORD ident;         // This contains GDICOMMENT_IDENTIFIER.
        /// DWORD iComment;      // This contains GDICOMMENT_WINDOWS_METAFILE.
        /// DWORD nVersion;      // This contains the version number of the
        ///                      // Windows-format metafile.
        /// DWORD nChecksum;     // This is the additive DWORD checksum for
        ///                      // the enhanced metafile.  The checksum
        ///                      // for the enhanced metafile data including
        ///                      // this comment record must be zero.
        ///                      // Otherwise, the enhanced metafile has been
        ///                      //  modified and the Windows-format
        ///                      // metafile is no longer valid.
        /// DWORD fFlags;        // This must be zero.
        /// DWORD cbWinMetaFile; // This is the size, in bytes. of the
        ///                      // Windows-format metafile data that follows.  
        /// </code>
        /// <list type="table">
        /// <item>
        /// <term>
        /// <see cref="GDICOMMENT_BEGINGROUP"/>
        /// </term>
        /// <term>
        /// The <see cref="GDICOMMENT_BEGINGROUP"/> public comment identifies the beginning of a group of drawing records.
        /// It identifies an object within an enhanced metafile.
        /// The comment has the following form:
        /// </term>
        /// </item>
        /// </list>
        /// <code>
        /// DWORD   ident;         // This contains GDICOMMENT_IDENTIFIER.
        /// DWORD   iComment;      // This contains GDICOMMENT_BEGINGROUP.
        /// RECTL   rclOutput;     // This is the bounding rectangle for the
        ///                        // object in logical coordinates.
        /// DWORD   nDescription;  // This is the number of characters in the
        ///                        // optional Unicode description string that
        ///                        // follows. This is zero if there is no
        ///                        // description string.  
        /// </code>
        /// <list type="table">
        /// <item>
        /// <term>
        /// <see cref="GDICOMMENT_ENDGROUP"/>
        /// </term>
        /// <term>
        /// The <see cref="GDICOMMENT_ENDGROUP"/> public comment identifies the end of a group of drawing records.
        /// The <see cref="GDICOMMENT_BEGINGROUP"/> comment and the <see cref="GDICOMMENT_ENDGROUP"/> comment
        /// must be included in a pair and may be nested.
        /// The comment has the following form:
        /// </term>
        /// </item>
        /// </list>
        /// <code>
        /// DWORD   ident;       // This contains GDICOMMENT_IDENTIFIER.
        /// DWORD iComment;    // This contains GDICOMMENT_ENDGROUP.  
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiComment", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiComment([In] HDC hdc, [In] UINT nSize, [In] BYTE[] lpData);

        /// <summary>
        /// <para>
        /// The <see cref="GetEnhMetaFile"/> function creates a handle that identifies the enhanced-format metafile stored in the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getenhmetafilew"/>
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// A pointer to a null-terminated string that specifies the name of an enhanced metafile.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the enhanced metafile.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When the application no longer needs an enhanced-metafile handle,
        /// it should delete the handle by calling the <see cref="DeleteEnhMetaFile"/> function.
        /// </para>
        /// <para>
        /// A Windows-format metafile must be converted to the enhanced format
        /// before it can be processed by the <see cref="GetEnhMetaFile"/> function.
        /// To convert the file, use the <see cref="SetWinMetaFileBits"/> function.
        /// </para>
        /// <para>
        /// Where text arguments must use Unicode characters, use this function as a wide-character function.
        /// Where text arguments must use characters from the Windows character set, use this function as an ANSI function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnhMetaFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HENHMETAFILE GetEnhMetaFile([In] LPCWSTR lpName);

        /// <summary>
        /// <para>
        /// The <see cref="GetEnhMetaFileBits"/> function retrieves the contents
        /// of the specified enhanced-format metafile and copies them into a buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getenhmetafilebits"/>
        /// </para>
        /// </summary>
        /// <param name="hEMF">
        /// A handle to the enhanced metafile.
        /// </param>
        /// <param name="nSize">
        /// The size, in bytes, of the buffer to receive the data.
        /// </param>
        /// <param name="lpData">
        /// A pointer to a buffer that receives the metafile data.
        /// The buffer must be sufficiently large to contain the data.
        /// If <paramref name="lpData"/> is <see langword="null"/>, the function returns the size necessary to hold the data.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds and the buffer pointer is <see langword="null"/>,
        /// the return value is the size of the enhanced metafile, in bytes.
        /// </para>
        /// <para>
        /// If the function succeeds and the buffer pointer is a valid pointer,
        /// the return value is the number of bytes copied to the buffer.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// After the enhanced-metafile bits are retrieved,
        /// they can be used to create a memory-based metafile by calling the <see cref="SetEnhMetaFileBits"/> function.
        /// </para>
        /// <para>
        /// The <see cref="GetEnhMetaFileBits"/> function does not invalidate the enhanced-metafile handle.
        /// The application must call the <see cref="DeleteEnhMetaFile"/> function to delete the handle when it is no longer needed.
        /// </para>
        /// <para>
        /// The metafile contents retrieved by this function are in the enhanced format.
        /// To retrieve the metafile contents in the Windows format, use the <see cref="GetWinMetaFileBits"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnhMetaFileBits", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetEnhMetaFileBits([In] HENHMETAFILE hEMF, [In] UINT nSize, [Out] BYTE[] lpData);

        /// <summary>
        /// <para>
        /// The <see cref="GetEnhMetaFileDescription"/> function retrieves an optional text description
        /// from an enhanced-format metafile and copies the string to the specified buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getenhmetafiledescriptionw"/>
        /// </para>
        /// </summary>
        /// <param name="hemf">
        /// A handle to the enhanced metafile.
        /// </param>
        /// <param name="cchBuffer">
        /// The size, in characters, of the buffer to receive the data. Only this many characters will be copied.
        /// </param>
        /// <param name="lpDescription">
        /// A pointer to a buffer that receives the optional text description.
        /// </param>
        /// <returns>
        /// <para>
        /// If the optional text description exists and the buffer pointer is <see cref="NULL"/>,
        /// the return value is the length of the text string, in characters.
        /// </para>
        /// <para>
        /// If the optional text description exists and the buffer pointer is a valid pointer,
        /// the return value is the number of characters copied into the buffer.
        /// </para>
        /// <para>
        /// If the optional text description does not exist, the return value is zero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="GDI_ERROR"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The optional text description contains two strings, the first identifying the application
        /// that created the enhanced metafile and the second identifying the picture contained in the metafile.
        /// The strings are separated by a null character and terminated with two null characters,
        /// for example, "XYZ Graphics Editor\0Bald Eagle\0\0" where \0 represents the null character.
        /// </para>
        /// <para>
        /// Where text arguments must use Unicode characters, use this function as a wide-character function.
        /// Where text arguments must use characters from the Windows character set, use this function as an ANSI function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnhMetaFileDescriptionW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetEnhMetaFileDescription([In] HENHMETAFILE hemf, [In] UINT cchBuffer, [In] LPWSTR lpDescription);

        /// <summary>
        /// <para>
        /// The <see cref="GetEnhMetaFileHeader"/> function retrieves the record
        /// containing the header for the specified enhanced-format metafile.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getenhmetafileheader"/>
        /// </para>
        /// </summary>
        /// <param name="hemf">
        /// A handle to the enhanced metafile for which the header is to be retrieved.
        /// </param>
        /// <param name="nSize">
        /// The size, in bytes, of the buffer to receive the data. Only this many bytes will be copied.
        /// </param>
        /// <param name="lpEnhMetaHeader">
        /// A pointer to an <see cref="ENHMETAHEADER"/> structure that receives the header record.
        /// If this parameter is <see cref="NullRef{ENHMETAHEADER}"/>, the function returns the size of the header record.
        /// </param>
        /// <returns>
        /// If the function succeeds and the structure pointer is <see cref="NullRef{ENHMETAHEADER}"/>,
        /// the return value is the size of the record that contains the header;
        /// if the structure pointer is a valid pointer, the return value is the number of bytes copied.
        /// Otherwise, it is zero.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An enhanced-metafile header contains such information as the metafile's size, in bytes;
        /// the dimensions of the picture stored in the metafile; the number of records stored in the metafile;
        /// the offset to the optional text description; the size of the optional palette,
        /// and the resolution of the device on which the picture was created.
        /// </para>
        /// <para>
        /// The record that contains the enhanced-metafile header is always the first record in the metafile.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnhMetaFileHeader", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetEnhMetaFileHeader([In] HENHMETAFILE hemf, [In] UINT nSize, [Out] out ENHMETAHEADER lpEnhMetaHeader);

        /// <summary>
        /// <para>
        /// The <see cref="GetEnhMetaFilePaletteEntries"/> function retrieves optional palette entries from the specified enhanced metafile.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getenhmetafilepaletteentries"/>
        /// </para>
        /// </summary>
        /// <param name="hemf">
        /// A handle to the enhanced metafile.
        /// </param>
        /// <param name="nNumEntries">
        /// The number of entries to be retrieved from the optional palette.
        /// </param>
        /// <param name="lpPaletteEntries">
        /// A pointer to an array of <see cref="PALETTEENTRY"/> structures that receives the palette colors.
        /// The array must contain at least as many structures as there are entries specified by the <paramref name="nNumEntries"/> parameter.
        /// </param>
        /// <returns>
        /// If the array pointer is <see langword="null"/> and the enhanced metafile contains an optional palette,
        /// the return value is the number of entries in the enhanced metafile's palette;
        /// if the array pointer is a valid pointer and the enhanced metafile contains an optional palette,
        /// the return value is the number of entries copied;
        /// if the metafile does not contain an optional palette, the return value is zero.
        /// Otherwise, the return value is <see cref="GDI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application can store an optional palette in an enhanced metafile
        /// by calling the <see cref="CreatePalette"/> and <see cref="SetPaletteEntries"/> functions
        /// before creating the picture and storing it in the metafile.
        /// By doing this, the application can achieve consistent colors when the picture is displayed on a variety of devices.
        /// </para>
        /// <para>
        /// An application that displays a picture stored in an enhanced metafile
        /// can call the <see cref="GetEnhMetaFilePaletteEntries"/> function to determine whether the optional palette exists.
        /// If it does, the application can call the <see cref="GetEnhMetaFilePaletteEntries"/> function a second time
        /// to retrieve the palette entries and then create a logical palette (by using the <see cref="CreatePalette"/> function),
        /// select it into its device context (by using the <see cref="SelectPalette"/> function),
        /// and then realize it (by using the <see cref="RealizePalette"/> function).
        /// After the logical palette has been realized,
        /// calling the <see cref="PlayEnhMetaFile"/> function displays the picture using its original colors.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetEnhMetaFilePaletteEntries", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetEnhMetaFilePaletteEntries([In] HENHMETAFILE hemf, [In] UINT nNumEntries, [Out] PALETTEENTRY[] lpPaletteEntries);

        /// <summary>
        /// <para>
        /// The <see cref="GetMetaFile"/> function creates a handle that identifies the metafile stored in the specified file.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getmetafilew"/>
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// A pointer to a null-terminated string that specifies the name of a metafile.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the metafile.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This function is not implemented in the Win32 API.
        /// It is provided for compatibility with 16-bit versions of Windows.
        /// In Win32 applications, use the <see cref="GetEnhMetaFile"/> function.
        /// </remarks>
        [Obsolete("GetMetaFile is no longer available for use as of Windows 2000. Instead, use GetEnhMetaFile.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMetaFileW", ExactSpelling = true, SetLastError = true)]
        public static extern HMETAFILE GetMetaFile([In] LPCWSTR lpName);

        /// <summary>
        /// <para>
        /// The <see cref="GetMetaFileBitsEx"/> function retrieves the contents
        /// of a Windows-format metafile and copies them into the specified buffer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function is provided only for compatibility with Windows-format metafiles.
        /// Enhanced-format metafiles provide superior functionality and are recommended for new applications.
        /// The corresponding function for an enhanced-format metafile is <see cref="GetEnhMetaFileBits"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getmetafilebitsex"/>
        /// </para>
        /// </summary>
        /// <param name="hMF">
        /// A handle to a Windows-format metafile.
        /// </param>
        /// <param name="cbBuffer">
        /// The size, in bytes, of the buffer to receive the data.
        /// </param>
        /// <param name="lpData">
        /// A pointer to a buffer that receives the metafile data.
        /// The buffer must be sufficiently large to contain the data.
        /// If <paramref name="lpData"/> is <see cref="NULL"/>, the function returns the number of bytes required to hold the data.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds and the buffer pointer is <see cref="NULL"/>, the return value is the number of bytes required for the buffer; if the function succeeds and the buffer pointer is a valid pointer, the return value is the number of bytes copied.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// After the Windows-metafile bits are retrieved, they can be used to create a memory-based metafile
        /// by calling the <see cref="SetMetaFileBitsEx"/> function.
        /// </para>
        /// <para>
        /// The <see cref="GetMetaFileBitsEx"/> function does not invalidate the metafile handle.
        /// An application must delete this handle by calling the <see cref="DeleteMetaFile"/> function.
        /// </para>
        /// <para>
        /// To convert a Windows-format metafile into an enhanced-format metafile, use the <see cref="SetWinMetaFileBits"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMetaFileBitsEx", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetMetaFileBitsEx([In] HMETAFILE hMF, [In] UINT cbBuffer, [In] LPVOID lpData);

        /// <summary>
        /// <para>
        /// The <see cref="GetMetaRgn"/> function retrieves the current metaregion for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getmetargn"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// A handle to an existing region before the function is called.
        /// After the function returns, this parameter is a handle to a copy of the current metaregion.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the function succeeds, <paramref name="hrgn"/> is a handle to a copy of the current metaregion.
        /// Subsequent changes to this copy will not affect the current metaregion.
        /// </para>
        /// <para>
        /// The current clipping region of a device context is defined by the intersection of its clipping region and its metaregion.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMetaRgn", ExactSpelling = true, SetLastError = true)]
        public static extern int GetMetaRgn([In] HDC hdc, [In] HRGN hrgn);

        /// <summary>
        /// <para>
        /// The <see cref="GetWinMetaFileBits"/> function converts the enhanced-format records
        /// from a metafile into Windows-format records and stores the converted records in the specified buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getwinmetafilebits"/>
        /// </para>
        /// </summary>
        /// <param name="hemf">
        /// A handle to the enhanced metafile.
        /// </param>
        /// <param name="cbData16">
        /// The size, in bytes, of the buffer into which the converted records are to be copied.
        /// </param>
        /// <param name="pData16">
        /// A pointer to the buffer that receives the converted records.
        /// If <paramref name="pData16"/> is <see langword="null"/>,
        /// <see cref="GetWinMetaFileBits"/> returns the number of bytes required to store the converted metafile records.
        /// </param>
        /// <param name="iMapMode">
        /// The mapping mode to use in the converted metafile.
        /// </param>
        /// <param name="hdcRef">
        /// A handle to the reference device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds and the buffer pointer is <see langword="null"/>,
        /// the return value is the number of bytes required to store the converted records;
        /// if the function succeeds and the buffer pointer is a valid pointer,
        /// the return value is the size of the metafile data in bytes.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function converts an enhanced metafile into a Windows-format metafile
        /// so that its picture can be displayed in an application that recognizes the older format.
        /// </para>
        /// <para>
        /// The system uses the reference device context to determine the resolution of the converted metafile.
        /// </para>
        /// <para>
        /// The <see cref="GetWinMetaFileBits"/> function does not invalidate the enhanced metafile handle.
        /// An application should call the <see cref="DeleteEnhMetaFile"/> function to release the handle when it is no longer needed.
        /// </para>
        /// <para>
        /// To create a scalable Windows-format metafile, specify <see cref="MM_ANISOTROPIC"/> as the <paramref name="iMapMode"/> parameter.
        /// </para>
        /// <para>
        /// The upper-left corner of the metafile picture is always mapped to the origin of the reference device.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWinMetaFileBits", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetWinMetaFileBits([In] HENHMETAFILE hemf, [In] UINT cbData16, [Out] BYTE[] pData16,
            [In] MappingModes iMapMode, [In] HDC hdcRef);

        /// <summary>
        /// <para>
        /// The <see cref="PlayEnhMetaFile"/> function displays the picture stored in the specified enhanced-format metafile.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-playenhmetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context for the output device on which the picture will appear.
        /// </param>
        /// <param name="hmf">
        /// A handle to the enhanced metafile.
        /// </param>
        /// <param name="lprect">
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates of the bounding rectangle used to display the picture.
        /// The coordinates are specified in logical units.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When an application calls the <see cref="PlayEnhMetaFile"/> function,
        /// the system uses the picture frame in the enhanced-metafile header to map the picture
        /// onto the rectangle pointed to by the <paramref name="lprect"/> parameter.
        /// (This picture may be sheared or rotated by setting the world transform
        /// in the output device before calling <see cref="PlayEnhMetaFile"/>.)
        /// Points along the edges of the rectangle are included in the picture.
        /// </para>
        /// <para>
        /// An enhanced-metafile picture can be clipped by defining the clipping region in the output device before playing the enhanced metafile.
        /// </para>
        /// <para>
        /// If an enhanced metafile contains an optional palette, an application can achieve consistent colors
        /// by setting up a color palette on the output device before calling <see cref="PlayEnhMetaFile"/>.
        /// To retrieve the optional palette, use the <see cref="GetEnhMetaFilePaletteEntries"/> function.
        /// </para>
        /// <para>
        /// An enhanced metafile can be embedded in a newly created enhanced metafile by calling <see cref="PlayEnhMetaFile"/>
        /// and playing the source enhanced metafile into the device context for the new enhanced metafile.
        /// </para>
        /// <para>
        /// The states of the output device context are preserved by this function.
        /// Any object created but not deleted in the enhanced metafile is deleted by this function.
        /// </para>
        /// <para>
        /// To stop this function, an application can call the <see cref="CancelDC"/> function from another thread to terminate the operation.
        /// In this case, the function returns <see cref="FALSE"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PlayEnhMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PlayEnhMetaFile([In] HDC hdc, [In] HENHMETAFILE hmf, [In] in RECT lprect);

        /// <summary>
        /// <para>
        /// The <see cref="PlayEnhMetaFileRecord"/> function plays an enhanced-metafile record
        /// by executing the graphics device interface (GDI) functions identified by the record.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-playenhmetafilerecord"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context passed to the <see cref="EnumEnhMetaFile"/> function.
        /// </param>
        /// <param name="pht">
        /// A pointer to a table of handles to GDI objects used when playing the metafile.
        /// The first entry in this table contains the enhanced-metafile handle.
        /// </param>
        /// <param name="pmr">
        /// A pointer to the enhanced-metafile record to be played.
        /// </param>
        /// <param name="cht">
        /// The number of handles in the handle table.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This is an enhanced-metafile function.
        /// </para>
        /// <para>
        /// An application typically uses <see cref="PlayEnhMetaFileRecord"/>
        /// in conjunction with the <see cref="EnumEnhMetaFile"/> function to process and play an enhanced-format metafile one record at a time.
        /// </para>
        /// <para>
        /// The <paramref name="hdc"/>, <paramref name="pht"/>, and <paramref name="cht"/> parameters
        /// must be exactly those passed to the <see cref="EnhMetaFileProc"/> callback procedure by the <see cref="EnumEnhMetaFile"/> function.
        /// </para>
        /// <para>
        /// If <see cref="PlayEnhMetaFileRecord"/> does not recognize a record, it ignores the record and returns <see cref="TRUE"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PlayEnhMetaFileRecord", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PlayEnhMetaFileRecord([In] HDC hdc, [In] in HANDLETABLE pht, [In] in ENHMETARECORD pmr, [In] UINT cht);

        /// <summary>
        /// <para>
        /// The <see cref="PlayMetaFile"/> function displays the picture stored in the given Windows-format metafile on the specified device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-playmetafile"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a device context.
        /// </param>
        /// <param name="hmf">
        /// Handle to a Windows-format metafile.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To convert a Windows-format metafile into an enhanced format metafile, use the <see cref="SetWinMetaFileBits"/> function.
        /// </para>
        /// <para>
        /// A Windows-format metafile can be played multiple times.
        /// </para>
        /// <para>
        /// A Windows-format metafile can be embedded in a second Windows-format metafile
        /// by calling the <see cref="PlayMetaFile"/> function and playing the source metafile into the device context for the target metafile.
        /// </para>
        /// <para>
        /// Any object created but not deleted in the Windows-format metafile is deleted by this function.
        /// </para>
        /// <para>
        /// To stop this function, an application can call the <see cref="CancelDC"/> function
        /// from another thread to terminate the operation.
        /// In this case, the function returns <see cref="FALSE"/>.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is PlayEnhMetaFile.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PlayMetaFile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PlayMetaFile([In] HDC hdc, [In] HMETAFILE hmf);

        /// <summary>
        /// <para>
        /// The <see cref="PlayMetaFileRecord"/> function plays a Windows-format metafile record
        /// by executing the graphics device interface (GDI) function contained within that record.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-playmetafilerecord"/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To convert a Windows-format metafile into an enhanced-format metafile, use the <see cref="SetWinMetaFileBits"/> function.
        /// </para>
        /// <para>
        /// An application typically uses <see cref="PlayMetaFileRecord"/> in conjunction with the <see cref="EnumMetaFile"/> function
        /// to process and play a Windows-format metafile one record at a time.
        /// </para>
        /// <para>
        /// The <paramref name="lpHandleTable"/> and <paramref name="noObjs"/> parameters
        /// must be identical to those passed to the <see cref="EnumMetaFileProc"/> callback procedure by <see cref="EnumMetaFile"/>.
        /// </para>
        /// <para>
        /// If the <see cref="PlayMetaFileRecord"/> function does not recognize a record,
        /// it ignores the record and returns <see cref="TRUE"/>.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles." +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications." +
            "The corresponding function for an enhanced-format metafile is PlayEnhMetaFileRecord.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PlayMetaFileRecord", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PlayMetaFileRecord([In] HDC hdc, [In] HGDIOBJ[] lpHandleTable, [In] in METARECORD lpMR, [In] UINT noObjs);

        /// <summary>
        /// <para>
        /// The <see cref="SetEnhMetaFileBits"/> function creates a memory-based enhanced-format metafile from the specified data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setenhmetafilebits"/>
        /// </para>
        /// </summary>
        /// <param name="nSize">
        /// Specifies the size, in bytes, of the data provided.
        /// </param>
        /// <param name="pb">
        /// Pointer to a buffer that contains enhanced-metafile data.
        /// (It is assumed that the data in the buffer was obtained by calling the <see cref="GetEnhMetaFileBits"/> function.)
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to a memory-based enhanced metafile.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When the application no longer needs the enhanced-metafile handle,
        /// it should delete the handle by calling the <see cref="DeleteEnhMetaFile"/> function.
        /// </para>
        /// <para>
        /// The <see cref="SetEnhMetaFileBits"/> function does not accept metafile data in the Windows format.
        /// To import Windows-format metafiles, use the <see cref="SetWinMetaFileBits"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetEnhMetaFileBits", ExactSpelling = true, SetLastError = true)]
        public static extern HENHMETAFILE SetEnhMetaFileBits([In] UINT nSize, [In] BYTE[] pb);

        /// <summary>
        /// <para>
        /// The <see cref="SetMetaFileBitsEx"/> function creates a memory-based Windows-format metafile from the supplied data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setmetafilebitsex"/>
        /// </para>
        /// </summary>
        /// <param name="cbBuffer">
        /// Specifies the size, in bytes, of the Windows-format metafile.
        /// </param>
        /// <param name="lpData">
        /// Pointer to a buffer that contains the Windows-format metafile.
        /// (It is assumed that the data was obtained by using the <see cref="GetMetaFileBitsEx"/> function.)
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to a memory-based Windows-format metafile.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To convert a Windows-format metafile into an enhanced-format metafile, use the <see cref="SetWinMetaFileBits"/> function.
        /// </para>
        /// <para>
        /// When the application no longer needs the metafile handle returned by <see cref="SetMetaFileBitsEx"/>,
        /// it should delete it by calling the <see cref="DeleteMetaFile"/> function.
        /// </para>
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with Windows-format metafiles. " +
            "Enhanced-format metafiles provide superior functionality and are recommended for new applications. " +
            "The corresponding function for an enhanced-format metafile is SetEnhMetaFileBits.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMetaFileBitsEx", ExactSpelling = true, SetLastError = true)]
        public static extern HMETAFILE SetMetaFileBitsEx([In] UINT cbBuffer, [In] BYTE[] lpData);

        /// <summary>
        /// <para>
        /// The <see cref="SetMetaRgn"/> function intersects the current clipping region for the specified device context
        /// with the current metaregion and saves the combined region as the new metaregion for the specified device context.
        /// The clipping region is reset to a null region.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setmetargn"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the new clipping region's complexity and can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred. (The previous clipping region is unaffected.)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The current clipping region of a device context is defined by the intersection of its clipping region and its metaregion.
        /// </para>
        /// <para>
        /// The <see cref="SetMetaRgn"/> function should only be called 
        /// after an application's original device context was saved by calling the <see cref="SaveDC"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMetaRgn", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags SetMetaRgn([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="SetWinMetaFileBits"/> function converts a metafile from the older Windows format
        /// to the new enhanced format and stores the new metafile in memory.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setwinmetafilebits"/>
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
        /// <para>
        /// If the function succeeds, the return value is a handle to a memory-based enhanced metafile.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Windows uses the reference device context's resolution data and the data
        /// in the <see cref="METAFILEPICT"/> structure to scale a picture.
        /// If the <paramref name="hdcRef"/> parameter is <see cref="NULL"/>,
        /// the system uses resolution data for the current output device.
        /// If the <paramref name="lpMeta16Data"/> parameter is <see cref="NULL"/>,
        /// the system uses the <see cref="MM_ANISOTROPIC"/> mapping mode to scale the picture so that it fits the entire device surface.
        /// The <see cref="METAFILEPICT.hMF"/> member of the <see cref="METAFILEPICT"/> structure is not used.
        /// </para>
        /// <para>
        /// When the application no longer needs the enhanced metafile handle,
        /// it should delete it by calling the <see cref="DeleteEnhMetaFile"/> function.
        /// </para>
        /// <para>
        /// The handle returned by this function can be used with other enhanced-metafile functions.
        /// </para>
        /// <para>
        /// If the reference device context is not identical to the device in which the metafile was originally created,
        /// some GDI functions that use device units may not draw the picture correctly.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWinMetaFileBits", ExactSpelling = true, SetLastError = true)]
        public static extern HENHMETAFILE SetWinMetaFileBits([In] UINT nSize, [In] IntPtr lpMeta16Data, [In] HDC hdcRef, [In] in METAFILEPICT lpMFP);
    }
}
