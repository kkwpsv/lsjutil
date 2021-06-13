using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.DWORD;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the time-out parameters for a communications device.
    /// The parameters determine the behavior of <see cref="ReadFile"/>, <see cref="WriteFile"/>,
    /// <see cref="ReadFileEx"/>, and <see cref="WriteFileEx"/> operations on the device.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-commtimeouts"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If an application sets <see cref="ReadIntervalTimeout"/> and <see cref="ReadTotalTimeoutMultiplier"/> to <see cref="MAXDWORD"/>
    /// and sets <see cref="ReadTotalTimeoutConstant"/> to a value greater than zero and less than <see cref="MAXDWORD"/>,
    /// one of the following occurs when the <see cref="ReadFile"/> function is called:
    /// If there are any bytes in the input buffer, <see cref="ReadFile"/> returns immediately with the bytes in the buffer.
    /// If there are no bytes in the input buffer, <see cref="ReadFile"/> waits until a byte arrives and then returns immediately.
    /// If no bytes arrive within the time specified by <see cref="ReadTotalTimeoutConstant"/>, <see cref="ReadFile"/> times out.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct COMMTIMEOUTS
    {
        /// <summary>
        /// The maximum time allowed to elapse before the arrival of the next byte on the communications line, in milliseconds.
        /// If the interval between the arrival of any two bytes exceeds this amount,
        /// the <see cref="ReadFile"/> operation is completed and any buffered data is returned.
        /// A value of zero indicates that interval time-outs are not used.
        /// A value of <see cref="MAXDWORD"/>, combined with zero values for both the <see cref="ReadTotalTimeoutConstant"/>
        /// and <see cref="ReadTotalTimeoutMultiplier"/> members, specifies that the read operation
        /// is to return immediately with the bytes that have already been received, even if no bytes have been received.
        /// </summary>
        public DWORD ReadIntervalTimeout;

        /// <summary>
        /// The multiplier used to calculate the total time-out period for read operations, in milliseconds.
        /// For each read operation, this value is multiplied by the requested number of bytes to be read.
        /// </summary>
        public DWORD ReadTotalTimeoutMultiplier;

        /// <summary>
        /// A constant used to calculate the total time-out period for read operations, in milliseconds.
        /// For each read operation, this value is added to the product
        /// of the <see cref="ReadTotalTimeoutMultiplier"/> member and the requested number of bytes.
        /// A value of zero for both the <see cref="ReadTotalTimeoutMultiplier"/> and <see cref="ReadTotalTimeoutConstant"/> members
        /// indicates that total time-outs are not used for read operations.
        /// </summary>
        public DWORD ReadTotalTimeoutConstant;

        /// <summary>
        /// The multiplier used to calculate the total time-out period for write operations, in milliseconds.
        /// For each write operation, this value is multiplied by the number of bytes to be written.
        /// </summary>
        public DWORD WriteTotalTimeoutMultiplier;

        /// <summary>
        /// A constant used to calculate the total time-out period for write operations, in milliseconds.
        /// For each write operation, this value is added to the product
        /// of the <see cref="WriteTotalTimeoutMultiplier"/> member and the number of bytes to be written.
        /// A value of zero for both the <see cref="WriteTotalTimeoutMultiplier"/> and <see cref="WriteTotalTimeoutConstant"/> members
        /// indicates that total time-outs are not used for write operations.
        /// </summary>
        public DWORD WriteTotalTimeoutConstant;
    }
}
