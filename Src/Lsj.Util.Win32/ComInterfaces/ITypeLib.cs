using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a type library, the data that describes a set of objects.
    /// A type library can be a stand-alone binary file (.TLB), a resource in a dynamic link library or executable file (.DLL, .OLB, or .EXE).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-itypelib"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="ITypeLib"/> interface provides methods for accessing a library of type descriptions.
    /// This interface supports the following:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Generalized containment for type information. <see cref="ITypeLib"/> allows iteration over the type descriptions contained in the library.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Global functions and data.
    /// A type library can contain descriptions of a set of modules (.DLLs) that exports data and functions.
    /// The type library supports compiling references to the exported data and functions.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// General information, including a user-readable name for the library and help for the library as a whole.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    public unsafe struct ITypeLib
    {
        nint* _vTable;
    }
}
