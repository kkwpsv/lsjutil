using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// The <see cref="STATFLAG"/> enumeration values indicate whether the method should try to return a name
    /// in the <see cref="STATSTG.pwcsName"/> member of the <see cref="STATSTG"/> structure.
    /// The values are used in the <see cref="ILockBytes.Stat"/>, <see cref="IStorage.Stat"/>,
    /// and <see cref="IStream.Stat"/> methods to save memory when the <see cref="STATSTG.pwcsName"/> member is not required.
    /// </summary>
    public enum STATFLAG
    {
        /// <summary>
        /// Requests that the statistics include the <see cref="STATSTG.pwcsName"/> member of the <see cref="STATSTG"/> structure.
        /// </summary>
        STATFLAG_DEFAULT = 0,

        /// <summary>
        /// Requests that the statistics not include the <see cref="STATSTG.pwcsName"/> member of the <see cref="STATSTG"/> structure.
        /// If the name is omitted, there is no need for the <see cref="ILockBytes.Stat"/>, <see cref="IStorage.Stat"/>,
        /// and <see cref="IStream.Stat"/> methods methods to allocate and free memory for the string value of the name,
        /// therefore the method reduces time and resources used in an allocation and free operation.
        /// </summary>
        STATFLAG_NONAME = 1,

        /// <summary>
        /// Not implemented.
        /// </summary>
        STATFLAG_NOOPEN = 2
    }
}
