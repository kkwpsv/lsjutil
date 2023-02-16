using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// D3d9.dll
    /// </summary>
    public static partial class D3d9
    {
        /// <summary>
        /// D3D_SDK_VERSION
        /// </summary>
        public const uint D3D_SDK_VERSION = 32;

        /// <summary>
        /// <para>
        /// Create an <see cref="IDirect3D9"/> object and return an interface to it.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9/"/>
        /// </para>
        /// </summary>
        /// <param name="SDKVersion">
        /// The value of this parameter should be <see cref="D3D_SDK_VERSION"/>.
        /// See Remarks.
        /// </param>
        /// <returns>
        /// If successful, this function returns a pointer to an <see cref="IDirect3D9"/> interface; otherwise, a NULL pointer is returned.
        /// </returns>
        /// <remarks>
        /// The Direct3D object is the first Direct3D COM object that your graphical application needs to create
        /// and the last object that your application needs to release.
        /// Functions for enumerating and retrieving capabilities of a device are accessible through the Direct3D object.
        /// This enables applications to select devices without creating them.
        /// Create an IDirect3D9 object as shown here:
        /// <code>
        /// LPDIRECT3D9 g_pD3D = NULL;
        /// if( NULL == (g_pD3D = Direct3DCreate9(D3D_SDK_VERSION)))
        ///     return E_FAIL;
        /// </code>
        /// The IDirect3D9 interface supports enumeration of active display adapters and allows the creation of <see cref="IDirect3DDevice9"/> objects.
        /// If the user dynamically adds adapters (either by adding devices to the desktop, or by hot-docking a laptop),
        /// those devices will not be included in the enumeration.
        /// Creating a new <see cref="IDirect3D9"/> interface will expose the new devices.
        /// <see cref="D3D_SDK_VERSION"/> is passed to this function to ensure that the header files against
        /// which an application is compiled match the version of the runtime DLL's that are installed on the machine.
        /// <see cref="D3D_SDK_VERSION"/> is only changed in the runtime when a header change (or other code change)
        /// would require an application to be rebuilt.
        /// If this function fails, it indicates that the header file version does not match the runtime DLL version.
        /// </remarks>
        [DllImport("D3d9.dll", CharSet = CharSet.Unicode, EntryPoint = "Direct3DCreate9", ExactSpelling = true)]
        public static extern P<IDirect3D9> Direct3DCreate9([In] UINT SDKVersion);
    }
}
