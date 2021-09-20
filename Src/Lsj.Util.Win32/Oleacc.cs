using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.EventConstants;
using static Lsj.Util.Win32.Enums.OBJID;
using static Lsj.Util.Win32.Enums.VARENUM;
using static Lsj.Util.Win32.OleAut32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Oleacc.dll
    /// </summary>
    public static class Oleacc
    {
        /// <summary>
        /// CHILDID_SELF
        /// </summary>
        public const uint CHILDID_SELF = 0;

        /// <summary>
        /// <para>
        /// Retrieves the address of the <see cref="IAccessible"/> interface for the object
        /// that generated the event that is currently being processed by the client's event hook function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/oleacc/nf-oleacc-accessibleobjectfromevent"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// Specifies the window handle of the window that generated the event.
        /// This value must be the window handle that is sent to the event hook function.
        /// </param>
        /// <param name="dwId">
        /// Specifies the object ID of the object that generated the event.
        /// This value must be the object ID that is sent to the event hook function.
        /// </param>
        /// <param name="dwChildId">
        /// Specifies whether the event was triggered by an object or one of its child elements.
        /// If the object triggered the event, <paramref name="dwChildId"/> is <see cref="CHILDID_SELF"/>.
        /// If a child element triggered the event, <paramref name="dwChildId"/> is the element's child ID.
        /// This value must be the child ID that is sent to the event hook function.
        /// </param>
        /// <param name="ppacc">
        /// Address of a pointer variable that receives the address of an <see cref="IAccessible"/> interface.
        /// The interface is either for the object that generated the event, or for the parent of the element that generated the event.
        /// </param>
        /// <param name="pvarChild">
        /// Address of a <see cref="VARIANT"/> structure that specifies the child ID that can be used to access information about the UI element.
        /// </param>
        /// <returns>
        /// If successful, returns <see cref="S_OK"/>.
        /// If not successful, returns one of the following or another standard COM error code.
        /// <see cref="E_INVALIDARG"/>: An argument is not valid.
        /// </returns>
        /// <remarks>
        /// Clients call this function within an event hook function to obtain an <see cref="IAccessible"/> interface pointer
        /// to either the object that generated the event or to the parent of the element that generated the event.
        /// The parameters sent to the WinEventProc callback function must be used for
        /// this function's <paramref name="hwnd"/>, <paramref name="dwId"/>, and <paramref name="dwChildId"/> parameters.
        /// This function retrieves the lowest-level accessible object in the object hierarchy that is associated with an event.
        /// If the element that generated the event is not an accessible object (that is, does not support <see cref="IAccessible"/>),
        /// then the function retrieves the <see cref="IAccessible"/> interface of the parent object.
        /// The parent object must provide information about the child element through the <see cref="IAccessible"/> interface.
        /// As with other <see cref="IAccessible"/> methods and functions, clients might receive errors
        /// for <see cref="IAccessible"/> interface pointers because of a user action.
        /// For more information, see Receiving Errors for IAccessible Interface Pointers.
        /// This function fails if called in response to <see cref="EVENT_OBJECT_CREATE"/> because the object is not fully initialized.
        /// Similarly, clients should not call this in response to <see cref="EVENT_OBJECT_DESTROY"/>
        /// because the object is no longer available and cannot respond.
        /// Clients watch for <see cref="EVENT_OBJECT_SHOW"/> and <see cref="EVENT_OBJECT_HIDE"/> events
        /// rather than for <see cref="EVENT_OBJECT_CREATE"/> and <see cref="EVENT_OBJECT_DESTROY"/>.
        /// </remarks>
        [DllImport("Oleacc.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessibleObjectFromEvent", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT AccessibleObjectFromEvent([In] HWND hwnd, [In] DWORD dwId, [In] DWORD dwChildId,
            [Out] out IntPtr ppacc, [Out] out VARIANT pvarChild);

        /// <summary>
        /// <para>
        /// Retrieves the address of the <see cref="IAccessible"/> interface pointer for the object displayed at a specified point on the screen.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/oleacc/nf-oleacc-accessibleobjectfrompoint"/>
        /// </para>
        /// </summary>
        /// <param name="ptScreen">
        /// Specifies, in physical screen coordinates, the point that is examined.
        /// </param>
        /// <param name="ppacc">
        /// Address of a pointer variable that receives the address of the object's <see cref="IAccessible"/> interface.
        /// </param>
        /// <param name="pvarChild">
        /// Address of a <see cref="VARIANT"/> structure that specifies whether the <see cref="IAccessible"/> interface pointer
        /// that is returned in <paramref name="ppacc"/> belongs to the object displayed at the specified point,
        /// or to the parent of the element at the specified point.
        /// The <see cref="VARIANT.vt"/> member of the <see cref="VARIANT"/> is always <see cref="VT_I4"/>.
        /// If the <see cref="VARIANT.lVal"/> member is <see cref="CHILDID_SELF"/>,
        /// then the <see cref="IAccessible"/> interface pointer at ppacc belongs to the object at the point.
        /// If the <see cref="VARIANT.lVal"/> member is not <see cref="CHILDID_SELF"/>,
        /// <paramref name="ppacc"/> is the address of the <see cref="IAccessible"/> interface of the child element's parent object.
        /// Clients must call <see cref="VariantClear"/> on the retrieved <see cref="VARIANT"/> parameter when finished using it.
        /// </param>
        /// <returns>
        /// If successful, returns <see cref="S_OK"/>.
        /// If not successful, returns one of the following or another standard COM error code.
        /// <see cref="E_INVALIDARG"/>: An argument is not valid.
        /// </returns>
        /// <remarks>
        /// This function retrieves the lowest-level accessible object in the object hierarchy at a given point.
        /// If the element at the point is not an accessible object (that is, does not support <see cref="IAccessible"/>),
        /// then the function retrieves the <see cref="IAccessible"/> interface of the parent object.
        /// The parent object must provide information about the child element through the <see cref="IAccessible"/> interface.
        /// Call <see cref="IAccessible.accHitTest"/> to identify the child element at the specified screen coordinates.
        /// As with other <see cref="IAccessible"/> methods and functions,
        /// clients might receive errors for <see cref="IAccessible"/> interface pointers because of a user action.
        /// For more information, see Receiving Errors for IAccessible Interface Pointers.
        /// </remarks>
        [DllImport("Oleacc.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessibleObjectFromPoint", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT AccessibleObjectFromPoint([In] POINT ptScreen, [Out] out IntPtr ppacc, [Out] out VARIANT pvarChild);

        /// <summary>
        /// <para>
        /// Retrieves the address of the specified interface for the object associated with the specified window.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/oleacc/nf-oleacc-accessibleobjectfromwindow"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// Specifies the handle of a window for which an object is to be retrieved.
        /// To retrieve an interface pointer to the cursor or caret object,
        /// specify <see cref="NULL"/> and use the appropriate object ID in <paramref name="dwId"/>.
        /// </param>
        /// <param name="dwId">
        /// Specifies the object ID.
        /// This value is one of the standard object identifier constants or a custom object ID such as <see cref="OBJID_NATIVEOM"/>,
        /// which is the object ID for the Office native object model.
        /// For more information about <see cref="OBJID_NATIVEOM"/>, see the Remarks section in this topic.
        /// </param>
        /// <param name="riid">
        /// Specifies the reference identifier of the requested interface.
        /// This value is either <see cref="IID_IAccessible"/> or <see cref="IID_IDispatch"/>, but it can also be <see cref="IID_IUnknown"/>,
        /// or the IID of any interface that the object is expected to support.
        /// </param>
        /// <param name="ppvObject">
        /// Address of a pointer variable that receives the address of the specified interface.
        /// </param>
        /// <returns>
        /// If successful, returns <see cref="S_OK"/>.
        /// If not successful, returns one of the following or another standard COM error code.
        /// <see cref="E_INVALIDARG"/>: An argument is not valid.
        /// <see cref="E_NOINTERFACE"/>: The requested interface is not supported.
        /// </returns>
        /// <remarks>
        /// Clients call this function to retrieve the address of an object's <see cref="IAccessible"/>,
        /// <see cref="IDispatch"/>, <see cref="IEnumVARIANT"/>, <see cref="IUnknown"/>, or other supported interface pointer.
        /// As with other <see cref="IAccessible"/> methods and functions,
        /// clients might receive errors for <see cref="IAccessible"/> interface pointers because of a user action.
        /// For more information, see Receiving Errors for IAccessible Interface Pointers.
        /// Clients use this function to obtain access to the Microsoft Office 2000 native object model.
        /// The native object model provides clients with accessibility information about an Office application's document
        /// or client area that is not exposed by Microsoft Active Accessibility.
        /// To obtain an <see cref="IDispatch"/> interface pointer to a class supported by the native object model,
        /// specify <see cref="OBJID_NATIVEOM"/> in <paramref name="dwId"/>. When using this object identifier,
        /// the <paramref name="hwnd"/> parameter must match the following window class types.
        /// Office application	Window class	IDispatch pointer to
        /// Word	            _WwG	        Window
        /// Excel	            EXCEL7	        Window
        /// PowerPoint	        paneClassDC 	DocumentWindow
        /// Command Bars	    MsoCommandBar	CommandBar
        /// Note that the above window classes correspond to the innermost document window or pane window.
        /// For more information about the Office object model, see the Microsoft Office 2000/Visual Basic Programmer's Guide.
        /// </remarks>
        [DllImport("Oleacc.dll", CharSet = CharSet.Unicode, EntryPoint = "AccessibleObjectFromWindow", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT AccessibleObjectFromWindow([In] HWND hwnd, [In] DWORD dwId, [In] in IID riid, [Out] out IntPtr ppvObject);
    }
}
