using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.CLSIDs;
using static Lsj.Util.Win32.Enums.SFGAOF;
using static Lsj.Util.Win32.GUIDs.BHIDs;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that retrieve information about a Shell item.
    /// <see cref="IShellItem"/> and <see cref="IShellItem2"/> are the preferred representations of items in any new code.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellitem"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// When to Implement
    /// Third parties do not implement this interface; only use the implementation provided with the system.
    /// </remarks>
    public unsafe struct IShellItem
    {
        IntPtr* _vTable;

        /// <summary>
        /// Binds to a handler for an item as specified by the handler ID value (BHID).
        /// </summary>
        /// <param name="pbc">
        /// A pointer to an <see cref="IBindCtx"/> interface on a bind context object.
        /// Used to pass optional parameters to the handler.
        /// The contents of the bind context are handler-specific.
        /// For example, when binding to <see cref="BHID_Stream"/>, the <see cref="STGM"/> flags in the bind context
        /// indicate the mode of access desired (read or read/write).
        /// </param>
        /// <param name="bhid">
        /// Reference to a GUID that specifies which handler will be created.
        /// One of the following values defined in Shlguid.h:
        /// <see cref="BHID_SFObject"/>: Restricts usage to <see cref="IShellFolder.BindToObject"/>.
        /// <see cref="BHID_SFUIObject"/>: Restricts usage to <see cref="IShellFolder.GetUIObjectOf"/>.
        /// <see cref="BHID_SFViewObject"/>: Restricts usage to <see cref="IShellFolder.CreateViewObject"/>.
        /// <see cref="BHID_Storage"/>: Attempts to retrieve the storage RIID, but defaults to Shell implementation on failure.
        /// <see cref="BHID_Stream"/>: Restricts usage to IStream.
        /// <see cref="BHID_LinkTargetItem"/>:
        /// <see cref="CLSID_ShellItem"/> is initialized with the target of this item (can only be <see cref="SFGAO_LINK"/>).
        /// See <see cref="GetAttributesOf"/> for a description of <see cref="SFGAO_LINK"/>.
        /// <see cref="BHID_StorageEnum"/>:
        /// If the item is a folder, gets an <see cref="IEnumShellItems"/> object with which to enumerate the storage contents.
        /// <see cref="BHID_Transfer"/>:
        /// Introduced in Windows Vista: If the item is a folder, gets an <see cref="ITransferSource"/> or <see cref="ITransferDestination"/> object.
        /// <see cref="BHID_PropertyStore"/>:
        /// Introduced in Windows Vista: Restricts usage to <see cref="IPropertyStore"/> or <see cref="IPropertyStoreFactory"/>.
        /// <see cref="BHID_ThumbnailHandler"/>:
        /// Introduced in Windows Vista: Restricts usage to <see cref="IExtractImage"/> or <see cref="IThumbnailProvider"/>.
        /// <see cref="BHID_EnumItems"/>:
        /// Introduced in Windows Vista:
        /// If the item is a folder, gets an <see cref="IEnumShellItems"/> object that enumerates all items in the folder.
        /// This includes folders, nonfolders, and hidden items.
        /// <see cref="BHID_DataObject"/>:
        /// Introduced in Windows Vista: Gets an <see cref="IDataObject"/> object for use with an item or an array of items.
        /// <see cref="BHID_AssociationArray"/>:
        /// Introduced in Windows Vista: Gets an <see cref="IQueryAssociations"/> object for use with an item or an array of items.
        /// <see cref="BHID_Filter"/>:
        /// Introduced in Windows Vista: Restricts usage to <see cref="IFilter"/>.
        /// <see cref="BHID_EnumAssocHandlers"/>:
        /// Introduced in Windows 7:
        /// Gets an <see cref="IEnumAssocHandlers"/> object used to enumerate the recommended association handlers for the given item.
        /// <see cref="BHID_RandomAccessStream"/>:
        /// Introduced in Windows 8: Gets an <see cref="IRandomAccessStream"/> object for the item.
        /// <see cref="BHID_FilePlaceholder"/>:
        /// Introduced in Windows 8.1: Gets an object used to provide placeholder file functionality.
        /// </param>
        /// <param name="riid">
        /// IID of the object type to retrieve.
        /// </param>
        /// <param name="ppv">
        /// When this method returns, contains a pointer of type <paramref name="riid"/>
        /// that is returned by the handler specified by <paramref name="bhid"/>.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT BindToHandler([In] in IBindCtx pbc, [In] in GUID bhid, [In] in IID riid, [Out] out IntPtr ppv)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IBindCtx, in GUID, in IID, out IntPtr, HRESULT>)_vTable[3])(thisPtr, pbc, bhid, riid, out ppv);
            }
        }

        /// <summary>
        /// Gets the parent of an <see cref="IShellItem"/> object.
        /// </summary>
        /// <param name="ppsi">
        /// The address of a pointer to the parent of an <see cref="IShellItem"/> interface.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful, or an error value otherwise.
        /// </returns>
        public HRESULT GetParent([Out] out IntPtr ppsi)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out IntPtr, HRESULT>)_vTable[4])(thisPtr, out ppsi);
            }
        }

        /// <summary>
        /// Gets the display name of the <see cref="IShellItem"/> object.
        /// </summary>
        /// <param name="sigdnName">
        /// One of the <see cref="SIGDN"/> values that indicates how the name should look.
        /// </param>
        /// <param name="ppszName">
        /// A value that, when this function returns successfully, receives the address of a pointer to the retrieved display name.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// It is the responsibility of the caller to free the string pointed to by <paramref name="ppszName"/> when it is no longer needed.
        /// Call <see cref="CoTaskMemFree"/> on <paramref name="ppszName"/> to free the memory.
        /// </remarks>
        public HRESULT GetDisplayName([In] SIGDN sigdnName, [Out] out IntPtr ppszName)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, SIGDN, out IntPtr, HRESULT>)_vTable[5])(thisPtr, sigdnName, out ppszName);
            }
        }

        /// <summary>
        /// Gets a requested set of attributes of the IShellItem object.
        /// </summary>
        /// <param name="sfgaoMask">
        /// Specifies the attributes to retrieve.
        /// One or more of the <see cref="SFGAOF"/> values.
        /// Use a bitwise OR operator to determine the attributes to retrieve.
        /// </param>
        /// <param name="psfgaoAttribs">
        /// A pointer to a value that, when this method returns successfully, contains the requested attributes.
        /// One or more of the <see cref="SFGAOF"/> values.
        /// Only those attributes specified by sfgaoMask are returned; other attribute values are undefined.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the attributes returned exactly match those requested in <paramref name="sfgaoMask"/>,
        /// <see cref="S_FALSE"/> if the attributes do not exactly match, or a standard COM error value otherwise.
        /// </returns>
        public HRESULT GetAttributes([In] SFGAOF sfgaoMask, [Out] out SFGAOF psfgaoAttribs)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, SFGAOF, out SFGAOF, HRESULT>)_vTable[6])(thisPtr, sfgaoMask, out psfgaoAttribs);
            }
        }

        /// <summary>
        /// Compares two <see cref="IShellItem"/> objects.
        /// </summary>
        /// <param name="psi">
        /// A pointer to an <see cref="IShellItem"/> object to compare with the existing <see cref="IShellItem"/> object.
        /// </param>
        /// <param name="hint">
        /// One of the <see cref="SICHINTF"/> values that determines how to perform the comparison.
        /// See <see cref="SICHINTF"/> for the list of possible values for this parameter.
        /// </param>
        /// <param name="piOrder">
        /// This parameter receives the result of the comparison.
        /// If the two items are the same this parameter equals zero; if they are different the parameter is nonzero.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if the items are the same, <see cref="S_FALSE"/> if they are different, or an error value otherwise.
        /// </returns>
        public HRESULT Compare([In] in IShellItem psi, [In] SICHINTF hint, [Out] out int piOrder)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IShellItem, SICHINTF, out int, HRESULT>)_vTable[7])(thisPtr, psi, hint, out piOrder);
            }
        }
    }
}
