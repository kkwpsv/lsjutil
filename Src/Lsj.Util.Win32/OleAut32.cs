using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.VARENUM;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// OleAut32.dll
    /// </summary>
    public static class OleAut32
    {
        /// <summary>
        /// <para>
        /// Converts the MS-DOS representation of time to the date and time representation stored in a variant.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/oleauto/nf-oleauto-dosdatetimetovarianttime"/>
        /// </para>
        /// </summary>
        /// <param name="wDosDate">
        /// RThe MS-DOS date to convert.
        /// The valid range of MS-DOS dates is January 1, 1980, to December 31, 2099, inclusive.
        /// </param>
        /// <param name="wDosTime">
        /// The MS-DOS time to convert.
        /// </param>
        /// <param name="pvtime">
        /// The converted time.
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> on success and <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// MS-DOS records file dates and times as packed 16-bit values.
        /// An MS-DOS date has the following format.
        /// Bits	Contents
        /// 0–4 	Day of the month (1–31).
        /// 5–8     Month (1 = January, 2 = February, and so on).
        /// 9–15	Year offset from 1980 (add 1980 to get the actual year).
        /// An MS-DOS time has the following format.
        /// Bits	Contents
        /// 0–4 	Second divided by 2.
        /// 5–10	Minute (0–59).
        /// 11–15	Hour (0– 23 on a 24-hour clock).
        /// The <see cref="DosDateTimeToVariantTime"/> function will accept invalid dates and try to fix them when resolving to a <see cref="VARIANT"/> time.
        /// For example, an invalid date such as 2/29/2001 will resolve to 3/1/2001.
        /// Only days are fixed, so invalid month values result in an error being returned.
        /// Days are checked to be between 1 and 31. 
        /// Negative days and days greater than 31 results in an error.
        /// A day less than 31 but greater than the maximum day in that month has the day promoted to the appropriate day of the next month.
        /// A day equal to zero resolves as the last day of the previous month.
        /// For example, an invalid dates such as 2/0/2001 will resolve to 1/31/2001.
        /// </remarks>
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "DosDateTimeToVariantTime", ExactSpelling = true, SetLastError = true)]
        public static extern INT DosDateTimeToVariantTime([In] USHORT wDosDate, [In] USHORT wDosTime, [Out] out DOUBLE pvtime);

        /// <summary>
        /// <para>
        /// Allocates a new string and copies the passed string into it.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/oleauto/nf-oleauto-sysallocstring"/>
        /// </para>
        /// </summary>
        /// <param name="psz">
        /// The string to copy.
        /// </param>
        /// <returns>
        /// If successful, returns the string.
        /// If <paramref name="psz"/> is a zero-length string, returns a zero-length <see cref="BSTR"/>.
        /// If <paramref name="psz"/> is <see langword="null"/> or insufficient memory exists, returns <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// You can free strings created with <see cref="SysAllocString"/> using <see cref="SysFreeString"/>.
        /// </remarks>
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "SysAllocString", ExactSpelling = true, SetLastError = true)]
        public static extern BSTR SysAllocString([In] LPCWSTR psz);

        /// <summary>
        /// <para>
        /// Takes an ANSI string as input, and returns a <see cref="BSTR"/> that contains an ANSI string.
        /// Does not perform any ANSI-to-Unicode translation.
        /// </para>
        /// </summary>
        /// <param name="psz">
        /// The string to copy, or <see cref="NULL"/> to keep the string uninitialized.
        /// </param>
        /// <param name="len">
        /// The number of bytes to copy.
        /// A null character is placed afterwards, allocating a total of <paramref name="len"/> plus the size of <see cref="OLECHAR"/> bytes.
        /// </param>
        /// <returns>
        /// A copy of the string, or <see cref="NULL"/> if there is insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// This function is provided to create BSTRs that contain binary data.
        /// You can use this type of <see cref="BSTR"/> only in situations where it will not be translated from ANSI to Unicode, or vice versa.
        /// For example, do not use these BSTRs between a 16-bit and a 32-bit application running on a 32-bit Windows system.
        /// The OLE 16-bit to 32-bit (and 32-bit to 16-bit) interoperability layer will translate the BSTR and corrupt the binary data.
        /// The preferred method of passing binary data is to use a SAFEARRAY of <see cref="VT_UI1"/>, which will not be translated by OLE.
        /// If <paramref name="psz"/> is <see cref="NULL"/>, a string of the requested length is allocated, but not initialized.
        /// The string <paramref name="psz"/> can contain embedded <see cref="NULL"/> characters, and does not need to end with a <see cref="NULL"/>.
        /// Free the returned string later with <see cref="SysFreeString"/>.
        /// </remarks>
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "SysAllocStringByteLen", ExactSpelling = true, SetLastError = true)]
        public static extern BSTR SysAllocStringByteLen([In] LPCSTR psz, [In] UINT len);

        /// <summary>
        /// /<para>
        /// Allocates a new string, copies the specified number of characters from the passed string, and appends a null-terminating character.
        /// </para>
        /// <para>
        /// <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/oleauto/nf-oleauto-sysallocstringlen"/>
        /// </para>
        /// </summary>
        /// <param name="strIn">
        /// The input string.
        /// </param>
        /// <param name="ui">
        /// The number of characters to copy.
        /// A null character is placed afterwards, allocating a total of <paramref name="ui"/> plus one characters.
        /// </param>
        /// <returns>
        /// A copy of the string, or <see cref="NULL"/> if there is insufficient memory to complete the operation.
        /// </returns>
        /// <remarks>
        /// The string can contain embedded null characters and does not need to end with a <see cref="NULL"/>.
        /// Free the returned string later with <see cref="SysFreeString"/>.
        /// If <paramref name="strIn"/> is not <see cref="NULL"/>, then the memory allocated to <paramref name="strIn"/> must be at least <paramref name="ui"/> characters long.
        /// Note
        /// This function does not convert a char* string into a Unicode BSTR.
        /// </remarks>
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "SysAllocStringLen", ExactSpelling = true, SetLastError = true)]
        public static extern BSTR SysAllocStringLen([In] LPCWSTR strIn, [In] UINT ui);

        /// <summary>
        /// <para>
        /// Deallocates a string allocated previously by <see cref="SysAllocString"/>, <see cref="SysAllocStringByteLen"/>,
        /// <see cref="SysReAllocString"/>, <see cref="SysAllocStringLen"/>, or <see cref="SysReAllocStringLen"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/oleauto/nf-oleauto-sysfreestring"/>
        /// </para>
        /// </summary>
        /// <param name="bstrString">
        /// The previously allocated string.
        /// If this parameter is <see cref="NULL"/>, the function simply returns.
        /// </param>
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "SysFreeString", ExactSpelling = true, SetLastError = true)]
        public static extern void SysFreeString([In] BSTR bstrString);

        /// <summary>
        /// <para>
        /// Clears a variant.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/oleauto/nf-oleauto-variantclear"/>
        /// </para>
        /// </summary>
        /// <param name="pvarg">
        /// The variant to clear.
        /// </param>
        /// <returns>
        /// This function can return one of these values.
        /// <see cref="S_OK"/>: Success.
        /// <see cref="DISP_E_ARRAYISLOCKED"/>: The variant contains an array that is locked.
        /// <see cref="DISP_E_BADVARTYPE"/>: The variant type is not a valid type of variant.
        /// <see cref="E_INVALIDARG"/>: One of the arguments is not valid.
        /// </returns>
        /// <remarks>
        /// Use this function to clear variables of type <see cref="VARIANTARG"/> (or <see cref="VARIANT"/>)
        /// before the memory containing the <see cref="VARIANTARG"/> is freed (as when a local variable goes out of scope).
        /// The function clears a <see cref="VARIANTARG"/> by setting the <see cref="VARIANTARG.vt"/> field to <see cref="VT_EMPTY"/>.
        /// The current contents of the <see cref="VARIANTARG"/> are released first.
        /// If the <see cref="VARIANTARG.vt"/> field is <see cref="VT_BSTR"/>, the string is freed.
        /// If the <see cref="VARIANTARG.vt"/> field is <see cref="VT_DISPATCH"/>, the object is released.
        /// If the <see cref="VARIANTARG.vt"/> field has the <see cref="VT_ARRAY"/> bit set, the array is freed.
        /// If the variant to be cleared is a COM object that is passed by reference, the <see cref="VARIANTARG.vt"/> field
        /// of the <paramref name="pvarg"/> parameter is <code>VT_DISPATCH | VT_BYREF or VT_UNKNOWN | VT_BYREF</code>.
        /// In this case, <see cref="VariantClear"/> does not release the object.
        /// Because the variant being cleared is a pointer to a reference to an object,
        /// <see cref="VariantClear"/> has no way to determine if it is necessary to release the object.
        /// It is therefore the responsibility of the caller to release the object or not, as appropriate.
        /// In certain cases, it may be preferable to clear a variant in code without calling <see cref="VariantClear"/>.
        /// For example, you can change the type of a <see cref="VT_I4"/> variant to another type without calling this function.
        /// Safearrays of BSTR will have <see cref="SysFreeString"/> called on each element not <see cref="VariantClear"/>.
        /// However, you must call <see cref="VariantClear"/> if a VT_type is received but cannot be handled.
        /// Safearrays of variant will also have <see cref="VariantClear"/> called on each member.
        /// Using <see cref="VariantClear"/> in these cases ensures that code will continue to work if Automation adds new variant types in the future.
        /// Do not use <see cref="VariantClear"/> on uninitialized variants; use <see cref="VariantInit"/> to initialize a new <see cref="VARIANTARG"/> or <see cref="VARIANT"/>.
        /// Variants containing arrays with outstanding references cannot be cleared.
        /// Attempts to do so will return an <see cref="HRESULT"/> containing <see cref="DISP_E_ARRAYISLOCKED"/>.
        /// </remarks>
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "VariantClear", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT VariantClear([In] in VARIANTARG pvarg);

        /// <summary>
        /// <para>
        /// Initializes a variant.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/oleauto/nf-oleauto-variantinit"/>
        /// </para>
        /// </summary>
        /// <param name="pvarg">
        /// The variant to initialize.
        /// </param>
        /// <remarks>
        /// The <see cref="VariantInit"/> function initializes the <see cref="VARIANTARG"/> by
        /// setting the <see cref="VARIANTARG.vt"/> field to <see cref="VT_EMPTY"/>.
        /// Unlike <see cref="VariantClear"/>, this function does not interpret the current contents of the <see cref="VARIANTARG"/>.
        /// Use <see cref="VariantInit"/> to initialize new local variables of type <see cref="VARIANTARG"/> (or <see cref="VARIANT"/>).
        /// </remarks>
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "VariantInit", ExactSpelling = true, SetLastError = true)]
        public static extern void VariantInit([In] in VARIANTARG pvarg);

        /// <summary>
        /// <para>
        /// Converts the variant representation of a date and time to MS-DOS date and time values.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/oleauto/nf-oleauto-varianttimetodosdatetime"/>
        /// </para>
        /// </summary>
        /// <param name="vtime">
        /// The variant time to convert.
        /// </param>
        /// <param name="pwDosDate">
        /// Receives the converted MS-DOS date.
        /// </param>
        /// <param name="pwDosTime">
        /// Receives the converted MS-DOS time
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> on success and <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// A variant time is stored as an 8-byte real value (double), representing a date between January 1, 100 and December 31, 9999, inclusive.
        /// The value 2.0 represents January 1, 1900; 3.0 represents January 2, 1900, and so on.
        /// Adding 1 to the value increments the date by a day.
        /// The fractional part of the value represents the time of day.
        /// Therefore, 2.5 represents noon on January 1, 1900; 3.25 represents 6:00 A.M. on January 2, 1900, and so on.
        /// Negative numbers represent the dates prior to December 30, 1899.
        /// For a description of the MS-DOS date and time formats, see <see cref="DosDateTimeToVariantTime"/>.
        /// The <see cref="VariantTimeToDosDateTime"/> function will accept invalid dates and try to fix them when resolving to a <see cref="VARIANT"/> time. 
        /// For example, an invalid date such as 2/29/2001 will resolve to 3/1/2001.
        /// Only days are fixed, so invalid month values result in an error being returned.
        /// Days are checked to be between 1 and 31. Negative days and days greater than 31 results in an error.
        /// A day less than 31 but greater than the maximum day in that month has the day promoted to the appropriate day of the next month.
        /// A day equal to zero resolves as the last day of the previous month.
        /// For example, an invalid dates such as 2/0/2001 will resolve to 1/31/2001.
        /// </remarks>
        [DllImport("OleAut32.dll", CharSet = CharSet.Unicode, EntryPoint = "VariantTimeToDosDateTime", ExactSpelling = true, SetLastError = true)]
        public static extern INT VariantTimeToDosDateTime([In] DOUBLE vtime, [Out] out USHORT pwDosDate, [Out] out USHORT pwDosTime);
    }
}
