using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.ComInterfaces.IIDs;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides the CLSID of an object that can be stored persistently in the system.
    /// Allows the object to specify which object handler to use in the client process, as it is used in the default implementation of marshaling.
    /// IPersist is the base interface for three other interfaces: <see cref="IPersistStorage"/>,
    /// <see cref="IPersistStream"/>, and <see cref="IPersistFile"/>.
    /// Each of these interfaces, therefore, includes the <see cref="GetClassID"/> method,
    /// and the appropriate one of these three interfaces is implemented on objects that can be serialized to a storage, a stream, or a file.
    /// The methods of these interfaces allow the state of these objects to be saved for later instantiations, and load the object using the saved state.
    /// Typically, the persistence interfaces are implemented by an embedded or linked object,
    /// and are called by the container application or the default object handler.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-ipersist
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IPersist)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersist
    {
        /// <summary>
        /// Retrieves the class identifier (CLSID) of the object.
        /// </summary>
        /// <param name="pClassID">
        /// A pointer to the location that receives the CLSID on return.
        /// The CLSID is a globally unique identifier (GUID) that uniquely represents an object class that defines the code
        /// that can manipulate the object's data.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetClassID"/> method retrieves the class identifier (CLSID) for an object,
        /// used in later operations to load object-specific code into the caller's context.
        /// Notes to Callers
        /// A container application might call this method to retrieve the original CLSID of an object that it is treating as a different class.
        /// Such a call would be necessary if a user performed an editing operation that required the object to be saved.
        /// If the container were to save it using the treat-as CLSID, the original application would no longer be able to edit the object.
        /// Typically, in this case, the container calls the <see cref="OleSave"/> helper function, which performs all the necessary steps.
        /// For this reason, most container applications have no need to call this method directly.
        /// The exception would be a container that provides an object handler for certain objects.
        /// In particular, a container application should not get an object's CLSID and then use it to retrieve class specific information from the registry.
        /// Instead, the container should use <see cref="IOleObject"/> and <see cref="IDataObject"/> interfaces
        /// to retrieve such class-specific information directly from the object.
        /// Notes to Implementers
        /// Typically, implementations of this method simply supply a constant CLSID for an object.
        /// If, however, the object's TreatAs registry key has been set by an application that supports emulation
        /// (and so is treating the object as one of a different class),
        /// a call to <see cref="GetClassID"/> must supply the CLSID specified in the TreatAs key.
        /// For more information on emulation, see <see cref="CoTreatAsClass"/>.
        /// When an object is in the running state, the default handler calls an implementation of <see cref="GetClassID"/>
        /// that delegates the call to the implementation in the object.
        /// When the object is not running, the default handler instead calls the <see cref="ReadClassStg"/> function
        /// to read the CLSID that is saved in the object's storage.
        /// If you are writing a custom object handler for your object,
        /// you might want to simply delegate this method to the default handler implementation (see <see cref="OleCreateDefaultHandler"/>).
        /// URL Moniker Notes
        /// This method returns <see cref="CLSID_StdURLMoniker"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT GetClassID([Out]out Guid pClassID);
    }
}
