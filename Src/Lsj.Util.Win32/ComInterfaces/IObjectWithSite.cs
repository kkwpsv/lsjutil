using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides a simple way to support communication between an object and its site in the container.
    /// </para>
    /// <para>
    /// Often an object needs to communicate directly with a container site object and, in effect, manage the site object itself.
    /// Outside of <see cref="IOleObject.SetClientSite"/>, there is no generic means through which an object becomes aware of its site.
    /// <see cref="IObjectWithSite"/> provides simple objects with a simple siting mechanism (lighter than <see cref="IOleObject"/>)
    /// This interface should only be used when <see cref="IOleObject"/> is not already in use.
    /// </para>
    /// <para>
    /// Through <see cref="IObjectWithSite"/>, a container can pass the <see cref="IUnknown"/> pointer of its site to the object through <see cref="IObjectWithSite.SetSite"/>.
    /// Callers can also retrieve the latest site passed to <see cref="IObjectWithSite.SetSite"/> through <see cref="IObjectWithSite.GetSite"/>.
    /// This latter method is included as a hooking mechanism, allowing a third party to intercept calls from the object to the site.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-iobjectwithsite"/>
    /// </para>
    /// </summary>
    public unsafe struct IObjectWithSite
    {
        IntPtr* _vTable;
    }
}
