using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Enums.SFGAOF;
using static Lsj.Util.Win32.Enums.SHCIDS;
using static Lsj.Util.Win32.Enums.SHGDNF;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.Shell32;
using BIND_OPTS = Lsj.Util.Win32.Structs.BIND_OPTS;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposed by all Shell namespace folder objects, its methods are used to manage folders.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellfolder
    /// </para>
    /// </summary>
    /// <remarks>
    /// Implement this interface for objects that extend the Shell's namespace.
    /// For example, implement this interface to create a separate namespace that requires a rooted Windows Explorer
    /// or to install a new namespace directly within the hierarchy of the system namespace.
    /// You are most familiar with the contents of your namespace, so you are responsible for implementing everything needed to access your data.
    /// Use this interface when you need to display or perform an operation on the contents of the Shell's namespace.
    /// Objects that support <see cref="IShellFolder"/> are usually created by other Shell folder objects.
    /// To retrieve a folder's <see cref="IShellFolder"/> interface, you typically start by calling <see cref="SHGetDesktopFolder"/>.
    /// This function returns a pointer to the desktop's <see cref="IShellFolder"/> interface.
    /// You can then use its methods to retrieve an <see cref="IShellFolder"/> interface for a particular namespace folder.
    /// <see cref="IShellFolder"/> methods only accept PIDLs that are relative to the folder.
    /// Some <see cref="IShellFolder"/> methods, such as <see cref="GetAttributesOf"/>, only accept single-level PIDLs.
    /// In other words, the PIDL must contain only a single <see cref="SHITEMID"/> structure, plus the terminating NULL.
    /// When you enumerate the contents of a folder with <see cref="IEnumIDList"/>, you will receive PIDLs of this form.
    /// Other methods, such as <see cref="CompareIDs"/>, accept multi-level PIDLs.
    /// These PIDLs can have multiple <see cref="SHITEMID"/> structures and identify objects one or more levels below the parent folder.
    /// Check the reference to be sure what type of PIDL can be accepted by a particular method.
    /// </remarks>
    [ComImport]
    [Guid(IID_IShellFolder)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IShellFolder
    {
        /// <summary>
        /// Translates the display name of a file object or a folder into an item identifier list.
        /// </summary>
        /// <param name="hwnd">
        /// A window handle.
        /// The client should provide a window handle if it displays a dialog or message box.
        /// Otherwise set hwnd to <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="pbc">
        /// Optional.
        /// A pointer to a bind context used to pass parameters as inputs and outputs to the parsing function.
        /// These passed parameters are often specific to the data source and are documented by the data source owners.
        /// For example, the file system data source accepts the name being parsed (as a <see cref="WIN32_FIND_DATA"/> structure),
        /// using the <see cref="STR_FILE_SYS_BIND_DATA"/> bind context parameter.
        /// <see cref="STR_PARSE_PREFER_FOLDER_BROWSING"/> can be passed to indicate that URLs are parsed using the file system data source when possible.
        /// Construct a bind context object using <see cref="CreateBindCtx"/> and populate the values using <see cref="IBindCtx.RegisterObjectParam"/>.
        /// See Bind Context String Keys for a complete list of these.
        /// If no data is being passed to or received from the parsing function, this value can be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="pszDisplayName">
        /// A null-terminated Unicode string with the display name.
        /// Because each Shell folder defines its own parsing syntax, the form this string can take may vary.
        /// The desktop folder, for instance, accepts paths such as "C:\My Docs\My File.txt".
        /// It also will accept references to items in the namespace that have a GUID associated with them using the "::{GUID}" syntax.
        /// For example, to retrieve a fully qualified identifier list for the control panel from the desktop folder, you can use the following:
        /// <code>
        /// ::{CLSID for Control Panel}\::{CLSID for printers folder}
        /// </code>
        /// </param>
        /// <param name="pchEaten">
        /// A pointer to a ULONG value that receives the number of characters of the display name that was parsed.
        /// If your application does not need this information, set pchEaten to <see langword="null"/>, and no value will be returned.
        /// </param>
        /// <param name="ppidl">
        /// When this method returns, contains a pointer to the PIDL for the object.
        /// The returned item identifier list specifies the item relative to the parsing folder.
        /// If the object associated with <paramref name="pszDisplayName"/> is within the parsing folder,
        /// the returned item identifier list will contain only one <see cref="SHITEMID"/> structure.
        /// If the object is in a subfolder of the parsing folder,
        /// the returned item identifier list will contain multiple <see cref="SHITEMID"/> structures.
        /// If an error occurs, <see cref="IntPtr.Zero"/> is returned in this address.
        /// When it is no longer needed, it is the responsibility of the caller to free this resource by calling <see cref="CoTaskMemFree"/>.
        /// </param>
        /// <param name="pdwAttributes">
        /// The value used to query for file attributes.
        /// If not used, it should be set to 0.
        /// To query for one or more attributes, initialize this parameter with the <see cref="SFGAOF"/> flags that represent the attributes of interest.
        /// On return, those attributes that are true and were requested will be set.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Some Shell folders may not implement <see cref="IShellFolder.ParseDisplayName"/>.
        /// Each folder that does will define its own parsing syntax.
        /// <see cref="ParseDisplayName"/> is not expected to handle the relative path or parent folder indicators ("." or "..").
        /// It is up to the caller to remove these appropriately.
        /// Do not use the <see cref="SFGAO_VALIDATE"/> flag in <paramref name="pdwAttributes"/> to verify the existence of the item
        /// whose name is being parsed. <see cref="IShellFolder.ParseDisplayName"/> implicitly validates the existence of the item
        /// unless that behavior is overridden by a special bind context parameter.
        /// Querying for some attributes may be relatively slow and use significant amounts of memory.
        /// For example, to determine if a file is shared, the Shell will load network components.
        /// This procedure may require the loading of several DLLs.
        /// The purpose of pdwAttributes is to allow you to restrict the query to only that information that is needed.
        /// The following code fragment illustrates how to find out if a file is compressed.
        /// <code>
        /// LPITEMIDLIST pidl;
        /// ULONG cbEaten;
        /// DWORD dwAttribs = SFGAO_COMPRESSED;
        /// hres = psf->ParseDisplayName(NULL,
        ///                              NULL,
        ///                              lpwszDisplayName,
        ///                              &amp;cbEaten,  // This can be NULL
        ///                              &amp;pidl,
        ///                              &amp;dwAttribs);
        ///                         
        /// if(dwAttribs &amp; SFGAO_COMPRESSED)
        /// {
        ///     // Do something with the compressed file
        /// }
        /// </code>
        /// Since pdwAttributes is an in/out parameter, it should always be initialized.
        /// If you pass in an uninitialized value, some of the bits may be inadvertantly set.
        /// <see cref="IShellFolder.ParseDisplayName"/> will then query for the corresponding attributes,
        /// which may lead to undesirable delays or memory demands.
        /// If you do not wish to query for attributes, set <paramref name="pdwAttributes"/> to 0 to avoid unpredictable behavior.
        /// This method is similar to the <see cref="IParseDisplayName.ParseDisplayName"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT ParseDisplayName([In] IntPtr hwnd, [MarshalAs(UnmanagedType.Interface)][In] IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName,
            [In][Out] ref uint pchEaten, [Out] out IntPtr ppidl, [In][Out] ref SFGAOF pdwAttributes);

        /// <summary>
        /// Enables a client to determine the contents of a folder by creating an item identifier enumeration object
        /// and returning its <see cref="IEnumIDList"/> interface.
        /// The methods supported by that interface can then be used to enumerate the folder's contents.
        /// </summary>
        /// <param name="hwnd">
        /// If user input is required to perform the enumeration,
        /// this window handle should be used by the enumeration object as the parent window to take user input.
        /// An example would be a dialog box to ask for a password or prompt the user to insert a CD or floppy disk.
        /// If <paramref name="hwnd"/> is set to <see cref="IntPtr.Zero"/>, the enumerator should not post any messages,
        /// and if user input is required, it should silently fail.
        /// </param>
        /// <param name="grfFlags">
        /// Flags indicating which items to include in the enumeration.
        /// For a list of possible values, see the <see cref="SHCONTF"/> enumerated type.
        /// </param>
        /// <param name="ppenumIDList">
        /// The address that receives a pointer to the <see cref="IEnumIDList"/> interface of the enumeration object created by this method.
        /// If an error occurs or no suitable subobjects are found, <paramref name="ppenumIDList"/> is set to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful, or an error value otherwise.
        /// Some implementations may also return <see cref="S_FALSE"/>, indicating that there are no children
        /// matching the <paramref name="grfFlags"/> that were passed in.
        /// If <see cref="S_FALSE"/> is returned, <paramref name="ppenumIDList"/> is set to <see langword="null"/>.
        /// </returns>
        /// <remarks>
        /// If the method returns <see cref="S_OK"/>, then <paramref name="ppenumIDList"/> receives a pointer to an enumerator.
        /// In this case, the calling application must free the returned <see cref="IEnumIDList"/> object
        /// by calling its <see cref="Marshal.ReleaseComObject(object)"/> method.
        /// If the method returns <see cref="S_FALSE"/>, then the folder contains no suitable subobjects and the pointer
        /// specified in <paramref name="ppenumIDList"/> is set to <see langword="null"/>.
        /// If the method fails, an error value is returned and the pointer specified in <paramref name="ppenumIDList"/> is set to <see langword="null"/>.
        /// If the folder contains no suitable subobjects, then the <see cref="EnumObjects"/> method is permitted
        /// either to set <paramref name="ppenumIDList"/> to <see langword="null"/> and return <see cref="S_FALSE"/>,
        /// or to set <paramref name="ppenumIDList"/> to an enumerator that produces no objects and return <see cref="S_OK"/>.
        /// Calling applications must be prepared for both success cases.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumObjects([In] IntPtr hwnd, [In] SHCONTF grfFlags, [MarshalAs(UnmanagedType.Interface)][Out] out IEnumIDList ppenumIDList);

        /// <summary>
        /// Retrieves a handler, typically the Shell folder object that implements <see cref="IShellFolder"/> for a particular item. 
        /// Optional parameters that control the construction of the handler are passed in the bind context.
        /// </summary>
        /// <param name="pidl">
        /// The address of an <see cref="ITEMIDLIST"/> structure (PIDL) that identifies the subfolder.
        /// This value can refer to an item at any level below the parent folder in the namespace hierarchy.
        /// The structure contains one or more <see cref="SHITEMID"/> structures, followed by a terminating <see langword="null"/>.
        /// </param>
        /// <param name="pbc">
        /// A pointer to an <see cref="IBindCtx"/> interface on a bind context object that can be used to pass parameters to the construction of the handler.
        /// If this parameter is not used, set it to <see langword="null"/>.
        /// Because support for this parameter is optional for folder object implementations, some folders may not support the use of bind contexts.
        /// Information that can be provided in the bind context includes a <see cref="BIND_OPTS"/> structure
        /// that includes a <see cref="BIND_OPTS.grfMode"/> member that indicates the access mode when binding to a stream handler.
        /// Other parameters can be set and discovered using <see cref="IBindCtx.RegisterObjectParam"/> and <see cref="IBindCtx.GetObjectParam"/>.
        /// </param>
        /// <param name="riid">
        /// The identifier of the interface to return.
        /// This may be <see cref="IID_IShellFolder"/>, <see cref="IID_IStream"/>, or any other interface that identifies a particular handler.
        /// </param>
        /// <param name="ppv">
        /// When this method returns, contains the address of a pointer to the requested interface.
        /// If an error occurs, a <see langword="null"/> pointer is returned at this address.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Applications use <see cref="BindToObject"/>(..., <see cref="IID_IShellFolder"/>, ...) to obtain the Shell folder object for a subitem.
        /// Clients should pass the canonical interface IID that is used to identify a specific handler.
        /// For example, <see cref="IID_IShellFolder"/> identifies the folder handler and <see cref="IID_IStream"/> identifies the stream handler.
        /// Implementations can support binding to handlers using derived interfaces as well, such as <see cref="IID_IShellFolder2"/>.
        /// A Shell namespace extension can implement this function by creating the Shell folder object for the specified subitem
        /// and then calling QueryInterface to communicate with the object through its interface pointer.
        /// Implementations of <see cref="BindToObject"/> can optimize any call to it by quickly failing for IID values that it does not support.
        /// For example, if the Shell folder object of the subitem does not support <see cref="IRemoteComputer"/>,
        /// the implementation should return <see cref="E_NOINTERFACE"/> immediately instead of needlessly creating the Shell folder object
        /// for the subitem and then finding that <see cref="IRemoteComputer"/> was not supported after all.
        /// </remarks>
        [PreserveSig]
        HRESULT BindToObject([In] IntPtr pidl, [MarshalAs(UnmanagedType.Interface)][In] IBindCtx pbc,
            [MarshalAs(UnmanagedType.LPStruct)][In] Guid riid, [MarshalAs(UnmanagedType.IUnknown)][Out] out object ppv);

        /// <summary>
        /// Requests a pointer to an object's storage interface.
        /// </summary>
        /// <param name="pidl">
        /// The address of an <see cref="ITEMIDLIST"/> structure that identifies the subfolder relative to its parent folder.
        /// The structure must contain exactly one <see cref="SHITEMID"/> structure followed by a terminating zero.
        /// </param>
        /// <param name="pbc">
        /// The optional address of an <see cref="IBindCtx"/> interface on a bind context object to be used during this operation.
        /// If this parameter is not used, set it to <see langword="null"/>.
        /// Because support for <paramref name="pbc"/> is optional for folder object implementations, some folders may not support the use of bind contexts.
        /// </param>
        /// <param name="riid">
        /// The IID of the requested storage interface.
        /// To retrieve an <see cref="IStream"/>, <see cref="IStorage"/>, or <see cref="IPropertySetStorage"/> interface pointer,
        /// set riid to <see cref="IID_IStream"/>, <see cref="IID_IStorage"/>, or <see cref="IID_IPropertySetStorage"/>, respectively.
        /// </param>
        /// <param name="ppv">
        /// The address that receives the interface pointer specified by riid.
        /// If an error occurs, a <see langword="null"/> pointer is returned in this address.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Namespace extensions have the option of allowing applications to bind to an object that represents an item's storage.
        /// If this option is supported, <see cref="BindToStorage"/> returns a specified interface pointer
        /// that can then be used to access the contents of object.
        /// See the <see cref="IMoniker.BindToStorage"/> reference for further discussion.
        /// </remarks>
        [PreserveSig]
        HRESULT BindToStorage([In] IntPtr pidl, [MarshalAs(UnmanagedType.Interface)][In] IBindCtx pbc,
            [MarshalAs(UnmanagedType.LPStruct)][In] Guid riid, [MarshalAs(UnmanagedType.IUnknown)][Out] out object ppv);

        /// <summary>
        /// Determines the relative order of two file objects or folders, given their item identifier lists.
        /// </summary>
        /// <param name="lParam">
        /// A value that specifies how the comparison should be performed.
        /// The lower sixteen bits of <paramref name="lParam"/> define the sorting rule.
        /// Most applications set the sorting rule to the default value of zero, indicating that the two items should be compared by name.
        /// The system does not define any other sorting rules.
        /// Some folder objects might allow calling applications to use the lower sixteen bits
        /// of <paramref name="lParam"/> to specify folder-specific sorting rules.
        /// The rules and their associated <paramref name="lParam"/> values are defined by the folder.
        /// When the system folder view object calls <see cref="IShellFolder.CompareIDs"/>,
        /// the lower sixteen bits of <paramref name="lParam"/> are used to specify the column to be used for the comparison.
        /// The upper sixteen bits of <paramref name="lParam"/> are used for flags that modify the sorting rule.
        /// The system currently defines these modifier flags.
        /// <see cref="SHCIDS_ALLFIELDS"/>
        /// Version 5.0.
        /// Compare all the information contained in the <see cref="ITEMIDLIST"/> structure, not just the display names.
        /// This flag is valid only for folder objects that support the <see cref="IShellFolder2"/> interface.
        /// For instance, if the two items are files, the folder should compare their names, sizes, file times, attributes,
        /// and any other information in the structures.
        /// If this flag is set, the lower sixteen bits of <paramref name="lParam"/> must be zero.
        /// <see cref="SHCIDS_CANONICALONLY"/>
        /// Version 5.0.
        /// When comparing by name, compare the system names but not the display names.
        /// When this flag is passed, the two items are compared by whatever criteria the Shell folder determines are most efficient,
        /// as long as it implements a consistent sort function.
        /// This flag is useful when comparing for equality or when the results of the sort are not displayed to the user.
        /// This flag cannot be combined with other flags.
        /// </param>
        /// <param name="pidl1">
        /// A pointer to the first item's <see cref="ITEMIDLIST"/> structure. It will be relative to the folder.
        /// This <see cref="ITEMIDLIST"/> structure can contain more than one element; therefore, the entire structure must be compared,
        /// not just the first element.
        /// </param>
        /// <param name="pidl2">
        /// A pointer to the second item's <see cref="ITEMIDLIST"/> structure. It will be relative to the folder.
        /// This <see cref="ITEMIDLIST"/> structure can contain more than one element; therefore, the entire structure must be compared,
        /// not just the first element.
        /// </param>
        /// <returns>
        /// If this method is successful, the CODE field of the <see cref="HRESULT"/> contains one of the following values.
        /// For information regarding the extraction of the CODE field from the returned <see cref="HRESULT"/>, see Remarks.
        /// If this method is unsuccessful, it returns a COM error code.
        /// Negative: A negative return value indicates that the first item should precede the second (pidl1 &lt; pidl2).
        /// Positive: A positive return value indicates that the first item should follow the second (pidl1 &gt; pidl2).
        /// Zero: A return value of zero indicates that the two items are the same (pidl1 = pidl2).
        /// </returns>
        /// <remarks>
        /// Note to Calling Applications
        /// Do not set the <see cref="SHCIDS_ALLFIELDS"/> flag in <paramref name="lParam"/>
        /// if the folder object does not support <see cref="IShellFolder2"/>.
        /// Doing so might have unpredictable results.
        /// If you use the <see cref="SHCIDS_ALLFIELDS"/> flag, the lower sixteen bits of <paramref name="lParam"/> must be set to zero.
        /// Use the <see cref="HRESULT_CODE"/> macro to extract the CODE field from the <see cref="HRESULT"/>,
        /// then cast the result as a short.
        /// Note to Implementers
        /// To extract the sorting rule, use a bitwise AND operator (&amp;) to combine lParam with SHCIDS_COLUMNMASK(0X0000FFFF).
        /// This operation masks off the upper sixteen bits of lParam, including the <see cref="SHCIDS_ALLFIELDS"/> value.
        /// The <see cref="MAKE_HRESULT"/> macro is useful for constructing the return value for an implementation of the <see cref="CompareIDs"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT CompareIDs([In] IntPtr lParam, [In] IntPtr pidl1, [In] IntPtr pidl2);

        /// <summary>
        /// Requests an object that can be used to obtain information from or interact with a folder object.
        /// </summary>
        /// <param name="hwndOwner">
        /// A handle to the owner window.
        /// If you have implemented a custom folder view object, your folder view window should be created as a child of <paramref name="hwndOwner"/>.
        /// </param>
        /// <param name="riid">
        /// A reference to the IID of the interface to retrieve through <paramref name="ppv"/>, typically <see cref="IID_IShellView"/>.
        /// </param>
        /// <param name="ppv">
        /// When this method returns successfully, contains the interface pointer requested in <paramref name="riid"/>.
        /// This is typically <see cref="IShellView"/>.
        /// See the Remarks section for more details.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// To support this request, create an object that exposes the interface indicated by riid and return a pointer to that interface.
        /// The primary purpose of this method is to provide Windows Explorer with the folder object's folder view object.
        /// Windows Explorer requests a folder view object by setting riid to <see cref="IID_IShellView"/>.
        /// The folder view object displays the contents of the folder in the Windows Explorer folder view.
        /// The folder view object must be independent of the Shell folder object,
        /// because Windows Explorer may call this method more than once to create multiple folder view objects.
        /// A new view object must be created each time this method is called.
        /// Your folder object can respond in one of two ways to this request.
        /// It can:
        /// Create a custom folder view object and return a pointer to its <see cref="IShellView"/> interface.
        /// Create a system folder view object and return a pointer to its <see cref="IShellView"/> interface.
        /// This method is also used to request objects that expose one of several optional interfaces,
        /// including <see cref="IContextMenu"/> or <see cref="IExtractIcon"/>.
        /// In this context, <see cref="CreateViewObject"/> is similar in usage to <see cref="GetUIObjectOf"/>.
        /// However, you call <see cref="GetUIObjectOf"/> to request an object for one of the items contained by a folder.
        /// Call <see cref="IShellFolder.CreateViewObject"/> to request an object for the folder itself.
        /// The most commonly requested interfaces are:
        /// <see cref="IQueryInfo"/>
        /// <see cref="IShellDetails"/>
        /// <see cref="IDropTarget"/>
        /// We recommend that you use the IID_PPV_ARGS macro, defined in Objbase.h, to package the riid and ppv parameters.
        /// This macro provides the correct IID based on the interface pointed to by the value in <paramref name="ppv"/>,
        /// which eliminates the possibility of a coding error in <paramref name="riid"/> that could lead to unexpected results.
        /// </remarks>
        [PreserveSig]
        HRESULT CreateViewObject([In] IntPtr hwndOwner, [MarshalAs(UnmanagedType.LPStruct)][In] Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)][Out] out object ppv);

        /// <summary>
        /// Gets the attributes of one or more file or folder objects contained in the object represented by <see cref="IShellFolder"/>.
        /// </summary>
        /// <param name="cidl">
        /// The number of items from which to retrieve attributes.
        /// </param>
        /// <param name="apidl">
        /// The address of an array of pointers to <see cref="ITEMIDLIST"/> structures,
        /// each of which uniquely identifies an item relative to the parent folder.
        /// Each <see cref="ITEMIDLIST"/> structure must contain exactly one <see cref="SHITEMID"/> structure followed by a terminating zero.
        /// </param>
        /// <param name="rgfInOut">
        /// Pointer to a single ULONG value that, on entry, contains the bitwise <see cref="SFGAOF"/> attributes that the calling application is requesting.
        /// On exit, this value contains the requested attributes that are common to all of the specified items.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// To optimize this operation, do not return unspecified flags.
        /// For a folder object, the <see cref="SFGAO_BROWSABLE"/> attribute implies that the client can bind to this object as shown in a general form here.
        /// <code>
        /// IShellFolder::BindToObject(..., pidl, IID_IShellFolder, &amp;psfItem);
        /// </code>
        /// The client can then create an <see cref="IShellView"/> on that item through this statement.
        /// <code>
        /// psfItem-&gt;CreateViewObject(..., IID_IShellView,...);
        /// </code>
        /// The <see cref="SFGAO_DROPTARGET"/> attribute implies that the client can bind to an instance of <see cref="IDropTarget"/> for this folder
        /// by calling <see cref="GetUIObjectOf"/> as shown here.
        /// <code>
        /// IShellFolder::GetUIObjectOf(hwnd, 1, &amp;pidl, IID_IDropTarget, NULL, &amp;pv)
        /// </code>
        /// The <see cref="SFGAO_NONENUMERATED"/> attribute indicates an item that is not returned by the enumerator created 
        /// by the <see cref="EnumObjects"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT GetAttributesOf([In] uint cidl, [In] IntPtr apidl, [In][Out] ref SFGAOF rgfInOut);

        /// <summary>
        /// Gets an object that can be used to carry out actions on the specified file objects or folders.
        /// </summary>
        /// <param name="hwndOwner">
        /// A handle to the owner window that the client should specify if it displays a dialog box or message box.
        /// </param>
        /// <param name="cidl">
        /// The number of file objects or subfolders specified in the <paramref name="apidl"/> parameter.
        /// </param>
        /// <param name="apidl">
        /// The address of an array of pointers to <see cref="ITEMIDLIST"/> structures,
        /// each of which uniquely identifies a file object or subfolder relative to the parent folder.
        /// Each item identifier list must contain exactly one <see cref="SHITEMID"/> structure followed by a terminating zero.
        /// </param>
        /// <param name="riid">
        /// A reference to the IID of the interface to retrieve through <paramref name="ppv"/>.
        /// This can be any valid interface identifier that can be created for an item.
        /// The most common identifiers used by the Shell are listed in the comments at the end of this reference.
        /// </param>
        /// <param name="rgfReserved">
        /// Reserved.
        /// </param>
        /// <param name="ppv">
        /// When this method returns successfully, contains the interface pointer requested in <paramref name="riid"/>.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// If <paramref name="cidl"/> is greater than one, the <see cref="IShellFolder.GetUIObjectOf"/> implementation should only succeed
        /// if it can create one object for all items specified in <paramref name="apidl"/>.
        /// If the implementation cannot create one object for all items, this method will fail.
        /// The following are the most common interface identifiers the Shell uses when requesting an interface from this method.
        /// The list also indicates if <paramref name="cidl"/> can be greater than one for the requested interface.
        /// Interface Identifier        Allowed cidl Value
        /// <see cref="IContextMenu"/>  The <paramref name="cidl"/> parameter can be greater than or equal to one.
        /// <see cref="IContextMenu2"/> The <paramref name="cidl"/> parameter can be greater than or equal to one.
        /// <see cref="IDataObject"/>   The <paramref name="cidl"/> parameter can be greater than or equal to one.
        /// <see cref="IDropTarget"/>   The <paramref name="cidl"/> parameter can only be one.
        /// <see cref="IExtractIcon"/>  The <paramref name="cidl"/> parameter can only be one.
        /// <see cref="IQueryInfo"/>    The <paramref name="cidl"/> parameter can only be one.
        /// We recommend that you use the IID_PPV_ARGS macro, defined in Objbase.h,
        /// to package the <paramref name="riid"/> and <paramref name="ppv"/> parameters.
        /// This macro provides the correct IID based on the interface pointed to by the value in <paramref name="ppv"/>,
        /// which eliminates the possibility of a coding error in riid that could lead to unexpected results.
        /// </remarks>
        [PreserveSig]
        HRESULT GetUIObjectOf([In] IntPtr hwndOwner, [In] uint cidl, [In] IntPtr apidl, [MarshalAs(UnmanagedType.LPStruct)][In] Guid riid,
            [In] IntPtr rgfReserved, [MarshalAs(UnmanagedType.IUnknown)][Out] out object ppv);

        /// <summary>
        /// Retrieves the display name for the specified file object or subfolder.
        /// </summary>
        /// <param name="pidl">
        /// PIDL that uniquely identifies the file object or subfolder relative to the parent folder.
        /// </param>
        /// <param name="uFlags">
        /// Flags used to request the type of display name to return.
        /// For a list of possible values, see the <see cref="SHGDNF"/> enumerated type.
        /// </param>
        /// <param name="pName">
        /// When this method returns, contains a pointer to a <see cref="STRRET"/> structure in which to return the display name.
        /// The type of name returned in this structure can be the requested type, but the Shell folder might return a different type.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// It is the caller's responsibility to free resources allocated by this function.
        /// Normally, <paramref name="pidl"/> can refer only to items contained by the parent folder.
        /// The PIDL must be single-level and contain exactly one <see cref="SHITEMID"/> structure followed by a terminating zero.
        /// If you want to retrieve the display name of an item that is deeper than one level away from the parent folder,
        /// use <see cref="SHBindToParent"/> to bind with the item's immediate parent folder
        /// and then pass the item's single-level PIDL to <see cref="GetDisplayNameOf"/>.
        /// Also, if the <see cref="SHGDN_FORPARSING"/> flag is set in <paramref name="uFlags"/> and the <see cref="SHGDN_INFOLDER"/> flag is not set,
        /// <paramref name="pidl"/> can refer to an object at any level below the parent folder in the namespace hierarchy.
        /// At one time, <paramref name="pidl"/> could be a multilevel PIDL, relative to the parent folder,
        /// and could contain multiple <see cref="SHITEMID"/> structures.
        /// However, this is no longer supported and <paramref name="pidl"/> should now refer only to a single child item.
        /// The simplest way to retrieve the display name from the structure pointed to by <paramref name="pName"/> is to pass it
        /// to either <see cref="StrRetToBuf"/> or <see cref="StrRetToStr"/>.
        /// These functions take a <see cref="STRRET"/> structure and return the name.
        /// You can also examine the structure's <see cref="STRRET.uType"/> member, and retrieve the name from the appropriate member.
        /// The flags specified in <paramref name="uFlags"/> are hints about the intended use of the name.
        /// They do not guarantee that <see cref="IShellFolder"/> will return the requested form of the name.
        /// If that form is not available, a different one might be returned.
        /// In particular, there is no guarantee that the name returned by the <see cref="SHGDN_FORPARSING"/> flag will be successfully
        /// parsed by <see cref="ParseDisplayName"/>.
        /// There are also some combinations of flags that might cause the <see cref="GetDisplayNameOf"/>/<see cref="GetDisplayNameOf"/>
        /// round trip to not return the original identifier list.
        /// This occurrence is exceptional, but you should check to be sure.
        /// The parsing name that is returned when <paramref name="uFlags"/> has the <see cref="SHGDN_FORPARSING"/> flag set
        /// is not necessarily a normal text string.
        /// Virtual folders such as My Computer might return a string containing the folder object's GUID in the form "::{GUID}".
        /// Developers who implement <see cref="GetDisplayNameOf"/> are encouraged to return parse names that are as close to the display names as possible,
        /// because the end user often needs to type or edit these names.
        /// </remarks>
        [PreserveSig]
        HRESULT GetDisplayNameOf([In] IntPtr pidl, [In] SHGDNF uFlags, [Out] out STRRET pName);

        /// <summary>
        /// Sets the display name of a file object or subfolder, changing the item identifier in the process.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the owner window of any dialog or message box that the client displays.
        /// </param>
        /// <param name="pidl">
        /// A pointer to an <see cref="ITEMIDLIST"/> structure that uniquely identifies the file object or subfolder relative to the parent folder.
        /// The structure must contain exactly one <see cref="SHITEMID"/> structure followed by a terminating zero.
        /// </param>
        /// <param name="pszName">
        /// A pointer to a null-terminated string that specifies the new display name.
        /// </param>
        /// <param name="uFlags">
        /// Flags that indicate the type of name specified by the <paramref name="pszName"/> parameter.
        /// For a list of possible values and combinations of values, see <see cref="SHGDNF"/>.
        /// </param>
        /// <param name="ppidlOut">
        /// Optional.
        /// If specified, the address of a pointer to an <see cref="ITEMIDLIST"/> structure that receives the <see cref="ITEMIDLIST"/> of the renamed item.
        /// The caller requests this value by passing a non-null <paramref name="ppidlOut"/>.
        /// Implementations of <see cref="IShellFolder.SetNameOf"/> must return a pointer
        /// to the new <see cref="ITEMIDLIST"/> in the <paramref name="ppidlOut"/> parameter.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Changing the display name of a file system object, or a folder within it, renames the file or directory.
        /// Before calling this method, applications should call <see cref="GetAttributesOf"/> and check that the <see cref="SFGAO_CANRENAME"/> flag is set.
        /// Note that this flag is essentially a hint to namespace clients. It does not necessarily imply that <see cref="SetNameOf"/> will succeed or fail.
        /// Implementers of <see cref="SetNameOf"/> must call <see cref="SHChangeNotify"/> with both the old
        /// and new absolute PIDLs once the renaming of an object is complete.
        /// This following example shows the call to <see cref="SHChangeNotify"/> following the renaming of a folder object.
        /// <code>
        /// SHChangeNotify(SHCNE_RENAMEFOLDER, SHCNF_IDLIST, pidlFullOld, pidlFullNew);
        /// </code>
        /// This call prevents both the old and new names being displayed in the view.
        /// </remarks>
        [PreserveSig]
        HRESULT SetNameOf([In] IntPtr hwnd, [In] IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)][In] string pszName, [In] SHGDNF uFlags, [Out] out IntPtr ppidlOut);
    }
}
