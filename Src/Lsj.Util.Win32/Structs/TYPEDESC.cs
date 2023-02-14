using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.VARENUM;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes the type of a variable, the return type of a function, or the type of a function parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-typedesc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the variable is <see cref="VT_SAFEARRAY"/> or <see cref="VT_PTR"/>,
    /// the union portion of the <see cref="TYPEDESC"/> contains a pointer to a <see cref="TYPEDESC"/> that specifies the element type.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TYPEDESC
    {
#pragma warning disable IDE1006 // 命名样式
        private TYPEDESC_DUMMYUNIONNAME _TYPEDESC_DUMMYUNIONNAME;
#pragma warning restore IDE1006 // 命名样式

        /// <summary>
        /// With <see cref="VT_PTR"/>, the type pointed to.
        /// </summary>
#pragma warning disable IDE1006 // 命名样式
        public P<TYPEDESC> lptdesc
#pragma warning restore IDE1006 // 命名样式
        {
            get => _TYPEDESC_DUMMYUNIONNAME.lptdesc;
            set => _TYPEDESC_DUMMYUNIONNAME.lptdesc = value;
        }

        /// <summary>
        /// With VT_CARRAY...
        /// </summary>
#pragma warning disable IDE1006 // 命名样式
        public P<ARRAYDESC> lpadesc
#pragma warning restore IDE1006 // 命名样式
        {
            get => _TYPEDESC_DUMMYUNIONNAME.lpadesc;
            set => _TYPEDESC_DUMMYUNIONNAME.lpadesc = value;
        }

        /// <summary>
        /// With <see cref="VT_USER_DEFINED"/>, this is used to get a TypeInfo for the UDT.
        /// </summary>
#pragma warning disable IDE1006 // 命名样式
        public HREFTYPE hreftype
#pragma warning restore IDE1006 // 命名样式
        {
            get => _TYPEDESC_DUMMYUNIONNAME.hreftype;
            set => _TYPEDESC_DUMMYUNIONNAME.hreftype = value;
        }

        /// <summary>
        /// The variant type.
        /// </summary>
        public VARTYPE vt;

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct TYPEDESC_DUMMYUNIONNAME
        {
            [FieldOffset(0)]
            public IntPtr lptdesc;

            [FieldOffset(0)]
            public IntPtr lpadesc;

            [FieldOffset(0)]
            public HREFTYPE hreftype;
        }
    }
}
