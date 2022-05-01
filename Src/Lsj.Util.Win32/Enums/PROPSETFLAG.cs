using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using static Lsj.Util.Win32.Enums.VARENUM;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="PROPSETFLAG"/> constants define characteristics of a property set.
    /// The values, listed in the following table, are used in the grfFlags parameter of <see cref="IPropertySetStorage"/> methods,
    /// the <see cref="StgCreatePropStg"/> function, and the <see cref="StgOpenPropStg"/> function.
    /// </para>
    /// </summary>
    /// <remarks>
    /// These values can be set and checked using bitwise operations that determine how property sets are created and opened.
    /// Property sets are created using the <see cref="IPropertySetStorage.Create"/> method or the <see cref="StgCreatePropStg"/> function.
    /// They are opened using the <see cref="IPropertySetStorage.Open"/> method or the <see cref="StgOpenPropStg"/> function.
    /// It is recommended that property sets be created as Unicode by not setting the <see cref="PROPSETFLAG_ANSI"/> flag in the grfFlags parameter.
    /// It is also recommended that you avoid using <see cref="VT_LPSTR"/> values, and use <see cref="VT_LPWSTR"/> values instead.
    /// When the property set code page is Unicode, <see cref="VT_LPSTR"/> string values are converted to Unicode when stored,
    /// and converted back to multibyte string values when retrieved.
    /// When the code page of the property set is not Unicode, property names, <see cref="VT_BSTR"/> strings,
    /// and nonsimple property values are converted to multibyte strings when stored, and converted back to Unicode when retrieved,
    /// all using the current system ANSI code page.
    /// </remarks>
    [Flags]
    public enum PROPSETFLAG : uint
    {
        /// <summary>
        /// If left unspecified, by default only simple property values may be written to the property set.
        /// Using simple property values prevents property sets from being transacted in the compound file
        /// and stand-alone implementations of <see cref="IPropertySetStorage"/>.
        /// Non-e property values must be used for this purpose.
        /// </summary>
        PROPSETFLAG_DEFAULT = 0,

        /// <summary>
        /// If specified, nonsimple property values can be written to the property set and the property set is saved in a storage object.
        /// Non-simple property values include those with a <see cref="VARTYPE"/> of
        /// <see cref="VT_STORAGE"/>, <see cref="VT_STREAM"/>, <see cref="VT_STORED_OBJECT"/>, or <see cref="VT_STREAMED_OBJECT"/>.
        /// If this flag is not specified, non-simple types cannot be written into the property set.
        /// In the compound file and stand-alone implementations, property sets may be transacted only if <see cref="PROPSETFLAG_NONSIMPLE"/> is specified.
        /// </summary>
        PROPSETFLAG_NONSIMPLE = 1,

        /// <summary>
        /// If specified, all string values in the property set that are not explicitly Unicode, that is,
        /// those other than <see cref="VT_LPWSTR"/>, are stored with the current system ANSI code page.
        /// For more information, see <see cref="GetACP"/>.
        /// Use of this value is not recommended. For more information, see Remarks
        /// If this value is absent, string values in the new property set are stored in Unicode.
        /// The degree of control that this value provides is necessary so that clients using the property-related interfaces
        /// can interoperate with standard property sets such as the OLE2 summary information, which may exist in the ANSI code page.
        /// </summary>
        PROPSETFLAG_ANSI = 2,

        /// <summary>
        /// Used only with the <see cref="StgCreatePropStg"/> and <see cref="StgOpenPropStg"/> functions;
        /// that is, in the stand-alone implementations of property set interfaces.
        /// If specified in these functions, changes to the property set are not buffered.
        /// Instead, changes are always written directly to the property set.
        /// Calls to a property set <see cref="IPropertyStorage"/> methods will change it.
        /// However, by default, changes are buffered in an internal property set cache
        /// and are subsequently written to the property set when the <see cref="IPropertyStorage.Commit"/> method is called
        /// Setting <see cref="PROPSETFLAG_UNBUFFERED"/> decreases performance
        /// because the property set internal buffer is automatically flushed after every change to the property set.
        /// However, writing changes directly will prevent coordination problems.
        /// For example, if the storage object is opened in transacted mode, and the property set is buffered.
        /// Then, if you call the <see cref="IStorage.Commit"/> method on the storage object,
        /// the property set changes will not be picked up as part of the transaction,
        /// because they are in a buffer that has not been flushed yet.
        /// You must call <see cref="IPropertyStorage.Commit"/> prior to calling <see cref="IStorage.Commit"/>
        /// to flush the property set buffer before committing changes to the storage. 
        /// As an alternative to making two calls, you can set <see cref="PROPSETFLAG_UNBUFFERED"/>
        /// so that changes are always written directly to the property set and are never buffered in the property set's internal cache.
        /// Then, the changes will be picked up when the transacted storage is committed.
        /// </summary>
        PROPSETFLAG_UNBUFFERED = 4,

        /// <summary>
        /// If specified, property names are case sensitive.
        /// Case-sensitive property names are only possible in the version 1 property set serialization format.
        /// For more information, see Property Set Serialization.
        /// </summary>
        PROPSETFLAG_CASE_SENSITIVE = 8,
    }
}
