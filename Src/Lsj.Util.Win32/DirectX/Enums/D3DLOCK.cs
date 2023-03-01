using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using static Lsj.Util.Win32.DirectX.Constants;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// A combination of zero or more locking options that describe the type of lock to perform.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dlock"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D3DLOCK
    {
        /// <summary>
        /// The application discards all memory within the locked region.
        /// For vertex and index buffers, the entire buffer will be discarded.
        /// This option is only valid when the resource is created with dynamic usage (see <see cref="D3DUSAGE"/>).
        /// </summary>
        D3DLOCK_DISCARD = 0x00002000,

        /// <summary>
        /// Allows an application to gain back CPU cycles if the driver cannot lock the surface immediately.
        /// If this flag is set and the driver cannot lock the surface immediately, the lock call will return <see cref="D3DERR_WASSTILLDRAWING"/>.
        /// This flag can only be used when locking a surface created using <see cref="IDirect3DDevice9.CreateOffscreenPlainSurface"/>,
        /// <see cref="IDirect3DDevice9.CreateRenderTarget"/>, or <see cref="IDirect3DDevice9.CreateDepthStencilSurface"/>.
        /// This flag can also be used with a back buffer.
        /// </summary>
        D3DLOCK_DONOTWAIT = 0x00004000,

        /// <summary>
        /// By default, a lock on a resource adds a dirty region to that resource.
        /// This option prevents any changes to the dirty state of the resource.
        /// Applications should use this option when they have additional information about the set of regions changed during the lock operation.
        /// </summary>
        D3DLOCK_NO_DIRTY_UPDATE = 0x00008000,

        /// <summary>
        /// Indicates that memory that was referred to in a drawing call since the last lock without this flag will not be modified during the lock.
        /// This can enable optimizations when the application is appending data to a resource.
        /// Specifying this flag enables the driver to return immediately if the resource is in use,
        /// otherwise, the driver must finish using the resource before returning from locking.
        /// </summary>
        D3DLOCK_NOOVERWRITE = 0x00001000,

        /// <summary>
        /// The default behavior of a video memory lock is to reserve a system-wide critical section,
        /// guaranteeing that no display mode changes will occur for the duration of the lock.
        /// This option causes the system-wide critical section not to be held for the duration of the lock.
        /// The lock operation is time consuming, but can enable the system to perform other duties, such as moving the mouse cursor.
        /// This option is useful for long-duration locks, such as the lock of the back buffer for software rendering that would otherwise adversely affect system responsiveness.
        /// </summary>
        D3DLOCK_NOSYSLOCK = 0x00000800,

        /// <summary>
        /// The application will not write to the buffer.
        /// This enables resources stored in non-native formats to save the recompression step when unlocking.
        /// </summary>
        D3DLOCK_READONLY = 0x00000010,
    }
}
