using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CommunicationErrorTypes;
using static Lsj.Util.Win32.Enums.CommunicationEventTypes;
using static Lsj.Util.Win32.Enums.DataTerminalReadyFlowControls;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Enums.RTSFlowControls;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Fills a specified <see cref="DCB"/> structure with values specified in a device-control string.
        /// The device-control string uses the syntax of the <c>mode</c> command.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-buildcommdcbw"/>
        /// </para>
        /// </summary>
        /// <param name="lpDef">
        /// <para>
        /// The device-control information.
        /// The function takes this string, parses it, and then sets appropriate values in the <see cref="DCB"/> structure pointed to by <paramref name="lpDCB"/>.
        /// </para>
        /// <para>
        /// The string must have the same form as the <c>mode</c> command's command-line arguments:
        /// </para>
        /// <para>
        /// <c>COMx[:][baud=b][parity=p][data=d][stop=s][to={on|off}][xon={on|off}][odsr={on|off}][octs={on|off}][dtr={on|off|hs}][rts={on|off|hs|tg}][idsr={on|off}]</c>
        /// </para>
        /// <para>
        /// The device name is optional, but it must specify a valid device if used.
        /// </para>
        /// <para>
        /// For example, the following string specifies a baud rate of 1200, no parity, 8 data bits, and 1 stop bit:
        /// </para>
        /// <para>
        /// <c>baud=1200 parity=N data=8 stop=1</c>
        /// </para>
        /// </param>
        /// <param name="lpDCB">
        /// A pointer to a <see cref="DCB"/> structure that receives the information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="BuildCommDCB"/> function adjusts only those members of the <see cref="DCB"/> structure
        /// that are specifically affected by the <paramref name="lpDef"/> parameter, with the following exceptions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the specified baud rate is 110, the function sets the stop bits to 2
        /// to remain compatible with the system's <c>mode</c> command.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// By default, <see cref="BuildCommDCB"/> disables XON/XOFF and hardware flow control.
        /// To enable flow control, you must explicitly set the appropriate members of the <see cref="DCB"/> structure.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="BuildCommDCB"/> function only fills in the members of the <see cref="DCB"/> structure.
        /// To apply these settings to a serial port, use the <see cref="SetCommState"/> function.
        /// </para>
        /// <para>
        /// There are older and newer forms of the <c>mode</c> syntax.
        /// The <see cref="BuildCommDCB"/> function supports both forms. However, you cannot mix the two forms together.
        /// </para>
        /// <para>
        /// The newer form of the <c>mode</c> syntax lets you explicitly set the values
        /// of the flow control members of the <see cref="DCB"/> structure.
        /// If you use an older form of the <c>mode</c> syntax,
        /// the <see cref="BuildCommDCB"/> function sets the flow control members of the <see cref="DCB"/> structure, as follows:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <para>
        /// For a string that does not end with an x or a p:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="DCB.fInX"/>, <see cref="DCB.fOutX"/>, <see cref="DCB.fOutxDsrFlow"/>,
        /// and <see cref="DCB.fOutxCtsFlow"/> are all set to <see cref="FALSE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DCB.fDtrControl"/> is set to <see cref="DTR_CONTROL_ENABLE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DCB.fRtsControl"/> is set to <see cref="RTS_CONTROL_ENABLE"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// For a string that ends with an x:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="DCB.fInX"/> and <see cref="DCB.fOutX"/> are both set to <see cref="TRUE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DCB.fOutxDsrFlow"/> and <see cref="DCB.fOutxCtsFlow"/> are both set to <see cref="FALSE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DCB.fDtrControl"/> is set to <see cref="DTR_CONTROL_ENABLE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DCB.fRtsControl"/> is set to <see cref="RTS_CONTROL_ENABLE"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// For a string that ends with a p:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="DCB.fInX"/> and <see cref="DCB.fOutX"/> are both set to <see cref="FALSE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DCB.fOutxDsrFlow"/> and <see cref="DCB.fOutxCtsFlow"/> are both set to <see cref="TRUE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DCB.fDtrControl"/> is set to <see cref="DTR_CONTROL_HANDSHAKE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DCB.fRtsControl"/> is set to <see cref="RTS_CONTROL_HANDSHAKE"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "BuildCommDCBW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL BuildCommDCB([In] LPCWSTR lpDef, [Out] out DCB lpDCB);

        /// <summary>
        /// <para>
        /// Translates a device-definition string into appropriate device-control block codes and places them into a device control block.
        /// The function can also set up time-out values, including the possibility of no time-outs, for a device;
        /// the function's behavior in this regard depends on the contents of the device-definition string.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-buildcommdcbandtimeoutsw"/>
        /// </para>
        /// </summary>
        /// <param name="lpDef">
        /// <para>
        /// The device-control information.
        /// The function takes this string, parses it, and then sets appropriate values
        /// in the <see cref="DCB"/> structure pointed to by <paramref name="lpDCB"/>.
        /// </para>
        /// <para>
        /// The string must have the same form as the <c>mode</c> command's command-line arguments:
        /// </para>
        /// <para>
        /// <c>COMx[:][baud={11|110|15|150|30|300|60|600|12|1200|24|2400|48|4800|96|9600|19|19200}][parity={n|e|o|m|s}][data={5|6|7|8}][stop={1|1.5|2}][to={on|off}][xon={on|off}][odsr={on|off}][octs={on|off}][dtr={on|off|hs}][rts={on|off|hs|tg}][idsr={on|off}]</c>
        /// </para>
        /// <para>
        /// The "baud" substring can be any of the values listed, which are in pairs.
        /// The two-digit values are the first two digits of the associated values that they represent.
        /// For example, 11 represents 110 baud, 19 represents 19,200 baud.
        /// </para>
        /// <para>
        /// The "parity" substring indicates how the parity bit is used to detect transmission errors.
        /// The values represent "none", "even", "odd", "mark", and "space".
        /// </para>
        /// <para>
        /// For more information, see the <c>Mode</c> command reference in TechNet.
        /// </para>
        /// <para>
        /// For example, the following string specifies a baud rate of 1200, no parity, 8 data bits, and 1 stop bit:
        /// </para>
        /// <para>
        /// <c>baud=1200 parity=N data=8 stop=1</c>
        /// </para>
        /// </param>
        /// <param name="lpDCB">
        /// A pointer to a <see cref="DCB"/> structure that receives information
        /// from the device-control information string pointed to by <paramref name="lpDef"/>.
        /// This <see cref="DCB"/> structure defines the control settings for a communications device.
        /// </param>
        /// <param name="lpCommTimeouts">
        /// A pointer to a <see cref="COMMTIMEOUTS"/> structure that receives time-out information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="BuildCommDCBAndTimeouts"/> function modifies its time-out setting behavior
        /// based on the presence or absence of a "to={on|off}" substring in <paramref name="lpDef"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If that string contains the substring "to=on",
        /// the function sets the <see cref="COMMTIMEOUTS.WriteTotalTimeoutConstant"/> member
        /// of the <see cref="COMMTIMEOUTS"/> structure to 60000 and all other members to 0.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If that string contains the substring "to=off",
        /// the function sets the members of <see cref="COMMTIMEOUTS"/> to 0.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If that string does not specify a "to={on|off}" substring,
        /// the function ignores the <see cref="COMMTIMEOUTS"/> structure in <paramref name="lpCommTimeouts"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For more information, see the Remarks for the <see cref="BuildCommDCB"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "BuildCommDCBAndTimeoutsW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL BuildCommDCBAndTimeouts([In] LPCWSTR lpDef, [Out] out DCB lpDCB, [Out] out COMMTIMEOUTS lpCommTimeouts);

        /// <summary>
        /// <para>
        /// Restores character transmission for a specified communications device and places the transmission line in a nonbreak state.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-clearcommbreak"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// A communications device is placed in a break state by the <see cref="SetCommBreak"/> or <see cref="EscapeCommFunction"/> function.
        /// Character transmission is then suspended until the break state is cleared by calling <see cref="ClearCommBreak"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ClearCommBreak", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ClearCommBreak([In] HANDLE hFile);

        /// <summary>
        /// <para>
        /// Retrieves information about a communications error and reports the current status of a communications device.
        /// The function is called when a communications error occurs,
        /// and it clears the device's error flag to enable additional input and output (I/O) operations.
        /// </para>
        /// <para>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-clearcommerror"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpErrors">
        /// <para>
        /// A pointer to a variable that receives a mask indicating the type of error.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CE_BREAK"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The hardware detected a break condition.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CE_FRAME"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The hardware detected a framing error.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CE_OVERRUN"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// A character-buffer overrun has occurred. The next character is lost.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CE_RXOVER"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// An input buffer overflow has occurred.
        /// There is either no room in the input buffer, or a character was received after the end-of-file (EOF) character.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CE_RXPARITY"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The hardware detected a parity error.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following values are not supported:
        /// </para>
        /// </param>
        /// <param name="lpStat">
        /// A pointer to a <see cref="COMSTAT"/> structure in which the device's status information is returned.
        /// If this parameter is <see cref="NullRef{COMSTAT}"/>, no status information is returned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If a communications port has been set up with a <see cref="TRUE"/> value
        /// for the <see cref="DCB.fAbortOnError"/> member of the setup <see cref="DCB"/> structure,
        /// the communications software will terminate all read and write operations
        /// on the communications port when a communications error occurs.
        /// No new read or write operations will be accepted
        /// until the application acknowledges the communications error by calling the <see cref="ClearCommError"/> function.
        /// </para>
        /// <para>
        /// The <see cref="ClearCommError"/> function fills the status buffer pointed to by the <paramref name="lpStat"/> parameter
        /// with the current status of the communications device specified by the <paramref name="hFile"/> parameter.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ClearCommError", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ClearCommError([In] HANDLE hFile, [Out] CommunicationErrorTypes lpErrors, [Out] out COMSTAT lpStat);

        /// <summary>
        /// <para>
        /// Displays a driver-supplied configuration dialog box.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-commconfigdialogw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszName">
        /// The name of the device for which a dialog box should be displayed.
        /// For example, COM1 through COM9 are serial ports and LPT1 through LPT9 are parallel ports.
        /// </param>
        /// <param name="hWnd">
        /// A handle to the window that owns the dialog box.
        /// This parameter can be any valid window handle,
        /// or it should be <see cref="NULL"/> if the dialog box is to have no owner.
        /// </param>
        /// <param name="lpCC">
        /// A pointer to a <see cref="COMMCONFIG"/> structure.
        /// This structure contains initial settings for the dialog box before the call, and changed values after the call.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="CommConfigDialog"/> function requires a dynamic-link library (DLL) provided by the communications hardware vendor.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CommConfigDialogW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CommConfigDialog([In] LPCWSTR lpszName, [In] HWND hWnd, [In][Out] ref COMMCONFIG lpCC);

        /// <summary>
        /// <para>
        /// Directs the specified communications device to perform an extended function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-escapecommfunction"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="dwFunc">
        /// <para>
        /// The extended function to be performed. This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CLRBREAK"/>
        /// </para>
        /// <para>
        /// 9
        /// </para>
        /// </term>
        /// <term>
        /// Restores character transmission and places the transmission line in a nonbreak state.
        /// The <see cref="CLRBREAK"/> extended function code is identical to the <see cref="ClearCommBreak"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CLRDTR"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// Clears the DTR (data-terminal-ready) signal.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CLRRTS"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// Clears the RTS (request-to-send) signal.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SETBREAK"/>
        /// </para>
        /// <para>
        /// 8
        /// </para>
        /// </term>
        /// <term>
        /// Suspends character transmission and places the transmission line in a break state
        /// until the <see cref="ClearCommBreak"/> function is called
        /// (or <see cref="EscapeCommFunction"/> is called with the <see cref="CLRBREAK"/> extended function code).
        /// The <see cref="SETBREAK"/> extended function code is identical to the <see cref="SetCommBreak"/> function.
        /// Note that this extended function does not flush data that has not been transmitted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SETDTR"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// Sends the DTR (data-terminal-ready) signal.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SETRTS"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// Sends the RTS (request-to-send) signal.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SETXOFF"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Causes transmission to act as if an XOFF character has been received.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SETXON"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Causes transmission to act as if an XON character has been received.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "EscapeCommFunction", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EscapeCommFunction([In] HANDLE hFile, [In] DWORD dwFunc);

        /// <summary>
        /// <para>
        /// Retrieves the current configuration of a communications device.
        /// </para>
        /// <para>
        /// To retrieve the default configuration settings from the device manager, use the <see cref="GetDefaultCommConfig"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getcommconfig"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the open communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpCC">
        /// A pointer to a buffer that receives a <see cref="COMMCONFIG"/> structure.
        /// </param>
        /// <param name="lpdwSize">
        /// The size, in bytes, of the buffer pointed to by <paramref name="lpCC"/>.
        /// When the function returns, the variable contains the number of bytes copied if the function succeeds,
        /// or the number of bytes required if the buffer was too small.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCommConfig", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCommConfig([In] HANDLE hFile, [In][Out] ref COMMCONFIG lpCC, [In][Out] ref DWORD lpdwSize);

        /// <summary>
        /// <para>
        /// Retrieves the value of the event mask for a specified communications device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getcommmask"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpEvtMask">
        /// <para>
        /// A pointer to the variable that receives a mask of events that are currently enabled.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_BREAK"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// A break was detected on input.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_CTS"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTS (clear-to-send) signal changed state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_DSR"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The DSR (data-set-ready) signal changed state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_ERR"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// A line-status error occurred.
        /// Line-status errors are <see cref="CE_FRAME"/>, <see cref="CE_OVERRUN"/>, and <see cref="CE_RXPARITY"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_EVENT1"/>
        /// </para>
        /// <para>
        /// 0x0800
        /// </para>
        /// </term>
        /// <term>
        /// An event of the first provider-specific type occurred.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_EVENT2"/>
        /// </para>
        /// <para>
        /// 0x1000
        /// </para>
        /// </term>
        /// <term>
        /// An event of the second provider-specific type occurred.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_PERR"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// A printer error occurred.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RING"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// A ring indicator was detected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RLSD"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The RLSD (receive-line-signal-detect) signal changed state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RX80FULL"/>
        /// </para>
        /// <para>
        /// 0x0400
        /// </para>
        /// </term>
        /// <term>
        /// The receive buffer is 80 percent full.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RXCHAR"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// A character was received and placed in the input buffer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RXFLAG"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The event character was received and placed in the input buffer.
        /// The event character is specified in the device's <see cref="DCB"/> structure,
        /// which is applied to a serial port by using the <see cref="SetCommState"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_TXEMPTY"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The last character in the output buffer was sent.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="GetCommMask"/> function uses a mask variable to indicate the set of events
        /// that can be monitored for a particular communications resource.
        /// A handle to the communications resource can be specified in a call to the <see cref="WaitCommEvent"/> function,
        /// which waits for one of the events to occur.
        /// To modify the event mask of a communications resource, use the <see cref="SetCommMask"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCommMask", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCommMask([In] HANDLE hFile, [Out] out DWORD lpEvtMask);

        /// <summary>
        /// <para>
        /// Retrieves the modem control-register values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getcommmodemstatus"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpModemStat">
        /// <para>
        /// A pointer to a variable that receives the current state of the modem control-register values.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MS_CTS_ON"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The CTS (clear-to-send) signal is on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MS_DSR_ON"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The DSR (data-set-ready) signal is on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MS_RING_ON"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The ring indicator signal is on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MS_RLSD_ON"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// The RLSD (receive-line-signal-detect) signal is on.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetCommModemStatus"/> function is useful when you are using the <see cref="WaitCommEvent"/> function
        /// to monitor the CTS, RLSD, DSR, or ring indicator signals.
        /// To detect when these signals change state, use <see cref="WaitCommEvent"/>
        /// and then use <see cref="GetCommModemStatus"/> to determine the state after a change occurs.
        /// </para>
        /// <para>
        /// The function fails if the hardware does not support the control-register values.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCommModemStatus", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCommModemStatus([In] HANDLE hFile, [Out] out DWORD lpModemStat);

        /// <summary>
        /// <para>
        /// Retrieves information about the communications properties for a specified communications device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getcommproperties"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpCommProp">
        /// A pointer to a <see cref="COMMPROP"/> structure in which the communications properties information is returned.
        /// This information can be used in subsequent calls to the <see cref="SetCommState"/>,
        /// <see cref="SetCommTimeouts"/>, or <see cref="SetupComm"/> function to configure the communications device.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="GetCommProperties"/> function returns information from a device driver
        /// about the configuration settings that are supported by the driver.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCommProperties", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCommProperties([In] HANDLE hFile, [Out] out COMMPROP lpCommProp);

        /// <summary>
        /// <para>
        /// Retrieves the current control settings for a specified communications device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getcommstate"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpDCB">
        /// A pointer to a <see cref="DCB"/> structure that receives the control settings information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCommState", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCommState([In] HANDLE hFile, [In][Out] ref DCB lpDCB);

        /// <summary>
        /// <para>
        /// Retrieves the time-out parameters for all read and write operations on a specified communications device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getcommtimeouts"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpCommTimeouts">
        /// A pointer to a <see cref="COMMTIMEOUTS"/> structure in which the time-out information is returned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// For more information about time-out values for communications devices, see the <see cref="SetCommTimeouts"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCommTimeouts", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCommTimeouts([In] HANDLE hFile, [Out] out COMMTIMEOUTS lpCommTimeouts);

        /// <summary>
        /// <para>
        /// Retrieves the default configuration for the specified communications device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getdefaultcommconfigw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszName">
        /// The name of the device.
        /// For example, COM1 through COM9 are serial ports and LPT1 through LPT9 are parallel ports.
        /// </param>
        /// <param name="lpCC">
        /// A pointer to a buffer that receives a <see cref="COMMCONFIG"/> structure.
        /// </param>
        /// <param name="lpdwSize">
        /// A pointer to a variable that specifies the size of the buffer pointed to by <paramref name="lpCC"/>, in bytes.
        /// Upon return, the variable contains the number of bytes copied if the function succeeds,
        /// or the number of bytes required if the buffer was too small.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, use the <see cref="GetLastError"/> function.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDefaultCommConfigW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetDefaultCommConfig([In] LPCWSTR lpszName, [In][Out] ref COMMCONFIG lpCC, [In][Out] ref DWORD lpdwSize);

        /// <summary>
        /// <para>
        /// Discards all characters from the output or input buffer of a specified communications resource.
        /// It can also terminate pending read or write operations on the resource.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-purgecomm"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications resource.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PURGE_RXABORT"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Terminates all outstanding overlapped read operations and returns immediately,
        /// even if the read operations have not been completed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PURGE_RXCLEAR"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Clears the input buffer (if the device driver has one).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PURGE_TXABORT"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Terminates all outstanding overlapped write operations and returns immediately,
        /// even if the write operations have not been completed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PURGE_TXCLEAR"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// Clears the output buffer (if the device driver has one).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If a thread uses <see cref="PurgeComm"/> to flush an output buffer, the deleted characters are not transmitted.
        /// To empty the output buffer while ensuring that the contents are transmitted,
        /// call the <see cref="FlushFileBuffers"/> function (a synchronous operation).
        /// Note, however, that <see cref="FlushFileBuffers"/> is subject to flow control but not to write time-outs,
        /// and it will not return until all pending write operations have been transmitted.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "PurgeComm", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PurgeComm([In] HANDLE hFile, [In] DWORD dwFlags);

        /// <summary>
        /// <para>
        /// Suspends character transmission for a specified communications device and places the transmission line in a break state
        /// until the <see cref="ClearCommBreak"/> function is called.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setcommbreak"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCommBreak", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCommBreak([In] HANDLE hFile);

        /// <summary>
        /// <para>
        /// Sets the current configuration of a communications device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setcommconfig"/>
        /// </para>
        /// </summary>
        /// <param name="hCommDev">
        /// A handle to the open communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpCC">
        /// A pointer to a <see cref="COMMCONFIG"/> structure.
        /// </param>
        /// <param name="dwSize">
        /// The size of the structure pointed to by <paramref name="lpCC"/>, in bytes.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCommConfig", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCommConfig([In] HANDLE hCommDev, [In] in COMMCONFIG lpCC, [In] DWORD dwSize);

        /// <summary>
        /// <para>
        /// Specifies a set of events to be monitored for a communications device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setcommmask"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpEvtMask">
        /// <para>
        /// The events to be enabled. A value of zero disables all events.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_BREAK"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// A break was detected on input.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_CTS"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTS (clear-to-send) signal changed state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_DSR"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The DSR (data-set-ready) signal changed state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_ERR"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// A line-status error occurred.
        /// Line-status errors are <see cref="CE_FRAME"/>, <see cref="CE_OVERRUN"/>, and <see cref="CE_RXPARITY"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RING"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// A ring indicator was detected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RLSD"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The RLSD (receive-line-signal-detect) signal changed state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RXCHAR"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// A character was received and placed in the input buffer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RXFLAG"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The event character was received and placed in the input buffer.
        /// The event character is specified in the device's <see cref="DCB"/> structure,
        /// which is applied to a serial port by using the <see cref="SetCommState"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_TXEMPTY"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The last character in the output buffer was sent.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="SetCommMask"/> function specifies the set of events that can be monitored for a particular communications resource.
        /// A handle to the communications resource can be specified in a call
        /// to the <see cref="WaitCommEvent"/> function, which waits for one of the events to occur.
        /// To get the current event mask of a communications resource, use the <see cref="GetCommMask"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCommMask", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCommMask([In] HANDLE hFile, [In] DWORD lpEvtMask);

        /// <summary>
        /// <para>
        /// Retrieves the current control settings for a specified communications device.
        /// </para>
        /// <para>
        /// body>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getcommstate"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpDCB">
        /// A pointer to a <see cref="DCB"/> structure that receives the control settings information.
        /// </param>
        /// <remarks>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCommState", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCommState([In] HANDLE hFile, [In] in DCB lpDCB);

        /// <summary>
        /// <para>
        /// Sets the time-out parameters for all read and write operations on a specified communications device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setcommtimeouts"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpCommTimeouts">
        /// A pointer to a <see cref="COMMTIMEOUTS"/> structure that contains the new time-out values.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCommTimeouts", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCommTimeouts([In] HANDLE hFile, [In] in COMMTIMEOUTS lpCommTimeouts);

        /// <summary>
        /// <para>
        /// Sets the default configuration for a communications device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setdefaultcommconfigw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszName">
        /// The name of the device.
        /// For example, COM1 through COM9 are serial ports and LPT1 through LPT9 are parallel ports.
        /// </param>
        /// <param name="lpCC">
        /// A pointer to a <see cref="COMMCONFIG"/> structure.
        /// </param>
        /// <param name="lpdwSize">
        /// The size of the structure pointed to by <paramref name="lpCC"/>, in bytes.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDefaultCommConfigW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetDefaultCommConfig([In] LPCWSTR lpszName, [In] in COMMCONFIG lpCC, [In] DWORD lpdwSize);

        /// <summary>
        /// <para>
        /// Initializes the communications parameters for a specified communications device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setupcomm"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="dwInQueue">
        /// The recommended size of the device's internal input buffer, in bytes.
        /// </param>
        /// <param name="dwOutQueue">
        /// The recommended size of the device's internal output buffer, in bytes.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// After a process uses the <see cref="CreateFile"/> function to open a handle to a communications device,
        /// but before doing any I/O with the device, it can call <see cref="SetupComm"/> to set the communications parameters for the device.
        /// If it does not set them, the device uses the default parameters when the first call to another communications function occurs.
        /// </para>
        /// <para>
        /// The <paramref name="dwInQueue"/> and <paramref name="dwOutQueue"/> parameters specify the recommended sizes
        /// for the internal buffers used by the driver for the specified device.
        /// For example, YMODEM protocol packets are slightly larger than 1024 bytes.
        /// Therefore, a recommended buffer size might be 1200 bytes for YMODEM communications.
        /// For Ethernet-based communications, a recommended buffer size might be 1600 bytes,
        /// which is slightly larger than a single Ethernet frame.
        /// </para>
        /// <para>
        /// The device driver receives the recommended buffer sizes, but is free to use any input and output (I/O) buffering scheme,
        /// as long as it provides reasonable performance and data is not lost due to overrun (except under extreme circumstances).
        /// For example, the function can succeed even though the driver does not allocate a buffer,
        /// as long as some other portion of the system provides equivalent functionality.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetupComm", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetupComm([In] HANDLE hFile, [In] DWORD dwInQueue, [In] DWORD dwOutQueue);

        /// <summary>
        /// <para>
        /// Transmits a specified character ahead of any pending data in the output buffer of the specified communications device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-transmitcommchar"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="cChar">
        /// The character to be transmitted.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="TransmitCommChar"/> function is useful for sending an interrupt character (such as a CTRL+C) to a host system.
        /// </para>
        /// <para>
        /// If the device is not transmitting, <see cref="TransmitCommChar"/> cannot be called repeatedly.
        /// Once <see cref="TransmitCommChar"/> places a character in the output buffer,
        /// the character must be transmitted before the function can be called again.
        /// If the previous character has not yet been sent, <see cref="TransmitCommChar"/> returns an error.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TransmitCommChar", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TransmitCommChar([In] HANDLE hFile, [In] byte cChar);

        /// <summary>
        /// <para>
        /// Waits for an event to occur for a specified communications device.
        /// The set of events that are monitored by this function is contained in the event mask associated with the device handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-waitcommevent"/>
        /// </para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the communications device.
        /// The <see cref="CreateFile"/> function returns this handle.
        /// </param>
        /// <param name="lpEvtMask">
        /// <para>
        /// A pointer to a variable that receives a mask indicating the type of event that occurred.
        /// If an error occurs, the value is zero; otherwise, it is one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_BREAK"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// A break was detected on input.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_CTS"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The CTS (clear-to-send) signal changed state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_DSR"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The DSR (data-set-ready) signal changed state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_ERR"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// A line-status error occurred.
        /// Line-status errors are <see cref="CE_FRAME"/>, <see cref="CE_OVERRUN"/>, and <see cref="CE_RXPARITY"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RING"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// A ring indicator was detected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RLSD"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The RLSD (receive-line-signal-detect) signal changed state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RXCHAR"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// A character was received and placed in the input buffer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_RXFLAG"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The event character was received and placed in the input buffer.
        /// The event character is specified in the device's <see cref="DCB"/> structure,
        /// which is applied to a serial port by using the <see cref="SetCommState"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="EV_TXEMPTY"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The last character in the output buffer was sent.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpOverlapped">
        /// <para>
        /// A pointer to an <see cref="OVERLAPPED"/> structure.
        /// This structure is required if <paramref name="hFile"/> was opened with <see cref="FILE_FLAG_OVERLAPPED"/>.
        /// </para>
        /// <para>
        /// If <paramref name="hFile"/> was opened with <see cref="FILE_FLAG_OVERLAPPED"/>,
        /// the <paramref name="lpOverlapped"/> parameter must not be <see cref="NULL"/>.
        /// It must point to a valid <see cref="OVERLAPPED"/> structure.
        /// If <paramref name="hFile"/> was opened with <see cref="FILE_FLAG_OVERLAPPED"/> and <paramref name="lpOverlapped"/> is <see cref="NULL"/>,
        /// the function can incorrectly report that the operation is complete.
        /// </para>
        /// <para>
        /// If <paramref name="hFile"/> was opened with <see cref="FILE_FLAG_OVERLAPPED"/> and <paramref name="lpOverlapped"/> is not <see cref="NULL"/>,
        /// <see cref="WaitCommEvent"/> is performed as an overlapped operation.
        /// In this case, the <see cref="OVERLAPPED"/> structure must contain a handle to a manual-reset event object
        /// (created by using the <see cref="CreateEvent"/> function).
        /// </para>
        /// <para>
        /// If <paramref name="hFile"/> was not opened with <see cref="FILE_FLAG_OVERLAPPED"/>,
        /// <see cref="WaitCommEvent"/> does not return until one of the specified events or an error occurs.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="WaitCommEvent"/> function monitors a set of events for a specified communications resource.
        /// To set and query the current event mask of a communications resource,
        /// use the <see cref="SetCommMask"/> and <see cref="GetCommMask"/> functions.
        /// </para>
        /// <para>
        /// If the overlapped operation cannot be completed immediately, the function returns <see cref="FALSE"/>
        /// and the <see cref="GetLastError"/> function returns <see cref="ERROR_IO_PENDING"/>,
        /// indicating that the operation is executing in the background.
        /// When this happens, the system sets the <see cref="OVERLAPPED.hEvent"/> member of the <see cref="OVERLAPPED"/> structure
        /// to the not-signaled state before <see cref="WaitCommEvent"/> returns,
        /// and then it sets it to the signaled state when one of the specified events or an error occurs.
        /// The calling process can use one of the wait functions to determine the event object's state
        /// and then use the <see cref="GetOverlappedResult"/> function to determine the results of the <see cref="WaitCommEvent"/> operation.
        /// <see cref="GetOverlappedResult"/> reports the success or failure of the operation,
        /// and the variable pointed to by the <paramref name="lpEvtMask"/> parameter is set to indicate the event that occurred.
        /// </para>
        /// <para>
        /// If a process attempts to change the device handle's event mask by using the <see cref="SetCommMask"/> function
        /// while an overlapped <see cref="WaitCommEvent"/> operation is in progress, <see cref="WaitCommEvent"/> returns immediately.
        /// The variable pointed to by the <paramref name="lpEvtMask"/> parameter is set to zero.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitCommEvent", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WaitCommEvent([In] HANDLE hFile, [Out] out CommunicationEventTypes lpEvtMask, [In] in OVERLAPPED lpOverlapped);
    }
}
