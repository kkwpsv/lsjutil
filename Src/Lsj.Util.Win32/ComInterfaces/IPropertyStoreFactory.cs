using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods to get an <see cref="IPropertyStore"/> object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/propsys/nn-propsys-ipropertystorefactory"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This interface is typically obtained through <see cref="IShellFolder.BindToObject"/> or <see cref="IShellItem.BindToHandler"/>.
    /// It is useful for data source implementers who want to avoid the additional overhead of creating a property store through <see cref="IShellItem2.GetPropertyStore"/>.
    /// However, <see cref="IShellItem2.GetPropertyStore"/> is the recommended method to obtain a property store
    /// unless you are implementing a data source through a Shell folder extension.
    /// </remarks>
    public unsafe struct IPropertyStoreFactory
    {
        IntPtr* _vTable;
    }
}
