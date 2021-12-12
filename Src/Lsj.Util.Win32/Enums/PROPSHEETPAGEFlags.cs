using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="PROPSHEETPAGE"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/pss-propsheetpage"/>
    /// </para>
    /// </summary>
    public enum PROPSHEETPAGEFlags : uint
    {
        /// <summary>
        /// PSP_DEFAULT
        /// </summary>
        PSP_DEFAULT = 0x00000000,

        /// <summary>
        /// PSP_DLGINDIRECT
        /// </summary>
        PSP_DLGINDIRECT = 0x00000001,

        /// <summary>
        /// PSP_USEHICON
        /// </summary>
        PSP_USEHICON = 0x00000002,

        /// <summary>
        /// PSP_USEICONID
        /// </summary>
        PSP_USEICONID = 0x00000004,

        /// <summary>
        /// PSP_USETITLE
        /// </summary>
        PSP_USETITLE = 0x00000008,

        /// <summary>
        /// PSP_RTLREADING
        /// </summary>
        PSP_RTLREADING = 0x00000010,

        /// <summary>
        /// PSP_HASHELP
        /// </summary>
        PSP_HASHELP = 0x00000020,

        /// <summary>
        /// 
        /// </summary>
        PSP_USEREFPARENT = 0x00000040,

        /// <summary>
        /// PSP_USECALLBACK
        /// </summary>
        PSP_USECALLBACK = 0x00000080,

        /// <summary>
        /// PSP_PREMATURE
        /// </summary>
        PSP_PREMATURE = 0x00000400,

        /// <summary>
        /// PSP_HIDEHEADER
        /// </summary>
        PSP_HIDEHEADER = 0x00000800,

        /// <summary>
        /// PSP_USEHEADERTITLE
        /// </summary>
        PSP_USEHEADERTITLE = 0x00001000,

        /// <summary>
        /// PSP_USEHEADERSUBTITLE
        /// </summary>
        PSP_USEHEADERSUBTITLE = 0x00002000,

        /// <summary>
        /// PSP_USEFUSIONCONTEXT
        /// </summary>
        PSP_USEFUSIONCONTEXT = 0x00004000,
    }
}
