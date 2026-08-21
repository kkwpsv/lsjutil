using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides an object with a property bag in which the object can save its properties persistently.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-ipropertybag"/>
    /// </para>
    /// </summary>
    public unsafe struct IPropertyBag
    {
        nint* _vTable;
    }
}
