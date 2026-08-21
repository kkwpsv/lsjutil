using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains the content bounds, mask information, opacity settings, and other options for a layer resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_layer_parameters"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_LAYER_PARAMETERS
    {
        /// <summary>
        /// The content bounds of the layer.
        /// Content won't render outside these bounds.
        /// </summary>
        public D2D1_RECT_F contentBounds;

        /// <summary>
        /// The geometric mask specifies the area of the layer that is composited into the render target.
        /// </summary>
        public P<ID2D1Geometry> geometricMask;

        /// <summary>
        /// A value that specifies the antialiasing mode for the <see cref="geometricMask"/>.
        /// </summary>
        public D2D1_ANTIALIAS_MODE maskAntialiasMode;

        /// <summary>
        /// A value that specifies the transform that is applied to the geometric mask when composing the layer.
        /// </summary>
        public D2D1_MATRIX_3X2_F maskTransform;

        /// <summary>
        /// An opacity value that is applied uniformly to all resources in the layer when compositing to the target.
        /// </summary>
        public FLOAT opacity;

        /// <summary>
        /// A brush that is used to modify the opacity of the layer.
        /// The brush is mapped to the layer, and the alpha channel of each mapped brush pixel
        /// is multiplied against the corresponding layer pixel.
        /// </summary>
        public P<ID2D1Brush> opacityBrush;

        /// <summary>
        /// A value that specifies whether the layer intends to render text with ClearType antialiasing.
        /// </summary>
        public D2D1_LAYER_OPTIONS layerOptions;
    }
}
