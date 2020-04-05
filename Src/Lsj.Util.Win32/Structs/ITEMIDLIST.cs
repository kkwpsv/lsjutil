using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains a list of item identifiers.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shtypes/ns-shtypes-itemidlist
    /// </para>
    /// </summary>
    /// <remarks>
    /// A pointer to this structure, called a PIDL, is used to identify objects in the Shell namespace.
    /// For more information about pointers to item identifier lists (PIDLs) and item identifiers, see Introduction to the Shell Namespace.
    /// ITEMIDLIST Strict Types
    /// As of Windows Vista, several forms of ITEMIDLIST are available as data types. The three main types are:
    /// IDLIST_ABSOLUTE: Fully qualified <see cref="ITEMIDLIST"/> relative to the root of the namespace. It may be multi-level.
    /// IDLIST_RELATIVE: <see cref="ITEMIDLIST"/> relative to a parent folder. It may be multi-level.
    /// ITEMID_CHILD: Single-level <see cref="ITEMIDLIST"/> relative to a parent folder. It contains exactly one <see cref="SHITEMID"/> structure.
    /// These types are used if you compile your code with the symbol <see cref="STRICT_TYPED_ITEMIDS"/> before you include the Shell header files,
    /// as shown in the following example code.
    /// <code>
    /// #define STRICT_TYPED_ITEMIDS    // Better type safety for IDLists
    /// #include &lt;shlobj.h&gt;       // Typical Shell header file
    /// </code>
    /// The meaning of each of these types can be altered with one or more of the following modifiers:
    /// P: The type is a pointer.
    /// C: The type is constant.
    /// U: The type is unaligned. It aligns to a <see cref="DWORD"/> boundary in 32-bit architectures and a <see cref="QWORD"/> boundary in 64-bit architectures.
    /// Some examples of these modified types are:
    /// PIDLIST_ABSOLUTE:
    /// The <see cref="ITEMIDLIST"/> is absolute and has been allocated, as indicated by its being non-constant.
    /// This means that it needs to be deallocated with ILFree when it is no longer needed. Because it is a direct pointer to allocated memory, it is aligned.
    /// PCIDLIST_ABSOLUTE:
    /// The <see cref="ITEMIDLIST"/> is absolute and constant.
    /// This is typically used when you are passed an absolute <see cref="ITEMIDLIST"/> as a parameter but do not own it, and so are not allowed to change it.
    /// PCUIDLIST_ABSOLUTE:
    /// The <see cref="ITEMIDLIST"/> is absolute, constant and unaligned. This is rarely used.
    /// Absolute <see cref="ITEMIDLIST"/> are typically allocated in memory aligned to a <see cref="DWORD"/> boundary in 32-bit architectures
    /// and to a <see cref="QWORD"/> boundary in 64-bit architectures.
    /// An absolute <see cref="ITEMIDLIST"/> would be unaligned only if it has been byte-packed along with other data, such as in a serialization format.
    /// PITEMID_CHILD:
    /// The <see cref="ITEMIDLIST"/> is an allocated child <see cref="ITEMIDLIST"/> relative to a parent folder,
    /// such as a result of <see cref="IEnumIDList.Next"/>.
    /// It contains exactly one <see cref="SHITEMID"/> structure.
    /// PCUITEMID_CHILD:
    /// The child <see cref="ITEMIDLIST"/> is relative, constant, and unaligned.
    /// This often occurs when you get a pointer to part of an existing PIDL.
    /// For example, if you have an absolute PIDL and call <see cref="ILFindLastID"/>,
    /// it returns the pointer to the last child <see cref="SHITEMID"/> in the list.
    /// It is unaligned because the byte-packed PIDL does not ensure that its individual <see cref="SHITEMID"/> structures fall on byte boundaries.
    /// References to child PIDLs such as these are always constant because the memory is owned by the absolute PIDL.
    /// PCITEMID_CHILD:
    /// The child <see cref="ITEMIDLIST"/> is constant and aligned. This is rarely used because as a child PIDL, it is usually a part of a larger PIDL,
    /// and therefore not aligned on byte boundaries.
    /// PUITEMID_CHILD:
    /// The child <see cref="ITEMIDLIST"/> is unaligned.
    /// This is rarely used because memory for this <see cref="ITEMIDLIST"/> is owned by the parent PIDL, which is absolute.
    /// This means that modifications can be made only to the parent PIDL, and so the child PIDL would need to be constant.
    /// This list is not exhaustive. Other types can also exist.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ITEMIDLIST
    {
        /// <summary>
        /// A list of item identifiers.
        /// </summary>
        public SHITEMID mkid;
    }
}
