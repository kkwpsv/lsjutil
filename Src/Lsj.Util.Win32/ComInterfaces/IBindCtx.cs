using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Ole32;
using BIND_OPTS = Lsj.Util.Win32.Structs.BIND_OPTS;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides access to a bind context, which is an object that stores information about a particular moniker binding operation.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-ibindctx
    /// </para>
    /// </summary>
    /// <remarks>
    /// A bind context includes the following information:
    /// A BIND_OPTS structure containing a set of parameters that do not change during the binding operation.
    /// When a composite moniker is bound, each component uses the same bind context,
    /// so it acts as a mechanism for passing the same parameters to each component of a composite moniker.
    /// A set of pointers to objects that the binding operation has activated.
    /// The bind context holds pointers to these bound objects, keeping them loaded and thus eliminating redundant activations
    /// if the objects are needed again during subsequent binding operations.
    /// A pointer to the running object table (ROT) on the same computer as the process that started the bind operation.
    /// Moniker implementations that need to access the ROT should use the <see cref="GetRunningObjectTable"/> method
    /// rather than using the <see cref="Ole32.GetRunningObjectTable"/> function.
    /// This allows future enhancements to the system's <see cref="IBindCtx"/> implementation to modify binding behavior.
    /// A table of interface pointers, each associated with a string key.
    /// This capability enables moniker implementations to store interface pointers under a well-known string
    /// so that they can later be retrieved from the bind context.
    /// For example, OLE defines several string keys ("ExceededDeadline", "ConnectManually", and so on)
    /// that can be used to store a pointer to the object that caused an error during a binding operation.
    /// </remarks>
    public unsafe struct IBindCtx
    {
        IntPtr* _vTable;

        /// <summary>
        /// Registers an object with the bind context to ensure that the object remains active until the bind context is released.
        /// </summary>
        /// <param name="punk">
        /// A pointer to the <see cref="IUnknown"/> interface on the object that is being registered as bound.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// Those writing a new moniker class (through an implementation of the <see cref="IMoniker"/> interface) should
        /// call this method whenever the implementation activates an object.
        /// This happens most often in the course of binding a moniker, but it can also happen while retrieving a moniker's display name,
        /// parsing a display name into a moniker, or retrieving the time that an object was last modified.
        /// <see cref="RegisterObjectBound"/> calls AddRef to create an additional reference to the object.
        /// You must, however, still release your own copy of the pointer.
        /// Calling this method twice for the same object creates two references to that object.
        /// You can release a reference obtained through a call to this method by calling <see cref="RevokeObjectBound"/>.
        /// All references held by the bind context are released when the bind context itself is released.
        /// Calling <see cref="RegisterObjectBound"/> to register an object with a bind context
        /// keeps the object active until the bind context is released.
        /// Reusing a bind context in a subsequent binding operation (either for another piece of the same composite moniker
        /// or for a different moniker) can make the subsequent binding operation more efficient because it doesn't have to reload that object.
        /// This, however, improves performance only if the subsequent binding operation requires some of the same objects as the original one,
        /// so you need to balance the possible performance improvement of reusing a bind context against the costs of keeping objects activated unnecessarily.
        /// <see cref="IBindCtx"/> does not provide a method to retrieve a pointer to an object registered using <see cref="RegisterObjectBound"/>.
        /// Assuming the object has registered itself with the running object table,
        /// moniker implementations can call <see cref="IRunningObjectTable.GetObject"/> to retrieve a pointer to the object.
        /// </remarks>
        public HRESULT RegisterObjectBound([In] in IUnknown punk)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IUnknown, HRESULT>)_vTable[3])(thisPtr, punk);
            }
        }

        /// <summary>
        /// Removes the object from the bind context, undoing a previous call to <see cref="RegisterObjectBound"/>.
        /// </summary>
        /// <param name="punk">
        /// A pointer to the <see cref="IUnknown"/> interface on the object to be removed.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>: The object was released successfully.
        /// <see cref="MK_E_NOTBOUND"/>: The object was not previously registered.
        /// </returns>
        /// <remarks>
        /// You would rarely call this method.
        /// It is documented primarily for completeness.
        /// </remarks>
        public HRESULT RevokeObjectBound([In] in IUnknown punk)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IUnknown, HRESULT>)_vTable[4])(thisPtr, punk);
            }
        }

        /// <summary>
        /// Releases all pointers to all objects that were previously registered by calls to <see cref="RegisterObjectBound"/>.
        /// </summary>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// You rarely call this method directly.
        /// The system's <see cref="IBindCtx"/> implementation calls this method when the pointer to the <see cref="IBindCtx"/> interface
        /// on the bind context is released (the bind context is released).
        /// If a bind context is not released, all of the registered objects remain active.
        /// If the same object has been registered more than once,
        /// this method calls the Release method on the object the number of times it was registered.
        /// </remarks>
        public HRESULT ReleaseBoundObjects([In] in IUnknown punk)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[5])(thisPtr);
            }
        }

        /// <summary>
        /// Sets new values for the binding parameters stored in the bind context.
        /// </summary>
        /// <param name="pbindopts">
        /// A pointer to a <see cref="BIND_OPTS3"/> structure containing the binding parameters.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// A bind context contains a block of parameters that are common to most <see cref="IMoniker"/> operations.
        /// These parameters do not change as the operation moves from piece to piece of a composite moniker.
        /// Subsequent binding operations can call <see cref="GetBindOptions"/> to retrieve these parameters.
        /// Notes to Callers
        /// This method can be called by moniker clients (those who use monikers to acquire interface pointers to objects).
        /// When you first create a bind context by using the <see cref="CreateBindCtx"/> function,
        /// the fields of the <see cref="BIND_OPTS"/> structure are initialized to the following values:
        /// <code>
        /// cbStruct = sizeof(BIND_OPTS); 
        /// grfFlags = 0;
        /// grfMode = STGM_READWRITE;
        /// dwTickCountDeadline = 0; 
        /// </code>
        /// You can use the <see cref="SetBindOptions"/> method to modify these values before using the bind context,
        /// if you want values other than the defaults.
        /// <see cref="SetBindOptions"/> copies the members of the specified structure,
        /// but not the <see cref="COSERVERINFO"/> structure and the pointers it contains.
        /// Callers may not free these pointers until the bind context is released.
        /// </remarks>
        public HRESULT SetBindOptions([In] in BIND_OPTS pbindopts)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in BIND_OPTS, HRESULT>)_vTable[6])(thisPtr, pbindopts);
            }
        }

        /// <summary>
        /// Retrieves the binding options stored in this bind context.
        /// </summary>
        /// <param name="pbindopts">
        /// A pointer to an initialized structure that receives the current binding parameters on return.
        /// See <see cref="BIND_OPTS3"/>.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_UNEXPECTED"/> and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// A bind context contains a block of parameters that are common to most <see cref="IMoniker"/> operations
        /// and that do not change as the operation moves from piece to piece of a composite moniker.
        /// Notes to Callers
        /// You typically call this method if you are writing your own moniker class.
        /// (This requires that you implement the <see cref="IMoniker"/> interface.)
        /// You call this method to retrieve the parameters specified by the moniker client.
        /// You must initialize the structure that is filled in by this method.
        /// Before calling this method, you must initialize the <see cref="BIND_OPTS.cbStruct"/> member to the size of the structure.
        /// </remarks>
        public HRESULT GetBindOptions([In][Out] ref BIND_OPTS pbindopts)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ref BIND_OPTS, HRESULT>)_vTable[7])(thisPtr, ref pbindopts);
            }
        }

        /// <summary>
        /// Retrieves an interface pointer to the running object table (ROT) for the computer on which this bind context is running.
        /// </summary>
        /// <param name="pprot">
        /// The address of a <see cref="IRunningObjectTable"/> pointer variable that receives the interface pointer to the running object table.
        /// If an error occurs, <paramref name="pprot"/> is set to <see langword="null"/>.
        /// If <paramref name="pprot"/> is non-NULL, the implementation calls AddRef on the running table object;
        /// it is the caller's responsibility to call Release.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/>, <see cref="E_UNEXPECTED"/>, and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// The running object table is a globally accessible table on each computer.
        /// It keeps track of all the objects that are currently running on the computer.
        /// Notes to Callers
        /// Typically, those implementing a new moniker class (through an implementation of <see cref="IMoniker"/> interface)
        /// call <see cref="GetRunningObjectTable"/>.
        /// It is useful to call this method in an implementation of <see cref="IMoniker.BindToObject"/>
        /// or <see cref="IMoniker.IsRunning"/> to check whether an object is currently running.
        /// You can also call this method in the implementation of <see cref="IMoniker.GetTimeOfLastChange"/>
        /// to learn when a running object was last modified.
        /// Moniker implementations should call this method instead of using the <see cref="Ole32.GetRunningObjectTable"/> function.
        /// This makes it possible for future implementations of <see cref="IBindCtx"/> to modify binding behavior.
        /// </remarks>
        public HRESULT GetRunningObjectTable([Out] out IntPtr pprot)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out IntPtr, HRESULT>)_vTable[8])(thisPtr, out pprot);
            }
        }

        /// <summary>
        /// Associates an object with a string key in the bind context's string-keyed table of pointers.
        /// </summary>
        /// <param name="pszKey">
        /// The bind context string key under which the object is being registered. Key string comparison is case-sensitive.
        /// </param>
        /// <param name="punk">
        /// A pointer to the <see cref="IUnknown"/> interface on the object that is to be registered.
        /// The method calls AddRef on the pointer.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// A bind context maintains a table of interface pointers, each associated with a string key.
        /// This enables communication between a moniker implementation and the caller that initiated the binding operation.
        /// One party can store an interface pointer under a string known to both parties
        /// 
        /// so that the other party can later retrieve it from the bind context.
        /// Binding operations subsequent to the use of this method can use <see cref="GetObjectParam"/> to retrieve the stored pointer.
        /// Notes to Callers
        /// <see cref="RegisterObjectParam"/> is useful to those implementing a new moniker class
        /// (through an implementation of <see cref="IMoniker"/>) and to moniker clients (those who use monikers to bind to objects).
        /// In implementing a new moniker class, you call this method when an error occurs
        /// during moniker binding to inform the caller of the cause of the error.
        /// The key that you would obtain with a call to this method would depend on the error condition.
        /// Following is a list of common moniker binding errors, describing for each the keys that would be appropriate:
        /// <see cref="MK_E_EXCEEDEDDEADLINE"/>:
        /// If a binding operation exceeds its deadline because a given object is not running,
        /// you should register the object's moniker using the first unused key from the list: "ExceededDeadline",
        /// "ExceededDeadline1", "ExceededDeadline2", and so on.
        /// If the caller later finds the moniker in the running object table, the caller can retry the binding operation.
        /// <see cref="MK_E_CONNECTMANUALLY"/>:
        /// The "ConnectManually" key indicates a moniker whose binding requires assistance from the end user.
        /// To request that the end user manually connect to the object,
        /// the caller can retry the binding operation after showing the moniker's display name.
        /// Common reasons for this error are that a password is needed or that a floppy needs to be mounted.
        /// <see cref="E_CLASSNOTFOUND"/>:
        /// The "ClassNotFound" key indicates a moniker whose class could not be found.
        /// (The server for the object identified by this moniker could not be located.)
        /// If this key is used for an OLE compound-document object, the caller can use <see cref="IMoniker.BindToStorage"/>
        /// to bind to the object and then try to carry out a Treat As... or Convert To... operation to associate the object with a different server.
        /// If this is successful, the caller can retry the binding operation.
        /// A moniker client with detailed knowledge of the implementation of the moniker can also call
        /// this method to pass private information to that implementation.
        /// You can define new strings as keys for storing pointers.
        /// By convention, you should use key names that begin with the string form of the CLSID of the moniker class.
        /// (See the <see cref="StringFromCLSID"/> function.)
        /// If the <paramref name="pszKey"/> parameter matches the name of an existing key in the bind context's table,
        /// the new object replaces the existing object in the table.
        /// When you register an object using this method, the object is not released until one of the following occurs:
        /// It is replaced in the table by another object with the same key.
        /// It is removed from the table by a call to <see cref="RevokeObjectParam"/>.
        /// The bind context is released. All registered objects are released when the bind context is released.
        /// </remarks>
        public HRESULT RegisterObjectParam([In] string pszKey, [In] in IUnknown punk)
        {
            fixed (void* thisPtr = &this)
            fixed (char* pszKeyPtr = pszKey)
            {
                return ((delegate* unmanaged[Stdcall]<void*, char*, in IUnknown, HRESULT>)_vTable[9])(thisPtr, pszKeyPtr, punk);
            }
        }

        /// <summary>
        /// Retrieves an interface pointer to the object associated with the specified key in the bind context's string-keyed table of pointers.
        /// </summary>
        /// <param name="pszKey">
        /// The bind context string key to be searched for. Key string comparison is case-sensitive.
        /// </param>
        /// <param name="ppunk">
        /// The address of an <see cref="IUnknown"/> pointer variable that receives
        /// the interface pointer to the object associated with <paramref name="pszKey"/>.
        /// When successful, the implementation calls AddRef on <paramref name="ppunk"/>.
        /// It is the caller's responsibility to call Release.
        /// If an error occurs, the implementation sets <paramref name="ppunk"/> to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="S_OK"/>.
        /// Otherwise, it is <see cref="E_FAIL"/>.
        /// </returns>
        /// <remarks>
        /// A bind context maintains a table of interface pointers, each associated with a string key.
        /// This enables communication between a moniker implementation and the caller that initiated the binding operation.
        /// One party can store an interface pointer under a string known to both parties
        /// so that the other party can later retrieve it from the bind context.
        /// The pointer this method retrieves must have previously been inserted into the table using the <see cref="RegisterObjectParam"/> method.
        /// Notes to Callers
        /// Objects using monikers to locate other objects can call this method when a binding operation
        /// fails to get specific information about the error that occurred.
        /// Depending on the error, it may be possible to correct the situation and retry the binding operation.
        /// See <see cref="RegisterObjectParam"/> for more information.
        /// Moniker implementations can call this method to handle situations
        /// where a caller initiates a binding operation and requests specific information.
        /// By convention, the implementer should use key names that begin with the string form of the CLSID of a moniker class.
        /// (See the <see cref="StringFromCLSID"/> function.)
        /// </remarks>
        public HRESULT GetObjectParam([In] string pszKey, [Out] out IntPtr ppunk)
        {
            fixed (void* thisPtr = &this)
            fixed (char* pszKeyPtr = pszKey)
            {
                return ((delegate* unmanaged[Stdcall]<void*, char*, out IntPtr, HRESULT>)_vTable[10])(thisPtr, pszKeyPtr, out ppunk);
            }
        }


        /// <summary>
        /// Retrieves a pointer to an interface that can be used to enumerate the keys of the bind context's string-keyed table of pointers.
        /// </summary>
        /// <param name="ppenum">
        /// The address of an <see cref="IEnumString"/> pointer variable that receives the interface pointer to the enumerator. 
        /// If an error occurs, <paramref name="ppenum"/> is set to <see langword="null"/>.
        /// If <paramref name="ppenum"/> is non-NULL, the implementation calls AddRef on <paramref name="ppenum"/>;
        /// it is the caller's responsibility to call Release.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// The keys returned by the enumerator are the ones previously specified in calls to <see cref="RegisterObjectParam"/>.
        /// Notes to Callers
        /// A bind context maintains a table of interface pointers, each associated with a string key.
        /// This enables communication between a moniker implementation and the caller that initiated the binding operation.
        /// One party can store an interface pointer under a string known to both parties
        /// so that the other party can later retrieve it from the bind context.
        /// In the system implementation of the <see cref="IBindCtx"/> interface, this method is not implemented.
        /// Therefore, calling this method results in a return value of <see cref="E_NOTIMPL"/>.
        /// </remarks>
        public HRESULT EnumObjectParam([Out] out IntPtr ppenum)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out IntPtr, HRESULT>)_vTable[11])(thisPtr, out ppenum);
            }
        }

        /// <summary>
        /// Removes the specified key and its associated pointer from the bind context's string-keyed table of objects.
        /// The key must have previously been inserted into the table with a call to <see cref="RegisterObjectParam"/>.
        /// </summary>
        /// <param name="pszKey">
        /// The bind context string key to be removed.
        /// Key string comparison is case-sensitive.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>: The specified key was removed successfully. 
        /// <see cref="S_FALSE"/>: The object was not previously registered. 
        /// </returns>
        /// <remarks>
        /// A bind context maintains a table of interface pointers, each associated with a string key.
        /// This enables communication between a moniker implementation and the caller that initiated the binding operation.
        /// One party can store an interface pointer under a string known to both parties
        /// so that the other party can later retrieve it from the bind context.
        /// This method is used to remove an entry from the table.
        /// If the specified key is found, the bind context also releases its reference to the object.
        /// </remarks>

        public HRESULT RevokeObjectParam([In] string pszKey)
        {
            fixed (void* thisPtr = &this)
            fixed (char* pszKeyPtr = pszKey)
            {
                return ((delegate* unmanaged[Stdcall]<void*, char*, HRESULT>)_vTable[12])(thisPtr, pszKeyPtr);
            }
        }
    }
}
