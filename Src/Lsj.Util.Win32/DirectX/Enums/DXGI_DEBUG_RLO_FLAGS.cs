using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Flags used with <see cref="IDXGIDebug.ReportLiveObjects"/> to specify the amount of info to report about an object's lifetime.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/ne-dxgidebug-dxgi_debug_rlo_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this enumeration with <see cref="IDXGIDebug.ReportLiveObjects"/>.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
    /// </para>
    /// </remarks>
    [Flags]
    public enum DXGI_DEBUG_RLO_FLAGS
    {
        /// <summary>
        /// A flag that specifies to obtain a summary about an object's lifetime.
        /// </summary>
        DXGI_DEBUG_RLO_SUMMARY = 0x1,

        /// <summary>
        /// A flag that specifies to obtain detailed info about an object's lifetime.
        /// </summary>
        DXGI_DEBUG_RLO_DETAIL = 0x2,

        /// <summary>
        /// <para>
        /// This flag indicates to ignore objects which have no external refcounts keeping them alive.
        /// </para>
        /// <para>
        /// D3D objects are printed using an external refcount and an internal refcount.
        /// </para>
        /// <para>
        /// Typically, all objects are printed.
        /// </para>
        /// <para>
        /// This flag means ignore the objects whose external refcount is 0, because the application is not responsible for keeping them alive.
        /// </para>
        /// </summary>
        DXGI_DEBUG_RLO_IGNORE_INTERNAL = 0x4,

        /// <summary>
        /// A flag that specifies to obtain both a summary and detailed info about an object's lifetime.
        /// </summary>
        DXGI_DEBUG_RLO_ALL = 0x7,
    }
}
