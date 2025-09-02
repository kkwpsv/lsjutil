using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Dwmapi;
using static Lsj.Util.Win32.Enums.ButtonStyles;
using static Lsj.Util.Win32.Enums.ComboBoxControlMessages;
using static Lsj.Util.Win32.Enums.ComboBoxStyles;
using static Lsj.Util.Win32.Enums.DialogBoxCommandIDs;
using static Lsj.Util.Win32.Enums.DialogBoxStyles;
using static Lsj.Util.Win32.Enums.DWMWINDOWATTRIBUTE;
using static Lsj.Util.Win32.Enums.EditControlMessages;
using static Lsj.Util.Win32.Enums.GetWindowLongIndexes;
using static Lsj.Util.Win32.Enums.HitTestResults;
using static Lsj.Util.Win32.Enums.ListBoxMessages;
using static Lsj.Util.Win32.Enums.ListBoxStyles;
using static Lsj.Util.Win32.Enums.OBJID;
using static Lsj.Util.Win32.Enums.POINTER_FLAGS;
using static Lsj.Util.Win32.Enums.RawInputDeviceFlags;
using static Lsj.Util.Win32.Enums.RedrawWindowFlags;
using static Lsj.Util.Win32.Enums.ScrollBarCommands;
using static Lsj.Util.Win32.Enums.SetWindowPosFlags;
using static Lsj.Util.Win32.Enums.StandardClipboardFormats;
using static Lsj.Util.Win32.Enums.StaticControlStyles;
using static Lsj.Util.Win32.Enums.SystemCommands;
using static Lsj.Util.Win32.Enums.TrackPopupMenuFlags;
using static Lsj.Util.Win32.Enums.VirtualKeyCodes;
using static Lsj.Util.Win32.Enums.WindowClassStyles;
using static Lsj.Util.Win32.Enums.WindowHookTypes;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.ExtendedWindowStyles;
using static Lsj.Util.Win32.Enums.WinHelpCommands;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Oleacc;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Windows messages
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/winmsg/about-messages-and-message-queues"/>
    /// </para>
    /// </summary>
    public enum WindowMessages : uint
    {
        /// <summary>
        /// Used to define private messages, usually of the form <see cref="WM_APP"/>+x, where x is an integer value.
        /// </summary>
        WM_APP = 0x8000,

        /// <summary>
        /// Used to define private messages for use by private window classes, 
        /// usually of the form <see cref="WM_USER"/>+x, where x is an integer value.
        /// </summary>
        WM_USER = 0x0400,

        /// <summary>
        /// WM_KEYFIRST
        /// </summary>
        WM_KEYFIRST = 0x0100,

        /// <summary>
        /// WM_KEYLAST
        /// </summary>
        WM_KEYLAST = 0x0109,

        /// <summary>
        /// WM_MOUSEFIRST
        /// </summary>
        WM_MOUSEFIRST = 0x0200,

        /// <summary>
        /// WM_MOUSELAST
        /// </summary>
        WM_MOUSELAST = 0x020E,

        #region Active Accessibility User Interface Services Reference

        /// <summary>
        /// <para>
        /// Sent by both Microsoft Active Accessibility and Microsoft UI Automation
        /// to obtain information about an accessible object contained in a server application.
        /// </para>
        /// <para>
        /// Applications never send this message directly.
        /// Microsoft Active Accessibility sends this message in response to calls to <see cref="AccessibleObjectFromPoint"/>,
        /// <see cref="AccessibleObjectFromEvent"/>, or <see cref="AccessibleObjectFromWindow"/>.
        /// However, server applications handle this message.
        /// UI Automation sends this message in response to calls to <see cref="IUIAutomation.ElementFromHandle"/>,
        /// <see cref="IUIAutomation.ElementFromPoint"/>, and <see cref="IUIAutomation.GetFocusedElement"/>,
        /// and when handling events for which a client has registered.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/winauto/wm-getobject"/>
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam (dwFlags)
        /// </para>
        /// <para>
        /// Provides additional information about the message and is used only by the system.
        /// Servers pass dwFlags as the wParam parameter in the call to <see cref="LresultFromObject"/> when handling the message.
        /// </para>
        /// <para>
        /// lParam (dwObjId)
        /// </para>
        /// <para>
        /// Object identifier.
        /// This value is one of the object identifier constants or a custom object identifier.
        /// A server application must check this value to identify the type of information being requested.
        /// Before comparing this value against the OBJID_ values, the server must cast it to <see cref="DWORD"/>;
        /// otherwise, on 64-bit Windows, the sign extension of the lParam can interfere with the comparison.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If dwObjId is one of the OBJID_ values such as <see cref="OBJID_CLIENT"/>,
        /// the request is for a Microsoft Active Accessibility object that implements <see cref="IAccessible"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If dwObjId is equal to <see cref="UiaRootObjectId"/>, the request is for a UI Automation provider.
        /// If the server is implementing UI Automation, it should return a provider using the <see cref="UiaReturnRawElementProvider"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If dwObjId is <see cref="OBJID_NATIVEOM"/>, the request is for the control's underlying object model.
        /// If the control supports this request, it should return an appropriate COM interface by calling the <see cref="LresultFromObject"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If dwObjId is <see cref="OBJID_QUERYCLASSNAMEIDX"/>, the request is for the control to identify itself
        /// as a standard Windows control or a common control implemented by the common control library (ComCtrl.dll).
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the window or control does not need to respond to this message, it should pass the message to the <see cref="DefWindowProc"/> function;
        /// otherwise, the window or control should return a value that corresponds to the request specified by dwObjId:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the window or control implements UI Automation,
        /// the window or control should return the value obtained by a call to the <see cref="UiaReturnRawElementProvider"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If dwObjId is <see cref="OBJID_NATIVEOM"/> and the window exposes a native Object Model,
        /// the windows should return the value obtained by a call to the <see cref="LresultFromObject"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If dwObjId is <see cref="OBJID_CLIENT"/> and the window implements <see cref="IAccessible"/>,
        /// the window should return the value obtained by a call to the <see cref="LresultFromObject"/> function.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// <para>
        /// When a client calls <see cref="AccessibleObjectFromWindow"/> or any of the other AccessibleObjectFromX functions
        /// that retrieve an interface to an object, Microsoft Active Accessibility sends the <see cref="WM_GETOBJECT"/> message
        /// to the appropriate window procedure within the appropriate server application.
        /// While processing <see cref="WM_GETOBJECT"/>, server applications call <see cref="LresultFromObject"/>
        /// and use the return value of this function as the return value for the message.
        /// Microsoft Active Accessibility, in conjunction with the COM library,
        /// performs the appropriate marshaling and passes the interface pointer from the server back to the client.
        /// </para>
        /// <para>
        /// Servers do not respond to <see cref="WM_GETOBJECT"/> before the object is fully initialized or after it begins to close down.
        /// When an application creates a new window, the system sends <see cref="EVENT_OBJECT_CREATE"/> to notify clients
        /// before it sends the <see cref="WM_CREATE"/> message to the application's window procedure.
        /// Because many applications use WM_CREATE to start their initialization process,
        /// servers do not respond to the <see cref="WM_GETOBJECT"/> message until finished processing the <see cref="WM_CREATE"/> message.
        /// </para>
        /// <para>
        /// A server uses <see cref="WM_GETOBJECT"/> to perform the following tasks:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Create New Accessible Objects
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Reuse Existing Pointers to Objects
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Create New Interfaces to the Same Object
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// For clients, this means that they might receive distinct interface pointers for the same user interface element, depending on the server's action.
        /// To determine if two interface pointers point to the same user interface element, clients compare <see cref="IAccessible"/> properties of the object.
        /// Comparing pointers does not work.
        /// </para>
        /// </remarks>
        WM_GETOBJECT = 0x003D,

        #endregion

        #region Button Control Notifications

        /// <summary>
        /// <para>
        /// The <see cref="WM_CTLCOLORBTN"/> message is sent to the parent window of a button before drawing the button.
        /// The parent window can change the button's text and background colors.
        /// However, only owner-drawn buttons respond to the parent window processing this message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-ctlcolorbtn"/>
        /// </para>
        /// <para>
        /// <see cref="Parameters"/>
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// An <see cref="HDC"/> that specifies the handle to the display context for the button.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// An <see cref="HWND"/> that specifies the handle to the button.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it must return a handle to a brush.
        /// The system uses the brush to paint the background of the button.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the application returns a brush that it created
        /// (for example, by using the <see cref="CreateSolidBrush"/> or <see cref="CreateBrushIndirect"/> function),
        /// the application must free the brush.
        /// If the application returns a system brush
        /// (for example, one that was retrieved by the <see cref="GetStockObject"/> or <see cref="GetSysColorBrush"/> function),
        /// the application does not need to free the brush.
        /// </para>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function selects the default system colors for the button.
        /// Buttons with the <see cref="BS_PUSHBUTTON"/>, <see cref="BS_DEFPUSHBUTTON"/>, or <see cref="BS_PUSHLIKE"/> styles do not use the returned brush.
        /// Buttons with these styles are always drawn with the default system colors.
        /// Drawing push buttons requires several different brushes-face, highlight,
        /// and shadow-but the <see cref="WM_CTLCOLORBTN"/> message allows only one brush to be returned.
        /// To provide a custom appearance for push buttons, use an owner-drawn button.
        /// For more information, see Creating Owner-Drawn Controls.
        /// </para>
        /// <para>
        /// The <see cref="WM_CTLCOLORBTN"/> message is never sent between threads.
        /// It is sent only within one thread.
        /// </para>
        /// <para>
        /// The text color of a check box or radio button applies to the box or button, its check mark, and the text.
        /// The focus rectangle for these buttons remains the system default color (typically black).
        /// The text color of a group box applies to the text but not to the line that defines the box.
        /// The text color of a push button applies only to its focus rectangle; it does not affect the color of the text.
        /// </para>
        /// <para>
        /// If a dialog box procedure handles this message,
        /// it should cast the desired return value to a <see cref="INT_PTR"/> and return the value directly.
        /// If the dialog box procedure returns <see cref="FALSE"/>, then default message handling is performed.
        /// The <see cref="DWL_MSGRESULT"/> value set by the <see cref="SetWindowLong"/> function is ignored.
        /// </para>
        /// </remarks>
        WM_CTLCOLORBTN = 0x0135,

        #endregion

        #region Clipboard Messages

        /// <summary>
        /// <para>
        /// An application sends a <see cref="WM_CUT"/> message to an edit control or combo box to delete (cut) the current selection,
        /// if any, in the edit control and copy the deleted text to the clipboard in <see cref="CF_TEXT"/> format.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message does not return a value.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The deletion performed by the <see cref="WM_CUT"/> message can be undone by sending the edit control an <see cref="EM_UNDO"/> message.
        /// </para>
        /// <para>
        /// To delete the current selection without placing the deleted text on the clipboard, use the <see cref="WM_CLEAR"/> message.
        /// </para>
        /// <para>
        /// When sent to a combo box, the <see cref="WM_CUT"/> message is handled by its edit control.
        /// This message has no effect when sent to a combo box with the <see cref="CBS_DROPDOWNLIST"/> style.
        /// </para>
        /// </remarks>
        WM_CUT = 0x0300,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_COPY"/> message to an edit control or combo box
        /// to copy the current selection to the clipboard in <see cref="CF_TEXT"/> format.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Always returns zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// When sent to a combo box, the <see cref="WM_COPY"/> message is handled by its edit control.
        /// This message has no effect when sent to a combo box with the <see cref="CBS_DROPDOWNLIST"/> style.
        /// </remarks>
        WM_COPY = 0x0301,

        /// <summary>
        /// <para>
        /// An application sends a <see cref="WM_PASTE"/> message to an edit control or combo box
        /// to copy the current content of the clipboard to the edit control at the current caret position.
        /// Data is inserted only if the clipboard contains data in <see cref="CF_TEXT"/> format.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message does not return a value.
        /// </para>
        /// </summary>
        /// <remarks>
        /// When sent to a combo box, the <see cref="WM_PASTE"/> message is handled by its edit control.
        /// This message has no effect when sent to a combo box with the <see cref="CBS_DROPDOWNLIST"/> style.
        /// </remarks>
        WM_PASTE = 0x0302,

        /// <summary>
        /// <para>
        /// An application sends a <see cref="WM_CLEAR"/> message to an edit control or combo box to delete (clear) the current selection,
        /// if any, from the edit control. 
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message does not return a value.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The deletion performed by the <see cref="WM_CLEAR"/> message can be undone by sending the edit control an <see cref="EM_UNDO"/> message.
        /// </para>
        /// <para>
        /// To delete the current selection and place the deleted content on the clipboard, use the <see cref="WM_CUT"/> message.
        /// </para>
        /// <para>
        /// When sent to a combo box, the <see cref="WM_CLEAR"/> message is handled by its edit control.
        /// This message has no effect when sent to a combo box with the <see cref="CBS_DROPDOWNLIST"/> style.
        /// </para>
        /// </remarks>
        WM_CLEAR = 0x0303,

        #endregion

        #region Clipboard Notifications

        /// <summary>
        /// <para>
        /// Sent to the clipboard owner by a clipboard viewer window to request the name of a <see cref="CF_OWNERDISPLAY"/> clipboard format.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The size, in characters, of the buffer pointed to by the lParam parameter.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to the buffer that is to receive the clipboard format name.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// In response to this message, the clipboard owner should copy the name of the owner-display format to the specified buffer,
        /// not exceeding the buffer size specified by the wParam parameter.
        /// </para>
        /// <para>
        /// A clipboard viewer window sends this message to the clipboard owner to determine the name of the <see cref="CF_OWNERDISPLAY"/> format
        /// for example, to initialize a menu listing available formats.
        /// </para>
        /// </remarks>
        WM_ASKCBFORMATNAME = 0x030C,

        /// <summary>
        /// <para>
        /// Sent to the first window in the clipboard viewer chain when a window is being removed from the chain.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the window being removed from the clipboard viewer chain.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the next window in the chain following the window being removed.
        /// This parameter is <see cref="NULL"/> if the window being removed is the last window in the chain.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Each clipboard viewer window saves the handle to the next window in the clipboard viewer chain.
        /// Initially, this handle is the return value of the <see cref="SetClipboardViewer"/> function.
        /// </para>
        /// <para>
        /// When a clipboard viewer window receives the <see cref="WM_CHANGECBCHAIN"/> message,
        /// it should call the <see cref="SendMessage"/> function to pass the message to the next window in the chain,
        /// unless the next window is the window being removed.
        /// In this case, the clipboard viewer should save the handle specified by the lParam parameter as the next window in the chain.
        /// </para>
        /// </remarks>
        WM_CHANGECBCHAIN = 0x30D,

        /// <summary>
        /// <para>
        /// Sent when the contents of the clipboard have changed.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// To register a window to receive this message, use the <see cref="AddClipboardFormatListener"/> function.
        /// </remarks>
        WM_CLIPBOARDUPDATE = 0x31D,

        /// <summary>
        /// <para>
        /// Sent to the clipboard owner when a call to the <see cref="EmptyClipboard"/> function empties the clipboard.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        WM_DESTROYCLIPBOARD = 0x307,

        /// <summary>
        /// <para>
        /// Sent to the first window in the clipboard viewer chain when the content of the clipboard changes.
        /// This enables a clipboard viewer window to display the new content of the clipboard.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Only clipboard viewer windows receive this message.
        /// These are windows that have been added to the clipboard viewer chain by using the <see cref="SetClipboardViewer"/> function.
        /// </para>
        /// <para>
        /// Each window that receives the <see cref="WM_DRAWCLIPBOARD"/> message must call the <see cref="SendMessage"/> function
        /// to pass the message on to the next window in the clipboard viewer chain.
        /// The handle to the next window in the chain is returned by <see cref="SetClipboardViewer"/>,
        /// and may change in response to a <see cref="WM_CHANGECBCHAIN"/> message.
        /// </para>
        /// </remarks>
        WM_DRAWCLIPBOARD = 0x308,

        /// <summary>
        /// <para>
        /// Sent to the clipboard owner by a clipboard viewer window.
        /// This occurs when the clipboard contains data in the <see cref="CF_OWNERDISPLAY"/> format
        /// and an event occurs in the clipboard viewer's horizontal scroll bar.
        /// The owner should scroll the clipboard image and update the scroll bar values.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the clipboard viewer window.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word of lParam specifies a scroll bar event.
        /// This parameter can be one of the following values.
        /// The high-order word of lParam specifies the current position of the scroll box
        /// if the low-order word of lParam is <see cref="SB_THUMBPOSITION"/>;
        /// otherwise, the high-order word is not used.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_ENDSCROLL"/>
        /// </para>
        /// <para>
        /// 8
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// End scroll.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_LEFT"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Scroll to upper left.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_RIGHT"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Scroll to lower right.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_LINELEFT"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Scrolls left by one unit.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_LINERIGHT"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Scrolls right by one unit.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_PAGELEFT"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Scrolls left by the width of the window.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_PAGERIGHT"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Scrolls right by the width of the window.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_THUMBPOSITION"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// Scroll to absolute position. The current position is specified by the high-order word.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The clipboard owner can use the <see cref="ScrollWindow"/> function
        /// to scroll the image in the clipboard viewer window and invalidate the appropriate region.
        /// </remarks>
        WM_HSCROLLCLIPBOARD = 0x030E,

        /// <summary>
        /// <para>
        /// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the <see cref="CF_OWNERDISPLAY"/> format
        /// and the clipboard viewer's client area needs repainting.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the clipboard viewer window.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to a global memory object that contains a <see cref="PAINTSTRUCT"/> structure.
        /// The structure defines the part of the client area to paint.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// To determine whether the entire client area or just a portion of it needs repainting,
        /// the clipboard owner must compare the dimensions of the drawing area
        /// given in the <see cref="PAINTSTRUCT.rcPaint"/> member of <see cref="PAINTSTRUCT"/> to the dimensions
        /// given in the most recent <see cref="WM_SIZECLIPBOARD"/> message.
        /// </para>
        /// <para>
        /// The clipboard owner must use the <see cref="GlobalLock"/> function to lock the memory
        /// that contains the <see cref="PAINTSTRUCT"/> structure.
        /// Before returning, the clipboard owner must unlock that memory by using the <see cref="GlobalUnlock"/> function.
        /// </para>
        /// </remarks>
        WM_PAINTCLIPBOARD = 0x309,

        /// <summary>
        /// <para>
        /// Sent to the clipboard owner before it is destroyed,
        /// if the clipboard owner has delayed rendering one or more clipboard formats.
        /// For the content of the clipboard to remain available to other applications,
        /// the clipboard owner must render data in all the formats it is capable of generating,
        /// and place the data on the clipboard by calling the <see cref="SetClipboardData"/> function.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// When responding to a <see cref="WM_RENDERALLFORMATS"/> message, the application must call the <see cref="OpenClipboard"/> function
        /// and then check that it is still the clipboard owner by calling the <see cref="GetClipboardOwner"/> function before calling <see cref="SetClipboardData"/>.
        /// </para>
        /// <para>
        /// The application needs to check that it is still the clipboard owner after opening the clipboard
        /// because after it receives the <see cref="WM_RENDERALLFORMATS"/> message, but before it opens the clipboard,
        /// another application may have opened and taken ownership of the clipboard, and that application's data should not be overwritten.
        /// </para>
        /// <para>
        /// In most cases, the application should not call the <see cref="EmptyClipboard"/> function before calling <see cref="SetClipboardData"/>,
        /// since doing so will erase the clipboard formats that the application has already rendered.
        /// </para>
        /// <para>
        /// When the application returns, the system removes any unrendered formats from the list of available clipboard formats.
        /// For information about delayed rendering, see Delayed Rendering.
        /// </para>
        /// </remarks>
        WM_RENDERALLFORMATS = 0x306,

        /// <summary>
        /// <para>
        /// Sent to the clipboard owner if it has delayed rendering a specific clipboard format and if an application has requested data in that format.
        /// The clipboard owner must render data in the specified format and place it on the clipboard by calling the <see cref="SetClipboardData"/> function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The clipboard format to be rendered.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// When responding to a <see cref="WM_RENDERFORMAT"/> message,
        /// the clipboard owner must not open the clipboard before calling <see cref="SetClipboardData"/>.
        /// Opening the clipboard is not necessary before placing data in response to <see cref="WM_RENDERFORMAT"/>,
        /// and any attempt to open the clipboard will fail
        /// because the clipboard is currently being held open by the application that requested the format to be rendered.
        /// </remarks>
        WM_RENDERFORMAT = 0x305,

        /// <summary>
        /// <para>
        /// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the <see cref="CF_OWNERDISPLAY"/> format
        /// and the clipboard viewer's client area has changed size.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the clipboard viewer window.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to a global memory object that contains a <see cref="RECT"/> structure.
        /// The structure specifies the new dimensions of the clipboard viewer's client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// When the clipboard viewer window is about to be destroyed or resized,
        /// a <see cref="WM_SIZECLIPBOARD"/> message is sent with a null rectangle (0, 0, 0, 0) as the new size.
        /// This permits the clipboard owner to free its display resources.
        /// </para>
        /// <para>
        /// The clipboard owner must use the <see cref="GlobalLock"/> function to lock the memory object that contains <see cref="RECT"/>.
        /// Before returning, the clipboard owner must unlock the object by using the <see cref="GlobalUnlock"/> function.
        /// </para>
        /// </remarks>
        WM_SIZECLIPBOARD = 0x30B,

        /// <summary>
        /// <para>
        /// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the <see cref="CF_OWNERDISPLAY"/> format
        /// and an event occurs in the clipboard viewer's vertical scroll bar.
        /// The owner should scroll the clipboard image and update the scroll bar values.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the clipboard viewer window.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word of lParam specifies a scroll bar event. This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_BOTTOM"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Scroll to lower right.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_ENDSCROLL"/>
        /// </para>
        /// <para>
        /// 8
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// End scroll.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_LINEDOWN"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Scroll one line down.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_LINEUP"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Scroll one line up.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_PAGEDOWN"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Scroll one page down.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_PAGEUP"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Scroll one page up.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_THUMBPOSITION"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Scroll to absolute position. The current position is specified by the high-order word.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SB_TOP"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// Scroll to upper left.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The high-order word of lParam specifies the current position of the scroll box if the low-order word of lParam is <see cref="SB_THUMBPOSITION"/>;
        /// otherwise, the high-order word of lParam is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The clipboard owner can use the <see cref="ScrollWindow"/> function
        /// to scroll the image in the clipboard viewer window and invalidate the appropriate region.
        /// </remarks>
        WM_VSCROLLCLIPBOARD = 0x30A,

        #endregion

        #region Color Messages

        /// <summary>
        /// <para>
        /// The <see cref="WM_PALETTECHANGED"/> message is sent to all top-level and overlapped windows
        /// after the window with the keyboard focus has realized its logical palette, thereby changing the system palette.
        /// This message enables a window that uses a color palette but does not have the keyboard focus
        /// to realize its logical palette and update its client area.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the window that caused the system palette to change.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-palettechanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message must be sent to all top-level and overlapped windows, including the one that changed the system palette.
        /// If any child windows use a color palette, this message must be passed on to them as well.
        /// </para>
        /// <para>
        /// To avoid creating an infinite loop, a window that receives this message must not realize its palette,
        /// unless it determines that wParam does not contain its own window handle.
        /// </para>
        /// </remarks>
        WM_PALETTECHANGED = 0x0311,

        /// <summary>
        /// <para>
        /// The <see cref="WM_PALETTEISCHANGING"/> message informs applications that an application is going to realize its logical palette.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the window that is going to realize its logical palette.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-paletteischanging"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The application changing its palette does not wait for acknowledgment of this message
        /// before changing the palette and sending the <see cref="WM_PALETTECHANGED"/> message.
        /// As a result, the palette may already be changed by the time an application receives this message.
        /// </para>
        /// <para>
        /// If the application either ignores or fails to process this message and a second application
        /// realizes its palette while the first is using palette indexes,
        /// there is a strong possibility that the user will see unexpected colors during subsequent drawing operations.
        /// </para>
        /// </remarks>
        WM_PALETTEISCHANGING = 0x0310,

        /// <summary>
        /// <para>
        /// The <see cref="WM_QUERYNEWPALETTE"/> message informs a window that it is about to receive the keyboard focus,
        /// giving the window the opportunity to realize its logical palette when it receives the focus.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the window realizes its logical palette, it must return <see cref="TRUE"/>; otherwise, it must return <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-querynewpalette"/>
        /// </para>
        /// </summary>
        WM_QUERYNEWPALETTE = 0x030F,

        /// <summary>
        /// <para>
        /// The <see cref="WM_SYSCOLORCHANGE"/> message is sent to all top-level windows when a change is made to a system color setting.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-syscolorchange"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The system sends a <see cref="WM_PAINT"/> message to any window that is affected by a system color change.
        /// </para>
        /// <para>
        /// Applications that have brushes using the existing system colors should delete those brushes and re-create them using the new system colors.
        /// </para>
        /// <para>
        /// Top level windows that use common controls must forward the <see cref="WM_SYSCOLORCHANGE"/> message to the controls;
        /// otherwise, the controls will not be notified of the color change.
        /// This ensures that the colors used by your common controls are consistent with those used by other user interface objects.
        /// For example, a toolbar control uses the "3D Objects" color to draw its buttons.
        /// If the user changes the 3D Objects color but the <see cref="WM_SYSCOLORCHANGE"/> message is not forwarded to the toolbar,
        /// the toolbar buttons will remain in their original color while the color of other buttons in the system changes.
        /// </para>
        /// </remarks>
        WM_SYSCOLORCHANGE = 0x0015,

        #endregion

        #region Common Dialog Box Messages

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_CHOOSEFONT_GETLOGFONT"/> message to a Font dialog box
        /// to retrieve information about the user's current font selections.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="LOGFONT"/> structure that receives information about the user's current font selections.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message does not return a value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dlgbox/wm-choosefont-getlogfont"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="ChooseFont"/> function creates a Font dialog box.
        /// When the user closes the Font dialog box, the <see cref="ChooseFont"/> function returns information
        /// about the user's font selections in the <see cref="CHOOSEFONT"/> structure.
        /// The <see cref="CHOOSEFONT.lpLogFont"/> member of the <see cref="CHOOSEFONT"/> structure is a pointer to a <see cref="LOGFONT"/> structure.
        /// </para>
        /// <para>
        /// Use the <see cref="WM_CHOOSEFONT_GETLOGFONT"/> message to get information about the user's current font selections while the Font dialog box is open.
        /// For example, if you enable the Apply button in the Font dialog box,
        /// send the message to get the font information to apply to the current text selection.
        /// </para>
        /// <para>
        /// Typically, you enable a  hook procedure to process <see cref="WM_COMMAND"/> messages for the Apply button.
        /// When the user clicks the Apply button, the hook procedure sends the <see cref="WM_CHOOSEFONT_GETLOGFONT"/> message to the dialog box.
        /// </para>
        /// </remarks>
        WM_CHOOSEFONT_GETLOGFONT = WM_USER + 1,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_CHOOSEFONT_SETFLAGS"/> message to a Font dialog box to set the display options for the dialog box.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="CHOOSEFONT"/> structure that contains new settings in the <see cref="CHOOSEFONT.Flags"/> member.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// No return value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dlgbox/wm-choosefont-setflags"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="ChooseFont"/> function creates a Font dialog box and uses a <see cref="CHOOSEFONT"/> structure
        /// to specify the initial values for the <see cref="CHOOSEFONT.Flags"/> member.
        /// Use the <see cref="WM_CHOOSEFONT_SETFLAGS"/> message to specify different values
        /// for the <see cref="CHOOSEFONT.Flags"/> member while the Font dialog box is open.
        /// </para>
        /// <para>
        /// Typically, you should send the <see cref="WM_CHOOSEFONT_SETFLAGS"/> message from a CFHookProc hook procedure.
        /// </para>
        /// </remarks>
        WM_CHOOSEFONT_SETFLAGS = WM_USER + 102,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_CHOOSEFONT_SETLOGFONT"/> message to a Font dialog box to set the current logical font information.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="LOGFONT"/> structure that contains information about the current logical font.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message has no return value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dlgbox/wm-choosefont-setlogfont"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// When you call the <see cref="ChooseFont"/> function to create a Font dialog box,
        /// you can use the <see cref="CHOOSEFONT.lpLogFont"/> member of the <see cref="CHOOSEFONT"/> structure
        /// to specify a <see cref="LOGFONT"/> structure containing initial values for the dialog box.
        /// Use the <see cref="WM_CHOOSEFONT_SETLOGFONT"/> message to specify a <see cref="LOGFONT"/> structure
        /// with different values while the Font dialog box is open.
        /// </para>
        /// <para>
        /// Typically, you would send the <see cref="WM_CHOOSEFONT_SETLOGFONT"/> message from a CFHookProc hook procedure.
        /// The hook procedure can also send the <see cref="WM_CHOOSEFONT_GETLOGFONT"/> and <see cref="WM_CHOOSEFONT_SETFLAGS"/> messages.
        /// </para>
        /// </remarks>
        WM_CHOOSEFONT_SETLOGFONT = WM_USER + 101,

        #endregion

        #region Common Dialog Box Notifications

        /// <summary>
        /// <para>
        /// Notifies the hook procedure of a Page Setup dialog box, PagePaintHook,
        /// that the dialog box is about to draw the envelope-stamp rectangle of the sample page.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the device context for the sample page.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates, in pixels, of the envelope-stamp rectangle.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="TRUE"/>, the dialog box does not draw the envelope-stamp portion of the sample page.
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="FALSE"/>, the dialog box draws the envelope-stamp portion of the sample page.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The Page Setup dialog box includes an image of a sample page
        /// that shows how the user's selections affect the appearance of the printed output.
        /// When you call the <see cref="PageSetupDlg"/> function,
        /// you can provide a PagePaintHook hook procedure to customize the appearance of the sample page.
        /// Whenever the dialog box is about to draw the contents of the sample page,
        /// the dialog box sends a sequence of messages to the hook procedure.
        /// </para>
        /// <para>
        /// A hook procedure receives this message only if the selected paper type is an envelope.
        /// </para>
        /// </remarks>
        WM_PSD_ENVSTAMPRECT = WM_USER + 5,

        /// <summary>
        /// <para>
        /// Notifies a PagePaintHook hook procedure of the coordinates of the sample page rectangle in the Page Setup dialog box.
        /// The dialog box sends this message when it is about to draw the contents of the sample page.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the device context for the sample page.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates, in pixels, of the sample page.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="TRUE"/>, the dialog box sends no more messages and does not draw in the sample page
        /// until the next time the system needs to redraw the sample page.
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="FALSE"/>, the dialog box sends the remaining messages of the drawing sequence.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The Page Setup dialog box includes an image of a sample page
        /// that shows how the user's selections affect the appearance of the printed output.
        /// When you call the <see cref="PageSetupDlg"/> function,
        /// you can provide a PagePaintHook hook procedure to customize the appearance of the sample page.
        /// Whenever the dialog box is about to draw the contents of the sample page,
        /// the dialog box sends a sequence of messages to the hook procedure.
        /// </remarks>
        WM_PSD_FULLPAGERECT = WM_USER + 1,

        /// <summary>
        /// <para>
        /// Notifies the hook procedure of a Page Setup dialog box, PagePaintHook,
        /// that the dialog box is about to draw Greek text inside the margin rectangle of the sample page.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the device context for the sample page.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates, in pixels, of the Greek text rectangle.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="TRUE"/>, the dialog box does not draw the Greek text portion of the sample page.
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="FALSE"/>, the dialog box draws the Greek text portion of the sample page.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The Page Setup dialog box includes an image of a sample page
        /// that shows how the user's selections affect the appearance of the printed output.
        /// When you call the <see cref="PageSetupDlg"/> function,
        /// you can provide a PagePaintHook hook procedure to customize the appearance of the sample page.
        /// Whenever the dialog box is about to draw the contents of the sample page,
        /// the dialog box sends a sequence of messages to the hook procedure.
        /// </remarks>
        WM_PSD_GREEKTEXTRECT = WM_USER + 4,

        /// <summary>
        /// <para>
        /// Notifies the hook procedure of a Page Setup dialog box, PagePaintHook,
        /// that the dialog box is about to draw the margin rectangle of the sample page.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the device context for the sample page.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates, in pixels, of the margin rectangle.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="TRUE"/>, the dialog box does not draw the margin rectangle in the sample page.
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="FALSE"/>, the dialog box draws the margin rectangle in the sample page.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The Page Setup dialog box includes an image of a sample page
        /// that shows how the user's selections affect the appearance of the printed output.
        /// When you call the <see cref="PageSetupDlg"/> function,
        /// you can provide a PagePaintHook hook procedure to customize the appearance of the sample page.
        /// Whenever the dialog box is about to draw the contents of the sample page,
        /// the dialog box sends a sequence of messages to the hook procedure.
        /// </remarks>
        WM_PSD_MARGINRECT = WM_USER + 3,

        /// <summary>
        /// <para>
        /// Notifies a PagePaintHook hook procedure of the coordinates of the margin rectangle in the sample page.
        /// A Page Setup dialog box sends this message when it is about to draw the contents of the sample page.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the device context for the sample page.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates, in pixels, of the minimum margin rectangle.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="TRUE"/>, the dialog box sends no more messages
        /// and does not draw in the sample page until the next time the system needs to redraw the sample page.
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="FALSE"/>, the dialog box sends the remaining messages of the drawing sequence.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The Page Setup dialog box includes an image of a sample page
        /// that shows how the user's selections affect the appearance of the printed output.
        /// When you call the <see cref="PageSetupDlg"/> function,
        /// you can provide a PagePaintHook hook procedure to customize the appearance of the sample page.
        /// Whenever the dialog box is about to draw the contents of the sample page,
        /// the dialog box sends a sequence of messages to the hook procedure.
        /// </remarks>
        WM_PSD_MINMARGINRECT = WM_USER + 2,

        /// <summary>
        /// <para>
        /// Notifies a PagePaintHook hook procedure that the Page Setup dialog box is about to draw the contents of the sample page.
        /// The hook procedure can use this message to carry out initialization tasks related to drawing the contents of the sample page.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word specifies a value that indicates the paper size. 
        /// This value can be one of the DMPAPER_ values listed in the description of the structure.
        /// The high-order word specifies the orientation of the paper or envelope,
        /// and whether the printer is a dot matrix or HPPCL (Hewlett Packard Printer Control Language) device.
        /// This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0x0001
        /// </term>
        /// <term>
        /// <para>
        /// Paper in landscape mode (dot matrix)
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0x0003
        /// </term>
        /// <term>
        /// <para>
        /// Paper in landscape mode (HPPCL)
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0x0005
        /// </term>
        /// <term>
        /// <para>
        /// Paper in portrait mode (dot matrix)
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0x0007
        /// </term>
        /// <term>
        /// <para>
        /// Paper in portrait mode (HPPCL)
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0x000b
        /// </term>
        /// <term>
        /// <para>
        /// Envelope in landscape mode (HPPCL)
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0x000d
        /// </term>
        /// <term>
        /// <para>
        /// Envelope in portrait mode (dot matrix)
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0x0019
        /// </term>
        /// <term>
        /// <para>
        /// Envelope in landscape mode (dot matrix)
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0x001f
        /// </term>
        /// <term>
        /// Envelope in portrait mode (HPPCL)
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="PAGESETUPDLG"/> structure that contains information used to initialize the Page Setup dialog box.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="TRUE"/>, the dialog box sends no more messages and does not draw in the sample page
        /// until the next time the system needs to redraw the sample page.
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="FALSE"/>, the dialog box sends the remaining messages of the drawing sequence.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The Page Setup dialog box includes an image of a sample page
        /// that shows how the user's selections affect the appearance of the printed output.
        /// When you call the <see cref="PageSetupDlg"/> function,
        /// you can provide a PagePaintHook hook procedure to customize the appearance of the sample page.
        /// Whenever the dialog box is about to draw the contents of the sample page,
        /// the dialog box sends a sequence of messages to the hook procedure.
        /// </para>
        /// <para>
        /// The first three messages of a drawing sequence (<see cref="WM_PSD_PAGESETUPDLG"/>, <see cref="WM_PSD_FULLPAGERECT"/>,
        /// or <see cref="WM_PSD_MINMARGINRECT"/>) provide information that the hook procedure can use to draw the contents of the sample page.
        /// The remaining messages (<see cref="WM_PSD_MARGINRECT"/>, <see cref="WM_PSD_GREEKTEXTRECT"/>,
        /// <see cref="WM_PSD_ENVSTAMPRECT"/>, <see cref="WM_PSD_YAFULLPAGERECT"/>) notify the hook procedure
        /// that the dialog box is about to draw a specific portion of the sample page.
        /// This allows the hook procedure to selectively draw portions of the sample page.
        /// </para>
        /// </remarks>
        WM_PSD_PAGESETUPDLG = WM_USER,

        /// <summary>
        /// <para>
        /// Notifies the hook procedure of a Page Setup dialog box, PagePaintHook,
        /// that the dialog box is about to draw the return address portion of an envelope sample page.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the device context for the sample page.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="RECT"/> structure that contains the coordinates, in pixels, of the sample page.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="TRUE"/>, the dialog box does not draw the return address portion of an envelope sample page.
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="FALSE"/>, the dialog box draws the return address portion of an envelope sample page.
        /// </para>
        /// <para>
        /// If the paper type is not an envelope, the return value has no effect.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The Page Setup dialog box includes an image of a sample page
        /// that shows how the user's selections affect the appearance of the printed output.
        /// When you call the <see cref="PageSetupDlg"/> function,
        /// you can provide a PagePaintHook hook procedure to customize the appearance of the sample page.
        /// Whenever the dialog box is about to draw the contents of the sample page,
        /// the dialog box sends a sequence of messages to the hook procedure.
        /// </remarks>
        WM_PSD_YAFULLPAGERECT = WM_USER + 6,

        #endregion

        #region ComboBox Control Notifications

        /// <summary>
        /// <para>
        /// Sent to determine the relative position of a new item in the sorted list of an owner-drawn combo box or list box.
        /// Whenever the application adds a new item, the system sends this message to the owner of a combo box or list box
        /// created with the <see cref="CBS_SORT"/> or <see cref="LBS_SORT"/> style.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Specifies the identifier of the control that sent the <see cref="WM_COMPAREITEM"/> message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Pointer to a <see cref="COMPAREITEMSTRUCT"/> structure
        /// that contains the identifiers and application-supplied data for two items in the combo or list box.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value indicates the relative position of the two items. It may be any of the values shown in the following table.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="Value"/>
        /// </term>
        /// <term>
        /// <para>
        /// Meaning
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// -1
        /// </term>
        /// <term>
        /// <para>
        /// Item 1 precedes item 2 in the sorted order.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// <para>
        /// Items 1 and 2 are equivalent in the sorted order.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Item 1 follows item 2 in the sorted order.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-compareitem"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// When the owner of an owner-drawn combo box or list box receives this message,
        /// the owner returns a value indicating which of the items
        /// specified by the <see cref="COMPAREITEMSTRUCT"/> structure will appear before the other.
        /// Typically, the system sends this message several times until it determines the exact position for the new item.
        /// </para>
        /// <para>
        /// If a dialog box procedure handles this message,
        /// it should cast the desired return value to a <see cref="BOOL"/> and return the value directly.
        /// The <see cref="DWL_MSGRESULT"/> value set by the <see cref="SetWindowLong"/> function is ignored.
        /// </para>
        /// </remarks>
        WM_COMPAREITEM = 0x0039,

        /// <summary>
        /// <para>
        /// Sent to the parent window of an owner-drawn button, combo box, list box, or menu
        /// when a visual aspect of the button, combo box, list box, or menu has changed.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Specifies the identifier of the control that sent the <see cref="WM_DRAWITEM"/> message.
        /// If the message was sent by a menu, this parameter is zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Pointer to a <see cref="DRAWITEMSTRUCT"/> structure containing information about the item to be drawn and the type of drawing required.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-drawitem"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function draws the focus rectangle for an owner-drawn list box item.
        /// </para>
        /// <para>
        /// The <see cref="DRAWITEMSTRUCT.itemAction"/> member of the <see cref="DRAWITEMSTRUCT"/> structure
        /// specifies the drawing operation that an application should perform.
        /// </para>
        /// <para>
        /// Before returning from processing this message, an application should ensure
        /// that the device context identified by the <see cref="DRAWITEMSTRUCT.hDC"/> member of the <see cref="DRAWITEMSTRUCT"/> structure is in the default state.
        /// </para>
        /// </remarks>
        WM_DRAWITEM = 0x002B,

        /// <summary>
        /// <para>
        /// Sent to the owner window of a combo box, list box, list-view control, or menu item when the control or menu is created.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains the value of the <see cref="MEASUREITEMSTRUCT.CtlID"/> member
        /// of the <see cref="MEASUREITEMSTRUCT"/> structure pointed to by the lParam parameter.
        /// This value identifies the control that sent the <see cref="WM_MEASUREITEM"/> message.
        /// If the message was sent by a menu, this parameter is zero.
        /// If the value is nonzero or the value is zero and the value of the <see cref="MEASUREITEMSTRUCT.CtlType"/> member
        /// of the <see cref="MEASUREITEMSTRUCT"/> pointed to by lParam is not <see cref="ODT_MENU"/>,
        /// the message was sent by a combo box or by a list box.
        /// If the value is nonzero, and the value of the <see cref="MEASUREITEMSTRUCT.itemID"/> member
        /// of the <see cref="MEASUREITEMSTRUCT"/> pointed to by lParam is (UINT) 1,
        /// the message was sent by a combo edit field.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Pointer to a <see cref="MEASUREITEMSTRUCT"/> structure that contains the dimensions of the owner-drawn control or menu item.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-measureitem"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// When the owner window receives the <see cref="WM_MEASUREITEM"/> message,
        /// the owner fills in the <see cref="MEASUREITEMSTRUCT"/> structure pointed to by the lParam parameter of the message and returns;
        /// this informs the system of the dimensions of the control.
        /// If a list box or combo box is created with the <see cref="LBS_OWNERDRAWVARIABLE"/> or <see cref="CBS_OWNERDRAWVARIABLE"/> style,
        /// this message is sent to the owner for each item in the control; otherwise, this message is sent once.
        /// </para>
        /// <para>
        /// The system sends the <see cref="WM_MEASUREITEM"/> message to the owner window of combo boxes and list boxes
        /// created with the OWNERDRAWFIXED style before sending the <see cref="WM_INITDIALOG"/> message.
        /// As a result, when the owner receives this message, the system has not yet determined the height and width of the font used in the control;
        /// function calls and calculations requiring these values should occur in the main function of the application or library.
        /// </para>
        /// </remarks>
        WM_MEASUREITEM = 0x002C,

        #endregion

        #region Control Messages

        /// <summary>
        /// <para>
        /// Sent by a common control to its parent window when an event has occurred or the control requires some information.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The identifier of the common control sending the message. This identifier is not guaranteed to be unique.
        /// An application should use the <see cref="NMHDR.hwndFrom"/> or <see cref="NMHDR.idFrom"/> member
        /// of the <see cref="NMHDR"/> structure (passed as the lParam parameter) to identify the control.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to an <see cref="NMHDR"/> structure that contains the notification code and additional information.
        /// For some notification messages, this parameter points to a larger structure that has the <see cref="NMHDR"/> structure as its first member.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is ignored except for notification messages that specify otherwise.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-notify"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The destination of the message must be the <see cref="HWND"/> of the parent of the control.
        /// This value can be obtained by using <see cref="GetParent"/>, as shown in the following example,
        /// where m_controlHwnd is the <see cref="HWND"/> of the control itself. 
        /// </para>
        /// <code>
        /// NMHDR nmh;
        /// nmh.code = CUSTOM_SELCHANGE;    // Message type defined by control.
        /// nmh.idFrom = GetDlgCtrlID(m_controlHwnd);
        /// nmh.hwndFrom = m_controlHwnd;
        /// SendMessage(GetParent(m_controlHwnd), 
        ///     WM_NOTIFY, 
        ///     nmh.idFrom, 
        ///     (LPARAM)&amp;nmh);
        /// </code>
        /// <para>
        /// Applications handle the message in the window procedure of the parent window, as shown in the following example,
        /// which handles the notification message sent by the custom control in the previous example. 
        /// </para>
        /// <code>
        /// INT_PTR CALLBACK DlgProc(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
        /// {
        ///     switch (message)
        ///     {
        ///     case WM_NOTIFY:
        ///         switch (((LPNMHDR)lParam)-&gt;code)
        ///         {
        ///         case CUSTOM_SELCHANGE:
        ///             if (((LPNMHDR)lParam)-&gt;idFrom == IDC_CUSTOMLISTBOX1)
        ///             {
        ///                 ...   // Respond to message.
        ///                 return TRUE;
        ///             }
        ///             break; 
        ///         ... // More cases on WM_NOTIFY switch.
        ///         break;
        ///         }
        ///     ...  // More cases on message switch.
        ///     }
        ///     return FALSE;
        /// }
        /// </code>
        /// <para>
        /// Some notifications, chiefly those that have been in the API for a long time, are sent as <see cref="WM_COMMAND"/> messages.
        /// For more information, see Control Messages.
        /// </para>
        /// <para>
        /// If the message handler is in a dialog box procedure,
        /// you must use the <see cref="SetWindowLong"/> function with <see cref="DWL_MSGRESULT"/> to set a return value.
        /// </para>
        /// <para>
        /// For Windows Vista and later systems, the <see cref="WM_NOTIFY"/> message cannot be sent between processes.
        /// </para>
        /// <para>
        /// Many notifications are available in both ANSI and Unicode formats.
        /// The window sending the <see cref="WM_NOTIFY"/> message uses the <see cref="WM_NOTIFYFORMAT"/> message to determine which format should be used.
        /// See <see cref="WM_NOTIFYFORMAT"/> for further discussion.
        /// </para>
        /// </remarks>
        WM_NOTIFY = 0x004E,

        /// <summary>
        /// <para>
        /// Determines if a window accepts ANSI or Unicode structures in the <see cref="WM_NOTIFY"/> notification message.
        /// <see cref="WM_NOTIFYFORMAT"/> messages are sent from a common control to its parent window and from the parent window to the common control.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the window that is sending the <see cref="WM_NOTIFYFORMAT"/> message.
        /// If lParam is <see cref="NF_QUERY"/>, this parameter is the handle to a control.
        /// If lParam is <see cref="NF_REQUERY"/>, this parameter is the handle to the parent window of a control.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The command value that specifies the nature of the <see cref="WM_NOTIFYFORMAT"/> message.
        /// This will be one of the following values:
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="NF_QUERY"/>
        /// </term>
        /// <term>
        /// The message is a query to determine whether ANSI or Unicode structures should be used in <see cref="WM_NOTIFY"/> messages.
        /// This command is sent from a control to its parent window during the creation of a control and in response to an <see cref="NF_REQUERY"/> command.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NF_REQUERY"/>
        /// </term>
        /// <term>
        /// The message is a request for a control to send an <see cref="NF_QUERY"/> form of this message to its parent window.
        /// This command is sent from the parent window.
        /// The parent window is asking the control to requery it about the type of structures to use in <see cref="WM_NOTIFY"/> messages.
        /// If lParam is <see cref="NF_REQUERY"/>, the return value is the result of the requery operation.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Returns one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="NFR_ANSI"/>
        /// </term>
        /// <term>
        /// ANSI structures should be used in <see cref="WM_NOTIFY"/> messages sent by the control.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NFR_UNICODE"/>
        /// </term>
        /// <term>
        /// Unicode structures should be used in <see cref="WM_NOTIFY"/> messages sent by the control.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// An error occurred.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-notifyformat"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// When a common control is created, the control sends a <see cref="WM_NOTIFYFORMAT"/> message
        /// to its parent window to determine the type of structures to use in <see cref="WM_NOTIFY"/> messages.
        /// If the parent window does not handle this message,
        /// the <see cref="DefWindowProc"/> function responds according to the type of the parent window.
        /// That is, if the parent window is a Unicode window, <see cref="DefWindowProc"/> returns <see cref="NFR_UNICODE"/>,
        /// and if the parent window is an ANSI window, <see cref="DefWindowProc"/> returns <see cref="NFR_ANSI"/>.
        /// If the parent window is a dialog box and does not handle this message,
        /// the <see cref="DefDlgProc"/> function similarly responds according to the type of the dialog box (Unicode or ANSI).
        /// </para>
        /// <para>
        /// A parent window can change the type of structures a common control uses in <see cref="WM_NOTIFY"/> messages
        /// by setting lParam to <see cref="NF_REQUERY"/> and sending a <see cref="WM_NOTIFYFORMAT"/> message to the control.
        /// This causes the control to send an <see cref="NF_QUERY"/> form of the <see cref="WM_NOTIFYFORMAT"/> message to the parent window.
        /// </para>
        /// <para>
        /// All common controls will send <see cref="WM_NOTIFYFORMAT"/> messages.
        /// However, the standard Windows controls (edit controls, combo boxes, list boxes, buttons, scroll bars, and static controls) do not.
        /// </para>
        /// </remarks>
        WM_NOTIFYFORMAT = 0x0055,

        #endregion

        #region Cursor Notifications

        /// <summary>
        /// <para>
        /// Sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the window that contains the cursor.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word of lParam specifies the hit-test result for the cursor position.
        /// See the return values for <see cref="WM_NCHITTEST"/> for possible values.
        /// </para>
        /// <para>
        /// The high-order word of lParam specifies the mouse window message which triggered this event, such as <see cref="WM_MOUSEMOVE"/>.
        /// When the window enters menu mode, this value is zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return <see cref="TRUE"/> to halt further processing or <see cref="FALSE"/> to continue.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The <see cref="DefWindowProc"/> function passes the <see cref="WM_SETCURSOR"/> message to a parent window before processing.
        /// If the parent window returns <see cref="TRUE"/>, further processing is halted.
        /// Passing the message to a window's parent window gives the parent window control over the cursor's setting in a child window.
        /// The <see cref="DefWindowProc"/> function also uses this message to set the cursor to an arrow if it is not in the client area,
        /// or to the registered class cursor if it is in the client area.
        /// If the low-order word of the lParam parameter is <see cref="HTERROR"/>
        /// and the high-order word of lParam specifies that one of the mouse buttons is pressed,
        /// <see cref="DefWindowProc"/> calls the <see cref="MessageBeep"/> function.
        /// </remarks>
        WM_SETCURSOR = 0x0020,

        #endregion

        #region Data Copy Message

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_COPYDATA"/> message to pass data to another application.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the window passing the data.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="COPYDATASTRUCT"/> structure that contains the data to be passed.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the receiving application processes this message, it should return <see cref="TRUE"/>;
        /// otherwise, it should return <see cref="FALSE"/>.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The data being passed must not contain pointers or other references to objects not accessible to the application receiving the data.
        /// </para>
        /// <para>
        /// While this message is being sent, the referenced data must not be changed by another thread of the sending process.
        /// </para>
        /// <para>
        /// The receiving application should consider the data read-only.
        /// The lParam parameter is valid only during the processing of the message.
        /// The receiving application should not free the memory referenced by lParam.
        /// If the receiving application must access the data after <see cref="SendMessage"/> returns,
        /// it must copy the data into a local buffer.
        /// </para>
        /// </remarks>
        WM_COPYDATA = 0x004A,

        #endregion

        #region Desktop Window Manager Messages

        /// <summary>
        /// <para>
        /// Informs all top-level windows that the colorization color has changed.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Specifies the new colorization color. The color format is 0xAARRGGBB.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Specifies whether the new color is blended with opacity.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// <see cref="DwmGetColorizationColor"/> is used to determine the current color value.
        /// </para>
        /// </remarks>
        WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320,

        /// <summary>
        /// <para>
        /// Informs all top-level windows that Desktop Window Manager (DWM) composition has been enabled or disabled.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// As of Windows 8, DWM composition is always enabled, so this message is not sent regardless of video mode changes.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// The <see cref="DwmIsCompositionEnabled"/> function can be used to determine the current composition state.
        /// </para>
        /// </remarks>
        WM_DWMCOMPOSITIONCHANGED = 0x031E,

        /// <summary>
        /// <para>
        /// Sent when the non-client area rendering policy has changed.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Specifies whether DWM rendering is enabled for the non-client area of the window.
        /// <see cref="TRUE"/> if enabled; otherwise, <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// The <see cref="DwmGetWindowAttribute"/> and <see cref="DwmSetWindowAttribute"/> functions are used to get or set the non-client rendering policy.
        /// </para>
        /// </remarks>
        WM_DWMNCRENDERINGCHANGED = 0x031F,

        /// <summary>
        /// <para>
        /// Instructs a window to provide a static bitmap to use as a live preview (also known as a Peek preview) of that window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A live preview (also known as a Peek preview) of a window appears when a user moves the mouse pointer
        /// over the window's thumbnail in the taskbar or gives the thumbnail focus in the ALT+TAB window.
        /// This view is a full-sized preview of the window and can be a live snapshot or an iconic representation.
        /// </para>
        /// <para>
        /// Desktop Window Manager (DWM) sends this message to a window if all of the following situations are true:
        /// </para>
        /// <para>
        /// The window that receives this message should respond by generating a full-scale bitmap.
        /// The window then calls the <see cref="DwmSetIconicLivePreviewBitmap"/> function to set the live preview.
        /// If the window does not set a bitmap in a given amount of time,
        /// DWM uses its own default iconic representation for the window.
        /// </para>
        /// </remarks>
        WM_DWMSENDICONICLIVEPREVIEWBITMAP = 0x0326,

        /// <summary>
        /// <para>
        /// Instructs a window to provide a static bitmap to use as a thumbnail representation of that window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The <see cref="HIWORD"/> of this value is the maximum x-coordinate of the thumbnail.
        /// The <see cref="LOWORD"/> is the maximum y-coordinate.
        /// If a thumbnail has a dimension that exceeds one or both of these values, the DWM does not accept the thumbnail.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// DWM sends this message to a window if all of the following situations are true:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// DWM is displaying an iconic representation of the window.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The <see cref="DWMWA_HAS_ICONIC_BITMAP"/> attribute is set on the window.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The window did not set a cached bitmap.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// There is room in the cache for another bitmap.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// The window that receives this message should respond by generating a bitmap
        /// that is not larger than the size that is requested in the message parameters.
        /// The window then calls the <see cref="DwmSetIconicThumbnail"/> function to override the default thumbnail.
        /// If the window does not supply a bitmap in a given amount of time,
        /// DWM uses its own default iconic representation for the window.
        /// </para>
        /// <para>
        /// The window must belong to the calling process.
        /// </para>
        /// </remarks>
        WM_DWMSENDICONICTHUMBNAIL = 0x0323,

        /// <summary>
        /// <para>
        /// Sent when a Desktop Window Manager (DWM) composed window is maximized.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Set to true to specify that the window has been maximized.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// A window receives this message through its WindowProc function.
        /// </remarks>
        WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321,

        #endregion

        #region Device Context Messages

        /// <summary>
        /// <para>
        /// The <see cref="WM_DEVMODECHANGE"/> message is sent to all top-level windows whenever the user changes device-mode settings.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a string that specifies the device name.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-devmodechange"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// This message cannot be sent directly to a window.
        /// To send the <see cref="WM_DEVMODECHANGE"/> message to all top-level windows,
        /// use the <see cref="SendMessageTimeout"/> function with the hWnd parameter set to <see cref="HWND_BROADCAST"/>.
        /// </remarks>
        WM_DEVMODECHANGE = 0x001B,

        #endregion

        #region Device Management Messages

        /// <summary>
        /// <para>
        /// Notifies an application of a change to the hardware configuration of a device or the computer.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The event that has occurred. This parameter can be one of the following values from the Dbt.h header file.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBT_DEVNODES_CHANGED"/>
        /// </para>
        /// <para>
        /// 0x0007
        /// </para>
        /// </term>
        /// <term>
        /// A device has been added to or removed from the system.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBT_QUERYCHANGECONFIG"/>
        /// </para>
        /// <para>
        /// 0x0017
        /// </para>
        /// </term>
        /// <term>
        /// Permission is requested to change the current configuration (dock or undock).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBT_CONFIGCHANGED"/>
        /// </para>
        /// <para>
        /// 0x0018
        /// </para>
        /// </term>
        /// <term>
        /// The current configuration has changed, due to a dock or undock.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBT_CONFIGCHANGECANCELED"/>
        /// </para>
        /// <para>
        /// 0x0019
        /// </para>
        /// </term>
        /// <term>
        /// A request to change the current configuration (dock or undock) has been canceled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBT_DEVICEARRIVAL"/>
        /// </para>
        /// <para>
        /// 0x8000
        /// </para>
        /// </term>
        /// <term>
        /// A device or piece of media has been inserted and is now available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBT_DEVICEQUERYREMOVE"/>
        /// </para>
        /// <para>
        /// 0x8001
        /// </para>
        /// </term>
        /// <term>
        /// Permission is requested to remove a device or piece of media.
        /// Any application can deny this request and cancel the removal.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBT_DEVICEQUERYREMOVEFAILED"/>
        /// </para>
        /// <para>
        /// 0x8002
        /// </para>
        /// </term>
        /// <term>
        /// A request to remove a device or piece of media has been canceled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBT_DEVICEREMOVEPENDING"/>
        /// </para>
        /// <para>
        /// 0x8003
        /// </para>
        /// </term>
        /// <term>
        /// A device or piece of media is about to be removed. Cannot be denied.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBT_DEVICEREMOVECOMPLETE"/>
        /// </para>
        /// <para>
        /// 0x8004
        /// </para>
        /// </term>
        /// <term>
        /// A device or piece of media has been removed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBT_DEVICETYPESPECIFIC"/>
        /// </para>
        /// <para>
        /// 0x8005
        /// </para>
        /// </term>
        /// <term>
        /// A device-specific event has occurred.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBT_CUSTOMEVENT"/>
        /// </para>
        /// <para>
        /// 0x8006
        /// </para>
        /// </term>
        /// <term>
        /// A custom event has occurred.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DBT_USERDEFINED"/>
        /// </para>
        /// <para>
        /// 0xFFFF
        /// </para>
        /// </term>
        /// <term>
        /// The meaning of this message is user-defined.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a structure that contains event-specific data.
        /// Its format depends on the value of the wParam parameter.
        /// For more information, refer to the documentation for each event.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Return <see cref="TRUE"/> to grant the request.
        /// </para>
        /// <para>
        /// Return <see cref="BROADCAST_QUERY_DENY"/> to deny the request.
        /// </para>
        /// </summary>
        /// <remarks>
        /// For devices that offer software-controllable features, such as ejection and locking,
        /// the system typically sends a <see cref="DBT_DEVICEREMOVEPENDING"/> message
        /// to let applications and device drivers end their use of the device gracefully.
        /// If the system forcibly removes a device, it may not send a <see cref="DBT_DEVICEQUERYREMOVE"/> message before doing so.
        /// </remarks>
        WM_DEVICECHANGE = 0x0219,

        #endregion

        #region Dialog Box Notifications

        /// <summary>
        /// <para>
        /// Sent to a dialog box before the system draws the dialog box.
        /// By responding to this message, the dialog box can set its text and background colors using the specified display device context handle.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the device context for the dialog box.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the dialog box.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it must return a handle to a brush.
        /// The system uses the brush to paint the background of the dialog box.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function selects the default system colors for the dialog box.
        /// </para>
        /// <para>
        /// The system does not automatically destroy the returned brush.
        /// It is the application's responsibility to destroy the brush when it is no longer needed.
        /// </para>
        /// <para>
        /// The <see cref="WM_CTLCOLORDLG"/> message is never sent between threads.
        /// It is sent only within one thread.
        /// </para>
        /// <para>
        /// Note that the <see cref="WM_CTLCOLORDLG"/> message is sent to the dialog box itself;
        /// all of the other WM_CTLCOLOR* messages are sent to the owner of the control.
        /// </para>
        /// <para>
        /// If a dialog box procedure handles this message,
        /// it should cast the desired return value to an <see cref="INT_PTR"/> and return the value directly.
        /// If the dialog box procedure returns <see cref="FALSE"/>, then default message handling is performed.
        /// The <see cref="DWL_MSGRESULT"/> value set by the <see cref="SetWindowLong"/> function is ignored.
        /// </para>
        /// </remarks>
        WM_CTLCOLORDLG = 0x0136,

        /// <summary>
        /// <para>
        /// Sent to the owner window of a modal dialog box or menu that is entering an idle state.
        /// A modal dialog box or menu enters an idle state when no messages are waiting in its queue after it has processed one or more previous messages.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the dialog box (if wParam is <see cref="MSGF_DIALOGBOX"/>)
        /// or window containing the displayed menu (if wParam is <see cref="MSGF_MENU"/>).
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// You can suppress the <see cref="WM_ENTERIDLE"/> message for a dialog box by creating the dialog box with the <see cref="DS_NOIDLEMSG"/> style.
        /// </remarks>
        WM_ENTERIDLE = 0x0121,

        /// <summary>
        /// <para>
        /// Sent to the window procedure associated with a control.
        /// By default, the system handles all keyboard input to the control;
        /// the system interprets certain types of keyboard input as dialog box navigation keys.
        /// To override this default behavior, the control can respond to the <see cref="WM_GETDLGCODE"/> message
        /// to indicate the types of input it wants to process itself.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The virtual key, pressed by the user, that prompted Windows to issue this notification.
        /// The handler must selectively handle these keys.
        /// For instance, the handler might accept and process <see cref="VK_RETURN"/> but delegate <see cref="VK_TAB"/> to the owner window.
        /// For a list of values, see Virtual-Key Codes.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to an <see cref="MSG"/> structure (or <see cref="NULL"/> if the system is performing a query).
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is one or more of the following values, indicating which type of input the application processes.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DLGC_BUTTON"/>
        /// </para>
        /// <para>
        /// 0x2000
        /// </para>
        /// </term>
        /// <term>
        /// Button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DLGC_DEFPUSHBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// Default push button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DLGC_HASSETSEL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// <see cref="EM_SETSEL"/> messages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DLGC_RADIOBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// Radio button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DLGC_STATIC"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// Static control.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DLGC_UNDEFPUSHBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// Non-default push button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DLGC_WANTALLKEYS"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// All keyboard input.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DLGC_WANTARROWS"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Direction keys.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DLGC_WANTCHARS"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// <see cref="WM_CHAR"/> messages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DLGC_WANTMESSAGE"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// All keyboard input (the application passes this message in the <see cref="MSG"/> structure to the control).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DLGC_WANTTAB"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// TAB key.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Although the <see cref="DefWindowProc"/> function always returns zero in response to the <see cref="WM_GETDLGCODE"/> message,
        /// the window procedure for the predefined control classes return a code appropriate for each class.
        /// </para>
        /// <para>
        /// The <see cref="WM_GETDLGCODE"/> message and the returned values are useful
        /// only with user-defined dialog box controls or standard controls modified by subclassing.
        /// </para>
        /// </remarks>
        WM_GETDLGCODE = 0x0087,

        /// <summary>
        /// <para>
        /// Sent to the dialog box procedure immediately before a dialog box is displayed.
        /// Dialog box procedures typically use this message to initialize controls
        /// and carry out any other initialization tasks that affect the appearance of the dialog box.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the control to receive the default keyboard focus.
        /// The system assigns the default keyboard focus only if the dialog box procedure returns <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Additional initialization data.
        /// This data is passed to the system as the lParam parameter in a call to the <see cref="CreateDialogIndirectParam"/>,
        /// <see cref="CreateDialogParam"/>, <see cref="DialogBoxIndirectParam"/>, or <see cref="DialogBoxParam"/> function used to create the dialog box.
        /// For property sheets, this parameter is a pointer to the <see cref="PROPSHEETPAGE"/> structure used to create the page.
        /// This parameter is zero if any other dialog box creation function is used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The dialog box procedure should return <see cref="TRUE"/> to direct the system to set the keyboard focus to the control specified by wParam.
        /// Otherwise, it should return <see cref="FALSE"/> to prevent the system from setting the default keyboard focus.
        /// </para>
        /// <para>
        /// The dialog box procedure should return the value directly.
        /// The <see cref="DWL_MSGRESULT"/> value set by the <see cref="SetWindowLong"/> function is ignored.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The control to receive the default keyboard focus is always the first control in the dialog box that is visible,
        /// not disabled, and that has the <see cref="WS_TABSTOP"/> style.
        /// When the dialog box procedure returns <see cref="TRUE"/>, the system checks the control to ensure that the procedure has not disabled it.
        /// If it has been disabled, the system sets the keyboard focus to the next control
        /// that is visible, not disabled, and has the <see cref="WS_TABSTOP"/>.
        /// </para>
        /// <para>
        /// An application can return <see cref="FALSE"/> only if it has set the keyboard focus to one of the controls of the dialog box.
        /// </para>
        /// </remarks>
        WM_INITDIALOG = 0x0110,

        /// <summary>
        /// <para>
        /// Sent to a dialog box procedure to set the keyboard focus to a different control in the dialog box.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// If lParam is <see cref="TRUE"/>, this parameter identifies the control that receives the focus.
        /// If lParam is <see cref="FALSE"/>, this parameter indicates
        /// whether the next or previous control with the <see cref="WS_TABSTOP"/> style receives the focus.
        /// If wParam is zero, the next control receives the focus;
        /// otherwise, the previous control with the <see cref="WS_TABSTOP"/> style receives the focus.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word indicates how the system uses wParam.
        /// If the low-order word is <see cref="TRUE"/>, wParam is a handle associated with the control that receives the focus;
        /// otherwise, wParam is a flag that indicates whether the next or previous control with the <see cref="WS_TABSTOP"/> style receives the focus.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message performs additional dialog box management operations beyond
        /// those performed by the <see cref="SetFocus"/> function <see cref="WM_NEXTDLGCTL"/> updates the default pushbutton border,
        /// sets the default control identifier, and automatically selects the text of an edit control (if the target window is an edit control).
        /// </para>
        /// <para>
        /// Do not use the <see cref="SendMessage"/> function to send a <see cref="WM_NEXTDLGCTL"/> message 
        /// if your application will concurrently process other messages that set the focus.
        /// Use the <see cref="PostMessage"/> function instead.
        /// </para>
        /// </remarks>
        WM_NEXTDLGCTL = 0x0028,

        #endregion

        #region Dynamic Data Exchange Messages

        /// <summary>
        /// <para>
        /// A Dynamic Data Exchange (DDE) client application sends a <see cref="WM_DDE_INITIATE"/> message
        /// to initiate a conversation with a server application responding to the specified application and topic names.
        /// Upon receiving this message, all server applications with names that match the specified application
        /// and that support the specified topic are expected to acknowledge it.
        /// (For more information, see the <see cref="WM_DDE_ACK"/> message.)
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the client window sending the message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word contains an atom that identifies the application with which a conversation is requested.
        /// The application name cannot contain slashes (/) or backslashes (\).
        /// These characters are reserved for network implementations.
        /// If this parameter is <see cref="NULL"/>, a conversation with all applications is requested.
        /// </para>
        /// <para>
        /// The high-order word contains an atom that identifies the topic for which a conversation is requested.
        /// If the topic is <see cref="NULL"/>, conversations for all available topics are requested.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the low-order word of lParam is <see cref="NULL"/>, any server application can respond.
        /// If the high-order word of lParam is <see cref="NULL"/>, any topic is valid.
        /// Upon receiving a <see cref="WM_DDE_INITIATE"/> request with the high-order word of the lParam parameter set to <see cref="NULL"/>,
        /// a server must send a <see cref="WM_DDE_ACK"/> message for each of the topics it supports.
        /// </para>
        /// <para>
        /// Sending
        /// </para>
        /// <para>
        /// The client broadcasts the message to all top-level windows
        /// by setting the first parameter of <see cref="SendMessage"/> to <see cref="HWND_BROADCAST"/>.
        /// </para>
        /// <para>
        /// If the client application has already obtained the window handle of the desired server,
        /// it can send <see cref="WM_DDE_INITIATE"/> directly to the server window
        /// by passing the server's window handle as the first parameter of <see cref="SendMessage"/>.
        /// </para>
        /// <para>
        /// The client application allocates atoms by calling the <see cref="GlobalAddAtom"/> function.
        /// </para>
        /// <para>
        /// When <see cref="SendMessage"/> returns, the client application must delete the atoms.
        /// </para>
        /// <para>
        /// Receiving
        /// </para>
        /// <para>
        /// To complete the initiation of a conversation,
        /// the server application must respond with one or more <see cref="WM_DDE_ACK"/> messages,
        /// where each message is for a separate topic.
        /// When sending <see cref="WM_DDE_ACK"/> message, the server should create new atoms;
        /// it should not reuse the atoms sent with <see cref="WM_DDE_INITIATE"/>.
        /// </para>
        /// </remarks>
        WM_DDE_INITIATE = 0x03E0,

        #endregion

        #region Dynamic Data Exchange Notifications

        /// <summary>
        /// <para>
        /// The <see cref="WM_DDE_ACK"/> message notifies a Dynamic Data Exchange (DDE) application
        /// of the receipt and processing of the following messages: <see cref="WM_DDE_POKE"/>, <see cref="WM_DDE_EXECUTE"/>,
        /// <see cref="WM_DDE_DATA"/>, <see cref="WM_DDE_ADVISE"/>, <see cref="WM_DDE_UNADVISE"/>,
        /// <see cref="WM_DDE_INITIATE"/>, or <see cref="WM_DDE_REQUEST"/> (in some cases).
        /// </para>
        /// <para>
        /// To post this message, call the <see cref="PostMessage"/> function with the following parameters.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// When responding to <see cref="WM_DDE_INITIATE"/>, this parameter is a handle to the server window sending the message.
        /// </para>
        /// <para>
        /// When responding to <see cref="WM_DDE_EXECUTE"/>, this parameter is a handle to the server window posting the message.
        /// </para>
        /// <para>
        /// When replying to all other messages, this parameter is a handle to the client or server window posting the message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// When responding to <see cref="WM_DDE_INITIATE"/>, the low-order word contains an atom that identifies the replying application.
        /// The high-order word contains an atom that identifies the topic for which a conversation is being established.
        /// </para>
        /// <para>
        /// When responding to <see cref="WM_DDE_EXECUTE"/>, the low-order word specifies a <see cref="DDEACK"/> structure
        /// containing a series of flags that indicate the status of the response.
        /// The high-order word is a handle to a global memory object that contains the command string
        /// that was received in the <see cref="WM_DDE_EXECUTE"/> message.
        /// </para>
        /// <para>
        /// When replying to all other messages, the low-order word specifies a <see cref="DDEACK"/> structure
        /// containing a series of flags that indicate the status of the response.
        /// The high-order word contains a global atom that identifies the name of the data item for which the response is sent.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Posting
        /// </para>
        /// <para>
        /// Except in response to the <see cref="WM_DDE_INITIATE"/> message,
        /// the application posts the <see cref="WM_DDE_ACK"/> message by calling the <see cref="PostMessage"/> function,
        /// not by calling the <see cref="SendMessage"/> function.
        /// When responding to <see cref="WM_DDE_INITIATE"/>,
        /// the application sends the <see cref="WM_DDE_ACK"/> message by calling <see cref="SendMessage"/>.
        /// In this case, neither the application-name atom nor the topic-name atom should be <see cref="NULL"/>
        /// (even if the <see cref="WM_DDE_INITIATE"/> message specified <see cref="NULL"/> atoms).
        /// </para>
        /// <para>
        /// When acknowledging any message with an accompanying atom,
        /// the application posting <see cref="WM_DDE_ACK"/> can either reuse the atom that accompanied the original message,
        /// or it can delete it and create a new one.
        /// </para>
        /// <para>
        /// When acknowledging <see cref="WM_DDE_EXECUTE"/>, the application that posts <see cref="WM_DDE_ACK"/>
        /// should reuse the global memory object identified in the original <see cref="WM_DDE_EXECUTE"/> message.
        /// </para>
        /// <para>
        /// All posted <see cref="WM_DDE_ACK"/> messages must create or reuse the lParam parameter
        /// by calling the <see cref="PackDDElParam"/> function or the <see cref="ReuseDDElParam"/> function.
        /// </para>
        /// <para>
        /// If an application has initiated the termination of a conversation
        /// by posting <see cref="WM_DDE_TERMINATE"/> and is awaiting confirmation,
        /// the waiting application should not acknowledge (positively or negatively) any subsequent messages sent by the other application.
        /// The waiting application should delete any atoms or shared memory objects received in these intervening messages.
        /// Memory objects should not be freed if the <see cref="fRelease"/> flag is set to <see cref="FALSE"/>
        /// in <see cref="WM_DDE_POKE"/> and <see cref="WM_DDE_DATA"/> messages.
        /// </para>
        /// <para>
        /// <see cref="Receiving"/>
        /// </para>
        /// <para>
        /// The application that receives a <see cref="WM_DDE_ACK"/> message should delete all atoms accompanying the message.
        /// If the application receives a <see cref="WM_DDE_ACK"/> in response to a message with an accompanying global memory object,
        /// and the object was sent with the <see cref="fRelease"/> flags set to <see cref="FALSE"/>,
        /// the application is responsible for deleting the object.
        /// </para>
        /// <para>
        /// If the application receives a negative <see cref="WM_DDE_ACK"/> message posted in reply to a <see cref="WM_DDE_ADVISE"/> message,
        /// the application should delete the global memory object posted with the original <see cref="WM_DDE_ADVISE"/> message.
        /// If the application receives a negative <see cref="WM_DDE_ACK"/> message posted
        /// in reply to a <see cref="WM_DDE_DATA"/>, <see cref="WM_DDE_POKE"/>, or <see cref="WM_DDE_EXECUTE"/> message,
        /// the application should delete the global memory object posted with the original <see cref="WM_DDE_DATA"/>,
        /// <see cref="WM_DDE_POKE"/>, or <see cref="WM_DDE_EXECUTE"/> message.
        /// </para>
        /// <para>
        /// The application that receives a posted <see cref="WM_DDE_ACK"/> message
        /// must free the lParam parameter by using the <see cref="FreeDDElParam"/> function.
        /// </para>
        /// </remarks>
        WM_DDE_ACK = 0x03E4,

        /// <summary>
        /// <para>
        /// A Dynamic Data Exchange (DDE) client application posts the <see cref="WM_DDE_ADVISE"/> message
        /// to a DDE server application to request the server to supply an update for a data item whenever the item changes.
        /// </para>
        /// <para>
        /// To post this message, call the <see cref="PostMessage"/> function with the following parameters.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the client window posting the message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word is a handle to a global memory object containing a <see cref="DDEADVISE"/> structure that specifies how the data is to be sent.
        /// </para>
        /// <para>
        /// The high-order word contains an atom that identifies the requested data item.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If a client application supports more than one clipboard format for a single topic and item, it can post multiple <see cref="WM_DDE_ADVISE"/> messages for the topic and item, specifying a different clipboard format with each message. Note that a server can support multiple formats only for hot data links, not warm data links.
        /// </para>
        /// <para>
        /// Posting
        /// </para>
        /// <para>
        /// The client application posts the <see cref="WM_DDE_ADVISE"/> message
        /// by calling the <see cref="PostMessage"/> function, not the <see cref="SendMessage"/> function.
        /// </para>
        /// <para>
        /// The client application allocates the global memory object using the <see cref="GlobalAlloc"/> function.
        /// It allocates the atom using the <see cref="GlobalAddAtom"/> function.
        /// </para>
        /// <para>
        /// The client application must create or reuse the <see cref="WM_DDE_ADVISE"/> lParam parameter
        /// by calling the <see cref="PackDDElParam"/> function or the <see cref="ReuseDDElParam"/> function.
        /// </para>
        /// <para>
        /// If the receiving (server) application responds with a negative <see cref="WM_DDE_ACK"/> message,
        /// the posting application must delete the object.
        /// </para>
        /// <para>
        /// The <see cref="fRelease"/> flag is not used in <see cref="WM_DDE_ADVISE"/> messages,
        /// but their data-freeing behavior is similar to that of <see cref="WM_DDE_DATA"/> and <see cref="WM_DDE_POKE"/> messages
        /// where <see cref="fRelease"/> is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// Receiving
        /// </para>
        /// <para>
        /// The server application posts the <see cref="WM_DDE_ACK"/> message to respond positively or negatively.
        /// When posting <see cref="WM_DDE_ACK"/>, the application can reuse the atom or delete it and create a new one.
        /// If the <see cref="WM_DDE_ACK"/> message is positive, the application should delete the global memory object;
        /// otherwise, the application should not delete the object.
        /// </para>
        /// <para>
        /// The server must create or reuse the <see cref="WM_DDE_ACK"/> lParam parameter
        /// by calling the <see cref="PackDDElParam"/> function or the <see cref="ReuseDDElParam"/> function.
        /// </para>
        /// </remarks>
        WM_DDE_ADVISE = 0x03E2,

        /// <summary>
        /// <para>
        /// A Dynamic Data Exchange (DDE) server application posts a <see cref="WM_DDE_DATA"/> message to a DDE client application to pass a data item to the client or to notify the client of the availability of a data item.
        /// </para>
        /// <para>
        /// To post this message, call the <see cref="PostMessage"/> function with the following parameters.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the server window posting the message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word is a handle to a global memory object
        /// containing a <see cref="DDEDATA"/> structure with the data and additional information.
        /// The handle should be set to <see cref="NULL"/>
        /// if the server is notifying the client that the data-item value has changed during a warm data link.
        /// A warm link is established by the client sending a <see cref="WM_DDE_ADVISE"/> message with the <see cref="fDeferUpd"/> bit set.
        /// </para>
        /// <para>
        /// The high-order word contains an atom that identifies the data item for which the data or notification is sent.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Posting
        /// </para>
        /// <para>
        /// The server application allocates the global memory object using the <see cref="GlobalAlloc"/> function.
        /// It allocates the atom using the <see cref="GlobalAddAtom"/> function.
        /// </para>
        /// <para>
        /// The server must create or reuse the <see cref="WM_DDE_DATA"/> lParam parameter
        /// by calling the <see cref="PackDDElParam"/> function or the <see cref="ReuseDDElParam"/> function.
        /// </para>
        /// <para>
        /// If the receiving (client) application responds with a negative <see cref="WM_DDE_ACK"/> message,
        /// the posting (server) application must delete the global memory object;
        /// otherwise, the client must delete the object after extracting its contents by calling the <see cref="UnpackDDElParam"/> function.
        /// </para>
        /// <para>
        /// If the server application sets the <see cref="DDEDATA.fRelease"/> member of the <see cref="DDEDATA"/> structure to <see cref="FALSE"/>,
        /// the server is responsible for deleting the object upon receiving either a positive or negative acknowledgment.
        /// </para>
        /// <para>
        /// The server application should not set both the <see cref="DDEDATA.fAckReq"/> and <see cref="DDEDATA.fRelease"/> members
        /// of the <see cref="DDEDATA"/> structure to <see cref="FALSE"/>.
        /// If both members are set to <see cref="FALSE"/>, it is impossible for the server to determine when to delete the object.
        /// </para>
        /// <para>
        /// Receiving
        /// </para>
        /// <para>
        /// If <see cref="DDEDATA.fAckReq"/> is <see cref="TRUE"/>, the client application should post the <see cref="WM_DDE_ACK"/> message
        /// to respond positively or negatively. When posting <see cref="WM_DDE_ACK"/>,
        /// the client can either reuse the atom, or it can delete it and create a new one.
        /// </para>
        /// <para>
        /// The client must create or reuse the <see cref="WM_DDE_ACK"/> lParam parameter
        /// by calling the <see cref="PackDDElParam"/> function or the <see cref="ReuseDDElParam"/> function.
        /// </para>
        /// <para>
        /// If <see cref="DDEDATA.fAckReq"/> is <see cref="FALSE"/>, the client application should delete the atom.
        /// </para>
        /// <para>
        /// If the posting application specified global memory object as <see cref="NULL"/>,
        /// the receiving application can request the server to send the data by posting a <see cref="WM_DDE_REQUEST"/> message.
        /// </para>
        /// <para>
        /// After processing a <see cref="WM_DDE_DATA"/> message in which the global memory object is not <see cref="NULL"/>,
        /// the client should free the object, unless one of the following conditions is true:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The <see cref="DDEDATA.fRelease"/> member is <see cref="FALSE"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The <see cref="DDEDATA.fRelease"/> member is <see cref="TRUE"/>,
        /// but the client application responds with a negative <see cref="WM_DDE_ACK"/> message.
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        WM_DDE_DATA = 0x03E5,

        /// <summary>
        /// <para>
        /// A Dynamic Data Exchange (DDE) client application posts a <see cref="WM_DDE_EXECUTE"/> message
        /// to a DDE server application to send a string to the server to be processed as a series of commands.
        /// The server application is expected to post a <see cref="WM_DDE_ACK"/> message in response.
        /// </para>
        /// <para>
        /// To post this message, call the <see cref="PostMessage"/> function with the following parameters.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the client window posting the message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains a global memory object that references an ANSI or Unicode command string,
        /// depending on the types of windows involved in the conversation.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The command string is a null-terminated string consisting of one or more opcode strings enclosed in single brackets ([ ]).
        /// Each opcode string has the following syntax, where the parameters list is optional:
        /// </para>
        /// <para>
        /// opcode parameters
        /// </para>
        /// <para>
        /// The opcode is any application-defined single token. It cannot include spaces, commas, parentheses, brackets, or quotation marks.
        /// </para>
        /// <para>
        /// The parameters list can contain any application-defined value or values.
        /// Multiple parameters are separated by commas, and the entire parameter list is enclosed in parentheses.
        /// Parameters cannot include commas or parentheses except inside a quoted string.
        /// If a bracket or parenthesis character is to appear in a quoted string, it need not be doubled, as was the case under the old rules.
        /// </para>
        /// <para>
        /// The following are valid command strings: 
        /// </para>
        /// <code>
        /// [connect][download(query1,results.txt)][disconnect] 
        /// [query("sales per employee for each district")] 
        /// [open("sample.xlm")][run("r1c1")] 
        /// [quote_case("This is a "" character")] 
        /// [bracket_or_paren_case("()s or []s should be no problem.")] 
        /// </code>
        /// <para>
        /// Note that, under the old rules, parentheses and brackets had to be doubled, as follows: 
        /// </para>
        /// <code>
        /// [bracket_or_paren_case("(())s or [[]]s should be no problem.")] 
        /// </code>
        /// <para>
        /// Servers should be able to parse commands in either form.
        /// </para>
        /// <para>
        /// Unicode execute strings should be used only when both the client and server window handles
        /// cause the <see cref="IsWindowUnicode"/> function to return <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// Posting
        /// </para>
        /// <para>
        /// The client application allocates the global memory object by calling the <see cref="GlobalAlloc"/> function.
        /// </para>
        /// <para>
        /// When processing the <see cref="WM_DDE_ACK"/> message that the server posts in reply to a <see cref="WM_DDE_EXECUTE"/> message,
        /// the client application must delete the object returned by the <see cref="WM_DDE_ACK"/> message.
        /// </para>
        /// <para>
        /// Receiving
        /// </para>
        /// <para>
        /// The server application posts the <see cref="WM_DDE_ACK"/> message to respond positively or negatively.
        /// The server should reuse the global memory object.
        /// </para>
        /// <para>
        /// Unless specified otherwise by a sub-protocol, the server should not post the <see cref="WM_DDE_ACK"/> message
        /// until all the actions specified by the execute command string are completed.
        /// The one exception to this rule is when the string causes the server to terminate the conversation.
        /// </para>
        /// </remarks>
        WM_DDE_EXECUTE = 0x03E8,

        /// <summary>
        /// <para>
        /// A Dynamic Data Exchange (DDE) client application posts a <see cref="WM_DDE_POKE"/> message to a DDE server application.
        /// A client uses this message to request the server to accept an unsolicited data item.
        /// The server is expected to reply with a <see cref="WM_DDE_ACK"/> message indicating whether it accepted the data item.
        /// </para>
        /// <para>
        /// To post this message, call the <see cref="PostMessage"/> function with the following parameters.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the client window posting the message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word is a handle to a global memory object containing a <see cref="DDEPOKE"/> structure with the data and additional information.
        /// </para>
        /// <para>
        /// The high-order word contains a global atom that identifies the data item for which the data or notification is being sent.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Posting
        /// </para>
        /// <para>
        /// The client application must allocate memory for the global memory object using the <see cref="GlobalAlloc"/> function.
        /// The client application must delete the object if either of the following conditions is true:
        /// </para>
        /// <para>
        /// The client application must create the atom using the <see cref="GlobalAddAtom"/> function.
        /// </para>
        /// <para>
        /// The client application must create or reuse the <see cref="WM_DDE_POKE"/> lParam parameter
        /// by calling the <see cref="PackDDElParam"/> function or the <see cref="ReuseDDElParam"/> function.
        /// </para>
        /// <para>
        /// Receiving
        /// </para>
        /// <para>
        /// The server application should post the <see cref="WM_DDE_ACK"/> message to respond positively or negatively.
        /// When posting <see cref="WM_DDE_ACK"/>, the server can either reuse the atom, or it can delete it and create a new one.
        /// </para>
        /// <para>
        /// The server must create or reuse the <see cref="WM_DDE_ACK"/> lParam parameter
        /// by calling the <see cref="PackDDElParam"/> function or the <see cref="ReuseDDElParam"/> function.
        /// </para>
        /// <para>
        /// To free the global memory object, the server should call the <see cref="GlobalFree"/> function.
        /// Also, if the data format is either <see cref="CF_DSPMETAFILEPICT"/> or <see cref="CF_METAFILEPICT"/>,
        /// the server must also call <see cref="DeleteMetaFile"/> with the embedded metafile handle.
        /// These two formats have an extra level of indirection;
        /// that is, an application must lock the object to get a pointer to a handle,
        /// then lock that handle to get a pointer to a <see cref="METAFILEPICT"/> structure,
        /// and finally call <see cref="DeleteMetaFile"/> with the handle
        /// from the <see cref="METAFILEPICT.hMF"/> member of the <see cref="METAFILEPICT"/> structure.
        /// </para>
        /// <para>
        /// To free the object, the server should call the <see cref="FreeDDElParam"/> function.
        /// </para>
        /// </remarks>
        WM_DDE_POKE = 0x03E7,

        /// <summary>
        /// <para>
        /// A Dynamic Data Exchange (DDE) client application posts a <see cref="WM_DDE_REQUEST"/> message
        /// to a DDE server application to request the value of a data item.
        /// </para>
        /// <para>
        /// To post this message, call the <see cref="PostMessage"/> function with the following parameters.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the client window sending the message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies a standard or registered clipboard format.
        /// </para>
        /// <para>
        /// The high-order word contains an atom that identifies the data item requested from the server.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Posting
        /// </para>
        /// <para>
        /// The client application allocates the atom by calling the <see cref="GlobalAddAtom"/> function.
        /// </para>
        /// <para>
        /// Receiving
        /// </para>
        /// <para>
        /// If the receiving (server) application can satisfy the request,
        /// it responds with a <see cref="WM_DDE_DATA"/> message containing the requested data.
        /// Otherwise, it responds with a negative <see cref="WM_DDE_ACK"/> message.
        /// </para>
        /// <para>
        /// When responding with either a <see cref="WM_DDE_DATA"/> or <see cref="WM_DDE_ACK"/> message,
        /// the server application can either reuse the atom or it can delete the atom and create a new one.
        /// </para>
        /// </remarks>
        WM_DDE_REQUEST = 0x03E6,

        /// <summary>
        /// <para>
        /// A Dynamic Data Exchange (DDE) application (client or server) posts a <see cref="WM_DDE_TERMINATE"/> message to terminate a conversation.
        /// </para>
        /// <para>
        /// To post this message, call the <see cref="PostMessage"/> function with the following parameters.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the client or server window posting the message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Posting
        /// </para>
        /// <para>
        /// While waiting for confirmation of the termination,
        /// the posting application should not post any other messages to the receiving application.
        /// If the sending application receives messages (other than <see cref="WM_DDE_TERMINATE"/>) from the receiving application,
        /// it should delete any atoms or shared memory objects accompanying the messages,
        /// except global memory objects associated with <see cref="WM_DDE_POKE"/> or <see cref="WM_DDE_DATA"/> messages
        /// that do not have the <see cref="DDEDATA.fRelease"/> member set.
        /// </para>
        /// <para>
        /// Receiving
        /// </para>
        /// <para>
        /// The client or server application should respond by posting a <see cref="WM_DDE_TERMINATE"/> message.
        /// </para>
        /// </remarks>
        WM_DDE_TERMINATE = 0x03E1,

        /// <summary>
        /// <para>
        /// A Dynamic Data Exchange (DDE) client application posts a <see cref="WM_DDE_UNADVISE"/> message to inform a DDE server application
        /// that the specified item or a particular clipboard format for the item should no longer be updated.
        /// This terminates the warm or hot data link for the specified item.
        /// </para>
        /// <para>
        /// To post this message, call the <see cref="PostMessage"/> function with the following parameters.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the client window sending the message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the clipboard format of the item for which the update request is being retracted.
        /// If this is <see cref="NULL"/>, all active <see cref="WM_DDE_ADVISE"/> conversations for the item are to be terminated.
        /// </para>
        /// <para>
        /// The high-order word contains a global atom that identifies the item for which the update request is being retracted.
        /// If this is <see cref="NULL"/>, all active <see cref="WM_DDE_ADVISE"/> links associated with the conversation are to be terminated.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The client application allocates the high-order word of lParam by calling the <see cref="GlobalAddAtom"/> function.
        /// </para>
        /// <para>
        /// The server application posts the <see cref="WM_DDE_ACK"/> message to respond positively or negatively.
        /// When posting <see cref="WM_DDE_ACK"/>, the server can either reuse the atom, or it can delete the atom and create a new one.
        /// </para>
        /// </remarks>
        WM_DDE_UNADVISE = 0x03E3,

        #endregion

        #region Edit Control Messages

        /// <summary>
        /// <para>
        /// An application sends a <see cref="WM_UNDO"/> message to an edit control to undo the last operation.
        /// When this message is sent to an edit control, the previously deleted text is restored or the previously added text is deleted.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Not used; must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Not used; must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the message succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If the message fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-undo"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Rich Edit: It is recommended that <see cref="EM_UNDO"/> be used instead of <see cref="WM_UNDO"/>.
        /// </remarks>
        WM_UNDO = 0x0304,

        #endregion

        #region Edit Control Notifications

        /// <summary>
        /// <para>
        /// An edit control that is not read-only or disabled sends the <see cref="WM_CTLCOLOREDIT"/> message
        /// to its parent window when the control is about to be drawn.
        /// By responding to this message, the parent window can use the specified device context handle
        /// to set the text and background colors of the edit control.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the device context for the edit control window.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the edit control.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it must return the handle of a brush.
        /// The system uses the brush to paint the background of the edit control.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-ctlcoloredit"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the application returns a brush that it created (for example, by using the <see cref="CreateSolidBrush"/>
        /// or <see cref="CreateBrushIndirect"/> function), the application must free the brush.
        /// If the application returns a system brush (for example, one that was retrieved by the <see cref="GetStockObject"/>
        /// or <see cref="GetSysColorBrush"/> function), the application does not need to free the brush.
        /// </para>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function selects the default system colors for the edit control.
        /// </para>
        /// <para>
        /// Read-only or disabled edit controls do not send the <see cref="WM_CTLCOLOREDIT"/> message;
        /// instead, they send the <see cref="WM_CTLCOLORSTATIC"/> message.
        /// </para>
        /// <para>
        /// The <see cref="WM_CTLCOLOREDIT"/> message is never sent between threads, it is only sent within the same thread.
        /// </para>
        /// <para>
        /// If a dialog box procedure handles this message,
        /// it should cast the desired return value to a <see cref="INT_PTR"/> and return the value directly.
        /// If the dialog box procedure returns <see cref="FALSE"/>, then default message handling is performed.
        /// The <see cref="DWL_MSGRESULT"/> value set by the <see cref="SetWindowLong"/> function is ignored.
        /// </para>
        /// <para>
        /// Rich Edit: This message is not supported.
        /// To set the background color for a rich edit control, use the <see cref="EM_SETBKGNDCOLOR"/> message.
        /// </para>
        /// </remarks>
        WM_CTLCOLOREDIT = 0x0133,

        #endregion

        #region Font and Text Messages

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_FONTCHANGE"/> message to all top-level windows in the system after changing the pool of font resources.
        /// </para>
        /// <para>
        /// To send this message, call the <see cref="SendMessage"/> function with the following parameters.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-fontchange"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// An application that adds or removes fonts from the system (for example, by using the <see cref="AddFontResource"/>
        /// or <see cref="RemoveFontResource"/> function) should send this message to all top-level windows.
        /// </para>
        /// <para>
        /// To send the <see cref="WM_FONTCHANGE"/> message to all top-level windows,
        /// an application can call the <see cref="SendMessage"/> function with the hwnd parameter set to <see cref="HWND_BROADCAST"/>.
        /// </para>
        /// </remarks>
        WM_FONTCHANGE = 0x001D,

        #endregion

        #region High DPI

        /// <summary>
        /// <para>
        /// Sent when the effective dots per inch (dpi) for a window has changed.
        /// The DPI is the scale factor for a window. There are multiple events that can cause the DPI to change.
        /// The following list indicates the possible causes for the change in DPI.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The window is moved to a new monitor that has a different DPI.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The DPI of the monitor hosting the window changes.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// The current DPI for a window always equals the last DPI sent by <see cref="WM_DPICHANGED"/>.
        /// This is the scale factor that the window should be scaling to for threads that are aware of DPI changes.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The <see cref="HIWORD"/> of the wParam contains the Y-axis value of the new dpi of the window.
        /// The <see cref="LOWORD"/> of the wParam contains the X-axis value of the new DPI of the window.
        /// For example, 96, 120, 144, or 192. The values of the X-axis and the Y-axis are identical for Windows apps.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="RECT"/> structure that provides a suggested size and position of the current window scaled for the new DPI.
        /// The expectation is that apps will reposition and resize windows based on the suggestions provided by lParam when handling this message.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/hidpi/wm-dpichanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message is only relevant for <see cref="PROCESS_PER_MONITOR_DPI_AWARE"/> applications
        /// or <see cref="DPI_AWARENESS_PER_MONITOR_AWARE"/> threads.
        /// It may be received on certain DPI changes if your top-level window or process is running as DPI unaware or system DPI aware,
        /// but in those situations it can be safely ignored.
        /// For more information about the different types of awareness, see <see cref="PROCESS_DPI_AWARENESS"/> and <see cref="DPI_AWARENESS"/>.
        /// Older versions of Windows required DPI awareness to be tied at the level of an application.
        /// Those apps use <see cref="PROCESS_DPI_AWARENESS"/>.
        /// Currently, DPI awareness is tied to threads and individual windows rather than the entire application.
        /// These apps use <see cref="DPI_AWARENESS"/>.
        /// </para>
        /// <para>
        /// You only need to use either the X-axis or the Y-axis value when scaling your application since they are the same.
        /// </para>
        /// <para>
        /// In order to handle this message correctly, you will need to resize and reposition your window
        /// based on the suggestions provided by lParam and using <see cref="SetWindowPos"/>.
        /// If you do not do this, your window will grow or shrink with respect to everything else on the new monitor.
        /// For example, if a user is using multiple monitors and drags your window from a 96 DPI monitor to a 192 DPI monitor,
        /// your window will appear to be half as large with respect to other items on the 192 DPI monitor.
        /// </para>
        /// <para>
        /// The base value of DPI is defined as <see cref="USER_DEFAULT_SCREEN_DPI"/> which is set to 96.
        /// To determine the scaling factor for a monitor, take the DPI value and divide by <see cref="USER_DEFAULT_SCREEN_DPI"/>.
        /// The following table provides some sample DPI values and associated scaling factors.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// DPI value
        /// </term>
        /// <term>
        /// Scaling percentage
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 96
        /// </term>
        /// <term>
        /// 100%
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 120
        /// </term>
        /// <term>
        /// 125%
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 144
        /// </term>
        /// <term>
        /// 150%
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 192
        /// </term>
        /// <term>
        /// 200%
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The following example provides a sample DPI change handler.
        /// </para>
        /// <para>
        /// The following code linearly scales a value from 100% (96 DPI) to an arbitrary DPI defined by <see cref="g_dpi"/>.
        /// </para>
        /// <code>
        /// case WM_DPICHANGED:
        ///     {
        ///         g_dpi = HIWORD(wParam);
        ///         UpdateDpiDependentFontsAndResources();
        /// 
        ///         RECT* const prcNewWindow = (RECT*)lParam;
        ///         SetWindowPos(hWnd,
        ///             NULL,
        ///             prcNewWindow -&gt;left,
        ///             prcNewWindow -&gt;top,
        ///             prcNewWindow-&gt;right - prcNewWindow-&gt;left,
        ///             prcNewWindow-&gt;bottom - prcNewWindow-&gt;top,
        ///             SWP_NOZORDER | SWP_NOACTIVATE);
        ///         break;
        ///     }
        /// </code>
        /// <para>
        /// An alternative way to scale a value is to convert the DPI value into a scale factor and use that.
        /// </para>
        /// <code>
        /// INT iBorderWidth100 = 5;
        ///     FLOAT fscale = (float) g_dpi / USER_DEFAULT_SCREEN_DPI;
        ///     iBorderWidth = iBorderWidth100 * fscale;
        /// </code>
        /// </remarks>
        WM_DPICHANGED = 0x02E0,

        /// <summary>
        /// <para>
        /// For Per Monitor v2 top-level windows, this message is sent to all HWNDs
        /// in the child HWDN tree of the window that is undergoing a DPI change.
        /// This message occurs before the top-level window receives <see cref="WM_DPICHANGED"/>,
        /// and traverses the child tree from the bottom up.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This value is unused and will be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This value is unused and will be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This value is unused and ignored by the system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/hidpi/wm-dpichanged-beforeparent"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// There is no default handling of this message in <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// This message is only sent when the top-level window has a DPI awareness context of PMv2.
        /// </para>
        /// </remarks>
        WM_DPICHANGED_BEFOREPARENT = 0x02E2,

        /// <summary>
        /// <para>
        /// For Per Monitor v2 top-level windows, this message is sent to all HWNDs
        /// in the child HWDN tree of the window that is undergoing a DPI change.
        /// This message occurs after the top-level window receives <see cref="WM_DPICHANGED"/>,
        /// and traverses the child tree from the top down.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This value is unused and will be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This value is unused and will be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This value is unused and ignored by the system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/hidpi/wm-dpichanged-afterparent"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// There is no default handling of this message in <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// This message is only sent when the top-level window has a DPI awareness context of PMv2.
        /// </para>
        /// </remarks>
        WM_DPICHANGED_AFTERPARENT = 0x02E3,

        /// <summary>
        /// <para>
        /// This message tells the operating system that the window will be sized to dimensions other than the default.
        /// </para>
        /// <para>
        /// This message is sent to top-level windows with a <see cref="DPI_AWARENESS_CONTEXT"/> of Per Monitor v2
        /// before a <see cref="WM_DPICHANGED"/> message is sent, and allows the window to compute its desired size for the pending DPI change.
        /// As linear DPI scaling is the default behavior, this is only useful in scenarios where the window wants to scale non-linearly.
        /// If the application responds to this message, the resulting size will be the candidate rectangle sent to <see cref="WM_DPICHANGED"/>.
        /// </para>
        /// <para>
        /// Use this message to alter the size of the rect that is provided with <see cref="WM_DPICHANGED"/>.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The WPARAM contains a DPI value.
        /// The scaled window size that the application would set needs to be computed as if the window were to switch to this DPI.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The LPARAM is an in/out pointer to a SIZE struct.
        /// The _In_ value in the LPARAM is the pending size of the window after a user-initiated move or a call to <see cref="SetWindowPos"/>.
        /// If the window is being resized, this size is not necessarily the same as the window's current size at the time this message is received.
        /// </para>
        /// <para>
        /// The _Out_ value in the LPARAM should be written to by the application
        /// to specify the desired scaled window size corresponding to the provided DPI value in the WPARAM.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The function returns a <see cref="BOOL"/>.
        /// Returning <see cref="TRUE"/> indicates that a new size has been computed.
        /// Returning <see cref="FALSE"/> indicates that the message will not be handled,
        /// and the default linear DPI scaling will apply to the window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/hidpi/wm-getdpiscaledsize"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message is only sent to top-level windows which have a DPI awareness context of Per Monitor v2.
        /// </para>
        /// <para>
        /// This event is necessary to facilitate graceful non-linear scaling,
        /// and ensures that the windows's position remains constant in relationship to the cursor and when moving back and forth across monitors.
        /// </para>
        /// <para>
        /// There is no specific default handling of this message in <see cref="DefWindowProc"/>.
        /// As for all messages it does not explicitly handle, <see cref="DefWindowProc"/> will return zero for this message.
        /// As noted above, this return tells the system to use the default linear behavior.
        /// </para>
        /// </remarks>
        WM_GETDPISCALEDSIZE = 0x02E4,

        #endregion

        #region Input Method Manager Messages

        /// <summary>
        /// <para>
        /// Sent to an application when the IME gets a character of the conversion result.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// DBCS: A single-byte or double-byte character value.
        /// For a double-byte character, (BYTE)(wParam &gt;&gt; 8) contains the lead byte.
        /// Note that the parentheses are necessary because the cast operator has higher precedence than the shift operator.
        /// </para>
        /// <para>
        /// Unicode: A Unicode character value.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The repeat count, scan code, extended key flag, context code, previous key state flag,
        /// and transition state flag, with values as defined below.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bit
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-15
        /// </term>
        /// <term>
        /// Repeat count. Since the first byte and second byte are continuous, this is always 1.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16-23
        /// </term>
        /// <term>
        /// Scan code for a complete Asian character.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Extended key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25-28
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// Context code.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// Previous key state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// Transition state.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/wm-ime-char"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Unlike the <see cref="WM_CHAR"/> message for a non-Unicode window, this message can include double-byte and single-byte character values.
        /// For a Unicode window, this message is the same as <see cref="WM_CHAR"/>.
        /// </para>
        /// <para>
        /// For a non-Unicode window, if the <see cref="WM_IME_CHAR"/> message includes a double-byte character
        /// and the application passes this message to <see cref="DefWindowProc"/>,
        /// the IME converts this message into two <see cref="WM_CHAR"/> messages, each containing one byte of the double-byte character.
        /// </para>
        /// </remarks>
        WM_IME_CHAR = 0x0286,

        /// <summary>
        /// <para>
        /// Sent to an application when the IME changes composition status as a result of a keystroke.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// hwnd
        /// </para>
        /// <para>
        /// A handle to window.
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// DBCS character representing the latest change to the composition string.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Value specifying how the composition string or character changed. This parameter can be one or more of the following values.
        /// For more information about these values, see IME Composition String Values.  
        /// </para>
        /// <para>
        /// <see cref="GCS_COMPATTR"/>  
        /// </para>
        /// <para>
        /// <see cref="GCS_COMPCLAUSE"/>  
        /// </para>
        /// <para>
        /// <see cref="GCS_COMPREADSTR"/>  
        /// </para>
        /// <para>
        /// <see cref="GCS_COMPREADATTR"/>  
        /// </para>
        /// <para>
        /// <see cref="GCS_COMPREADCLAUSE"/>  
        /// </para>
        /// <para>
        /// <see cref="GCS_COMPSTR"/>  
        /// </para>
        /// <para>
        /// <see cref="GCS_CURSORPOS"/>  
        /// </para>
        /// <para>
        /// <see cref="GCS_DELTASTART"/>  
        /// </para>
        /// <para>
        /// <see cref="GCS_RESULTCLAUSE"/>  
        /// </para>
        /// <para>
        /// <see cref="GCS_RESULTREADCLAUSE"/>  
        /// </para>
        /// <para>
        /// <see cref="GCS_RESULTREADSTR"/>  
        /// </para>
        /// <para>
        /// <see cref="GCS_RESULTSTR"/>
        /// </para>
        /// <para>
        /// The lParam parameter can also have one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="CS_INSERTCHAR"/>
        /// </term>
        /// <term>
        /// Insert the wParam composition character at the current insertion point.
        /// An application should display the composition character if it processes this message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CS_NOMOVECARET"/>
        /// </term>
        /// <term>
        /// Do not move the caret position as a result of processing the message.
        /// For example, if an IME specifies a combination of <see cref="CS_INSERTCHAR"/> and <see cref="CS_NOMOVECARET"/>,
        /// the application should insert the specified character at the current caret position but should not move the caret to the next position.
        /// A subsequent <see cref="WM_IME_COMPOSITION"/> message with <see cref="GCS_RESULTSTR"/> will replace this character.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/wm-ime-composition"/>
        /// </para>
        /// </summary>
        WM_IME_COMPOSITION = 0x010F,

        /// <summary>
        /// <para>
        /// Sent to an application when the IME window finds no space to extend the area for the composition window.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// This message has no parameters.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message has no return value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/wm-ime-compositionfull"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The application should use the <see cref="IMC_SETCOMPOSITIONWINDOW"/> command to specify how the window should be displayed.
        /// </para>
        /// <para>
        /// The IME window, instead of the IME, sends this notification message by the <see cref="SendMessage"/> function.
        /// </para>
        /// </remarks>
        WM_IME_COMPOSITIONFULL = 0x0284,

        /// <summary>
        /// <para>
        /// Sent by an application to direct the IME window to carry out the requested command.
        /// The application uses this message to control the IME window that it has created.
        /// To send this message, the application calls the <see cref="SendMessage"/> function with the following parameters.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The command. This parameter can have one of the following values:
        /// </para>
        /// <para>
        /// <see cref="IMC_CLOSESTATUSWINDOW"/>
        /// </para>
        /// <para>
        /// <see cref="IMC_GETCANDIDATEPOS"/>
        /// </para>
        /// <para>
        /// <see cref="IMC_GETCOMPOSITIONFONT"/>
        /// </para>
        /// <para>
        /// <see cref="IMC_GETCOMPOSITIONWINDOW"/>
        /// </para>
        /// <para>
        /// <see cref="IMC_GETSTATUSWINDOWPOS"/>
        /// </para>
        /// <para>
        /// <see cref="IMC_OPENSTATUSWINDOW"/>
        /// </para>
        /// <para>
        /// <see cref="IMC_SETCANDIDATEPOS"/>
        /// </para>
        /// <para>
        /// <see cref="IMC_SETCOMPOSITIONFONT"/>
        /// </para>
        /// <para>
        /// <see cref="IMC_SETCOMPOSITIONWINDOW"/>
        /// </para>
        /// <para>
        /// <see cref="IMC_SETSTATUSWINDOWPOS"/>
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Command-specific data, with format dependent on the value of the wParam parameter.
        /// For more information, refer to the documentation for each command.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The message returns a command-specific value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/wm-ime-control"/>
        /// </para>
        /// </summary>
        WM_IME_CONTROL = 0x0283,

        /// <summary>
        /// <para>
        /// Sent to an application when the IME ends composition.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// This message has no parameters.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message has no return value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/wm-ime-compositionfull"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// An application should process this message if it displays composition characters itself.
        /// </para>
        /// <para>
        /// If the application has created an IME window, it should pass this message to that window.
        /// The <see cref="DefWindowProc"/> function processes this message by passing it to the default IME window.
        /// </para>
        /// </remarks>
        WM_IME_ENDCOMPOSITION = 0x010E,

        /// <summary>
        /// <para>
        /// Sent to an application by the IME to notify the application of a key press and to keep message order.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Virtual key code of the key.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Repeat count, scan code, extended key flag, context code, previous key state flag, and transition state flag, as shown in the following table.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bit
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-15
        /// </term>
        /// <term>
        /// Repeat count.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16-23
        /// </term>
        /// <term>
        /// Scan code.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Extended key. This value is 1 if it is an extended key. Otherwise, it is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25-28
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// Context code. This value is always 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// Previous key state. This value is 1 if the key is down or 0 if it is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// Transition state. This value is always 0.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return 0 if it processes this message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/wm-ime-keydown"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// An application can process this message or pass it to the <see cref="DefWindowProc"/> function
        /// to generate a matching <see cref="WM_KEYDOWN"/> message.
        /// </remarks>
        WM_IME_KEYDOWN = 0x0290,

        /// <summary>
        /// <para>
        /// Sent to an application by the IME to notify the application of a key release and to keep message order.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Virtual key code of the key.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Repeat count, scan code, extended key flag, context code, previous key state flag, and transition state flag, as shown below.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bit
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-15
        /// </term>
        /// <term>
        /// Repeat count.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16-23
        /// </term>
        /// <term>
        /// Scan code.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Extended key. This value is 1 if it is an extended key. Otherwise, it is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25-28
        /// </term>
        /// <term>
        /// Not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// Context code. This value is always 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// Previous key state. This value is 1 if the key is down or 0 if it is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// Transition state. This value is always 0.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return 0 if it processes this message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/wm-ime-keyup"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// An application can process this message or pass it to the <see cref="DefWindowProc"/> function
        /// to generate a matching <see cref="WM_KEYUP"/> message.
        /// </remarks>
        WM_IME_KEYUP = 0x0291,

        /// <summary>
        /// <para>
        /// Sent to an application to notify it of changes to the IME window.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The command. This parameter can have one of the following values.
        /// </para>
        /// <para>
        /// <see cref="IMN_CHANGECANDIDATE"/>
        /// </para>
        /// <para>
        /// <see cref="IMN_CLOSECANDIDATE"/>
        /// </para>
        /// <para>
        /// <see cref="IMN_CLOSESTATUSWINDOW"/>
        /// </para>
        /// <para>
        /// <see cref="IMN_GUIDELINE"/>
        /// </para>
        /// <para>
        /// <see cref="IMN_OPENCANDIDATE"/>
        /// </para>
        /// <para>
        /// <see cref="IMN_OPENSTATUSWINDOW"/>
        /// </para>
        /// <para>
        /// <see cref="IMN_SETCANDIDATEPOS"/>
        /// </para>
        /// <para>
        /// <see cref="IMN_SETCOMPOSITIONFONT"/>
        /// </para>
        /// <para>
        /// <see cref="IMN_SETCOMPOSITIONWINDOW"/>
        /// </para>
        /// <para>
        /// <see cref="IMN_SETCONVERSIONMODE"/>
        /// </para>
        /// <para>
        /// <see cref="IMN_SETOPENSTATUS"/>
        /// </para>
        /// <para>
        /// <see cref="IMN_SETSENTENCEMODE"/>
        /// </para>
        /// <para>
        /// <see cref="IMN_SETSTATUSWINDOWPOS"/>
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Command-specific data, with format dependent on the value of the wParam parameter. For more information, refer to the documentation for each command.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value depends on the command sent.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/wm-ime-request"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// An application processes this message if it is responsible for managing the IME window.
        /// </remarks>
        WM_IME_NOTIFY = 0x0282,

        /// <summary>
        /// <para>
        /// Sent to an application to provide commands and request information.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Command. This parameter can have one of the following values:
        /// </para>
        /// <para>
        /// <see cref="IMR_CANDIDATEWINDOW"/>
        /// </para>
        /// <para>
        /// <see cref="IMR_COMPOSITIONFONT"/>
        /// </para>
        /// <para>
        /// <see cref="IMR_COMPOSITIONWINDOW"/>
        /// </para>
        /// <para>
        /// <see cref="IMR_CONFIRMRECONVERTSTRING"/>
        /// </para>
        /// <para>
        /// <see cref="IMR_DOCUMENTFEED"/>
        /// </para>
        /// <para>
        /// <see cref="IMR_QUERYCHARPOSITION"/>
        /// </para>
        /// <para>
        /// <see cref="IMR_RECONVERTSTRING"/>
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Command-specific data. For more information, see the description for each command.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Returns a command-specific value.
        /// </para>
        /// <para>
        /// body>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/wm-ime-request"/>
        /// </para>
        /// </summary>
        WM_IME_REQUEST = 0x0288,

        /// <summary>
        /// <para>
        /// Sent to an application when the operating system is about to change the current IME.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Selection indicator. This parameter specifies <see cref="TRUE"/> if the indicated IME is selected.
        /// The parameter is set to <see cref="FALSE"/> if the specified IME is no longer selected.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Input locale identifier associated with the IME.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message has no return value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/wm-ime-select"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// An application that has created an IME window should pass this message to that window
        /// so that it can retrieve the keyboard layout handle to the newly selected IME.
        /// </para>
        /// <para>
        /// The <see cref="DefWindowProc"/> function processes this message by passing the information to the default IME window.
        /// </para>
        /// </remarks>
        WM_IME_SELECT = 0x0285,

        /// <summary>
        /// <para>
        /// Sent to an application when a window is activated. A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// <see cref="TRUE"/> if the window is active, and <see cref="FALSE"/> otherwise.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Display options. This parameter can have one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ISC_SHOWUICOMPOSITIONWINDOW"/>
        /// </term>
        /// <term>
        /// Show the composition window by user interface window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ISC_SHOWUIGUIDWINDOW"/>
        /// </term>
        /// <term>
        /// Show the guide window by user interface window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ISC_SHOWUISOFTKBD"/>
        /// </term>
        /// <term>
        /// Show the soft keyboard by user interface window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ISC_SHOWUICANDIDATEWINDOW"/>
        /// </term>
        /// <term>
        /// Show the candidate window of index 0 by user interface window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// ISC_SHOWUICANDIDATEWINDOW &lt;&lt; 1
        /// </term>
        /// <term>
        /// Show the candidate window of index 1 by user interface window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// ISC_SHOWUICANDIDATEWINDOW &lt;&lt; 2
        /// </term>
        /// <term>
        /// Show the candidate window of index 2 by user interface window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// ISC_SHOWUICANDIDATEWINDOW &lt;&lt; 3
        /// </term>
        /// <term>
        /// Show the candidate window of index 3 by user interface window.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Returns the value returned by <see cref="DefWindowProc"/> or <see cref="ImmIsUIMessage"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/wm-ime-setcontext"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the application has created an IME window, it should call <see cref="ImmIsUIMessage"/>.
        /// Otherwise, it should pass this message to <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// If the application draws the composition window, the default IME window does not have to show its composition window.
        /// In this case, the application must clear the <see cref="ISC_SHOWUICOMPOSITIONWINDOW"/> value
        /// from the lParam parameter before passing the message to <see cref="DefWindowProc"/> or <see cref="ImmIsUIMessage"/>.
        /// To display a certain user interface window, an application should remove the corresponding value so that the IME will not display it.
        /// </para>
        /// </remarks>
        WM_IME_SETCONTEXT = 0x0281,

        /// <summary>
        /// <para>
        /// Sent immediately before the IME generates the composition string as a result of a keystroke.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// This message has no parameters.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message has no return value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/wm-ime-startcomposition"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message is a notification to an IME window to open its composition window.
        /// An application should process this message if it displays composition characters itself.
        /// </para>
        /// <para>
        /// If an application has created an IME window, it should pass this message to that window.
        /// The <see cref="DefWindowProc"/> function processes the message by passing it to the default IME window.
        /// </para>
        /// </remarks>
        WM_IME_STARTCOMPOSITION = 0x010D,

        #endregion

        #region Hook Notifications

        /// <summary>
        /// <para>
        /// Warning
        /// </para>
        /// <para>
        /// Journaling Hooks APIs are unsupported starting in Windows 11 and will be removed in a future release.
        /// Because of this, we highly recommend calling the <see cref="SendInput"/> TextInput API instead.
        /// </para>
        /// <para>
        /// Posted to an application when a user cancels the application's journaling activities.
        /// The message is posted with a <see cref="NULL"/> window handle.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: void
        /// </para>
        /// <para>
        /// This message does not return a value.
        /// It is meant to be processed from within an application's main loop or a <see cref="GetMessage"/> hook procedure, not from a window procedure.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Journal record and playback modes are modes imposed on the system that let an application sequentially record or play back user input.
        /// The system enters these modes when an application installs a JournalRecordProc or JournalPlaybackProc hook procedure.
        /// When the system is in either of these journaling modes, applications must take turns reading input from the input queue.
        /// If any one application stops reading input while the system is in a journaling mode, other applications are forced to wait.
        /// </para>
        /// <para>
        /// To ensure a robust system, one that cannot be made unresponsive by any one application,
        /// the system automatically cancels any journaling activities when a user presses CTRL+ESC or CTRL+ALT+DEL.
        /// The system then unhooks any journaling hook procedures, and posts a <see cref="WM_CANCELJOURNAL"/> message,
        /// with a <see cref="NULL"/> window handle, to the application that set the journaling hook.
        /// </para>
        /// <para>
        /// The <see cref="WM_CANCELJOURNAL"/> message has a <see cref="NULL"/> window handle, therefore it cannot be dispatched to a window procedure.
        /// There are two ways for an application to see a <see cref="WM_CANCELJOURNAL"/> message:
        /// If the application is running in its own main loop, it must catch the message
        /// between its call to <see cref="GetMessage"/> or <see cref="PeekMessage"/> and its call to <see cref="DispatchMessage"/>.
        /// If the application is not running in its own main loop, it must set a GetMsgProc hook procedure
        /// (through a call to <see cref="SetWindowsHookEx"/> specifying the <see cref="WH_GETMESSAGE"/> hook type) that watches for the message.
        /// </para>
        /// <para>
        /// When an application sees a <see cref="WM_CANCELJOURNAL"/> message, it can assume two things:
        /// the user has intentionally canceled the journal record or playback mode,
        /// and the system has already unhooked any journal record or playback hook procedures.
        /// </para>
        /// <para>
        /// Note that the key combinations mentioned above (CTRL+ESC or CTRL+ALT+DEL) cause the system to cancel journaling.
        /// If any one application is made unresponsive, they give the user a means of recovery.
        /// The <see cref="VK_CANCEL"/> virtual key code (usually implemented as the CTRL+BREAK key combination)
        /// is what an application that is in journal record mode should watch for as a signal that the user wishes to cancel the journaling activity.
        /// The difference is that watching for <see cref="VK_CANCEL"/> is a suggested behavior for journaling applications,
        /// whereas CTRL+ESC or CTRL+ALT+DEL cause the system to cancel journaling regardless of a journaling application's behavior.
        /// </para>
        /// </remarks>
        WM_CANCELJOURNAL = 0x004B,

        /// <summary>
        /// <para>
        /// Sent by a computer-based training (CBT) application to separate user-input messages
        /// from other messages sent through the <see cref="WH_JOURNALPLAYBACK"/> procedure.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: void
        /// </para>
        /// <para>
        /// A CBT application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Whenever a CBT application uses the <see cref="WH_JOURNALPLAYBACK"/> procedure, the first and last messages are <see cref="WM_QUEUESYNC"/>.
        /// This allows the CBT application to intercept and examine user-initiated messages without doing so for events that it sends.
        /// </para>
        /// <para>
        /// If an application specifies a <see cref="NULL"/> window handle, the message is posted to the message queue of the active window.
        /// </para>
        /// </remarks>
        WM_QUEUESYNC = 0x0023,

        #endregion

        #region Keyboard Accelerator Messages

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_CHANGEUISTATE"/> message to indicate that the UI state should be changed.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word specifies the action to be taken.
        /// This member can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UIS_CLEAR"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The UI state flags specified by the high-order word should be cleared.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UIS_INITIALIZE"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// The UI state flags specified by the high-order word should be changed based on the last input event.
        /// For more information, see Remarks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UIS_SET"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The UI state flags specified by the high-order word should be set.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The high-order word specifies which UI state elements are affected or the style of the control.
        /// This member can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UISF_ACTIVE"/>
        /// </para>
        /// <para>
        /// 0x4
        /// </para>
        /// </term>
        /// <term>
        /// A control should be drawn in the style used for active controls.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UISF_HIDEACCEL"/>
        /// </para>
        /// <para>
        /// 0x2
        /// </para>
        /// </term>
        /// <term>
        /// Keyboard accelerators are hidden.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UISF_HIDEFOCUS"/>
        /// </para>
        /// <para>
        /// 0x1
        /// </para>
        /// </term>
        /// <term>
        /// Focus indicators are hidden.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be 0.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A window should send this message to itself or its paren
        /// t when it must change the UI state elements of all windows in the same hierarchy.
        /// The window procedure must let <see cref="DefWindowProc"/> process this message
        /// so that the entire window tree has a consistent UI state.
        /// When the top-level window receives the <see cref="WM_CHANGEUISTATE"/> message, 
        /// it sends a <see cref="WM_UPDATEUISTATE"/> message with the same parameters to all child windows.
        /// When the system processes the <see cref="WM_UPDATEUISTATE"/> message, it makes the change in the UI state.
        /// </para>
        /// <para>
        /// If the low-order word of wParam is <see cref="UIS_INITIALIZE"/>,
        /// the system will send the <see cref="WM_UPDATEUISTATE"/> message with a UI state based on the last input event.
        /// For example, if the last input came from the mouse, the system will hide the keyboard cues.
        /// And, if the last input came from the keyboard, the system will show the keyboard cues.
        /// If the state that results from processing <see cref="WM_CHANGEUISTATE"/> is the same as the old state,
        /// <see cref="DefWindowProc"/> does not send this message.
        /// </para>
        /// </remarks>
        WM_CHANGEUISTATE = 0x0127,

        /// <summary>
        /// <para>
        /// Sent when a menu is about to become active.
        /// It occurs when the user clicks an item on the menu bar or presses a menu key.
        /// This allows the application to modify the menu before it is displayed.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the menu to be initialized.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// A <see cref="WM_INITMENU"/> message is sent only when a menu is first accessed;
        /// only one <see cref="WM_INITMENU"/> message is generated for each access.
        /// For example, moving the mouse across several menu items while holding down the button does not generate new messages.
        /// <see cref="WM_INITMENU"/> does not provide information about menu items.
        /// </remarks>
        WM_INITMENU = 0x0116,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_QUERYUISTATE"/> message to retrieve the UI state for a window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be 0.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be 0.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is <see cref="NULL"/> if the focus indicators and the keyboard accelerators are visible.
        /// Otherwise, the return value can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UISF_ACTIVE"/>
        /// </para>
        /// <para>
        /// 0x4
        /// </para>
        /// </term>
        /// <term>
        /// A control should be drawn in the style used for active controls.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UISF_HIDEACCEL"/>
        /// </para>
        /// <para>
        /// 0x2
        /// </para>
        /// </term>
        /// <term>
        /// Keyboard accelerators are hidden.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UISF_HIDEFOCUS"/>
        /// </para>
        /// <para>
        /// 0x1
        /// </para>
        /// </term>
        /// <term>
        /// Focus indicators are hidden.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        WM_QUERYUISTATE = 0x0129,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_UPDATEUISTATE"/> message
        /// to change the UI state for the specified window and all its child windows.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word specifies the action to be performed. This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UIS_CLEAR"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The UI state element specified by the high-order word should be visible.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UIS_INITIALIZE"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// The UI state element specified by the high-order word should be changed based on the last input event.
        /// For more information, see Remarks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UIS_SET"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The UI state element specified by the high-order word should be hidden.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The high-order word specifies which UI state elements are affected or the style of the control.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UISF_ACTIVE"/>
        /// </para>
        /// <para>
        /// 0x4
        /// </para>
        /// </term>
        /// <term>
        /// A control should be drawn in the style used for active controls.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UISF_HIDEACCEL"/>
        /// </para>
        /// <para>
        /// 0x2
        /// </para>
        /// </term>
        /// <term>
        /// Keyboard accelerators.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UISF_HIDEFOCUS"/>
        /// </para>
        /// <para>
        /// 0x1
        /// </para>
        /// </term>
        /// <term>
        /// Focus indicators.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A window should send this message to change the UI state of all its child windows.
        /// In contrast to the <see cref="WM_CHANGEUISTATE"/> message, which is a notification,
        /// when <see cref="DefWindowProc"/> processes the <see cref="WM_UPDATEUISTATE"/> message
        /// it changes the UI state and propagates the changes to all child windows.
        /// </para>
        /// <para>
        /// The <see cref="DefWindowProc"/> function updates the UI state according to the wParam value.
        /// If the UI state is modified, the function sends the message to all the immediate child windows.
        /// <see cref="DefWindowProc"/> also sends this message when it receives a <see cref="WM_CHANGEUISTATE"/> message
        /// notifying the system that a child window intends to modify the UI state.
        /// </para>
        /// </remarks>
        WM_UPDATEUISTATE = 0x0128,

        #endregion

        #region Keyboard Accelerator Notifications

        /// <summary>
        /// <para>
        /// Sent when a drop-down menu or submenu is about to become active.
        /// This allows an application to modify the menu before it is displayed, without changing the entire menu.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the drop-down menu or submenu.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the zero-based relative position of the menu item that opens the drop-down menu or submenu.
        /// </para>
        /// <para>
        /// The high-order word indicates whether the drop-down menu is the window menu.
        /// If the menu is the window menu, this parameter is <see cref="TRUE"/>; otherwise, it is <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        WM_INITMENUPOPUP = 0x0117,

        /// <summary>
        /// <para>
        /// Sent when a menu is active and the user presses a key that does not correspond to any mnemonic or accelerator key.
        /// This message is sent to the window that owns the menu.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word specifies the character code that corresponds to the key the user pressed.
        /// </para>
        /// <para>
        /// The high-order word specifies the active menu type.
        /// This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_POPUP"/>
        /// </para>
        /// <para>
        /// 0x00000010L
        /// </para>
        /// </term>
        /// <term>
        /// A drop-down menu, submenu, or shortcut menu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SYSMENU"/>
        /// </para>
        /// <para>
        /// 0x00002000L
        /// </para>
        /// </term>
        /// <term>
        /// The window menu.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the active menu.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application that processes this message should return one of the following values in the high-order word of the return value.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MNC_CLOSE"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Informs the system that it should close the active menu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MNC_EXECUTE"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Informs the system that it should choose the item specified in the low-order word of the return value.
        /// The owner window receives a <see cref="WM_COMMAND"/> message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MNC_IGNORE"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Informs the system that it should discard the character the user pressed and create a short beep on the system speaker.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MNC_SELECT"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// Informs the system that it should select the item specified in the low-order word of the return value.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The low-order word is ignored if the high-order word contains 0 or 1.
        /// </para>
        /// <para>
        /// An application should process this message when an accelerator is used to select a menu item that displays a bitmap.
        /// </para>
        /// </remarks>
        WM_MENUCHAR = 0x0120,

        /// <summary>
        /// <para>
        /// Sent to a menu's owner window when the user selects a menu item.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word specifies the menu item or submenu index.
        /// If the selected item is a command item, this parameter contains the identifier of the menu item.
        /// If the selected item opens a drop-down menu or submenu,
        /// this parameter contains the index of the drop-down menu or submenu in the main menu,
        /// and the lParam parameter contains the handle to the main (clicked) menu;
        /// use the <see cref="GetSubMenu"/> function to get the menu handle to the drop-down menu or submenu.
        /// </para>
        /// <para>
        /// The high-order word specifies one or more menu flags.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_BITMAP"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// Item displays a bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_CHECKED"/>
        /// </para>
        /// <para>
        /// 0x00000008L
        /// </para>
        /// </term>
        /// <term>
        /// Item is checked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_DISABLED"/>
        /// </para>
        /// <para>
        /// 0x00000002L
        /// </para>
        /// </term>
        /// <term>
        /// Item is disabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_GRAYED"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// Item is grayed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_HILITE"/>
        /// </para>
        /// <para>
        /// 0x00000080L
        /// </para>
        /// </term>
        /// <term>
        /// Item is highlighted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_MOUSESELECT"/>
        /// </para>
        /// <para>
        /// 0x00008000L
        /// </para>
        /// </term>
        /// <term>
        /// Item is selected with the mouse.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_OWNERDRAW"/>
        /// </para>
        /// <para>
        /// 0x00000100L
        /// </para>
        /// </term>
        /// <term>
        /// Item is an owner-drawn item.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_POPUP"/>
        /// </para>
        /// <para>
        /// 0x00000010L
        /// </para>
        /// </term>
        /// <term>
        /// Item opens a drop-down menu or submenu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MF_SYSMENU"/>
        /// </para>
        /// <para>
        /// 0x00002000L
        /// </para>
        /// </term>
        /// <term>
        /// Item is contained in the window menu.
        /// The <see cref="lParam"/> parameter contains a handle to the menu associated with the message.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the menu that was clicked.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the high-order word of wParam contains 0xFFFF and the lParam parameter contains <see cref="NULL"/>, the system has closed the menu.
        /// </para>
        /// <para>
        /// Do not use the value 1 for the high-order word of wParam, because this value is specified as <c>(UINT) HIWORD(wParam)</c>.
        /// If the value is 0xFFFF, it would be interpreted as 0x0000FFFF, not 1, because of the cast to a <see cref="UINT"/>.
        /// </para>
        /// </remarks>
        WM_MENUSELECT = 0x011F,

        /// <summary>
        /// <para>
        /// Posted to the window with the keyboard focus
        /// when a <see cref="WM_SYSKEYDOWN"/> message is translated by the <see cref="TranslateMessage"/> function.
        /// It specifies the character code of a system character key that is,
        /// a character key that is pressed while the ALT key is down.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The character code of the window menu key.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The repeat count, scan code, extended-key flag, context code, previous key-state flag,
        /// and transition-state flag, as shown in the following table.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0 15
        /// </term>
        /// <term>
        /// The repeat count for the current message.
        /// The value is the number of times the keystroke was auto-repeated as a result of the user holding down the key.
        /// If the keystroke is held long enough, multiple messages are sent.
        /// However, the repeat count is not cumulative.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16 23
        /// </term>
        /// <term>
        /// The scan code. The value depends on the original equipment manufacturer (OEM).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Indicates whether the key is an extended key,
        /// such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard.
        /// The value is 1 if it is an extended key; otherwise, it is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25 28
        /// </term>
        /// <term>
        /// Reserved; do not use.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// The context code. The value is 1 if the ALT key is held down while the key is pressed; otherwise, the value is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// The previous key state. The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// The transition state. The value is 1 if the key is being released, or it is 0 if the key is being pressed.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// For more detail, see Keystroke Message Flags.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// When the context code is zero, the message can be passed to the <see cref="TranslateAccelerator"/> function,
        /// which will handle it as though it were a standard key message instead of a system character-key message.
        /// This allows accelerator keys to be used with the active window even if the active window does not have the keyboard focus.
        /// </para>
        /// <para>
        /// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and CTRL keys on the main section of the keyboard;
        /// the INS, DEL, HOME, END, PAGE UP, PAGE DOWN and arrow keys in the clusters to the left of the numeric keypad;
        /// the PRINT SCRN key; the BREAK key; the NUMLOCK key; and the divide (/) and ENTER keys in the numeric keypad.
        /// Other keyboards may support the extended-key bit in the parameter.
        /// </para>
        /// </remarks>
        WM_SYSCHAR = 0x0106,

        /// <summary>
        /// <para>
        /// A window receives this message when the user chooses a command from the Window menu
        /// (formerly known as the system or control menu)
        /// or when the user chooses the maximize button, minimize button, restore button, or close button.
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The type of system command requested. This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_CLOSE"/>
        /// </para>
        /// <para>
        /// 0xF060
        /// </para>
        /// </term>
        /// <term>
        /// Closes the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_CONTEXTHELP"/>
        /// </para>
        /// <para>
        /// 0xF180
        /// </para>
        /// </term>
        /// <term>
        /// Changes the cursor to a question mark with a pointer.
        /// If the user then clicks a control in the dialog box, the control receives a <see cref="WM_HELP"/> message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_DEFAULT"/>
        /// </para>
        /// <para>
        /// 0xF160
        /// </para>
        /// </term>
        /// <term>
        /// Selects the default item; the user double-clicked the window menu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_HOTKEY"/>
        /// </para>
        /// <para>
        /// 0xF150
        /// </para>
        /// </term>
        /// <term>
        /// Activates the window associated with the application-specified hot key.
        /// The lParam parameter identifies the window to activate.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_HSCROLL"/>
        /// </para>
        /// <para>
        /// 0xF080
        /// </para>
        /// </term>
        /// <term>
        /// Scrolls horizontally.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SCF_ISSECURE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Indicates whether the screen saver is secure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_KEYMENU"/>
        /// </para>
        /// <para>
        /// 0xF100
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the window menu as a result of a keystroke.
        /// For more information, see the Remarks section.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_MAXIMIZE"/>
        /// </para>
        /// <para>
        /// 0xF030
        /// </para>
        /// </term>
        /// <term>
        /// Maximizes the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_MINIMIZE"/>
        /// </para>
        /// <para>
        /// 0xF020
        /// </para>
        /// </term>
        /// <term>
        /// Minimizes the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_MONITORPOWER"/>
        /// </para>
        /// <para>
        /// 0xF170
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Sets the state of the display.
        /// This command supports devices that have power-saving features, such as a battery-powered personal computer.
        /// </para>
        /// <para>
        /// The <see cref="lParam"/> parameter can have the following values:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// -1 (the display is powering on)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// 1 (the display is going to low power)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// 2 (the display is being shut off)
        /// </description>
        /// </item>
        /// </list>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_MOUSEMENU"/>
        /// </para>
        /// <para>
        /// 0xF090
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the window menu as a result of a mouse click.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_MOVE"/>
        /// </para>
        /// <para>
        /// 0xF010
        /// </para>
        /// </term>
        /// <term>
        /// Moves the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_NEXTWINDOW"/>
        /// </para>
        /// <para>
        /// 0xF040
        /// </para>
        /// </term>
        /// <term>
        /// Moves to the next window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_PREVWINDOW"/>
        /// </para>
        /// <para>
        /// 0xF050
        /// </para>
        /// </term>
        /// <term>
        /// Moves to the previous window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_RESTORE"/>
        /// </para>
        /// <para>
        /// 0xF120
        /// </para>
        /// </term>
        /// <term>
        /// Restores the window to its normal position and size.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_SCREENSAVE"/>
        /// </para>
        /// <para>
        /// 0xF140
        /// </para>
        /// </term>
        /// <term>
        /// Executes the screen saver application specified in the [boot] section of the System.ini file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_SIZE"/>
        /// </para>
        /// <para>
        /// 0xF000
        /// </para>
        /// </term>
        /// <term>
        /// Sizes the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_TASKLIST"/>
        /// </para>
        /// <para>
        /// 0xF130
        /// </para>
        /// </term>
        /// <term>
        /// Activates the <see cref="Start"/> menu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SC_VSCROLL"/>
        /// </para>
        /// <para>
        /// 0xF070
        /// </para>
        /// </term>
        /// <term>
        /// Scrolls vertically.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the horizontal position of the cursor, in screen coordinates,
        /// if a window menu command is chosen with the mouse.
        /// Otherwise, this parameter is not used.
        /// </para>
        /// <para>
        /// The high-order word specifies the vertical position of the cursor, in screen coordinates,
        /// if a window menu command is chosen with the mouse.
        /// This parameter is 1 if the command is chosen using a system accelerator, or zero if using a mnemonic.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// To obtain the position coordinates in screen coordinates, use the following code:
        /// </para>
        /// <para>
        /// The <see cref="DefWindowProc"/> function carries out the window menu request for the predefined actions specified in the previous table.
        /// </para>
        /// <para>
        /// In <see cref="WM_SYSCOMMAND"/> messages, the four low-order bits of the wParam parameter are used internally by the system.
        /// To obtain the correct result when testing the value of wParam,
        /// an application must combine the value 0xFFF0 with the wParam value by using the bitwise AND operator.
        /// </para>
        /// <para>
        /// The menu items in a window menu can be modified by using the <see cref="GetSystemMenu"/>, <see cref="AppendMenu"/>,
        /// <see cref="InsertMenu"/>, <see cref="ModifyMenu"/>, <see cref="InsertMenuItem"/>, and <see cref="SetMenuItemInfo"/> functions.
        /// Applications that modify the window menu must process <see cref="WM_SYSCOMMAND"/> messages.
        /// </para>
        /// <para>
        /// An application can carry out any system command at any time by passing a <see cref="WM_SYSCOMMAND"/> message to <see cref="DefWindowProc"/>.
        /// Any <see cref="WM_SYSCOMMAND"/> messages not handled by the application must be passed to <see cref="DefWindowProc"/>.
        /// Any command values added by an application must be processed by the application and cannot be passed to <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// If password protection is enabled by policy, the screen saver is started regardless of
        /// what an application does with the <see cref="SC_SCREENSAVE"/> notification even if fails to pass it to <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// Accelerator keys that are defined to choose items from the window menu are translated into <see cref="WM_SYSCOMMAND"/> messages;
        /// all other accelerator keystrokes are translated into <see cref="WM_COMMAND"/> messages.
        /// </para>
        /// <para>
        /// If the wParam is <see cref="SC_KEYMENU"/>, lParam contains the character code of the key
        /// that is used with the ALT key to display the popup menu.
        /// For example, pressing ALT+F to display the File popup will cause a <see cref="WM_SYSCOMMAND"/>
        /// with wParam equal to <see cref="SC_KEYMENU"/> and lParam equal to 'f'.
        /// </para>
        /// </remarks>
        WM_SYSCOMMAND = 0x0112,

        #endregion

        #region Keyboard Input Messages

        /// <summary>
        /// <para>
        /// Sent to determine the hot key associated with a window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Not used; must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Not used; must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is the virtual-key code and modifiers for the hot key,
        /// or <see cref="NULL"/> if no hot key is associated with the window.
        /// The virtual-key code is in the low byte of the return value and the modifiers are in the high byte.
        /// The modifiers can be a combination of the following flags from CommCtrl.h.
        /// </para>
        /// </summary>
        WM_GETHOTKEY = 0x0033,

        /// <summary>
        /// <para>
        /// Sent to a window to associate a hot key with the window.
        /// When the user presses the hot key, the system activates the window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low byte of the low-order word specifies the virtual-key code to associate with the window.
        /// </para>
        /// <para>
        /// The high byte of the low-order word can be one or more of the following values from CommCtrl.h.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HOTKEYF_ALT"/>
        /// </para>
        /// <para>
        /// 0x04
        /// </para>
        /// </term>
        /// <term>
        /// ALT key
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HOTKEYF_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x02
        /// </para>
        /// </term>
        /// <term>
        /// CTRL key
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HOTKEYF_EXT"/>
        /// </para>
        /// <para>
        /// 0x08
        /// </para>
        /// </term>
        /// <term>
        /// Extended key
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HOTKEYF_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x01
        /// </para>
        /// </term>
        /// <term>
        /// SHIFT key
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The high-order word of wParam is ignored.
        /// </para>
        /// <para>
        /// Setting wParam to <see cref="NULL"/> removes the hot key associated with a window.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is one of the following.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// -1
        /// </term>
        /// <term>
        /// The function is unsuccessful; the hot key is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// The function is unsuccessful; the window is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// The function is successful, and no other window has the same hot key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// The function is successful, but another window already has the same hot key.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A hot key cannot be associated with a child window.
        /// </para>
        /// <para>
        /// <see cref="VK_ESCAPE"/>, <see cref="VK_SPACE"/>, <see cref="VK_TAB"/>, and <see cref="VK_PACKET"/> are invalid hot keys.
        /// </para>
        /// <para>
        /// When the user presses the hot key, the system generates a <see cref="WM_SYSCOMMAND"/> message
        /// with wParam equal to <see cref="SC_HOTKEY"/> and lParam equal to the window's handle.
        /// If this message is passed on to <see cref="DefWindowProc"/>,
        /// the system will bring the window's last active popup (if it exists) or the window itself (if there is no popup window) to the foreground.
        /// </para>
        /// <para>
        /// A window can only have one hot key.
        /// If the window already has a hot key associated with it, the new hot key replaces the old one.
        /// If more than one window has the same hot key, the window that is activated by the hot key is random.
        /// </para>
        /// <para>
        /// These hot keys are unrelated to the hot keys set by <see cref="RegisterHotKey"/>.
        /// </para>
        /// </remarks>
        WM_SETHOTKEY = 0x0032,

        #endregion

        #region Keyboard Input Notifications

        /// <summary>
        /// <para>
        /// Sent to both the window being activated and the window being deactivated.
        /// If the windows use the same input queue, the message is sent synchronously,
        /// first to the window procedure of the top-level window being deactivated,
        /// then to the window procedure of the top-level window being activated.
        /// If the windows use different input queues, the message is sent asynchronously, so the window is activated immediately.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word specifies whether the window is being activated or deactivated.
        /// This parameter can be one of the following values.
        /// The high-order word specifies the minimized state of the window being activated or deactivated.
        /// A nonzero value indicates the window is minimized.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WA_ACTIVE"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Activated by some method other than a mouse click
        /// (for example, by a call to the <see cref="SetActiveWindow"/> function or by use of the keyboard interface to select the window).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WA_CLICKACTIVE"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Activated by a mouse click.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WA_INACTIVE"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Deactivated.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the window being activated or deactivated, depending on the value of the wParam parameter.
        /// If the low-order word of wParam is <see cref="WA_INACTIVE"/>, lParam is the handle to the window being activated.
        /// If the low-order word of wParam is <see cref="WA_ACTIVE"/> or <see cref="WA_CLICKACTIVE"/>,
        /// lParam is the handle to the window being deactivated.
        /// This handle can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// If the window is being activated and is not minimized, the <see cref="DefWindowProc"/> function sets the keyboard focus to the window.
        /// If the window is activated by a mouse click, it also receives a <see cref="WM_MOUSEACTIVATE"/> message.
        /// </remarks>
        WM_ACTIVATE = 0x0006,

        /// <summary>
        /// <para>
        /// Notifies a window that the user generated an application command event,
        /// for example, by clicking an application command button using the mouse or typing an application command key on the keyboard.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the window where the user clicked the button or pressed the key.
        /// This can be a child window of the window receiving the message.
        /// For more information about processing this message, see the Remarks section.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Use the following code to get the information contained in the lParam parameter.
        /// </para>
        /// <code>
        /// cmd  = GET_APPCOMMAND_LPARAM(lParam);
        /// 
        /// uDevice = GET_DEVICE_LPARAM(lParam);
        /// 
        /// dwKeys = GET_KEYSTATE_LPARAM(lParam);
        /// </code>
        /// <para>
        /// The application command is cmd, which can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_BASS_BOOST"/>
        /// </para>
        /// <para>
        /// 20
        /// </para>
        /// </term>
        /// <term>
        /// Toggle the bass boost on and off.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_BASS_DOWN"/>
        /// </para>
        /// <para>
        /// 19
        /// </para>
        /// </term>
        /// <term>
        /// Decrease the bass.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_BASS_UP"/>
        /// </para>
        /// <para>
        /// 21
        /// </para>
        /// </term>
        /// <term>
        /// Increase the bass.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_BROWSER_BACKWARD"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Navigate backward.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_BROWSER_FAVORITES"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// Open favorites.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_BROWSER_FORWARD"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Navigate forward.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_BROWSER_HOME"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// Navigate home.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_BROWSER_REFRESH"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// Refresh page.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_BROWSER_SEARCH"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// Open search.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_BROWSER_STOP"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// Stop download.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_CLOSE"/>
        /// </para>
        /// <para>
        /// 31
        /// </para>
        /// </term>
        /// <term>
        /// Close the window (not the application).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_COPY"/>
        /// </para>
        /// <para>
        /// 36
        /// </para>
        /// </term>
        /// <term>
        /// Copy the selection.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_CORRECTION_LIST"/>
        /// </para>
        /// <para>
        /// 45
        /// </para>
        /// </term>
        /// <term>
        /// Brings up the correction list when a word is incorrectly identified during speech input.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_CUT"/>
        /// </para>
        /// <para>
        /// 37
        /// </para>
        /// </term>
        /// <term>
        /// Cut the selection.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_DICTATE_OR_COMMAND_CONTROL_TOGGLE"/>
        /// </para>
        /// <para>
        /// 43
        /// </para>
        /// </term>
        /// <term>
        /// Toggles between two modes of speech input: dictation and command/control (giving commands to an application or accessing menus).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_FIND"/>
        /// </para>
        /// <para>
        /// 28
        /// </para>
        /// </term>
        /// <term>
        /// Open the Find dialog.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_FORWARD_MAIL"/>
        /// </para>
        /// <para>
        /// 40
        /// </para>
        /// </term>
        /// <term>
        /// Forward a mail message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_HELP"/>
        /// </para>
        /// <para>
        /// 27
        /// </para>
        /// </term>
        /// <term>
        /// Open the Help dialog.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_LAUNCH_APP1"/>
        /// </para>
        /// <para>
        /// 17
        /// </para>
        /// </term>
        /// <term>
        /// Start App1.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_LAUNCH_APP2"/>
        /// </para>
        /// <para>
        /// 18
        /// </para>
        /// </term>
        /// <term>
        /// Start App2.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_LAUNCH_MAIL"/>
        /// </para>
        /// <para>
        /// 15
        /// </para>
        /// </term>
        /// <term>
        /// Open mail.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_LAUNCH_MEDIA_SELECT"/>
        /// </para>
        /// <para>
        /// 16
        /// </para>
        /// </term>
        /// <term>
        /// Go to Media Select mode.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MEDIA_CHANNEL_DOWN"/>
        /// </para>
        /// <para>
        /// 52
        /// </para>
        /// </term>
        /// <term>
        /// Decrement the channel value, for example, for a TV or radio tuner.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MEDIA_CHANNEL_UP"/>
        /// </para>
        /// <para>
        /// 51
        /// </para>
        /// </term>
        /// <term>
        /// Increment the channel value, for example, for a TV or radio tuner.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MEDIA_FAST_FORWARD"/>
        /// </para>
        /// <para>
        /// 49
        /// </para>
        /// </term>
        /// <term>
        /// Increase the speed of stream playback.
        /// This can be implemented in many ways, for example, using a fixed speed or toggling through a series of increasing speeds.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MEDIA_NEXTTRACK"/>
        /// </para>
        /// <para>
        /// 11
        /// </para>
        /// </term>
        /// <term>
        /// Go to next track.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MEDIA_PAUSE"/>
        /// </para>
        /// <para>
        /// 47
        /// </para>
        /// </term>
        /// <term>
        /// Pause. If already paused, take no further action.
        /// This is a direct PAUSE command that has no state.
        /// If there are discrete Play and Pause buttons,
        /// applications should take action on this command as well as <see cref="APPCOMMAND_MEDIA_PLAY_PAUSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MEDIA_PLAY"/>
        /// </para>
        /// <para>
        /// 46
        /// </para>
        /// </term>
        /// <term>
        /// Begin playing at the current position.
        /// If already paused, it will resume.
        /// This is a direct PLAY command that has no state.
        /// If there are discrete Play and Pause buttons,
        /// applications should take action on this command as well as <see cref="APPCOMMAND_MEDIA_PLAY_PAUSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MEDIA_PLAY_PAUSE"/>
        /// </para>
        /// <para>
        /// 14
        /// </para>
        /// </term>
        /// <term>
        /// Play or pause playback.
        /// If there are discrete Play and Pause buttons,
        /// applications should take action on this command as well as <see cref="APPCOMMAND_MEDIA_PLAY"/> and <see cref="APPCOMMAND_MEDIA_PAUSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MEDIA_PREVIOUSTRACK"/>
        /// </para>
        /// <para>
        /// 12
        /// </para>
        /// </term>
        /// <term>
        /// Go to previous track.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MEDIA_RECORD"/>
        /// </para>
        /// <para>
        /// 48
        /// </para>
        /// </term>
        /// <term>
        /// Begin recording the current stream.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MEDIA_REWIND"/>
        /// </para>
        /// <para>
        /// 50
        /// </para>
        /// </term>
        /// <term>
        /// Go backward in a stream at a higher rate of speed.
        /// This can be implemented in many ways, for example, using a fixed speed or toggling through a series of increasing speeds.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MEDIA_STOP"/>
        /// </para>
        /// <para>
        /// 13
        /// </para>
        /// </term>
        /// <term>
        /// Stop playback.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MIC_ON_OFF_TOGGLE"/>
        /// </para>
        /// <para>
        /// 44
        /// </para>
        /// </term>
        /// <term>
        /// Toggle the microphone.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MICROPHONE_VOLUME_DOWN"/>
        /// </para>
        /// <para>
        /// 25
        /// </para>
        /// </term>
        /// <term>
        /// Decrease microphone volume.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MICROPHONE_VOLUME_MUTE"/>
        /// </para>
        /// <para>
        /// 24
        /// </para>
        /// </term>
        /// <term>
        /// Mute the microphone.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_MICROPHONE_VOLUME_UP"/>
        /// </para>
        /// <para>
        /// 26
        /// </para>
        /// </term>
        /// <term>
        /// Increase microphone volume.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_NEW"/>
        /// </para>
        /// <para>
        /// 29
        /// </para>
        /// </term>
        /// <term>
        /// Create a new window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_OPEN"/>
        /// </para>
        /// <para>
        /// 30
        /// </para>
        /// </term>
        /// <term>
        /// Open a window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_PASTE"/>
        /// </para>
        /// <para>
        /// 38
        /// </para>
        /// </term>
        /// <term>
        /// Paste
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_PRINT"/>
        /// </para>
        /// <para>
        /// 33
        /// </para>
        /// </term>
        /// <term>
        /// Print current document.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_REDO"/>
        /// </para>
        /// <para>
        /// 35
        /// </para>
        /// </term>
        /// <term>
        /// Redo last action.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_REPLY_TO_MAIL"/>
        /// </para>
        /// <para>
        /// 39
        /// </para>
        /// </term>
        /// <term>
        /// Reply to a mail message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_SAVE"/>
        /// </para>
        /// <para>
        /// 32
        /// </para>
        /// </term>
        /// <term>
        /// Save current document.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_SEND_MAIL"/>
        /// </para>
        /// <para>
        /// 41
        /// </para>
        /// </term>
        /// <term>
        /// Send a mail message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_SPELL_CHECK"/>
        /// </para>
        /// <para>
        /// 42
        /// </para>
        /// </term>
        /// <term>
        /// Initiate a spell check.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_TREBLE_DOWN"/>
        /// </para>
        /// <para>
        /// 22
        /// </para>
        /// </term>
        /// <term>
        /// Decrease the treble.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_TREBLE_UP"/>
        /// </para>
        /// <para>
        /// 23
        /// </para>
        /// </term>
        /// <term>
        /// Increase the treble.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_UNDO"/>
        /// </para>
        /// <para>
        /// 34
        /// </para>
        /// </term>
        /// <term>
        /// Undo last action.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_VOLUME_DOWN"/>
        /// </para>
        /// <para>
        /// 9
        /// </para>
        /// </term>
        /// <term>
        /// Lower the volume.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_VOLUME_MUTE"/>
        /// </para>
        /// <para>
        /// 8
        /// </para>
        /// </term>
        /// <term>
        /// Mute the volume.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="APPCOMMAND_VOLUME_UP"/>
        /// </para>
        /// <para>
        /// 10
        /// </para>
        /// </term>
        /// <term>
        /// Raise the volume.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The uDevice component indicates the input device that generated the input event, and can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FAPPCOMMAND_KEY"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// User pressed a key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FAPPCOMMAND_MOUSE"/>
        /// </para>
        /// <para>
        /// 0x8000
        /// </para>
        /// </term>
        /// <term>
        /// User clicked a mouse button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FAPPCOMMAND_OEM"/>
        /// </para>
        /// <para>
        /// 0x1000
        /// </para>
        /// </term>
        /// <term>
        /// An unidentified hardware source generated the event. It could be a mouse or a keyboard event.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The dwKeys component indicates whether various virtual keys are down, and can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return <see cref="TRUE"/>.
        /// For more information about processing the return value, see the Remarks section.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// <see cref="DefWindowProc"/> generates the <see cref="WM_APPCOMMAND"/> message
        /// when it processes the <see cref="WM_XBUTTONUP"/> or <see cref="WM_NCXBUTTONUP"/> message,
        /// or when the user types an application command key.
        /// </para>
        /// <para>
        /// If a child window does not process this message and instead calls <see cref="DefWindowProc"/>,
        /// <see cref="DefWindowProc"/> will send the message to its parent window.
        /// If a top level window does not process this message and instead calls <see cref="DefWindowProc"/>,
        /// <see cref="DefWindowProc"/> will call a shell hook with the hook code equal to <see cref="HSHELL_APPCOMMAND"/>.
        /// </para>
        /// <para>
        /// To get the coordinates of the cursor if the message was generated by a mouse click,
        /// the application can call <see cref="GetMessagePos"/>.
        /// An application can test whether the message was generated by the mouse
        /// by checking whether lParam contains <see cref="FAPPCOMMAND_MOUSE"/>.
        /// </para>
        /// <para>
        /// Unlike other windows messages, an application should return <see cref="TRUE"/> from this message if it processes it.
        /// Doing so will allow software that simulates this message on Windows systems earlier than Windows 2000
        /// to determine whether the window procedure processed the message or called <see cref="DefWindowProc"/> to process it.
        /// </para>
        /// </remarks>
        WM_APPCOMMAND = 0x0319,

        /// <summary>
        /// <para>
        /// Posted to the window with the keyboard focus
        /// when a <see cref="WM_KEYDOWN"/> message is translated by the <see cref="TranslateMessage"/> function.
        /// The <see cref="WM_CHAR"/> message contains the character code of the key that was pressed.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The character code of the key.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The repeat count, scan code, extended-key flag, context code, previous key-state flag,
        /// and transition-state flag, as shown in the following table.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-15
        /// </term>
        /// <term>
        /// The repeat count for the current message.
        /// The value is the number of times the keystroke is autorepeated as a result of the user holding down the key.
        /// If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16-23
        /// </term>
        /// <term>
        /// The scan code. The value depends on the OEM.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Indicates whether the key is an extended key,
        /// such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard.
        /// The value is 1 if it is an extended key; otherwise, it is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25-28
        /// </term>
        /// <term>
        /// Reserved; do not use.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// The context code.
        /// The value is 1 if the ALT key is held down while the key is pressed; otherwise, the value is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// The previous key state.
        /// The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// The transition state.
        /// The value is 1 if the key is being released, or it is 0 if the key is being pressed.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// For more detail, see Keystroke Message Flags.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="WM_CHAR"/> message uses UTF-16 (16-bit Unicode Transformation Format) code units
        /// in its wParam if the Unicode version of the <see cref="RegisterClass"/> function was used to register the window class.
        /// Otherwise, the system provides characters in the current process code page,
        /// which can be set to UTF-8 in Windows Version 1903 (May 2019 Update) and newer.
        /// For more information, see Registering Window Classes and Use UTF-8 code pages in Windows apps.
        /// </para>
        /// <para>
        /// Starting with Windows Vista, <see cref="WM_CHAR"/> message can send UTF-16 surrogate pairs to Unicode windows.
        /// Use the <see cref="IS_HIGH_SURROGATE"/>, <see cref="IS_LOW_SURROGATE"/>,
        /// and <see cref="IS_SURROGATE_PAIR"/> macros to detect such cases, if necessary.
        /// </para>
        /// <para>
        /// There is not necessarily a one-to-one correspondence between keys pressed and character messages generated,
        /// and so the information in the high-order word of the lParam parameter is generally not useful to applications.
        /// The information in the high-order word applies only to the most recent <see cref="WM_KEYDOWN"/> message
        /// that precedes the posting of the <see cref="WM_CHAR"/> message.
        /// </para>
        /// <para>
        /// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and the right CTRL keys on the main section of the keyboard;
        /// the INS, DEL, HOME, END, PAGE UP, PAGE DOWN and arrow keys in the clusters to the left of the numeric keypad;
        /// and the divide (/) and ENTER keys in the numeric keypad.
        /// Some other keyboards may support the extended-key bit in the lParam parameter.
        /// </para>
        /// <para>
        /// The <see cref="WM_UNICHAR"/> message is the same as <see cref="WM_CHAR"/>, except it uses UTF-32.
        /// It is designed to send or post Unicode characters to ANSI windows,
        /// and it can handle Unicode Supplementary Plane characters.
        /// </para>
        /// </remarks>
        WM_CHAR = 0x0102,

        /// <summary>
        /// <para>
        /// Posted to the window with the keyboard focus
        /// when a <see cref="WM_KEYUP"/> message is translated by the <see cref="TranslateMessage"/> function.
        /// <see cref="WM_DEADCHAR"/> specifies a character code generated by a dead key.
        /// A dead key is a key that generates a character, such as the umlaut (double-dot),
        /// that is combined with another character to form a composite character.
        /// For example, the umlaut-O character ( ) is generated by typing the dead key for the umlaut character, and then typing the O key.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The character code generated by the dead key.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The repeat count, scan code, extended-key flag, context code,
        /// previous key-state flag, and transition-state flag, as shown in the following table.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-15
        /// </term>
        /// <term>
        /// The repeat count for the current message.
        /// The value is the number of times the keystroke is autorepeated as a result of the user holding down the key.
        /// If the keystroke is held long enough, multiple messages are sent.
        /// However, the repeat count is not cumulative.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16-23
        /// </term>
        /// <term>
        /// The scan code. The value depends on the OEM.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Indicates whether the key is an extended key,
        /// such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard.
        /// The value is 1 if it is an extended key; otherwise, it is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25-28
        /// </term>
        /// <term>
        /// Reserved; do not use.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// The context code.
        /// The value is 1 if the ALT key is held down while the key is pressed; otherwise, the value is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// The previous key state.
        /// The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// The transition state.
        /// The value is 1 if the key is being released, or it is 0 if the key is being pressed.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// For more detail, see Keystroke Message Flags.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="WM_DEADCHAR"/> message typically is used by applications to give the user feedback about each key pressed.
        /// For example, an application can display the accent in the current character position without moving the caret.
        /// </para>
        /// <para>
        /// Because there is not necessarily a one-to-one correspondence between keys pressed and character messages generated,
        /// the information in the high-order word of the lParam parameter is generally not useful to applications.
        /// The information in the high-order word applies only to the most recent <see cref="WM_KEYDOWN"/> message
        /// that precedes the posting of the <see cref="WM_DEADCHAR"/> message.
        /// </para>
        /// <para>
        /// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and the right CTRL keys on the main section of the keyboard;
        /// the INS, DEL, HOME, END, PAGE UP, PAGE DOWN and arrow keys in the clusters to the left of the numeric keypad;
        /// and the divide (/) and ENTER keys in the numeric keypad.
        /// Some other keyboards may support the extended-key bit in the lParam parameter.
        /// </para>
        /// </remarks>
        WM_DEADCHAR = 0x0103,

        /// <summary>
        /// <para>
        /// Posted when the user presses a hot key registered by the <see cref="RegisterHotKey"/> function.
        /// The message is placed at the top of the message queue associated with the thread that registered the hot key.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The identifier of the hot key that generated the message.
        /// If the message was generated by a system-defined hot key, this parameter will be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDHOT_SNAPDESKTOP"/>
        /// </para>
        /// <para>
        /// -2
        /// </para>
        /// </term>
        /// <term>
        /// The "snap desktop" hot key was pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDHOT_SNAPWINDOW"/>
        /// </para>
        /// <para>
        /// -1
        /// </para>
        /// </term>
        /// <term>
        /// The "snap window" hot key was pressed.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the keys that were to be pressed in combination
        /// with the key specified by the high-order word to generate the <see cref="WM_HOTKEY"/> message.
        /// This word can be one or more of the following values.
        /// The high-order word specifies the virtual key code of the hot key.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOD_ALT"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Either ALT key was held down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOD_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Either CTRL key was held down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOD_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// Either SHIFT key was held down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOD_WIN"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Either WINDOWS key was held down.
        /// These keys are labeled with the Windows logo.
        /// Hotkeys that involve the Windows key are reserved for use by the operating system.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// <see cref="WM_HOTKEY"/> is unrelated to the <see cref="WM_GETHOTKEY"/> and <see cref="WM_SETHOTKEY"/> hot keys.
        /// The <see cref="WM_HOTKEY"/> message is sent for generic hot keys
        /// while the <see cref="WM_SETHOTKEY"/> and <see cref="WM_GETHOTKEY"/> messages relate to window activation hot keys.
        /// </remarks>
        WM_HOTKEY = 0x0312,

        /// <summary>
        /// <para>
        /// Posted to the window with the keyboard focus when a nonsystem key is pressed.
        /// A nonsystem key is a key that is pressed when the ALT key is not pressed.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The virtual-key code of the nonsystem key. See Virtual-Key Codes.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The repeat count, scan code, extended-key flag, context code,
        /// previous key-state flag, and transition-state flag, as shown following.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-15
        /// </term>
        /// <term>
        /// The repeat count for the current message.
        /// The value is the number of times the keystroke is autorepeated as a result of the user holding down the key.
        /// If the keystroke is held long enough, multiple messages are sent.
        /// However, the repeat count is not cumulative.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16-23
        /// </term>
        /// <term>
        /// The scan code.
        /// The value depends on the OEM.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Indicates whether the key is an extended key,
        /// such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard.
        /// The value is 1 if it is an extended key; otherwise, it is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25-28
        /// </term>
        /// <term>
        /// Reserved; do not use.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// The context code.
        /// The value is always 0 for a <see cref="WM_KEYDOWN"/> message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// The previous key state.
        /// The value is 1 if the key is down before the message is sent, or it is zero if the key is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// The transition state.
        /// The value is always 0 for a <see cref="WM_KEYDOWN"/> message.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// For more detail, see Keystroke Message Flags.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the F10 key is pressed, the <see cref="DefWindowProc"/> function sets an internal flag.
        /// When <see cref="DefWindowProc"/> receives the <see cref="WM_KEYUP"/> message,
        /// the function checks whether the internal flag is set and, if so, sends a <see cref="WM_SYSCOMMAND"/> message to the top-level window.
        /// The <see cref="WM_SYSCOMMAND"/> parameter of the message is set to <see cref="SC_KEYMENU"/>.
        /// </para>
        /// <para>
        /// Because of the autorepeat feature, more than one <see cref="WM_KEYDOWN"/> message
        /// may be posted before a <see cref="WM_KEYUP"/> message is posted.
        /// The previous key state (bit 30) can be used to determine
        /// whether the <see cref="WM_KEYDOWN"/> message indicates the first down transition or a repeated down transition.
        /// </para>
        /// <para>
        /// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and CTRL keys on the main section of the keyboard;
        /// the INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad;
        /// and the divide (/) and ENTER keys in the numeric keypad.
        /// Other keyboards may support the extended-key bit in the lParam parameter.
        /// </para>
        /// <para>
        /// Applications must pass wParam to <see cref="TranslateMessage"/> without altering it at all.
        /// </para>
        /// </remarks>
        WM_KEYDOWN = 0x0100,

        /// <summary>
        /// <para>
        /// Posted to the window with the keyboard focus when a nonsystem key is released.
        /// A nonsystem key is a key that is pressed when the ALT key is not pressed,
        /// or a keyboard key that is pressed when a window has the keyboard focus.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The virtual-key code of the nonsystem key. See Virtual-Key Codes.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The repeat count, scan code, extended-key flag, context code,
        /// previous key-state flag, and transition-state flag, as shown in the following table.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-15
        /// </term>
        /// <term>
        /// The repeat count for the current message.
        /// The value is the number of times the keystroke is autorepeated as a result of the user holding down the key.
        /// The repeat count is always 1 for a <see cref="WM_KEYUP"/> message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16-23
        /// </term>
        /// <term>
        /// The scan code. The value depends on the OEM.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Indicates whether the key is an extended key,
        /// such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard.
        /// The value is 1 if it is an extended key; otherwise, it is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25-28
        /// </term>
        /// <term>
        /// Reserved; do not use.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// The context code.
        /// The value is always 0 for a <see cref="WM_KEYUP"/> message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// The previous key state.
        /// The value is always 1 for a <see cref="WM_KEYUP"/> message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// The transition state.
        /// The value is always 1 for a <see cref="WM_KEYUP"/> message.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// For more detail, see Keystroke Message Flags.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the F10 key is pressed, the <see cref="DefWindowProc"/> function sets an internal flag.
        /// When <see cref="DefWindowProc"/> receives the <see cref="WM_KEYUP"/> message,
        /// the function checks whether the internal flag is set and, if so, sends a <see cref="WM_SYSCOMMAND"/> message to the top-level window.
        /// The <see cref="WM_SYSCOMMAND"/> parameter of the message is set to <see cref="SC_KEYMENU"/>.
        /// </para>
        /// <para>
        /// Because of the autorepeat feature, more than one <see cref="WM_KEYDOWN"/> message
        /// may be posted before a <see cref="WM_KEYUP"/> message is posted.
        /// The previous key state (bit 30) can be used to determine
        /// whether the <see cref="WM_KEYDOWN"/> message indicates the first down transition or a repeated down transition.
        /// </para>
        /// <para>
        /// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and CTRL keys on the main section of the keyboard;
        /// the INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad;
        /// and the divide (/) and ENTER keys in the numeric keypad.
        /// Other keyboards may support the extended-key bit in the lParam parameter.
        /// </para>
        /// <para>
        /// Applications must pass wParam to <see cref="TranslateMessage"/> without altering it at all.
        /// </para>
        /// </remarks>
        WM_KEYUP = 0x0101,

        /// <summary>
        /// <para>
        /// Sent to a window immediately before it loses the keyboard focus.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the window that receives the keyboard focus.
        /// This parameter can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If an application is displaying a caret, the caret should be destroyed at this point.
        /// </para>
        /// <para>
        /// While processing this message, do not make any function calls that display or activate a window.
        /// This causes the thread to yield control and can cause the application to stop responding to messages.
        /// For more information, see Message Deadlocks.
        /// </para>
        /// </remarks>
        WM_KILLFOCUS = 0x0008,

        /// <summary>
        /// <para>
        /// Sent to a window after it has gained the keyboard focus.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the window that has lost the keyboard focus.
        /// This parameter can be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// To display a caret, an application should call the appropriate caret functions
        /// when it receives the <see cref="WM_SETFOCUS"/> message.
        /// </remarks>
        WM_SETFOCUS = 0x0007,

        /// <summary>
        /// <para>
        /// Sent to the window with the keyboard focus
        /// when a <see cref="WM_SYSKEYDOWN"/> message is translated by the <see cref="TranslateMessage"/> function.
        /// <see cref="WM_SYSDEADCHAR"/> specifies the character code of a system dead key that is,
        /// a dead key that is pressed while holding down the ALT key.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The character code generated by the system dead key that is,
        /// a dead key that is pressed while holding down the ALT key.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The repeat count, scan code, extended-key flag, context code,
        /// previous key-state flag, and transition-state flag, as shown in the following table.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-15
        /// </term>
        /// <term>
        /// The repeat count for the current message.
        /// The value is the number of times the keystroke is autorepeated as a result of the user holding down the key.
        /// If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16-23
        /// </term>
        /// <term>
        /// The scan code. The value depends on the OEM.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard.
        /// The value is 1 if it is an extended key; otherwise, it is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25-28
        /// </term>
        /// <term>
        /// Reserved; do not use.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// The context code.
        /// The value is 1 if the ALT key is held down while the key is pressed; otherwise, the value is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// The previous key state.
        /// The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// Transition state.
        /// The value is 1 if the key is being released, or it is 0 if the key is being pressed.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// For more detail, see Keystroke Message Flags.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and CTRL keys on the main section of the keyboard;
        /// the INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad;
        /// and the divide (/) and ENTER keys in the numeric keypad.
        /// Other keyboards may support the extended-key bit in the lParam parameter.
        /// </remarks>
        WM_SYSDEADCHAR = 0x0107,

        /// <summary>
        /// <para>
        /// Posted to the window with the keyboard focus
        /// when the user presses the F10 key (which activates the menu bar) or holds down the ALT key and then presses another key.
        /// It also occurs when no window currently has the keyboard focus;
        /// in this case, the <see cref="WM_SYSKEYDOWN"/> message is sent to the active window.
        /// The window that receives the message can distinguish
        /// between these two contexts by checking the context code in the lParam parameter.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The virtual-key code of the key being pressed. See Virtual-Key Codes.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The repeat count, scan code, extended-key flag, context code,
        /// previous key-state flag, and transition-state flag, as shown in the following table.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-15
        /// </term>
        /// <term>
        /// The repeat count for the current message.
        /// The value is the number of times the keystroke is autorepeated as a result of the user holding down the key.
        /// If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16-23
        /// </term>
        /// <term>
        /// The scan code.
        /// The value depends on the OEM.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard.
        /// The value is 1 if it is an extended key; otherwise, it is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25-28
        /// </term>
        /// <term>
        /// Reserved; do not use.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// The context code.
        /// The value is 1 if the ALT key is down while the key is pressed;
        /// it is 0 if the <see cref="WM_SYSKEYDOWN"/> message is posted to the active window because no window has the keyboard focus.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// The previous key state.
        /// The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// The transition state.
        /// The value is always 0 for a <see cref="WM_SYSKEYDOWN"/> message.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// For more detail, see Keystroke Message Flags.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="DefWindowProc"/> function examines the specified key
        /// and generates a <see cref="WM_SYSCOMMAND"/> message if the key is either TAB or ENTER.
        /// </para>
        /// <para>
        /// When the context code is zero, the message can be passed to the <see cref="TranslateAccelerator"/> function,
        /// which will handle it as though it were a normal key message instead of a character-key message.
        /// This allows accelerator keys to be used with the active window even if the active window does not have the keyboard focus.
        /// </para>
        /// <para>
        /// Because of automatic repeat, more than one <see cref="WM_SYSKEYDOWN"/> message
        /// may occur before a <see cref="WM_SYSKEYUP"/> message is sent.
        /// The previous key state (bit 30) can be used to determine
        /// whether the <see cref="WM_SYSKEYDOWN"/> message indicates the first down transition or a repeated down transition.
        /// </para>
        /// <para>
        /// For enhanced 101- and 102-key keyboards, enhanced keys are the right ALT and CTRL keys on the main section of the keyboard;
        /// the INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad;
        /// and the divide (/) and ENTER keys in the numeric keypad.
        /// Other keyboards may support the extended-key bit in the lParam parameter.
        /// </para>
        /// <para>
        /// This message is also sent whenever the user presses the F10 key without the ALT key.
        /// </para>
        /// </remarks>
        WM_SYSKEYDOWN = 0x0104,

        /// <summary>
        /// <para>
        /// Posted to the window with the keyboard focus
        /// when the user releases a key that was pressed while the ALT key was held down.
        /// It also occurs when no window currently has the keyboard focus;
        /// in this case, the <see cref="WM_SYSKEYUP"/> message is sent to the active window.
        /// The window that receives the message can distinguish
        /// between these two contexts by checking the context code in the lParam parameter.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The virtual-key code of the key being released. See Virtual-Key Codes.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The repeat count, scan code, extended-key flag, context code,
        /// previous key-state flag, and transition-state flag, as shown in the following table.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-15
        /// </term>
        /// <term>
        /// The repeat count for the current message.
        /// The value is the number of times the keystroke is autorepeated as a result of the user holding down the key.
        /// The repeat count is always one for a <see cref="WM_SYSKEYUP"/> message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16-23
        /// </term>
        /// <term>
        /// The scan code.
        /// The value depends on the OEM.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard.
        /// The value is 1 if it is an extended key; otherwise, it is zero.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25-28
        /// </term>
        /// <term>
        /// Reserved; do not use.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// The context code.
        /// The value is 1 if the ALT key is down while the key is released;
        /// it is zero if the <see cref="WM_SYSKEYUP"/> message is posted to the active window because no window has the keyboard focus.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// The previous key state.
        /// The value is always 1 for a <see cref="WM_SYSKEYUP"/> message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// The transition state.
        /// The value is always 1 for a <see cref="WM_SYSKEYUP"/> message.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// For more details, see Keystroke Message Flags.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="DefWindowProc"/> function sends a <see cref="WM_SYSCOMMAND"/> message
        /// to the top-level window if the F10 key or the ALT key was released.
        /// The wParam parameter of the message is set to <see cref="SC_KEYMENU"/>.
        /// </para>
        /// <para>
        /// When the context code is zero, the message can be passed to the <see cref="TranslateAccelerator"/> function,
        /// which will handle it as though it were a normal key message instead of a character-key message.
        /// This allows accelerator keys to be used with the active window even if the active window does not have the keyboard focus.
        /// </para>
        /// <para>
        /// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and CTRL keys on the main section of the keyboard;
        /// the INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad;
        /// and the divide (/) and ENTER keys in the numeric keypad.
        /// Other keyboards may support the extended-key bit in the lParam parameter.
        /// </para>
        /// <para>
        /// For non-U.S. enhanced 102-key keyboards, the right ALT key is handled as a CTRL+ALT key.
        /// The following table shows the sequence of messages that result when the user presses and releases this key.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Message
        /// </term>
        /// <term>
        /// Virtual-key code
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WM_KEYDOWN"/>
        /// </term>
        /// <term>
        /// <see cref="VK_CONTROL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_KEYDOWN"/>
        /// </term>
        /// <term>
        /// <see cref="VK_MENU"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_KEYUP"/>
        /// </term>
        /// <term>
        /// <see cref="VK_CONTROL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_SYSKEYUP"/>
        /// </term>
        /// <term>
        /// <see cref="VK_MENU"/>
        /// </term>
        /// </item>
        /// </list>
        /// </remarks>
        WM_SYSKEYUP = 0x0105,

        /// <summary>
        /// <para>
        /// The <see cref="WM_UNICHAR"/> message can be used by an application to post input to other windows.
        /// This message contains the character code of the key that was pressed.
        /// (Test whether a target app can process <see cref="WM_UNICHAR"/> messages
        /// by sending the message with wParam set to <see cref="UNICODE_NOCHAR"/>.)
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The character code of the key.
        /// </para>
        /// <para>
        /// If wParam is <see cref="UNICODE_NOCHAR"/> and the application processes this message, then return <see cref="TRUE"/>.
        /// The <see cref="DefWindowProc"/> function will return <see cref="FALSE"/> (the default).
        /// </para>
        /// <para>
        /// If wParam is not <see cref="UNICODE_NOCHAR"/>, return <see cref="FALSE"/>.
        /// The Unicode <see cref="DefWindowProc"/> posts a <see cref="WM_CHAR"/> message
        /// with the same parameters and the ANSI <see cref="DefWindowProc"/> function
        /// posts either one or two <see cref="WM_CHAR"/> messages with the corresponding ANSI character(s).
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The repeat count, scan code, extended-key flag, context code,
        /// previous key-state flag, and transition-state flag, as shown in the following table.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0-15
        /// </term>
        /// <term>
        /// The repeat count for the current message.
        /// The value is the number of times the keystroke is autorepeated as a result of the user holding down the key.
        /// If the keystroke is held long enough, multiple messages are sent.
        /// However, the repeat count is not cumulative.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16-23
        /// </term>
        /// <term>
        /// The scan code. The value depends on the OEM.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Indicates whether the key is an extended key,
        /// such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard.
        /// The value is 1 if it is an extended key; otherwise, it is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25-28
        /// </term>
        /// <term>
        /// Reserved; do not use.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 29
        /// </term>
        /// <term>
        /// The context code.
        /// The value is 1 if the ALT key is held down while the key is pressed; otherwise, the value is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 30
        /// </term>
        /// <term>
        /// The previous key state.
        /// The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 31
        /// </term>
        /// <term>
        /// The transition state.
        /// The value is 1 if the key is being released, or it is 0 if the key is being pressed.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// For more detail, see Keystroke Message Flags.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="WM_UNICHAR"/> message is similar to <see cref="WM_CHAR"/>,
        /// but it uses Unicode Transformation Format (UTF)-32, whereas <see cref="WM_CHAR"/> uses UTF-16.
        /// </para>
        /// <para>
        /// This message is designed to send or post Unicode characters to ANSI windows and can handle Unicode Supplementary Plane characters.
        /// </para>
        /// <para>
        /// Because there is not necessarily a one-to-one correspondence between keys pressed and character messages generated,
        /// the information in the high-order word of the lParam parameter is generally not useful to applications.
        /// The information in the high-order word applies only to the most recent <see cref="WM_KEYDOWN"/> message
        /// that precedes the posting of the <see cref="WM_UNICHAR"/> message.
        /// </para>
        /// <para>
        /// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and the right CTRL keys on the main section of the keyboard;
        /// the INS, DEL, HOME, END, PAGE UP, PAGE DOWN and arrow keys in the clusters to the left of the numeric keypad;
        /// and the divide (/) and ENTER keys in the numeric keypad.
        /// Some other keyboards may support the extended-key bit in the lParam parameter.
        /// </para>
        /// </remarks>
        WM_UNICHAR = 0x0109,

        #endregion

        #region List Box Notifications

        /// <summary>
        /// <para>
        /// Sent by a list box with the <see cref="LBS_WANTKEYBOARDINPUT"/> style
        /// to its owner in response to a <see cref="WM_CHAR"/> message.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The <see cref="LOWORD"/> specifies the character code of the key the user pressed.
        /// The <see cref="HIWORD"/> specifies the current position of the caret.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Handle to the list box.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value specifies the action that the application performed in response to the message.
        /// A return value of -1 or -2 indicates that the application handled
        /// all aspects of selecting the item and requires no further action by the list box.
        /// A return value of 0 or greater specifies the zero-based index of an item in the list box
        /// and indicates that the list box should perform the default action for the keystroke on the specified item.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-chartoitem"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="DefWindowProc"/> function returns -1.
        /// </para>
        /// <para>
        /// Only owner-drawn list boxes that do not have the <see cref="LBS_HASSTRINGS"/> style can receive this message.
        /// </para>
        /// <para>
        /// If a dialog box procedure handles this message,
        /// it should cast the desired return value to a <see cref="BOOL"/> and return the value directly.
        /// The <see cref="DWL_MSGRESULT"/> value set by the <see cref="SetWindowLong"/> function is ignored.
        /// </para>
        /// </remarks>
        WM_CHARTOITEM = 0x002F,

        /// <summary>
        /// <para>
        /// Sent to the parent window of a list box before the system draws the list box.
        /// By responding to this message, the parent window can set the text and background colors
        /// of the list box by using the specified display device context handle.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Handle to the device context for the list box.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Handle to the list box.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it must return a handle to a brush.
        /// The system uses the brush to paint the background of the list box.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-ctlcolorlistbox"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function selects the default system colors for the list box.
        /// </para>
        /// <para>
        /// The <see cref="WM_CTLCOLORLISTBOX"/> message is never sent between threads.
        /// It is sent only within one thread.
        /// </para>
        /// <para>
        /// If a dialog box procedure handles this message,
        /// it should cast the desired return value to a <see cref="INT_PTR"/> and return the value directly.
        /// If the dialog box procedure returns <see cref="FALSE"/>, then default message handling is performed.
        /// The <see cref="DWL_MSGRESULT"/> value set by the <see cref="SetWindowLong"/> function is ignored.
        /// </para>
        /// </remarks>
        WM_CTLCOLORLISTBOX = 0x0134,

        /// <summary>
        /// <para>
        /// Sent to the owner of a list box or combo box when the list box or combo box is destroyed
        /// or when items are removed by the <see cref="LB_DELETESTRING"/>, <see cref="LB_RESETCONTENT"/>,
        /// <see cref="CB_DELETESTRING"/>, or <see cref="CB_RESETCONTENT"/> message.
        /// The system sends a <see cref="WM_DELETEITEM"/> message for each deleted item.
        /// The system sends the <see cref="WM_DELETEITEM"/> message for any deleted list box or combo box item with nonzero item data.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Specifies the identifier of the control that sent the <see cref="WM_DELETEITEM"/> message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Pointer to a <see cref="DELETEITEMSTRUCT"/> structure that contains information about the item deleted from a list box.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return <see cref="TRUE"/> if it processes this message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-deleteitem"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Microsoft Windows NT and later: Windows sends a <see cref="WM_DELETEITEM"/> message only for items deleted from an owner-drawn list box
        /// (with the <see cref="LBS_OWNERDRAWFIXED"/> or <see cref="LBS_OWNERDRAWVARIABLE"/> style)
        /// or owner-drawn combo box (with the <see cref="CBS_OWNERDRAWFIXED"/> or <see cref="CBS_OWNERDRAWVARIABLE"/> style).
        /// </para>
        /// <para>
        /// Windows 95: Windows sends the <see cref="WM_DELETEITEM"/> message for any deleted list box or combo box item with nonzero item data.
        /// </para>
        /// </remarks>
        WM_DELETEITEM = 0x002D,

        /// <summary>
        /// <para>
        /// Sent by a list box with the <see cref="LBS_WANTKEYBOARDINPUT"/> style to its owner in response to a <see cref="WM_KEYDOWN"/> message.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The <see cref="LOWORD"/> specifies the virtual-key code of the key the user pressed.
        /// The <see cref="HIWORD"/> specifies the current position of the caret.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Handle to the list box.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value specifies the action that the application performed in response to the message.
        /// A return value of -2 indicates that the application handled all aspects of selecting the item and requires no further action by the list box.
        /// (See Remarks.)
        /// A return value of -1 indicates that the list box should perform the default action in response to the keystroke.
        /// A return value of 0 or greater specifies the index of an item in the list box and indicates
        /// that the list box should perform the default action for the keystroke on the specified item.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-vkeytoitem"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A return value of -2 is valid only for keys that are not translated into characters by the list box control.
        /// If the <see cref="WM_KEYDOWN"/> message translates to a <see cref="WM_CHAR"/> message
        /// and the application processes the <see cref="WM_VKEYTOITEM"/> message generated as a result of the key press,
        /// the list box ignores the return value and does the default processing for that character).
        /// <see cref="WM_KEYDOWN"/> messages generated by keys such as <see cref="VK_UP"/>,
        /// <see cref="VK_DOWN"/>, <see cref="VK_NEXT"/>, and <see cref="VK_PREVIOUS"/> are not translated to <see cref="WM_CHAR"/> messages.
        /// In such cases, trapping the <see cref="WM_VKEYTOITEM"/> message and returning -2
        /// prevents the list box from doing the default processing for that key.
        /// </para>
        /// <para>
        /// To trap keys that generate a char message and do special processing,
        /// the application must subclass the list box, trap both the <see cref="WM_KEYDOWN"/> and <see cref="WM_CHAR"/> messages,
        /// and process the messages appropriately in the subclass procedure.
        /// </para>
        /// <para>
        /// The preceding remarks apply to regular list boxes that are created with the <see cref="LBS_WANTKEYBOARDINPUT"/> style.
        /// If the list box is owner-drawn, the application must process the <see cref="WM_CHARTOITEM"/> message.
        /// </para>
        /// <para>
        /// The <see cref="DefWindowProc"/> function returns -1.
        /// </para>
        /// <para>
        /// If a dialog box procedure handles this message,
        /// it should cast the desired return value to a <see cref="BOOL"/> and return the value directly.
        /// The <see cref="DWL_MSGRESULT"/> value set by the <see cref="SetWindowLong"/> function is ignored.
        /// </para>
        /// </remarks>
        WM_VKEYTOITEM = 0x002E,

        #endregion

        #region Menu Notifications

        /// <summary>
        /// <para>
        /// Sent when the user selects a command item from a menu,
        /// when a control sends a notification message to its parent window, or when an accelerator keystroke is translated.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// For a description of this parameter, see Remarks.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// For a description of this parameter, see Remarks.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use of the wParam and lParam parameters are summarized here.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Message Source
        /// </term>
        /// <term>
        /// wParam (high word)
        /// </term>
        /// <term>
        /// wParam (low word)
        /// </term>
        /// <term>
        /// lParam
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Menu
        /// </term>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// Menu identifier (IDM_*)
        /// </term>
        /// <term>
        /// 0
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Accelerator
        /// </term>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Accelerator identifier (IDM_*)
        /// </term>
        /// <term>
        /// 0
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Control
        /// </term>
        /// <term>
        /// Control-defined notification code
        /// </term>
        /// <term>
        /// Control identifier
        /// </term>
        /// <term>
        /// Handle to the control window
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Menus
        /// </para>
        /// <para>
        /// If an application enables a menu separator, the system sends a <see cref="WM_COMMAND"/> message
        /// with the low-word of the wParam parameter set to zero when the user selects the separator.
        /// </para>
        /// <para>
        /// If a menu is defined with a <see cref="MENUINFO.dwStyle"/> value of <see cref="MNS_NOTIFYBYPOS"/>,
        /// <see cref="WM_MENUCOMMAND"/> is sent instead of <see cref="WM_COMMAND"/>.
        /// </para>
        /// <para>
        /// Accelerators
        /// </para>
        /// <para>
        /// Accelerator keystrokes that select items from the window menu are translated into <see cref="WM_SYSCOMMAND"/> messages.
        /// </para>
        /// <para>
        /// If an accelerator keystroke occurs that corresponds to a menu item
        /// when the window that owns the menu is minimized, no <see cref="WM_COMMAND"/> message is sent.
        /// However, if an accelerator keystroke occurs that does not match any of the items
        /// in the window's menu or in the window menu, a <see cref="WM_COMMAND"/> message is sent, even if the window is minimized.
        /// </para>
        /// </remarks>
        WM_COMMAND = 0x0111,

        /// <summary>
        /// <para>
        /// Notifies a window that the user desires a context menu to appear.
        /// The user may have clicked the right mouse button (right-clicked) in the window,
        /// pressed Shift+F10 or pressed the applications key (context menu key) available on some keyboards.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the window in which the user right-clicked the mouse.
        /// This can be a child window of the window receiving the message.
        /// For more information about processing this message, see the Remarks section.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the horizontal position of the cursor,
        /// in screen coordinates, at the time of the mouse click.
        /// </para>
        /// <para>
        /// The high-order word specifies the vertical position of the cursor,
        /// in screen coordinates, at the time of the mouse click.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// No return value.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A window can process this message by displaying a shortcut menu
        /// using the <see cref="TrackPopupMenu"/> or <see cref="TrackPopupMenuEx"/> functions.
        /// To obtain the horizontal and vertical positions, use the following code.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// If a window does not display a shortcut menu it should pass this message to the <see cref="DefWindowProc"/> function.
        /// If a window is a child window, <see cref="DefWindowProc"/> sends the message to the parent.
        /// Otherwise, <see cref="DefWindowProc"/> displays a default shortcut menu if the specified position is in the window's caption.
        /// </para>
        /// <para>
        /// <see cref="DefWindowProc"/> generates the <see cref="WM_CONTEXTMENU"/> message
        /// when it processes the <see cref="WM_RBUTTONUP"/> or <see cref="WM_NCRBUTTONUP"/> message or when the user types SHIFT+F10.
        /// The <see cref="WM_CONTEXTMENU"/> message is also generated when the user presses and releases the <see cref="VK_APPS"/> key.
        /// </para>
        /// <para>
        /// If the context menu is generated from the keyboard for example,
        /// if the user types SHIFT+F10 then the x- and y-coordinates are -1 and the application
        /// should display the context menu at the location of the current selection rather than at (xPos, yPos).
        /// </para>
        /// </remarks>
        WM_CONTEXTMENU = 0x007B,

        /// <summary>
        /// <para>
        /// Notifies an application's main window procedure that a menu modal loop has been entered.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Specifies whether the window menu was entered using the <see cref="TrackPopupMenu"/> function.
        /// This parameter has a value of <see cref="TRUE"/> if the window menu was entered
        /// using <see cref="TrackPopupMenu"/>, and <see cref="FALSE"/> if it was not.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The <see cref="DefWindowProc"/> function returns zero.
        /// </remarks>
        WM_ENTERMENULOOP = 0x0211,

        /// <summary>
        /// <para>
        /// Notifies an application's main window procedure that a menu modal loop has been exited.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Specifies whether the menu is a shortcut menu.
        /// This parameter has a value of <see cref="TRUE"/> if it is a shortcut menu, <see cref="FALSE"/> if it is not.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The <see cref="DefWindowProc"/> function returns zero.
        /// </remarks>
        WM_EXITMENULOOP = 0x0212,

        /// <summary>
        /// <para>
        /// Sent to request extended title bar information.
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be 0.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="TITLEBARINFOEX"/> structure.
        /// The message sender is responsible for allocating memory for this structure.
        /// Set the <see cref="TITLEBARINFOEX.cbSize"/> member of this structure to <c>TITLEBARINFOEX</c>
        /// before passing this structure with the message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The following example shows how the message receiver casts an <see cref="LPARAM"/> value
        /// to retrieve the <see cref="TITLEBARINFOEX"/> structure.
        /// </para>
        /// <para>
        /// <c>TITLEBARINFOEX *ptinfo = (TITLEBARINFOEX *)lParam;</c>
        /// </para>
        /// </remarks>
        WM_GETTITLEBARINFOEX = 0x033F,

        /// <summary>
        /// <para>
        /// Sent when the user makes a selection from a menu.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The zero-based index of the item selected.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the menu for the item selected.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="WM_MENUCOMMAND"/> message gives you a handle to the menu
        /// so you can access the menu data in the <see cref="MENUINFO"/> structure
        /// and also gives you the index of the selected item, which is typically what applications need.
        /// In contrast, the <see cref="WM_COMMAND"/> message gives you the menu item identifier.
        /// </para>
        /// <para>
        /// The <see cref="WM_MENUCOMMAND"/> message is sent only for menus
        /// that are defined with the <see cref="MNS_NOTIFYBYPOS"/> flag set
        /// in the <see cref="MENUINFO.dwStyle"/> member of the <see cref="MENUINFO"/> structure.
        /// </para>
        /// </remarks>
        WM_MENUCOMMAND = 0x0126,

        /// <summary>
        /// <para>
        /// Sent to the owner of a drag-and-drop menu when the user drags a menu item.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The position of the item where the drag operation began.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the menu containing the item.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The application should return one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MND_CONTINUE"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Menu should remain active.
        /// If the mouse is released, it should be ignored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MND_ENDMENU"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Menu should be ended.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The application can call the <see cref="DoDragDrop"/> function in response to this message.
        /// </para>
        /// <para>
        /// To create a drag-and-drop menu, call <see cref="SetMenuInfo"/> with <see cref="MNS_DRAGDROP"/>.
        /// </para>
        /// </remarks>
        WM_MENUDRAG = 0x0123,

        /// <summary>
        /// <para>
        /// Sent to the owner of a drag-and-drop menu when the mouse cursor enters a menu item
        /// or moves from the center of the item to the top or bottom of the item.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="MENUGETOBJECTINFO"/> structure.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The application should return one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MNGO_NOERROR"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// An interface pointer was returned in the <see cref="MENUGETOBJECTINFO.pvObj"/> member of <see cref="MENUGETOBJECTINFO"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MNGO_NOINTERFACE"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// The interface is not supported.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        WM_MENUGETOBJECT = 0x0124,

        /// <summary>
        /// <para>
        /// Sent when the user releases the right mouse button while the cursor is on a menu item.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The zero-based index of the menu item on which the right mouse button was released.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the menu containing the item.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The <see cref="WM_MENURBUTTONUP"/> message allows applications to provide a context-sensitive menu
        /// also known as a shortcut menu for the menu item specified in this message.
        /// To display a context-sensitive menu for a menu item,
        /// call the <see cref="TrackPopupMenuEx"/> function with <see cref="TPM_RECURSE"/>.
        /// </remarks>
        WM_MENURBUTTONUP = 0x0122,

        /// <summary>
        /// <para>
        /// Sent to an application when the right or left arrow key is used to switch between the menu bar and the system menu.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The virtual-key code of the key. See Virtual-Key Codes.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="MDINEXTMENU"/> structure that contains information about the menu to be activated.
        /// </para>
        /// </summary>
        /// <remarks>
        /// In responding to this message, the application can specify the menu
        /// to switch to in the <see cref="MDINEXTMENU.hmenuNext"/> member of <see cref="MDINEXTMENU"/>
        /// and the window to receive the menu notification messages
        /// in the <see cref="MDINEXTMENU.hwndNext"/> member of the <see cref="MDINEXTMENU"/> structure.
        /// You must set both members for the changes to take effect (they are initially <see cref="NULL"/>).
        /// </remarks>
        WM_NEXTMENU = 0x0213,

        /// <summary>
        /// <para>
        /// Sent when a drop-down menu or submenu has been destroyed.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the menu
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The high-order word identifies the menu that was destroyed.
        /// Currently, this parameter can only be <see cref="MF_SYSMENU"/> (the window menu).
        /// </para>
        /// </summary>
        /// <remarks>
        /// If an application receives a <see cref="WM_INITMENUPOPUP"/> message, it will receive a <see cref="WM_UNINITMENUPOPUP"/> message.
        /// </remarks>
        WM_UNINITMENUPOPUP = 0x0125,

        #endregion

        #region Mouse Input Notifications

        /// <summary>
        /// <para>
        /// Sent to the window that is losing the mouse capture.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the window gaining the mouse capture.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A window receives this message even if it calls <see cref="ReleaseCapture"/> itself.
        /// An application should not attempt to set the mouse capture in response to this message.
        /// </para>
        /// <para>
        /// When it receives this message, a window should redraw itself,
        /// if necessary, to reflect the new mouse-capture state.
        /// </para>
        /// </remarks>
        WM_CAPTURECHANGED = 0x0215,

        /// <summary>
        /// <para>
        /// Posted when the user double-clicks the left mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether various virtual keys are down.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short (both represent signed values
        /// because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates
        /// , and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// Only windows that have the <see cref="CS_DBLCLKS"/> style can receive <see cref="WM_LBUTTONDBLCLK"/> messages,
        /// which the system generates whenever the user presses, releases,
        /// and again presses the left mouse button within the system's double-click time limit.
        /// Double-clicking the left mouse button actually generates a sequence of four messages:
        /// <see cref="WM_LBUTTONDOWN"/>, <see cref="WM_LBUTTONUP"/>, <see cref="WM_LBUTTONDBLCLK"/>, and <see cref="WM_LBUTTONUP"/>.
        /// </para>
        /// </remarks>
        WM_LBUTTONDBLCLK = 0x0213,

        /// <summary>
        /// <para>
        /// Posted when the user presses the left mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether various virtual keys are down.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// To detect that the ALT key was pressed, check whether <see cref="GetKeyState"/> with <see cref="VK_MENU"/> &lt; 0.
        /// Note, this must not be <see cref="GetAsyncKeyState"/>.
        /// </para>
        /// </remarks>
        WM_LBUTTONDOWN = 0x0201,

        /// <summary>
        /// <para>
        /// Posted when the user releases the left mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether various virtual keys are down.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the lParam value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        ///  Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// </remarks>
        WM_LBUTTONUP = 0x0202,

        /// <summary>
        /// <para>
        /// Posted when the user double-clicks the middle mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether various virtual keys are down.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// Only windows that have the <see cref="CS_DBLCLKS"/> style can receive <see cref="WM_MBUTTONDBLCLK"/> messages,
        /// which the system generates when the user presses, releases,
        /// and again presses the middle mouse button within the system's double-click time limit.
        /// Double-clicking the middle mouse button actually generates four messages:
        /// <see cref="WM_MBUTTONDOWN"/>, <see cref="WM_MBUTTONUP"/>, <see cref="WM_MBUTTONDBLCLK"/>, and <see cref="WM_MBUTTONUP"/> again.
        /// </para>
        /// </remarks>
        WM_MBUTTONDBLCLK = 0x0209,

        /// <summary>
        /// <para>
        /// Posted when the user presses the middle mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether various virtual keys are down.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// To detect that the ALT key was pressed, check whether <see cref="GetKeyState"/> with <see cref="VK_MENU"/> &lt; 0.
        /// Note, this must not be <see cref="GetAsyncKeyState"/>.
        /// </para>
        WM_MBUTTONDOWN = 0x0207,

        /// <summary>
        /// <para>
        /// Posted when the user releases the middle mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether various virtual keys are down.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Note that when a shortcut menu is present (displayed), coordinates are relative to the screen, not the client area.
        /// Because <see cref="TrackPopupMenu"/> is an asynchronous call
        /// and the <see cref="WM_MBUTTONUP"/> notification does not have a special flag indicating coordinate derivation,
        /// an application cannot tell if the x,y coordinates contained in lParam are relative to the screen or the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// </remarks>
        WM_MBUTTONUP = 0x0208,

        /// <summary>
        /// <para>
        /// Sent when the cursor is in an inactive window and the user presses a mouse button.
        /// The parent window receives this message only if the child window passes it to the <see cref="DefWindowProc"/> function.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the top-level parent window of the window being activated.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the hit-test value returned by the <see cref="DefWindowProc"/> function
        /// as a result of processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// The high-order word specifies the identifier of the mouse message generated when the user pressed a mouse button.
        /// The mouse message is either discarded or posted to the window, depending on the return value.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value specifies whether the window should be activated
        /// and whether the identifier of the mouse message should be discarded.
        /// It must be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MA_ACTIVATE"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Activates the window, and does not discard the mouse message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MA_ACTIVATEANDEAT"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Activates the window, and discards the mouse message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MA_NOACTIVATE"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// Does not activate the window, and does not discard the mouse message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MA_NOACTIVATEANDEAT"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// Does not activate the window, but discards the mouse message.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// The <see cref="DefWindowProc"/> function passes the message to a child window's parent window before any processing occurs.
        /// The parent window determines whether to activate the child window.
        /// If it activates the child window, the parent window should return <see cref="MA_NOACTIVATE"/>
        /// or <see cref="MA_NOACTIVATEANDEAT"/> to prevent the system from processing the message further.
        /// </remarks>
        WM_MOUSEACTIVATE = 0x0021,

        /// <summary>
        /// <para>
        /// Posted to a window when the cursor hovers over the client area of the window
        /// for the period of time specified in a prior call to <see cref="TrackMouseEvent"/>.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether various virtual keys are down. 
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is depressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is depressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is depressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is depressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is depressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Hover tracking stops when <see cref="WM_MOUSEHOVER"/> is generated.
        /// The application must call <see cref="TrackMouseEvent"/> again if it requires further tracking of mouse hover behavior.
        /// </para>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        ///  Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// </remarks>
        WM_MOUSEHOVER = 0x02A1,

        /// <summary>
        /// <para>
        /// Sent to the active window when the mouse's horizontal scroll wheel is tilted or rotated.
        /// The <see cref="DefWindowProc"/> function propagates the message to the window's parent.
        /// There should be no internal forwarding of the message,
        /// since <see cref="DefWindowProc"/> propagates it up the parent chain until it finds a window that processes it.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The high-order word indicates the distance the wheel is rotated,
        /// expressed in multiples or factors of <see cref="WHEEL_DELTA"/>, which is set to 120.
        /// A positive value indicates that the wheel was rotated to the right;
        /// a negative value indicates that the wheel was rotated to the left.
        /// </para>
        /// <para>
        /// The low-order word indicates whether various virtual keys are down.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the pointer,
        /// relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the pointer,
        /// relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use the following code to obtain the information in the wParam parameter.
        /// </para>
        /// <code>
        /// fwKeys = GET_KEYSTATE_WPARAM(wParam);
        /// zDelta = GET_WHEEL_DELTA_WPARAM(wParam);
        /// </code>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// The wheel rotation is a multiple of <see cref="WHEEL_DELTA"/>, which is set to 120.
        /// This is the threshold for action to be taken, and one such action (for example, scrolling one increment) should occur for each delta.
        /// </para>
        /// <para>
        /// The delta was set to 120 to allow Microsoft or other vendors to build finer-resolution wheels
        /// (for example, a freely-rotating wheel with no notches) to send more messages per rotation, but with a smaller value in each message.
        /// To use this feature, you can either add the incoming delta values
        /// until <see cref="WHEEL_DELTA"/> is reached (so for a delta-rotation you get the same response),
        /// or scroll partial lines in response to more frequent messages.
        /// You can also choose your scroll granularity and accumulate deltas until it is reached.
        /// </para>
        /// </remarks>
        WM_MOUSEHWHEEL = 0x020E,

        /// <summary>
        /// <para>
        /// Posted to a window when the cursor leaves the client area of the window specified in a prior call to <see cref="TrackMouseEvent"/>.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// All tracking requested by <see cref="TrackMouseEvent"/> is canceled when this message is generated.
        /// The application must call <see cref="TrackMouseEvent"/> when the mouse reenters its window
        /// if it requires further tracking of mouse hover behavior.
        /// </remarks>
        WM_MOUSELEAVE = 0x02A3,

        /// <summary>
        /// <para>
        /// Posted to a window when the cursor moves.
        /// If the mouse is not captured, the message is posted to the window that contains the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether various virtual keys are down.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        ///  Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// </remarks>
        WM_MOUSEMOVE = 0x0200,

        /// <summary>
        /// <para>
        /// Sent to the focus window when the mouse wheel is rotated.
        /// The <see cref="DefWindowProc"/> function propagates the message to the window's parent.
        /// There should be no internal forwarding of the message,
        /// since <see cref="DefWindowProc"/> propagates it up the parent chain until it finds a window that processes it.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The high-order word indicates the distance the wheel is rotated,
        /// expressed in multiples or divisions of <see cref="WHEEL_DELTA"/>, which is 120.
        /// A positive value indicates that the wheel was rotated forward, away from the user;
        /// a negative value indicates that the wheel was rotated backward, toward the user.
        /// </para>
        /// <para>
        /// The low-order word indicates whether various virtual keys are down.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the pointer,
        /// relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the pointer,
        /// relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <para>
        /// Use the following code to get the information in the wParam parameter:
        /// </para>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        ///  Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// The wheel rotation will be a multiple of <see cref="WHEEL_DELTA"/>, which is set at 120.
        /// This is the threshold for action to be taken, and one such action (for example, scrolling one increment) should occur for each delta.
        /// </para>
        /// <para>
        /// The delta was set to 120 to allow Microsoft or other vendors to build finer-resolution wheels
        /// (a freely-rotating wheel with no notches) to send more messages per rotation, but with a smaller value in each message.
        /// To use this feature, you can either add the incoming delta values
        /// until <see cref="WHEEL_DELTA"/> is reached (so for a delta-rotation you get the same response),
        /// or scroll partial lines in response to the more frequent messages.
        /// You can also choose your scroll granularity and accumulate deltas until it is reached.
        /// </para>
        /// <para>
        /// Note, there is no fwKeys for <see cref="MSH_MOUSEWHEEL"/>.
        /// Otherwise, the parameters are exactly the same as for <see cref="WM_MOUSEWHEEL"/>.
        /// </para>
        /// <para>
        /// It is up to the application to forward <see cref="MSH_MOUSEWHEEL"/> to any embedded objects or controls.
        /// The application is required to send the message to an active embedded OLE application.
        /// It is optional that the application sends it to a wheel-enabled control with focus.
        /// If the application does send the message to a control, it can check the return value to see if the message was processed.
        /// Controls are required to return a value of <see cref="TRUE"/> if they process the message.
        /// </para>
        WM_MOUSEWHEEL = 0x020A,

        /// <summary>
        /// <para>
        /// Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate.
        /// This can happen, for example, when the cursor moves, when a mouse button is pressed or released,
        /// or in response to a call to a function such as <see cref="WindowFromPoint"/>.
        /// If the mouse is not captured, the message is sent to the window beneath the cursor.
        /// Otherwise, the message is sent to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor
        /// . The coordinate is relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value of the <see cref="DefWindowProc"/> function is one of the following values,
        /// indicating the position of the cursor hot spot.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTBORDER"/>
        /// </para>
        /// <para>
        /// 18
        /// </para>
        /// </term>
        /// <term>
        /// In the border of a window that does not have a sizing border.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTBOTTOM"/>
        /// </para>
        /// <para>
        /// 15
        /// </para>
        /// </term>
        /// <term>
        /// In the lower-horizontal border of a resizable window (the user can click the mouse to resize the window vertically).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTBOTTOMLEFT"/>
        /// </para>
        /// <para>
        /// 16
        /// </para>
        /// </term>
        /// <term>
        /// In the lower-left corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTBOTTOMRIGHT"/>
        /// </para>
        /// <para>
        /// 17
        /// </para>
        /// </term>
        /// <term>
        /// In the lower-right corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTCAPTION"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// In a title bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTCLIENT"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// In a client area.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTCLOSE"/>
        /// </para>
        /// <para>
        /// 20
        /// </para>
        /// </term>
        /// <term>
        /// In a <see cref="Close"/> button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTERROR"/>
        /// </para>
        /// <para>
        /// -2
        /// </para>
        /// </term>
        /// <term>
        /// On the screen background or on a dividing line between windows
        /// (same as <see cref="HTNOWHERE"/>, except that the <see cref="DefWindowProc"/> function produces a system beep to indicate an error).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTGROWBOX"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// In a size box (same as <see cref="HTSIZE"/>).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTHELP"/>
        /// </para>
        /// <para>
        /// 21
        /// </para>
        /// </term>
        /// <term>
        /// In a <see cref="Help"/> button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTHSCROLL"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// In a horizontal scroll bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTLEFT"/>
        /// </para>
        /// <para>
        /// 10
        /// </para>
        /// </term>
        /// <term>
        /// In the left border of a resizable window (the user can click the mouse to resize the window horizontally).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTMENU"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// In a menu.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTMAXBUTTON"/>
        /// </para>
        /// <para>
        /// 9
        /// </para>
        /// </term>
        /// <term>
        /// In a Maximize button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTMINBUTTON"/>
        /// </para>
        /// <para>
        /// 8
        /// </para>
        /// </term>
        /// <term>
        /// In a Minimize button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTNOWHERE"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// On the screen background or on a dividing line between windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTREDUCE"/>
        /// </para>
        /// <para>
        /// 8
        /// </para>
        /// </term>
        /// <term>
        /// In a <see cref="Minimize"/> button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTRIGHT"/>
        /// </para>
        /// <para>
        /// 11
        /// </para>
        /// </term>
        /// <term>
        /// In the right border of a resizable window (the user can click the mouse to resize the window horizontally).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTSIZE"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// In a size box (same as <see cref="HTGROWBOX"/>).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTSYSMENU"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// In a window menu or in a Close button in a child window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTTOP"/>
        /// </para>
        /// <para>
        /// 12
        /// </para>
        /// </term>
        /// <term>
        /// In the upper-horizontal border of a window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTTOPLEFT"/>
        /// </para>
        /// <para>
        /// 13
        /// </para>
        /// </term>
        /// <term>
        /// In the upper-left corner of a window border.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTTOPRIGHT"/>
        /// </para>
        /// <para>
        /// 14
        /// </para>
        /// </term>
        /// <term>
        /// In the upper-right corner of a window border.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTTRANSPARENT"/>
        /// </para>
        /// <para>
        /// -1
        /// </para>
        /// </term>
        /// <term>
        /// In a window currently covered by another window in the same thread
        /// (the message will be sent to underlying windows in the same thread
        /// until one of them returns a code that is not <see cref="HTTRANSPARENT"/>).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTVSCROLL"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// In the vertical scroll bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HTZOOM"/>
        /// </para>
        /// <para>
        /// 9
        /// </para>
        /// </term>
        /// <term>
        /// In a Maximize button.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// Windows Vista: When creating custom frames that include the standard caption buttons,
        /// this message should first be passed to the <see cref="DwmDefWindowProc"/> function.
        /// This enables the Desktop Window Manager (DWM) to provide hit-testing for the captions buttons.
        /// If <see cref="DwmDefWindowProc"/> does not handle the message, further processing of <see cref="WM_NCHITTEST"/> may be needed.
        /// </para>
        /// </remarks>
        WM_NCHITTEST = 0x0084,

        /// <summary>
        /// <para>
        /// Posted when the user double-clicks the left mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The hit-test value returned by the <see cref="DefWindowProc"/> function
        /// as a result of processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// You can also use the <see cref="GET_X_LPARAM"/> and <see cref="GET_Y_LPARAM"/> macros
        /// to extract the values of the x- and y- coordinates from lParam.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function tests the specified point
        /// to find out the location of the cursor and performs the appropriate action.
        /// If appropriate, <see cref="DefWindowProc"/> sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// <para>
        /// A window need not have the <see cref="CS_DBLCLKS"/> style to receive <see cref="WM_NCLBUTTONDBLCLK"/> messages.
        /// </para>
        /// <para>
        /// The system generates a <see cref="WM_NCLBUTTONDBLCLK"/> message when the user presses, releases,
        /// and again presses the left mouse button within the system's double-click time limit.
        /// Double-clicking the left mouse button actually generates four messages:
        /// <see cref="WM_NCLBUTTONDOWN"/>, <see cref="WM_NCLBUTTONUP"/>, <see cref="WM_NCLBUTTONDBLCLK"/>, and <see cref="WM_NCLBUTTONUP"/> again.
        /// </para>
        /// </remarks>
        WM_NCLBUTTONDBLCLK = 0x00A3,

        /// <summary>
        /// <para>
        /// Posted when the user presses the left mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The hit-test value returned by the <see cref="DefWindowProc"/> function
        /// as a result of processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="DefWindowProc"/> function tests the specified point
        /// to find the location of the cursor and performs the appropriate action.
        /// If appropriate, <see cref="DefWindowProc"/> sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// <para>
        /// You can also use the <see cref="GET_X_LPARAM"/> and <see cref="GET_Y_LPARAM"/> macros
        /// to extract the values of the x- and y- coordinates from lParam.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// </remarks>
        WM_NCLBUTTONDOWN = 0x00A1,

        /// <summary>
        /// <para>
        /// Posted when the user releases the left mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The hit-test value returned by the <see cref="DefWindowProc"/> function
        /// as a result of processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="DefWindowProc"/> function tests the specified point
        /// to find the location of the cursor and performs the appropriate action.
        /// If appropriate, <see cref="DefWindowProc"/> sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// <para>
        /// You can also use the <see cref="GET_X_LPARAM"/> and <see cref="GET_Y_LPARAM"/> macros
        /// to extract the values of the x- and y- coordinates from lParam.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// If it is appropriate to do so, the system sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// </remarks>
        WM_NCLBUTTONUP = 0x00A2,

        /// <summary>
        /// <para>
        /// Posted when the user double-clicks the middle mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The hit-test value returned by the <see cref="DefWindowProc"/> function
        /// as a result of processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A window need not have the <see cref="CS_DBLCLKS"/> style to receive <see cref="WM_NCMBUTTONDBLCLK"/> messages.
        /// </para>
        /// <para>
        /// The system generates a <see cref="WM_NCMBUTTONDBLCLK"/> message when the user presses, releases,
        /// and again presses the middle mouse button within the system's double-click time limit.
        /// Double-clicking the middle mouse button actually generates four messages:
        /// <see cref="WM_NCMBUTTONDOWN"/>, <see cref="WM_NCMBUTTONUP"/>, <see cref="WM_NCMBUTTONDBLCLK"/>, and <see cref="WM_NCMBUTTONUP"/> again.
        /// </para>
        /// <para>
        /// You can also use the <see cref="GET_X_LPARAM"/> and <see cref="GET_Y_LPARAM"/> macros
        /// to extract the values of the x- and y- coordinates from lParam.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// If it is appropriate to do so, the system sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// </remarks>
        WM_NCMBUTTONDBLCLK = 0x00A9,

        /// <summary>
        /// <para>
        /// Posted when the user presses the middle mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The hit-test value returned by the <see cref="DefWindowProc"/> function
        /// as a result of processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// You can also use the <see cref="GET_X_LPARAM"/> and <see cref="GET_Y_LPARAM"/> macros
        /// to extract the values of the x- and y- coordinates from lParam.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// If it is appropriate to do so, the system sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// </remarks>
        WM_NCMBUTTONDOWN = 0x00A7,

        /// <summary>
        /// <para>
        /// Posted when the user releases the middle mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The hit-test value returned by the <see cref="DefWindowProc"/> function
        /// as a result of processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// You can also use the <see cref="GET_X_LPARAM"/> and <see cref="GET_Y_LPARAM"/> macros
        /// to extract the values of the x- and y- coordinates from lParam.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// If it is appropriate to do so, the system sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// </remarks>
        WM_NCMBUTTONUP = 0x00A8,

        /// <summary>
        /// <para>
        /// Posted to a window when the cursor hovers over the nonclient area of the window
        /// for the period of time specified in a prior call to <see cref="TrackMouseEvent"/>.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The hit-test value returned by the <see cref="DefWindowProc"/> function
        /// as a result of processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Hover tracking stops when this message is generated.
        /// The application must call <see cref="TrackMouseEvent"/> again if it requires further tracking of mouse hover behavior.
        /// </para>
        /// <para>
        /// You can also use the <see cref="GET_X_LPARAM"/> and <see cref="GET_Y_LPARAM"/> macros
        /// to extract the values of the x- and y- coordinates from lParam.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// </remarks>
        WM_NCMOUSEHOVER = 0x02A0,

        /// <summary>
        /// <para>
        /// Posted to a window when the cursor leaves the nonclient area of the window specified in a prior call to <see cref="TrackMouseEvent"/>.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// All tracking requested by <see cref="TrackMouseEvent"/> is canceled when this message is generated.
        /// The application must call <see cref="TrackMouseEvent"/> when the mouse reenters its window
        /// if it requires further tracking of mouse hover behavior.
        /// </remarks>
        WM_NCMOUSELEAVE = 0x02A2,

        /// <summary>
        /// <para>
        /// Posted to a window when the cursor is moved within the nonclient area of the window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The hit-test value returned by the <see cref="DefWindowProc"/> function
        /// as a result of processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If it is appropriate to do so, the system sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// <para>
        /// You can also use the <see cref="GET_X_LPARAM"/> and <see cref="GET_Y_LPARAM"/> macros
        /// to extract the values of the x- and y- coordinates from lParam.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// </remarks>
        WM_NCMOUSEMOVE = 0x00A0,

        /// <summary>
        /// <para>
        /// Posted when the user double-clicks the right mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The hit-test value returned by the <see cref="DefWindowProc"/> function
        /// as a result of processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A window need not have the <see cref="CS_DBLCLKS"/> style to receive <see cref="WM_NCRBUTTONDBLCLK"/> messages.
        /// </para>
        /// <para>
        /// The system generates a <see cref="WM_NCRBUTTONDBLCLK"/> message when the user presses, releases,
        /// and again presses the right mouse button within the system's double-click time limit.
        /// Double-clicking the right mouse button actually generates four messages:
        /// <see cref="WM_NCRBUTTONDOWN"/>, <see cref="WM_NCRBUTTONUP"/>, <see cref="WM_NCRBUTTONDBLCLK"/>, and <see cref="WM_NCRBUTTONUP"/> again.
        /// </para>
        /// <para>
        /// You can also use the <see cref="GET_X_LPARAM"/> and <see cref="GET_Y_LPARAM"/> macros
        /// to extract the values of the x- and y- coordinates from lParam.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// If it is appropriate to do so, the system sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// </remarks>
        WM_NCRBUTTONDBLCLK = 0x00A6,

        /// <summary>
        /// <para>
        /// Posted when the user presses the right mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The hit-test value returned by the <see cref="DefWindowProc"/> function
        /// as a result of processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// You can also use the <see cref="GET_X_LPARAM"/> and <see cref="GET_Y_LPARAM"/> macros
        /// to extract the values of the x- and y- coordinates from lParam.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// If it is appropriate to do so, the system sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// </remarks>
        WM_NCRBUTTONDOWN = 0x00A4,

        /// <summary>
        /// <para>
        /// Posted when the user releases the right mouse button while the cursor is within the nonclient area of a window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The hit-test value returned by the <see cref="DefWindowProc"/> function
        /// as a result of processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// You can also use the <see cref="GET_X_LPARAM"/> and <see cref="GET_Y_LPARAM"/> macros
        /// to extract the values of the x- and y- coordinates from lParam.
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// If it is appropriate to do so, the system sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// </remarks>
        WM_NCRBUTTONUP = 0x00A5,

        /// <summary>
        /// <para>
        /// Posted when the user double-clicks either XBUTTON1 or XBUTTON2 while the cursor is in the nonclient area of a window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word specifies the hit-test value returned by the <see cref="DefWindowProc"/> function
        /// from processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// The high-order word indicates which button was double-clicked.
        /// It can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 was double-clicked..
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The second XBUTTON2 was double-clicked.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return <see cref="TRUE"/>.
        /// For more information about processing the return value, see the Remarks section.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Windows supports mice with up to five buttons: left, middle, and right, plus two additional buttons called XBUTTON1 and XBUTTON2.
        /// The XBUTTON1 and XBUTTON2 buttons are often located on the sides of the mouse, near the base.
        /// These extra buttons are not present on all mice.
        /// If present, the XBUTTON1 and XBUTTON2 buttons are often mapped to an application function,
        /// such as forward and backward navigation in a Web browser.
        /// </para>
        /// <para>
        /// Use the following code to get the information in the wParam parameter.
        /// </para>
        /// <code>
        /// nHittest = GET_NCHITTEST_WPARAM(wParam); 
        /// fwButton = GET_XBUTTON_WPARAM(wParam);
        /// </code>
        /// <para>
        /// You can also use the following code to get the x- and y-coordinates from lParam:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function tests the specified point
        /// to get the position of the cursor and performs the appropriate action.
        /// If appropriate, it sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// <para>
        /// A window need not have the <see cref="CS_DBLCLKS"/> style to receive <see cref="WM_NCXBUTTONDBLCLK"/> messages.
        /// The system generates a <see cref="WM_NCXBUTTONDBLCLK"/> message when the user presses, releases,
        /// and again presses an XBUTTON within the system's double-click time limit.
        /// Double-clicking one of these buttons actually generates four messages:
        /// <see cref="WM_NCXBUTTONDOWN"/>, <see cref="WM_NCXBUTTONUP"/>, <see cref="WM_NCXBUTTONDBLCLK"/>, and <see cref="WM_NCXBUTTONUP"/> again.
        /// </para>
        /// <para>
        /// Unlike the <see cref="WM_NCLBUTTONDBLCLK"/>, <see cref="WM_NCMBUTTONDBLCLK"/>, and <see cref="WM_NCRBUTTONDBLCLK"/> messages,
        /// an application should return <see cref="TRUE"/> from this message if it processes it.
        /// Doing so will allow software that simulates this message on Windows systems earlier than Windows 2000
        /// to determine whether the window procedure processed the message or called <see cref="DefWindowProc"/> to process it.
        /// </para>
        /// </remarks>
        WM_NCXBUTTONDBLCLK = 0x00A0,

        /// <summary>
        /// <para>
        /// Posted when the user presses either XBUTTON1 or XBUTTON2 while the cursor is in the nonclient area of a window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word specifies the hit-test value returned by the <see cref="DefWindowProc"/> function
        /// from processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// The high-order word indicates which button was pressed. It can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 was double-clicked..
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The second XBUTTON2 was double-clicked.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return <see cref="TRUE"/>.
        /// For more information about processing the return value, see the Remarks section.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Windows supports mice with up to five buttons: left, middle, and right, plus two additional buttons called XBUTTON1 and XBUTTON2.
        /// The XBUTTON1 and XBUTTON2 buttons are often located on the sides of the mouse, near the base.
        /// These extra buttons are not present on all mice.
        /// If present, the XBUTTON1 and XBUTTON2 buttons are often mapped to an application function,
        /// such as forward and backward navigation in a Web browser.
        /// </para>
        /// <para>
        /// Use the following code to get the information in the wParam parameter.
        /// </para>
        /// <code>
        /// nHittest = GET_NCHITTEST_WPARAM(wParam); 
        /// fwButton = GET_XBUTTON_WPARAM(wParam);
        /// </code>
        /// <para>
        /// You can also use the following code to get the x- and y-coordinates from lParam:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function tests the specified point
        /// to get the position of the cursor and performs the appropriate action.
        /// If appropriate, it sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// <para>
        /// Unlike the <see cref="WM_NCLBUTTONDBLCLK"/>, <see cref="WM_NCMBUTTONDBLCLK"/>, and <see cref="WM_NCRBUTTONDBLCLK"/> messages,
        /// an application should return <see cref="TRUE"/> from this message if it processes it.
        /// Doing so will allow software that simulates this message on Windows systems earlier than Windows 2000
        /// to determine whether the window procedure processed the message or called <see cref="DefWindowProc"/> to process it.
        /// </para>
        /// </remarks>
        WM_NCXBUTTONDOWN = 0x00AB,

        /// <summary>
        /// <para>
        /// Posted when the user releases either XBUTTON1 or XBUTTON2 while the cursor is in the nonclient area of a window.
        /// This message is posted to the window that contains the cursor.
        /// If a window has captured the mouse, this message is not posted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word specifies the hit-test value returned by the <see cref="DefWindowProc"/> function
        /// from processing the <see cref="WM_NCHITTEST"/> message.
        /// For a list of hit-test values, see <see cref="WM_NCHITTEST"/>.
        /// </para>
        /// <para>
        /// The high-order word indicates which button was released.
        /// It can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 was released.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 was released.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="POINTS"/> structure that contains the x- and y-coordinates of the cursor.
        /// The coordinates are relative to the upper-left corner of the screen.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return <see cref="TRUE"/>.
        /// For more information about processing the return value, see the Remarks section.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Windows supports mice with up to five buttons: left, middle, and right, plus two additional buttons called XBUTTON1 and XBUTTON2.
        /// The XBUTTON1 and XBUTTON2 buttons are often located on the sides of the mouse, near the base.
        /// These extra buttons are not present on all mice.
        /// If present, the XBUTTON1 and XBUTTON2 buttons are often mapped to an application function,
        /// such as forward and backward navigation in a Web browser.
        /// </para>
        /// <para>
        /// Use the following code to get the information in the wParam parameter.
        /// </para>
        /// <code>
        /// nHittest = GET_NCHITTEST_WPARAM(wParam); 
        /// fwButton = GET_XBUTTON_WPARAM(wParam);
        /// </code>
        /// <para>
        /// You can also use the following code to get the x- and y-coordinates from lParam:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function tests the specified point
        /// to get the position of the cursor and performs the appropriate action.
        /// If appropriate, it sends the <see cref="WM_SYSCOMMAND"/> message to the window.
        /// </para>
        /// <para>
        /// Unlike the <see cref="WM_NCLBUTTONDBLCLK"/>, <see cref="WM_NCMBUTTONDBLCLK"/>, and <see cref="WM_NCRBUTTONDBLCLK"/> messages,
        /// an application should return <see cref="TRUE"/> from this message if it processes it.
        /// Doing so will allow software that simulates this message on Windows systems earlier than Windows 2000
        /// to determine whether the window procedure processed the message or called <see cref="DefWindowProc"/> to process it.
        /// </para>
        /// </remarks>
        WM_NCXBUTTONUP = 0x00AC,

        /// <summary>
        /// <para>
        /// Posted when the user double-clicks the right mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether various virtual keys are down.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Only windows that have the <see cref="CS_DBLCLKS"/> style can receive <see cref="WM_RBUTTONDBLCLK"/> messages,
        /// which the system generates whenever the user presses, releases,
        /// and again presses the right mouse button within the system's double-click time limit.
        /// Double-clicking the right mouse button actually generates four messages:
        /// <see cref="WM_RBUTTONDOWN"/>, <see cref="WM_RBUTTONUP"/>, <see cref="WM_RBUTTONDBLCLK"/>, and <see cref="WM_RBUTTONUP"/> again.
        /// </para>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// </remarks>
        WM_RBUTTONDBLCLK = 0x0206,

        /// <summary>
        /// <para>
        /// Posted when the user presses the right mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether various virtual keys are down.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// To detect that the ALT key was pressed, check whether <see cref="GetKeyState"/> with <see cref="VK_MENU"/> &lt; 0.
        /// Note, this must not be <see cref="GetAsyncKeyState"/>.
        /// </para>
        /// </remarks>
        WM_RBUTTONDOWN = 0x0204,

        /// <summary>
        /// <para>
        /// Posted when the user releases the right mouse button while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether various virtual keys are down.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// </remarks>
        WM_RBUTTONUP = 0x0205,

        /// <summary>
        /// <para>
        /// Posted when the user double-clicks either XBUTTON1 or XBUTTON2 while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word indicates whether various virtual keys are down.
        /// It can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The high-order word indicates which button was double-clicked.
        /// It can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 was double-clicked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 was double-clicked.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return <see cref="TRUE"/>.
        /// For more information about processing the return value, see the Remarks section.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Windows supports mice with up to five buttons: left, middle, and right, plus two additional buttons called XBUTTON1 and XBUTTON2.
        /// The XBUTTON1 and XBUTTON2 buttons are often located on the sides of the mouse, near the base.
        /// These extra buttons are not present on all mice.
        /// If present, the XBUTTON1 and XBUTTON2 buttons are often mapped to an application function,
        /// such as forward and backward navigation in a Web browser.
        /// </para>
        /// <para>
        /// Use the following code to get the information in the wParam parameter:
        /// </para>
        /// <code>
        /// fwKeys = GET_KEYSTATE_WPARAM (wParam); 
        /// fwButton = GET_XBUTTON_WPARAM (wParam);
        /// </code>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// Only windows that have the <see cref="CS_DBLCLKS"/> style can receive <see cref="WM_XBUTTONDBLCLK"/> messages,
        /// which the system generates whenever the user presses, releases,
        /// and again presses either XBUTTON1 or XBUTTON2 within the system's double-click time limit.
        /// Double-clicking one of these buttons actually generates four messages:
        /// <see cref="WM_XBUTTONDOWN"/>, <see cref="WM_XBUTTONUP"/>, <see cref="WM_XBUTTONDBLCLK"/>, and <see cref="WM_XBUTTONUP"/> again.
        /// </para>
        /// <para>
        /// Unlike the <see cref="WM_LBUTTONDBLCLK"/>, <see cref="WM_MBUTTONDBLCLK"/>, and <see cref="WM_RBUTTONDBLCLK"/> messages,
        /// an application should return <see cref="TRUE"/> from this message if it processes it.
        /// Doing so will allow software that simulates this message on Windows systems earlier than Windows 2000 to determine
        /// whether the window procedure processed the message or called <see cref="DefWindowProc"/> to process it.
        /// </para>
        /// </remarks>
        WM_XBUTTONDBLCLK = 0x020D,

        /// <summary>
        /// <para>
        /// Posted when the user presses either XBUTTON1 or XBUTTON2 while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word indicates whether various virtual keys are down.
        /// It can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The high-order word indicates which button was double-clicked.
        /// It can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 was double-clicked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 was double-clicked.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return <see cref="TRUE"/>.
        /// For more information about processing the return value, see the Remarks section.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Windows supports mice with up to five buttons: left, middle, and right, plus two additional buttons called XBUTTON1 and XBUTTON2.
        /// The XBUTTON1 and XBUTTON2 buttons are often located on the sides of the mouse, near the base.
        /// These extra buttons are not present on all mice.
        /// If present, the XBUTTON1 and XBUTTON2 buttons are often mapped to an application function,
        /// such as forward and backward navigation in a Web browser.
        /// </para>
        /// <para>
        /// Use the following code to get the information in the wParam parameter:
        /// </para>
        /// <code>
        /// fwKeys = GET_KEYSTATE_WPARAM (wParam); 
        /// fwButton = GET_XBUTTON_WPARAM (wParam);
        /// </code>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// Unlike the <see cref="WM_LBUTTONDBLCLK"/>, <see cref="WM_MBUTTONDBLCLK"/>, and <see cref="WM_RBUTTONDBLCLK"/> messages,
        /// an application should return <see cref="TRUE"/> from this message if it processes it.
        /// Doing so will allow software that simulates this message on Windows systems earlier than Windows 2000 to determine
        /// whether the window procedure processed the message or called <see cref="DefWindowProc"/> to process it.
        /// </para>
        /// </remarks>
        WM_XBUTTONDOWN = 0x020B,

        /// <summary>
        /// <para>
        /// Posted when the user releases either XBUTTON1 or XBUTTON2 while the cursor is in the client area of a window.
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word indicates whether various virtual keys are down.
        /// It can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_CONTROL"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_LBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The left mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_MBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The middle mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_RBUTTON"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The right mouse button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_SHIFT"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MK_XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 is down.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The high-order word indicates which button was released.
        /// It can be one of the following values:
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON1 was released.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The XBUTTON2 was released.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the x-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// The high-order word specifies the y-coordinate of the cursor.
        /// The coordinate is relative to the upper-left corner of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return <see cref="TRUE"/>.
        /// For more information about processing the return value, see the Remarks section.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Windows supports mice with up to five buttons: left, middle, and right, plus two additional buttons called XBUTTON1 and XBUTTON2.
        /// The XBUTTON1 and XBUTTON2 buttons are often located on the sides of the mouse, near the base.
        /// These extra buttons are not present on all mice.
        /// If present, the XBUTTON1 and XBUTTON2 buttons are often mapped to an application function,
        /// such as forward and backward navigation in a Web browser.
        /// </para>
        /// <para>
        /// Use the following code to get the information in the wParam parameter:
        /// </para>
        /// <code>
        /// fwKeys = GET_KEYSTATE_WPARAM (wParam); 
        /// fwButton = GET_XBUTTON_WPARAM (wParam);
        /// </code>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// As noted above, the x-coordinate is in the low-order short of the return value;
        /// the y-coordinate is in the high-order short
        /// (both represent signed values because they can take negative values on systems with multiple monitors).
        /// If the return value is assigned to a variable,
        /// you can use the <see cref="MAKEPOINTS"/> macro to obtain a <see cref="POINTS"/> structure from the return value.
        /// You can also use the <see cref="GET_X_LPARAM"/> or <see cref="GET_Y_LPARAM"/> macro to extract the x- or y-coordinate.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Do not use the <see cref="LOWORD"/> or <see cref="HIWORD"/> macros to extract the x- and y- coordinates of the cursor position
        /// because these macros return incorrect results on systems with multiple monitors.
        /// Systems with multiple monitors can have negative x- and y- coordinates,
        /// and <see cref="LOWORD"/> and <see cref="HIWORD"/> treat the coordinates as unsigned quantities.
        /// </para>
        /// <para>
        /// Unlike the <see cref="WM_LBUTTONDBLCLK"/>, <see cref="WM_MBUTTONDBLCLK"/>, and <see cref="WM_RBUTTONDBLCLK"/> messages,
        /// an application should return <see cref="TRUE"/> from this message if it processes it.
        /// Doing so will allow software that simulates this message on Windows systems earlier than Windows 2000 to determine
        /// whether the window procedure processed the message or called <see cref="DefWindowProc"/> to process it.
        /// </para>
        /// </remarks>
        WM_XBUTTONUP = 0x020C,

        #endregion

        #region Multiple Document Interface Messages

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_MDIACTIVATE"/> message to a multiple-document interface (MDI) client window
        /// to instruct the client window to activate a different MDI child window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the MDI child window to be activated.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application sends this message to an MDI client window, the return value is zero.
        /// </para>
        /// <para>
        /// An MDI child window should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// As the client window processes this message,
        /// it sends <see cref="WM_MDIACTIVATE"/> to the child window being deactivated and to the child window being activated.
        /// The message parameters received by an MDI child window are as follows:
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the MDI child window being deactivated.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the MDI child window being activated.
        /// </para>
        /// <para>
        /// An MDI child window is activated independently of the MDI frame window.
        /// When the frame window becomes active, the child window last activated by using the <see cref="WM_MDIACTIVATE"/> message
        /// receives the <see cref="WM_NCACTIVATE"/> message to draw an active window frame and title bar;
        /// the child window does not receive another <see cref="WM_MDIACTIVATE"/> message.
        /// </para>
        /// </remarks>
        WM_MDIACTIVATE = 0x0222,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_MDICASCADE"/> message
        /// to a multiple-document interface (MDI) client window to arrange all its child windows in a cascade format.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The cascade behavior.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MDITILE_SKIPDISABLED"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Prevents disabled MDI child windows from being cascaded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MDITILE_ZORDER"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// Arranges the windows in Z order.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the message succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If the message fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </summary>
        WM_MDICASCADE = 0x0227,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_MDICREATE"/> message
        /// to a multiple-document interface (MDI) client window to create an MDI child window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to an <see cref="MDICREATESTRUCT"/> structure containing information that the system uses to create the MDI child window.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: <see cref="HWND"/>
        /// </para>
        /// <para>
        /// If the message succeeds, the return value is the handle to the new child window.
        /// </para>
        /// <para>
        /// If the message fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The MDI child window is created with the window style bits <see cref="WS_CHILD"/>,
        /// <see cref="WS_CLIPSIBLINGS"/>,<see cref="WS_CLIPCHILDREN"/>, <see cref="WS_SYSMENU"/>,
        /// <see cref="WS_CAPTION"/>, <see cref="WS_THICKFRAME"/>, <see cref="WS_MINIMIZEBOX"/>,
        /// and <see cref="WS_MAXIMIZEBOX"/>, plus additional style bits specified in the <see cref="MDICREATESTRUCT"/> structure.
        /// The system adds the title of the new child window to the window menu of the frame window.
        /// An application should use this message to create all child windows of the client window.
        /// </para>
        /// <para>
        /// If an MDI client window receives any message that changes the activation of its child windows while the active child window is maximized,
        /// the system restores the active child window and maximizes the newly activated child window.
        /// </para>
        /// <para>
        /// When an MDI child window is created, the system sends the <see cref="WM_CREATE"/> message to the window.
        /// The lParam parameter of the <see cref="WM_CREATE"/> message contains a pointer to a <see cref="CREATESTRUCT"/> structure.
        /// The <see cref="CREATESTRUCT.lpCreateParams"/> member of this structure contains
        /// a pointer to the <see cref="MDICREATESTRUCT"/> structure passed with the <see cref="WM_MDICREATE"/> message that created the MDI child window.
        /// </para>
        /// <para>
        /// An application should not send a second <see cref="WM_MDICREATE"/> message
        /// while a <see cref="WM_MDICREATE"/> message is still being processed.
        /// For example, it should not send a <see cref="WM_MDICREATE"/> message
        /// while an MDI child window is processing its <see cref="WM_MDICREATE"/> message.
        /// </para>
        /// </remarks>
        WM_MDICREATE = 0x0220,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_MDIDESTROY"/> message
        /// to a multiple-document interface (MDI) client window to close an MDI child window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the MDI child window to be closed.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message always returns zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message removes the title of the MDI child window from the MDI frame window and deactivates the child window.
        /// An application should use this message to close all MDI child windows.
        /// </para>
        /// <para>
        /// If an MDI client window receives a message that changes the activation of its child windows and the active MDI child window is maximized,
        /// the system restores the active child window and maximizes the newly activated child window.
        /// </para>
        /// </remarks>
        WM_MDIDESTROY = 0x0221,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_MDIGETACTIVE"/> message
        /// to a multiple-document interface (MDI) client window to retrieve the handle to the active MDI child window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The maximized state. If this parameter is not <see cref="NULL"/>,
        /// it is a pointer to a value that indicates the maximized state of the MDI child window.
        /// If the value is <see cref="TRUE"/>, the window is maximized; a value of <see cref="FALSE"/> indicates that it is not.
        /// If this parameter is <see cref="NULL"/>, the parameter is ignored.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: <see cref="HWND"/>
        /// </para>
        /// <para>
        /// The return value is the handle to the active MDI child window.
        /// </para>
        /// </summary>
        WM_MDIGETACTIVE = 0x0229,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_MDIICONARRANGE"/> message
        /// to a multiple-document interface (MDI) client window to arrange all minimized MDI child windows.
        /// It does not affect child windows that are not minimized.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used; it must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used; it must be zero.
        /// </para>
        /// </summary>
        WM_MDIICONARRANGE = 0x0228,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_MDIMAXIMIZE"/> message
        /// to a multiple-document interface (MDI) client window to maximize an MDI child window.
        /// The system resizes the child window to make its client area fill the client window.
        /// The system places the child window's window menu icon in the rightmost position of the frame window's menu bar,
        /// and places the child window's restore icon in the leftmost position.
        /// The system also appends the title bar text of the child window to that of the frame window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the MDI child window to be maximized.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is always zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// If an MDI client window receives any message that changes the activation of its child windows
        /// while the currently active MDI child window is maximized,
        /// the system restores the active child window and maximizes the newly activated child window.
        /// </remarks>
        WM_MDIMAXIMIZE = 0x0225,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_MDINEXT"/> message
        /// to a multiple-document interface (MDI) client window to activate the next or previous child window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the MDI child window.
        /// The system activates the child window that is immediately before or after the specified child window,
        /// depending on the value of the lParam parameter.
        /// If the wParam parameter is <see cref="NULL"/>,
        /// the system activates the child window that is immediately before or after the currently active child window.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// If this parameter is zero, the system activates the next MDI child window
        /// and places the child window identified by the wParam parameter behind all other child windows.
        /// If this parameter is nonzero, the system activates the previous child window,
        /// placing it in front of the child window identified by wParam.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is always zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// If an MDI client window receives any message that changes the activation of its child windows
        /// while the active MDI child window is maximized,
        /// the system restores the active child window and maximizes the newly activated child window.
        /// </remarks>
        WM_MDINEXT = 0x0224,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_MDIREFRESHMENU"/> message
        /// to a multiple-document interface (MDI) client window to refresh the window menu of the MDI frame window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: <see cref="HMENU"/>
        /// </para>
        /// <para>
        /// If the message succeeds, the return value is the handle to the frame window menu.
        /// </para>
        /// <para>
        /// If the message fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </summary>
        /// <remarks>
        /// After sending this message, an application must call the <see cref="DrawMenuBar"/> function to update the menu bar.
        /// </remarks>
        WM_MDIREFRESHMENU = 0x0234,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_MDIRESTORE"/> message to a multiple-document interface (MDI) client window
        /// to restore an MDI child window from maximized or minimized size.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the MDI child window to be restored.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is always zero.
        /// </para>
        /// </summary>
        WM_MDIRESTORE = 0x0223,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_MDISETMENU"/> message to a multiple-document interface (MDI) client window
        /// to replace the entire menu of an MDI frame window, to replace the window menu of the frame window, or both.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the new frame window menu.
        /// If this parameter is <see cref="NULL"/>, the frame window menu is not changed.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the new window menu.
        /// If this parameter is <see cref="NULL"/>, the window menu is not changed.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the message succeeds, the return value is the handle to the old frame window menu.
        /// </para>
        /// <para>
        /// If the message fails, the return value is zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// After sending this message, an application must call the <see cref="DrawMenuBar"/> function to update the menu bar.
        /// </para>
        /// <para>
        /// If this message replaces the window menu,
        /// the MDI child window menu items are removed from the previous window menu and added to the new window menu.
        /// </para>
        /// <para>
        /// If an MDI child window is maximized and this message replaces the MDI frame window menu,
        /// the window menu icon and restore icon are removed from the previous frame window menu and added to the new frame window menu.
        /// </para>
        /// </remarks>
        WM_MDISETMENU = 0x0230,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_MDITILE"/> message
        /// to a multiple-document interface (MDI) client window to arrange all of its MDI child windows in a tile format.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The tiling option.
        /// This parameter can be one of the following values,
        /// optionally combined with <see cref="MDITILE_SKIPDISABLED"/> to prevent disabled MDI child windows from being tiled.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MDITILE_HORIZONTAL"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Tiles windows horizontally.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MDITILE_VERTICAL"/>
        /// </para>
        /// <para>
        /// 0x0000
        /// </para>
        /// </term>
        /// <term>
        /// Tiles windows vertically.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the message succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If the message fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </summary>
        WM_MDITILE = 0x0226,

        #endregion

        #region Painting and Drawing Messages

        /// <summary>
        /// <para>
        /// The <see cref="WM_DISPLAYCHANGE"/> message is sent to all windows when the display resolution has changed.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The new image depth of the display, in bits per pixel.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the horizontal resolution of the screen.
        /// </para>
        /// <para>
        /// The high-order word specifies the vertical resolution of the screen.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-displaychange"/>
        /// </para>
        /// </summary>
        /// <remark>
        /// This message is only sent to top-level windows.
        /// For all other windows it is posted.
        /// </remark>
        WM_DISPLAYCHANGE = 0x007E,

        /// <summary>
        /// <para>
        /// The <see cref="WM_NCPAINT"/> message is sent to a window when its frame must be painted.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the update region of the window.
        /// The update region is clipped to the window frame.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application returns zero if it processes this message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-ncpaint"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="DefWindowProc"/> function paints the window frame.
        /// </para>
        /// <para>
        /// An application can intercept the <see cref="WM_NCPAINT"/> message and paint its own custom window frame.
        /// The clipping region for a window is always rectangular, even if the shape of the frame is altered.
        /// </para>
        /// <para>
        /// The wParam value can be passed to <see cref="GetDCEx"/> as in the following example.
        /// </para>
        /// <code>
        /// case WM_NCPAINT:
        /// {
        ///     HDC hdc;
        ///     hdc = GetDCEx(hwnd, (HRGN)wParam, DCX_WINDOW|DCX_INTERSECTRGN);
        ///     // Paint into this DC 
        ///     ReleaseDC(hwnd, hdc);
        /// }
        /// </code>
        /// </remarks>
        WM_NCPAINT = 0x0085,

        /// <summary>
        /// <para>
        /// The <see cref="WM_PAINT"/> message is sent when the system or another application
        /// makes a request to paint a portion of an application's window.
        /// The message is sent when the <see cref="UpdateWindow"/> or <see cref="RedrawWindow"/> function is called,
        /// or by the <see cref="DispatchMessage"/> function when the application obtains a <see cref="WM_PAINT"/> message
        /// by using the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application returns zero if it processes this message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-paint"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="WM_PAINT"/> message is generated by the system and should not be sent by an application.
        /// To force a window to draw into a specific device context, use the <see cref="WM_PRINT"/> or <see cref="WM_PRINTCLIENT"/> message.
        /// Note that this requires the target window to support the <see cref="WM_PRINTCLIENT"/> message.
        /// Most common controls support the <see cref="WM_PRINTCLIENT"/> message.
        /// </para>
        /// <para>
        /// The <see cref="DefWindowProc"/> function validates the update region.
        /// The function may also send the <see cref="WM_NCPAINT"/> message to the window procedure
        /// if the window frame must be painted and send the <see cref="WM_ERASEBKGND"/> message if the window background must be erased.
        /// </para>
        /// <para>
        /// The system sends this message when there are no other messages in the application's message queue.
        /// <see cref="DispatchMessage"/> determines where to send the message; <see cref="GetMessage"/> determines which message to dispatch.
        /// <see cref="GetMessage"/> returns the <see cref="WM_PAINT"/> message when there are no other messages in the application's message queue,
        /// and <see cref="DispatchMessage"/> sends the message to the appropriate window procedure.
        /// </para>
        /// <para>
        /// A window may receive internal paint messages as a result of calling <see cref="RedrawWindow"/> with the <see cref="RDW_INTERNALPAINT"/> flag set.
        /// In this case, the window may not have an update region.
        /// An application may call the <see cref="GetUpdateRect"/> function to determine whether the window has an update region.
        /// If <see cref="GetUpdateRect"/> returns zero, the application need not call the <see cref="BeginPaint"/> and <see cref="EndPaint"/> functions.
        /// </para>
        /// <para>
        /// An application must check for any necessary internal painting
        /// by looking at its internal data structures for each <see cref="WM_PAINT"/> message,
        /// because a <see cref="WM_PAINT"/> message may have been caused by both a non-NULL update region
        /// and a call to <see cref="RedrawWindow"/> with the <see cref="RDW_INTERNALPAINT"/> flag set.
        /// </para>
        /// <para>
        /// The system sends an internal <see cref="WM_PAINT"/> message only once.
        /// After an internal <see cref="WM_PAINT"/> message is returned from <see cref="GetMessage"/> or <see cref="PeekMessage"/>
        /// or is sent to a window by <see cref="UpdateWindow"/>, the system does not post or send further <see cref="WM_PAINT"/> messages
        /// until the window is invalidated or until <see cref="RedrawWindow"/> is called again with the <see cref="RDW_INTERNALPAINT"/> flag set.
        /// </para>
        /// <para>
        /// For some common controls, the default <see cref="WM_PAINT"/> message processing checks the wParam parameter.
        /// If wParam is non-NULL, the control assumes that the value is an HDC and paints using that device context.
        /// </para>
        /// </remarks>
        WM_PAINT = 0x000F,

        /// <summary>
        /// <para>
        /// The <see cref="WM_PRINT"/> message is sent to a window to request that it draw itself in the specified device context,
        /// most commonly in a printer device context.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the device context to draw in.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The drawing options.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PRF_CHECKVISIBLE"/>
        /// </term>
        /// <term>
        /// Draws the window only if it is visible.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRF_CHILDREN"/>
        /// </term>
        /// <term>
        /// Draws all visible children windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRF_CLIENT"/>
        /// </term>
        /// <term>
        /// Draws the client area of the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRF_ERASEBKGND"/>
        /// </term>
        /// <term>
        /// Erases the background before drawing the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRF_NONCLIENT"/>
        /// </term>
        /// <term>
        /// Draws the nonclient area of the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRF_OWNED"/>
        /// </term>
        /// <term>
        /// Draws all owned windows.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-print"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The <see cref="DefWindowProc"/> function processes this message based on which drawing option is specified:
        /// if <see cref="PRF_CHECKVISIBLE"/> is specified and the window is not visible, do nothing,
        /// if <see cref="PRF_NONCLIENT"/> is specified, draw the nonclient area in the specified device context,
        /// if <see cref="PRF_ERASEBKGND"/> is specified, send the window a <see cref="WM_ERASEBKGND"/> message,
        /// if <see cref="PRF_CLIENT"/> is specified, send the window a <see cref="WM_PRINTCLIENT"/> message,
        /// if <see cref="PRF_CHILDREN"/> is set, send each visible child window a <see cref="WM_PRINT"/> message,
        /// if <see cref="PRF_OWNED"/> is set, send each visible owned window a <see cref="WM_PRINT"/> message.
        /// </remarks>
        WM_PRINT = 0x0317,

        /// <summary>
        /// <para>
        /// The <see cref="WM_PRINTCLIENT"/> message is sent to a window to request
        /// that it draw its client area in the specified device context, most commonly in a printer device context.
        /// </para>
        /// <para>
        /// Unlike <see cref="WM_PRINT"/>, <see cref="WM_PRINTCLIENT"/> is not processed by <see cref="DefWindowProc"/>.
        /// A window should process the <see cref="WM_PRINTCLIENT"/> message
        /// through an application-defined WindowProc function for it to be used properly.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the device context to draw in.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The drawing options. This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PRF_CHECKVISIBLE"/>
        /// </term>
        /// <term>
        /// Draws the window only if it is visible.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRF_CHILDREN"/>
        /// </term>
        /// <term>
        /// Draws all visible children windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRF_CLIENT"/>
        /// </term>
        /// <term>
        /// Draws the client area of the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRF_ERASEBKGND"/>
        /// </term>
        /// <term>
        /// Erases the background before drawing the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRF_NONCLIENT"/>
        /// </term>
        /// <term>
        /// Draws the nonclient area of the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PRF_OWNED"/>
        /// </term>
        /// <term>
        /// Draws all owned windows.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-printclient"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A window can process this message in much the same manner as <see cref="WM_PAINT"/>,
        /// except that <see cref="BeginPaint"/> and <see cref="EndPaint"/> need not be called (a device context is provided),
        /// and the window should draw its entire client area rather than just the invalid region.
        /// </para>
        /// <para>
        /// Windows that can be used anywhere in the system, such as controls, should process this message.
        /// It is probably worthwhile for other windows to process this message as well because it is relatively easy to implement.
        /// </para>
        /// <para>
        /// The <see cref="AnimateWindow"/> function requires that the window being animated implements the <see cref="WM_PRINTCLIENT"/> message.
        /// </para>
        /// </remarks>
        WM_PRINTCLIENT = 0x0318,

        /// <summary>
        /// <para>
        /// You send the <see cref="WM_SETREDRAW"/> message to a window to allow changes in that window to be redrawn,
        /// or to prevent changes in that window from being redrawn.
        /// </para>
        /// <para>
        /// To send this message, call the <see cref="SendMessage"/> function with the following parameters.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// The redraw state. If this parameter is <see cref="TRUE"/>, then the content can be redrawn after a change.
        /// If this parameter is <see cref="FALSE"/>, then the content can't be redrawn after a change.
        /// </para>
        /// <para>
        /// This parameter isn't used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Your application should return 0 if it processes this message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-setredraw"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message can be useful if your application must add several items to a list box.
        /// Your application can call this message with wParam set to <see cref="FALSE"/>,
        /// add the items, and then call the message again with wParam set to <see cref="TRUE"/>.
        /// Finally, your application can call
        /// <c> RedrawWindow(hWnd, NULL, NULL, RDW_ERASE | RDW_FRAME | RDW_INVALIDATE | RDW_ALLCHILDREN)</c> to cause the list box to be repainted.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// You should use <see cref="RedrawWindow"/> with the specified flags, instead of <see cref="InvalidateRect"/>,
        /// because the former is necessary for some controls that have nonclient area of their own,
        /// or have window styles that cause them to be given a nonclient area
        /// (such as <see cref="WS_THICKFRAME"/>, <see cref="WS_BORDER"/>, or <see cref="WS_EX_CLIENTEDGE"/>).
        /// If the control does not have a nonclient area, then <see cref="RedrawWindow"/> with these flags
        /// will do only as much invalidation as <see cref="InvalidateRect"/> would.
        /// </para>
        /// <para>
        /// Passing a <see cref="WM_SETREDRAW"/> message to the <see cref="DefWindowProc"/> function
        /// removes the <see cref="WS_VISIBLE"/> style from the window when wParam is set to <see cref="FALSE"/>.
        /// Although the window content remains visible on screen,
        /// the <see cref="IsWindowVisible"/> function returns <see cref="FALSE"/> when called on a window in this state.
        /// </para>
        /// <para>
        /// Passing a <see cref="WM_SETREDRAW"/> message to the <see cref="DefWindowProc"/> function
        /// adds the <see cref="WS_VISIBLE"/> style to the window, if not set, when wParam is set to <see cref="TRUE"/>.
        /// If your application sends the <see cref="WM_SETREDRAW"/> message with wParam set to <see cref="TRUE"/> to a hidden window,
        /// then the window becomes visible.
        /// </para>
        /// <para>
        /// Windows 10 and later; Windows Server 2016 and later.
        /// The system sets a property named SysSetRedraw on a window
        /// whose window procedure passes <see cref="WM_SETREDRAW"/> messages to <see cref="DefWindowProc"/>.
        /// You can use the <see cref="GetProp"/> function to get the property value when it's available.
        /// <see cref="GetProp"/> returns a non-zero value when redraw is disabled.
        /// <see cref="GetProp"/> will return zero when redraw is enabled, or when the window property doesn't exist.
        /// </para>
        /// </remarks>
        WM_SETREDRAW = 0x000B,

        /// <summary>
        /// <para>
        /// The <see cref="WM_SYNCPAINT"/> message is used to synchronize painting while avoiding linking independent GUI threads.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application returns zero if it processes this message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/gdi/wm-syncpaint"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// When a window has been hidden, shown, moved, or sized, the system may determine
        /// that it is necessary to send a <see cref="WM_SYNCPAINT"/> message to the top-level windows of other threads.
        /// Applications must pass <see cref="WM_SYNCPAINT"/> to <see cref="DefWindowProc"/> for processing.
        /// The <see cref="DefWindowProc"/> function will send a <see cref="WM_NCPAINT"/> message to the window procedure
        /// if the window frame must be painted and send a <see cref="WM_ERASEBKGND"/> message if the window background must be erased.
        /// </remarks>
        WM_SYNCPAINT = 0x0088,

        #endregion

        #region  Pointer Input Messages and Notifications

        /// <summary>
        /// <para>
        /// Posted when a pointer makes contact over the non-client area of a window.
        /// The message targets the window over which the pointer makes contact.
        /// The pointer is implicitly captured to the window
        /// so that the window continues to receive input for the pointer until it breaks contact.
        /// </para>
        /// <para>
        /// If a window has captured this pointer, this message is not posted.
        /// Instead, a <see cref="WM_POINTERDOWN"/> is posted to the window that has captured this pointer.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains the pointer identifier and additional information. Use the following macros to retrieve this information.
        /// </para>
        /// <para>
        /// <see cref="GET_POINTERID_WPARAM"/>(wParam): pointer identifier.
        /// </para>
        /// <para>
        /// <see cref="HIWORD"/>(wParam): hit-test value returned from processing the <see cref="WM_NCHITTEST"/> message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains the point location of the pointer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Because the pointer may make contact with the device over a non-trivial area,
        /// this point location may be a simplification of a more complex pointer area.
        /// Whenever possible, an application should use the complete pointer area information instead of the point location.
        /// </para>
        /// <para>
        /// Use the following macros to retrieve the physical screen coordinates of the point.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_X_LPARAM"/>(lParam): the x (horizontal point) coordinate.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GET_Y_LPARAM"/>(lParam): the y (vertical point) coordinate.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-ncpointerdown"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// If the application does not process this message,
        /// <see cref="DefWindowProc"/> may perform one or more system actions depending on the hit-test result included in the message.
        /// Typically, applications should not need to handle this message.
        /// </remarks>
        WM_NCPOINTERDOWN = 0x0242,

        /// <summary>
        /// <para>
        /// Posted when a pointer that made contact over the non-client area of a window breaks contact.
        /// The message targets the window over which the pointer makes contact and the pointer is, at that point,
        /// implicitly captured to the window so that the window continues to receive input for the pointer until it breaks contact,
        /// including the <see cref="WM_NCPOINTERUP"/> notification.
        /// </para>
        /// <para>
        /// If a window has captured this pointer, this message is not posted.
        /// Instead, a <see cref="WM_POINTERUP"/> is posted to the window that has captured this pointer.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains the pointer identifier and additional information. Use the following macros to retrieve this information.
        /// </para>
        /// <para>
        /// <see cref="GET_POINTERID_WPARAM"/>(wParam): pointer identifier.
        /// </para>
        /// <para>
        /// <see cref="HIWORD"/>(wParam): hit-test value returned from processing the <see cref="WM_NCHITTEST"/> message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains the point location of the pointer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Because the pointer may make contact with the device over a non-trivial area,
        /// this point location may be a simplification of a more complex pointer area.
        /// Whenever possible, an application should use the complete pointer area information instead of the point location.
        /// </para>
        /// <para>
        /// Use the following macros to retrieve the physical screen coordinates of the point.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_X_LPARAM"/>(lParam): the x (horizontal point) coordinate.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GET_Y_LPARAM"/>(lParam): the y (vertical point) coordinate.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-ncpointerup"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// If the application does not process this message,
        /// <see cref="DefWindowProc"/> may perform one or more system actions depending on the hit-test result included in the message.
        /// Typically, applications should not need to handle this message.
        /// </remarks>
        WM_NCPOINTERUP = 0x0243,

        /// <summary>
        /// <para>
        /// Posted to provide an update on a pointer that made contact over the non-client area of a window
        /// or when a hovering uncaptured contact moves over the non-client area of a window.
        /// While the pointer is hovering, the message targets whichever window the pointer happens to be over.
        /// While the pointer is in contact with the surface, the pointer is implicitly captured to the window over
        /// which the pointer made contact and that window continues to receive input for the pointer until it breaks contact.
        /// </para>
        /// <para>
        /// If a window has captured this pointer, this message is not posted.
        /// Instead, a <see cref="WM_POINTERUPDATE"/> is posted to the window that has captured this pointer.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains the pointer identifier and additional information. Use the following macros to retrieve this information.
        /// </para>
        /// <para>
        /// <see cref="GET_POINTERID_WPARAM"/>(wParam): pointer identifier.
        /// </para>
        /// <para>
        /// <see cref="HIWORD"/>(wParam): hit-test value returned from processing the <see cref="WM_NCHITTEST"/> message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains the point location of the pointer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Because the pointer may make contact with the device over a non-trivial area,
        /// this point location may be a simplification of a more complex pointer area.
        /// Whenever possible, an application should use the complete pointer area information instead of the point location.
        /// </para>
        /// <para>
        /// Use the following macros to retrieve the physical screen coordinates of the point.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_X_LPARAM"/>(lParam): the x (horizontal point) coordinate.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GET_Y_LPARAM"/>(lParam): the y (vertical point) coordinate.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-ncpointerupdate"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// If the application does not process this message,
        /// <see cref="DefWindowProc"/> may perform one or more system actions depending on the hit-test result included in the message.
        /// Typically, applications should not need to handle this message.
        /// </remarks>
        WM_NCPOINTERUPDATE = 0x0241,

        /// <summary>
        /// <para>
        /// Sent to a window when a significant action occurs on a descendant window.
        /// This message is now extended to include the <see cref="WM_POINTERDOWN"/> event.
        /// When the child window is being created, the system sends <see cref="WM_PARENTNOTIFY"/>
        /// just before the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function that creates the window returns.
        /// When the child window is being destroyed,
        /// the system sends the message before any processing to destroy the window takes place.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word of wParam specifies the event for which the parent is being notified.
        /// The value of the high-order word depends on the value of the low-order word.
        /// This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <c>LOWORD(wParam)</c>
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WM_CREATE"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The child window is being created.
        /// </para>
        /// <para>
        /// <c>HIWORD(wParam)</c> is the identifier of the child window.
        /// </para>
        /// <para>
        /// lParam is a handle to the child window.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WM_DESTROY"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The child window is being destroyed.
        /// </para>
        /// <para>
        /// HHIWORD(wParam)is the identifier of the child window.
        /// </para>
        /// <para>
        /// lParam is a handle to the child window.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WM_LBUTTONDOWN"/>
        /// </para>
        /// <para>
        /// 0x0201
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The user has placed the cursor over the child window and has clicked the left mouse button.
        /// </para>
        /// <para>
        /// HIWORD(wParam) is undefined.
        /// </para>
        /// <para>
        /// lParam is the x-coordinate of the cursor is the low-order word, and the y-coordinate of the cursor is the high-order word.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WM_MBUTTONDOWN"/>
        /// </para>
        /// <para>
        /// 0x0207
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The user has placed the cursor over the child window and has clicked the middle mouse button.
        /// </para>
        /// <para>
        /// HIWORD(wParam) is undefined.
        /// </para>
        /// <para>
        /// lParam is the x-coordinate of the cursor is the low-order word, and the y-coordinate of the cursor is the high-order word.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WM_RBUTTONDOWN"/>
        /// </para>
        /// <para>
        /// 0x0204
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The user has placed the cursor over the child window and has clicked the right mouse button.
        /// </para>
        /// <para>
        /// HIWORD(wParam) is undefined.
        /// </para>
        /// <para>
        /// lParam is the x-coordinate of the cursor is the low-order word, and the y-coordinate of the cursor is the high-order word.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WM_XBUTTONDOWN"/>
        /// </para>
        /// <para>
        /// 0x020B
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The user has placed the cursor over the child window and has clicked the first or second X button.
        /// </para>
        /// <para>
        /// HIWORD(wParam) indicates which button was pressed. This parameter can be one of the following values: XBUTTON1 or XBUTTON2.
        /// </para>
        /// <para>
        /// lParam is the x-coordinate of the cursor is the low-order word, and the y-coordinate of the cursor is the high-order word.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WM_POINTERDOWN"/>
        /// </para>
        /// <para>
        /// 0x0246
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// A pointer has made contact with the child window.
        /// </para>
        /// <para>
        /// HIWORD(wParam) contains the identifier of the pointer that generated the <see cref="WM_POINTERDOWN"/> event.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains the point location of the pointer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Because the pointer may make contact with the device over a non-trivial area,
        /// this point location may be a simplification of a more complex pointer area.
        /// Whenever possible, an application should use the complete pointer area information instead of the point location.
        /// </para>
        /// <para>
        /// Use the following macros to retrieve the physical screen coordinates of the point.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_X_LPARAM"/>(lParam): the x (horizontal point) coordinate.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GET_Y_LPARAM"/>(lParam): the y (vertical point) coordinate.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-parentnotify"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message is also sent to all ancestor windows of the child window, including the top-level window.
        /// </para>
        /// <para>
        /// All child windows, except those that have the <see cref="WS_EX_NOPARENTNOTIFY"/> extended window style,
        /// send this message to their parent windows.
        /// By default, child windows in a dialog box have the <see cref="WS_EX_NOPARENTNOTIFY"/> style,
        /// unless the <see cref="CreateWindowEx"/> function is called to create the child window without this style.
        /// </para>
        /// <para>
        /// This notification provides the child window's ancestor windows an opportunity to examine the pointer information and,
        /// if required, capture the pointer using the pointer capture functions.
        /// </para>
        /// </remarks>
        WM_PARENTNOTIFY = 0x0210,

        /// <summary>
        /// <para>
        /// Sent to an inactive window when a primary pointer generates a <see cref="WM_POINTERDOWN"/> over the window.
        /// As long as the message remains unhandled, it travels up the parent window chain until it is reaches the top-level window.
        /// Applications can respond to this message to specify whether they wish to be activated.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains the pointer identifier and additional information. Use the following macros to retrieve this information.
        /// </para>
        /// <para>
        /// <see cref="GET_POINTERID_WPARAM"/>(wParam): pointer identifier
        /// </para>
        /// <para>
        /// <see cref="HIWORD"/>(wParam): hit-test value returned from processing the <see cref="WM_NCHITTEST"/> message.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains the handle to the top-level window of the window being activated.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return one of the values described in the Remarks section.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointeractivate"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// An application can handle this message and return one of the following values
        /// to determine how the system processes the activation and the activating input:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="PA_ACTIVATE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PA_NOACTIVATE"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// It is important to note that, when the user is interacting with the system with multiple simultaneous pointers,
        /// the activation opportunity that the <see cref="WM_POINTERACTIVATE"/> message represents
        /// is available to applications only for the first of those pointers.
        /// Applications should, therefore, be aware that they may still receive input from pointers while they are inactive.
        /// </para>
        /// <para>
        /// If the application does not handle this message, <see cref="DefWindowProc"/> passes the message to the parent window.
        /// </para>
        /// </remarks>
        WM_POINTERACTIVATE = 0x024B,

        /// <summary>
        /// <para>
        /// Sent to a window that is losing capture of an input pointer.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains information about the input pointer that is being lost.
        /// Use <see cref="GET_POINTERID_WPARAM"/> to get the pointer ID.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains a handle to the window that is capturing the input pointer.
        /// This value can be NULL if the pointer is no longer being captured by the window.
        /// </para>
        /// <para>
        /// If this message is generated from internal processing, the value can be the handle of the window receiving the message.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointercapturechanged"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A window should use this notification to stop processing subsequent messages and initiate any cleanup required for the pointer being lost.
        /// Processing of gestures associated with the pointer should also be terminated
        /// (for example, by calling <see cref="StopInteractionContext"/>) and remaining contacts re-associated with the window.
        /// </para>
        /// <para>
        /// Typically, if a window receives the <see cref="WM_POINTERCAPTURECHANGED"/> notification,
        /// no subsequent notifications related to the input pointer are received.
        /// Because of this, do not depend on paired notifications such as <see cref="WM_POINTERENTER"/> and <see cref="WM_POINTERLEAVE"/>.
        /// </para>
        /// <para>
        /// <see cref="WM_POINTERCAPTURECHANGED"/> does not include <see cref="POINTER_INFO"/> data.
        /// Other than the <see cref="POINTER_FLAG_CAPTURECHANGED"/> flag being set,
        /// the data returned by <see cref="GetPointerInfo"/> (or any variant) is identical to that returned prior to the notification.
        /// </para>
        /// <para>
        /// If the application does not process this notification,
        /// <see cref="DefWindowProc"/> may generate one or more <see cref="WM_GESTURE"/> messages or,
        /// if a gesture is not recognized, <see cref="DefWindowProc"/> may generate mouse input.
        /// </para>
        /// <para>
        /// If an application selectively consumes some pointer input and passes the rest to <see cref="DefWindowProc"/>,
        /// the resulting behavior is undefined.
        /// </para>
        /// </remarks>
        WM_POINTERCAPTURECHANGED = 0x024C,

        /// <summary>
        /// <para>
        /// Sent to a window when there is a change in the settings of a monitor that has a digitizer attached to it.
        /// This message contains information regarding the scaling of the display mode.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains a value from Pointer Device Change Constants.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Additional message-specific information.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerdevicechange"/>
        /// </para>
        /// </summary>
        WM_POINTERDEVICECHANGE = 0x238,

        /// <summary>
        /// <para>
        /// Sent to a window when a pointer device is detected within range of an input digitizer.
        /// This message contains information regarding the device and its proximity.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Additional message-specific information.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Additional message-specific information.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerdeviceinrange"/>
        /// </para>
        /// </summary>
        WM_POINTERDEVICEINRANGE = 0x239,

        /// <summary>
        /// <para>
        /// Sent to a window when a pointer device has departed the range of an input digitizer.
        /// This message contains information regarding the device and its proximity.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Additional message-specific information.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Additional message-specific information.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerdeviceoutofrange"/>
        /// </para>
        /// </summary>
        WM_POINTERDEVICEOUTOFRANGE = 0x23A,

        /// <summary>
        /// <para>
        /// Posted when a pointer makes contact over the client area of a window.
        /// This input message targets the window over which the pointer makes contact,
        /// and the pointer is implicitly captured to the window so that the window continues to receive input for the pointer until it breaks contact.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains information about the pointer.
        /// Use the following macros to retrieve information from the wParam parameter.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_POINTERID_WPARAM"/>(wParam):
        /// the pointer identifier.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_NEW_WPARAM"/>(wParam):
        /// a flag that indicates whether this message represents the first input generated by a new pointer.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_INRANGE_WPARAM"/>(wParam):
        /// a flag that indicates whether this message was generated by a pointer during its lifetime.
        /// This flag is not set on messages that indicate that the pointer has left detection range
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_INCONTACT_WPARAM"/>(wParam):
        /// a flag that indicates whether this message was generated by a pointer that is in contact with the window surface.
        /// This flag is not set on messages that indicate a hovering pointer.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_PRIMARY_WPARAM"/>(wParam):
        /// indicates that this pointer has been designated as primary.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="IS_POINTER_FIRSTBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether there is a primary action.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This is analogous to a mouse left button down.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A touch pointer will have this set when it is in contact with the digitizer surface.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A pen pointer will have this set when it is in contact with the digitizer surface with no buttons pressed.
        /// </description>
        /// </item>
        /// </list>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="IS_POINTER_SECONDBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether there is a secondary action.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This is analogous to a mouse right button down.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A pen pointer will have this set when it is in contact with the digitizer surface with the pen barrel button pressed.
        /// </description>
        /// </item>
        /// </list>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_THIRDBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether there are one or more tertiary actions based on the pointer type;
        /// applications that wish to respond to tertiary actions must retrieve information
        /// specific to the pointer type to determine which tertiary buttons are pressed.
        /// For example, an application can determine the buttons states of a pen
        /// by calling <see cref="GetPointerPenInfo"/> and examining the flags that specify button states.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_FOURTHBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether the specified pointer took fourth action.
        /// Applications that wish to respond to fourth actions must retrieve information specific to the pointer type
        /// to determine if the first extended mouse (XButton1) button is pressed.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="IS_POINTER_FIFTHBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether the specified pointer took fifth action.
        /// Applications that wish to respond to fifth actions must retrieve information specific to the pointer type
        /// to determine if the second extended mouse (XButton2) button is pressed.
        /// </para>
        /// <para>
        /// See Pointer Flags for more details.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// A hovering pointer has none of the button flags set.
        /// This is analogous to a mouse move with no mouse buttons down.
        /// An application can determine the buttons states of a hovering pen,
        /// for example, by calling <see cref="GetPointerPenInfo"/> and examining the flags that specify button states.
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains the point location of the pointer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Because the pointer may make contact with the device over a non-trivial area,
        /// this point location may be a simplification of a more complex pointer area.
        /// Whenever possible, an application should use the complete pointer area information instead of the point location.
        /// </para>
        /// <para>
        /// Use the following macros to retrieve the physical screen coordinates of the point.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_X_LPARAM"/>(lParam): the x (horizontal point) coordinate.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GET_Y_LPARAM"/>(lParam): the y (vertical point) coordinate.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerdown"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// When a window loses capture of a pointer and it receives the <see cref="WM_POINTERCAPTURECHANGED"/> notification,
        /// it typically will not receive any further notifications.
        /// For this reason, it is important that you not make any assumptions
        /// based on evenly paired <see cref="WM_POINTERDOWN"/>/<see cref="WM_POINTERUP"/>
        /// or <see cref="WM_POINTERENTER"/>/<see cref="WM_POINTERLEAVE"/> notifications.
        /// </para>
        /// <para>
        /// Each pointer has a unique pointer identifier during its lifetime.
        /// The lifetime of a pointer begins when it is first detected.
        /// </para>
        /// <para>
        /// A <see cref="WM_POINTERENTER"/> message is generated if a hovering pointer is detected.
        /// A <see cref="WM_POINTERDOWN"/> message followed by a <see cref="WM_POINTERENTER"/> message
        /// is generated if a non-hovering pointer is detected.
        /// </para>
        /// <para>
        /// During its lifetime, a pointer may generate a series of <see cref="WM_POINTERUPDATE"/> messages while it is hovering or in contact.
        /// </para>
        /// <para>
        /// The lifetime of a pointer ends when it is no longer detected.
        /// This generates a <see cref="WM_POINTERLEAVE"/> message.
        /// </para>
        /// <para>
        /// When a pointer is aborted, <see cref="POINTER_FLAG_CANCELED"/> is set.
        /// </para>
        /// <para>
        /// A <see cref="WM_POINTERLEAVE"/> message may also be generated
        /// when a non-captured pointer moves outside the bounds of a window.
        /// </para>
        /// <para>
        /// To obtain the horizontal and vertical position of a pointer, use the following:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// To convert the lParam parameter to a <see cref="POINTS"/>) structure, use the <see cref="MAKEPOINTS"/> macro.
        /// </para>
        /// <para>
        /// To retrieve further information associated with the message, use the <see cref="GetPointerInfo"/> function.
        /// </para>
        /// <para>
        /// To determine the keyboard modifier key states associated with this message, use the <see cref="GetKeyState"/> function.
        /// For example, to detect that the ALT key was pressed, check whether GetKeyState(VK_MENU) &lt; 0.
        /// </para>
        /// <para>
        /// Note that if the application does not process this message,
        /// <see cref="DefWindowProc"/> may generate one or more <see cref="WM_GESTURE"/> messages
        /// if the sequence of input from this and, possibly, other pointers is recognized as a gesture.
        /// If a gesture is not recognized, <see cref="DefWindowProc"/> may generate mouse input.
        /// </para>
        /// <para>
        /// If an application selectively consumes some pointer input and passes the rest to <see cref="DefWindowProc"/>,
        /// the resulting behavior is undefined.
        /// </para>
        /// <para>
        /// When a window loses capture of a pointer and receives the <see cref="WM_POINTERCAPTURECHANGED"/> notification,
        /// it will typically not receive any further notifications.
        /// Therefore, it is important that a window does not make any assumptions of its pointer status,
        /// regardless of whether it receives evenly paired DOWN / UP or ENTER / LEAVE notifications.
        /// </para>
        /// </remarks>
        WM_POINTERDOWN = 0x0246,

        /// <summary>
        /// <para>
        /// Sent to a window when a new pointer enters detection range over the window (hover)
        /// or when an existing pointer moves within the boundaries of the window.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains the pointer identifier and additional information.
        /// Use the following macros to retrieve specific information in the wParam parameter.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_POINTERID_WPARAM"/>(wParam):
        /// the pointer identifier.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_NEW_WPARAM"/>(wParam):
        /// indicates whether this message is the first message generated by a new pointer entering detection range (hover).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_INRANGE_WPARAM"/>(wParam):
        /// indicates whether this message was generated by a pointer that has not left detection range.
        /// This flag is always set for <see cref="WM_POINTERENTER"/> messages.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_INCONTACT_WPARAM"/>(wParam):
        /// a flag that indicates whether this message was generated by a pointer that is in contact.
        /// This flag is not set for a pointer in detection range (hover).
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains the point location of the pointer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Because the pointer may make contact with the device over a non-trivial area,
        /// this point location may be a simplification of a more complex pointer area.
        /// Whenever possible, an application should use the complete pointer area information instead of the point location.
        /// </para>
        /// <para>
        /// Use the following macros to retrieve the physical screen coordinates of the point.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_X_LPARAM"/>(lParam): the x (horizontal point) coordinate.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GET_Y_LPARAM"/>(lParam): the y (vertical point) coordinate.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerenter"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="WM_POINTERENTER"/> notification can be used by a window to provide feedback to the user
        /// while the pointer is over its surface or to otherwise react to the presence of a pointer over its surface.
        /// </para>
        /// <para>
        /// This notification is only sent to the window that is receiving input for the pointer.
        /// The following table lists some of the situations in which this notification is sent.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Action
        /// </term>
        /// <term>
        /// Flags Set
        /// </term>
        /// <term>
        /// Notifications Sent To
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// A new pointer enters detection range (hover).
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="IS_POINTER_NEW_WPARAM"/>
        /// </para>
        /// <para>
        /// <see cref="IS_POINTER_INRANGE_WPARAM"/>
        /// </para>
        /// </term>
        /// <term>
        /// Window over which the pointer enters detection range.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// A hovering pointer crosses within the window boundaries.
        /// </term>
        /// <term>
        /// <see cref="IS_POINTER_INRANGE_WPARAM"/>
        /// </term>
        /// <term>
        /// Window within which the pointer has crossed.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// When a window loses capture of a pointer and it receives the <see cref="WM_POINTERCAPTURECHANGED"/> notification,
        /// it typically will not receive any further notifications.
        /// For this reason, it is important that you not make any assumptions based on evenly paired
        /// <see cref="WM_POINTERDOWN"/>/<see cref="WM_POINTERUP"/> or <see cref="WM_POINTERENTER"/>/<see cref="WM_POINTERLEAVE"/> notifications.
        /// </para>
        /// <para>
        /// When inputs come from the mouse, as a result of mouse and pointer message integration, <see cref="WM_POINTERENTER"/> is not sent.
        /// </para>
        /// </remarks>
        WM_POINTERENTER = 0x0249,

        /// <summary>
        /// <para>
        /// Sent to a window when a pointer leaves detection range over the window (hover)
        /// or when a pointer moves outside the boundaries of the window.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains the pointer identifier and additional information.
        /// Use the following macros to retrieve this information.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_POINTERID_WPARAM"/>(wParam):
        /// the pointer identifier.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_INRANGE_WPARAM"/>(wParam):
        /// indicates whether this message was generated by a pointer that has not left detection range.
        /// This flag is not set when the pointer leaves the detection range of the window.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_INCONTACT_WPARAM"/>(wParam):
        /// a flag that indicates whether this message was generated by a pointer that is in contact.
        /// This flag is not set for a pointer in detection range (hover).
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains the point location of the pointer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Because the pointer may make contact with the device over a non-trivial area,
        /// this point location may be a simplification of a more complex pointer area.
        /// Whenever possible, an application should use the complete pointer area information instead of the point location.
        /// </para>
        /// <para>
        /// Use the following macros to retrieve the physical screen coordinates of the point.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_X_LPARAM"/>(lParam): the x (horizontal point) coordinate.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GET_Y_LPARAM"/>(lParam): the y (vertical point) coordinate.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerleave"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="WM_POINTERLEAVE"/> notification can be used by a window
        /// to change mode or stop any feedback to the user while the pointer is over the window surface.
        /// </para>
        /// <para>
        /// This notification is only sent to the window that is receiving input for the pointer.
        /// The following table lists some of the situations in which this notification is sent.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Action
        /// </term>
        /// <term>
        /// Flags Set
        /// </term>
        /// <term>
        /// Notifications Sent To
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// A hovering pointer crosses window boundaries.
        /// </term>
        /// <term>
        /// <see cref="IS_POINTER_INRANGE_WPARAM"/>
        /// </term>
        /// <term>
        /// Window outside of whose boundary the pointer moved.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// A pointer goes out of detection range.
        /// </term>
        /// <term>
        /// N/A
        /// </term>
        /// <term>
        /// Window for which the pointer leaves detection range.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// When a window loses capture of a pointer and it receives the <see cref="WM_POINTERCAPTURECHANGED"/> notification,
        /// it typically will not receive any further notifications.
        /// For this reason, it is important that you not make any assumptions based on evenly paired
        /// <see cref="WM_POINTERDOWN"/>/<see cref="WM_POINTERUP"/> or <see cref="WM_POINTERENTER"/>/<see cref="WM_POINTERLEAVE"/> notifications.
        /// </para>
        /// <para>
        /// If contact is maintained with the input digitizer and the pointer moves outside the window,
        /// <see cref="WM_POINTERLEAVE"/> is not generated.
        /// <see cref="WM_POINTERLEAVE"/> is generated only when a hovering pointer crosses window boundaries or contact is terminated.
        /// </para>
        /// <para>
        /// <see cref="WM_POINTERLEAVE"/> is posted to the posted message queue if the input is originated from a mouse device.
        /// </para>
        /// </remarks>
        WM_POINTERLEAVE = 0x024A,

        /// <summary>
        /// <para>
        /// Occurs on the process receiving input when the pointer input is routed to another process.
        /// </para>
        /// <para>
        /// Sent when pointer input transitions from one process to another across content configured
        /// for cross-process chaining (<see cref="IDirectManipulationCompositor2.AddContentWithCrossProcessChaining"/>).
        /// </para>
        /// <para>
        /// This message is sent to the process currently receiving pointer input.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Unused.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Unused.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// <see cref="NULL"/>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerroutedaway"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// This message is not sent with either a <see cref="WM_POINTERUP"/> message or a <see cref="WM_POINTERCAPTURECHANGED"/> message.
        /// </remarks>
        WM_POINTERROUTEDAWAY = 0x0252,

        /// <summary>
        /// <para>
        /// Sent to all processes (configured for cross-process chaining
        /// through <see cref="IDirectManipulationCompositor2.AddContentWithCrossProcessChaining"/> and not currently handling pointer input)
        /// ever associated with a specific pointer ID, when a <see cref="WM_POINTERUP"/> message is received on the current process.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Unused.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Unused.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// <see cref="NULL"/>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerroutedreleased"/>
        /// </para>
        /// </summary>
        WM_POINTERROUTEDRELEASED = 0x0253,

        /// <summary>
        /// <para>
        /// Sent when ongoing pointer input, for an existing pointer ID,
        /// transitions from one process to another across content configured for cross-process chaining
        /// (<see cref="IDirectManipulationCompositor2.AddContentWithCrossProcessChaining"/>).
        /// </para>
        /// <para>
        /// This message is sent to the process not currently receiving pointer input.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Unused.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Unused.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// <see cref="NULL"/>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerroutedto"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message is not sent when a <see cref="WM_POINTERDOWN"/> message is posted for a new pointer ID on a different process.
        /// </para>
        /// <para>
        /// A <see cref="WM_POINTERDOWN"/> message is not sent if a <see cref="WM_POINTERROUTEDTO"/> message is posted first.
        /// </para>
        /// </remarks>
        WM_POINTERROUTEDTO = 0x0251,

        /// <summary>
        /// <para>
        /// Posted when a pointer that made contact over the client area of a window breaks contact.
        /// This input message targets the window over which the pointer makes contact and the pointer is,
        /// at that point, implicitly captured to the window so that the window continues to receive input messages
        /// including the <see cref="WM_POINTERUP"/> notification for the pointer until it breaks contact.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains information about the pointer.
        /// Use the following macros to retrieve information from the wParam parameter.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_POINTERID_WPARAM"/>(wParam):
        /// the pointer identifier.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_NEW_WPARAM"/>(wParam):
        /// a flag that indicates whether this message represents the first input generated by a new pointer.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_INRANGE_WPARAM"/>(wParam):
        /// a flag that indicates whether this message was generated by a pointer during its lifetime.
        /// This flag is not set on messages that indicate that the pointer has left detection range
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_INCONTACT_WPARAM"/>(wParam):
        /// a flag that indicates whether this message was generated by a pointer that is in contact with the window surface.
        /// This flag is not set on messages that indicate a hovering pointer.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_PRIMARY_WPARAM"/>(wParam):
        /// indicates that this pointer has been designated as primary.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="IS_POINTER_FIRSTBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether there is a primary action.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This is analogous to a mouse left button down.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A touch pointer will have this set when it is in contact with the digitizer surface.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A pen pointer will have this set when it is in contact with the digitizer surface with no buttons pressed.
        /// </description>
        /// </item>
        /// </list>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="IS_POINTER_SECONDBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether there is a secondary action.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This is analogous to a mouse right button down.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A pen pointer will have this set when it is in contact with the digitizer surface with the pen barrel button pressed.
        /// </description>
        /// </item>
        /// </list>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_THIRDBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether there are one or more tertiary actions based on the pointer type;
        /// applications that wish to respond to tertiary actions must retrieve information
        /// specific to the pointer type to determine which tertiary buttons are pressed.
        /// For example, an application can determine the buttons states of a pen
        /// by calling <see cref="GetPointerPenInfo"/> and examining the flags that specify button states.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_FOURTHBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether the specified pointer took fourth action.
        /// Applications that wish to respond to fourth actions must retrieve information
        /// specific to the pointer type to determine if the first extended mouse (XButton1) button is pressed.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="IS_POINTER_FIFTHBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether the specified pointer took fifth action.
        /// Applications that wish to respond to fifth actions must retrieve information
        /// specific to the pointer type to determine if the second extended mouse (XButton2) button is pressed.
        /// </para>
        /// <para>
        /// See Pointer Flags for more details.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// A hovering pointer has none of the button flags set.
        /// This is analogous to a mouse move with no mouse buttons down.
        /// An application can determine the buttons states of a hovering pen, for example,
        /// by calling <see cref="GetPointerPenInfo"/> and examining the flags that specify button states.
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains the point location of the pointer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Because the pointer may make contact with the device over a non-trivial area,
        /// this point location may be a simplification of a more complex pointer area.
        /// Whenever possible, an application should use the complete pointer area information instead of the point location.
        /// </para>
        /// <para>
        /// Use the following macros to retrieve the physical screen coordinates of the point.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_X_LPARAM"/>(lParam): the x (horizontal point) coordinate.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GET_Y_LPARAM"/>(lParam): the y (vertical point) coordinate.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerup"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// When a window loses capture of a pointer and it receives the <see cref="WM_POINTERCAPTURECHANGED"/> notification,
        /// it typically will not receive any further notifications.
        /// For this reason, it is important that you not make any assumptions based on evenly paired
        /// <see cref="WM_POINTERDOWN"/>/<see cref="WM_POINTERUP"/> or <see cref="WM_POINTERENTER"/>/<see cref="WM_POINTERLEAVE"/> notifications.
        /// </para>
        /// <para>
        /// Each pointer has a unique pointer identifier during its lifetime.
        /// The lifetime of a pointer begins when it is first detected.
        /// </para>
        /// <para>
        /// A <see cref="WM_POINTERENTER"/> message is generated if a hovering pointer is detected.
        /// A <see cref="WM_POINTERDOWN"/> message followed by a <see cref="WM_POINTERENTER"/> message is generated if a non-hovering pointer is detected.
        /// </para>
        /// <para>
        /// During its lifetime, a pointer may generate a series of <see cref="WM_POINTERUPDATE"/> messages while it is hovering or in contact.
        /// </para>
        /// <para>
        /// The lifetime of a pointer ends when it is no longer detected.
        /// This generates a <see cref="WM_POINTERLEAVE"/> message.
        /// </para>
        /// <para>
        /// When a pointer is aborted, <see cref="POINTER_FLAG_CANCELED"/> is set.
        /// </para>
        /// <para>
        /// A <see cref="WM_POINTERLEAVE"/> message may also be generated when a non-captured pointer moves outside the bounds of a window.
        /// </para>
        /// <para>
        /// To obtain the horizontal and vertical position of a pointer, use the following:
        /// </para>
        /// <para>
        /// Use the following code to obtain the horizontal and vertical position:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// The <see cref="MAKEPOINTS"/> macro can also be used to convert the lParam parameter to a <see cref="POINTS"/> structure.
        /// </para>
        /// <para>
        /// The <see cref="GetKeyState"/> function can be used to determine the keyboard modifier key states associated with this message.
        /// For example, to detect that the ALT key was pressed, check whether <see cref="GetKeyState"/>(VK_MENU) &lt; 0.
        /// </para>
        /// <para>
        /// If the application does not process this message,
        /// <see cref="DefWindowProc"/> may generate one or more <see cref="WM_GESTURE"/> messages
        /// if the sequence of input from this and, possibly, other pointers is recognized as a gesture.
        /// If a gesture is not recognized, <see cref="DefWindowProc"/> may generate mouse input.
        /// </para>
        /// <para>
        /// If an application selectively consumes some pointer input and passes the rest to <see cref="DefWindowProc"/>,
        /// the resulting behavior is undefined.
        /// </para>
        /// <para>
        /// Use the <see cref="GetPointerInfo"/> function to retrieve further information related to this message.
        /// </para>
        /// </remarks>
        WM_POINTERUP = 0x0247,

        /// <summary>
        /// <para>
        /// Posted to provide an update on a pointer that made contact over the client area of a window
        /// or on a hovering uncaptured pointer over the client area of a window.
        /// While the pointer is hovering, the message targets whichever window the pointer happens to be over.
        /// While the pointer is in contact with the surface
        /// , the pointer is implicitly captured to the window over which the pointer made contact
        /// and that window continues to receive input for the pointer until it breaks contact.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains information about the pointer.
        /// Use the following macros to retrieve information from the wParam parameter.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_POINTERID_WPARAM"/>(wParam):
        /// the pointer identifier.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_NEW_WPARAM"/>(wParam):
        /// a flag that indicates whether this message represents the first input generated by a new pointer.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_INRANGE_WPARAM"/>(wParam):
        /// a flag that indicates whether this message was generated by a pointer during its lifetime.
        /// This flag is not set on messages that indicate that the pointer has left detection range
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_INCONTACT_WPARAM"/>(wParam):
        /// a flag that indicates whether this message was generated by a pointer that is in contact with the window surface.
        /// This flag is not set on messages that indicate a hovering pointer.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_PRIMARY_WPARAM"/>(wParam):
        /// indicates that this pointer has been designated as primary.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="IS_POINTER_FIRSTBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether there is a primary action.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This is analogous to a mouse left button down.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A touch pointer will have this set when it is in contact with the digitizer surface.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A pen pointer will have this set when it is in contact with the digitizer surface with no buttons pressed.
        /// </description>
        /// </item>
        /// </list>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="IS_POINTER_SECONDBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether there is a secondary action.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This is analogous to a mouse right button down.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A pen pointer will have this set when it is in contact with the digitizer surface with the pen barrel button pressed.
        /// </description>
        /// </item>
        /// </list>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_THIRDBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether there are one or more tertiary actions based on the pointer type;
        /// applications that wish to respond to tertiary actions must retrieve information
        /// specific to the pointer type to determine which tertiary buttons are pressed.
        /// For example, an application can determine the buttons states of a pen
        /// by calling <see cref="GetPointerPenInfo"/> and examining the flags that specify button states.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IS_POINTER_FOURTHBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether the specified pointer took fourth action.
        /// Applications that wish to respond to fourth actions must retrieve information 
        /// specific to the pointer type to determine if the first extended mouse (XButton1) button is pressed.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="IS_POINTER_FIFTHBUTTON_WPARAM"/>(wParam):
        /// a flag that indicates whether the specified pointer took fifth action.
        /// Applications that wish to respond to fifth actions must retrieve information
        /// specific to the pointer type to determine if the second extended mouse (XButton2) button is pressed.
        /// </para>
        /// <para>
        /// See Pointer Flags for more details.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// A hovering pointer has none of the button flags set.
        /// This is analogous to a mouse move with no mouse buttons down.
        /// An application can determine the buttons states of a hovering pen, for example,
        /// by calling <see cref="GetPointerPenInfo"/> and examining the flags that specify button states.
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains the point location of the pointer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Because the pointer may make contact with the device over a non-trivial area,
        /// this point location may be a simplification of a more complex pointer area.
        /// Whenever possible, an application should use the complete pointer area information instead of the point location.
        /// </para>
        /// <para>
        /// Use the following macros to retrieve the physical screen coordinates of the point.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_X_LPARAM"/>(lParam): the x (horizontal point) coordinate.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GET_Y_LPARAM"/>(lParam): the y (vertical point) coordinate.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerupdate"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Each pointer has a unique pointer identifier during its lifetime.
        /// The lifetime of a pointer begins when it is first detected.
        /// </para>
        /// <para>
        /// A <see cref="WM_POINTERENTER"/> message is generated if a hovering pointer is detected.
        /// A <see cref="WM_POINTERDOWN"/> message followed by a <see cref="WM_POINTERENTER"/> message
        /// is generated if a non-hovering pointer is detected.
        /// </para>
        /// <para>
        /// During its lifetime, a pointer may generate a series of <see cref="WM_POINTERUPDATE"/> messages while it is hovering or in contact.
        /// </para>
        /// <para>
        /// The lifetime of a pointer ends when it is no longer detected.
        /// This generates a <see cref="WM_POINTERLEAVE"/> message.
        /// </para>
        /// <para>
        /// When a pointer is aborted, <see cref="POINTER_FLAG_CANCELED"/> is set.
        /// </para>
        /// <para>
        /// A <see cref="WM_POINTERLEAVE"/> message may also be generated when a non-captured pointer moves outside the bounds of a window.
        /// </para>
        /// <para>
        /// To obtain the horizontal and vertical position of a pointer, use the following:
        /// </para>
        /// <code>
        /// xPos = GET_X_LPARAM(lParam); 
        /// yPos = GET_Y_LPARAM(lParam);
        /// </code>
        /// <para>
        /// The <see cref="MAKEPOINTS"/> macro can also be used to convert the lParam parameter to a <see cref="POINTS"/> structure.
        /// </para>
        /// <para>
        /// The <see cref="GetKeyState"/> function can be used to determine the keyboard modifier key states associated with this message.
        /// For example, to detect that the ALT key was pressed, check whether <see cref="GetKeyState"/> (VK_MENU) &lt; 0.
        /// </para>
        /// <para>
        /// If the application does not process this message,
        /// <see cref="DefWindowProc"/> may generate one or more <see cref="WM_GESTURE"/> messages
        /// if the sequence of input from this and, possibly, other pointers is recognized as a gesture.
        /// If a gesture is not recognized, <see cref="DefWindowProc"/> may generate mouse input.
        /// </para>
        /// <para>
        /// If an application selectively consumes some pointer input and passes the rest to <see cref="DefWindowProc"/>,
        /// the resulting behavior is undefined.
        /// </para>
        /// <para>
        /// Use the <see cref="GetPointerInfo"/> function to retrieve further information related to this message.
        /// </para>
        /// <para>
        /// If the application does not process these messages as fast as they are generated, some moves may be coalesced.
        /// The history of inputs that were coalesced into this message can be retrieved using the <see cref="GetPointerInfoHistory"/> function.
        /// </para>
        /// </remarks>
        WM_POINTERUPDATE = 0x0245,

        /// <summary>
        /// <para>
        /// Posted to the window with foreground keyboard focus when a scroll wheel is rotated.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains the pointer identifier and wheel delta. Use the following macros to retrieve this information.
        /// </para>
        /// <para>
        /// <see cref="GET_POINTERID_WPARAM"/>(wParam): pointer identifier.
        /// </para>
        /// <para>
        /// <see cref="GET_WHEEL_DELTA_WPARAM"/>(wParam): wheel delta as a signed short value.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains the point location of the pointer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Because the pointer may make contact with the device over a non-trivial area,
        /// this point location may be a simplification of a more complex pointer area.
        /// Whenever possible, an application should use the complete pointer area information instead of the point location.
        /// </para>
        /// <para>
        /// Use the following macros to retrieve the physical screen coordinates of the point.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_X_LPARAM"/>(lParam): the x (horizontal point) coordinate.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GET_Y_LPARAM"/>(lParam): the y (vertical point) coordinate.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerwheel"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// To retrieve the wheel scroll units, use the <see cref="POINTER_INFO.InputData"/> filed
        /// of the <see cref="POINTER_INFO"/> structure returned by calling <see cref="GetPointerInfo"/> function.
        /// This field contains a signed value and is expressed in a multiple of <see cref="WHEEL_DELTA"/>.
        /// A positive value indicates a rotation forward and a negative value indicates a rotation backward.
        /// </para>
        /// <para>
        /// Note that the wheel inputs may be delivered even if the mouse cursor is located outside of application s window.
        /// The wheel messages are delivered in a way very similar to the keyboard inputs.
        /// The focus window of the foreground message queue receives the wheel messages.
        /// </para>
        /// </remarks>
        WM_POINTERWHEEL = 0x024E,

        /// <summary>
        /// <para>
        /// Posted to the window with foreground keyboard focus when a horizontal scroll wheel is rotated.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Contains the pointer identifier and wheel delta. Use the following macros to retrieve this information.
        /// </para>
        /// <para>
        /// <see cref="GET_POINTERID_WPARAM"/>(wParam): pointer identifier.
        /// </para>
        /// <para>
        /// <see cref="GET_WHEEL_DELTA_WPARAM"/>(wParam): wheel delta as signed short value.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains the point location of the pointer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Because the pointer may make contact with the device over a non-trivial area,
        /// this point location may be a simplification of a more complex pointer area.
        /// Whenever possible, an application should use the complete pointer area information instead of the point location.
        /// </para>
        /// <para>
        /// Use the following macros to retrieve the physical screen coordinates of the point.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GET_X_LPARAM"/>(lParam): the x (horizontal point) coordinate.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GET_Y_LPARAM"/>(lParam): the y (vertical point) coordinate.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process this message, it should call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerhwheel"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// To retrieve the wheel scroll units, use the <see cref="POINTER_INFO.InputData"/> filed
        /// of the <see cref="POINTER_INFO"/> structure returned by calling <see cref="GetPointerInfo"/> function.
        /// This field contains a signed value and is expressed in a multiple of <see cref="WHEEL_DELTA"/>.
        /// A positive value indicates a rotation forward and a negative value indicates a rotation backward.
        /// </para>
        /// <para>
        /// Note that the wheel inputs may be delivered even if the mouse cursor is located outside of application s window.
        /// The wheel messages are delivered in a way very similar to the keyboard inputs.
        /// The focus window of the foreground message queue receives the wheel messages.
        /// </para>
        /// </remarks>
        WM_POINTERHWHEEL = 0x024F,

        /// <summary>
        /// <para>
        /// Sent to a window on a touch down in order to determine the most probable touch target.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// Desktop apps should be DPI aware.
        /// If your app is not DPI aware, screen coordinates contained in pointer messages and related structures
        /// might appear inaccurate due to DPI virtualization.
        /// DPI virtualization provides automatic scaling support to applications
        /// that are not DPI aware and is active by default (users can turn it off).
        /// For more information, see Writing High-DPI Win32 Applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Unused.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Pointer to the <see cref="TOUCH_HIT_TESTING_INPUT"/> structure that holds the touch contact area data.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If one or more elements are within the touch contact area,
        /// an application should return the result of <see cref="PackTouchHitTestingProximityEvaluation"/>.
        /// </para>
        /// <para>
        /// If no elements are within the touch contact area, an application should set the value of score
        /// in <see cref="TOUCH_HIT_TESTING_PROXIMITY_EVALUATION"/> to <see cref="TOUCH_HIT_TESTING_PROXIMITY_FARTHEST"/>
        /// and call <see cref="PackTouchHitTestingProximityEvaluation"/> to get the <see cref="LRESULT"/> return value.
        /// </para>
        /// <para>
        /// If the application does not process this message, it must call <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-touchhittesting"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// This message is sent to windows that register through the <see cref="RegisterTouchHitTestingWindow"/> function.
        /// </remarks>
        WM_TOUCHHITTESTING = 0x024D,

        #endregion

        #region Power Management

        /// <summary>
        /// <para>
        /// Notifies applications that the system, typically a battery-powered personal computer, is about to enter a suspended mode.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The <see cref="WM_POWER"/> message is obsolete.
        /// It is provided only for compatibility with 16-bit Windows-based applications.
        /// Applications should use the <see cref="WM_POWERBROADCAST"/> message.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The power-event notification.
        /// This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PWR_CRITICALRESUME"/>
        /// </term>
        /// <term>
        /// Indicates that the system is resuming operation after entering suspended mode
        /// without first broadcasting a <see cref="PWR_SUSPENDREQUEST"/> notification message to the application.
        /// An application should perform any necessary recovery actions.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PWR_SUSPENDREQUEST"/>
        /// </term>
        /// <term>
        /// Indicates that the system is about to enter suspended mode.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PWR_SUSPENDRESUME"/>
        /// </term>
        /// <term>
        /// Indicates that the system is resuming operation after having entered suspended mode normally that is
        /// , the system broadcast a <see cref="PWR_SUSPENDREQUEST"/> notification message to the application before the system was suspended.
        /// An application should perform any necessary recovery actions.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The value an application returns depends on the value of the wParam parameter.
        /// If wParam is <see cref="PWR_SUSPENDREQUEST"/>, the return value is <see cref="PWR_FAIL"/> to prevent the system from entering the suspended state;
        /// otherwise, it is <see cref="PWR_OK"/>.
        /// If wParam is <see cref="PWR_SUSPENDRESUME"/> or <see cref="PWR_CRITICALRESUME"/>, the return value is zero.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/power/wm-power"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message is broadcast only to an application that is running on a system
        /// that conforms to the Advanced Power Management (APM) basic input/output system (BIOS) specification.
        /// The message is broadcast by the power-management driver to each window returned by the <see cref="EnumWindows"/> function.
        /// </para>
        /// <para>
        /// The suspended mode is the state in which the greatest amount of power savings occurs, but all operational data and parameters are preserved.
        /// Random-access memory (RAM) contents are preserved, but many devices are likely to be turned off.
        /// </para>
        /// </remarks>
        WM_POWER = 0x0048,

        /// <summary>
        /// <para>
        /// Notifies applications that a power-management event has occurred.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The power-management event. This parameter can be one of the following event identifiers.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Event
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PBT_APMPOWERSTATUSCHANGE"/>
        /// </para>
        /// <para>
        /// 10 (0xA)
        /// </para>
        /// </term>
        /// <term>
        /// Power status has changed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PBT_APMRESUMEAUTOMATIC"/>
        /// </para>
        /// <para>
        /// 18 (0x12)
        /// </para>
        /// </term>
        /// <term>
        /// Operation is resuming automatically from a low-power state.
        /// This message is sent every time the system resumes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PBT_APMRESUMESUSPEND"/>
        /// </para>
        /// <para>
        /// 7 (0x7)
        /// </para>
        /// </term>
        /// <term>
        /// Operation is resuming from a low-power state.
        /// This message is sent after <see cref="PBT_APMRESUMEAUTOMATIC"/> if the resume is triggered by user input, such as pressing a key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PBT_APMSUSPEND"/>
        /// </para>
        /// <para>
        /// 4 (0x4)
        /// </para>
        /// </term>
        /// <term>
        /// System is suspending operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PBT_POWERSETTINGCHANGE"/>
        /// </para>
        /// <para>
        /// 32787 (0x8013)
        /// </para>
        /// </term>
        /// <term>
        /// A power setting change event has been received.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The event-specific data. For most events, this parameter is reserved and not used.
        /// </para>
        /// <para>
        /// If the wParam parameter is <see cref="PBT_POWERSETTINGCHANGE"/>,
        /// the lParam parameter is a pointer to a <see cref="POWERBROADCAST_SETTING"/> structure.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return <see cref="TRUE"/> if it processes this message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/power/wm-powerbroadcast"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The system always sends a <see cref="PBT_APMRESUMEAUTOMATIC"/> message whenever the system resumes.
        /// If the system resumes in response to user input such as pressing a key,
        /// the system also sends a <see cref="PBT_APMRESUMESUSPEND"/> message after sending <see cref="PBT_APMRESUMEAUTOMATIC"/>.
        /// </para>
        /// <para>
        /// <see cref="WM_POWERBROADCAST"/> messages do not distinguish between different low-power states.
        /// An application can determine only that the system is entering or has resumed from a low-power state;
        /// it cannot determine the specific power state.
        /// The system records details about power state transitions in the Windows System event log.
        /// </para>
        /// <para>
        /// To prevent the system from transitioning to a low-power state in Windows Vista,
        /// an application must call <see cref="SetThreadExecutionState"/> to inform the system that it is in use.
        /// </para>
        /// <para>
        /// The following messages are not supported on any of the operating systems specified in the Requirements section:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="PBT_APMQUERYSTANDBY"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PBT_APMQUERYSTANDBYFAILED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PBT_APMSTANDBY"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="PBT_APMRESUMESTANDBY"/>
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        WM_POWERBROADCAST = 0x0218,

        #endregion

        #region Raw Input Notifications

        /// <summary>
        /// <para>
        /// Sent to the window that is getting raw input.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The input code. Use <see cref="GET_RAWINPUT_CODE_WPARAM"/> macro to get the value.
        /// </para>
        /// <para>
        /// Can be one of the following values:
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RIM_INPUT"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Input occurred while the application was in the foreground.
        /// </para>
        /// <para>
        /// The application must call <see cref="DefWindowProc"/> so the system can perform cleanup.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RIM_INPUTSINK"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Input occurred while the application was not in the foreground.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A <see cref="HRAWINPUT"/> handle to the <see cref="RAWINPUT"/> structure that contains the raw input from the device.
        /// To get the raw data, use this handle in the call to <see cref="GetRawInputData"/>.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Raw input is available only when the application calls <see cref="RegisterRawInputDevices"/> with valid device specifications.
        /// </remarks>
        WM_INPUT = 0x00FF,

        /// <summary>
        /// <para>
        /// Sent to the window that registered to receive raw input.
        /// </para>
        /// <para>
        /// Raw input notifications are available only after the application calls <see cref="RegisterRawInputDevices"/> with <see cref="RIDEV_DEVNOTIFY"/> flag.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GIDC_ARRIVAL"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// A new device has been added to the system.
        /// </para>
        /// <para>
        /// You can call <see cref="GetRawInputDeviceInfo"/> to get more information regarding the device.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GIDC_REMOVAL"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// A device has been removed from the system.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The <see cref="HANDLE"/> to the raw input device.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        WM_INPUT_DEVICE_CHANGE = 0x00FE,

        #endregion

        #region Scroll Bar Notifications

        /// <summary>
        /// <para>
        /// The <see cref="WM_CTLCOLORSCROLLBAR"/> message is sent to the parent window
        /// of a scroll bar control when the control is about to be drawn.
        /// By responding to this message, the parent window can use the display context handle
        /// to set the background color of the scroll bar control.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Handle to the device context for the scroll bar control.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Handle to the scroll bar.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it must return the handle to a brush.
        /// The system uses the brush to paint the background of the scroll bar control.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the application returns a brush that it created
        /// (for example, by using the <see cref="CreateSolidBrush"/> or <see cref="CreateBrushIndirect"/> function),
        /// the application must free the brush.
        /// If the application returns a system brush
        /// (for example, one that was retrieved by the <see cref="GetStockObject"/> or <see cref="GetSysColorBrush"/> function),
        /// the application does not need to free the brush.
        /// </para>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function selects the default system colors for the scroll bar control.
        /// </para>
        /// <para>
        /// The <see cref="WM_CTLCOLORSCROLLBAR"/> message is never sent between threads; it is only sent within the same thread.
        /// </para>
        /// <para>
        /// If a dialog box procedure handles this message,
        /// it should cast the desired return value to a <see cref="INT_PTR"/> and return the value directly.
        /// If the dialog box procedure returns <see cref="FALSE"/>, then default message handling is performed.
        /// The <see cref="DWL_MSGRESULT"/> value set by the <see cref="SetWindowLong"/> function is ignored.
        /// </para>
        /// <para>
        /// The <see cref="WM_CTLCOLORSCROLLBAR"/> message is used only by child scroll bar controls.
        /// Scrollbars attached to a window (WS_SCROLL and WS_VSCROLL) do not generate this message.
        /// To customize the appearance of scrollbars attached to a window, use the flat scroll bar functions.
        /// </para>
        /// </remarks>
        WM_CTLCOLORSCROLLBAR = 0x0137,

        /// <summary>
        /// <para>
        /// The <see cref="WM_HSCROLL"/> message is sent to a window when a scroll event occurs in the window's standard horizontal scroll bar.
        /// This message is also sent to the owner of a horizontal scroll bar control when a scroll event occurs in the control.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The <see cref="HIWORD"/> specifies the current position of the scroll box
        /// if the <see cref="LOWORD"/> is <see cref="SB_THUMBPOSITION"/> or <see cref="SB_THUMBTRACK"/>;
        /// otherwise, this word is not used.
        /// </para>
        /// <para>
        /// The <see cref="LOWORD"/> specifies a scroll bar value that indicates the user's scrolling request.
        /// This word can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="SB_ENDSCROLL"/>
        /// </term>
        /// <term>
        /// Ends scroll.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_LEFT"/>
        /// </term>
        /// <term>
        /// Scrolls to the upper left.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_RIGHT"/>
        /// </term>
        /// <term>
        /// Scrolls to the lower right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_LINELEFT"/>
        /// </term>
        /// <term>
        /// Scrolls left by one unit.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_LINERIGHT"/>
        /// </term>
        /// <term>
        /// Scrolls right by one unit.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_PAGELEFT"/>
        /// </term>
        /// <term>
        /// Scrolls left by the width of the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_PAGERIGHT"/>
        /// </term>
        /// <term>
        /// Scrolls right by the width of the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_THUMBPOSITION"/>
        /// </term>
        /// <term>
        /// The user has dragged the scroll box (thumb) and released the mouse button.
        /// The <see cref="HIWORD"/> indicates the position of the scroll box at the end of the drag operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_THUMBTRACK"/>
        /// </term>
        /// <term>
        /// The user is dragging the scroll box. This message is sent repeatedly until the user releases the mouse button.
        /// The <see cref="HIWORD"/> indicates the position that the scroll box has been dragged to.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// If the message is sent by a scroll bar control, this parameter is the handle to the scroll bar control.
        /// If the message is sent by a standard scroll bar, this parameter is <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="SB_THUMBTRACK"/> request code is typically used by applications that provide feedback as the user drags the scroll box.
        /// </para>
        /// <para>
        /// If an application scrolls the content of the window,
        /// it must also reset the position of the scroll box by using the <see cref="SetScrollPos"/> function.
        /// </para>
        /// <para>
        /// Note that the <see cref="WM_HSCROLL"/> message carries only 16 bits of scroll box position data.
        /// Thus, applications that rely solely on <see cref="WM_HSCROLL"/> (and <see cref="WM_VSCROLL"/>)
        /// for scroll position data have a practical maximum position value of 65,535.
        /// </para>
        /// <para>
        /// However, because the <see cref="SetScrollInfo"/>, <see cref="SetScrollPos"/>,
        /// <see cref="SetScrollRange"/>, <see cref="GetScrollInfo"/>, <see cref="GetScrollPos"/>,
        /// and <see cref="GetScrollRange"/> functions support 32-bit scroll bar position data,
        /// there is a way to circumvent the 16-bit barrier of the <see cref="WM_HSCROLL"/> and <see cref="WM_VSCROLL"/> messages.
        /// See <see cref="GetScrollInfo"/> for a description of the technique.
        /// </para>
        /// </remarks>
        WM_HSCROLL = 0x0114,

        /// <summary>
        /// <para>
        /// The <see cref="WM_VSCROLL"/> message is sent to a window when a scroll event occurs in the window's standard vertical scroll bar.
        /// This message is also sent to the owner of a vertical scroll bar control when a scroll event occurs in the control.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The <see cref="HIWORD"/> specifies the current position of the scroll box
        /// if the <see cref="LOWORD"/> is <see cref="SB_THUMBPOSITION"/> or <see cref="SB_THUMBTRACK"/>; otherwise, this word is not used.
        /// </para>
        /// <para>
        /// The <see cref="LOWORD"/> specifies a scroll bar value that indicates the user's scrolling request.
        /// This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="SB_BOTTOM"/>
        /// </term>
        /// <term>
        /// Scrolls to the lower right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_ENDSCROLL"/>
        /// </term>
        /// <term>
        /// Ends scroll.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_LINEDOWN"/>
        /// </term>
        /// <term>
        /// Scrolls one line down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_LINEUP"/>
        /// </term>
        /// <term>
        /// Scrolls one line up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_PAGEDOWN"/>
        /// </term>
        /// <term>
        /// Scrolls one page down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_PAGEUP"/>
        /// </term>
        /// <term>
        /// Scrolls one page up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_THUMBPOSITION"/>
        /// </term>
        /// <term>
        /// The user has dragged the scroll box (thumb) and released the mouse button.
        /// The <see cref="HIWORD"/> indicates the position of the scroll box at the end of the drag operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_THUMBTRACK"/>
        /// </term>
        /// <term>
        /// The user is dragging the scroll box. This message is sent repeatedly until the user releases the mouse button.
        /// The <see cref="HIWORD"/> indicates the position that the scroll box has been dragged to.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_TOP"/>
        /// </term>
        /// <term>
        /// Scrolls to the upper left.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// If the message is sent by a scroll bar control, this parameter is the handle to the scroll bar control.
        /// If the message is sent by a standard scroll bar, this parameter is <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="SB_THUMBTRACK"/> request code is typically used by applications that provide feedback as the user drags the scroll box.
        /// </para>
        /// <para>
        /// If an application scrolls the content of the window,
        /// it must also reset the position of the scroll box by using the <see cref="SetScrollPos"/> function.
        /// </para>
        /// <para>
        /// Note that the <see cref="WM_VSCROLL"/> message carries only 16 bits of scroll box position data.
        /// Thus, applications that rely solely on <see cref="WM_VSCROLL"/> (and <see cref="WM_HSCROLL"/>)
        /// for scroll position data have a practical maximum position value of 65,535.
        /// </para>
        /// <para>
        /// However, because the <see cref="SetScrollInfo"/>, <see cref="SetScrollPos"/>,
        /// <see cref="SetScrollRange"/>, <see cref="GetScrollInfo"/>, <see cref="GetScrollPos"/>,
        /// and <see cref="GetScrollRange"/> functions support 32-bit scroll bar position data,
        /// there is a way to circumvent the 16-bit barrier of the <see cref="WM_HSCROLL"/> and <see cref="WM_VSCROLL"/> messages.
        /// See <see cref="GetScrollInfo"/> for a description of the technique.
        /// </para>
        /// </remarks>
        WM_VSCROLL = 0x0115,

        #endregion

        #region Shell Messages and Notifications

        /// <summary>
        /// <para>
        /// Sent when the user drops a file on the window of an application that has registered itself as a recipient of dropped files.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to an internal structure describing the dropped files.
        /// Pass this handle <see cref="DragFinish"/>, <see cref="DragQueryFile"/>,
        /// or <see cref="DragQueryPoint"/> to retrieve information about the dropped files.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/shell/wm-dropfiles"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The <see cref="HDROP"/> handle is declared in Shellapi.h.
        /// You must include this header in your build to use <see cref="WM_DROPFILES"/>.
        /// For further discussion of how to use drag-and-drop to transfer Shell data,
        /// see Transferring Shell Data Using Drag-and-Drop or the Clipboard.
        /// </remarks>
        WM_DROPFILES = 0x0233,

        /// <summary>
        /// <para>
        /// Indicates that the user pressed the F1 key.
        /// If a menu is active when F1 is pressed, <see cref="WM_HELP"/> is sent to the window associated with the menu;
        /// otherwise, <see cref="WM_HELP"/> is sent to the window that has the keyboard focus.
        /// If no window has the keyboard focus, <see cref="WM_HELP"/> is sent to the currently active window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The address of a <see cref="HELPINFO"/> structure that contains information
        /// about the menu item, control, dialog box, or window for which Help is requested.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Returns <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/shell/wm-help"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The <see cref="DefWindowProc"/> function passes <see cref="WM_HELP"/>
        /// to the parent window of a child window or to the owner of a top-level window.
        /// </remarks>
        WM_HELP = 0x0053,

        /// <summary>
        /// <para>
        /// Sent to an application that has initiated a training card with Windows Help.
        /// The message informs the application when the user clicks an authorable button.
        /// An application initiates a training card by specifying the <see cref="HELP_TCARD"/> command in a call to the <see cref="WinHelp"/> function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A value that indicates the action the user has taken. This can be one of the following values.
        /// </para>
        /// <para>
        /// <see cref="IDABORT"/>
        /// </para>
        /// <para>
        /// The user clicked an authorable Abort button.
        /// </para>
        /// <para>
        /// <see cref="IDCANCEL"/>
        /// </para>
        /// <para>
        /// The user clicked an authorable Cancel button.
        /// </para>
        /// <para>
        /// <see cref="IDCLOSE"/>
        /// </para>
        /// <para>
        /// The user closed the training card.
        /// </para>
        /// <para>
        /// <see cref="IDHELP"/>
        /// </para>
        /// <para>
        /// The user clicked an authorable Windows Help button.
        /// </para>
        /// <para>
        /// <see cref="IDIGNORE"/>
        /// </para>
        /// <para>
        /// The user clicked an authorable Ignore button.
        /// </para>
        /// <para>
        /// <see cref="IDOK"/>
        /// </para>
        /// <para>
        /// The user clicked an authorable OK button.
        /// </para>
        /// <para>
        /// <see cref="IDNO"/>
        /// </para>
        /// <para>
        /// The user clicked an authorable No button.
        /// </para>
        /// <para>
        /// <see cref="IDRETRY"/>
        /// </para>
        /// <para>
        /// The user clicked an authorable Retry button.
        /// </para>
        /// <para>
        /// <see cref="HELP_TCARD_DATA"/>
        /// </para>
        /// <para>
        /// The user clicked an authorable button.
        /// The lParam parameter contains a long integer specified by the Help author.
        /// </para>
        /// <para>
        /// <see cref="HELP_TCARD_OTHER_CALLER"/>
        /// </para>
        /// <para>
        /// Another application has requested training cards.
        /// </para>
        /// <para>
        /// <see cref="IDYES"/>
        /// </para>
        /// <para>
        /// The user clicked an authorable Yes button.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// If wParam specifies <see cref="HELP_TCARD_DATA"/>, this parameter is a long specified by the Help author.
        /// Otherwise, this parameter is zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is ignored; use zero.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/shell/wm-tcard"/>
        /// </para>
        /// </summary>
        WM_TCARD = 0x0052,

        #endregion

        #region Static Control Notifications

        /// <summary>
        /// <para>
        /// A static control, or an edit control that is read-only or disabled,
        /// sends the <see cref="WM_CTLCOLORSTATIC"/> message to its parent window when the control is about to be drawn.
        /// By responding to this message, the parent window can use the specified device context handle
        /// to set the text foreground and background colors of the static control.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Handle to the device context for the static control window.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Handle to the static control.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message,
        /// the return value is a handle to a brush that the system uses to paint the background of the static control.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/wm-ctlcolorstatic"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the application returns a brush that it created
        /// (for example, by using the <see cref="CreateSolidBrush"/> or <see cref="CreateBrushIndirect"/> function),
        /// the application must free the brush.
        /// If the application returns a system brush
        /// (for example, one that was retrieved by the <see cref="GetStockObject"/> or <see cref="GetSysColorBrush"/> function),
        /// the application does not need to free the brush.
        /// </para>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function selects the default system colors for the static control.
        /// </para>
        /// <para>
        /// You can set the text background color of a disabled edit control, but you cannot set the text foreground color.
        /// The system always uses <see cref="COLOR_GRAYTEXT"/>.
        /// </para>
        /// <para>
        /// Edit controls that are not read-only or disabled do not send the <see cref="WM_CTLCOLORSTATIC"/> message;
        /// instead, they send the <see cref="WM_CTLCOLOREDIT"/> message.
        /// </para>
        /// <para>
        /// The <see cref="WM_CTLCOLORSTATIC"/> message is never sent between threads; it is sent only within the same thread.
        /// </para>
        /// <para>
        /// If a dialog box procedure handles this message, it should cast the desired return value to a <see cref="INT_PTR"/> and return the value directly.
        /// If the dialog box procedure returns <see cref="FALSE"/>, then default message handling is performed.
        /// The <see cref="DWL_MSGRESULT"/> value set by the <see cref="SetWindowLong"/> function is ignored.
        /// </para>
        /// </remarks>
        WM_CTLCOLORSTATIC = 0x0138,

        #endregion

        #region SystemParametersInfo Messages

        /// <summary>
        /// <para>
        /// A message that is sent to all top-level windows
        /// when the <see cref="SystemParametersInfo"/> function changes a system-wide setting or when policy settings have changed.
        /// </para>
        /// <para>
        /// Applications should send <see cref="WM_SETTINGCHANGE"/> to all top-level windows
        /// when they make changes to system parameters.
        /// (This message cannot be sent directly to a window.)
        /// To send the <see cref="WM_SETTINGCHANGE"/> message to all top-level windows,
        /// use the <see cref="SendMessageTimeout"/> function with the hwnd parameter set to <see cref="HWND_BROADCAST"/>.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// When the system sends this message as a result of a <see cref="SystemParametersInfo"/> call,
        /// the wParam parameter is the value of the uiAction parameter passed to the <see cref="SystemParametersInfo"/> function.
        /// For a list of values, see <see cref="SystemParametersInfo"/>.
        /// </para>
        /// <para>
        /// When the system sends this message as a result of a change in policy settings,
        /// this parameter indicates the type of policy that was applied.
        /// This value is 1 if computer policy was applied or zero if user policy was applied.
        /// </para>
        /// <para>
        /// When the system sends this message as a result of a change in locale settings, this parameter is zero.
        /// </para>
        /// <para>
        /// When an application sends this message, this parameter must be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// When the system sends this message as a result of a <see cref="SystemParametersInfo"/> call,
        /// lParam is a pointer to a string that indicates the area containing the system parameter that was changed.
        /// This parameter does not usually indicate which specific system parameter changed.
        /// (Note that some applications send this message with lParam set to <see cref="NULL"/>.)
        /// In general, when you receive this message,
        /// you should check and reload any system parameter settings that are used by your application.
        /// </para>
        /// <para>
        /// This string can be the name of a registry key or the name of a section in the Win.ini file.
        /// When the string is a registry name, it typically indicates only the leaf node in the registry, not the full path.
        /// </para>
        /// <para>
        /// When the system sends this message as a result of a change in policy settings,
        /// this parameter points to the string "Policy".
        /// </para>
        /// <para>
        /// When the system sends this message as a result of a change in locale settings,
        /// this parameter points to the string "intl".
        /// </para>
        /// <para>
        /// To effect a change in the environment variables for the system or the user,
        /// broadcast this message with lParam set to the string "Environment".
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If you process this message, return zero.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-settingchange"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The lParam parameter indicates which system metric has changed, for example,
        /// "ConvertibleSlateMode" if the CONVERTIBLESLATEMODE indicator was toggled
        /// or "SystemDockMode" if the DOCKED indicator was toggled.
        /// </remarks>
        WM_SETTINGCHANGE = WM_WININICHANGE,

        /// <summary>
        /// <para>
        /// An application sends the <see cref="WM_WININICHANGE"/> message to all top-level windows
        /// after making a change to the WIN.INI file.
        /// The <see cref="SystemParametersInfo"/> function sends this message
        /// after an application uses the function to change a setting in WIN.INI.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// The <see cref="WM_WININICHANGE"/> message is provided only for compatibility with earlier versions of the system.
        /// Applications should use the <see cref="WM_SETTINGCHANGE"/> message.
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a string containing the name of the system parameter that was changed.
        /// For example, this string can be the name of a registry key or the name of a section in the Win.ini file.
        /// This parameter is not particularly useful in determining which system parameter changed.
        /// For example, when the string is a registry name, it typically indicates only the leaf node in the registry, not the whole path.
        /// In addition, some applications send this message with lParam set to <see cref="NULL"/>.
        /// In general, when you receive this message, you should check and reload any system parameter settings that are used by your application.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: <see cref="LRESULT"/>
        /// </para>
        /// <para>
        /// If you process this message, return zero.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-wininichange"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// To send the <see cref="WM_WININICHANGE"/> message to all top-level windows,
        /// use the <see cref="SendMessage"/> function with the hWnd parameter set to <see cref="HWND_BROADCAST"/>.
        /// </para>
        /// <para>
        /// Calls to functions that change WIN.INI may be mapped to the registry instead.
        /// This mapping occurs when WIN.INI and the section being changed are specified in the registry under the following key:
        /// </para>
        /// <para>
        /// HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\IniFileMapping
        /// </para>
        /// <para>
        /// The change in the storage location has no effect on the behavior of this message.
        /// </para>
        /// </remarks>
        WM_WININICHANGE = 0x001A,

        #endregion

        #region System Shutdown Messages

        /// <summary>
        /// <para>
        /// The <see cref="WM_ENDSESSION"/> message is sent to an application
        /// after the system processes the results of the <see cref="WM_QUERYENDSESSION"/> message.
        /// The <see cref="WM_ENDSESSION"/> message informs the application whether the session is ending.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// If the session is being ended, this parameter is <see cref="TRUE"/>;
        /// the session can end any time after all applications have returned from processing this message.
        /// Otherwise, it is <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter can be one or more of the following values.
        /// If this parameter is 0, the system is shutting down or restarting
        /// (it is not possible to determine which event is occurring).
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ENDSESSION_CLOSEAPP"/>
        /// </para>
        /// <para>
        /// 0x1
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// If wParam is <see cref="TRUE"/>, the application must shut down.
        /// Any data should be saved automatically without prompting the user (for more information, see Remarks).
        /// The Restart Manager sends this message when the application is using a file that needs to be replaced,
        /// when it must service the system, or when system resources are exhausted.
        /// The application will be restarted if it has registered for restart using the <see cref="RegisterApplicationRestart"/> function.
        /// For more information, see Guidelines for Applications.
        /// </para>
        /// <para>
        /// If wParam is <see cref="FALSE"/>, the application should not shut down.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ENDSESSION_CRITICAL"/>
        /// </para>
        /// <para>
        /// 0x40000000
        /// </para>
        /// </term>
        /// <term>
        /// The application is forced to shut down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ENDSESSION_LOGOFF"/>
        /// </para>
        /// <para>
        /// 0x80000000
        /// </para>
        /// </term>
        /// <term>
        /// The user is logging off. For more information, see Logging Off.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Note that this parameter is a bit mask.
        /// To test for this value, use a bit-wise operation; do not test for equality.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/shutdown/wm-endsession"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Applications that have unsaved data could save the data to a temporary location and restore it the next time the application starts.
        /// It is recommended that applications save their data and state frequently;
        /// for example, automatically save data between save operations initiated by the user to reduce the amount of data to be saved at shutdown.
        /// </para>
        /// <para>
        /// The application need not call the <see cref="DestroyWindow"/> or <see cref="PostQuitMessage"/> function when the session is ending.
        /// </para>
        /// </remarks>
        WM_ENDSESSION = 0x0016,

        /// <summary>
        /// <para>
        /// The <see cref="WM_QUERYENDSESSION"/> message is sent
        /// when the user chooses to end the session or when an application calls one of the system shutdown functions.
        /// If any application returns zero, the session is not ended.
        /// The system stops sending <see cref="WM_QUERYENDSESSION"/> messages as soon as one application returns zero.
        /// </para>
        /// <para>
        /// After processing this message, the system sends the <see cref="WM_ENDSESSION"/> message
        /// with the wParam parameter set to the results of the <see cref="WM_QUERYENDSESSION"/> message.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is reserved for future use.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter can be one or more of the following values.
        /// If this parameter is 0, the system is shutting down or restarting (it is not possible to determine which event is occurring).
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ENDSESSION_CLOSEAPP"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The application is using a file that must be replaced, the system is being serviced, or system resources are exhausted.
        /// For more information, see Guidelines for Applications.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ENDSESSION_CRITICAL"/>
        /// </para>
        /// <para>
        /// 0x40000000
        /// </para>
        /// </term>
        /// <term>
        /// The application is forced to shut down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ENDSESSION_LOGOFF"/>
        /// </para>
        /// <para>
        /// 0x80000000
        /// </para>
        /// </term>
        /// <term>
        /// The user is logging off. For more information, see Logging Off.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Note that this parameter is a bit mask. To test for this value, use a bit-wise operation; do not test for equality.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Applications should respect the user's intentions and return <see cref="TRUE"/>.
        /// By default, the <see cref="DefWindowProc"/> function returns <see cref="TRUE"/> for this message.
        /// </para>
        /// <para>
        /// If shutting down would corrupt the system or media that is being burned, the application can return <see cref="FALSE"/>.
        /// However, it is good practice to respect the user's actions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/shutdown/wm-queryendsession"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// When an application returns <see cref="TRUE"/> for this message, it receives the <see cref="WM_ENDSESSION"/> message,
        /// regardless of how the other applications respond to the <see cref="WM_QUERYENDSESSION"/> message.
        /// Each application should return <see cref="TRUE"/> or <see cref="FALSE"/> immediately upon receiving this message,
        /// and defer any cleanup operations until it receives the <see cref="WM_ENDSESSION"/> message.
        /// </para>
        /// <para>
        /// Applications can display a user interface prompting the user for information at shutdown, however it is not recommended.
        /// After five seconds, the system displays information about the applications
        /// that are preventing shutdown and allows the user to terminate them.
        /// For example, Windows XP displays a dialog box,
        /// while Windows Vista displays a full screen with additional information about the applications blocking shutdown.
        /// If your application must block or postpone system shutdown, use the <see cref="ShutdownBlockReasonCreate"/> function.
        /// For more information, see Shutdown Changes for Windows Vista.
        /// </para>
        /// <para>
        /// Console applications can use the <see cref="SetConsoleCtrlHandler"/> function to receive shutdown notification.
        /// </para>
        /// <para>
        /// Service applications can use the <see cref="RegisterServiceCtrlHandlerEx"/> function to receive shutdown notifications in a handler routine.
        /// </para>
        /// </remarks>
        WM_QUERYENDSESSION = 0x0011,

        #endregion

        #region Timer Notifications

        /// <summary>
        /// <para>
        /// Posted to the installing thread's message queue when a timer expires.
        /// The message is posted by the <see cref="GetMessage"/> or <see cref="PeekMessage"/> function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The timer identifier.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to an application-defined callback function that was passed to the <see cref="SetTimer"/> function when the timer was installed.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// You can process the message by providing a <see cref="WM_TIMER"/> case in the window procedure.
        /// Otherwise, <see cref="DispatchMessage"/> will call the TimerProc callback function
        /// specified in the call to the <see cref="SetTimer"/> function used to install the timer.
        /// </para>
        /// <para>
        /// The <see cref="WM_TIMER"/> message is a low-priority message.
        /// The <see cref="GetMessage"/> and <see cref="PeekMessage"/> functions post this message
        /// only when no other higher-priority messages are in the thread's message queue.
        /// </para>
        /// </remarks>
        WM_TIMER = 0x0113,

        #endregion

        #region Window Messages

        /// <summary>
        /// <para>
        /// Sent when the window background must be erased (for example, when a window is resized).
        /// The message is sent to prepare an invalidated portion of a window for painting.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the device context.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: <see cref="LRESULT"/>
        /// </para>
        /// <para>
        /// An application should return nonzero if it erases the background; otherwise, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="DefWindowProc"/> function erases the background by using the class background brush
        /// specified by the <see cref="WNDCLASS.hbrBackground"/> member of the <see cref="WNDCLASS"/> structure.
        /// If <see cref="WNDCLASS.hbrBackground"/> is <see cref="NULL"/>,
        /// the application should process the <see cref="WM_ERASEBKGND"/> message and erase the background.
        /// </para>
        /// <para>
        /// An application should return nonzero in response to <see cref="WM_ERASEBKGND"/>
        /// if it processes the message and erases the background; this indicates that no further erasing is required.
        /// If the application returns zero, the window will remain marked for erasing.
        /// (Typically, this indicates that the <see cref="PAINTSTRUCT.fErase"/> member
        /// of the <see cref="PAINTSTRUCT"/> structure will be <see cref="TRUE"/>.)
        /// </para>
        /// </remarks>
        WM_ERASEBKGND = 0x0014,

        /// <summary>
        /// <para>
        /// Retrieves the font with which the control is currently drawing its text.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is a handle to the font used by the control, or <see cref="NULL"/> if the control is using the system font.
        /// </para>
        /// </summary>
        WM_GETFONT = 0x0031,

        /// <summary>
        /// <para>
        /// Copies the text that corresponds to a window into a buffer provided by the caller.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The maximum number of characters to be copied, including the terminating null character.
        /// </para>
        /// <para>
        /// ANSI applications may have the string in the buffer reduced in size
        /// (to a minimum of half that of the wParam value) due to conversion from ANSI to Unicode.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to the buffer that is to receive the text.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is the number of characters copied, not including the terminating null character.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="DefWindowProc"/> function copies the text associated
        /// with the window into the specified buffer and returns the number of characters copied.
        /// Note, for non-text static controls this gives you the text with which the control was originally created, that is, the ID number.
        /// However, it gives you the ID of the non-text static control as originally created.
        /// That is, if you subsequently used a <see cref="STM_SETIMAGE"/> to change it the original ID would still be returned.
        /// </para>
        /// <para>
        /// For an edit control, the text to be copied is the content of the edit control.
        /// For a combo box, the text is the content of the edit control (or static-text) portion of the combo box.
        /// For a button, the text is the button name.
        /// For other windows, the text is the window title.
        /// To copy the text of an item in a list box, an application can use the <see cref="LB_GETTEXT"/> message.
        /// </para>
        /// <para>
        /// When the <see cref="WM_GETTEXT"/> message is sent to a static control with the <see cref="SS_ICON"/> style,
        /// a handle to the icon will be returned in the first four bytes of the buffer pointed to by lParam.
        /// This is true only if the <see cref="WM_SETTEXT"/> message has been used to set the icon.
        /// </para>
        /// <para>
        /// Rich Edit: If the text to be copied exceeds 64K, use either the <see cref="EM_STREAMOUT"/> or <see cref="EM_GETSELTEXT"/> message.
        /// </para>
        /// <para>
        /// Sending a <see cref="WM_GETTEXT"/> message to a non-text static control,
        /// such as a static bitmap or static icon control, does not return a string value.
        /// Instead, it returns zero.
        /// In addition, in early versions of Windows,
        /// applications could send a <see cref="WM_GETTEXT"/> message to a non-text static control to retrieve the control's ID.
        /// To retrieve a control's ID, applications can use <see cref="GetWindowLong"/> passing <see cref="GWL_ID"/>
        /// as the index value or <see cref="GetWindowLongPtr"/> using <see cref="GWLP_ID"/>.
        /// </para>
        /// </remarks>
        WM_GETTEXT = 0x000D,

        /// <summary>
        /// <para>
        /// Determines the length, in characters, of the text associated with a window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used and must be zero.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is the length of the text in characters, not including the terminating null character.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// For an edit control, the text to be copied is the content of the edit control.
        /// For a combo box, the text is the content of the edit control (or static-text) portion of the combo box.
        /// For a button, the text is the button name.
        /// For other windows, the text is the window title.
        /// To determine the length of an item in a list box, an application can use the <see cref="LB_GETTEXTLEN"/> message.
        /// </para>
        /// <para>
        /// When the <see cref="WM_GETTEXTLENGTH"/> message is sent,
        /// the <see cref="DefWindowProc"/> function returns the length, in characters, of the text.
        /// Under certain conditions, the <see cref="DefWindowProc"/> function returns a value that is larger than the actual length of the text.
        /// This occurs with certain mixtures of ANSI and Unicode,
        /// and is due to the system allowing for the possible existence of double-byte character set (DBCS) characters within the text.
        /// The return value, however, will always be at least as large as the actual length of the text;
        /// you can thus always use it to guide buffer allocation.
        /// This behavior can occur when an application uses both ANSI functions and common dialogs, which use Unicode.
        /// </para>
        /// <para>
        /// To obtain the exact length of the text, use the <see cref="WM_GETTEXT"/>, <see cref="LB_GETTEXT"/>,
        /// or <see cref="CB_GETLBTEXT"/> messages, or the <see cref="GetWindowText"/> function.
        /// </para>
        /// <para>
        /// Sending a <see cref="WM_GETTEXTLENGTH"/> message to a non-text static control,
        /// such as a static bitmap or static icon controlc, does not return a string value.
        /// Instead, it returns zero.
        /// </para>
        /// </remarks>
        WM_GETTEXTLENGTH = 0x000E,

        /// <summary>
        /// <para>
        /// Sets the font that a control is to use when drawing text.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the font (<see cref="HFONT"/>).
        /// If this parameter is <see cref="NULL"/>, the control uses the default system font to draw text.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word of lParam specifies whether the control should be redrawn immediately upon setting the font.
        /// If this parameter is <see cref="TRUE"/>, the control redraws itself.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message does not return a value.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="WM_SETFONT"/> message applies to all controls, not just those in dialog boxes.
        /// </para>
        /// <para>
        /// The best time for the owner of a dialog box control to set the font of the control is
        /// when it receives the <see cref="WM_INITDIALOG"/> message.
        /// The application should call the <see cref="DeleteObject"/> function to delete the font when it is no longer needed;
        /// for example, after it destroys the control.
        /// </para>
        /// <para>
        /// The size of the control does not change as a result of receiving this message.
        /// To avoid clipping text that does not fit within the boundaries of the control,
        /// the application should correct the size of the control window before it sets the font.
        /// </para>
        /// <para>
        /// When a dialog box uses the <see cref="DS_SETFONT"/> style to set the text in its controls,
        /// the system sends the <see cref="WM_SETFONT"/> message to the dialog box procedure before it creates the controls.
        /// An application can create a dialog box that contains the <see cref="DS_SETFONT"/> style by calling any of the following functions:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="CreateDialogIndirect"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="CreateDialogIndirectParam"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DialogBoxIndirect"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DialogBoxIndirectParam"/>
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        WM_SETFONT = 0x0030,

        /// <summary>
        /// <para>
        /// Associates a new large or small icon with a window.
        /// The system displays the large icon in the ALT+TAB dialog box, and the small icon in the window caption.C++
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The type of icon to be set. This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ICON_BIG"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Set the large icon for the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ICON_SMALL"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Set the small icon for the window.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A handle to the new large or small icon.
        /// If this parameter is <see cref="NULL"/>, the icon indicated by wParam is removed.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is a handle to the previous large or small icon, depending on the value of wParam.
        /// It is <see cref="NULL"/> if the window previously had no icon of the type indicated by wParam.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The <see cref="DefWindowProc"/> function returns a handle to the previous large or small icon associated with the window,
        /// depending on the value of wParam.
        /// </remarks>
        WM_SETICON = 0x0080,

        /// <summary>
        /// <para>
        /// Sets the text of a window.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a null-terminated string that is the window text.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is <see cref="TRUE"/> if the text is set.
        /// It is <see cref="FALSE"/> (for an edit control), <see cref="LB_ERRSPACE"/> (for a list box),
        /// or <see cref="CB_ERRSPACE"/> (for a combo box) if insufficient space is available to set the text in the edit control.
        /// It is <see cref="CB_ERR"/> if this message is sent to a combo box without an edit control.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="DefWindowProc"/> function sets and displays the window text.
        /// For an edit control, the text is the contents of the edit control.
        /// For a combo box, the text is the contents of the edit-control portion of the combo box.
        /// For a button, the text is the button name.
        /// For other windows, the text is the window title.
        /// </para>
        /// <para>
        /// This message does not change the current selection in the list box of a combo box.
        /// An application should use the <see cref="CB_SELECTSTRING"/> message to select the item
        /// in a list box that matches the text in the edit control.
        /// </para>
        /// </remarks>
        WM_SETTEXT = 0x000C,

        #endregion

        #region Window Notifications

        /// <summary>
        /// <para>
        /// Sent when a window belonging to a different application than the active window is about to be activated.
        /// The message is sent to the application whose window is being activated
        /// and to the application whose window is being deactivated.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether the window is being activated or deactivated.
        /// This parameter is <see cref="TRUE"/> if the window is being activated;
        /// it is <see cref="FALSE"/> if the window is being deactivated.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The thread identifier. If the wParam parameter is <see cref="TRUE"/>,
        /// lParam is the identifier of the thread that owns the window being deactivated.
        /// If wParam is <see cref="FALSE"/>, lParam is the identifier of the thread that owns the window being activated.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        WM_ACTIVATEAPP = 0x001C,

        /// <summary>
        /// <para>
        /// Sent to cancel certain modes, such as mouse capture.
        /// For example, the system sends this message to the active window when a dialog box or message box is displayed.
        /// Certain functions also send this message explicitly to the specified window regardless of whether it is the active window.
        /// For example, the <see cref="EnableWindow"/> function sends this message when disabling the specified window.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// When the <see cref="WM_CANCELMODE"/> message is sent,
        /// the <see cref="DefWindowProc"/> function cancels internal processing of standard scroll bar input,
        /// cancels internal menu processing, and releases the mouse capture.
        /// </remarks>
        WM_CANCELMODE = 0x001F,

        /// <summary>
        /// <para>
        /// Sent to a child window when the user clicks the window's title bar or when the window is activated, moved, or sized.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        WM_CHILDACTIVATE = 0x0022,

        /// <summary>
        /// <para>
        /// Sent as a signal that a window or an application should terminate.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// An application can prompt the user for confirmation, prior to destroying a window,
        /// by processing the <see cref="WM_CLOSE"/> message and calling the <see cref="DestroyWindow"/> function only if the user confirms the choice.
        /// </para>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function calls the <see cref="DestroyWindow"/> function to destroy the window.
        /// </para>
        /// </remarks>
        WM_CLOSE = 0x0010,

        /// <summary>
        /// <para>
        /// Sent to all top-level windows when the system detects more than 12.5 percent of system time
        /// over a 30- to 60-second interval is being spent compacting memory.
        /// This indicates that system memory is low.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This message is provided only for compatibility with 16-bit Windows-based applications.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The ratio of central processing unit (CPU) time currently spent by the system compacting memory
        /// to CPU time currently spent by the system performing other operations.
        /// For example, 0x8000 represents 50 percent of CPU time spent compacting memory.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// When an application receives this message, it should free as much memory as possible,
        /// taking into account the current level of activity of the application and the total number of applications running on the system.
        /// </remarks>
        WM_COMPACTING = 0x0041,

        /// <summary>
        /// <para>
        /// Sent when an application requests that a window be created
        /// by calling the <see cref="CreateWindowEx"/> or <see cref="CreateWindow"/> function.
        /// (The message is sent before the function returns.)
        /// The window procedure of the new window receives this message after the window is created,
        /// but before the window becomes visible.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="CREATESTRUCT"/> structure that contains information about the window being created.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero to continue creation of the window.
        /// If the application returns –1, the window is destroyed
        /// and the <see cref="CreateWindowEx"/> or <see cref="CreateWindow"/> function returns a <see cref="NULL"/> handle.
        /// </para>
        /// </summary>
        WM_CREATE = 0x0001,

        /// <summary>
        /// <para>
        /// Sent when a window is being destroyed.
        /// It is sent to the window procedure of the window being destroyed after the window is removed from the screen.
        /// </para>
        /// <para>
        /// This message is sent first to the window being destroyed and then to the child windows (if any) as they are destroyed.
        /// During the processing of the message, it can be assumed that all child windows still exist.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: <see cref="LRESULT"/>
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// If the window being destroyed is part of the clipboard viewer chain 
        /// (set by calling the <see cref="SetClipboardViewer"/> function),
        /// the window must remove itself from the chain by processing the <see cref="ChangeClipboardChain"/> function
        /// before returning from the <see cref="WM_DESTROY"/> message.
        /// </remarks>
        WM_DESTROY = 0x0002,

        /// <summary>
        /// <para>
        /// Sent when an application changes the enabled state of a window.
        /// It is sent to the window whose enabled state is changing.
        /// This message is sent before the <see cref="EnableWindow"/> function returns,
        /// but after the enabled state (<see cref="WS_DISABLED"/> style bit) of the window has changed.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether the window has been enabled or disabled.
        /// This parameter is <see cref="TRUE"/> if the window has been enabled or <see cref="FALSE"/> if the window has been disabled.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        WM_ENABLE = 0x000A,

        /// <summary>
        /// <para>
        /// Sent one time to a window after it enters the moving or sizing modal loop.
        /// The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border,
        /// or when the window passes the <see cref="WM_SYSCOMMAND"/> message
        /// to the <see cref="DefWindowProc"/> function and the wParam parameter of the message
        /// specifies the <see cref="SC_MOVE"/> or <see cref="SC_SIZE"/> value.
        /// The operation is complete when <see cref="DefWindowProc"/> returns.
        /// </para>
        /// <para>
        /// The system sends the <see cref="WM_ENTERSIZEMOVE"/> message regardless of whether the dragging of full windows is enabled.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        WM_ENTERSIZEMOVE = 0x0231,

        /// <summary>
        /// <para>
        /// Sent one time to a window, after it has exited the moving or sizing modal loop.
        /// The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border,
        /// or when the window passes the <see cref="WM_SYSCOMMAND"/> message
        /// to the <see cref="DefWindowProc"/> function and the wParam parameter of the message
        /// specifies the <see cref="SC_MOVE"/> or <see cref="SC_SIZE"/> value.
        /// The operation is complete when <see cref="DefWindowProc"/> returns.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        WM_EXITSIZEMOVE = 0x232,

        /// <summary>
        /// <para>
        /// Sent to a window to retrieve a handle to the large or small icon associated with a window.
        /// The system displays the large icon in the ALT+TAB dialog, and the small icon in the window caption.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The type of icon being retrieved.
        /// This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ICON_BIG"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Retrieve the large icon for the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ICON_SMALL"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Retrieve the small icon for the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ICON_SMALL2"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Retrieves the small icon provided by the application.
        /// If the application does not provide one, the system uses the system-generated icon for that window.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The DPI of the icon being retrieved.
        /// This can be used to provide different icons depending on the icon size.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The return value is a handle to the large or small icon, depending on the value of wParam.
        /// When an application receives this message, it can return a handle to a large or small icon,
        /// or pass the message to the <see cref="DefWindowProc"/> function.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// When an application receives this message, it can return a handle to a large or small icon,
        /// or pass the message to <see cref="DefWindowProc"/>.
        /// </para>
        /// <para>
        /// <see cref="DefWindowProc"/> returns a handle to the large or small icon associated with the window, depending on the value of wParam.
        /// </para>
        /// <para>
        /// A window that has no icon explicitly set (with <see cref="WM_SETICON"/>) uses the icon for the registered window class,
        /// and in this case <see cref="DefWindowProc"/> will return 0 for a <see cref="WM_GETICON"/> message.
        /// If sending a <see cref="WM_GETICON"/> message to a window returns 0,
        /// next try calling the <see cref="GetClassLongPtr"/> function for the window.
        /// If that returns 0 then try the <see cref="LoadIcon"/> function.
        /// </para>
        /// </remarks>
        WM_GETICON = 0x007F,

        /// <summary>
        /// <para>
        /// Sent to a window when the size or position of the window is about to change.
        /// An application can use this message to override the window's default maximized size and position,
        /// or its default minimum or maximum tracking size.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="MINMAXINFO"/> structure that contains the default maximized position and dimensions,
        /// and the default minimum and maximum tracking sizes.
        /// An application can override the defaults by setting the members of this structure.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The maximum tracking size is the largest window size that can be produced by using the borders to size the window.
        /// The minimum tracking size is the smallest window size that can be produced by using the borders to size the window.
        /// </remarks>
        WM_GETMINMAXINFO = 0x0024,

        /// <summary>
        /// <para>
        /// Sent to the topmost affected window after an application's input language has been changed.
        /// You should make any application-specific settings and pass the message to the <see cref="DefWindowProc"/> function,
        /// which passes the message to all first-level child windows.
        /// These child windows can pass the message to <see cref="DefWindowProc"/> to have it pass the message to their child windows, and so on.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The <see cref="BYTE"/> font character set for the input language.
        /// </para>
        /// <para>
        /// If you register the window class using the Unicode version of RegisterClassEx (<see cref="RegisterClassEx"/>),
        /// you typically do not need to use this value.
        /// If you register the window class using the ANSI version of RegisterClassEx (RegisterClassExA),
        /// this value can be used to create fonts that can correctly display the character set.
        /// See iCharSet parameter of the <see cref="CreateFont"/> function for a list of possible values.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The <see cref="HKL"/> input locale identifier.
        /// </para>
        /// <para>
        /// The low word contains a Language Identifier for the input language.
        /// The high word contains a device handle.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: <see cref="LRESULT"/>
        /// </para>
        /// <para>
        /// An application should return nonzero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// You can retrieve the BCP 47 locale name from the language identifier by calling the <see cref="LCIDToLocaleName"/> function.
        /// Once you have the locale name, you can then use modern locale functions to extract additional locale information.
        /// </para>
        /// <code>
        /// case WM_INPUTLANGCHANGE:
        /// {
        ///     HKL hkl = (HKL)lParam;
        ///     // LANGIDs are deprecated. Use BCP 47 locale names where possible.
        ///     LANGID langId = LOWORD(HandleToUlong(hkl));
        /// 
        ///     WCHAR localeName[LOCALE_NAME_MAX_LENGTH];
        ///     LCIDToLocaleName(MAKELCID(langId, SORT_DEFAULT), localeName, LOCALE_NAME_MAX_LENGTH, 0);
        /// 
        ///     // Get the ISO abbreviated language name (for example, "eng").
        ///     WCHAR lang[9];
        ///     GetLocaleInfoEx(localeName, LOCALE_SISO639LANGNAME2, lang, 9);
        ///     
        ///     // Get the keyboard layout identifier (for example, "00020409" for United States-International keyboard layout)
        ///     WCHAR keyboardLayoutId[KL_NAMELENGTH];
        ///     GetKeyboardLayoutNameW(keyboardLayoutId);
        /// }
        /// </code>
        /// <para>
        /// To get the name of the currently active keyboard layout, call the <see cref="GetKeyboardLayoutName"/>.
        /// For more information, see Languages, Locales, and Keyboard Layouts.
        /// </para>
        /// <para>
        /// For a list of the input layouts that are supplied with Windows, see Keyboard Identifiers and Input Method Editors for Windows.
        /// </para>
        /// <para>
        /// Input Method Editor (IME) profile changes may not be notified with <see cref="WM_INPUTLANGCHANGE"/>.
        /// You can use <see cref="ITfActiveLanguageProfileNotifySink"/> from the Text Services Framework to handle active language or text service changes.
        /// </para>
        /// <para>
        /// Starting with Windows 8
        /// </para>
        /// <para>
        /// Some input layouts may not have assigned language identifiers and could be reported as transient language identifiers,
        /// such as <c>LOCALE_TRANSIENT_KEYBOARD1</c> (0x2000) or <c>LOCALE_TRANSIENT_KEYBOARD2</c> (0x2400), in the low word of <see cref="LPARAM"/>.
        /// </para>
        /// <para>
        /// As these transient language identifiers can be re-assigned by the system at any time
        /// (such as when the user changes their Language Profile),
        /// and can identify a different locale based on the user and/or system,
        /// they cannot be considered durable identifiers.
        /// See The deprecation of LCIDs for more info.
        /// </para>
        /// <para>
        /// Retrieve the language associated with the current keyboard layout or input method
        /// by calling Windows.Globalization.Language.CurrentInputMethodLanguageTag.
        /// If your app passes language tags from CurrentInputMethodLanguageTag to any National Language Support functions,
        /// it must first convert the tags with <see cref="ResolveLocaleName"/>.
        /// If you want to be notified about a language change in a UWP app,
        /// handle the Windows.UI.Text.Core.CoreTextServicesManager.InputLanguageChanged event.
        /// </para>
        /// </remarks>
        WM_INPUTLANGCHANGE = 0x0051,

        /// <summary>
        /// <para>
        /// Posted to the window with the focus when the user chooses a new input language,
        /// either with the hotkey (specified in the Keyboard control panel application) or from the indicator on the system taskbar.
        /// An application can accept the change by passing the message to the <see cref="DefWindowProc"/> function
        /// or reject the change (and prevent it from taking place) by returning immediately.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The new input locale. This parameter can be a combination of the following flags.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="INPUTLANGCHANGE_BACKWARD"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// A hot key was used to choose the previous input locale in the installed list of input locales.
        /// This flag cannot be used with the <see cref="INPUTLANGCHANGE_FORWARD"/> flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="INPUTLANGCHANGE_FORWARD"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// A hot key was used to choose the next input locale in the installed list of input locales.
        /// This flag cannot be used with the <see cref="INPUTLANGCHANGE_BACKWARD"/> flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="INPUTLANGCHANGE_SYSCHARSET"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The new input locale's keyboard layout can be used with the system character set.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The input locale identifier.
        /// For more information, see Languages, Locales, and Keyboard Layouts.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message is posted, not sent, to the application, so the return value is ignored.
        /// To accept the change, the application should pass the message to <see cref="DefWindowProc"/>.
        /// To reject the change, the application should return zero without calling <see cref="DefWindowProc"/>.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// When the <see cref="DefWindowProc"/> function receives the <see cref="WM_INPUTLANGCHANGEREQUEST"/> message,
        /// it activates the new input locale and notifies the application of the change by sending the <see cref="WM_INPUTLANGCHANGE"/> message.
        /// </para>
        /// <para>
        /// The language indicator is present on the taskbar only if you have installed more than one keyboard layout
        /// and if you have enabled the indicator using the Keyboard control panel application.
        /// </para>
        /// </remarks>
        WM_INPUTLANGCHANGEREQUEST = 0x0050,

        /// <summary>
        /// <para>
        /// Sent after a window has been moved.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The x and y coordinates of the upper-left corner of the client area of the window.
        /// The low-order word contains the x-coordinate while the high-order word contains the y coordinate.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The parameters are given in screen coordinates for overlapped and pop-up windows and in parent-client coordinates for child windows.
        /// </para>
        /// <para>
        /// The following example demonstrates how to obtain the position from the lParam parameter.
        /// </para>
        /// <code>
        /// xPos = (int)(short) LOWORD(lParam);   // horizontal position 
        /// yPos = (int)(short) HIWORD(lParam);   // vertical position
        /// </code>
        /// <para>
        /// You can also use the <see cref="MAKEPOINTS"/> macro to convert the lParam parameter to a <see cref="POINTS"/> structure.
        /// </para>
        /// <para>
        /// The <see cref="DefWindowProc"/> function sends the <see cref="WM_SIZE"/> and <see cref="WM_MOVE"/> messages
        /// when it processes the <see cref="WM_WINDOWPOSCHANGED"/> message.
        /// The <see cref="WM_SIZE"/> and <see cref="WM_MOVE"/> messages are not sent
        /// if an application handles the <see cref="WM_WINDOWPOSCHANGED"/> message without calling <see cref="DefWindowProc"/>.
        /// </para>
        /// </remarks>
        WM_MOVE = 0x0003,

        /// <summary>
        /// <para>
        /// Sent to a window that the user is moving.
        /// By processing this message, an application can monitor the position of the drag rectangle and, if needed, change its position.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="RECT"/> structure with the current position of the window, in screen coordinates.
        /// To change the position of the drag rectangle, an application must change the members of this structure.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return <see cref="TRUE"/> if it processes this message.
        /// </para>
        /// </summary>
        WM_MOVING = 0x0216,

        /// <summary>
        /// <para>
        /// Sent to a window when its nonclient area needs to be changed to indicate an active or inactive state.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates when a title bar or icon needs to be changed to indicate an active or inactive state.
        /// If an active title bar or icon is to be drawn, the wParam parameter is <see cref="TRUE"/>.
        /// If an inactive title bar or icon is to be drawn, wParam is <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// If this parameter is set to -1, <see cref="DefWindowProc"/> does not repaint the nonclient area to reflect the state change.
        /// </para>
        /// <para>
        /// Otherwise, if wParam is <see cref="TRUE"/>, this parameter is a handle to the previously active window.
        /// If wParam is <see cref="FALSE"/>, this parameter is a handle to the window that is going to be activated.
        /// This parameter can be <see cref="NULL"/> if the window that was previously active
        /// (or is going to be activated) is from another application.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: <see cref="LRESULT"/>
        /// </para>
        /// <para>
        /// When the wParam parameter is <see cref="FALSE"/>, an application should return <see cref="TRUE"/>
        /// to indicate that the system should proceed with the default processing,
        /// or it should return <see cref="FALSE"/> to prevent the change.
        /// When wParam is <see cref="TRUE"/>, the return value is ignored.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Processing messages related to the nonclient area of a standard window is not recommended,
        /// because the application must be able to draw all the required parts of the nonclient area for the window.
        /// If an application does process this message,
        /// it must return <see cref="TRUE"/> to direct the system to complete the change of active window.
        /// If the window is minimized when this message is received,
        /// the application should pass the message to the <see cref="DefWindowProc"/> function.
        /// </para>
        /// <para>
        /// The <see cref="DefWindowProc"/> function draws the title bar or icon title in its active colors
        /// when the wParam parameter is <see cref="TRUE"/> and in its inactive colors when wParam is <see cref="FALSE"/>.
        /// </para>
        /// </remarks>
        WM_NCACTIVATE = 0x0086,

        /// <summary>
        /// <para>
        /// Sent when the size and position of a window's client area must be calculated.
        /// By processing this message, an application can control the content of the window's client area
        /// when the size or position of the window changes.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// If wParam is <see cref="TRUE"/>, it specifies that the application should indicate which part of the client area contains valid information.
        /// The system copies the valid information to the specified area within the new client area.
        /// </para>
        /// <para>
        /// If wParam is <see cref="FALSE"/>, the application does not need to indicate the valid part of the client area.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// If wParam is <see cref="TRUE"/>, lParam points to an <see cref="NCCALCSIZE_PARAMS"/> structure
        /// that contains information an application can use to calculate the new size and position of the client rectangle.
        /// </para>
        /// <para>
        /// If wParam is <see cref="FALSE"/>, lParam points to a <see cref="RECT"/> structure.
        /// On entry, the structure contains the proposed window rectangle for the window.
        /// On exit, the structure should contain the screen coordinates of the corresponding window client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the wParam parameter is <see cref="FALSE"/>, the application should return zero.
        /// </para>
        /// <para>
        /// If wParam is <see cref="TRUE"/>, the application should return zero or a combination of the following values.
        /// </para>
        /// <para>
        /// If wParam is <see cref="TRUE"/> and an application returns zero,
        /// the old client area is preserved and is aligned with the upper-left corner of the new client area.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WVR_ALIGNTOP"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the client area of the window is to be preserved and aligned with the top of the new position of the window.
        /// For example, to align the client area to the upper-left corner,
        /// return the <see cref="WVR_ALIGNTOP"/> and <see cref="WVR_ALIGNLEFT"/> values.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WVR_ALIGNRIGHT"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the client area of the window is to be preserved and aligned with the right side of the new position of the window.
        /// For example, to align the client area to the lower-right corner,
        /// return the <see cref="WVR_ALIGNRIGHT"/> and <see cref="WVR_ALIGNBOTTOM"/> values.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WVR_ALIGNLEFT"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the client area of the window is to be preserved and aligned with the left side of the new position of the window.
        /// For example, to align the client area to the lower-left corner,
        /// return the <see cref="WVR_ALIGNLEFT"/> and <see cref="WVR_ALIGNBOTTOM"/> values.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WVR_ALIGNBOTTOM"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the client area of the window is to be preserved and aligned with the bottom of the new position of the window.
        /// For example, to align the client area to the top-left corner,
        /// return the <see cref="WVR_ALIGNTOP"/> and <see cref="WVR_ALIGNLEFT"/> values.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WVR_HREDRAW"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// Used in combination with any other values, except <see cref="WVR_VALIDRECTS"/>,
        /// causes the window to be completely redrawn if the client rectangle changes size horizontally.
        /// This value is similar to <see cref="CS_HREDRAW"/> class style
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WVR_VREDRAW"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// Used in combination with any other values, except <see cref="WVR_VALIDRECTS"/>,
        /// causes the window to be completely redrawn if the client rectangle changes size vertically.
        /// This value is similar to <see cref="CS_VREDRAW"/> class style
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WVR_REDRAW"/>
        /// </para>
        /// <para>
        /// 0x0300
        /// </para>
        /// </term>
        /// <term>
        /// This value causes the entire window to be redrawn.
        /// It is a combination of <see cref="WVR_HREDRAW"/> and <see cref="WVR_VREDRAW"/> values.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WVR_VALIDRECTS"/>
        /// </para>
        /// <para>
        /// 0x0400
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// This value indicates that, upon return from <see cref="WM_NCCALCSIZE"/>,
        /// the rectangles specified by the rgrc[1] and rgrc[2] members of the <see cref="NCCALCSIZE_PARAMS"/> structure
        /// contain valid destination and source area rectangles, respectively.
        /// The system combines these rectangles to calculate the area of the window to be preserved.
        /// The system copies any part of the window image that is within the source rectangle and clips the image to the destination rectangle.
        /// Both rectangles are in parent-relative or screen-relative coordinates.
        /// This flag cannot be combined with any other flags.
        /// </para>
        /// <para>
        /// This return value allows an application to implement more elaborate client-area preservation strategies,
        /// such as centering or preserving a subset of the client area.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The window may be redrawn, depending on whether the <see cref="CS_HREDRAW"/> or <see cref="CS_VREDRAW"/> class style is specified.
        /// This is the default, backward-compatible processing of this message by the <see cref="DefWindowProc"/> function
        /// (in addition to the usual client rectangle calculation described in the preceding table).
        /// </para>
        /// <para>
        /// When wParam is <see cref="TRUE"/>, simply returning 0 without processing the <see cref="NCCALCSIZE_PARAMS"/> rectangles
        /// will cause the client area to resize to the size of the window, including the window frame.
        /// This will remove the window frame and caption items from your window, leaving only the client area displayed.
        /// </para>
        /// <para>
        /// Starting with Windows Vista, removing the standard frame by simply returning 0
        /// when the wParam is <see cref="TRUE"/> does not affect frames
        /// that are extended into the client area using the <see cref="DwmExtendFrameIntoClientArea"/> function.
        /// Only the standard frame will be removed.
        /// </para>
        /// </remarks>
        WM_NCCALCSIZE = 0x0083,

        /// <summary>
        /// <para>
        /// Sent prior to the <see cref="WM_CREATE"/> message when a window is first created.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to the <see cref="CREATESTRUCT"/> structure that contains information about the window being created.
        /// The members of <see cref="CREATESTRUCT"/> are identical to the parameters of the <see cref="CreateWindowEx"/> function.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: <see cref="LRESULT"/>
        /// </para>
        /// <para>
        /// If an application processes this message, it should return <see cref="TRUE"/> to continue creation of the window.
        /// If the application returns <see cref="FALSE"/>,
        /// the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function will return a <see cref="NULL"/> handle.
        /// </para>
        /// </summary>
        WM_NCCREATE = 0x0081,

        /// <summary>
        /// <para>
        /// Notifies a window that its nonclient area is being destroyed.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="DestroyWindow"/> function sends the <see cref="WM_NCDESTROY"/> message
        /// to the window following the <see cref="WM_DESTROY"/> message.
        /// <see cref="WM_NCDESTROY"/> is used to free the allocated memory object associated with the window.
        /// </para>
        /// <para>
        /// The <see cref="WM_NCDESTROY"/> message is sent after the child windows have been destroyed.
        /// In contrast, <see cref="WM_DESTROY"/> is sent before the child windows are destroyed.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// This message frees any memory internally allocated for the window.
        /// </para>
        /// </remarks>
        WM_NCDESTROY = 0x0082,

        /// <summary>
        /// <para>
        /// Performs no operation. An application sends the <see cref="WM_NULL"/> message
        /// if it wants to post a message that the recipient window will ignore.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: <see cref="LRESULT"/>
        /// </para>
        /// <para>
        /// An application returns zero if it processes this message.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// For example, if an application has installed a <see cref="WH_GETMESSAGE"/> hook and wants to prevent a message from being processed,
        /// the GetMsgProc callback function can change the message number to <see cref="WM_NULL"/> so the recipient will ignore it.
        /// </para>
        /// <para>
        /// As another example, an application can check if a window is responding to messages
        /// by sending the <see cref="WM_NULL"/> message with the <see cref="SendMessageTimeout"/> function.
        /// </para>
        /// </remarks>
        WM_NULL = 0x0000,

        /// <summary>
        /// <para>
        /// Sent to a minimized (iconic) window.
        /// The window is about to be dragged by the user but does not have an icon defined for its class.
        /// An application can return a handle to an icon or cursor.
        /// The system displays this cursor or icon while the user drags the icon.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return a handle to a cursor or icon that the system is to display while the user drags the icon.
        /// The cursor or icon must be compatible with the display driver's resolution.
        /// If the application returns <see cref="NULL"/>, the system displays the default cursor.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// When the user drags the icon of a window without a class icon, the system replaces the icon with a default cursor.
        /// If the application requires a different cursor to be displayed during dragging,
        /// it must return a handle to the cursor or icon compatible with the display driver's resolution.
        /// If an application returns a handle to a color cursor or icon, the system converts the cursor or icon to black and white.
        /// The application can call the <see cref="LoadCursor"/> or <see cref="LoadIcon"/> function
        /// to load a cursor or icon from the resources in its executable (.exe) file and to retrieve this handle.
        /// </para>
        /// <para>
        /// If a dialog box procedure handles this message,
        /// it should cast the desired return value to a <see cref="BOOL"/> and return the value directly.
        /// The <see cref="DWL_MSGRESULT"/> value set by the <see cref="SetWindowLong"/> function is ignored.
        /// </para>
        /// </remarks>
        WM_QUERYDRAGICON = 0x0037,

        /// <summary>
        /// <para>
        /// Sent to an icon when the user requests that the window be restored to its previous size and position.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the icon can be opened, an application that processes this message should return <see cref="TRUE"/>;
        /// otherwise, it should return <see cref="FALSE"/> to prevent the icon from being opened.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// By default, the <see cref="DefWindowProc"/> function returns <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// While processing this message, the application should not perform any action
        /// that would cause an activation or focus change (for example, creating a dialog box).
        /// </para>
        /// </remarks>
        WM_QUERYOPEN = 0x0013,

        /// <summary>
        /// <para>
        /// Indicates a request to terminate an application,
        /// and is generated when the application calls the <see cref="PostQuitMessage"/> function.
        /// This message causes the <see cref="GetMessage"/> function to return zero.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The exit code given in the <see cref="PostQuitMessage"/> function.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: <see cref="LRESULT"/>
        /// </para>
        /// <para>
        /// This message does not have a return value
        /// because it causes the message loop to terminate before the message is sent to the application's window procedure.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="WM_QUIT"/> message is not associated with a window
        /// and therefore will never be received through a window's window procedure.
        /// It is retrieved only by the <see cref="GetMessage"/> or <see cref="PeekMessage"/> functions.
        /// </para>
        /// <para>
        /// Do not post the <see cref="WM_QUIT"/> message using the <see cref="PostMessage"/> function; use <see cref="PostQuitMessage"/>.
        /// </para>
        /// </remarks>
        WM_QUIT = 0x0012,

        /// <summary>
        /// <para>
        /// Sent to a window when the window is about to be hidden or shown.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether a window is being shown.
        /// If wParam is <see cref="TRUE"/>, the window is being shown.
        /// If wParam is <see cref="FALSE"/>, the window is being hidden.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The status of the window being shown.
        /// If lParam is zero, the message was sent because of a call to the <see cref="ShowWindow"/> function;
        /// otherwise, lParam is one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_OTHERUNZOOM"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// The window is being uncovered because a maximize window was restored or minimized.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_OTHERZOOM"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The window is being covered by another window that has been maximized.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_PARENTCLOSING"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The window's owner window is being minimized.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SW_PARENTOPENING"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// The window's owner window is being restored.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="DefWindowProc"/> function hides or shows the window, as specified by the message.
        /// If a window has the <see cref="WS_VISIBLE"/> style when it is created,
        /// the window receives this message after it is created, but before it is displayed.
        /// A window also receives this message when its visibility state is changed by the <see cref="ShowWindow"/> or <see cref="ShowOwnedPopups"/> function.
        /// </para>
        /// <para>
        /// The <see cref="WM_SHOWWINDOW"/> message is not sent under the following circumstances:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// When a top-level, overlapped window is created with the <see cref="WS_MAXIMIZE"/> or <see cref="WS_MINIMIZE"/> style.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// When the <see cref="SW_SHOWNORMAL"/> flag is specified in the call to the <see cref="ShowWindow"/> function.
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        WM_SHOWWINDOW = 0x0018,

        /// <summary>
        /// <para>
        /// Sent to a window after its size has changed.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The type of resizing requested.
        /// This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SIZE_MAXHIDE"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// Message is sent to all pop-up windows when some other window is maximized.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SIZE_MAXIMIZED"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The window has been maximized.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SIZE_MAXSHOW"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// Message is sent to all pop-up windows when some other window has been restored to its former size.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SIZE_MINIMIZED"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The window has been minimized.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SIZE_RESTORED"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// The window has been resized, but neither the <see cref="SIZE_MINIMIZED"/> nor <see cref="SIZE_MAXIMIZED"/> value applies.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word of lParam specifies the new width of the client area.
        /// </para>
        /// <para>
        /// The high-order word of lParam specifies the new height of the client area.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// Type: <see cref="LRESULT"/>
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the <see cref="SetScrollPos"/> or <see cref="MoveWindow"/> function is called for a child window
        /// as a result of the <see cref="WM_SIZE"/> message,
        /// the bRedraw or bRepaint parameter should be nonzero to cause the window to be repainted.
        /// </para>
        /// <para>
        /// Although the width and height of a window are 32-bit values,
        /// the lParam parameter contains only the low-order 16 bits of each.
        /// </para>
        /// <para>
        /// The <see cref="DefWindowProc"/> function sends the <see cref="WM_SIZE"/> and <see cref="WM_MOVE"/> messages
        /// when it processes the <see cref="WM_WINDOWPOSCHANGED"/> message.
        /// The <see cref="WM_SIZE"/> and <see cref="WM_MOVE"/> messages are not sent
        /// if an application handles the <see cref="WM_WINDOWPOSCHANGED"/> message without calling <see cref="DefWindowProc"/>.
        /// </para>
        /// </remarks>
        WM_SIZE = 0x0005,

        /// <summary>
        /// <para>
        /// Sent to a window that the user is resizing.
        /// By processing this message, an application can monitor the size and position of the drag rectangle and,
        /// if needed, change its size or position.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The edge of the window that is being sized.
        /// This parameter can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WMSZ_BOTTOM"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// Bottom edge
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WMSZ_BOTTOMLEFT"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// Bottom-left corner
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WMSZ_BOTTOMRIGHT"/>
        /// </para>
        /// <para>
        /// 8
        /// </para>
        /// </term>
        /// <term>
        /// Bottom-right corner
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WMSZ_LEFT"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Left edge
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WMSZ_RIGHT"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Right edge
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WMSZ_TOP"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// Top edge
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WMSZ_TOPLEFT"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// Top-left corner
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WMSZ_TOPRIGHT"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// Top-right corner
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="RECT"/> structure with the screen coordinates of the drag rectangle.
        /// To change the size or position of the drag rectangle,
        /// an application must change the members of this structure.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return <see cref="TRUE"/> if it processes this message.
        /// </para>
        /// </summary>
        WM_SIZING = 0x0214,

        /// <summary>
        /// <para>
        /// Sent to a window after the <see cref="SetWindowLong"/> function has changed one or more of the window's styles.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether the window's styles or extended window styles have changed.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_EXSTYLE"/>
        /// </para>
        /// <para>
        /// -20
        /// </para>
        /// </term>
        /// <term>
        /// The extended window styles have changed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_STYLE"/>
        /// </para>
        /// <para>
        /// -16
        /// </para>
        /// </term>
        /// <term>
        /// The window styles have changed.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="STYLESTRUCT"/> structure that contains the new styles for the window.
        /// An application can examine the styles, but cannot change them.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        WM_STYLECHANGED = 0x007D,

        /// <summary>
        /// <para>
        /// Sent to a window when the <see cref="SetWindowLong"/> function is about to change one or more of the window's styles.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// Indicates whether the window's styles or extended window styles are changing.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_EXSTYLE"/>
        /// </para>
        /// <para>
        /// -20
        /// </para>
        /// </term>
        /// <term>
        /// The extended window styles are changing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="GWL_STYLE"/>
        /// </para>
        /// <para>
        /// -16
        /// </para>
        /// </term>
        /// <term>
        /// The window styles are changing.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="STYLESTRUCT"/> structure that contains the proposed new styles for the window.
        /// An application can examine the styles and, if necessary, change them.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        WM_STYLECHANGING = 0x007C,

        /// <summary>
        /// <para>
        /// Broadcast to every window following a theme change event.
        /// Examples of theme change events are the activation of a theme,
        /// the deactivation of a theme, or a transition from one theme to another.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is reserved.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is reserved.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This message is posted by the operating system.
        /// Applications typically do not send this message.
        /// </para>
        /// <para>
        /// Themes are specifications for the appearance of controls,
        /// so that the visual element of a control is treated separately from its functionality.
        /// </para>
        /// <para>
        /// To release an existing theme handle, call <see cref="CloseThemeData"/>.
        /// To acquire a new theme handle, use <see cref="OpenThemeData"/>.
        /// </para>
        /// <para>
        /// Following the <see cref="WM_THEMECHANGED"/> broadcast, any existing theme handles are invalid.
        /// A theme-aware window should release and reopen any of its pre-existing theme handles
        /// when it receives the <see cref="WM_THEMECHANGED"/> message.
        /// If the <see cref="OpenThemeData"/> function returns <see cref="NULL"/>, the window should paint unthemed.
        /// </para>
        /// </remarks>
        WM_THEMECHANGED = 0x031A,

        /// <summary>
        /// <para>
        /// Sent to all windows after the user has logged on or off.
        /// When the user logs on or off, the system updates the user-specific settings.
        /// The system sends this message immediately after updating the settings.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// This message is not supported as of Windows Vista.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// An application should return zero if it processes this message.
        /// </para>
        /// </summary>
        WM_USERCHANGED = 0x0054,

        /// <summary>
        /// <para>
        /// Sent to a window whose size, position, or place in the Z order has changed
        /// as a result of a call to the <see cref="SetWindowPos"/> function or another window-management function.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="WINDOWPOS"/> structure that contains information about the window's new size and position.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// By default, the <see cref="DefWindowProc"/> function sends the <see cref="WM_SIZE"/> and <see cref="WM_MOVE"/> messages to the window.
        /// The <see cref="WM_SIZE"/> and <see cref="WM_MOVE"/> messages are not sent
        /// if an application handles the <see cref="WM_WINDOWPOSCHANGED"/> message without calling <see cref="DefWindowProc"/>.
        /// It is more efficient to perform any move or size change processing
        /// during the <see cref="WM_WINDOWPOSCHANGED"/> message without calling <see cref="DefWindowProc"/>.
        /// </remarks>
        WM_WINDOWPOSCHANGED = 0x0047,

        /// <summary>
        /// <para>
        /// Sent to a window whose size, position, or place in the Z order is about to change
        /// as a result of a call to the <see cref="SetWindowPos"/> function or another window-management function.
        /// </para>
        /// <para>
        /// A window receives this message through its WindowProc function.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="WINDOWPOS"/> structure that contains information about the window's new size and position.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// For a window with the <see cref="WS_OVERLAPPED"/> or <see cref="WS_THICKFRAME"/> style,
        /// the <see cref="DefWindowProc"/> function sends the <see cref="WM_GETMINMAXINFO"/> message to the window.
        /// This is done to validate the new size and position of the window
        /// and to enforce the <see cref="CS_BYTEALIGNCLIENT"/> and <see cref="CS_BYTEALIGNWINDOW"/> client styles.
        /// By not passing the <see cref="WM_WINDOWPOSCHANGING"/> message to the <see cref="DefWindowProc"/> function,
        /// an application can override these defaults.
        /// </para>
        /// <para>
        /// While this message is being processed, modifying any of the values
        /// in <see cref="WINDOWPOS"/> affects the window's new size, position, or place in the Z order.
        /// An application can prevent changes to the window
        /// by setting or clearing the appropriate bits in the flags member of <see cref="WINDOWPOS"/>.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// Changes to some SWP flags, including <see cref="SWP_NOACTIVATE"/> and <see cref="SWP_NOOWNERZORDER"/>,
        /// are ignored when they are modified during <see cref="WM_WINDOWPOSCHANGING"/>.
        /// </para>
        /// </remarks>
        WM_WINDOWPOSCHANGING = 0x0046,

        #endregion

        #region Windows Touch Input

        /// <summary>
        /// <para>
        /// Notifies the window when one or more touch points, such as a finger or pen, touches a touch-sensitive digitizer surface.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The low-order word contains the number of touch points associated with this message.
        /// The high-order word is reserved for future use.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// Contains a touch input handle that can be used in a call to <see cref="GetTouchInputInfo"/>
        /// to retrieve detailed information about the touch points associated with this message.
        /// </para>
        /// <para>
        /// This handle is valid only within the current process and should not be passed cross-process
        /// except as the <see cref="LPARAM"/> in a <see cref="SendMessage"/> or <see cref="PostMessage"/> call.
        /// </para>
        /// <para>
        /// When the application no longer requires this handle,
        /// the application must call <see cref="CloseTouchInputHandle"/> to free the process memory associated with this handle.
        /// Failing to do so can result in an application memory leak.
        /// </para>
        /// <para>
        /// Note that the touch input handle in this parameter is no longer valid
        /// after the message has been passed to <see cref="DefWindowProc"/>.
        /// <see cref="DefWindowProc"/> will close and invalidate this handle.
        /// </para>
        /// <para>
        /// Note also that the touch input handle in this parameter is no longer valid
        /// after the message has been forwarded using <see cref="PostMessage"/>, <see cref="SendMessage"/>, or one of their variants.
        /// These functions will close and invalidate this handle.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If an application processes this message, it should return zero.
        /// </para>
        /// <para>
        /// If the application does not process the message, it must call <see cref="DefWindowProc"/>.
        /// Not doing so causes the application to leak memory because the touch input handle is not closed and associated process memory is not freed.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/wintouch/wm-touchdown"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// <see cref="WM_TOUCH"/> messages do not respect <see cref="HTTRANSPARENT"/> regions of windows.
        /// If a window returns <see cref="HTTRANSPARENT"/> in response to a <see cref="WM_NCHITTEST"/> message,
        /// mouse messages go to the parent, and <see cref="WM_TOUCH"/> messages go directly to the window.
        /// </para>
        /// </remarks>
        WM_TOUCH = 0x0240,

        #endregion
    }
}
