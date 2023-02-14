using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the type description and process-transfer information for a variable, a function, or a function parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-elemdesc-r1"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ELEMDESC
    {
        /// <summary>
        /// The type of the element.
        /// </summary>
        public TYPEDESC tdesc;

#pragma warning disable IDE1006 // 命名样式
        private ELEMDESC_DUMMYUNIONNAME _ELEMDESC_DUMMYUNIONNAME;
#pragma warning restore IDE1006 // 命名样式

        /// <summary>
        /// 
        /// </summary>
#pragma warning disable IDE1006 // 命名样式
        public IDLDESC idldesc
#pragma warning restore IDE1006 // 命名样式
        {
            get => _ELEMDESC_DUMMYUNIONNAME.idldesc;
            set => _ELEMDESC_DUMMYUNIONNAME.idldesc = value;
        }

        /// <summary>
        /// 
        /// </summary>
#pragma warning disable IDE1006 // 命名样式
        public PARAMDESC paramdesc
#pragma warning restore IDE1006 // 命名样式
        {
            get => _ELEMDESC_DUMMYUNIONNAME.paramdesc;
            set => _ELEMDESC_DUMMYUNIONNAME.paramdesc = value;
        }

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct ELEMDESC_DUMMYUNIONNAME
        {
            [FieldOffset(0)]
            public IDLDESC idldesc;

            [FieldOffset(0)]
            public PARAMDESC paramdesc;
        }
    }
}
