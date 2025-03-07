using System;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods to copy, move, rename, create, and delete Shell items as well as methods to provide progress and error dialogs.
    /// This interface replaces the <see cref="SHFileOperation"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifileoperation"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A Shell item can be any object in the namespace, including file system objects such as files and folders, but also virtual objects.
    /// In the <see cref="IFileOperation"/> method topics, the term "item" is used to refer generically to any namespace object.
    /// </para>
    /// <para>
    /// <see cref="IFileOperation"/> offers many advantages over the older <see cref="SHFileOperation"/> function.
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Use of <see cref="IShellItem"/> to identify items rather than string paths.
    /// <see cref="SHFileOperation"/> required path and destination strings to terminate in two null characters rather than the standard single null character,
    /// which itself was used to delimit multiple paths in the string.
    /// Identifying an item through <see cref="IShellItem"/> is more robust and less prone to programming errors.
    /// It also allows you to access non-file system items such as virtual folders.
    /// Multiple items in one operation can be passed as an <see cref="IShellItemArray"/>, <see cref="IDataObject"/>,
    /// or a collection accessed through <see cref="IEnumShellItems"/> rather than as a string.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// More accurate error reporting through HRESULT values in conjunction with an API such as <see cref="FormatMessage"/>.
    /// Return codes from <see cref="SHFileOperation"/> could be misleading or inaccurate.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Extensibility. As a Component Object Model (COM) interface,
    /// <see cref="IFileOperation"/> can have its capabilities extended by a third-party to meet their specific needs,
    /// although this should be a very rare case.
    /// Windows provides a default implementation of <see cref="IFileOperation"/> that should meet the needs of most users.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Better progress feedback. Detailed operation progress,
    /// including notifications when specific operations begin and end on individual items as well as the overall progress,
    /// can be received during the operation.
    /// While <see cref="SHFileOperation"/> did provide progress UI, it was not as detailed.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// More functionality.
    /// In addition to the copy, delete, move, and rename functionality provided by <see cref="SHFileOperation"/>,
    /// <see cref="IFileOperation"/> allows you to apply property values and create new items.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// More control over the operation.
    /// In addition to the operation flags recognized by <see cref="SHFileOperation"/>,
    /// new flags are recognized in <see cref="IFileOperation.SetOperationFlags"/> that specify extended operation options.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Different operations can be performed in one call.
    /// For instance, you can move a set of files, copy others, rename a folder, and apply properties to yet another item all in one operation.
    /// <see cref="SHFileOperation"/> could only do one operation—copy, move, rename, or delete—at a time.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// To accomplish a file operation using this interface, a sequence of calls must be made.
    /// </para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// Optional. Set up the event sink for progress status and error notifications through <see cref="Advise"/> and <see cref="Unadvise"/>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Set the operation state using the following as needed:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="SetOperationFlags"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="SetOwnerWindow"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="SetProgressDialog"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="SetProgressMessage"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="SetProperties"/>
    /// </description>
    /// </item>
    /// </list>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Specify which operations to perform on which items using the following as needed.
    /// /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="ApplyPropertiesToItem"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ApplyPropertiesToItems"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="CopyItem"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="CopyItems"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DeleteItem"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DeleteItems"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="MoveItem"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="MoveItems"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="NewItem"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="RenameItem"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="RenameItems"/>
    /// </description>
    /// </item>
    /// </list>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Execute the operations by calling <see cref="PerformOperations"/>
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// <see cref="IFileOperation"/> can only be applied in a single-threaded apartment (STA) situation.
    /// It cannot be used for a multithreaded apartment (MTA) situation.
    /// For MTA, you still must use <see cref="SHFileOperation"/>.
    /// </para>
    /// <para>
    /// A full sample that demonstrates the extension of <see cref="IFileOperation"/> is included in the Windows Software Development Kit (SDK).
    /// In a default installation, it can be found at %ProgramFiles%\Microsoft SDKs\Windows\v6.0\Samples\WinUI\Shell\AppPlatform\FileOperations.
    /// </para>
    /// </remarks>
    public unsafe struct IFileOperation
    {
        IntPtr* _vTable;
    }
}
