using Lsj.Util.Win32.ComInterfaces;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Enums.STGM;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="STGFMT"/> enumeration values specify the format of a storage object
    /// and are used in the <see cref="StgCreateStorageEx"/> and <see cref="StgOpenStorageEx"/> functions in the stgfmt parameter.
    /// This value, in combination with the value in the riid parameter, is used to determine the file format and the interface implementation to use.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/aa380330(v=vs.85)"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the <see cref="STGFMT"/> value, specified to the <see cref="StgCreateStorageEx"/> or <see cref="StgOpenStorageEx"/> function,
    /// is <see cref="STGFMT_FILE"/>, the riid parameter must be the header-defined value for <see cref="IID_IPropertySetStorage"/>.
    /// It is not possible to get an <see cref="IStorage"/> interface for noncompound files.
    /// Similarly, if the <see cref="STGFMT_ANY"/> flag is specified to <see cref="StgOpenStorageEx"/>,
    /// and the file is not a compound file, the riid parameter must be <see cref="IID_IPropertySetStorage"/>.
    /// Note
    /// The <see cref="STGM"/> Constants values <see cref="STGM_CONVERT"/>, <see cref="STGM_DELETEONRELEASE"/>, <see cref="STGM_PRIORITY"/>,
    /// <see cref="STGM_SIMPLE"/>, and <see cref="STGM_TRANSACTED"/> cannot currently be used in the following situations.
    /// In combination with the <see cref="STGFMT_FILE"/> flag.
    /// In combination with the <see cref="STGFMT_ANY"/> flag if the file is not a compound file.
    /// </remarks>
    public enum STGFMT : uint
    {
        /// <summary>
        /// Indicates that the file must be a compound file.
        /// </summary>
        STGFMT_STORAGE = 0,

        /// <summary>
        /// 
        /// </summary>
        STGFMT_NATIVE = 1,

        /// <summary>
        /// Indicates that the file must not be a compound file.
        /// This element is only valid when using the <see cref="StgCreateStorageEx"/> or <see cref="StgOpenStorageEx"/> functions
        /// to access the NTFS file system implementation of the <see cref="IPropertySetStorage"/> interface.
        /// Therefore, these functions return an error if the riid parameter does not specify the <see cref="IPropertySetStorage"/> interface,
        /// or if the specified file is not located on an NTFS file system volume.
        /// </summary>
        STGFMT_FILE = 3,

        /// <summary>
        /// ndicates that the system will determine the file type and use the appropriate structured storage or property set implementation.
        /// This value cannot be used with the <see cref="StgCreateStorageEx"/> function.
        /// </summary>
        STGFMT_ANY = 4,

        /// <summary>
        /// Indicates that the file must be a compound file, and is similar to the <see cref="STGFMT_STORAGE"/> flag,
        /// but indicates that the compound-file form of the compound-file implementation must be used.
        /// For more information, see Compound File Implementation Limits.
        /// </summary>
        STGFMT_DOCFILE = 5,
    }
}
