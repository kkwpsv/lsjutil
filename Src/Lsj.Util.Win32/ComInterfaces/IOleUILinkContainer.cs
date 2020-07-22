using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Enums.OLEUPDATE;
using static Lsj.Util.Win32.Enums.OLEVERB;
using static Lsj.Util.Win32.Enums.USERCLASSTYPE;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Implemented by containers and used by OLE common dialog boxes.
    /// It supports these dialog boxes by providing the methods needed to manage a container's links.
    /// The <see cref="IOleUILinkContainer"/> methods enumerate the links associated with a container,
    /// and specify how they should be updated, automatically or manually.
    /// They change the source of a link and obtain information associated with a link.
    /// They also open a link's source document, update links, and break a link to the source.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/oledlg/nn-oledlg-ioleuilinkcontainerw
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IOleUILinkContainer)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleUILinkContainer
    {
        /// <summary>
        /// Enumerates the links in a container.
        /// </summary>
        /// <param name="dwLink">
        /// Container-defined unique identifier for a single link.
        /// This value is only passed to other methods on this interface, so it can be any value that uniquely identifies a link to the container.
        /// Containers frequently use the pointer to the link's container site object for this value.
        /// </param>
        /// <returns></returns>
        [PreserveSig]
        DWORD GetNextLink([In] DWORD dwLink);

        /// <summary>
        /// Sets a link's update options to automatic or manual.
        /// </summary>
        /// <param name="dwLink">
        /// Container-defined unique identifier for a single link.
        /// See <see cref="GetNextLink"/>.
        /// </param>
        /// <param name="dwUpdateOpt">
        /// Update options, which can be automatic (<see cref="OLEUPDATE_ALWAYS"/>) or manual (<see cref="OLEUPDATE_ONCALL"/>).
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_ACCESSDENIED"/>: Insufficient access permissions.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// <see cref="E_INVALIDARG"/>: The specified identifier is invalid.
        /// <see cref="E_OUTOFMEMORY"/>: There is insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// Notes to Implementers
        /// Containers can implement this method for OLE links by simply calling <see cref="IOleLink.SetUpdateOptions"/> on the link object. 
        /// </remarks>
        [PreserveSig]
        HRESULT SetLinkUpdateOptions([In] DWORD dwLink, [In] OLEUPDATE dwUpdateOpt);

        /// <summary>
        /// Determines the current update options for a link.
        /// </summary>
        /// <param name="dwLink">
        /// Container-defined unique identifier for a single link. See <see cref="GetNextLink"/>.
        /// </param>
        /// <param name="lpdwUpdateOpt">
        /// A pointer to the location that the current update options will be written.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_ACCESSDENIED"/>: Insufficient access permissions.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// <see cref="E_INVALIDARG"/>: The specified identifier is invalid.
        /// <see cref="E_OUTOFMEMORY"/>: There is insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// Notes to Implementers
        /// Containers can implement this method for OLE links by simply calling <see cref="IOleLink.SetUpdateOptions"/> on the link object. 
        /// </remarks>
        [PreserveSig]
        HRESULT GetLinkUpdateOptions([In] DWORD dwLink, [Out] out OLEUPDATE lpdwUpdateOpt);

        /// <summary>
        /// Changes the source of a link.
        /// </summary>
        /// <param name="dwLink">
        /// Container-defined unique identifier for a single link. See <see cref="GetNextLink"/>.
        /// </param>
        /// <param name="lpszDisplayName">
        /// Pointer to new source string to be parsed.
        /// </param>
        /// <param name="lenFileName">
        /// Length of the leading file name portion of the <paramref name="lpszDisplayName"/> string.
        /// If the link source is not stored in a file, then <paramref name="lenFileName"/> should be 0.
        /// For OLE links, call <see cref="IOleLink.GetSourceDisplayName"/>.
        /// </param>
        /// <param name="pchEaten">
        /// Pointer to the number of characters successfully parsed in <paramref name="lpszDisplayName"/>.
        /// </param>
        /// <param name="fValidateSource">
        /// <see cref="TRUE"/> if the moniker should be validated; for OLE links, <see cref="MkParseDisplayName"/> should be called.
        /// <see cref="FALSE"/> if the moniker should not be validated.
        /// If possible, the link should accept the unvalidated source, and mark itself as unavailable.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_ACCESSDENIED"/>: Insufficient access permissions.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// <see cref="E_INVALIDARG"/>: The specified identifier is invalid.
        /// <see cref="E_OUTOFMEMORY"/>: There is insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// Call this method from the Change Source dialog box, with <paramref name="fValidateSource"/> initially set to <see cref="TRUE"/>.
        /// Change Source can be called directly or from the Links dialog box.
        /// If this call to <see cref="SetLinkSource"/> returns an error (e.g., <see cref="MkParseDisplayName"/> failed
        /// because the source was unavailable), then you should display an Invalid Link Source message,
        /// and the user should be allowed to decide whether to fix the source.
        /// If the user chooses to fix the source, then the user should be returned to the Change Source dialog box
        /// with the invalid portion of the input string highlighted.
        /// If the user chooses not to fix the source, then <see cref="SetLinkSource"/> should be called a second time
        /// with <paramref name="fValidateSource"/> set to <see cref="FALSE"/>,
        /// and the user should be returned to the Links dialog box with the link marked Unavailable. 
        /// </remarks>
        [PreserveSig]
        HRESULT SetLinkSource([In] DWORD dwLink, [MarshalAs(UnmanagedType.LPWStr)][In] string lpszDisplayName, [In] ULONG lenFileName,
            [Out] out ULONG pchEaten, [In] BOOL fValidateSource);

        /// <summary>
        /// Retrieves information about a link that can be displayed in the Links dialog box.
        /// </summary>
        /// <param name="dwLink">
        /// Container-defined unique identifier for a single link. See <see cref="GetNextLink"/>.
        /// </param>
        /// <param name="lplpszDisplayName">
        /// Address of a pointer variable that receives a pointer to the full display name string for the link source.
        /// The Links dialog box will free this string.
        /// </param>
        /// <param name="lplenFileName">
        /// Pointer to the length of the leading file name portion of the <paramref name="lplpszDisplayName"/> string.
        /// If the link source is not stored in a file, then <paramref name="lplenFileName"/> should be 0.
        /// For OLE links, call <see cref="IOleLink.GetSourceDisplayName"/>.
        /// </param>
        /// <param name="lplpszFullLinkType">
        /// Address of a pointer variable that receives a pointer to the full link type string
        /// that is displayed at the bottom of the Links dialog box.
        /// The caller allocates this string. The Links dialog box will free this string.
        /// For OLE links, this should be the full User Type name.
        /// Use <see cref="IOleObject.GetUserType"/>, specifying <see cref="USERCLASSTYPE_FULL"/> for dwFormOfType.
        /// </param>
        /// <param name="lplpszShortLinkType">
        /// Address of a pointer variable that receives a pointer to the short link type string
        /// that is displayed in the listbox of the Links dialog box.
        /// The caller allocates this string.
        /// The Links dialog box will free this string.
        /// For OLE links, this should be the short user type name.
        /// Use <see cref="IOleObject.GetUserType"/>, specifying <see cref="USERCLASSTYPE_FULL"/> for dwFormOfType.
        /// </param>
        /// <param name="lpfSourceAvailable">
        /// Pointer that returns <see cref="FALSE"/> if it is known that a link is unavailable
        /// since the link is to some known but unavailable document.
        /// Certain options, such as Update Now, are disabled (grayed in the user interface) for such cases.
        /// </param>
        /// <param name="lpfIsSelected">
        /// Pointer to a variable that tells the Edit Links dialog box
        /// that this link's entry should be selected in the dialog's multi-selection listbox.
        /// <see cref="OleUIEditLinks"/> calls this method at least once for each item to be placed in the links list.
        /// If none of them return <see cref="TRUE"/>, then none of them will be selected when the dialog box is first displayed.
        /// If all of them return <see cref="TRUE"/>, then all will be displayed.
        /// That is, it returns <see cref="TRUE"/> if this link is currently part of the selection
        /// in the underlying document, <see cref="FALSE"/> if not.
        /// Any links that are selected in the underlying document are selected in the dialog box;
        /// this way, the user can select a set of links and use the dialog box to update them or change their source(s) simultaneously.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_ACCESSDENIED"/>: Insufficient access permissions.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// <see cref="E_INVALIDARG"/>: The specified identifier is invalid.
        /// <see cref="E_OUTOFMEMORY"/>: There is insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// Call this method during dialog box initialization, after returning from the Change Source dialog box. 
        /// </remarks>
        [PreserveSig]
        HRESULT GetLinkSource([In] DWORD dwLink, [Out] out IntPtr lplpszDisplayName, [Out] out ULONG lplenFileName, [Out] out IntPtr lplpszFullLinkType,
            [Out] out IntPtr lplpszShortLinkType, [Out] out BOOL lpfSourceAvailable, [Out] out BOOL lpfIsSelected);

        /// <summary>
        /// Opens the link's source.
        /// </summary>
        /// <param name="dwLink">
        /// Container-defined unique identifier for a single link.
        /// Containers can use the pointer to the link's container site for this value.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_ACCESSDENIED"/>: Insufficient access permissions.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// <see cref="E_INVALIDARG"/>: The specified identifier is invalid.
        /// <see cref="E_OUTOFMEMORY"/>: There is insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// The <see cref="OpenLinkSource"/> method is called when the Open Source button is selected from the Links dialog box.
        /// For OLE links, call <see cref="IOleObject.DoVerb"/>, specifying <see cref="OLEIVERB_SHOW"/> for iVerb. 
        /// </remarks>
        [PreserveSig]
        HRESULT OpenLinkSource([In] DWORD dwLink);

        /// <summary>
        /// Forces selected links to connect to their source and retrieve current information.
        /// </summary>
        /// <param name="dwLink">
        /// Container-defined unique identifier for a single link.
        /// Containers can use the pointer to the link's container site for this value.
        /// </param>
        /// <param name="fErrorMessage">
        /// Determines whether the caller (implementer of <see cref="IOleUILinkContainer"/>)
        /// should show an error message upon failure to update a link.
        /// The Update Links dialog box sets this to <see cref="FALSE"/>.
        /// The Object Properties and Links dialog boxes set it to <see cref="TRUE"/>.
        /// </param>
        /// <param name="fReserved">
        /// This parameter is reserved and must be set to <see cref="FALSE"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_ACCESSDENIED"/>: Insufficient access permissions.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// <see cref="E_INVALIDARG"/>: The specified identifier is invalid.
        /// <see cref="E_OUTOFMEMORY"/>: There is insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// Call this method with <paramref name="fErrorMessage"/> set to <see cref="TRUE"/> in cases
        /// where the user expressly presses a button to have a link updated, that is, presses the links' Update Now button.
        /// Call it with <see cref="FALSE"/> in cases where the container should never display an error message,
        /// that is, where a large set of operations are being performed and the error should be propagated back to the user later,
        /// as might occur with the Update links progress meter.
        /// Rather than providing one message for each failure, assuming there are failures,
        /// provide a single message for all failures at the end of the operation.
        /// Notes to Implementers
        /// For OLE links, call <see cref="IOleObject.Update"/>. 
        /// </remarks>
        [PreserveSig]
        HRESULT UpdateLink([In] DWORD dwLink, [In] BOOL fErrorMessage, [In] BOOL fReserved);

        /// <summary>
        /// Disconnects the selected links.
        /// </summary>
        /// <param name="dwLink">
        /// Container-defined unique identifier for a single link.
        /// Containers can use the pointer to the link's container site for this value.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="E_ACCESSDENIED"/>: Insufficient access permissions.
        /// <see cref="E_FAIL"/>: The operation failed.
        /// <see cref="E_INVALIDARG"/>: The specified identifier is invalid.
        /// <see cref="E_OUTOFMEMORY"/>: There is insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// Call <see cref="CancelLink"/> when the user selects the Break Link button from the Links dialog box.
        /// The link should be converted to a picture. The Links dialog box will not be dismissed for OLE links.
        /// Notes to Implementers
        /// For OLE links, <see cref="OleCreateStaticFromData"/> can be used to create a static picture object
        /// using the <see cref="IDataObject"/> interface of the link as the source. 
        /// </remarks>
        [PreserveSig]
        HRESULT CancelLink([In] DWORD dwLink);
    }
}
