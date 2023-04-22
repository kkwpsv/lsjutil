using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Represents a handle to a shared resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_shared_resource"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To create a shared surface, pass a shared-resource handle into the <see cref="IDXGIDevice.CreateSurface"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_SHARED_RESOURCE
    {
        /// <summary>
        /// A handle to a shared resource.
        /// </summary>
        public HANDLE Handle;
    }
}
