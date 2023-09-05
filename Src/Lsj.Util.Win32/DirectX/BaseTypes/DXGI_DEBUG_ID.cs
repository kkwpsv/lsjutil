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
