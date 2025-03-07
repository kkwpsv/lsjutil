using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables an object to remain inactive most of the time, yet still participate in interaction with the mouse, including drag and drop.
    /// </para>
    /// <para>
    /// Objects can be active (in-place or UI active) or they can be inactive (loaded or running).
    /// An active object creates a window and can receive Windows mouse and keyboard messages.
    /// An inactive object can render itself and provide a representation of its data in a given format.
    /// While they provide more functionality, active objects also consume more resources than inactive objects.
    /// Typically, they are larger and slower than inactive objects.
    /// Thus, keeping an object inactive can provide performance improvements.
    /// </para>
    /// <para>
    /// However, an object, such as a control, needs to be able to control the mouse pointer, fire mouse events,
    /// and act as a drop target so it can participate in the user interface of its container application.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ipointerinactive"/>
    /// </para>
    /// </summary>
    public unsafe struct IPointerInactive
    {
        IntPtr* _vTable;
    }
}
