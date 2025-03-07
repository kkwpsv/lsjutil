using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that simplify the process of retrieving information stored in the registry in association with defining a file type or protocol and associating it with an application.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlwapi/nn-shlwapi-iqueryassociations"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// When to Implement
    /// </para>
    /// <para>
    /// This interface is exposed by the Shell or by namespace extensions to simplify handling file and protocol associations.
    /// You should not implement this interface.
    /// </para>
    /// <para>
    /// When to Use
    /// </para>
    /// <para>
    /// Use this interface if you need information from the registry related to file or protocol associations.
    /// For example, you can use this interface to retrieve information associated with a file name extension such as the command string of one of its verbs.
    /// </para>
    /// <para>
    /// A complete registry path or HKEY value is not required.
    /// Instead, you can retrieve information based on criteria such as the file name extension or executable name.
    /// For a discussion of file associations, see File Types.
    /// </para>
    /// <para>
    /// You can also retrieve an application's name using this interface. Use method <see cref="IQueryAssociations.GetString"/>.
    /// Set the str parameter to <see cref="ASSOCSTR_FRIENDLYAPPNAME"/>.
    /// </para>
    /// <para>
    /// To use this interface, you must first retrieve a pointer to it.
    /// Typically, you retrieve an <see cref="IUnknown.QueryInterface"/> pointer by calling a Shell object's <see cref="IShellFolder.GetUIObjectOf"/> method.
    /// You can also retrieve an interface pointer by calling <see cref="AssocCreate"/> (set clsid to <see cref="CLSID_QueryAssociations"/>).
    /// Initialize the interface with <see cref="IQueryAssociations.Init"/>.
    /// This method sets the root key that will be used when you call any of the remaining three methods to retrieve information from the registry.
    /// They will look only below the root key. You must release the interface when you no longer need it.
    /// </para>
    /// <para>
    /// The <see cref="IQueryAssociations"/> interface is useful if you need to repeatedly query the registry for information.
    /// Once the interface is initialized, the overhead of calling the various methods is relatively small.
    /// There are also several related functions, listed in the See Also section,
    /// that allow you to retrieve the same information from the registry with a single function call.
    /// While they are simpler to use, they cause the overhead of creating and initializing <see cref="IQueryAssociations"/> each time they are called.
    /// Because of this, they are best suited for single use.
    /// </para>
    /// </remarks>
    public unsafe struct IQueryAssociations
    {
        IntPtr* _vTable;
    }
}
