using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a code page.
    /// This structure is used by the <see cref="GetCPInfo"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/ns-winnls-cpinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Lead bytes are unique to DBCS code pages that allow for more than 256 characters.
    /// A lead byte is the first byte of a 2-byte character in a DBCS.
    /// On each DBCS code page, the lead bytes occupy a specific range of byte values.
    /// This range is different for different code pages.
    /// The lead byte information is not very helpful for most code pages,
    /// and is not even provided for many multi-byte encodings, for example, UTF-8 and GB18030.
    /// Your applications are discouraged from using this information to predict
    /// what the <see cref="MultiByteToWideChar"/> or <see cref="WideCharToMultiByte"/> function will do.
    /// The function might end up using a default character or performing other default behavior if the bytes following the lead byte are not as expected.
    /// <see cref="CPINFOEX"/>, used by the <see cref="GetCPInfoEx"/> function, provides an extended version of this structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CPINFO
    {
        /// <summary>
        /// Maximum length, in bytes, of a character in the code page.
        /// The length can be 1 for a single-byte character set (SBCS), 2 for a double-byte character set (DBCS),
        /// or a value larger than 2 for other character set types.
        /// The function cannot use the size to distinguish an SBCS or a DBCS from other character sets because of other factors,
        /// for example, the use of ISCII or ISO-2022-xx code pages.
        /// </summary>
        public UINT MaxCharSize;

        /// <summary>
        /// Default character used when translating character strings to the specific code page.
        /// This character is used by the <see cref="WideCharToMultiByte"/> function if an explicit default character is not specified.
        /// The default is usually the "?" character for the code page.
        /// </summary>
        public ByValBYTEArrayStructForSize2 DefaultChar;

        /// <summary>
        /// A fixed-length array of lead byte ranges, for which the number of lead byte ranges is variable.
        /// If the code page has no lead bytes, every element of the array is set to NULL.
        /// If the code page has lead bytes, the array specifies a starting value and an ending value for each range.
        /// Ranges are inclusive, and the maximum number of ranges for any code page is five.
        /// The array uses two bytes to describe each range, with two null bytes as a terminator after the last range
        /// Note
        /// Some code pages use lead bytes and a combination of other encoding mechanisms.
        /// This member is usually only populated for a subset of the code pages that use lead bytes in some form.
        /// For more information, see the Remarks section.
        /// </summary>
        public ByValBYTEArrayStructForSize12 LeadByte;
    }
}
