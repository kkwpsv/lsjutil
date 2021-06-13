using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Adds a character string to the local atom table and returns a unique value (an atom) identifying the string.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-addatomw"/>
        /// </para>
        /// </summary>
        /// <param name="lpString">
        /// The null-terminated string to be added.
        /// The string can have a maximum size of 255 bytes. Strings differing only in case are considered identical.
        /// The case of the first string added is preserved and returned by the <see cref="GetAtomName"/> function.
        /// Alternatively, you can use an integer atom that has been converted using the <see cref="MAKEINTATOM"/> macro.
        /// See the Remarks for more information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the newly created atom.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="AddAtom"/> function stores no more than one copy of a given string in the atom table.
        /// If the string is already in the table, the function returns the existing atom and, in the case of a string atom,
        /// increments the string's reference count.
        /// If <paramref name="lpString"/> has the form "#1234", AddAtom returns an integer atom whose value is the 16-bit representation of the decimal number
        /// specified in the string (0x04D2, in this example).
        /// If the decimal value specified is 0x0000 or is greater than or equal to 0xC000, the return value is zero, indicating an error.
        /// If <paramref name="lpString"/> was created by the <see cref="MAKEINTATOM"/> macro, the low-order word must be in the range 0x0001 through 0xBFFF.
        /// If the low-order word is not in this range, the function fails.
        /// If <paramref name="lpString"/> has any other form, <see cref="AddAtom"/> returns a string atom.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAtomW", ExactSpelling = true, SetLastError = true)]
        public static extern ATOM AddAtom([MarshalAs(UnmanagedType.LPWStr)][In] string lpString);

        /// <summary>
        /// <para>
        /// Decrements the reference count of a local string atom.
        /// If the atom's reference count is reduced to zero, <see cref="DeleteAtom"/> removes the string associated with the atom from the local atom table.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-deleteatom"/>
        /// </para>
        /// </summary>
        /// <param name="nAtom">
        /// The atom to be deleted.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is zero.
        /// If the function fails, the return value is the <paramref name="nAtom"/> parameter.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A string atom's reference count specifies the number of times the atom has been added to the atom table.
        /// The <see cref="AddAtom"/> function increments the count on each call.
        /// The <see cref="DeleteAtom"/> function decrements the count on each call but removes the string only if the atom's reference count is zero.
        /// Each call to <see cref="AddAtom"/> should have a corresponding call to <see cref="DeleteAtom"/>.
        /// Do not call <see cref="DeleteAtom"/> more times than you call <see cref="AddAtom"/>, or you may delete the atom while other clients are using it.
        /// The <see cref="DeleteAtom"/> function has no effect on an integer atom (an atom whose value is in the range 0x0001 to 0xBFFF).
        /// The function always returns zero for an integer atom.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteAtom", ExactSpelling = true, SetLastError = true)]
        public static extern ATOM DeleteAtom([In] ATOM nAtom);

        /// <summary>
        /// <para>
        /// Searches the local atom table for the specified character string and retrieves the atom associated with that string.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findatomw"/>
        /// </para>
        /// </summary>
        /// <param name="lpString">
        /// The character string for which to search.
        /// Alternatively, you can use an integer atom that has been converted using the <see cref="MAKEINTATOM"/> macro.
        /// See Remarks for more information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the atom associated with the given string.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Even though the system preserves the case of a string in an atom table,
        /// the search performed by the <see cref="FindAtom"/> function is not case sensitive.
        /// If <paramref name="lpString"/> was created by the <see cref="MAKEINTATOM"/> macro, the low-order word must be in the range 0x0001 through 0xBFFF.
        /// If the low-order word is not in this range, the function fails.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindAtomW", ExactSpelling = true, SetLastError = true)]
        public static extern ATOM FindAtom([MarshalAs(UnmanagedType.LPWStr)][In] string lpString);

        /// <summary>
        /// <para>
        /// Retrieves a copy of the character string associated with the specified local atom.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-getatomnamew"/>
        /// </para>
        /// </summary>
        /// <param name="nAtom">
        /// The local atom that identifies the character string to be retrieved.
        /// </param>
        /// <param name="lpBuffer">
        /// The character string.
        /// </param>
        /// <param name="nSize">
        /// The size, in characters, of the buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string copied to the buffer, in characters,
        /// not including the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The string returned for an integer atom (an atom whose value is in the range 0x0001 to 0xBFFF) is a null-terminated string
        /// in which the first character is a pound sign (#) and the remaining characters represent the unsigned integer atom value.
        /// Security Considerations
        /// Using this function incorrectly might compromise the security of your program.
        /// Incorrect use of this function includes not correctly specifying the size of the <paramref name="lpBuffer"/> parameter.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetAtomNameW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetAtomName([In] ATOM nAtom, [In] IntPtr lpBuffer, [In] int nSize);


        /// <summary>
        /// <para>
        /// Adds a character string to the global atom table and returns a unique value (an atom) identifying the string.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globaladdatomw"/>
        /// </para>
        /// </summary>
        /// <param name="lpString">
        /// The null-terminated string to be added.
        /// The string can have a maximum size of 255 bytes.
        /// Strings that differ only in case are considered identical.
        /// The case of the first string of this name added to the table is preserved and returned by the <see cref="GlobalGetAtomName"/> function.
        /// Alternatively, you can use an integer atom that has been converted using the <see cref="MAKEINTATOM"/> macro.
        /// See the Remarks for more information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the newly created atom.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the string already exists in the global atom table,
        /// the atom for the existing string is returned and the atom's reference count is incremented.
        /// The string associated with the atom is not deleted from memory until its reference count is zero.
        /// For more information, see the <see cref="GlobalDeleteAtom"/> function.
        /// Global atoms are not deleted automatically when the application terminates.
        /// For every call to the <see cref="GlobalAddAtom"/> function, there must be a corresponding call to the <see cref="GlobalDeleteAtom"/> function.
        /// If the <paramref name="lpString"/> parameter has the form "#1234",
        /// <see cref="GlobalAddAtom"/> returns an integer atom whose value is the 16-bit representation of the decimal number
        /// specified in the string (0x04D2, in this example).
        /// If the decimal value specified is 0x0000 or is greater than or equal to 0xC000, the return value is zero, indicating an error.
        /// If <paramref name="lpString"/> was created by the <see cref="MAKEINTATOM"/> macro,
        /// the low-order word must be in the range 0x0001 through 0xBFFF.
        /// If the low-order word is not in this range, the function fails.
        /// If <paramref name="lpString"/> has any other form, <see cref="GlobalAddAtom"/> returns a string atom.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalAddAtom", ExactSpelling = true, SetLastError = true)]
        public static extern ATOM GlobalAddAtom([MarshalAs(UnmanagedType.LPWStr)][In] string lpString);

        /// <summary>
        /// <para>
        /// Decrements the reference count of a global string atom.
        /// If the atom's reference count reaches zero, <see cref="GlobalDeleteAtom"/> removes the string associated with the atom
        /// from the global atom table.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globaldeleteatom"/>
        /// </para>
        /// </summary>
        /// <param name="nAtom">
        /// The atom and character string to be deleted.
        /// </param>
        /// <returns>
        /// The function always returns (ATOM) 0.
        /// To determine whether the function has failed,
        /// call <see cref="SetLastError"/> with <see cref="ERROR_SUCCESS"/> before calling <see cref="GlobalDeleteAtom"/>,
        /// then call <see cref="GetLastError"/>.
        /// If the last error code is still <see cref="ERROR_SUCCESS"/>, <see cref="GlobalDeleteAtom"/> has succeeded.
        /// </returns>
        /// <remarks>
        /// A string atom's reference count specifies the number of times the string has been added to the atom table.
        /// The <see cref="GlobalAddAtom"/> function increments the reference count of a string
        /// that already exists in the global atom table each time it is called.
        /// Each call to <see cref="GlobalAddAtom"/> should have a corresponding call to <see cref="GlobalDeleteAtom"/>.
        /// Do not call <see cref="GlobalDeleteAtom"/> more times than you call <see cref="GlobalAddAtom"/>,
        /// or you may delete the atom while other clients are using it.
        /// Applications using Dynamic Data Exchange (DDE) should follow the rules on global atom management to prevent leaks and premature deletion.
        /// <see cref="GlobalDeleteAtom"/> has no effect on an integer atom (an atom whose value is in the range 0x0001 to 0xBFFF).
        /// The function always returns zero for an integer atom.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalDeleteAtom", ExactSpelling = true, SetLastError = true)]
        public static extern ATOM GlobalDeleteAtom([In] ATOM nAtom);

        /// <summary>
        /// <para>
        /// Searches the global atom table for the specified character string and retrieves the global atom associated with that string.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globalfindatomw"/>
        /// </para>
        /// </summary>
        /// <param name="lpString">
        /// The null-terminated character string for which to search.
        /// Alternatively, you can use an integer atom that has been converted using the <see cref="MAKEINTATOM"/> macro.
        /// See the Remarks for more information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the global atom associated with the given string.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Even though the system preserves the case of a string in an atom table as it was originally entered,
        /// the search performed by <see cref="GlobalFindAtom"/> is not case sensitive.
        /// If <paramref name="lpString"/> was created by the <see cref="MAKEINTATOM"/> macro, the low-order word must be in the range 0x0001 through 0xBFFF.
        /// If the low-order word is not in this range, the function fails.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalFindAtomW", ExactSpelling = true, SetLastError = true)]
        public static extern ATOM GlobalFindAtom([MarshalAs(UnmanagedType.LPWStr)][In] string lpString);

        /// <summary>
        /// <para>
        /// Retrieves a copy of the character string associated with the specified global atom.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-globalgetatomnamew"/>
        /// </para>
        /// </summary>
        /// <param name="nAtom">
        /// The global atom associated with the character string to be retrieved.
        /// </param>
        /// <param name="lpBuffer">
        /// The buffer for the character string.
        /// </param>
        /// <param name="nSize">
        /// The size, in characters, of the buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string copied to the buffer, in characters,
        /// not including the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The string returned for an integer atom (an atom whose value is in the range 0x0001 to 0xBFFF) is a null-terminated string
        /// in which the first character is a pound sign (#) and the remaining characters represent the unsigned integer atom value.
        /// Security Considerations
        /// Using this function incorrectly might compromise the security of your program.
        /// Incorrect use of this function includes not correctly specifying the size of the <paramref name="lpBuffer"/> parameter.
        /// Also, note that a global atom is accessible by anyone; thus, privacy and the integrity of its contents is not assured.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GlobalGetAtomNameW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GlobalGetAtomName([In] ATOM nAtom, [In] IntPtr lpBuffer, [In] int nSize);

        /// <summary>
        /// <para>
        /// Initializes the local atom table and sets the number of hash buckets to the specified size.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-initatomtable"/>
        /// </para>
        /// </summary>
        /// <param name="nSize">
        /// The number of hash buckets to use for the atom table.
        /// If this parameter is zero, the default number of hash buckets are created.
        /// To achieve better performance, specify a prime number in <paramref name="nSize"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// </returns>
        /// <remarks>
        /// An application need not use this function to use a local atom table.
        /// The default number of hash buckets used is 37. 
        /// If an application does use <see cref="InitAtomTable"/>, however, it should call the function before any other atom-management function.
        /// If an application uses a large number of local atoms,
        /// it can reduce the time required to add an atom to the local atom table or to find an atom in the table by increasing the size of the table.
        /// However, this increases the amount of memory required to maintain the table.
        /// The number of buckets in the global atom table cannot be changed.
        /// If the atom table has already been initialized, either explicitly by a prior call to <see cref="InitAtomTable"/>,
        /// or implicitly by the use of any atom-management function, <see cref="InitAtomTable"/> returns success without changing the number of hash buckets.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitAtomTable", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InitAtomTable([In] DWORD nSize);

        /// <summary>
        /// <para>
        /// Converts the specified atom into a string, so it can be passed to functions which accept either atoms or strings.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-makeintatom"/>
        /// </para>
        /// </summary>
        /// <param name="i">
        /// The numeric value to be made into an integer atom. This parameter can be either an integer atom or a string atom.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Although the return value of the <see cref="MAKEINTATOM"/> macro is cast as an LPTSTR value,
        /// it cannot be used as a string pointer except when it is passed to atom-management functions that require an LPTSTR argument.
        /// </remarks>
        public static IntPtr MAKEINTATOM(int i) => new IntPtr(i);
    }
}
