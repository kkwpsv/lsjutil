using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides a method for enumerating a collection of variants, including heterogeneous collections of objects and intrinsic types.
    /// Callers of this interface do not need to know the specific type (or types) of the elements in the collection.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-ienumvariant"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To see how to implement a collection of objects using <see cref="IEnumVARIANT"/>, refer to the file Enumvar.cpp in the Lines sample code.
    /// </remarks>
    public unsafe struct IEnumVARIANT
    {
        IntPtr* _vTable;
    }
}
