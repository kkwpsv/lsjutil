using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_FEATURE_LEVEL;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_RENDER_TARGET_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_RENDER_TARGET_USAGE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains rendering options (hardware or software), pixel format, DPI information, remoting options,
    /// and Direct3D support requirements for a render target.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_render_target_properties"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this structure when creating a render target, or use it with the <see cref="ID2D1RenderTarget.IsSupported"/> method
    /// to check the properties supported by an existing render target.
    /// </para>
    /// <para>
    /// As a convenience, Direct2D provides the <c>D2D1.RenderTargetProperties</c> helper function
    /// for creating <see cref="D2D1_RENDER_TARGET_PROPERTIES"/> structures.
    /// An easy way to create a <see cref="D2D1_RENDER_TARGET_PROPERTIES"/> structure that works for most render targets
    /// is to call the function without specifying any parameters.
    /// Doing so creates a <see cref="D2D1_RENDER_TARGET_PROPERTIES"/> structure that has its fields set to default values.
    /// For more information, see <c>D2D1.RenderTargetProperties</c>.
    /// </para>
    /// <para>
    /// Not all render targets support hardware rendering.
    /// For a list, see the Render Targets Overview.
    /// </para>
    /// <para>
    /// Using Default DPI Settings
    /// </para>
    /// <para>
    /// To use the default DPI, set <see cref="dpiX"/> and <see cref="dpiY"/> to 0.
    /// The default DPI varies depending on the render target:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// For a compatible render target, the default DPI is the DPI of the parent render target.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// For a <see cref="ID2D1HwndRenderTarget"/>,
    /// the default DPI is the system DPI obtained from the render target's <see cref="ID2D1Factory"/>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// For other render targets, the default DPI is 96.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// To use the default DPI setting, both <see cref="dpiX"/> and <see cref="dpiY"/> must be set to 0.
    /// Setting only one value to 0 causes an <see cref="E_INVALIDARG"/> error when attempting to create a render target.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_RENDER_TARGET_PROPERTIES
    {
        /// <summary>
        /// A value that specifies whether the render target should force hardware or software rendering.
        /// A value of <see cref="D2D1_RENDER_TARGET_TYPE_DEFAULT"/> specifies
        /// that the render target should use hardware rendering if it is available;
        /// otherwise, it uses software rendering.
        /// Note that WIC bitmap render targets do not support hardware rendering.
        /// </summary>
        public D2D1_RENDER_TARGET_TYPE type;

        /// <summary>
        /// The pixel format and alpha mode of the render target.
        /// You can use the <c>D2D1.PixelFormat</c> function to create a pixel format
        /// that specifies that Direct2D should select the pixel format and alpha mode for you.
        /// For a list of pixel formats and alpha modes supported by each render target, see Supported Pixel Formats and Alpha Modes.
        /// </summary>
        public D2D1_PIXEL_FORMAT pixelFormat;

        /// <summary>
        /// The horizontal DPI of the render target.
        /// To use the default DPI, set <see cref="dpiX"/> and <see cref="dpiY"/> to 0.
        /// For more information, see the Remarks section.
        /// </summary>
        public FLOAT dpiX;

        /// <summary>
        /// The vertical DPI of the render target.
        /// To use the default DPI, set <see cref="dpiX"/> and <see cref="dpiY"/> to 0.
        /// For more information, see the Remarks section.
        /// </summary>
        public FLOAT dpiY;

        /// <summary>
        /// A value that specifies how the render target is remoted and whether it should be GDI-compatible.
        /// Set to <see cref="D2D1_RENDER_TARGET_USAGE_NONE"/> to create a render target
        /// that is not compatible with GDI and uses Direct3D command-stream remoting if it is available.
        /// </summary>
        public D2D1_RENDER_TARGET_USAGE usage;

        /// <summary>
        /// A value that specifies the minimum Direct3D feature level required for hardware rendering.
        /// If the specified minimum level is not available, the render target uses software rendering
        /// if the type member is set to <see cref="D2D1_RENDER_TARGET_TYPE_DEFAULT"/>;
        /// if type is set to <see cref="D2D1_RENDER_TARGET_TYPE_HARDWARE"/>, render target creation fails.
        /// A value of <see cref="D2D1_FEATURE_LEVEL_DEFAULT"/> indicates that Direct2D should determine
        /// whether the Direct3D feature level of the device is adequate.
        /// This field is used only when creating <see cref="ID2D1HwndRenderTarget"/> and <see cref="ID2D1DCRenderTarget"/> objects.
        /// </summary>
        public D2D1_FEATURE_LEVEL minLevel;
    }
}
