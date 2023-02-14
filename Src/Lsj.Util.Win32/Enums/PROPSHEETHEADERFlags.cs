using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="PROPSHEETHEADER"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/pss-propsheetheader"/>
    /// </para>
    /// </summary>
    public enum PROPSHEETHEADERFlags : uint
    {
        /// <summary>
        /// PSH_DEFAULT
        /// </summary>
        PSH_DEFAULT = 0x00000000,

        /// <summary>
        /// PSH_AEROWIZARD
        /// </summary>
        PSH_AEROWIZARD = 0x00004000,

        /// <summary>
        /// PSH_HASHELP
        /// </summary>
        PSH_HASHELP = 0x00000200,

        /// <summary>
        /// PSH_HEADER
        /// </summary>
        PSH_HEADER = 0x00080000,

        /// <summary>
        /// PSH_HEADERBITMAP
        /// </summary>
        PSH_HEADERBITMAP = 0x08000000,

        /// <summary>
        /// PSH_MODELESS
        /// </summary>
        PSH_MODELESS = 0x00000400,

        /// <summary>
        /// PSH_NOAPPLYNOW
        /// </summary>
        PSH_NOAPPLYNOW = 0x00000080,

        /// <summary>
        /// PSH_NOCONTEXTHELP
        /// </summary>
        PSH_NOCONTEXTHELP = 0x02000000,

        /// <summary>
        /// PSH_NOMARGIN
        /// </summary>
        PSH_NOMARGIN = 0x10000000,

        /// <summary>
        /// PSH_PROPSHEETPAGE
        /// </summary>
        PSH_PROPSHEETPAGE = 0x00000008,

        /// <summary>
        /// PSH_PROPTITLE
        /// </summary>
        PSH_PROPTITLE = 0x00000001,

        /// <summary>
        /// PSH_RESIZABLE
        /// </summary>
        PSH_RESIZABLE = 0x04000000,

        /// <summary>
        /// PSH_RTLREADING
        /// </summary>
        PSH_RTLREADING = 0x00000800,

        /// <summary>
        /// PSH_STRETCHWATERMARK
        /// </summary>
        PSH_STRETCHWATERMARK = 0x00040000,

        /// <summary>
        /// PSH_USECALLBACK
        /// </summary>
        PSH_USECALLBACK = 0x00000100,

        /// <summary>
        /// PSH_USEHBMHEADER
        /// </summary>
        PSH_USEHBMHEADER = 0x00100000,

        /// <summary>
        /// PSH_USEHBMWATERMARK
        /// </summary>
        PSH_USEHBMWATERMARK = 0x00010000,

        /// <summary>
        /// PSH_USEHICON
        /// </summary>
        PSH_USEHICON = 0x00000002,

        /// <summary>
        /// PSH_USEHPLWATERMARK
        /// </summary>
        PSH_USEHPLWATERMARK = 0x00020000,

        /// <summary>
        /// PSH_USEICONID
        /// </summary>
        PSH_USEICONID = 0x00000004,

        /// <summary>
        /// PSH_USEPAGELANG
        /// </summary>
        PSH_USEPAGELANG = 0x00200000,

        /// <summary>
        /// PSH_USEPSTARTPAGE
        /// </summary>
        PSH_USEPSTARTPAGE = 0x00000040,

        /// <summary>
        /// PSH_WATERMARK
        /// </summary>
        PSH_WATERMARK = 0x00008000,

        /// <summary>
        /// PSH_WIZARD
        /// </summary>
        PSH_WIZARD = 0x00000020,

        /// <summary>
        /// PSH_WIZARD97
        /// </summary>
        PSH_WIZARD97 = 0x01000000,

        /// <summary>
        /// PSH_WIZARDCONTEXTHELP
        /// </summary>
        PSH_WIZARDCONTEXTHELP = 0x00001000,

        /// <summary>
        /// PSH_WIZARDHASFINISH
        /// </summary>
        PSH_WIZARDHASFINISH = 0x00000010,

        /// <summary>
        /// PSH_WIZARD_LITE
        /// </summary>
        PSH_WIZARD_LITE = 0x00400000,
    }
}
