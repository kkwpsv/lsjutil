using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DXGI_OUTDUPL_POINTER_SHAPE_INFO"/> structure describes information about the cursor shape.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_outdupl_pointer_shape_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// An application draws the cursor shape with the top-left-hand corner drawn at the position
    /// that the <see cref="DXGI_OUTDUPL_POINTER_POSITION.Position"/> member
    /// of the <see cref="DXGI_OUTDUPL_POINTER_POSITION"/> structure specifies;
    /// the application does not use the hot spot to draw the cursor shape.
    /// </para>
    /// <para>
    /// An application calls the <see cref="IDXGIOutputDuplication.GetFramePointerShape"/> method
    /// to retrieve cursor shape information in a <see cref="DXGI_OUTDUPL_POINTER_SHAPE_INFO"/> structure.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_OUTDUPL_POINTER_SHAPE_INFO
    {
        /// <summary>
        /// A <see cref="DXGI_OUTDUPL_POINTER_SHAPE_TYPE"/>-typed value that specifies the type of cursor shape.
        /// </summary>
        public DXGI_OUTDUPL_POINTER_SHAPE_TYPE Type;

        /// <summary>
        /// The width in pixels of the mouse cursor.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// The height in scan lines of the mouse cursor.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// The height in scan lines of the mouse cursor.
        /// </summary>
        public UINT Pitch;

        /// <summary>
        /// The position of the cursor's hot spot relative to its upper-left pixel.
        /// An application does not use the hot spot when it determines where to draw the cursor shape.
        /// </summary>
        public POINT HotSpot;
    }
}
