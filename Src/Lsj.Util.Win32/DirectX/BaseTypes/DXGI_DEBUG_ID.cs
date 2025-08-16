using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.BaseTypes
{
    /// <summary>
    /// <para>
    /// Globally unique identifier (GUID) values that identify producers of debug messages.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-debug-id"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use these values with the <see cref="IDXGIInfoQueue"/> interface.
    /// </para>
    /// <code>
    /// typedef GUID DXGI_DEBUG_ID;
    /// 
    /// DEFINE_GUID(DXGI_DEBUG_ALL, 0xe48ae283, 0xda80, 0x490b, 0x87, 0xe6, 0x43, 0xe9, 0xa9, 0xcf, 0xda, 0x8);
    /// DEFINE_GUID(DXGI_DEBUG_DX, 0x35cdd7fc, 0x13b2, 0x421d, 0xa5, 0xd7, 0x7e, 0x44, 0x51, 0x28, 0x7d, 0x64);
    /// DEFINE_GUID(DXGI_DEBUG_DXGI, 0x25cddaa4, 0xb1c6, 0x47e1, 0xac, 0x3e, 0x98, 0x87, 0x5b, 0x5a, 0x2e, 0x2a);
    /// DEFINE_GUID(DXGI_DEBUG_APP, 0x6cd6e01, 0x4219, 0x4ebd, 0x87, 0x9, 0x27, 0xed, 0x23, 0x36, 0xc, 0x62);
    /// 
    /// DEFINE_GUID(DXGI_DEBUG_D3D11, 0x4b99317b, 0xac39, 0x4aa6, 0xbb, 0xb, 0xba, 0xa0, 0x47, 0x84, 0x79, 0x8f);
    /// </code>
    /// <para>
    /// To use any of these GUID values, include DXGIDebug.h in your code and link to dxguid.lib.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct DXGI_DEBUG_ID
    {
        [FieldOffset(0)]
        private Guid _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Guid(DXGI_DEBUG_ID val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DXGI_DEBUG_ID(Guid val) => new DXGI_DEBUG_ID { _value = val };

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();
    }
}
