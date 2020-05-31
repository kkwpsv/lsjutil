using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.CLSID;
using static Lsj.Util.Win32.Enums.STATFLAG;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="STATSTG"/> structure contains statistical data about an open storage, stream, or byte-array object.
    /// This structure is used in the <see cref="IEnumSTATSTG"/>, <see cref="ILockBytes"/>,
    /// <see cref="IStorage"/>, and <see cref="IStream"/> interfaces.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/ns-objidl-statstg
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct STATSTG
    {
        /// <summary>
        /// A pointer to a NULL-terminated Unicode string that contains the name.
        /// Space for this string is allocated by the method called and freed by the caller (for more information, see <see cref="CoTaskMemFree"/>).
        /// To not return this member, specify the <see cref="STATFLAG_NONAME"/> value when you call a method
        /// that returns a <see cref="STATSTG"/> structure, except for calls to <see cref="IEnumSTATSTG.Next"/>,
        /// which provides no way to specify this value.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pwcsName;

        /// <summary>
        /// Indicates the type of storage object.
        /// This is one of the values from the <see cref="STGTY"/> enumeration.
        /// </summary>
        public STGTY type;

        /// <summary>
        /// Specifies the size, in bytes, of the stream or byte array.
        /// </summary>
        public ULARGE_INTEGER cbSize;

        /// <summary>
        /// Indicates the last modification time for this storage, stream, or byte array.
        /// </summary>
        public FILETIME mtime;

        /// <summary>
        /// Indicates the creation time for this storage, stream, or byte array.
        /// </summary>
        public FILETIME ctime;

        /// <summary>
        /// Indicates the last access time for this storage, stream, or byte array.
        /// </summary>
        public FILETIME atime;

        /// <summary>
        /// Indicates the access mode specified when the object was opened.
        /// This member is only valid in calls to Stat methods.
        /// </summary>
        public STGM grfMode;

        /// <summary>
        /// Indicates the types of region locking supported by the stream or byte array.
        /// For more information about the values available, see the <see cref="LOCKTYPE"/> enumeration.
        /// This member is not used for storage objects.
        /// </summary>
        public LOCKTYPE grfLocksSupported;

        /// <summary>
        /// Indicates the class identifier for the storage object; set to <see cref="CLSID_NULL"/> for new storage objects.
        /// This member is not used for streams or byte arrays.
        /// </summary>
        public CLSID clsid;

        /// <summary>
        /// Indicates the current state bits of the storage object;
        /// that is, the value most recently set by the <see cref="IStorage.SetStateBits"/> method.
        /// This member is not valid for streams or byte arrays.
        /// </summary>
        public DWORD grfStateBits;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public DWORD reserved;
    }
}
