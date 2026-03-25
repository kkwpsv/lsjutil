using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains the HWND, pixel size, and presentation options for an <see cref="ID2D1HwndRenderTarget"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_hwnd_render_target_properties"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this structure when you call the <see cref="ID2D1Factory.CreateHwndRenderTarget"/> method
    /// to create a new <see cref="ID2D1HwndRenderTarget"/>.
    /// </para>
    /// <para>
    /// For convenience, Direct2D provides the <c>D2D1.HwndRenderTargetProperties</c> function
    /// for creating new <see cref="D2D1_HWND_RENDER_TARGET_PROPERTIES"/> structures.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_HWND_RENDER_TARGET_PROPERTIES
    {
        /// <summary>
        /// The <see cref="HWND"/> to which the render target issues the output from its drawing commands.
        /// </summary>
        public HWND hwnd;

        /// <summary>
        /// The size of the render target, in pixels.
        /// </summary>
        public D2D1_SIZE_U pixelSize;

        /// <summary>
        /// A value that specifies whether the render target retains the frame
        /// after it is presented and whether the render target waits for the device to refresh before presenting.
        /// </summary>
        public D2D1_PRESENT_OPTIONS presentOptions;
    }
}
