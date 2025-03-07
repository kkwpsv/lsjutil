using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes a method for getting a thumbnail image and is intended to be implemented for thumbnail handlers.
    /// The object that implements this interface must also implement <see cref="IInitializeWithStream"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/thumbcache/nn-thumbcache-ithumbnailprovider"/>
    /// </para>
    /// </summary>
    public unsafe struct IThumbnailProvider
    {
        IntPtr* _vTable;
    }
}
