using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables a class of objects to be created.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/unknwn/nn-unknwn-iclassfactory"/>
    /// </para>
    /// </summary>
    public unsafe struct IClassFactory
    {
        IntPtr* _vTable;

        /// <summary>
        /// Creates an uninitialized object.
        /// </summary>
        /// <param name="pUnkOuter">
        /// If the object is being created as part of an aggregate, specify a pointer to the controlling <see cref="IUnknown"/> interface of the aggregate.
        /// Otherwise, this parameter must be <see langword="null"/>.
        /// </param>
        /// <param name="riid">
        /// A reference to the identifier of the interface to be used to communicate with the newly created object.
        /// If <paramref name="pUnkOuter"/> is <see langword="null"/>, this parameter is generally the IID of the initializing interface;
        /// if <paramref name="pUnkOuter"/> is non-NULL, <paramref name="riid"/> must be <see cref="IID_IUnknown"/>.
        /// </param>
        /// <param name="ppvObject">
        /// The address of pointer variable that receives the interface pointer requested in <paramref name="riid"/>.
        /// Upon successful return, <paramref name="ppvObject"/> contains the requested interface pointer.
        /// If the object does not support the interface specified in <paramref name="riid"/>,
        /// the implementation must set <paramref name="ppvObject"/> to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_INVALIDARG"/>,
        /// <see cref="E_OUTOFMEMORY"/>, and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The specified object was created.
        /// <see cref="CLASS_E_NOAGGREGATION"/>: The <paramref name="pUnkOuter"/> parameter was non-NULL and the object does not support aggregation.
        /// <see cref="E_NOINTERFACE"/>:
        /// The object that <paramref name="ppvObject"/> points to does not support the interface identified by <paramref name="riid"/>.
        /// </returns>
        /// <remarks>
        /// A COM server's implementation of <see cref="CreateInstance"/> must return a reference to an object contained
        /// in an apartment that belongs to the server's DCOM resolver.
        /// It must not return a reference to an object that is contained in a remote apartment.
        /// The <see cref="IClassFactory"/> interface is always on a class object.
        /// The <see cref="CreateInstance"/> method creates an uninitialized object of the class identified with the specified CLSID.
        /// When an object is created in this way, the CLSID must be registered in the system registry with the <see cref="CoRegisterClassObject"/> function.
        /// The <paramref name="pUnkOuter"/> parameter indicates whether the object is being created as part of an aggregate.
        /// Object definitions are not required to support aggregation they must be specifically designed and implemented to support it.
        /// The <paramref name="riid"/> parameter specifies the IID (interface identifier) of the interface through
        /// which you will communicate with the new object.
        /// If <paramref name="pUnkOuter"/> is non-NULL (indicating aggregation),
        /// the value of the <paramref name="riid"/> parameter must be <see cref="IID_IUnknown"/>.
        /// If the object is not part of an aggregate, riid often specifies the interface though which the object will be initialized.
        /// For OLE embeddings, the initialization interface is <see cref="IPersistStorage"/>, but in other situations, other interfaces are used.
        /// To initialize the object, there must be a subsequent call to an appropriate method in the initializing interface.
        /// Common initialization functions include <see cref="IPersistStorage.InitNew"/> (for new, blank embeddable components),
        /// <see cref="IPersistStorage.Load"/> (for reloaded embeddable components),
        /// <see cref="IPersistStream.Load"/>, (for objects stored in a stream object)
        /// or <see cref="IPersistFile.Load"/>(for objects stored in a file).
        /// In general, if an application supports only one class of objects,
        /// and the class object is registered for single use, only one object can be created.
        /// The application must not create other objects, and a request to do so should return an error from <see cref="CreateInstance"/>.
        /// The same is true for applications that support multiple classes, each with a class object registered for single use;
        /// a call to <see cref="CreateInstance"/> for one class followed by
        /// a call to <see cref="CreateInstance"/> for any of the classes that should return an error.
        /// To avoid returning an error, applications that support multiple classes with single-use class objects can revoke the registered class object
        /// of the first class by calling <see cref="CoRevokeClassObject"/> when a request for instantiating a second is received.
        /// For example, suppose there are two classes, A and B.
        /// When <see cref="CreateInstance"/> is called for class A, revoke the class object for B.
        /// When B is created, revoke the class object for A.
        /// This solution complicates shutdown because one of the class objects might have already been revoked (and cannot be revoked twice).
        /// </remarks>
        public HRESULT CreateInstance([In] in IUnknown pUnkOuter, [In] in IID riid, [Out] out IntPtr ppvObject)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IUnknown, in IID, out IntPtr, HRESULT>)_vTable[3])(thisPtr, pUnkOuter, riid, out ppvObject);
            }
        }

        /// <summary>
        /// Locks an object application open in memory. This enables instances to be created more quickly.
        /// </summary>
        /// <param name="fLock">
        /// If <see cref="TRUE"/>, increments the lock count; if <see cref="FALSE"/>, decrements the lock count.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/>,
        /// <see cref="E_UNEXPECTED"/>, <see cref="E_FAIL"/>, and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="LockServer"/> controls whether an object's server is kept in memory.
        /// Keeping the application alive in memory allows instances to be created more quickly.
        /// Notes to Callers
        /// Most clients do not need to call this method.
        /// It is provided only for those clients that require special performance in creating multiple instances of their objects
        /// Notes to Implementers
        /// If the lock count is zero, there are no more objects in use, and the application is not under user control, the server can be closed.
        /// One way to implement <see cref="LockServer"/> is to call the <see cref="CoLockObjectExternal"/> function.
        /// The process that locks the object application is responsible for unlocking it.
        /// After the class object is released, there is no mechanism that guarantees the caller connection to the same class later
        /// (as in the case where a class object is registered as single-use).
        /// It is important to count all calls, not just the last one, to <see cref="LockServer"/>,
        /// because calls must be balanced before attempting to release the pointer to the <see cref="IClassFactory"/> interface
        /// on the class object or an error results.
        /// For every call to <see cref="LockServer"/> with <paramref name="fLock"/> set to <see cref="TRUE"/>,
        /// there must be a call to <see cref="LockServer"/> with <paramref name="fLock"/> set to <see cref="FALSE"/>.
        /// When the lock count and the class object reference count are both zero, the class object can be freed.
        /// </remarks>
        public HRESULT LockServer([In] BOOL fLock)
        {

            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, HRESULT>)_vTable[4])(thisPtr, fLock);
            }
        }
    }
}
