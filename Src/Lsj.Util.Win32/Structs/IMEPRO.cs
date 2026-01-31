using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// IMEPRO
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct IMEPRO
    {
        /// <summary>
        /// 
        /// </summary>
        public HWND hWnd;

        /// <summary>
        /// 
        /// </summary>
        public DATETIME InstDate;

        /// <summary>
        /// 
        /// </summary>
        public UINT wVersion;

        /// <summary>
        /// 
        /// </summary>
        public ByValStringStructForSize50 szDescription;

        /// <summary>
        /// 
        /// </summary>
        public ByValStringStructForSize80 szName;

        /// <summary>
        /// 
        /// </summary>
        public ByValStringStructForSize30 szOptions;
    }
}
