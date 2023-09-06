using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DXGI_OUTDUPL_POINTER_POSITION"/> structure describes the position of the hardware cursor.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_outdupl_pointer_position"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="Position"/> member is valid only if the <see cref="Visible"/> member’s value is set to <see cref="TRUE"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_OUTDUPL_POINTER_POSITION
    {
        /// <summary>
        /// The position of the hardware cursor relative to the top-left of the adapter output.
        /// </summary>
        public POINT Position;

        /// <summary>
        /// Specifies whether the hardware cursor is visible.
        /// <see cref="TRUE"/> if visible; otherwise, <see cref="FALSE"/>.
        /// If the hardware cursor is not visible, the calling application does not display the cursor in the client.
        /// </summary>
        public BOOL Visible;
    }
}
