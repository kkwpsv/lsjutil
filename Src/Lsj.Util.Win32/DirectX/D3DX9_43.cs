using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.D3d9;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// D3DX9_43.dll
    /// </summary>
    public static class D3DX9_43
    {
        /// <summary>
        /// <para>
        /// Verify that the version of D3DX you compiled with is the version that you are running.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dxcheckversion"/>
        /// </para>
        /// </summary>
        /// <param name="D3DSDKVersion">
        /// Use <see cref="D3D_SDK_VERSION"/>.
        /// See remarks.
        /// </param>
        /// <param name="D3DXSDKVersion">
        /// Use <see cref="D3DX_SDK_VERSION"/>.
        /// See remarks.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the version of D3DX you compiled against is the version you are running with; otherwise, <see cref="FALSE"/> is returned.
        /// </returns>
        /// <remarks>
        /// Use this function during the initialization of your application like this:
        /// <code>
        /// HRESULT CD3DXMyApplication::Initialize(HINSTANCE hInstance, 
        ///     LPCSTR szWindowName, LPCSTR szClassName, UINT uWidth, UINT uHeight)
        /// {
        ///     HRESULT hr;
        ///     
        ///     if (!D3DXCheckVersion(D3D_SDK_VERSION, D3DX_SDK_VERSION))
        ///     {
        ///         return E_FAIL;
        ///     
        ///     ...
        /// }
        /// </code>
        /// Use <see cref="Direct3DCreate9"/> to verify that the correct runtime is installed.
        /// </remarks>
        [DllImport("D3DX9_43.dll", CharSet = CharSet.Unicode, EntryPoint = "D3DXCheckVersion", ExactSpelling = true)]
        public static extern BOOL D3DXCheckVersion([In] UINT D3DSDKVersion, [In] UINT D3DXSDKVersion);

        /// <summary>
        /// <para>
        /// Creates a buffer object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dxcreatebuffer"/>
        /// </para>
        /// </summary>
        /// <param name="NumBytes">
        /// Size of the buffer to create, in bytes.
        /// </param>
        /// <param name="ppBuffer">
        /// Address of a pointer to an <see cref="ID3DXBuffer"/> interface, representing the created buffer object.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the function fails, the return value can be one of the following: <see cref="E_OUTOFMEMORY"/>.
        /// </returns>
        [DllImport("D3DX9_43.dll", CharSet = CharSet.Unicode, EntryPoint = "D3DXCreateBuffer", ExactSpelling = true)]
        public static extern HRESULT D3DXCreateBuffer([In] DWORD NumBytes, [Out] out P<ID3DXBuffer> ppBuffer);
    }
}
