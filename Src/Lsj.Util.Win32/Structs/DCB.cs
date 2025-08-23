using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.CommunicationBaudRates;
using static Lsj.Util.Win32.Enums.DataTerminalReadyFlowControls;
using static Lsj.Util.Win32.Enums.ParitySchemes;
using static Lsj.Util.Win32.Enums.RTSFlowControls;
using static Lsj.Util.Win32.Enums.StopBits;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines the control setting for a serial communications device.
    /// </para>
    /// <para>
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-dcb"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// When a <see cref="DCB"/> structure is used to configure the 8250,
    /// the following restrictions apply to the values specified for the <see cref="ByteSize"/> and <see cref="StopBits"/> members:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// The number of data bits must be 5 to 8 bits.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The use of 5 data bits with 2 stop bits is an invalid combination, as is 6, 7, or 8 data bits with 1.5 stop bits.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DCB
    {
        /// <summary>
        /// The length of the structure, in bytes.
        /// The caller must set this member to <code>sizeof(DCB)</code>.
        /// </summary>
        public DWORD DCBlength;

        /// <summary>
        /// <para>
        /// The baud rate at which the communications device operates. This member can be an actual baud rate value, or one of the following indexes.
        /// </para>
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
        /// <see cref="CBR_110"/>
        /// </para>
        /// <para>
        /// 110
        /// </para>
        /// </term>
        /// <term>
        /// 110 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_300"/>
        /// </para>
        /// <para>
        /// 300
        /// </para>
        /// </term>
        /// <term>
        /// 300 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_600"/>
        /// </para>
        /// <para>
        /// 600
        /// </para>
        /// </term>
        /// <term>
        /// 600 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_1200"/>
        /// </para>
        /// <para>
        /// 1200
        /// </para>
        /// </term>
        /// <term>
        /// 1200 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_2400"/>
        /// </para>
        /// <para>
        /// 2400
        /// </para>
        /// </term>
        /// <term>
        /// 2400 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_4800"/>
        /// </para>
        /// <para>
        /// 4800
        /// </para>
        /// </term>
        /// <term>
        /// 4800 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_9600"/>
        /// </para>
        /// <para>
        /// 9600
        /// </para>
        /// </term>
        /// <term>
        /// 9600 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_14400"/>
        /// </para>
        /// <para>
        /// 14400
        /// </para>
        /// </term>
        /// <term>
        /// 14400 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_19200"/>
        /// </para>
        /// <para>
        /// 19200
        /// </para>
        /// </term>
        /// <term>
        /// 19200 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_38400"/>
        /// </para>
        /// <para>
        /// 38400
        /// </para>
        /// </term>
        /// <term>
        /// 38400 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_57600"/>
        /// </para>
        /// <para>
        /// 57600
        /// </para>
        /// </term>
        /// <term>
        /// 57600 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_115200"/>
        /// </para>
        /// <para>
        /// 115200
        /// </para>
        /// </term>
        /// <term>
        /// 115200 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_128000"/>
        /// </para>
        /// <para>
        /// 128000
        /// </para>
        /// </term>
        /// <term>
        /// 128000 bps
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CBR_256000"/>
        /// </para>
        /// <para>
        /// 256000
        /// </para>
        /// </term>
        /// <term>
        /// 256000 bps
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public CommunicationBaudRates BaudRate;

        private DWORD _bitFiled;

#pragma warning disable IDE1006
        /// <summary>
        /// If this member is <see cref="TRUE"/>, binary mode is enabled.
        /// Windows does not support nonbinary mode transfers, so this member must be <see cref="TRUE"/>.
        /// </summary>
        public DWORD fBinary
        {
            get => _bitFiled & 1;
            set => _bitFiled |= (value & 1);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, parity checking is performed and errors are reported.
        /// </summary>
        public DWORD fParity
        {
            get => (_bitFiled >> 1) & 1;
            set => _bitFiled |= ((value & 1) << 1);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, the CTS (clear-to-send) signal is monitored for output flow control.
        /// If this member is <see cref="TRUE"/> and CTS is turned off, output is suspended until CTS is sent again.
        /// </summary>
        public DWORD fOutxCtsFlow
        {
            get => (_bitFiled >> 2) & 1;
            set => _bitFiled |= ((value & 1) << 2);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, the DSR (data-set-ready) signal is monitored for output flow control.
        /// If this member is <see cref="TRUE"/> and DSR is turned off, output is suspended until DSR is sent again.
        /// </summary>
        public DWORD fOutxDsrFlow
        {
            get => (_bitFiled >> 3) & 1;
            set => _bitFiled |= ((value & 1) << 3);
        }

        /// <summary>
        /// <para>
        /// The DTR (data-terminal-ready) flow control. This member can be one of the following values.
        /// </para>
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
        /// <see cref="DTR_CONTROL_DISABLE"/>
        /// </para>
        /// <para>
        /// 0x00
        /// </para>
        /// </term>
        /// <term>
        /// Disables the DTR line when the device is opened and leaves it disabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DTR_CONTROL_ENABLE"/>
        /// </para>
        /// <para>
        /// 0x01
        /// </para>
        /// </term>
        /// <term>
        /// Enables the DTR line when the device is opened and leaves it on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DTR_CONTROL_HANDSHAKE"/>
        /// </para>
        /// <para>
        /// 0x02
        /// </para>
        /// </term>
        /// <term>
        /// Enables DTR handshaking.
        /// If handshaking is enabled, it is an error for the application to adjust the line by using the <see cref="EscapeCommFunction"/> function.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public DataTerminalReadyFlowControls fDtrControl
        {
            get => (DataTerminalReadyFlowControls)((_bitFiled >> 4) & 3);
            set => _bitFiled |= (((uint)value & 3) << 4);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, the communications driver is sensitive to the state of the DSR signal.
        /// The driver ignores any bytes received, unless the DSR modem input line is high.
        /// </summary>
        public DWORD fDsrSensitivity
        {
            get => (_bitFiled >> 6) & 1;
            set => _bitFiled |= ((value & 1) << 6);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, transmission continues after the input buffer has come within <see cref="XoffLim"/> bytes
        /// of being full and the driver has transmitted the <see cref="XoffChar"/> character to stop receiving bytes.
        /// If this member is <see cref="FALSE"/>, transmission does not continue until the input buffer is within <see cref="XonLim"/> bytes
        /// of being empty and the driver has transmitted the <see cref="XonChar"/> character to resume reception.
        /// </summary>
        public DWORD fTXContinueOnXoff
        {
            get => (_bitFiled >> 7) & 1;
            set => _bitFiled |= ((value & 1) << 7);
        }

        /// <summary>
        /// Indicates whether XON/XOFF flow control is used during transmission.
        /// If this member is <see cref="TRUE"/>, transmission stops when the <see cref="XoffChar"/> character is received
        /// and starts again when the <see cref="XonChar"/> character is received.
        /// </summary>
        public DWORD fOutX
        {
            get => (_bitFiled >> 8) & 1;
            set => _bitFiled |= ((value & 1) << 8);
        }

        /// <summary>
        /// Indicates whether XON/XOFF flow control is used during reception.
        /// If this member is <see cref="TRUE"/>, the <see cref="XoffChar"/> character is sent
        /// when the input buffer comes within <see cref="XoffLim"/> bytes of being full,
        /// and the <see cref="XonChar"/> character is sent when the input buffer comes within <see cref="XonLim"/> bytes of being empty.
        /// </summary>
        public DWORD fInX
        {
            get => (_bitFiled >> 9) & 1;
            set => _bitFiled |= ((value & 1) << 9);
        }

        /// <summary>
        /// Indicates whether bytes received with parity errors are replaced with the character specified by the <see cref="ErrorChar"/> member.
        /// If this member is <see cref="TRUE"/> and the <see cref="fParity"/> member is <see cref="TRUE"/>, replacement occurs.
        /// </summary>
        public DWORD fErrorChar
        {
            get => (_bitFiled >> 10) & 1;
            set => _bitFiled |= ((value & 1) << 10);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, null bytes are discarded when received.
        /// </summary>
        public DWORD fNull
        {
            get => (_bitFiled >> 11) & 1;
            set => _bitFiled |= ((value & 1) << 11);
        }

        /// <summary>
        /// <para>
        /// The RTS (request-to-send) flow control. This member can be one of the following values.
        /// </para>
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
        /// <see cref="RTS_CONTROL_DISABLE"/>
        /// </para>
        /// <para>
        /// 0x00
        /// </para>
        /// </term>
        /// <term>
        /// Disables the RTS line when the device is opened and leaves it disabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RTS_CONTROL_ENABLE"/>
        /// </para>
        /// <para>
        /// 0x01
        /// </para>
        /// </term>
        /// <term>
        /// Enables the RTS line when the device is opened and leaves it on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RTS_CONTROL_HANDSHAKE"/>
        /// </para>
        /// <para>
        /// 0x02
        /// </para>
        /// </term>
        /// <term>
        /// Enables RTS handshaking.
        /// The driver raises the RTS line when the "type-ahead" (input) buffer is less than one-half full
        /// and lowers the RTS line when the buffer is more than three-quarters full.
        /// If handshaking is enabled, it is an error for the application to adjust the line by using the <see cref="EscapeCommFunction"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RTS_CONTROL_TOGGLE"/>
        /// </para>
        /// <para>
        /// 0x03
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that the RTS line will be high if bytes are available for transmission.
        /// After all buffered bytes have been sent, the RTS line will be low.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public DWORD fRtsControl
        {
            get => (_bitFiled >> 12) & 3;
            set => _bitFiled |= ((value & 3) << 12);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, the driver terminates all read and write operations with an error status if an error occurs.
        /// The driver will not accept any further communications operations
        /// until the application has acknowledged the error by calling the <see cref="ClearCommError"/> function.
        /// </summary>
        public DWORD fAbortOnError
        {
            get => (_bitFiled >> 14) & 1;
            set => _bitFiled |= ((value & 1) << 14);
        }

        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public DWORD fDummy2
        {
            get => _bitFiled >> 15;
            set => _bitFiled |= (value << 15);
        }
#pragma warning restore IDE1006 

        /// <summary>
        /// Reserved; must be zero.
        /// </summary>
        public WORD wReserved;

        /// <summary>
        /// The minimum number of bytes in use allowed in the input buffer before flow control is activated to allow transmission by the sender.
        /// This assumes that either XON/XOFF, RTS, or DTR input flow control is specified
        /// in the <see cref="fInX"/>, <see cref="fRtsControl"/>, or <see cref="fDtrControl"/> members.
        /// </summary>
        public WORD XonLim;

        /// <summary>
        /// The minimum number of free bytes allowed in the input buffer before flow control is activated to inhibit the sender.
        /// Note that the sender may transmit characters after the flow control signal has been activated, so this value should never be zero.
        /// This assumes that either XON/XOFF, RTS, or DTR input flow control is specified
        /// in the <see cref="fInX"/>, <see cref="fRtsControl"/>, or <see cref="fDtrControl"/> members.
        /// The maximum number of bytes in use allowed is calculated by subtracting this value from the size, in bytes, of the input buffer.
        /// </summary>
        public WORD XoffLim;

        /// <summary>
        /// The number of bits in the bytes transmitted and received.
        /// </summary>
        public BYTE ByteSize;

        /// <summary>
        /// <para>
        /// The parity scheme to be used. This member can be one of the following values.
        /// </para>
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
        /// <see cref="EVENPARITY"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Even parity.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MARKPARITY"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// Mark parity.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="NOPARITY"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// No parity.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ODDPARITY"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Odd parity.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SPACEPARITY"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// Space parity.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public ParitySchemes Parity;

        /// <summary>
        /// <para>
        /// The number of stop bits to be used. This member can be one of the following values.
        /// </para>
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
        /// <see cref="ONESTOPBIT"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// 1 stop bit.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="ONE5STOPBITS"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// 1.5 stop bits.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="TWOSTOPBITS"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// 2 stop bits.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public BYTE StopBits;

        /// <summary>
        /// The value of the XON character for both transmission and reception.
        /// </summary>
        public byte XonChar;

        /// <summary>
        /// The value of the XOFF character for both transmission and reception.
        /// </summary>
        public byte XoffChar;

        /// <summary>
        /// The value of the character used to replace bytes received with a parity error.
        /// </summary>
        public byte ErrorChar;

        /// <summary>
        /// The value of the character used to signal the end of data.
        /// </summary>
        public byte EofChar;

        /// <summary>
        /// The value of the character used to signal an event.
        /// </summary>
        public byte EvtChar;

        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public WORD wReserved1;
    }
}
