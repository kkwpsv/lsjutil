using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An extension derived from <see cref="IViewObject2"/> to provide support for:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Enhanced, flicker-free drawing for non-rectangular objects and transparent objects
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Hit testing for non-rectangular objects
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Control sizing
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-iviewobjectex"/>
    /// </para>
    /// </summary>
    public unsafe struct IViewObjectEx
    {
        IntPtr* _vTable;
    }
}
