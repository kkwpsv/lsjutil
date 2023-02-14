using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a file, related to its use with MUI.
    /// Most of this data is stored in the resource configuration data for the particular file.
    /// When this structure is retrieved by <see cref="GetFileMUIInfo"/>, not all fields are necessarily filled in.
    /// The fields used depend on the flags that the application has passed to that function.
    /// Note
    /// Your MUI applications can use the MUI macros to access this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnls/ns-winnls-filemuiinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// All offsets are from the base of the structure.
    /// An offset of 0 indicates that the data is not available.
    /// The following is an example showing how to access data for the position in the structure that is described by an offset.
    /// This example accesses the language name string with the position defined by <see cref="dwLanguageNameOffset"/>.
    /// <code>
    /// PFILEMUIINFO pFileMUIInfo = NULL;
    /// 
    /// Allocate_pFileMUIInfo_AndPassTo_GetFileMUIInfo(&amp;pFileMUIInfo);
    /// 
    /// LPWSTR lpszLang = reinterpret_cast&lt;LPWSTR&gt;(reinterpret_cast&lt;BYTE*&gt;(pFileMUIInfo) + pFileMUIInfo-&gt;dwLanguageNameOffset);
    /// </code>
    /// This example uses two reinterpret casts.
    /// First the code casts to BYTE* so the pointer arithmetic for the offset will be done in bytes.
    /// Then the code casts the resulting pointer to the desired type.
    /// Alternatively, the code can be written as shown below. The effect is the same; the choice is strictly one of style.
    /// <code>
    /// PFILEMUIINFO pFileMUIInfo = NULL;
    /// 
    /// Allocate_pFileMUIInfo_AndPassTo_GetFileMUIInfo(&amp;pFileMUIInfo);
    /// 
    /// DWORD ix = pFileMUIInfo-&gt;ldwLanguageNameOffset - offsetof(struct _FILEMUIINFO, abBuffer);
    /// LPWSTR lpszLang = reinterpret_cast&lt;LPWSTR&gt;(&amp;(pFileMUIInfo-&gt;abBuffer[ix]));
    /// </code>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILEMUIINFO
    {
        /// <summary>
        /// Size of the structure, including the buffer, which can be extended past the 8 bytes declared.
        /// The minimum value allowed is <code>sizeof(FILEMUIINFO)</code>.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// Version of the structure.
        /// The current version is 0x001.
        /// </summary>
        public DWORD dwVersion;

        /// <summary>
        /// The file type. Possible values are:
        /// <see cref="MUI_FILETYPE_NOT_LANGUAGE_NEUTRAL"/>:
        /// The input file does not have resource configuration data.
        /// This file type is typical for older executable files.
        /// If this file type is specified, the other file types will not provide useful information.
        /// <see cref="MUI_FILETYPE_LANGUAGE_NEUTRAL_MAIN"/>:
        /// The input file is an LN file.
        /// <see cref="MUI_FILETYPE_LANGUAGE_NEUTRAL_MUI"/>:
        /// The input file is a language-specific resource file.
        /// </summary>
        public MUI_FILETYPE dwFileType;

        /// <summary>
        /// Pointer to a 128-bit checksum for the file, if it is either an LN file or a language-specific resource file.
        /// </summary>
        public ByValBYTEArrayStructForSize16 pChecksum;

        /// <summary>
        /// Pointer to a 128-bit checksum for the file, used for servicing.
        /// </summary>
        public ByValBYTEArrayStructForSize16 pServiceChecksum;

        /// <summary>
        /// Offset, in bytes, from the beginning of the structure to the language name string for a language-specific resource file,
        /// or to the ultimate fallback language name string for an LN file.
        /// </summary>
        public DWORD dwLanguageNameOffset;

        /// <summary>
        /// Size of the array for which the offset is indicated by <see cref="dwTypeIDMainOffset"/>.
        /// The size also corresponds to the number of strings in the multi-string array indicated by <see cref="dwTypeNameMainOffset"/>.
        /// </summary>
        public DWORD dwTypeIDMainSize;

        /// <summary>
        /// Offset, in bytes, from the beginning of the structure to a DWORD array enumerating the resource types contained in the LN file.
        /// </summary>
        public DWORD dwTypeIDMainOffset;

        /// <summary>
        /// Offset, in bytes, from the beginning of the structure to a series of null-terminated strings
        /// in a multi-string array enumerating the resource names contained in the LN file.
        /// </summary>
        public DWORD dwTypeNameMainOffset;

        /// <summary>
        /// Size of the array with the offset indicated by <see cref="dwTypeIDMUIOffset"/>.
        /// The size also corresponds to the number of strings in the series of strings indicated by <see cref="dwTypeNameMUIOffset"/>.
        /// </summary>
        public DWORD dwTypeIDMUISize;

        /// <summary>
        /// Offset, in bytes, from the beginning of the structure to a DWORD array enumerating the resource types contained in the LN file.
        /// </summary>
        public DWORD dwTypeIDMUIOffset;

        /// <summary>
        /// Offset, in bytes, from the beginning of the structure to a multi-string array enumerating the resource names contained in the LN file.
        /// </summary>
        public DWORD dwTypeNameMUIOffset;

        /// <summary>
        /// Remainder of the allocated memory for this structure. See the Remarks section for correct use of this array.
        /// </summary>
        public ByValBYTEArrayStructForSize8 abBuffer;
    }
}
