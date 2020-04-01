using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="CreateMetaFile"/> function creates a device context for a Windows-format metafile.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createmetafilew
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateMetaFileW", SetLastError = true)]
        public static extern HDC CreateMetaFile([In]string pszFile);

        /// <summary>
        /// <para>
        /// The <see cref="CloseMetaFile"/> function closes a metafile device context and returns a handle that identifies a Windows-format metafile.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-closemetafile
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseMetaFile", SetLastError = true)]
        public static extern HMETAFILE CloseMetaFile([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="CopyMetaFile"/> function copies the content of a Windows-format metafile to the specified file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-copymetafilew
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyMetaFileW", SetLastError = true)]
        public static extern HMETAFILE CopyMetaFile([In]HMETAFILE arg1, [MarshalAs(UnmanagedType.LPWStr)][In]string arg2);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteMetaFile"/> function deletes a Windows-format metafile or Windows-format metafile handle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-deletemetafile
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteMetaFile", SetLastError = true)]
        public static extern BOOL DeleteMetaFile([In]HMETAFILE hmf);

        /// <summary>
        /// <para>
        /// The <see cref="GetMetaFile"/> function creates a handle that identifies the metafile stored in the specified file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getmetafilew
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMetaFileW", SetLastError = true)]
        public static extern HMETAFILE GetMetaFile([MarshalAs(UnmanagedType.LPWStr)][In]string lpName);

        /// <summary>
        /// <para>
        /// The <see cref="PlayMetaFile"/> function displays the picture stored in the given Windows-format metafile on the specified device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-playmetafile
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PlayMetaFile", SetLastError = true)]
        public static extern BOOL PlayMetaFile([In]HDC hdc, [In]HMETAFILE hmf);

        /// <summary>
        /// <para>
        /// The <see cref="PlayMetaFileRecord"/> function plays a Windows-format metafile record
        /// by executing the graphics device interface (GDI) function contained within that record.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-playmetafilerecord
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PlayMetaFileRecord", SetLastError = true)]
        public static extern BOOL PlayMetaFileRecord([In]HDC hdc, [MarshalAs(UnmanagedType.LPArray)][In]HGDIOBJ[] lpHandleTable,
            [MarshalAs(UnmanagedType.LPStruct)][In]METARECORD lpMR, [In]UINT noObjs);
    }
}
