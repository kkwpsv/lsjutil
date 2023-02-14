using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.STGC;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IPropertyStorage"/> interface manages the persistent properties of a single property set.
    /// Persistent properties consist of information that can be stored persistently in a property set,
    /// such as the summary information associated with a file.
    /// This contrasts with run-time properties associated with Controls and Automation, which can be used to affect system behavior.
    /// Use the methods of the <see cref="IPropertySetStorage"/> interface to create or open a persistent property set.
    /// An instance of the <see cref="IPropertySetStorage"/> interface can manage zero or more <see cref="IPropertyStorage"/> instances.
    /// Each property within a property set is identified by a property identifier (ID), a four-byte ULONG value unique to that set.
    /// You can also assign a string name to a property through the <see cref="IPropertyStorage"/> interface.
    /// Property IDs differ from the dispatch IDs used in Automation dispid property name tags.
    /// One difference is that the general-purpose use of property ID values zero and one is prohibited in <see cref="IPropertyStorage"/>,
    /// while no such restriction exists in <see cref="IDispatch"/>.
    /// In addition, while there is significant overlap among the data types for property values
    /// that may be used in <see cref="IPropertyStorage"/> and <see cref="IDispatch"/>, the property sets are not identical.
    /// Persistent property data types used in <see cref="IPropertyStorage"/> methods are defined in the <see cref="PROPVARIANT"/> structure.
    /// The <see cref="IPropertyStorage"/> interface can be used to access both simple and nonsimple property sets.
    /// Nonsimple property sets can hold several complex property types that cannot be held in a simple property set.
    /// For more information see Storage and Stream Objects for a Property Set.
    /// </para>
    /// <para>
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/propidl/nn-propidl-ipropertystorage"/>
    /// </para>
    /// </summary>
    public unsafe struct IPropertyStorage
    {
        IntPtr* _vTable;

        /// <summary>
        /// The <see cref="Commit"/> method saves changes made to a property storage object to the parent storage object.
        /// </summary>
        /// <param name="grfCommitFlags">
        /// The flags that specify the conditions under which the commit is to be performed.
        /// For more information about specific flags and their meanings, see the Remarks section.
        /// </param>
        /// <returns>
        /// This method supports the standard return value <see cref="E_UNEXPECTED"/>, as well as the following:
        /// </returns>
        /// <remarks>
        /// Like <see cref="IStorage.Commit"/>, the <see cref="Commit"/> method ensures
        /// that any changes made to a property storage object are reflected in the parent storage.
        /// In direct mode in the compound file implementation, a call to this method causes any changes currently
        /// in the memory buffers to be flushed to the underlying property stream.
        /// In the compound-file implementation for nonsimple property sets, see cref="IStorage.Commit"/> is also called
        /// on the underlying substorage object with the passed <paramref name="grfCommitFlags"/> parameter.
        /// In transacted mode, this method causes the changes to be permanently reflected in the persistent image of the storage object.
        /// The changes that are committed must have been made to this property set since it was opened or since the last commit on this opening of the property set.
        /// The commit method publishes the changes made on one object level to the next level.
        /// Of course, this remains subject to any outer-level transaction that may be present on the object in which this property set is contained.
        /// Write permission must be specified when the property set is opened (through <see cref="IPropertySetStorage"/>)
        /// on the property set opening for the commit operation to succeed.
        /// If the commit operation fails for any reason, the state of the property storage object remains as it was before the commit.
        /// This call has no effect on existing storage- or stream-valued properties opened from this property storage, but it does commit them.
        /// Valid values for the <paramref name="grfCommitFlags"/> parameter are listed in the following table.
        /// <see cref="STGC_DEFAULT"/>:
        /// Commits per the usual transaction semantics.
        /// Last writer wins. This flag may not be specified with other flag values.
        /// <see cref="STGC_ONLYIFCURRENT"/>:
        /// Commits the changes only if the current persistent contents of the property set are the ones
        /// on which the changes about to be committed are based.
        /// That is, does not commit changes if the contents of the property set have been changed by a commit from another opening of the property set.
        /// The error <see cref="STG_E_NOTCURRENT"/> is returned if the commit does not succeed for this reason.
        /// <see cref="STGC_OVERWRITE"/>:
        /// Useful only when committing a transaction that has no further outer nesting level of transactions, though acceptable in all cases.
        /// Note  Indicates that the caller is willing to risk some data corruption at the expense of decreased disk usage on the destination volume.
        /// This flag is potentially useful in low disk-space scenarios, though it should be used with caution.
        /// Note  Using <see cref="Commit"/> to write properties to image files on Windows XP does not work.
        /// Affected image file formats include:
        /// .bmp
        /// .dib
        /// .emf
        /// .gif
        /// .ico
        /// .jfif
        /// .jpe
        /// .jpeg
        /// .jpg
        /// .png
        /// .rle
        /// .tiff
        /// .wmf
        /// Due to a bug in the image file property handler on Windows XP,
        /// calling <see cref="Commit"/> actually discards any changes made rather than persisting them.
        /// A workaround is to omit the call to <see cref="Commit"/>.
        /// Calling <see cref="IUnknown.Release"/> on the XP image file property handler
        /// without calling <see cref="Commit"/> first implicitly commits the changes to the file.
        /// Note that in general, calling <see cref="IUnknown.Release"/> without first calling <see cref="Commit"/> will discard any changes made;
        /// this workaround is specific to the image file property handler on Windows XP.
        /// Also note that on later versions of Windows, this component functions properly
        /// (that is, calling <see cref="Commit"/> persists changes and calling <see cref="IUnknown.Release"/> without calling <see cref="Commit"/> discards them).
        /// </remarks>
        public HRESULT Commit([In] STGC grfCommitFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, STGC, HRESULT>)_vTable[9])(thisPtr, grfCommitFlags);
            }
        }
    }
}
