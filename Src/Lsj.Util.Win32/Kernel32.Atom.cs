using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
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
