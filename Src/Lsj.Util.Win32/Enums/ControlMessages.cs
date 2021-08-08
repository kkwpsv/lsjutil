namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Control Messages
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-general-control-reference-messages"/>
    /// </para>
    /// </summary>
    public enum ControlMessages : uint
    {
        /// <summary>
        /// CCM_FIRST
        /// </summary>
        CCM_FIRST = 0x2000,

        /// <summary>
        /// Enables automatic high dots per inch (dpi) scaling in Tree-View controls, List-View controls,
        /// ComboBoxEx controls, Header controls, Buttons, Toolbar controls, Animation controls, and Image Lists.
        /// </summary>
        CCM_DPISCALE = (CCM_FIRST + 0xc),

        /// <summary>
        /// Gets the Unicode character format flag for the control.
        /// </summary>
        CCM_GETUNICODEFORMAT = (CCM_FIRST + 6),

        /// <summary>
        /// Gets the version number for a control set by the most recent <see cref="CCM_SETVERSION"/> message.
        /// </summary>
        /// <remarks>
        /// This message does not return the DLL version.
        /// See Shell Versions for a discussion of how to use <see cref="DllGetVersion"/> to retrieve the current DLL version.
        /// The version number is set on a control by control basis, and may not be the same for all controls.
        /// </remarks>
        CCM_GETVERSION = (CCM_FIRST + 0x8),

        /// <summary>
        /// Sets the Unicode character format flag for the control.
        /// This message enables you to change the character set used by the control at run time rather than having to re-create the control.
        /// </summary>
        CCM_SETUNICODEFORMAT = (CCM_FIRST + 5),

        /// <summary>
        /// This message is used to inform the control that you are expecting a behavior associated with a particular version.
        /// </summary>
        /// <remarks>
        /// In a few cases, a control may behave differently, depending on the version.
        /// This primarily applies to bugs that were fixed in later versions.
        /// The <see cref="CCM_SETVERSION"/> message enables you to inform the control which behavior is expected.
        /// You can determine which version you have specified by sending a <see cref="CCM_GETVERSION"/> message.
        /// For an example of how to use this message, see Custom Draw With List-View and Tree-View Controls.
        /// If you have ComCtl32.dll version 6 installed, regardless of what value you set in wParam, the <see cref="CCM_SETVERSION"/> message returns version 6.
        /// This message only sets the version number for the control to which it is sent.
        /// </remarks>
        CCM_SETVERSION = (CCM_FIRST + 0x7),

        /// <summary>
        /// Sets the visual style of a control.
        /// </summary>
        /// <remarks>
        /// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see Enabling Visual Styles.
        /// </remarks>
        CCM_SETWINDOWTHEME = (CCM_FIRST + 0xb),
    }
}
