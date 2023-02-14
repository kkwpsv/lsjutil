using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="GetUserObjectInformation"/> Indexes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getuserobjectinformationw"/>
    /// </para>
    /// </summary>
    public enum GetUserObjectInformationIndexes
    {
        /// <summary>
        /// The handle flags.
        /// The pvInfo parameter must point to a <see cref="USEROBJECTFLAGS"/> structure.
        /// </summary>
        UOI_FLAGS = 1,

        /// <summary>
        /// The size of the desktop heap, in KB, as a ULONG value.
        /// The hObj parameter must be a handle to a desktop object, otherwise, the function fails.
        /// Windows Server 2003 and Windows XP/2000:  This value is not supported.
        /// </summary>
        UOI_HEAPSIZE = 5,

        /// <summary>
        /// TRUE if the hObj parameter is a handle to the desktop object that is receiving input from the user. FALSE otherwise.
        /// Windows Server 2003 and Windows XP/2000:  This value is not supported.
        /// </summary>
        UOI_IO = 6,

        /// <summary>
        /// The name of the object, as a string.
        /// </summary>
        UOI_NAME = 2,

        /// <summary>
        /// The type name of the object, as a string.
        /// </summary>
        UOI_TYPE = 3,

        /// <summary>
        /// The <see cref="SID"/> structure that identifies the user that is currently associated with the specified object.
        /// If no user is associated with the object, the value returned in the buffer pointed to by lpnLengthNeeded is zero.
        /// Note that <see cref="SID"/> is a variable length structure.
        /// You will usually make a call to <see cref="GetUserObjectInformation"/> to determine the length
        /// of the <see cref="SID"/> before retrieving its value.
        /// </summary>
        UOI_USER_SID = 4,
    }
}
