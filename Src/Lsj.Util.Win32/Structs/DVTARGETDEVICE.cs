using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies information about the target device for which data is being composed.
    /// <see cref="DVTARGETDEVICE"/> contains enough information about a Windows target device
    /// so a handle to a device context (HDC) can be created using the <see cref="CreateDC"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/ns-objidl-dvtargetdevice"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Some OLE 1 client applications incorrectly construct target devices
    /// by allocating too few bytes in the <see cref="DEVMODE"/> structure for the <see cref="DVTARGETDEVICE"/>.
    /// They typically only supply the number of bytes in the <see cref="DEVMODE.dmSize"/> member of <see cref="DEVMODE"/>.
    /// The number of bytes to be allocated should be the sum of <see cref="DEVMODE.dmSize"/> + <see cref="DEVMODE.dmDriverExtra"/>.
    /// When a call is made to the <see cref="CreateDC"/> function with an incorrect target device,
    /// the printer driver tries to access the additional bytes and unpredictable results can occur.
    /// To help protect against a crash and make the additional bytes available,
    /// OLE pads the size of OLE 2 target devices created from OLE 1 target devices.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DVTARGETDEVICE
    {
        /// <summary>
        /// The size, in bytes, of the <see cref="DVTARGETDEVICE"/> structure.
        /// The initial size is included so the structure can be copied more easily.
        /// </summary>
        public DWORD tdSize;

        /// <summary>
        /// The offset, in bytes, from the beginning of the structure to the device driver name,
        /// which is stored as a NULL-terminated string in the <see cref="tdData"/> buffer.
        /// </summary>
        public WORD tdDriverNameOffset;

        /// <summary>
        /// The offset, in bytes, from the beginning of the structure to the device name,
        /// which is stored as a NULL-terminated string in the <see cref="tdData"/> buffer.
        /// This value can be zero to indicate no device name.
        /// </summary>
        public WORD tdDeviceNameOffset;

        /// <summary>
        /// The offset, in bytes, from the beginning of the structure to the port name,
        /// which is stored as a NULL-terminated string in the <see cref="tdData"/> buffer.
        /// This value can be zero to indicate no port name.
        /// </summary>
        public WORD tdPortNameOffset;

        /// <summary>
        /// The offset, in bytes, from the beginning of the structure to the <see cref="DEVMODE"/> structure
        /// retrieved by calling <see cref="DocumentProperties"/>.
        /// </summary>
        public WORD tdExtDevmodeOffset;

        /// <summary>
        /// An array of bytes containing data for the target device.
        /// It is not necessary to include empty strings in <see cref="tdData"/> (for names where the offset value is zero).
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public BYTE[] tdData;
    }
}
