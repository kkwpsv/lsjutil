using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.DirectX.Enums.D3DCREATE;
using static Lsj.Util.Win32.DirectX.Enums.D3DPOOL;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Driver capability flags.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcaps2"/>
    /// </para>
    /// </summary>
    public enum D3DCAPS2 : uint
    {
        /// <summary>
        /// The driver is capable of automatically generating mipmaps
        /// For more information, see Automatic Generation of Mipmaps (Direct3D 9).
        /// </summary>
        D3DCAPS2_CANAUTOGENMIPMAP = 0x40000000,

        /// <summary>
        /// The system has a calibrator installed that can automatically adjust the gamma ramp so that the result is identical on all systems that have a calibrator. 
        /// To invoke the calibrator when setting new gamma levels, use the <see cref="D3DSGR_CALIBRATE"/> flag when calling <see cref="IDirect3DDevice9.SetGammaRamp"/>.
        /// Calibrating gamma ramps incurs some processing overhead and should not be used frequently.
        /// </summary>
        D3DCAPS2_CANCALIBRATEGAMMA = 0x00100000,

        /// <summary>
        /// The device can create sharable resources.
        /// Methods that create resources can set non-NULL values for their pSharedHandle parameters.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DCAPS2_CANSHARERESOURCE = 0x80000000,

        /// <summary>
        /// The driver is capable of managing resources.
        /// On such drivers, <see cref="D3DPOOL_MANAGED"/> resources will be managed by the driver.
        /// To have Direct3D override the driver so that Direct3D manages resources,
        /// use the <see cref="D3DCREATE_DISABLE_DRIVER_MANAGEMENT"/> flag when calling <see cref="IDirect3D9.CreateDevice"/>.
        /// </summary>
        D3DCAPS2_CANMANAGERESOURCE = 0x10000000,

        /// <summary>
        /// The driver supports dynamic textures.
        /// </summary>
        D3DCAPS2_DYNAMICTEXTURES = 0x20000000,

        /// <summary>
        /// The driver supports dynamic gamma ramp adjustment in full-screen mode.
        /// </summary>
        D3DCAPS2_FULLSCREENGAMMA = 0x00020000,

        /// <summary>
        /// Reserved; not used.
        /// </summary>
        D3DCAPS2_RESERVED = 0x02000000,
    }
}
