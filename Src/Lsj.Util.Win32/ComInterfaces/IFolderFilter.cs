using static Lsj.Util.Win32.Enums.BrowseForFolderDialogOptionFlags;
using static Lsj.Util.Win32.Enums.BrowseForFolderMessages;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposed by a client to specify how to filter the enumeration of a Shell folder by a server application.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifolderfilter"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface is most often used with <see cref="SHBrowseForFolder"/> to filter the contents of the tree view displayed in a folder selection dialog box.
    /// To use <see cref="IFolderFilter"/> with <see cref="SHBrowseForFolder"/>, the <see cref="BIF_NEWDIALOGSTYLE"/> flag must be set.
    /// </para>
    /// <para>
    /// When your application calls <see cref="SHBrowseForFolder"/>, you become a client of the folder browser object.
    /// The folder browser object communicates with you by sending messages to a callback function, <see cref="BrowseCallbackProc"/>.
    /// The <see cref="BFFM_IUNKNOWN"/> message handled by that callback function contains a pointer to the folder browser's <see cref="IUnknown"/> interface.
    /// To filter the display of a folder's contents, do the following:
    /// </para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// Use the folder browser's <see cref="IUnknown.QueryInterface"/> method to request a pointer to the <see cref="IFolderFilterSite"/> interface.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Call <see cref="IFolderFilterSite.SetFilter"/>, passing it a pointer to your <see cref="IFolderFilter"/> interface.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The folder browser then queries <see cref="IFolderFilter.GetEnumFlags"/> and <see cref="IFolderFilter.ShouldShow"/> to determine how to filter the enumeration.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    public unsafe struct IFolderFilter
    {
        nint* _vTable;
    }
}
