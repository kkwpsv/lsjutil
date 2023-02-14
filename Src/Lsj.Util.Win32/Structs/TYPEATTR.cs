using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.MEMBERID;
using TYPEKIND = Lsj.Util.Win32.Enums.TYPEKIND;
using static Lsj.Util.Win32.Enums.TYPEKIND;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains attributes of a type.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-typeattr"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TYPEATTR
    {
        /// <summary>
        /// The GUID of the type information.
        /// </summary>
        public GUID guid;

        /// <summary>
        /// The locale of member names and documentation strings.
        /// </summary>
        public LCID lcid;

        /// <summary>
        /// Reserved.
        /// </summary>
        public DWORD dwReserved;

        /// <summary>
        /// The constructor ID, or <see cref="MEMBERID_NIL"/> if none.
        /// </summary>
        public MEMBERID memidConstructor;

        /// <summary>
        /// The destructor ID,, or <see cref="MEMBERID_NIL"/> if none.
        /// </summary>
        public MEMBERID memidDestructor;

        /// <summary>
        /// Reserved.
        /// </summary>
        public IntPtr lpstrSchema;

        /// <summary>
        /// The size of an instance of this type.
        /// </summary>
        public ULONG cbSizeInstance;

        /// <summary>
        /// The kind of type.
        /// </summary>
        public TYPEKIND typekind;

        /// <summary>
        /// The number of functions.
        /// </summary>
        public WORD cFuncs;

        /// <summary>
        /// The number of variables or data members.
        /// </summary>
        public WORD cVars;

        /// <summary>
        /// The number of implemented interfaces.
        /// </summary>
        public WORD cImplTypes;

        /// <summary>
        /// The size of this type's VTBL.
        /// </summary>
        public WORD cbSizeVft;

        /// <summary>
        /// The byte alignment for an instance of this type.
        /// A value of 0 indicates alignment on the 64K boundary; 1 indicates no special alignment.
        /// For other values, n indicates aligned on byte n.
        /// </summary>
        public WORD cbAlignment;

        /// <summary>
        /// The type flags. See <see cref="TYPEFLAGS"/>.
        /// </summary>
        public WORD wTypeFlags;

        /// <summary>
        /// The major version number.
        /// </summary>
        public WORD wMajorVerNum;

        /// <summary>
        /// The minor version number.
        /// </summary>
        public WORD wMinorVerNum;

        /// <summary>
        /// If typekind is <see cref="TKIND_ALIAS"/>, specifies the type for which this type is an alias.
        /// </summary>
        public TYPEDESC tdescAlias;

        /// <summary>
        /// The IDL attributes of the described type.
        /// </summary>
        public IDLDESC idldescType;
    }
}
