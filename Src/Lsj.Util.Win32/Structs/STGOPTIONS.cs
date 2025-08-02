using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.STGFMT;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="STGOPTIONS"/> structure specifies features of the storage object, such as sector size,
    /// in the <see cref="StgCreateStorageEx"/> and <see cref="StgOpenStorageEx"/> functions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/coml2api/ns-coml2api-stgoptions"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="STGOPTIONS"/> is only supported on Unicode APIs.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct STGOPTIONS
    {
        /// <summary>
        /// STGOPTIONS_VERSION
        /// </summary>
        public const ushort STGOPTIONS_VERSION = 2;

        /// <summary>
        /// <para>
        /// Specifies the version of the <see cref="STGOPTIONS"/> structure.
        /// It is set to <see cref="STGOPTIONS_VERSION"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// When <see cref="usVersion"/> is set to 1, the <see cref="ulSectorSize"/> member can be set.
        /// This is useful when creating a large-sector documentation file.
        /// However, when <see cref="usVersion"/> is set to 1, the <see cref="pwcsTemplateFile"/> member cannot be used.
        /// </para>
        /// <para>
        /// In Windows 2000 and later: <see cref="STGOPTIONS_VERSION"/> can be set to 1 for version 1.
        /// </para>
        /// <para>
        /// In Windows XP and later: <see cref="STGOPTIONS_VERSION"/> can be set to 2 for version 2.
        /// </para>
        /// <para>
        /// For operating systems prior to Windows 2000: <see cref="STGOPTIONS_VERSION"/> will be set to 0 for version 0.
        /// </para>
        /// </summary>
        public USHORT usVersion;

        /// <summary>
        /// Reserved for future use; must be zero.
        /// </summary>
        public USHORT reserved;

        /// <summary>
        /// Specifies the sector size of the storage object. The default is 512 bytes.
        /// </summary>
        public ULONG ulSectorSize;

        /// <summary>
        /// <para>
        /// Specifies the name of a file whose Encrypted File System (EFS) metadata will be transferred to a newly created Structured Storage file.
        /// This member is valid only when <see cref="STGFMT_DOCFILE"/> is used with <see cref="StgCreateStorageEx"/>.
        /// </para>
        /// <para>
        /// In Windows XP and later:
        /// The <see cref="pwcsTemplateFile"/> member is only valid if version 2 or later is specified in the <see cref="usVersion"/> member.
        /// </para>
        /// </summary>
        public IntPtr pwcsTemplateFile;
    }
}
