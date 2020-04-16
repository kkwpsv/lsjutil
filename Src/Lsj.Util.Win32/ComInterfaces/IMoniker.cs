using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Enums.BIND_FLAGS;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables you to use a moniker object, which contains information that uniquely identifies a COM object.
    /// An object that has a pointer to the moniker object's <see cref="IMoniker"/> interface can locate, activate,
    /// and get access to the identified object without having any other specific information on
    /// where the object is actually located in a distributed system.
    /// Monikers are used as the basis for linking in COM. A linked object contains a moniker that identifies its source.
    /// When the user activates the linked object to edit it, the moniker is bound; this loads the link source into memory.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-imoniker
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IMoniker)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMoniker : IPersistStream
    {
        /// <summary>
        /// From <see cref="IPersist"/>, just make COM happy.
        /// </summary>
        /// <param name="pClassID"></param>
        /// <returns></returns>
        [PreserveSig]
        new HRESULT GetClassID([Out]out Guid pClassID);

        /// <summary>
        /// From <see cref="IPersistStream"/>, just make COM happy.
        /// </summary>
        /// <returns></returns>
        [PreserveSig]
        new HRESULT IsDirty();

        /// <summary>
        /// From <see cref="IPersistStream"/>, just make COM happy.
        /// </summary>
        /// <param name="pStm"></param>
        /// <returns></returns>
        [PreserveSig]
        new HRESULT Load([In]IStream pStm);

        /// <summary>
        /// From <see cref="IPersistStream"/>, just make COM happy.
        /// </summary>
        /// <param name="pStm"></param>
        /// <param name="fClearDirty"></param>
        /// <returns></returns>
        [PreserveSig]
        new HRESULT Save([In]IStream pStm, [In]BOOL fClearDirty);

        /// <summary>
        /// From <see cref="IPersistStream"/>, just make COM happy.
        /// </summary>
        /// <param name="pcbSize"></param>
        /// <returns></returns>
        [PreserveSig]
        new HRESULT GetSizeMax([Out]out ULARGE_INTEGER pcbSize);

        /// <summary>
        /// Binds to the specified object.
        /// The binding process involves finding the object, putting it into the running state if necessary,
        /// and providing the caller with a pointer to a specified interface on the identified object.
        /// </summary>
        /// <param name="pbc">
        /// A pointer to the <see cref="IBindCtx"/> interface on the bind context object, which is used in this binding operation.
        /// The bind context caches objects bound during the binding process, contains parameters that apply to all operations using the bind context,
        /// and provides the means by which the moniker implementation should retrieve information about its environment.
        /// </param>
        /// <param name="pmkToLeft">
        /// If the moniker is part of a composite moniker, pointer to the moniker to the left of this moniker.
        /// This parameter is primarily used by moniker implementers to enable cooperation between the various components of a composite moniker.
        /// Moniker clients should use NULL.
        /// </param>
        /// <param name="riidResult">
        /// The IID of the interface the client wishes to use to communicate with the object that the moniker identifies.
        /// </param>
        /// <param name="ppvResult">
        /// The address of pointer variable that receives the interface pointer requested in riid.
        /// Upon successful return, <paramref name="ppvResult"/> contains the requested interface pointer to the object the moniker identifies.
        /// When successful, the implementation must call AddRef on the moniker.
        /// It is the caller's responsibility to call Release.
        /// If an error occurs, <paramref name="ppvResult"/> should be <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The binding operation was successful.
        /// <see cref="MK_E_NOOBJECT"/>:
        /// The object identified by this moniker, or some object identified by the composite moniker of which this moniker is a part, could not be found.
        /// <see cref="MK_E_EXCEEDEDDEADLINE"/>:
        /// The binding operation could not be completed within the time limit specified by the bind context's <see cref="BIND_OPTS"/> structure.
        /// <see cref="MK_E_CONNECTMANUALLY"/>:
        /// The binding operation requires assistance from the end user.
        /// The most common reason for returning this value is that a password is needed or that a floppy needs to be mounted.
        /// When this value is returned, retrieve the moniker that caused the error
        /// with a call to <see cref="IBindCtx.GetObjectParam"/> with the key "ConnectManually".
        /// You can then call <see cref="GetDisplayName"/> to get the display name, display a dialog box that communicates the desired information,
        /// such as instructions to mount a floppy or a request for a password, and then retry the binding operation.
        /// <see cref="MK_E_INTERMEDIATEINTERFACENOTSUPPORTED"/>:
        /// An intermediate object was found but it did not support an interface required to complete the binding operation.
        /// For example, an item moniker returns this value if its container does not support the <see cref="IOleItemContainer"/> interface.
        /// <see cref="STG_E_ACCESSDENIED"/>:
        /// Unable to access the storage object.
        /// This method can also return the errors associated with the <see cref="IOleItemContainer.GetObject"/> method.
        /// </returns>
        /// <remarks>
        /// <see cref="BindToObject"/> implements the primary function of a moniker, which is to locate the object identified by the moniker
        /// and return a pointer to one of its interfaces.
        /// Notes to Callers
        /// If you are using a moniker as a persistent connection between two objects, you activate the connection by calling <see cref="BindToObject"/>.
        /// You typically call <see cref="BindToObject"/> during the following process:
        /// 1.Create a bind context object with a call to the <see cref="CreateBindCtx"/> function.
        /// 2.Call <see cref="BindToObject"/> using the moniker, retrieving a pointer to a desired interface on the identified object.
        /// 3.Release the bind context.
        /// 4.Through the acquired interface pointer, perform the desired operations on the object.
        /// 5.When finished with the object, release the object's interface pointer.
        /// The following code fragment illustrates these steps.
        /// <code>
        /// HRESULT hr;       // An error code
        /// IMoniker * pMnk;  // A previously acquired interface moniker
        /// 
        /// // Obtain an IBindCtx interface.
        /// IBindCtx * pbc; 
        /// hr = CreateBindCtx(NULL, &amp;pbc); 
        /// if (FAILED(hr)) exit(0);  // Handle errors here.
        /// 
        /// // Obtain an implementation of pCellRange. 
        /// ICellRange * pCellRange; 
        /// hr = pMnk->BindToObject(pbc, NULL, IID_ICellRange, &amp;pCellRange); 
        /// if (FAILED(hr)) exit(0);  // Handle errors here. 
        /// 
        /// // Use pCellRange here. 
        /// 
        /// // Release interfaces after use. 
        /// pbc->Release(); 
        /// pCellRange->Release(); 
        /// </code>
        /// You can also use the <see cref="BindMoniker"/> function when you intend only one binding operation
        /// and don't need to retain the bind context object.
        /// This helper function encapsulates the creation of the bind context, calling <see cref="BindToObject"/> and releasing the bind context.
        /// COM containers that support links to objects use monikers to locate and get access to the linked object
        /// but typically do not call <see cref="BindToObject"/> directly.
        /// Instead, when a user activates a link in a container, the link container usually calls <see cref="IOleObject.DoVerb"/>,
        /// using the link handler's implementation, which calls <see cref="BindToObject"/> on the moniker stored in the linked object
        /// (if it cannot handle the verb).
        /// Notes to Implementers
        /// What your implementation does depends on whether you expect your moniker to have a prefix that is,
        /// whether you expect the <paramref name="pmkToLeft"/> parameter to be <see langword="null"/> or not.
        /// For example, an item moniker, which identifies an object within a container, expects that <paramref name="pmkToLeft"/> identifies the container.
        /// An item moniker consequently uses pmkToLeft to request services from that container.
        /// If you expect your moniker to have a prefix, you should use the <paramref name="pmkToLeft"/> parameter
        /// (for example, calling <see cref="BindToObject"/> on it) to request services from the object it identifies.
        /// If you expect your moniker to have no prefix, your <see cref="BindToObject"/> implementation should first check
        /// the running object table (ROT) to see whether the object is already running.
        /// To acquire a pointer to the ROT, your implementation should call <see cref="IBindCtx.GetRunningObjectTable"/>
        /// on the <paramref name="pbc"/> parameter.
        /// You can then call the <see cref="IRunningObjectTable.GetObject"/> method to see if the current moniker has been registered in the ROT.
        /// If so, you can immediately call QueryInterface to get a pointer to the interface requested by the caller.
        /// When your <see cref="BindToObject"/> implementation binds to some object,
        /// it should use the pbc parameter to call <see cref="IBindCtx.RegisterObjectBound"/> to store a reference to the bound object in the bind context.
        /// This ensures that the bound object remains running until the bind context is released,
        /// which can avoid the expense of having a subsequent binding operation load it again later.
        /// If the bind context's <see cref="BIND_OPTS"/> structure specifies the <see cref="BIND_JUSTTESTEXISTENCE"/> flag,
        /// your implementation has the option of returning <see langword="null"/> in <paramref name="ppvResult"/>
        /// (although you can also ignore the flag and perform the complete binding operation).
        /// </remarks>
        [PreserveSig]
        HRESULT BindToObject([In]IBindCtx pbc, [In]IMoniker pmkToLeft, [MarshalAs(UnmanagedType.LPStruct)][In]Guid riidResult,
            [MarshalAs(UnmanagedType.Interface)][Out]out object ppvResult);

        /// <summary>
        /// Binds to the storage for the specified object.
        /// Unlike the <see cref="IMoniker.BindToObject"/> method, this method does not activate the object identified by the moniker.
        /// </summary>
        /// <param name="pbc">
        /// A pointer to the <see cref="IBindCtx"/> interface on the bind context object, which is used in this binding operation.
        /// The bind context caches objects bound during the binding process, contains parameters that apply to all operations using the bind context,
        /// and provides the means by which the moniker implementation should retrieve information about its environment.
        /// </param>
        /// <param name="pmkToLeft">
        /// If the moniker is part of a composite moniker, pointer to the moniker to the left of this moniker.
        /// This parameter is primarily used by moniker implementers to enable cooperation between the various components of a composite moniker.
        /// Moniker clients should use NULL.
        /// </param>
        /// <param name="riid">
        /// A reference to the identifier of the storage interface requested, whose pointer will be returned in <paramref name="ppvObj"/>.
        /// Storage interfaces commonly requested include <see cref="IStorage"/>, <see cref="IStream"/>, and <see cref="ILockBytes"/>.
        /// </param>
        /// <param name="ppvObj">
        /// The address of pointer variable that receives the interface pointer requested in <paramref name="riid"/>.
        /// Upon successful return, <paramref name="ppvObj"/> contains the requested interface pointer to the storage of the object the moniker identifies.
        /// When successful, the implementation must call AddRef on the storage. It is the caller's responsibility to call Release.
        /// If an error occurs, <paramref name="ppvObj"/> should be <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The binding operation was successful.
        /// <see cref="MK_E_NOSTORAGE"/>: The object identified by this moniker does not have its own storage.
        /// <see cref="MK_E_EXCEEDEDDEADLINE"/>:
        /// The binding operation could not be completed within the time limit specified by the bind context's <see cref="BIND_OPTS"/> structure.
        /// <see cref="MK_E_CONNECTMANUALLY"/>:
        /// The operation was unable to connect to the storage, possibly because a network device could not be connected to.
        /// For more information, see <see cref="BindToObject"/>.
        /// <see cref="MK_E_INTERMEDIATEINTERFACENOTSUPPORTED"/>:
        /// An intermediate object was found but it did not support an interface required to complete the binding operation.
        /// For example, an item moniker returns this value if its container does not support the <see cref="IOleItemContainer"/> interface.
        /// <see cref="STG_E_ACCESSDENIED"/>:
        /// Unable to access the storage object.
        /// This method can also return the errors associated with the <see cref="IOleItemContainer.GetObject"/> method.
        /// </returns>
        /// <remarks>
        /// There is an important difference between the <see cref="BindToObject"/> and <see cref="BindToStorage"/> methods.
        /// If, for example, you have a moniker that identifies a spreadsheet object,
        /// calling <see cref="BindToObject"/> provides access to the spreadsheet object itself,
        /// while calling <see cref="BindToStorage"/> provides access to the storage object in which the spreadsheet resides.
        /// Notes to Callers
        /// Although none of the COM moniker classes call this method in their binding operations,
        /// it might be appropriate to call it in the implementation of a new moniker class.
        /// You could call this method in an implementation of <see cref="BindToObject"/> that requires information from the object
        /// identified by the <paramref name="pmkToLeft"/> parameter and can get it from the persistent storage of the object without activation.
        /// For example, if your monikers are used to identify objects that can be activated without activating their containers,
        /// you may find this method useful.
        /// A client that can read the storage of the object its moniker identifies could also call this method.
        /// Notes to Implementers
        /// Your implementation should locate the persistent storage for the object identified by the current moniker
        /// and return the desired interface pointer.
        /// Some types of monikers represent pseudo-objects, which are objects that do not have their own persistent storage.
        /// Such objects comprise some portion of the internal state of its container as, for example, a range of cells in a spreadsheet.
        /// If your moniker class identifies this type of object,
        /// your implementation of <see cref="BindToStorage"/> should return the error <see cref="MK_E_NOSTORAGE"/>.
        /// If the bind context's <see cref="BIND_OPTS"/> structure specifies the <see cref="BIND_JUSTTESTEXISTENCE"/> flag,
        /// your implementation has the option of returning <see langword="null"/> in <paramref name="ppvObj"/>
        /// (although you can also ignore the flag and perform the complete binding operation).
        /// </remarks>
        [PreserveSig]
        HRESULT BindToStorage([In]IBindCtx pbc, [In]IMoniker pmkToLeft, [MarshalAs(UnmanagedType.LPStruct)][In]Guid riid,
            [MarshalAs(UnmanagedType.Interface)][Out]out object ppvObj);

        /// <summary>
        /// Reduces a moniker to its simplest form.
        /// </summary>
        /// <param name="pbc">
        /// A pointer to the <see cref="IBindCtx"/> interface on the bind context to be used in this binding operation.
        /// The bind context caches objects bound during the binding process, contains parameters that apply to all operations using the bind context,
        /// and provides the means by which the moniker implementation should retrieve information about its environment.
        /// </param>
        /// <param name="dwReduceHowFar">
        /// Specifies how far this moniker should be reduced.
        /// This parameter must be one of the values from the <see cref="MKRREDUCE"/> enumeration.
        /// </param>
        /// <param name="ppmkToLeft">
        /// On entry, a pointer to an <see cref="IMoniker"/> pointer variable that contains the interface pointer to moniker to the left of this moniker.
        /// This parameter is used primarily by moniker implementers to enable cooperation between the various components of a composite moniker;
        /// moniker clients can usually pass <see langword="null"/>.
        /// On return, <paramref name="ppmkToLeft"/> is usually set to <see langword="null"/>, indicating no change in the original moniker to the left.
        /// In rare situations, <paramref name="ppmkToLeft"/> indicates a moniker, indicating that the previous moniker to the left
        /// should be disregarded and the moniker returned through <paramref name="ppmkToLeft"/> is the replacement.
        /// In such a situation, the implementation must call Release on the old moniker to the left of this moniker
        /// and must call AddRef on the new returned moniker; the caller must release it later.
        /// If an error occurs, the implementation can either leave the interface pointer unchanged or set it to <see langword="null"/>.
        /// </param>
        /// <param name="ppmkReduced">
        /// A pointer to an <see cref="IMoniker"/> pointer variable that receives the interface pointer to the reduced form of this moniker,
        /// which can be <see langword="null"/> if an error occurs or if this moniker is reduced to nothing.
        /// If this moniker cannot be reduced, <paramref name="ppmkReduced"/> is simply set to this moniker
        /// and the return value is <see cref="MK_S_REDUCED_TO_SELF"/>.
        /// If <paramref name="ppmkReduced"/> is non-NULL, the implementation must call AddRef on the new moniker;
        /// it is the caller's responsibility to call Release. (This is true even if <paramref name="ppmkReduced"/> is set to this moniker.)
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="MK_S_REDUCED_TO_SELF"/>:
        /// This moniker could not be reduced any further, so <paramref name="ppmkReduced"/> indicates this moniker.
        /// <see cref="MK_E_EXCEEDEDDEADLINE"/>:
        /// The operation could not be completed within the time limit specified by the bind context's <see cref="BIND_OPTS"/> structure.
        /// </returns>
        /// <remarks>
        /// This method is intended for the following uses:
        /// Enable the construction of user-defined macros or aliases as new kinds of moniker classes.
        /// When reduced, the moniker to which the macro evaluates is returned.
        /// Enable the construction of a kind of moniker that tracks data as it moves about.
        /// When reduced, the moniker of the data in its current location is returned.
        /// On file systems that support an identifier-based method of accessing files that is independent of filenames;
        /// a file moniker could be reduced to a moniker which contains one of these identifiers.
        /// The intent of the <see cref="MKRREDUCE"/> flags passed in the <paramref name="dwReduceHowFar"/> parameter is
        /// to provide the ability to programmatically reduce a moniker to a form whose display name is recognizable to the user.
        /// For example, paths in the file system, bookmarks in word-processing documents, and range names in spreadsheets are all recognizable to users.
        /// In contrast, a macro or an alias encapsulated in a moniker are not recognizable to users.
        /// Notes to Callers
        /// The scenarios described above are not currently implemented by the system-supplied moniker classes.
        /// You should call Reduce before comparing two monikers using the <see cref="IsEqual"/> method
        /// because a reduced moniker is in its most specific form.
        /// <see cref="IsEqual"/> may return <see cref="S_FALSE"/> on two monikers
        /// before they are reduced and return <see cref="S_OK"/> after they are reduced.
        /// Notes to Implementers
        /// If the current moniker can be reduced, your implementation must not reduce the moniker in-place.
        /// Instead, it must return a new moniker that represents the reduced state of the current one.
        /// This way, the caller still has the option of using the nonreduced moniker (for example, enumerating its components).
        /// Your implementation should reduce the moniker at least as far as is requested.
        /// </remarks>
        [PreserveSig]
        HRESULT Reduce([In]IBindCtx pbc, [In]uint dwReduceHowFar, [MarshalAs(UnmanagedType.Interface)][In][Out]ref IMoniker ppmkToLeft,
            [MarshalAs(UnmanagedType.Interface)][Out]out IMoniker ppmkReduced);

        /// <summary>
        /// Creates a new composite moniker by combining the current moniker with the specified moniker.
        /// </summary>
        /// <param name="pmkRight">
        /// A pointer to the <see cref="IMoniker"/> interface on the moniker to compose onto the end of this moniker.
        /// </param>
        /// <param name="fOnlyIfNotGeneric">
        /// If <see langword="true"/>, the caller requires a nongeneric composition, so the operation should proceed
        /// only if <paramref name="pmkRight"/> is a moniker class that this moniker can compose with in some way other than forming a generic composite.
        /// If <see langword="false"/>, the method can create a generic composite if necessary.
        /// Most callers should set this parameter to <see langword="false"/>.
        /// </param>
        /// <param name="ppmkComposite">
        /// A pointer to an <see cref="IMoniker"/> pointer variable that receives the composite moniker pointer.
        /// When successful, the implementation must call AddRef on the resulting moniker; it is the caller's responsibility to call Release.
        /// If an error occurs or if the monikers compose to nothing (for example, composing an anti-moniker with an item moniker or a file moniker),
        /// <paramref name="ppmkComposite"/> should be set to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The monikers were successfully combined.
        /// <see cref="MK_E_NEEDGENERIC"/>:
        /// Indicates that <paramref name="fOnlyIfNotGeneric"/> was <see langword="true"/>,
        /// but the monikers could not be composed together without creating a generic composite moniker.
        /// </returns>
        /// <remarks>
        /// Joining two monikers together is called composition.
        /// Sometimes two monikers of the same class can be combined in what is called nongeneric composition.
        /// For example, a file moniker representing an incomplete path and another file moniker representing a relative path
        /// can be combined to form a single file moniker representing the complete path.
        /// Nongeneric composition for a given moniker class can be handled only in the implementation of <see cref="ComposeWith"/> for that moniker class.
        /// Combining two monikers of any class is called generic composition,
        /// which can be accomplished through a call to the <see cref="CreateGenericComposite"/> function.
        /// Composition of monikers is an associative operation.
        /// That is, if A, B, and C are monikers, then, where Comp() represents the composition operation,
        /// Comp( Comp( A, B ), C ) is always equal to Comp( A, Comp( B, C ) ).
        /// Notes to Callers
        /// To combine two monikers, you should call <see cref="ComposeWith"/> rather than
        /// calling the <see cref="CreateGenericComposite"/> function to give the first moniker a chance to perform a nongeneric composition.
        /// An object that provides item monikers to identify its objects would call <see cref="ComposeWith"/>
        /// to provide a moniker that completely identifies the location of the object.
        /// This would apply, for example, to a server that supports linking to portions of a document,
        /// or to a container that supports linking to embedded objects within its documents.
        /// In such a situation, you would do the following:
        /// Create an item moniker that identifies the object.
        /// Get a moniker that identifies the object's container.
        /// Call <see cref="ComposeWith"/> on the moniker identifying the container, passing the item moniker as the <paramref name="pmkRight"/> parameter.
        /// Notes to Implementers
        /// You can use either nongeneric or generic composition to compose the current moniker with the moniker that <paramref name="pmkRight"/> points to.
        /// If the class of the moniker indicated by <paramref name="pmkRight"/> is the same as that of the current moniker,
        /// it is possible to use the contents of <paramref name="pmkRight"/> to perform a more intelligent nongeneric composition.
        /// In writing a new moniker class, you must decide if there are any kinds of monikers, whether of your own class or another class,
        /// to which you want to give special treatment.
        /// If so, implement <see cref="ComposeWith"/> to check whether <paramref name="pmkRight"/> is a moniker of the type that should have this treatment.
        /// To do this, you can call the moniker's <see cref="IPersist.GetClassID"/> method,
        /// or if you have defined a moniker object that supports a custom interface, you can call QueryInterface on the moniker for that interface.
        /// An example of special treatment would be the nongeneric composition of an absolute file moniker with a relative file moniker.
        /// The most common case of a special moniker is the inverse for your moniker class
        /// (whatever you return from your implementation of <see cref="Inverse"/>).
        /// If <paramref name="pmkRight"/> completely negates the receiver so that the resulting composite is empty,
        /// you should pass back <see langword="null"/> in <paramref name="ppmkComposite"/> and return the status code <see cref="S_OK"/>.
        /// If the <paramref name="pmkRight"/> parameter is not of a class to which you give special treatment,
        /// examine <paramref name="fOnlyIfNotGeneric"/> to determine what to do next.
        /// If <paramref name="fOnlyIfNotGeneric"/> is <see langword="true"/>, pass back <see langword="null"/>
        /// through <paramref name="ppmkComposite"/> and return the status code <see cref="MK_E_NEEDGENERIC"/>.
        /// If <paramref name="fOnlyIfNotGeneric"/> is <see langword="false"/>,
        /// call the <see cref="CreateGenericComposite"/> function to perform the composition generically.
        /// </remarks>
        [PreserveSig]
        HRESULT ComposeWith([In]IMoniker pmkRight, [MarshalAs(UnmanagedType.Bool)]bool fOnlyIfNotGeneric, [Out]out IMoniker ppmkComposite);

        /// <summary>
        /// Retrieves a pointer to an enumerator for the components of a composite moniker.
        /// </summary>
        /// <param name="fForward">
        /// If <see langword="true"/>, enumerates the monikers from left to right.
        /// If <see langword="false"/>, enumerates from right to left.
        /// </param>
        /// <param name="ppenumMoniker">
        /// A pointer to an <see cref="IEnumMoniker"/> pointer variable that receives the interface pointer to the enumerator object for the moniker.
        /// When successful, the implementation must call AddRef on the enumerator object.
        /// It is the caller's responsibility to call Release.
        /// If an error occurs or if the moniker has no enumerable components,
        /// the implementation sets <paramref name="ppenumMoniker"/> to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/>, <see cref="E_UNEXPECTED"/>, and <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// This method must supply an <see cref="IEnumMoniker"/> pointer to an enumerator that can enumerate the components of a moniker.
        /// For example, the implementation of the <see cref="Enum"/> method for a generic composite moniker creates an enumerator
        /// that can determine the individual monikers that make up the composite, while the <see cref="Enum"/> method
        /// for a file moniker creates an enumerator that returns monikers representing each of the components in the path.
        /// Notes to Callers
        /// Call this method to examine the components that make up a composite moniker.
        /// Notes to Implementers
        /// If the new moniker class has no discernible internal structure, your implementation of this method can simply return <see cref="S_OK"/>
        /// and set <paramref name="ppenumMoniker"/> to <see langword="null"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT Enum([MarshalAs(UnmanagedType.Bool)][In]bool fForward, [Out]out IEnumMoniker ppenumMoniker);

        /// <summary>
        /// Determines whether this moniker is identical to the specified moniker.
        /// </summary>
        /// <param name="pmkOtherMoniker">
        /// A pointer to the <see cref="IMoniker"/> interface on the moniker to be used for comparison with this one
        /// (the one from which this method is called).
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> to indicate that the two monikers are identical, and <see cref="S_OK"/> otherwise.
        /// </returns>
        /// <remarks>
        /// Previous implementations of the running object table (ROT) called this method.
        /// The current implementation of the ROT uses the IROTData interface instead.
        /// Notes to Callers
        /// Call this method to determine whether two monikers are identical.
        /// The reduced form of a moniker is considered different from the unreduced form.
        /// You should call the <see cref="Reduce"/> method before calling <see cref="IsEqual"/>, because a reduced moniker is in its most specific form.
        /// <see cref="IsEqual"/> may return <see cref="S_FALSE"/> on two monikers before they are reduced, and <see cref="S_OK"/> after they are reduced.
        /// Notes to Implementers
        /// Your implementation should not reduce the current moniker before performing the comparison.
        /// It is the caller's responsibility to call <see cref="Reduce"/> to compare reduced monikers.
        /// Two monikers that compare as equal must hash to the same value using <see cref="Hash"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT IsEqual([In]IMoniker pmkOtherMoniker);

        /// <summary>
        /// Creates a hash value using the internal state of the moniker.
        /// </summary>
        /// <param name="pdwHash">
        /// A pointer to a variable that receives the hash value.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> to indicate that the hash value was retrieved successfully.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// You can use the value returned by this method to maintain a hash table of monikers.
        /// The hash value determines a hash bucket in the table.
        /// To search such a table for a specified moniker, calculate its hash value and then compare it to the monikers
        /// in that hash bucket using <see cref="IsEqual"/>.
        /// Notes to Implementers
        /// The hash value must be constant for the lifetime of the moniker.
        /// Two monikers that compare as equal using <see cref="IsEqual"/> must hash to the same value.
        /// Marshaling and then unmarshaling a moniker should have no effect on its hash value.
        /// Consequently, your implementation of <see cref="Hash"/> should rely only on the internal state of the moniker, not on its memory address.
        /// </remarks>
        [PreserveSig]
        HRESULT Hash(out uint pdwHash);

        /// <summary>
        /// Determines whether the object identified by this moniker is currently loaded and running.
        /// </summary>
        /// <param name="pbc">
        /// A pointer to the <see cref="IBindCtx"/> interface on the bind context to be used in this binding operation.
        /// The bind context caches objects bound during the binding process, contains parameters that apply to all operations using the bind context,
        /// and provides the means by which the moniker implementation should retrieve information about its environment.
        /// </param>
        /// <param name="pmkToLeft">
        /// A pointer to the <see cref="IMoniker"/> interface on the moniker to the left of this moniker if this moniker is part of a composite.
        /// This parameter is used primarily by moniker implementers to enable cooperation between the various components of a composite moniker;
        /// moniker clients can usually pass <see langword="null"/>.
        /// </param>
        /// <param name="pmkNewlyRunning">
        /// A pointer to the <see cref="IMoniker"/> interface on the moniker most recently added to the running object table (ROT).
        /// This can be <see langword="null"/>. If non-NULL, the implementation can return the results of calling <see cref="IsEqual"/>
        /// on the <paramref name="pmkNewlyRunning"/> parameter, passing the current moniker.
        /// This parameter is intended to enable <see cref="IsRunning"/> implementations that are more efficient than just searching the ROT,
        /// but the implementation can choose to ignore <paramref name="pmkNewlyRunning"/> without causing any harm.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The moniker is running.
        /// <see cref="S_FALSE"/>: The moniker is not running.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// If speed is important when you're requesting services from the object identified by the moniker,
        /// you may want those services only if the object is already running (because loading an object into the running state may be time-consuming).
        /// In such a situation, you should call <see cref="IsRunning"/> to determine whether the object is running.
        /// For the monikers stored within linked objects, IsRunning is primarily called
        /// by the default handler's implementation of <see cref="IOleLink.BindIfRunning"/>.
        /// Notes to Implementers
        /// To get a pointer to the ROT, your implementation should call <see cref="IBindCtx.GetRunningObjectTable"/> on the pbc parameter.
        /// Your implementation can then call <see cref="IRunningObjectTable.IsRunning"/> to determine whether the object identified
        /// by the moniker is running.
        /// The object identified by the moniker must have registered itself with the ROT when it first began running.
        /// </remarks>
        [PreserveSig]
        HRESULT IsRunning([In]IBindCtx pbc, [In]IMoniker pmkToLeft, [In]IMoniker pmkNewlyRunning);

        /// <summary>
        /// Retrieves the time at which the object identified by this moniker was last changed.
        /// </summary>
        /// <param name="pbc">
        /// A pointer to the bind context to be used in this binding operation.
        /// The bind context caches objects bound during the binding process, contains parameters that apply to all operations using the bind context,
        /// and provides the means by which the moniker implementation should retrieve information about its environment.
        /// For more information, see <see cref="IBindCtx"/>.
        /// </param>
        /// <param name="pmkToLeft">
        /// If the moniker is part of a composite moniker, pointer to the moniker to the left of this moniker.
        /// This parameter is primarily used by moniker implementers to enable cooperation between the various components of a composite moniker.
        /// Moniker clients should pass <see langword="null"/>.
        /// </param>
        /// <param name="pFileTime">
        /// A pointer to the <see cref="FILETIME"/> structure that receives the time of last change.
        /// A value of {0xFFFFFFFF,0x7FFFFFFF} indicates an error (for example, exceeded time limit, information not available).
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/>, as well as the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="MK_E_EXCEEDEDDEADLINE"/>:
        /// The binding operation could not be completed within the time limit specified by the bind context's <see cref="BIND_OPTS"/> structure.
        /// <see cref="MK_E_CONNECTMANUALLY"/>:
        /// The operation was unable to connect to the storage for this object, possibly because a network device could not be connected to.
        /// For more information, see <see cref="BindToObject"/>.
        /// <see cref="MK_E_UNAVAILABLE"/>:
        /// The time of the change is unavailable and will not be available regardless of the deadline that is used.
        /// </returns>
        /// <remarks>
        /// To be precise, the time returned is the earliest time COM can identify after which no change has occurred,
        /// so this time may be later than the time of the last change to the object.
        /// Notes to Callers
        /// If you're caching information returned by the object identified by the moniker, you may want to ensure that your information is up-to-date.
        /// To do so, you would call <see cref="GetTimeOfLastChange"/> and compare the time returned
        /// with the time you last retrieved information from the object.
        /// For the monikers stored within linked objects, <see cref="GetTimeOfLastChange"/> is primarily called
        /// by the default handler's implementation of <see cref="IOleObject.IsUpToDate"/>.
        /// Container applications call <see cref="IOleObject.IsUpToDate"/> to determine if a linked object
        /// (or an embedded object containing linked objects) is up-to-date without actually binding to the object.
        /// This enables an application to determine quickly which linked objects require updating when the end user opens a document.
        /// The application can then bind only those linked objects that need updating
        /// (after prompting the end user to determine whether they should be updated) instead of binding every linked object in the document.
        /// Notes to Implementers
        /// It is important to perform this operation quickly because, for linked objects, this method is called when a user first opens a compound document.
        /// Consequently, your <see cref="GetTimeOfLastChange"/> implementation should not bind to any objects.
        /// In addition, your implementation should check the deadline parameter in the bind context and return <see cref="MK_E_EXCEEDEDDEADLINE"/>
        /// if the operation cannot be completed by the specified time.
        /// Following are some strategies you can use in your implementations:
        /// For many types of monikers, the <paramref name="pmkToLeft"/> parameter identifies the container of the object identified by this moniker.
        /// If this is true of your moniker class, you can simply call <see cref="GetTimeOfLastChange"/> on the pmkToLeft parameter,
        /// because an object cannot have changed at a date later than its container.
        /// You can get a pointer to the running object table (ROT) by calling <see cref="IBindCtx.GetRunningObjectTable"/> on the pbc parameter
        /// and then calling <see cref="IRunningObjectTable.GetTimeOfLastChange"/>, because the ROT generally records the time of last change.
        /// You can get the storage associated with this moniker (or the <paramref name="pmkToLeft"/> moniker) and
        /// return the storage's last modification time with a call to <see cref="IStorage.Stat"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT GetTimeOfLastChange([In]IBindCtx pbc, [In]IMoniker pmkToLeft, [Out]out Structs.FILETIME pFileTime);

        /// <summary>
        /// Creates a moniker that is the inverse of this moniker.
        /// When composed to the right of this moniker or one of similar structure, the moniker will compose to nothing.
        /// </summary>
        /// <param name="ppmk">
        /// The address of an <see cref="IMoniker"/> pointer variable that receives the interface pointer to a moniker that is the inverse of this moniker.
        /// When successful, the implementation must call AddRef on the new inverse moniker.
        /// It is the caller's responsibility to call Release.
        /// If an error occurs, the implementation should set <paramref name="ppmk"/> to NULL.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/>, as well as the following values.
        /// <see cref="S_OK"/>: The inverse moniker has been returned successfully.
        /// <see cref="MK_E_NOINVERSE"/>: The moniker class does not have an inverse.
        /// </returns>
        /// <remarks>
        /// The inverse of a moniker is analogous to the ".." directory in MS-DOS file systems;
        /// the ".." directory acts as the inverse to any other directory name, because appending ".." to a directory name results in an empty path.
        /// In the same way, the inverse of a moniker typically is also the inverse of all monikers in the same class.
        /// However, it is not necessarily the inverse of a moniker of a different class.
        /// The inverse of a composite moniker is a composite consisting of the inverses of the components of the original moniker,
        /// arranged in reverse order.
        /// For example, if the inverse of A is Inv( A ) and the composite of A, B, and C is Comp( A, B, C ), then
        /// Inv( Comp( A, B, C ) ) is equal to Comp( Inv( C ), Inv( B ), Inv( A ) ).
        /// Not all monikers have inverses. Most monikers that are themselves inverses, such as anti-monikers, do not have inverses.
        /// Monikers that have no inverse cannot have relative monikers formed from inside the objects they identify to other objects outside.
        /// Notes to Callers
        /// An object that is using a moniker to locate another object usually does not know the class of the moniker it is using.
        /// To get the inverse of a moniker, you should always call <see cref="Inverse"/> rather than the <see cref="CreateAntiMoniker"/> function,
        /// because you cannot be certain that the moniker you're using considers an anti-moniker to be its inverse.
        /// The <see cref="Inverse"/> method is also called by the implementation of the <see cref="RelativePathTo"/> method,
        /// to assist in constructing a relative moniker.
        /// Notes to Implementers
        /// If your monikers have no internal structure, you can call the <see cref="CreateAntiMoniker"/> function in to get an anti-moniker
        /// in your implementation of <see cref="Inverse"/>. In your implementation of <see cref="ComposeWith"/>,
        /// you need to check for the inverse you supply in the implementation of <see cref="Inverse"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT Inverse([Out]out IMoniker ppmk);

        /// <summary>
        /// Creates a new moniker based on the prefix that this moniker has in common with the specified moniker.
        /// </summary>
        /// <param name="pmkOther">
        /// A pointer to the <see cref="IMoniker"/> interface on another moniker to be compared with this one to determine whether there is a common prefix.
        /// </param>
        /// <param name="ppmkPrefix">
        /// The address of an <see cref="IMoniker"/> pointer variable that receives the interface pointer to the moniker
        /// that is the common prefix of this moniker and <paramref name="pmkOther"/>.
        /// When successful, the implementation must call AddRef on the resulting moniker; it is the caller's responsibility to call Release.
        /// If an error occurs or if there is no common prefix, the implementation should set <paramref name="ppmkPrefix"/> to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/>, as well as the following values.
        /// <see cref="S_OK"/>: A common prefix exists that is neither this moniker nor <paramref name="pmkOther"/>.
        /// <see cref="MK_S_NOPREFIX"/>: No common prefix exists.
        /// <see cref="MK_S_HIM"/>: The entire <paramref name="pmkOther"/> is a prefix of this moniker.
        /// <see cref="MK_S_US"/>: The two monikers are identical.
        /// <see cref="MK_S_ME"/>: This moniker is a prefix of the <paramref name="pmkOther"/> moniker.
        /// <see cref="MK_S_NOTBINDABLE"/>:
        /// This method was called on a relative moniker. It is not meaningful to take the common prefix on a relative moniker.
        /// </returns>
        /// <remarks>
        /// <see cref="CommonPrefixWith"/> creates a new moniker that consists of the common prefixes of the moniker
        /// on this moniker object and another moniker.
        /// For example, if one moniker represents the path "c:\projects\secret\art\pict1.bmp" and another moniker represents
        /// the path "c:\projects\secret\docs\chap1.txt", the common prefix of these two monikers would be a moniker representing
        /// the path "c:\projects\secret".
        /// Notes to Callers
        /// The <see cref="CommonPrefixWith"/> method is primarily called in the implementation of the <see cref="RelativePathTo"/> method.
        /// Clients using a moniker to locate an object rarely need to call this method.
        /// Call this method only if <paramref name="pmkOther"/> and this moniker are both absolute monikers.
        /// An absolute moniker is either a file moniker or a generic composite whose leftmost component is a file moniker that represents an absolute path.
        /// Do not call this method on relative monikers because it would not produce meaningful results.
        /// Notes to Implementers
        /// Your implementation should first determine whether <paramref name="pmkOther"/> is a moniker of a class that you recognize
        /// and for which you can provide special handling (for example, if it is of the same class as this moniker).
        /// If so, your implementation should determine the common prefix of the two monikers.
        /// Otherwise, it should pass both monikers in a call to the <see cref="MonikerCommonPrefixWith"/> function,
        /// which correctly handles the generic case.
        /// </remarks>
        [PreserveSig]
        HRESULT CommonPrefixWith([In]IMoniker pmkOther, [Out]out IMoniker ppmkPrefix);

        /// <summary>
        /// Creates a relative moniker between this moniker and the specified moniker.
        /// </summary>
        /// <param name="pmkOther">
        /// A pointer to the <see cref="IMoniker"/> interface on the moniker to which a relative path should be taken.
        /// </param>
        /// <param name="ppmkRelPath">
        /// A pointer to an <see cref="IMoniker"/> pointer variable that receives the interface pointer to the relative moniker.
        /// When successful, the implementation must call AddRef on the new moniker; it is the caller's responsibility to call Release.
        /// If an error occurs, the implementation sets <paramref name="ppmkRelPath"/> to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="MK_S_HIM"/>: No common prefix is shared
        /// by the two monikers and the moniker returned in <paramref name="ppmkRelPath"/> is <paramref name="pmkOther"/>.
        /// <see cref="MK_E_NOTBINDABLE"/>:
        /// This moniker is a relative moniker, such as an item moniker.
        /// This moniker must be composed with the moniker of its container before a relative path can be determined.
        /// </returns>
        /// <remarks>
        /// A relative moniker is analogous to a relative path (such as "..\backup").
        /// For example, suppose you have one moniker that represents the path "c:\projects\secret\art\pict1.bmp" and
        /// another moniker that represents the path "c:\projects\secret\docs\chap1.txt".
        /// Calling <see cref="RelativePathTo"/> on the first moniker, passing the second one as the <paramref name="pmkOther"/> parameter,
        /// would create a relative moniker representing the path "..\docs\chap1.txt".
        /// Notes to Callers
        /// Moniker clients typically do not need to call <see cref="RelativePathTo"/>.
        /// This method is called primarily by the default handler for linked objects.
        /// Linked objects contain both an absolute and a relative moniker to identify the link source.
        /// (This enables link tracking if the user moves a directory tree containing both the container and source files.)
        /// The default handler calls this method to create a relative moniker from the container document to the link source.
        /// (That is, it calls RelativePathTo on the moniker identifying the container document,
        /// passing the moniker identifying the link source as the <paramref name="pmkOther"/> parameter.)
        /// If you do call <see cref="RelativePathTo"/>, call it only on absolute monikers”for example, a file moniker
        /// or a composite moniker whose leftmost component is a file moniker, where the file moniker represents an absolute path.
        /// Do not call this method on relative monikers.
        /// Notes to Implementers
        /// Your implementation of <see cref="RelativePathTo"/> should first determine whether <paramref name="pmkOther"/> is a moniker of a class
        /// that you recognize and for which you can provide special handling (for example, if it is of the same class as this moniker).
        /// If so, your implementation should determine the relative path.
        /// Otherwise, it should pass both monikers in a call to the <see cref="MonikerRelativePathTo"/> function, which correctly handles the generic case.
        /// The first step in determining a relative path is determining the common prefix of this moniker and <paramref name="pmkOther"/>.
        /// The next step is to break this moniker and <paramref name="pmkOther"/> into two parts each, say (P, myTail) and (P, otherTail) respectively,
        /// where P is the common prefix.
        /// The correct relative path is then the inverse of myTail composed with otherTail:
        /// Comp( Inv( myTail ), otherTail ) where Comp() represents the composition operation and Inv() represents the inverse operation.
        /// For certain types of monikers, you cannot use your IMoniker::Inverse method to construct the inverse of myTail.
        /// For example, a file moniker returns an anti-moniker as an inverse, while its <see cref="RelativePathTo"/> method
        /// must use one or more file monikers that each represent the path ".." to construct the inverse of myTail.
        /// </remarks>
        [PreserveSig]
        HRESULT RelativePathTo([In]IMoniker pmkOther, [Out]out IMoniker ppmkRelPath);

        /// <summary>
        /// Retrieves the display name for the moniker.
        /// </summary>
        /// <param name="pbc">
        /// A pointer to the <see cref="IBindCtx"/> interface on the bind context to be used in this operation.
        /// The bind context caches objects bound during the binding process, contains parameters that apply to all operations using the bind context,
        /// and provides the means by which the moniker implementation should retrieve information about its environment.
        /// </param>
        /// <param name="pmkToLeft">
        /// If the moniker is part of a composite moniker, pointer to the moniker to the left of this moniker.
        /// This parameter is used primarily by moniker implementers to enable cooperation between the various components of a composite moniker.
        /// Moniker clients should pass <see langword="null"/>.
        /// </param>
        /// <param name="ppszDisplayName">
        /// The address of a pointer variable that receives a pointer to the display name string for the moniker.
        /// The implementation must use <see cref="IMalloc.Alloc"/> to allocate the string returned in <paramref name="ppszDisplayName"/>,
        /// and the caller is responsible for calling <see cref="IMalloc.Free"/> to free it.
        /// Both the caller and the implementation of this method use the COM task allocator returned by <see cref="CoGetMalloc"/>.
        /// If an error occurs, the implementation must set <paramref name="ppszDisplayName"/> should be set to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/>, as well as the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="MK_E_EXCEEDEDDEADLINE"/>:
        /// The binding operation could not be completed within the time limit specified by the bind context's <see cref="BIND_OPTS"/> structure.
        /// <see cref="E_NOTIMPL"/>:
        /// There is no display name.
        /// </returns>
        /// <remarks>
        /// <see cref="GetDisplayName"/> provides a string that is a displayable representation of the moniker.
        /// A display name is not a complete representation of a moniker's internal state; it is simply a form that can be read by users.
        /// As a result, it is possible (though rare) for two different monikers to have the same display name.
        /// While there is no guarantee that the display name of a moniker can be parsed back into that moniker
        /// when calling the <see cref="MkParseDisplayName"/> function with it, failure to do so is rare.
        /// Notes to Callers
        /// It is possible that retrieving a moniker's display name may be an expensive operation.
        /// For efficiency, you may want to cache the results of the first successful call to <see cref="GetDisplayName"/>,
        /// rather than making repeated calls.
        /// Notes to Implementers
        /// If you are writing a moniker class in which the display name does not change, simply cache the display name
        /// and supply the cached name when requested.
        /// If the display name can change over time, getting the current display name might mean that the moniker
        /// has to access the object's storage or bind to the object, either of which can be expensive operations.
        /// If this is the case, your implementation of <see cref="GetDisplayName"/> should return <see cref="MK_E_EXCEEDEDDEADLINE"/>
        /// if the name cannot be retrieved by the time specified in the bind context's <see cref="BIND_OPTS"/> structure.
        /// A moniker that is intended to be part of a generic composite moniker should
        /// include any preceding delimiter (such as '') as part of its display name.
        /// For example, the display name returned by an item moniker includes the delimiter specified
        /// when it was created with the <see cref="CreateItemMoniker"/> function.
        /// The display name for a file moniker does not include a delimiter because file monikers are always expected to be
        /// the leftmost component of a composite.
        /// </remarks>
        [PreserveSig]
        HRESULT GetDisplayName([In]IBindCtx pbc, [In]IMoniker pmkToLeft, [MarshalAs(UnmanagedType.LPWStr)][Out]out string ppszDisplayName);

        /// <summary>
        /// Converts a display name into a moniker.
        /// </summary>
        /// <param name="pbc">
        /// A pointer to the IBindCtx interface on the bind context to be used in this binding operation.
        /// The bind context caches objects bound during the binding process, contains parameters that apply to all operations using the bind context,
        /// and provides the means by which the moniker implementation should retrieve information about its environment.
        /// </param>
        /// <param name="pmkToLeft">
        /// A pointer to the <see cref="IMoniker"/> interface on the moniker that has been built out of the display name up to this point.
        /// </param>
        /// <param name="pszDisplayName">
        /// The remaining display name to be parsed.
        /// </param>
        /// <param name="pchEaten">
        /// A pointer to a variable that receives the number of characters in <paramref name="pszDisplayName"/> that were consumed in this step.
        /// </param>
        /// <param name="ppmkOut">
        /// A pointer to an <see cref="IMoniker"/> pointer variable that receives the interface pointer to the moniker
        /// that was built from <paramref name="pszDisplayName"/>.
        /// When successful, the implementation must call AddRef on the new moniker; it is the caller's responsibility to call Release.
        /// If an error occurs, the implementation sets <paramref name="ppmkOut"/> to <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// This method can return the standard return values <see cref="E_OUTOFMEMORY"/> and <see cref="E_UNEXPECTED"/>, as well as the following values.
        /// <see cref="S_OK"/>: The parsing operation was completed successfully.
        /// <see cref="MK_E_SYNTAX"/>: An error in the syntax of the input components
        /// (<paramref name="pmkToLeft"/>, this moniker, and <paramref name="pszDisplayName"/>).
        /// For example, a file moniker returns this error if pmkToLeft is non-NULL,
        /// and an item moniker returns it if <paramref name="pmkToLeft"/> is NULL.
        /// This method can also return the errors associated with the <see cref="BindToObject"/> method.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// Moniker clients do not typically call ParseDisplayName directly.
        /// Instead, they call the <see cref="MkParseDisplayName"/> function when they want to convert a display name into a moniker
        /// (for example, in implementing the Links dialog box for a container application, 
        /// or for implementing a macro language that supports references to objects outside the document).
        /// That function first parses the initial portion of the display name itself.
        /// It then calls <see cref="ParseDisplayName"/> on the moniker it has just created,
        /// passing the remainder of the display name and getting a new moniker in return;
        /// this step is repeated until the entire display name has been parsed.
        /// Notes to Implementers
        /// Your implementation may be able to perform this parsing by itself if your moniker class is designed to designate only certain kinds of objects.
        /// Otherwise, you must get an <see cref="IParseDisplayName"/> interface pointer for the object identified by the moniker-so-far
        /// (that is, the composition of <paramref name="pmkToLeft"/> and this moniker) and
        /// then return the results of calling <see cref="IParseDisplayName.ParseDisplayName"/>.
        /// There are different strategies for getting an <see cref="IParseDisplayName"/> pointer, as follows:
        /// You can try to get the object's CLSID (by calling <see cref="IPersist.GetClassID"/> on the object) and then
        /// call the <see cref="CoGetClassObject"/> function, requesting the <see cref="IParseDisplayName"/> interface on the class factory
        /// associated with that CLSID.
        /// You can try to bind to the object itself to get an <see cref="IParseDisplayName"/> pointer.
        /// You can try binding to the object identified by <paramref name="pmkToLeft"/> to get an <see cref="IOleItemContainer"/> pointer
        /// and then call <see cref="IOleItemContainer.GetObject"/> to get an <see cref="IParseDisplayName"/> pointer for the item.
        /// Any objects that are bound should be registered with the bind context (see <see cref="IBindCtx.RegisterObjectBound"/>)
        /// to ensure that they remain running for the duration of the parsing operation.
        /// </remarks>
        [PreserveSig]
        HRESULT ParseDisplayName([In]IBindCtx pbc, [In]IMoniker pmkToLeft, [In][MarshalAs(UnmanagedType.LPWStr)]string pszDisplayName,
            [Out]out int pchEaten, [Out]out IMoniker ppmkOut);

        /// <summary>
        /// Determines whether this moniker is one of the system-provided moniker classes.
        /// </summary>
        /// <param name="pdwMksys">
        /// A pointer to a variables that receives one of the values from the <see cref="MKSYS"/> enumeration and refers to one of the COM moniker classes.
        /// This parameter cannot be <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> to indicate that the moniker is a system moniker, and <see cref="S_FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// Notes to Callers
        /// New values of the <see cref="MKSYS"/> enumeration may be defined in the future;
        /// therefore, you should explicitly test for each value you are interested in.
        /// Notes to Implementers
        /// Your implementation of this method must return <see cref="MKSYS_NONE"/>.
        /// You cannot use this function to identify your own monikers (for example, in your implementation of <see cref="ComposeWith"/>).
        /// Instead, you should use your moniker's implementation of <see cref="IPersist.GetClassID"/>
        /// or use <see cref="QueryInterface"/> to test for your own private interface.
        /// </remarks>
        [PreserveSig]
        HRESULT IsSystemMoniker([Out]out MKSYS pdwMksys);
    }
}
