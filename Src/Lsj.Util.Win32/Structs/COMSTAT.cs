using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a communications device.
    /// This structure is filled by the <see cref="ClearCommError"/> function.
    /// </para>
    /// <para>
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-comstat"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COMSTAT
    {
        private DWORD _bitFiled;

#pragma warning disable IDE1006
        /// <summary>
        /// If this member is <see cref="TRUE"/>, transmission is waiting for the CTS (clear-to-send) signal to be sent.
        /// </summary>
        public DWORD fCtsHold
        {
            get => _bitFiled & 1;
            set => _bitFiled |= (value & 1);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, transmission is waiting for the DSR (data-set-ready) signal to be sent.
        /// </summary>
        public DWORD fDsrHold
        {
            get => (_bitFiled >> 1) & 1;
            set => _bitFiled |= ((value & 1) << 1);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, transmission is waiting for the RLSD (receive-line-signal-detect) signal to be sent.
        /// If this member is <see cref="TRUE"/> and CTS is turned off, output is suspended until CTS is sent again.
        /// </summary>
        public DWORD fRlsdHold
        {
            get => (_bitFiled >> 2) & 1;
            set => _bitFiled |= ((value & 1) << 2);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, transmission is waiting because the XOFF character was received.
        /// </summary>
        public DWORD fXoffHold
        {
            get => (_bitFiled >> 3) & 1;
            set => _bitFiled |= ((value & 1) << 3);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, transmission is waiting because the XOFF character was transmitted.
        /// (Transmission halts when the XOFF character is transmitted to a system that takes the next character as XON, regardless of the actual character.)
        /// </summary>
        public DWORD fXoffSent
        {
            get => (_bitFiled >> 4) & 1;
            set => _bitFiled |= ((value & 1) << 4);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, the end-of-file (EOF) character has been received.
        /// </summary>
        public DWORD fEof
        {
            get => (_bitFiled >> 5) & 1;
            set => _bitFiled |= ((value & 1) << 5);
        }

        /// <summary>
        /// If this member is <see cref="TRUE"/>, there is a character queued for transmission that
        /// has come to the communications device by way of the <see cref="TransmitCommChar"/> function.
        /// The communications device transmits such a character ahead of other characters in the device's output buffer.
        /// </summary>
        public DWORD fTxim
        {
            get => (_bitFiled >> 6) & 1;
            set => _bitFiled |= ((value & 1) << 6);
        }

        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public DWORD fReserved
        {
            get => _bitFiled >> 7;
            set => _bitFiled |= (value << 7);
        }
#pragma warning restore IDE1006 // 命名样式

        /// <summary>
        /// The number of bytes received by the serial provider but not yet read by a <see cref="ReadFile"/> operation.
        /// </summary>
        public DWORD cbInQue;

        /// <summary>
        /// The number of bytes of user data remaining to be transmitted for all write operations.
        /// This value will be zero for a nonoverlapped write.
        /// </summary>
        public DWORD cbOutQue;
    }
}
