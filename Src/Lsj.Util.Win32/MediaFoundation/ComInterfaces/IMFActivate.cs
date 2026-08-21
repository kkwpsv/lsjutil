using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.MediaFoundation.Mfplat;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables the application to defer the creation of an object. This interface is exposed by activation objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/nn-mfobjects-imfactivate"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Typically, the application calls some function that returns an <see cref="IMFActivate"/> pointer
    /// and then passes that pointer to another component.
    /// The other component calls <see cref="ActivateObject"/> at a later time to create the object.
    /// In the protected media path (PMP), the <see cref="IMFActivate"/> pointer
    /// might be marshaled to the protected process, so that the object can be created in that process.
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
    [ComInterface(IID = "7FEE9E9A-4A89-47a6-899C-B6A53A70FB67", BeginVTableSlotIndex = 33, EndVTableSlotIndex = 35,
        InheritedFromTypes = [typeof(IUnknown), typeof(IMFAttributes)])]
    public unsafe struct IMFActivate
    {
        nint* _vTable;

        /// <summary>
        /// Creates the object associated with this activation object.
        /// </summary>
        /// <param name="riid">
        /// Interface identifier (IID) of the requested interface.
        /// </param>
        /// <param name="ppv">
        /// Receives a pointer to the requested interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Some Microsoft Media Foundation objects must be shut down before being released.
        /// If so, the caller is responsible for shutting down the object that is returned in <paramref name="ppv"/>.
        /// To shut down the object, do one of the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Call <see cref="IMFActivate.ShutdownObject"/> on the activation object, or
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Call the object-specific shutdown method.
        /// This method will depend on the type of object.
        /// Possibilities include:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Media sources: Call <see cref="IMFMediaSource.Shutdown"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Media sinks: Call <see cref="IMFMediaSink.Shutdown"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Any object that supports the <see cref="IMFShutdown"/> interface:
        /// Call <see cref="IMFShutdown.Shutdown"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="ShutdownObject"/> method is generic to all object types.
        /// If the object does not require a shutdown method, <see cref="ShutdownObject"/> succeeds and has no effect.
        /// If you do not know the specific shutdown method for the object (or do not know the object type),
        /// call <see cref="ShutdownObject"/>.
        /// </para>
        /// <para>
        /// After the first call to <see cref="ActivateObject"/>, subsequent calls return a pointer to the same instance,
        /// until the client calls either <see cref="ShutdownObject"/> or <see cref="DetachObject"/>.
        /// </para>
        /// </remarks>
        public HRESULT ActivateObject([In] in GUID riid, [Out] out nint ppv)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, out nint, HRESULT>)_vTable[33])(thisPtr, riid, out ppv);
            }
        }

        /// <summary>
        /// Shuts down the created object.
        /// </summary>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
        /// </para>
        /// <para>
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If you create an object by calling <see cref="ActivateObject"/>,
        /// call <see cref="ShutdownObject"/> when you are done using the object.
        /// </para>
        /// <para>
        /// The component that calls <see cref="ActivateObject"/>
        /// —not the component that creates the activation object—is responsible for calling <see cref="ShutdownObject"/>.
        /// For example, in a typical playback application, the application creates activation objects for the media sinks,
        /// but the Media Session calls <see cref="ActivateObject"/>.
        /// Therefore the Media Session, not the application, calls <see cref="ShutdownObject"/>.
        /// </para>
        /// <para>
        /// After <see cref="ShutdownObject"/> is called, the activation object releases all of its internal references to the created object.
        /// If you call <see cref="ActivateObject"/> again, the activation object will create a new instance of the other object.
        /// </para>
        /// </remarks>
        public HRESULT ShutdownObject()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[34])(thisPtr);
            }
        }

        /// <summary>
        /// Detaches the created object from the activation object.
        /// </summary>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
        /// </para>
        /// <para>
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_NOTIMPL"/>
        /// </term>
        /// <term>
        /// Not implemented.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The activation object releases all of its internal references to the created object.
        /// If you call <see cref="ActivateObject"/> again,
        /// the activation object will create a new instance of the other object.
        /// </para>
        /// <para>
        /// The <see cref="DetachObject"/> method does not shut down the created object.
        /// If the <see cref="DetachObject"/> method succeeds, the client must shut down the created object.
        /// This rule applies only to objects that have a shutdown method or that support the <see cref="IMFShutdown"/> interface.
        /// See the remarks for <see cref="ActivateObject"/>.
        /// </para>
        /// <para>
        /// Implementation of this method is optional.
        /// If the activation object does not support this method, the method returns <see cref="E_NOTIMPL"/>.
        /// </para>
        /// </remarks>
        public HRESULT DetachObject()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[35])(thisPtr);
            }
        }
    }
}
