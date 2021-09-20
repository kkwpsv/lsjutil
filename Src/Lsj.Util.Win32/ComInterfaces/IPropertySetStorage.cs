using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.STGM;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IPropertySetStorage"/> interface creates, opens, deletes, and enumerates property set storages
    /// that support instances of the <see cref="IPropertyStorage"/> interface.
    /// The <see cref="IPropertyStorage"/> interface manages a single property set in a property storage subobject;
    /// and the <see cref="IPropertySetStorage"/> interface manages the storage of groups of such property sets.
    /// Any file system entity can support <see cref="IPropertySetStorage"/> that is currently implemented in the COM compound file object.
    /// The <see cref="IPropertySetStorage"/> and <see cref="IPropertyStorage"/> interfaces provide a uniform way to create and manage property sets,
    /// whether or not these sets reside in a storage object that supports <see cref="IStorage"/>.
    /// When called through an object supporting <see cref="IStorage"/> (such as structured and compound files) or <see cref="IStream"/>,
    /// the property sets created conform to the COM property set format, described in detail in Structured Storage Serialized Property Set Format.
    /// Similarly, properties written using <see cref="IStorage"/> to the COM property set format
    /// are visible through <see cref="IPropertySetStorage"/> and <see cref="IPropertyStorage"/>.
    /// <see cref="IPropertySetStorage"/> methods identify property sets through a globally unique identifier (GUID) called a format identifier (<see cref="FMTID"/>).
    /// The <see cref="FMTID"/> for a property set identifies the property identifiers in the property set, their meaning, and any constraints on the values.
    /// The <see cref="FMTID"/> of a property set should also provide the means to manipulate that property set.
    /// Only one instance of a given FMTID may exist at a time within a single property storage.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/propidl/nn-propidl-ipropertysetstorage"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// There is an exception to the above in The DocumentSummaryInformation and UserDefined property set.
    /// This property set is unique in that it may have two property set sections in a single underlying stream.
    /// This property set is described in The DocumentSummaryInformation and UserDefined Property Sets.
    /// The first section is the DocumentSummaryInformation property set.
    /// The second section is the UserDefined property set. Each section is identified by a unique format identifier (<see cref="FMTID"/>).
    /// For example, <see cref="FMTID_DocSummaryInformation"/> and <see cref="FMTID_UserDefined"/> property set.
    /// The fact that these two property sets can exist in a single stream affects the behavior of the <see cref="IPropertySetStorage"/> interface.
    /// When <see cref="Create"/> is called to create the UserDefined property set, the first section is created automatically.
    /// Once the <see cref="FMTID_UserDefinedProperties"/> is created, <see cref="FMTID_DocSummaryInformation"/> need not be created,
    /// but can be opened with a call to <see cref="Open"/>.
    /// Creating the first section does not automatically create the second section and it is not possible to open both sections simultaneously.
    /// Calling <see cref="Delete"/>, to delete the first section, causes both sections to be deleted.
    /// In other words, calling <see cref="Delete"/> with <see cref="FMTID_DocSummaryInformation"/> causes
    /// both that section and the <see cref="FMTID_UserDefinedProperties"/> section to be deleted.
    /// However, deleting the second section does not automatically delete the first section.
    /// When <see cref="IPropertySetStorage.Enum"/> is used to enumerate property sets, the UserDefined property set is not enumerated.
    /// </remarks>
    public unsafe struct IPropertySetStorage
    {
        IntPtr* _vTable;

        /// <summary>
        /// The <see cref="Create"/> method creates and opens a new property set in the property set storage object.
        /// </summary>
        /// <param name="rfmtid">
        /// The <see cref="FMTID"/> of the property set to be created
        /// For information about FMTIDs that are well-known and predefined in the Platform SDK, see Predefined Property Set Format Identifiers.
        /// </param>
        /// <param name="pclsid">
        /// A pointer to the initial class identifier <see cref="CLSID"/> for this property set.
        /// May be <see cref="NullRef{CLSID}"/>, in which case it is set to all zeroes.
        /// The <see cref="CLSID"/> is the <see cref="CLSID"/> of a class that displays and/or provides programmatic access to the property values.
        /// If there is no such class, it is recommended that the <see cref="FMTID"/> be used.
        /// </param>
        /// <param name="grfFlags">
        /// The values from <see cref="PROPSETFLAG"/> Constants.
        /// </param>
        /// <param name="grfMode">
        /// An access mode in which the newly created property set is to be opened, taken from certain values of STGM_Constants,
        /// as described in the following Remarks section.
        /// </param>
        /// <param name="ppprstg">
        /// A pointer to the output variable that receives the <see cref="IPropertyStorage"/> interface pointer.
        /// </param>
        /// <returns>
        /// This method supports the standard return value <see cref="E_UNEXPECTED"/>, as well as the following:
        /// </returns>
        /// <remarks>
        /// <see cref="Create"/> creates and opens a new property set subobject (supporting the <see cref="IPropertyStorage"/> interface)
        /// contained in this property set storage object.
        /// The property set automatically contains code page and locale ID properties.
        /// These are set to the Unicode and the current user default, respectively.
        /// The <paramref name="grfFlags"/> parameter is a combination of values taken from <see cref="PROPSETFLAG"/> Constants.
        /// If the <see cref="PROPSETFLAG_ANSI"/> value from this enumeration is used,
        /// the code page is set to the current system default, rather than Unicode.
        /// The <paramref name="grfMode"/> parameter specifies the access mode in which the newly created set is to be opened.
        /// Values for this parameter are as in the <paramref name="grfMode"/> parameter to <see cref="Open"/>,
        /// with the addition of the values listed in the following table.
        /// <see cref="STGM_FAILIFTHERE"/>:
        /// If another property set with the specified fmtid parameter exists, the call fails.
        /// This is the default action; that is, unless <see cref="STGM_CREATE"/> is specified, <see cref="STGM_FAILIFTHERE"/> is implied.
        /// <see cref="STGM_CREATE"/>:
        /// If another property set with the specified fmtid parameter already exists, it is removed and replaced with this new one.
        /// The created property set is simple by default, but the caller may request a nonsimple property set
        /// by specifying the <see cref="PROPSETFLAG_NONSIMPLE"/> value in the <paramref name="grfFlags"/> parameter.
        /// For more information about simple and nonsimple property sets, see Storage and Stream Objects for a Property Set.
        /// This method is subject to the constraints of the underlying <see cref="IStorage.CreateStream"/>(for simple property sets)
        /// or <see cref="IStorage.CreateStorage"/> (for nonsimple property sets).
        /// For example, when using the IPropertySetStorage-Compound File Implementation,
        /// specify <see cref="STGM_SHARE_EXCLUSIVE"/> in the <paramref name="grfMode"/> parameter to <see cref="Create"/>.
        /// Conversely, if using the IPropertySetStorage-Stand-alone Implementation,
        /// <see cref="Create"/> is subject to constraints that apply to the caller-specified <see cref="IStorage"/>.
        /// </remarks>
        public HRESULT Create([In] in FMTID rfmtid, [In] in CLSID pclsid, [In] PROPSETFLAG grfFlags, [In] STGM grfMode, [Out] out P<IPropertyStorage> ppprstg)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in FMTID, in CLSID, PROPSETFLAG, STGM, out P<IPropertyStorage>, HRESULT>)_vTable[3])
                    (thisPtr, rfmtid, pclsid, grfFlags, grfMode, out ppprstg);
            }
        }

        /// <summary>
        /// The <see cref="Delete"/> method deletes one of the property sets contained in the property set storage object.
        /// </summary>
        /// <param name="rfmtid">
        /// <see cref="FMTID"/> of the property set to be deleted.
        /// </param>
        /// <returns>
        /// This method supports the standard return value <see cref="E_UNEXPECTED"/>, in addition to the following:
        /// </returns>
        /// <remarks>
        /// <see cref="Delete"/> deletes the property set specified by its <see cref="FMTID"/>.
        /// Specifying a property set that does not exist returns an error.
        /// Open substorages and streams(opened through one of the storage- or stream-valued properties) are put into the reverted state.
        /// </remarks>
        public HRESULT Delete([In] in FMTID rfmtid)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in FMTID, HRESULT>)_vTable[5])(thisPtr, rfmtid);
            }
        }
    }
}
