using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Discriminator for the union in the <see cref="FILE_ID_DESCRIPTOR"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ne-winbase-file_id_type"/>
    /// </para>
    /// </summary>
    public enum FILE_ID_TYPE
    {
        /// <summary>
        /// Use the <see cref="FILE_ID_DESCRIPTOR.FileId"/> member of the union.
        /// </summary>
        FileIdType,

        /// <summary>
        /// Use the <see cref="FILE_ID_DESCRIPTOR.ObjectId"/> member of the union.
        /// </summary>
        ObjectIdType,

        /// <para>
        /// Use the <see cref="FILE_ID_DESCRIPTOR.ExtendedFileId"/> member of the union.
        /// </para>
        /// <para>
        /// Windows XP, Windows Server 2003, Windows Vista, Windows Server 2008, Windows 7 and Windows Server 2008 R2:
        /// This value is not supported before Windows 8 and Windows Server 2012.
        /// </para>
        ExtendedFileIdType,

        /// <summary>
        /// This value is used for comparison only.
        /// All valid values are less than this value.
        /// </summary>
        MaximumFileIdType
    }
}
