using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// A combination of one or more flags that control the device create behavior.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcreate"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="D3DCREATE_HARDWARE_VERTEXPROCESSING"/>, <see cref="D3DCREATE_MIXED_VERTEXPROCESSING"/>,
    /// and <see cref="D3DCREATE_SOFTWARE_VERTEXPROCESSING"/> are mutually exclusive flags.
    /// At least one of these vertex processing flags must be specified when calling <see cref="IDirect3D9.CreateDevice"/>.
    /// </remarks>
    [Flags]
    public enum D3DCREATE
    {
        /// <summary>
        /// Application asks the device to drive all the heads that this master adapter owns.
        /// The flag is illegal on nonmaster adapters.
        /// If this flag is set, the presentation parameters passed to <see cref="IDirect3D9.CreateDevice"/>
        /// should point to an array of <see cref="D3DPRESENT_PARAMETERS"/>.
        /// The number of elements in <see cref="D3DPRESENT_PARAMETERS"/> should equal the number of adapters
        /// defined by the <see cref="D3DCAPS9.AdapterOrdinalInGroup"/> member of the <see cref="D3DCAPS9"/> structure.
        /// The DirectX runtime will assign each element to each head in the numerical order
        /// specified by the <see cref="D3DCAPS9.AdapterOrdinalInGroup"/> member of <see cref="D3DCAPS9"/>.
        /// </summary>
        D3DCREATE_ADAPTERGROUP_DEVICE = 0x00000200,

        /// <summary>
        /// Direct3D will manage resources instead of the driver.
        /// Direct3D calls will not fail for resource errors such as insufficient video memory.
        /// </summary>
        D3DCREATE_DISABLE_DRIVER_MANAGEMENT = 0x00000100,

        /// <summary>
        /// Like <see cref="D3DCREATE_DISABLE_DRIVER_MANAGEMENT"/>, Direct3D will manage resources instead of the driver.
        /// Unlike <see cref="D3DCREATE_DISABLE_DRIVER_MANAGEMENT"/>, <see cref="D3DCREATE_DISABLE_DRIVER_MANAGEMENT_EX"/> will
        /// return errors for conditions such as insufficient video memory.
        /// </summary>
        D3DCREATE_DISABLE_DRIVER_MANAGEMENT_EX = 0x00000400,

        /// <summary>
        /// Causes the runtime not register hotkeys for Printscreen, Ctrl-Printscreen and Alt-Printscreen to capture the desktop or window content.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DCREATE_DISABLE_PRINTSCREEN = 0x00008000,

        /// <summary>
        /// Restrict computation to the main application thread.
        /// If the flag is not set, the runtime may perform software vertex processing and other computations
        /// in worker thread to improve performance on multi-processor systems.
        /// Differences between Windows XP and Windows Vista:
        /// This flag is available on Windows Vista, Windows Server 2008, and Windows 7.
        /// </summary>
        D3DCREATE_DISABLE_PSGP_THREADING = 0x00002000,

        /// <summary>
        /// Enables the gathering of present statistics on the device.
        /// Calls to <see cref="IDirect3DSwapChain9Ex.GetPresentStatistics"/> will return valid data.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DCREATE_ENABLE_PRESENTSTATS = 0x00004000,

        /// <summary>
        /// Set the precision for Direct3D floating-point calculations to the precision used by the calling thread.
        /// If you do not specify this flag, Direct3D defaults to single-precision round-to-nearest mode for two reasons:
        /// Double-precision mode will reduce Direct3D performance.
        /// Portions of Direct3D assume floating-point unit exceptions are masked; unmasking these exceptions may result in undefined behavior.
        /// </summary>
        D3DCREATE_FPU_PRESERVE = 0x00000002,

        /// <summary>
        /// Specifies hardware vertex processing.
        /// </summary>
        D3DCREATE_HARDWARE_VERTEXPROCESSING = 0x00000040,

        /// <summary>
        /// Specifies mixed (both software and hardware) vertex processing.
        /// For Windows 10, version 1607 and later, use of this setting is not recommended.
        /// See <see cref="D3DCREATE_SOFTWARE_VERTEXPROCESSING"/>.
        /// </summary>
        D3DCREATE_MIXED_VERTEXPROCESSING = 0x00000080,

        /// <summary>
        /// Specifies software vertex processing.
        /// For Windows 10, version 1607 and later, use of this setting is not recommended.
        /// Use <see cref="D3DCREATE_HARDWARE_VERTEXPROCESSING"/>.
        /// [!Note]
        /// Unless hardware vertex processing is not available, the usage of software vertex processing is not recommended in Windows 10, version 1607 (and later versions)
        /// because the efficiency of software vertex processing was significantly reduced while improving the security of the implementation.
        /// </summary>
        D3DCREATE_SOFTWARE_VERTEXPROCESSING = 0x00000020,

        /// <summary>
        /// Indicates that the application requests Direct3D to be multithread safe.
        /// This makes a Direct3D thread take ownership of its global critical section more frequently, which can degrade performance.
        /// If an application processes window messages in one thread while making Direct3D API calls in another,
        /// the application must use this flag when creating the device.
        /// This window must also be destroyed before unloading d3d9.dll.
        /// </summary>
        D3DCREATE_MULTITHREADED = 0x00000004,

        /// <summary>
        /// Indicates that Direct3D must not alter the focus window in any way.
        /// [!Note]
        /// If this flag is set, the application must fully support all focus management events, such as ALT+TAB and mouse click events.
        /// </summary>
        D3DCREATE_NOWINDOWCHANGES = 0x00000800,

        /// <summary>
        /// Specifies that Direct3D does not support Get* calls for anything that can be stored in state blocks.
        /// It also tells Direct3D not to provide any emulation services for vertex processing.
        /// This means that if the device does not support vertex processing, then the application can use only post-transformed vertices.
        /// </summary>
        D3DCREATE_PUREDEVICE = 0x00000010,

        /// <summary>
        /// Allows screensavers during a fullscreen application.
        /// Without this flag, Direct3D will disable screensavers for as long as the calling application is fullscreen.
        /// If the calling application is already a screensaver, this flag has no effect.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DCREATE_SCREENSAVER = 0x10000000,
    }
}
