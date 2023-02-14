using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.KF_CATEGORY;
using static Lsj.Util.Win32.Enums.KNOWN_FOLDER_FLAG;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that allow an application to retrieve information about a known folder's category, type, GUID,
    /// pointer to an item identifier list (PIDL) value, redirection capabilities, and definition.
    /// It provides a method for the retrieval of a known folder's <see cref="IShellItem"/> object.
    /// It also provides methods to get or set the path of the known folder.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iknownfolder"/>
    /// </para>
    /// </summary>
    public unsafe struct IKnownFolder
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves the location of a known folder in the Shell namespace in the form of a Shell item (<see cref="IShellItem"/> or derived interface).
        /// </summary>
        /// <param name="dwFlags">
        /// Flags that specify special retrieval options.
        /// This value can be 0; otherwise, one or more of the <see cref="KNOWN_FOLDER_FLAG"/> values.
        /// </param>
        /// <param name="riid">
        /// A reference to the IID of the requested interface.
        /// </param>
        /// <param name="ppv">
        /// When this method returns, contains the interface pointer requested in <paramref name="riid"/>.
        /// This is typically <see cref="IShellItem"/> or <see cref="IShellItem2"/>.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetShellItem([In] KNOWN_FOLDER_FLAG dwFlags, [In] in IID riid, [Out] out IntPtr ppv)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, KNOWN_FOLDER_FLAG, in IID, out IntPtr, HRESULT>)_vTable[5])(thisPtr, dwFlags, riid, out ppv);
            }
        }

        /// <summary>
        /// <para>
        /// Retrieves the path of a known folder as a string.
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Flags that specify special retrieval options.
        /// This value can be 0; otherwise, one or more of the <see cref="KNOWN_FOLDER_FLAG"/> values.
        /// </param>
        /// <param name="ppszPath">
        /// When this method returns, contains the address of a pointer to a null-terminated buffer that contains the path.
        /// The calling application is responsible for calling <see cref="CoTaskMemFree"/> to free this resource when it is no longer needed.
        /// </param>
        /// <returns></returns>
        public HRESULT GetPath([In] KNOWN_FOLDER_FLAG dwFlags, [Out] out IntPtr ppszPath)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, KNOWN_FOLDER_FLAG, out IntPtr, HRESULT>)_vTable[6])(thisPtr, dwFlags, out ppszPath);
            }
        }

        /// <summary>
        /// <para>
        /// Assigns a new path to a known folder.
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// Either zero or the following value:
        /// <see cref="KF_FLAG_DONT_UNEXPAND"/>:
        /// Set the full path without environment strings.
        /// If this flag is not set, portions of the path at <paramref name="pszPath"/> may be represented by environment strings such as %USERPROFILE%.
        /// </param>
        /// <param name="pszPath">
        /// Pointer to the folder's new path.
        /// This is a null-terminated Unicode string of length <see cref="MAX_PATH"/>.
        /// This path cannot be of zero length.
        /// If this value is <see cref="NULL"/>, the <see cref="SetPath"/> sets the path to the default value.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method cannot be called on folders of type <see cref="KF_CATEGORY_FIXED"/> or <see cref="KF_CATEGORY_VIRTUAL"/>.
        /// To call this method on a folder of type <see cref="KF_CATEGORY_COMMON"/>, the calling application must be running with elevated privileges.
        /// This method is equivalent to <see cref="SHSetKnownFolderPath"/>.
        /// </remarks>
        public HRESULT SetPath([In] KNOWN_FOLDER_FLAG dwFlags, [In] LPCWSTR pszPath)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, KNOWN_FOLDER_FLAG, LPCWSTR, HRESULT>)_vTable[6])(thisPtr, dwFlags, pszPath);
            }
        }

        /// <summary>
        /// Retrieves the path of a known folder as a string.
        /// </summary>
        /// <param name="dwFlags">
        /// Flags that specify special retrieval options.
        /// This value can be 0; otherwise, one or more of the <see cref="KNOWN_FOLDER_FLAG"/> values.
        /// </param>
        /// <param name="ppidl">
        /// When this method returns, contains the address of a pointer to a null-terminated buffer that contains the path.
        /// The calling application is responsible for calling <see cref="CoTaskMemFree"/> to free this resource when it is no longer needed.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Equivalent to <see cref="SHGetKnownFolderPath"/>
        /// </remarks>
        public HRESULT GetIDList([In] KNOWN_FOLDER_FLAG dwFlags, [Out] out LPITEMIDLIST ppidl)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, KNOWN_FOLDER_FLAG, out LPITEMIDLIST, HRESULT>)_vTable[8])(thisPtr, dwFlags, out ppidl);
            }
        }
    }
}
