using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains a Message Authentication Code (MAC).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_omac"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_OMAC
    {
        /// <summary>
        /// A byte array that contains the cryptographic MAC value of the message.
        /// </summary>
        public ByValBYTEArrayStructForSize16 Omac;
    }
}
