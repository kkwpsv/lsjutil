using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.CBR;
using static Lsj.Util.Win32.Enums.DTR_CONTROL;
using static Lsj.Util.Win32.Enums.PARITY;
using static Lsj.Util.Win32.Enums.RTS_CONTROL;
using static Lsj.Util.Win32.Enums.STOPBIT;
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
    /// When a DCB structure is used to configure the 8250, the following restrictions apply to the values
    /// specified for the <see cref="ByteSize"/> and <see cref="StopBits"/> members:
    /// The number of data bits must be 5 to 8 bits.
    /// The use of 5 data bits with 2 stop bits is an invalid combination, as is 6, 7, or 8 data bits with 1.5 stop bits.
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
        /// The baud rate at which the communications device operates.
        /// This member can be an actual baud rate value, or one of the following indexes.
        /// <see cref="CBR_110"/>, <see cref="CBR_300"/>, <see cref="CBR_600"/>, <see cref="CBR_1200"/>,
        /// <see cref="CBR_2400"/>, <see cref="CBR_4800"/>, <see cref="CBR_9600"/>, <see cref="CBR_14400"/>,
        /// <see cref="CBR_19200"/>, <see cref="CBR_38400"/>, <see cref="CBR_57600"/>, <see cref="CBR_115200"/>,
        /// <see cref="CBR_128000"/>, <see cref="CBR_256000"/>
        /// </summary>
        public CBR BaudRate;

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
        /// The DTR (data-terminal-ready) flow control.
        /// This member can be one of the following values.
        /// <see cref="DTR_CONTROL_DISABLE"/>, <see cref="DTR_CONTROL_ENABLE"/>, <see cref="DTR_CONTROL_HANDSHAKE"/>
        /// </summary>
        public DTR_CONTROL fDtrControl
        {
            get => (DTR_CONTROL)((_bitFiled >> 4) & 3);
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
        /// The RTS (request-to-send) flow control. This member can be one of the following values.
        /// <see cref="RTS_CONTROL_DISABLE"/>, <see cref="RTS_CONTROL_ENABLE"/>,
        /// <see cref="RTS_CONTROL_HANDSHAKE"/>, <see cref="RTS_CONTROL_TOGGLE"/>
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
        /// The parity scheme to be used. This member can be one of the following values.
        /// <see cref="EVENPARITY"/>, <see cref="MARKPARITY"/>, <see cref="NOPARITY"/>, <see cref="ODDPARITY"/>, <see cref="SPACEPARITY"/>
        /// </summary>
        public PARITY Parity;

        /// <summary>
        /// The number of stop bits to be used.
        /// This member can be one of the following values.
        /// <see cref="ONESTOPBIT"/>, <see cref="ONE5STOPBITS"/>, <see cref="TWOSTOPBITS"/>
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
