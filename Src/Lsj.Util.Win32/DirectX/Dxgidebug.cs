using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.DXGI;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// Dxgidebug.dll
    /// </summary>
    public static class Dxgidebug
    {
        /// <summary>
        /// <para>
        /// Retrieves a debugging interface.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/nf-dxgidebug-dxgigetdebuginterface"/>
        /// </para>
        /// </summary>
        /// <param name="riid">
        /// The globally unique identifier (GUID) of the requested interface type.
        /// </param>
        /// <param name="pDebug">
        /// A pointer to a buffer that receives a pointer to the debugging interface.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="IDXGIDebug"/> and <see cref="IDXGIInfoQueue"/> are debugging interfaces.
        /// </para>
        /// <para>
        /// To access <see cref="DXGIGetDebugInterface"/>, call the <see cref="GetModuleHandle"/> function to get Dxgidebug.dll
        /// and the <see cref="GetProcAddress"/> function to get the address of <see cref="DXGIGetDebugInterface"/>.
        /// </para>
        /// <para>
        /// Windows 8.1:
        /// </para>
        /// <para>
        /// Starting in Windows 8.1, Windows Store apps call the <see cref="DXGIGetDebugInterface1"/> function
        /// to get an <see cref="IDXGIDebug1"/> interface.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("Dxgidebug.dll", CharSet = CharSet.Unicode, EntryPoint = "DXGIGetDebugInterface", ExactSpelling = true)]
        public static extern HRESULT DXGIGetDebugInterface([In] in IID riid, [Out] out IntPtr pDebug);
    }
}
