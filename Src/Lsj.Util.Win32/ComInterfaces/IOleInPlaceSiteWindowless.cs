using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Extends the <see cref="IOleInPlaceSiteEx"/> interface.
    /// <see cref="IOleInPlaceSiteWindowless"/> works with <see cref="IOleInPlaceObjectWindowless"/> which is implemented on the windowless object.
    /// Together, these two interfaces provide services to a windowless object from its container allowing the windowless object to:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Process window messages
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Participate in drag and drop operations
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Perform drawing operations
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// Having a window can place unnecessary burdens on small objects, such as controls. It prevents an object from being non-rectangular.
    /// It prevents windows from being transparent. It prevents the small instance size needed by many small controls.
    /// </para>
    /// <para>
    /// A windowless object can enter the in-place active state without requiring a window or the resources associated with a window.
    /// Instead, the object's container provides the object with many of the services associated with having a window.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ioleinplacesitewindowless"/>
    /// </para>
    /// </summary>
    public unsafe struct IOleInPlaceSiteWindowless
    {
        IntPtr* _vTable;
    }
}
