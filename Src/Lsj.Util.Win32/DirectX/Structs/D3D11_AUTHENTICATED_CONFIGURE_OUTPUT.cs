using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains the response from the <see cref="ID3D11VideoContext.ConfigureAuthenticatedChannel"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_authenticated_configure_output"/>
    /// </para>
    /// </summary>

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_AUTHENTICATED_CONFIGURE_OUTPUT
    {
        /// <summary>
        /// A <see cref="D3D11_OMAC"/> structure that contains a Message Authentication Code (MAC) of the data.
        /// The driver uses AES-based one-key CBC MAC (OMAC) to calculate this value for the block of data that appears after this structure member.
        /// </summary>
        public D3D11_OMAC omac;

        /// <summary>
        /// A GUID that specifies the command.
        /// For a list of GUIDs, see <see cref="D3D11_AUTHENTICATED_CONFIGURE_INPUT"/>.
        /// </summary>
        public GUID ConfigureType;

        /// <summary>
        /// A handle to the authenticated channel.
        /// </summary>
        public HANDLE hChannel;

        /// <summary>
        /// The command sequence number.
        /// </summary>
        public UINT SequenceNumber;

        /// <summary>
        /// The result code for the command.
        /// </summary>
        public HRESULT ReturnCode;
    }
}
