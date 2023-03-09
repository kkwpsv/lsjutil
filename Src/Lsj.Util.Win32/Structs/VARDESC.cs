using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a variable, constant, or data member.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-vardesc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct VARDESC
    {
        /// <summary>
        /// The member ID.
        /// </summary>
        public MEMBERID memid;

        /// <summary>
        /// Reserved.
        /// </summary>
        public IntPtr lpstrSchema;

#pragma warning disable IDE1006 
        private VARDESC_DUMMYUNIONNAME _VARDESC_DUMMYUNIONNAME;
#pragma warning restore IDE1006 

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct VARDESC_DUMMYUNIONNAME
        {
            [FieldOffset(0)]
            public ULONG oInst;

            [FieldOffset(0)]
            public IntPtr lpvarValue;
        }

        /// <summary>
        /// With <see cref="VAR_PERINSTANCE"/>, the offset of this variable within the instance.
        /// </summary>
#pragma warning disable IDE1006 
        public ULONG oInst
#pragma warning restore IDE1006 
        {
            get => _VARDESC_DUMMYUNIONNAME.oInst;
            set => _VARDESC_DUMMYUNIONNAME.oInst = value;
        }

        /// <summary>
        /// With <see cref="VAR_CONST"/>, the value of the constant.
        /// </summary>
#pragma warning disable IDE1006 
        public IntPtr lpvarValue
#pragma warning restore IDE1006 
        {
            get => _VARDESC_DUMMYUNIONNAME.lpvarValue;
            set => _VARDESC_DUMMYUNIONNAME.lpvarValue = value;
        }

        /// <summary>
        /// The variable type.
        /// </summary>
        public ELEMDESC elemdescVar;

        /// <summary>
        /// The variable flags.
        /// See <see cref="VARFLAGS"/>.
        /// </summary>
        public WORD wVarFlags;

        /// <summary>
        /// The variable type.
        /// </summary>
        public VARKIND varkind;
    }
}
