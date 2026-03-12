using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.FILE_ID_TYPE;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the type of ID that is being used.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-file_id_descriptor"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct FILE_ID_DESCRIPTOR
    {
        /// <summary>
        /// <para>
        /// <c>dwSize</c>
        /// </para>
        /// <para>
        /// The size of this <see cref="FILE_ID_DESCRIPTOR"/> structure.
        /// </para>
        /// </summary>
        [FieldOffset(0)]
        public DWORD dwSize;

        /// <summary>
        /// <para>
        /// The discriminator for the union indicating the type of identifier that is being passed.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FileIdType"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Use the <see cref="FileId"/> member of the union.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ObjectIdType"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Use the <see cref="ObjectId"/> member of the union.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ExtendedFileIdType"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Use the <see cref="ExtendedFileId"/> member of the union.
        /// </para>
        /// <para>
        /// Windows XP, Windows Server 2003, Windows Vista, Windows Server 2008, Windows 7 and Windows Server 2008 R2:
        /// This value is not supported before Windows 8 and Windows Server 2012.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        [FieldOffset(4)]
        public FILE_ID_TYPE Type;

        /// <summary>
        /// The ID of the file to open.
        /// </summary>
        [FieldOffset(8)]
        public LARGE_INTEGER FileId;

        /// <summary>
        /// The ID of the object to open.
        /// </summary>
        [FieldOffset(8)]
        public GUID ObjectId;

        /// <summary>
        /// <para>
        /// A <see cref="FILE_ID_128"/> structure containing the 128-bit file ID of the file.
        /// This is used on ReFS file systems.
        /// </para>
        /// <para>
        /// Windows XP, Windows Server 2003, Windows Vista, Windows Server 2008, Windows 7 and Windows Server 2008 R2:
        /// This member is not supported before Windows 8 and Windows Server 2012.
        /// </para>
        /// </summary>
        [FieldOffset(8)]
        public FILE_ID_128 ExtendedFileId;
    }
}
