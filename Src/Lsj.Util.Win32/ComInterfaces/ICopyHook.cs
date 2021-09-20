using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DialogBoxCommandIDs;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes a method that creates a copy hook handler.
    /// A copy hook handler is a Shell extension that determines if a Shell folder or printer object can be moved, copied, renamed, or deleted.
    /// The Shell calls the <see cref="CopyCallback"/> method prior to performing one of these operations.
    /// </para>
    /// <para>
    /// <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/bb776049(v=vs.85)"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The copy hook handler, which is an OLE in-process server (a DLL), does not perform the task itself, but it does approve or disapprove the action.
    /// If the Shell receives approval from the copy hook handler, it performs the file system operation.
    /// Copy hook handlers are not informed about the success of an operation, so they cannot monitor actions taken on folder objects unless <see cref="FindFirstChangeNotification"/> is used.
    /// A folder object can have multiple copy hook handlers.
    /// For example, even if the Shell already has a copy hook handler registered for a particular folder object, you can still register one of your own.
    /// If two or more copy hook handlers are registered for an object, the Shell simply calls each of them before performing one of the specified file system operations.
    /// The Shell initializes <see cref="ICopyHook"/> directly, without using the <see cref="IShellExtInit"/> interface first.
    /// <see cref="CopyCallback"/> returns an int value that indicates whether the Shell should perform the operation.
    /// The Shell will call each copy hook handler registered for a folder object until all the handlers have been called or until one of them has returned a value other than IDYES.
    /// The handler returns <see cref="IDYES"/> to specify that the operation should be performed,
    /// or <see cref="IDNO"/> or <see cref="IDCANCEL"/> to specify that the operation should be discontinued.
    /// Implement a copy hook handler when you want to be able to control when, or if, these file system operations are performed on a given object.
    /// You might want to use a copy hook handler on shared folders, for example.
    /// You do not call this Shell extension directly. 
    /// <see cref="CopyCallback"/> is called by the Shell prior to moving, copying, deleting, or renaming a Shell folder object.
    /// </remarks>
    public unsafe struct ICopyHook
    {
        IntPtr* _vTable;

        /// <summary>
        /// Determines whether the Shell will be allowed to move, copy, delete, or rename a folder or printer object.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window that the copy hook handler should use as the parent for any user interface elements the handler may need to display.
        /// If <see cref="FOF_SILENT"/> is specified in <paramref name="wFunc"/>, the method should ignore this parameter.
        /// </param>
        /// <param name="wFunc">
        /// The operation to perform.
        /// This parameter can be one of the values listed under the <see cref="SHFILEOPSTRUCT.wFunc"/> member of the <see cref="SHFILEOPSTRUCT"/> structure.
        /// </param>
        /// <param name="wFlags">
        /// The flags that control the operation.
        /// This parameter can be one or more of the values listed under the fFlags member of the <see cref="SHFILEOPSTRUCT"/> structure.
        /// For printer copy hooks, this value is one of the following values defined in Shellapi.h.
        /// <see cref="PO_DELETE"/>
        /// A printer is being deleted.
        /// <paramref name="pszSrcFile"/> points to the full path to the specified printer.
        /// <see cref="PO_RENAME"/>
        /// A printer is being renamed.
        /// The <paramref name="pszSrcFile"/> parameter points to the printer's new name. The <paramref name="pszDestFile"/> parameter points to the old name.
        /// <see cref="PO_PORTCHANGE"/>
        /// Not supported.
        /// <see cref="PO_REN_PORT"/>
        /// Not supported. Do not use.
        /// </param>
        /// <param name="pszSrcFile">
        /// A pointer to a string that contains the name of the source folder.
        /// </param>
        /// <param name="dwSrcAttribs">
        /// The attributes of the source folder.
        /// This parameter can be a combination of any of the file attribute flags (FILE_ATTRIBUTE_*) defined in the Windows header files.
        /// See File Attribute Constants.
        /// </param>
        /// <param name="pszDestFile">
        /// A pointer to a string that contains the name of the destination folder.
        /// </param>
        /// <param name="dwDestAttribs">
        /// The attributes of the destination folder.
        /// This parameter can be a combination of any of the file attribute flags (FILE_ATTRIBUTE_*) defined in the Windows header files.
        /// See File Attribute Constants.
        /// </param>
        /// <returns>
        /// Returns an integer value that indicates whether the Shell should perform the operation.
        /// One of the following:
        /// <see cref="IDYES"/>:
        /// Allows the operation.
        /// <see cref="IDNO"/>:
        /// Prevents the operation on this folder but continues with any other operations that have been approved (for example, a batch copy operation).
        /// <see cref="IDCANCEL"/>:
        /// Prevents the current operation and cancels any pending operations.
        /// </returns>
        /// <remarks>
        /// The Shell calls each copy hook handler registered for a folder or printer object until all the handlers have been called, 
        /// or until one of them returns <see cref="IDNO"/> or <see cref="IDCANCEL"/>.
        /// Copy hook handlers for folders are registered under the following key.
        ///  HKEY_CLASSES_ROOT\Directory\Shellex\CopyHookHandlers\your_copyhook
        ///  (Default) = {copyhook CLSID value}
        /// Copy hook handlers for printers are registered under the following key.
        /// FakePre-f29856611b71466b9961cc96d1f8ac70-c0c87b08f3c14e4f95a64cce2bfe0232
        /// When this method is called, the Shell initializes the <see cref="ICopyHook"/> interface directly without using an <see cref="IShellExtInit"/> interface first.
        /// </remarks>
        public UINT CopyCallback([In] HWND hwnd, [In] UINT wFunc, [In] UINT wFlags, [In] LPCWSTR pszSrcFile, [In] FileAttributes dwSrcAttribs,
                [In] LPCWSTR pszDestFile, [In] FileAttributes dwDestAttribs)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, UINT, UINT, LPCWSTR, FileAttributes, LPCWSTR, FileAttributes, UINT>)_vTable[3])
                    (thisPtr, hwnd, wFunc, wFlags, pszSrcFile, dwSrcAttribs, pszDestFile, dwDestAttribs);
            }
        }
    }
}
