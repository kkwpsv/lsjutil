using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.Urlmon;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables the saving and loading of objects that use a simple serial stream for their storage needs.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-ipersiststream"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// One way in which this interface is used is to support OLE moniker implementations.
    /// Each of the OLE-provided moniker interfaces provides an <see cref="IPersistStream"/> implementation through which the moniker saves or loads itself.
    /// An instance of the OLE generic composite moniker class calls the <see cref="IPersistStream"/> methods of its component monikers
    /// to load or save the components in the proper sequence in a single stream.
    /// <see cref="IPersistStream"/> URL Moniker Implementation
    /// The URL moniker implementation of <see cref="IPersistStream"/> is found on an URL moniker object,
    /// which supports <see cref="IUnknown"/>, <see cref="IAsyncMoniker"/>, and <see cref="IMoniker"/>.
    /// The <see cref="IMoniker"/> interface inherits its definition from <see cref="IPersistStream"/> and thus,
    /// the URL moniker also provides an implementation of <see cref="IPersistStream"/> as part of its implementation of <see cref="IMoniker"/>.
    /// The <see cref="IAsyncMoniker"/> interface on an URL moniker is simply <see cref="IUnknown"/> (there are no additional methods);
    /// it is used to allow clients to determine if a moniker supports asynchronous binding.
    /// To get a pointer to the <see cref="IMoniker"/> interface on this object, call the <see cref="CreateURLMonikerEx"/> function.
    /// Then, to get a pointer to <see cref="IPersistStream"/>, call the QueryInterface method.
    /// <see cref="IPersistStream"/>, in addition to inheriting its definition from <see cref="IUnknown"/>,
    /// also inherits the single method of <see cref="IPersist"/>, <see cref="GetClassID"/>.
    /// </remarks>
    public unsafe struct IPersistStream
    {
        IntPtr* _vTable;

        /// <summary>
        /// Determines whether an object has changed since it was last saved to its stream.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> to indicate that the object has changed.
        /// Otherwise, it returns <see cref="S_FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Use this method to determine whether an object should be saved before closing it.
        /// The dirty flag for an object is conditionally cleared in the <see cref="Save"/> method.
        /// Notes to Callers
        /// You should treat any error return codes as an indication that the object has changed.
        /// Unless this method explicitly returns <see cref="S_FALSE"/>, assume that the object must be saved.
        /// Note that the OLE-provided implementations of the <see cref="IsDirty"/> method
        /// in the OLE-provided moniker interfaces always return <see cref="S_FALSE"/> because their internal state never changes.
        /// </remarks>
        public HRESULT IsDirty()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[4])(thisPtr);
            }
        }

        /// <summary>
        /// Initializes an object from the stream where it was saved previously.
        /// </summary>
        /// <param name="pStm">
        /// An <see cref="IStream"/> pointer to the stream from which the object should be loaded.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="E_OUTOFMEMORY"/>: The object was not loaded due to lack of memory.
        /// <see cref="E_FAIL"/>: The object was not loaded due to some reason other than a lack of memory.
        /// </returns>
        /// <remarks>
        /// This method loads an object from its associated stream.
        /// The seek pointer is set as it was in the most recent <see cref="Save"/> method.
        /// This method can seek and read from the stream, but cannot write to it.
        /// Notes to Callers
        /// Rather than calling <see cref="Load"/> directly, you typically call the <see cref="OleLoadFromStream"/> function does the following:
        /// Calls the <see cref="ReadClassStm"/> function to get the class identifier from the stream.
        /// Calls the <see cref="CoCreateInstance"/> function to create an instance of the object.
        /// Queries the instance for <see cref="IPersistStream"/>.
        /// Calls see cref="Load"/>.
        /// The <see cref="OleLoadFromStream"/> function assumes that objects are stored in the stream with a class identifier followed by the object data.
        /// This storage pattern is used by the generic, composite-moniker implementation provided by OLE.
        /// If the objects are not stored using this pattern, you must call the methods separately yourself.
        /// URL Moniker Notes
        /// Initializes an URL moniker from data within a stream, usually stored there previously
        /// using its <see cref="Save"/>(using <see cref="OleSaveToStream"/>).
        /// The binary format of the URL moniker is its URL string in Unicode
        /// (may be a full or partial URL string, see <see cref="CreateURLMonikerEx"/> for details).
        /// This is represented as a <see cref="ULONG"/> count of characters followed by that many Unicode characters.
        /// </remarks>
        public HRESULT Load([In] in IStream pStm)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IStream, HRESULT>)_vTable[5])(thisPtr, pStm);
            }
        }

        /// <summary>
        /// Saves an object to the specified stream.
        /// </summary>
        /// <param name="pStm">
        /// An <see cref="IStream"/> pointer to the stream into which the object should be saved.
        /// </param>
        /// <param name="fClearDirty">
        /// Indicates whether to clear the dirty flag after the save is complete.
        /// If <see cref="TRUE"/>, the flag should be cleared.
        /// If <see cref="FALSE"/>, the flag should be left unchanged.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="STG_E_CANTSAVE"/>:
        /// The object could not save itself to the stream.
        /// This error could indicate, for example, that the object contains another object that is not serializable to a stream
        /// or that an <see cref="ISequentialStream.Write"/> call returned <see cref="STG_E_CANTSAVE"/>.
        /// <see cref="STG_E_MEDIUMFULL"/>: The object could not be saved because there is no space left on the storage device.
        /// </returns>
        /// <remarks>
        /// <see cref="Save"/> saves an object into the specified stream and indicates whether the object should reset its dirty flag.
        /// The seek pointer is positioned at the location in the stream at which the object should begin writing its data.
        /// The object calls the <see cref="ISequentialStream.Write"/> method to write its data.
        /// On exit, the seek pointer must be positioned immediately past the object data.
        /// The position of the seek pointer is undefined if an error returns.
        /// Notes to Callers
        /// Rather than calling <see cref="Save"/> directly, you typically call the <see cref="OleSaveToStream"/> helper function which does the following:
        /// Calls <see cref="GetClassID"/> to get the object's CLSID.
        /// Calls the <see cref="WriteClassStm"/> function to write the object's CLSID to the stream.
        /// Calls <see cref="Save"/>.
        /// If you call these methods directly, you can write other data into the stream after the CLSID before calling <see cref="Save"/>.
        /// The OLE-provided implementation of <see cref="IPersistStream"/> follows this same pattern.
        /// Notes to Implementers
        /// The <see cref="Save"/> method does not write the CLSID to the stream. The caller is responsible for writing the CLSID.
        /// The <see cref="Save"/> method can read from, write to, and seek in the stream;
        /// but it must not seek to a location in the stream before that of the seek pointer on entry.
        /// URL Moniker Notes
        /// Saves an URL moniker to a stream.The binary format of URL moniker is its URL string in Unicode
        /// (may be a full or partial URL string, see <see cref="CreateURLMonikerEx"/> for details).
        /// This is represented as a <see cref="ULONG"/> count of characters followed by that many Unicode characters.
        /// </remarks>
        public HRESULT Save([In] in IStream pStm, [In] BOOL fClearDirty)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IStream, BOOL, HRESULT>)_vTable[6])(thisPtr, pStm, fClearDirty);
            }
        }

        /// <summary>
        /// Retrieves the size of the stream needed to save the object.
        /// </summary>
        /// <param name="pcbSize">
        /// The size in bytes of the stream needed to save this object, in bytes.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> to indicate that the size was retrieved successfully.
        /// </returns>
        /// <remarks>
        /// This method returns the size needed to save an object.
        /// You can call this method to determine the size and set the necessary buffers before calling the <see cref="Save"/> method.
        /// Notes to Implementers
        /// The <see cref="GetSizeMax"/> implementation should return a conservative estimate of the necessary size
        /// because the caller might call the <see cref="Save"/> method with a non-growable stream.
        /// URL Moniker Notes
        /// This method retrieves the maximum number of bytes in the stream that will be required by a subsequent call to <see cref="Save"/>.
        /// This value is sizeof(ULONG)==4 plus sizeof(WCHAR)*n where n is the length
        /// of the full or partial URL string, including the <see cref="NULL"/> terminator.
        /// </remarks>
        public HRESULT GetSizeMax([Out] out ULARGE_INTEGER pcbSize)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out ULARGE_INTEGER, HRESULT>)_vTable[7])(thisPtr, out pcbSize);
            }
        }
    }
}
