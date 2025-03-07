using System;
using static Lsj.Util.Win32.Enums.BROWSEINFOFlags;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exported by a host to allow clients to specify how to filter a Shell folder enumeration.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifolderfiltersite"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The most common use of this interface is when your application calls <see cref="SHBrowseForFolder"/>.
    /// When you call this function, you become a client of the folder browser object.
    /// That object communicates with you by sending messages to a callback function, <see cref="BrowseCallbackProc"/>.
    /// The <see cref="BFFM_IUNKNOWN"/> message contains a pointer to the folder browser's <see cref="IUnknown"/> interface.
    /// To filter folder enumeration:
    /// </para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// Use the <see cref="IUnknown"/> pointer to call the folder browser's <see cref="IUnknown.QueryInterface"/> method,
    /// and request a pointer to the <see cref="IFolderFilterSite"/> interface.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call <see cref="IFolderFilterSite.SetFilter"/>, and pass the folder browser a pointer
    /// to your <see cref="IFolderFilter"/> (<see cref="IUnknown"/> or IFilterFolder?) interface.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The folder browser will then query the two methods of the <see cref="IFolderFilterSite"/> interface to determine how to filter the enumeration.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    public unsafe struct IFolderFilterSite
    {
        IntPtr* _vTable;
    }
}
