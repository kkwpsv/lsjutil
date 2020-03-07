using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.ComInterfaces.IIDs;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables clients to get pointers to other interfaces on a given object through the <see cref="QueryInterface"/> method,
    /// and manage the existence of the object through the <see cref="AddRef"/> and <see cref="Release"/> methods.
    /// All other COM interfaces are inherited, directly or indirectly, from <see cref="IUnknown"/>.
    /// Therefore, the three methods in <see cref="IUnknown"/> are the first entries in the vtable for every interface.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/unknwn/nn-unknwn-iunknown
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IUnknown)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IUnknown
    {
        ///// <summary>
        ///// <para>
        ///// Queries a COM object for a pointer to one of its interface; identifying the interface by a reference to its interface identifier (IID).
        ///// If the COM object implements the interface, then it returns a pointer to that interface after calling <see cref="AddRef"/> on it.
        ///// </para>
        ///// </summary>
        ///// <param name="riid">
        ///// A reference to the interface identifier (IID) of the interface being queried for.
        ///// </param>
        ///// <param name="ppvObject">
        ///// The address of a pointer to an interface with the IID specified in the riid parameter.
        ///// Because you pass the address of an interface pointer, the method can overwrite that address with the pointer to the inteface being queried for.
        ///// Upon successful return, *ppvObject (the dereferenced address) contains a pointer to the requested interface.
        ///// If the object doesn't support the interface, the method sets *<paramref name="ppvObject"/> (the dereferenced address) to <see langword="null"/>.
        ///// </param>
        ///// <returns>
        ///// This method returns <see cref="S_OK"/> if the interface is supported, and <see cref="E_NOINTERFACE"/> otherwise.
        ///// If <paramref name="ppvObject"/> (the address) is <see langword="null"/>, then this method returns <see cref="E_POINTER"/>.
        ///// </returns>
        ///// <remarks>
        ///// For any given COM object (also known as a COM component), a specific query for the <see cref="IUnknown"/> interface
        ///// on any of the object's interfaces must always return the same pointer value.
        ///// This enables a client to determine whether two pointers point to the same component
        ///// by calling <see cref="QueryInterface"/> with <see cref="IID_IUnknown"/> and comparing the results.
        ///// It is specifically not the case that queries for interfaces other than <see cref="IUnknown"/>
        ///// (even the same interface through the same pointer) must return the same pointer value.
        ///// There are four requirements for implementations of <see cref="QueryInterface"/>
        ///// (In these cases, "must succeed" means "must succeed barring catastrophic failure.").
        ///// The set of interfaces accessible on an object through <see cref="QueryInterface"/> must be static, not dynamic.
        ///// This means that if a call to <see cref="QueryInterface"/> for a pointer to a specified interface succeeds the first time,
        ///// then it must succeed again.
        ///// If the call fails the first time, then it must fail on all subsequent calls.
        ///// It must be reflexive—if a client holds a pointer to an interface on an object, and the client queries for that interface,
        ///// then the call must succeed.
        ///// It must be symmetric—if a client holding a pointer to one interface queries successfully for another,
        ///// then a query through the obtained pointer for the first interface must succeed.
        ///// It must be transitive—if a client holding a pointer to one interface queries successfully for a second,
        ///// and through that pointer queries successfully for a third interface, then a query for the first interface
        ///// through the pointer for the third interface must succeed.
        ///// Notes to implementers
        ///// Implementations of <see cref="QueryInterface"/> must never check ACLs.
        ///// The main reason for this rule is that COM requires that an object supporting a particular interface
        ///// always return success when queried for that interface.
        ///// Another reason is that checking ACLs on <see cref="QueryInterface"/> does not provide any real security
        ///// because any client who has access to a particular interface can hand it directly to another client without any calls back to the server.
        ///// Also, because COM caches interface pointers, it does not call <see cref="QueryInterface"/> on the server every time a client does a query.
        ///// </remarks>
        //[PreserveSig]
        //HRESULT QueryInterface([In]ref Guid riid, [Out]out object ppvObject);

        ///// <summary>
        ///// Increments the reference count for an interface pointer to a COM object. You should call this method whenever you make a copy of an interface pointer
        ///// </summary>
        ///// <returns>
        ///// The method returns the new reference count. This value is intended to be used only for test purposes.
        ///// </returns>
        ///// <remarks>
        ///// A COM object uses a per-interface reference-counting mechanism to ensure that the object doesn't outlive references to it.
        ///// You use <see cref="AddRef"/> to stabilize a copy of an interface pointer.
        ///// It can also be called when the life of a cloned pointer must extend beyond the lifetime of the original pointer.
        ///// The cloned pointer must be released by calling <see cref="Release"/> on it.
        ///// The internal reference counter that <see cref="AddRef"/> maintains should be a 32-bit unsigned integer.
        ///// Notes to callers
        ///// Call this method for every new copy of an interface pointer that you make.
        ///// For example, if you return a copy of a pointer from a method, then you must call <see cref="AddRef"/> on that pointer.
        ///// You must also call <see cref="AddRef"/> on a pointer before passing it as an in-out parameter to a method;
        ///// the method will call <see cref="Release"/> before copying the out-value on top of it.
        ///// </remarks>
        //[PreserveSig]
        //uint AddRef();

        ///// <summary>
        ///// Decrements the reference count for an interface on a COM object.
        ///// </summary>
        ///// <returns>
        ///// The method returns the new reference count. This value is intended to be used only for test purposes.
        ///// </returns>
        ///// <remarks>
        ///// When the reference count on an object reaches zero, Release must cause the interface pointer to free itself.
        ///// When the released pointer is the only (formerly) outstanding reference to an object (whether the object supports single or multiple interfaces), 
        ///// the implementation must free the object.
        ///// Note that aggregation of objects restricts the ability to recover interface pointers.
        ///// Notes to callers
        ///// Call this method when you no longer need to use an interface pointer.
        ///// If you are writing a method that takes an in-out parameter, call <see cref="Release"/> on the pointer you are passing in
        ///// before copying the out-value on top of it.
        ///// </remarks>
        //[PreserveSig]
        //uint Release();
    }
}
