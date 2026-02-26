using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACTCTX_SECTION_KEYED_DATA_ASSEMBLY_METADATA
    {
        /// <summary>
        /// 
        /// </summary>
        public PVOID lpInformation;

        /// <summary>
        /// 
        /// </summary>
        public PVOID lpSectionBase;

        /// <summary>
        /// 
        /// </summary>
        public ULONG ulSectionLength;

        /// <summary>
        /// 
        /// </summary>
        public PVOID lpSectionGlobalDataBase;

        /// <summary>
        /// 
        /// </summary>
        public ULONG ulSectionGlobalDataLength;
    }
}
