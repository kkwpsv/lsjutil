using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDropTarget"/> interface is one of the interfaces you implement to provide drag-and-drop operations in your application.
    /// It contains methods used in any application that can be a target for data during a drag-and-drop operation.
    /// A drop-target application is responsible for:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Determining the effect of the drop on the target application.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Incorporating any valid dropped data when the drop occurs.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Communicating target feedback to the source so the source application can provide appropriate visual feedback such as setting the cursor.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Implementing drag scrolling.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Registering and revoking its application windows as drop targets.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// The <see cref="IDropTarget"/> interface contains methods that handle all these responsibilities
    /// except registering and revoking the application window as a drop target,
    /// for which you must call the <see cref="RegisterDragDrop"/> and the <see cref="RevokeDragDrop"/> functions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-idroptarget"/>
    /// </para>
    /// </summary>

    public unsafe struct IDropTarget
    {
        nint* _vTable;
    }
}
