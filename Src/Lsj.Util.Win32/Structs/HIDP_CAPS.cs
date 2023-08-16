using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="HIDP_CAPS"/> structure contains information about a top-level collection's capability.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpi/ns-hidpi-_hidp_caps"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Callers of the HIDClass support routines use the information provided in this structure when a called routine requires,
    /// as input, the size of a report type, the number of link collection nodes, the number of control capabilities, or the number of data indices.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HIDP_CAPS
    {
        /// <summary>
        /// Specifies a top-level collection's usage ID.
        /// </summary>
        public USHORT Usage;

        /// <summary>
        /// Specifies the top-level collection's usage page.
        /// </summary>
        public USHORT UsagePage;

        /// <summary>
        /// Specifies the maximum size, in bytes, of all the input reports.
        /// Includes the report ID, which is prepended to the report data.
        /// If report ID is not used, the ID value is zero.
        /// </summary>
        public USHORT InputReportByteLength;

        /// <summary>
        /// Specifies the maximum size, in bytes, of all the output reports.
        /// Includes the report ID, which is prepended to the report data.
        /// If report ID is not used, the ID value is zero.
        /// </summary>
        public USHORT OutputReportByteLength;

        /// <summary>
        /// Specifies the maximum length, in bytes, of all the feature reports.
        /// Includes the report ID, which is prepended to the report data.
        /// If report ID is not used, the ID value is zero.
        /// </summary>
        public USHORT FeatureReportByteLength;

        /// <summary>
        /// Reserved for internal system use.
        /// </summary>
        public ByValUSHORTArrayStructForSize17 Reserved;

        /// <summary>
        /// Specifies the number of <see cref="HIDP_LINK_COLLECTION_NODE"/> structures
        /// that are returned for this top-level collection by <see cref="HidP_GetLinkCollectionNodes"/>.
        /// </summary>
        public USHORT NumberLinkCollectionNodes;

        /// <summary>
        /// Specifies the number of input <see cref="HIDP_BUTTON_CAPS"/> structures that <see cref="HidP_GetButtonCaps"/> returns.
        /// </summary>
        public USHORT NumberInputButtonCaps;

        /// <summary>
        /// Specifies the number of input <see cref="HIDP_VALUE_CAPS"/> structures that <see cref="HidP_GetValueCaps"/> returns.
        /// </summary>
        public USHORT NumberInputValueCaps;

        /// <summary>
        /// Specifies the number of data indices assigned to buttons and values in all input reports.
        /// </summary>
        public USHORT NumberInputDataIndices;

        /// <summary>
        /// Specifies the number of output <see cref="HIDP_BUTTON_CAPS"/> structures that <see cref="HidP_GetButtonCaps"/> returns.
        /// </summary>
        public USHORT NumberOutputButtonCaps;

        /// <summary>
        /// Specifies the number of output <see cref="HIDP_VALUE_CAPS"/> structures that <see cref="HidP_GetValueCaps"/> returns.
        /// </summary>
        public USHORT NumberOutputValueCaps;

        /// <summary>
        /// Specifies the number of data indices assigned to buttons and values in all output reports.
        /// </summary>
        public USHORT NumberOutputDataIndices;

        /// <summary>
        /// Specifies the total number of feature <see cref="HIDP_BUTTONS_CAPS"/> structures that <see cref="HidP_GetButtonCaps"/> returns.
        /// </summary>
        public USHORT NumberFeatureButtonCaps;

        /// <summary>
        /// Specifies the total number of feature <see cref="HIDP_VALUE_CAPS"/> structures that <see cref="HidP_GetValueCaps"/> returns.
        /// </summary>
        public USHORT NumberFeatureValueCaps;

        /// <summary>
        /// Specifies the number of data indices assigned to buttons and values in all feature reports.
        /// </summary>
        public USHORT NumberFeatureDataIndices;
    }
}
