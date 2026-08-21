using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides simple frame controls that act as simple containers for other nested controls. Some controls merely contain other controls.
    /// In such cases, the simple control container, called a simple frame, need not implement all container requirements.
    /// It can delegate most of the interface calls from its contained controls to the outer container that manages the simple frame.
    /// To support what are called simple frame controls, a container implements this interface
    /// as well as other site interfaces such as <see cref="IOleControlSite"/>.
    /// </para>
    /// <para>
    /// An example of a simple frame control is a group box that only needs to capture a few keystrokes
    /// for its contained controls to implement the correct tab or arrow key behavior, but does not want to handle every other message.
    /// Through the two methods of this interface, the simple frame control passes messages to its control site both before and after its own processing.
    /// If that site is itself a simple frame, it can continue to pass messages up the chain.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-isimpleframesite"/>
    /// </para>
    /// </summary>
    public unsafe struct ISimpleFrameSite
    {
        nint* _vTable;
    }
}
