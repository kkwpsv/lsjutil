using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies options that can be applied when a layer resource is applied to create a layer.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// Starting in Windows 8, the <see cref="D2D1_LAYER_OPTIONS_INITIALIZE_FOR_CLEARTYPE"/> option is no longer supported.
    /// </para>
    /// <para>
    /// See <see cref="D2D1_LAYER_OPTIONS1"/> for Windows 8 layer options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_layer_options"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// ClearType antialiasing must use the current contents of the render target to blend properly.
    /// When a pushed layer requests initializing for ClearType,
    /// Direct2D copies the current contents of the render target into the layer
    /// so that ClearType antialiasing can be performed. Rendering ClearType text into a transparent layer does not produce the desired results.
    /// </para>
    /// <para>
    /// A small performance hit from re-copying content occurs when <see cref="ID2D1RenderTarget.Clear"/> is called.
    /// </para>
    /// </remarks>
    public enum D2D1_LAYER_OPTIONS : uint
    {
        /// <summary>
        /// The text in this layer does not use ClearType antialiasing.
        /// </summary>
        D2D1_LAYER_OPTIONS_NONE = 0x00000000,

        /// <summary>
        /// The layer renders correctly for ClearType text.
        /// If the render target is set to ClearType, the layer continues to render ClearType.
        /// If the render target is set to ClearType and this option is not specified,
        /// the render target will be set to render gray-scale until the layer is popped.
        /// The caller can override this default by calling <see cref="ID2D1RenderTarget.SetTextAntialiasMode"/> while within the layer.
        /// This flag is slightly slower than the default.
        /// </summary>
        D2D1_LAYER_OPTIONS_INITIALIZE_FOR_CLEARTYPE = 0x00000001,

        /// <summary>
        /// 
        /// </summary>
        D2D1_LAYER_OPTIONS_FORCE_DWORD = 0xffffffff
    }
}
