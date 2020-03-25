using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Adds a character string to the local atom table and returns a unique value (an atom) identifying the string.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-addatomw
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "AddAtomW", SetLastError = true)]
        public static extern ATOM AddAtom([MarshalAs(UnmanagedType.LPWStr)][In]string lpString);


        /// <summary>
        /// <para>
        /// Initializes the local atom table and sets the number of hash buckets to the specified size.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-initatomtable
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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitAtomTable", SetLastError = true)]
        public static extern BOOL InitAtomTable([In]DWORD nSize);
    }
}
