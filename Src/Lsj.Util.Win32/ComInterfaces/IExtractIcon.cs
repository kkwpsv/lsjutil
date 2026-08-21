using System;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that allow a client to retrieve the icon that is associated with one of the objects in a folder.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nn-shlobj_core-iextracticonw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// There are two ways to retrieve an object's icon. The simplest way is to call <see cref="SHGetFileInfo"/>.
    /// However, this approach is inflexible and may be slow.
    /// A more flexible and efficient way to retrieve an item's icon is to use <see cref="IExtractIcon"/>.
    /// The Shell uses <see cref="IExtractIcon"/> to retrieve icons when it displays the contents of a folder.
    /// To use <see cref="IExtractIcon"/> to retrieve an object's icon, do the following:
    /// </para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// Get a pointer to the <see cref="IShellFolder"/> interface of the folder that contains the object.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call <see cref="IShellFolder.GetUIObjectOf"/> with the pointer to an item identifier list (PIDL) of the object
    /// and the interface ID of <see cref="IExtractIcon"/> (<see cref="IID_IExtractIcon"/>).
    /// The folder creates an object to handle the icon extraction, and returns the object's <see cref="IExtractIcon"/> interface pointer.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call <see cref="IExtractIcon.GetIconLocation"/> to retrieve the icon's location.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call <see cref="IExtractIcon.Extract"/> to retrieve the icon's handle.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// It may also be possible to extract icons asynchronously on a background thread.
    /// This approach is useful when extraction is a time-consuming operation.
    /// For details, see <see cref="IExtractIcon.GetIconLocation"/>.
    /// </para>
    /// <para>
    /// Namespace extensions implement <see cref="IExtractIcon"/> to provide icons for their objects.
    /// A client obtains an <see cref="IExtractIcon"/> interface pointer for an object in a folder by calling the folder's <see cref="IShellFolder.GetUIObjectOf"/> method.
    /// The <see cref="IShellFolder.GetUIObjectOf"/> implementation must create an object to handle the icon extraction
    /// and return a pointer to the object's <see cref="IExtractIcon"/> interface.
    /// </para>
    /// <para>
    /// Icon handlers also implement <see cref="IExtractIcon"/>.
    /// An icon handler is a type of Shell extension handler that allows you to dynamically assign icons to the members of a file type.
    /// </para>
    /// <para>
    /// Call this interface if your application needs a more flexible way to retrieve an object's icon than <see cref="SHGetFileInfo"/>.
    /// </para>
    /// </remarks>
    public unsafe struct IExtractIcon
    {
        nint* _vTable;
    }
}
