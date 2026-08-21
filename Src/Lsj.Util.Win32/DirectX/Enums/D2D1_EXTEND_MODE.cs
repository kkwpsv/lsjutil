using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how a brush paints areas outside of its normal content area.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_extend_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For an <see cref="ID2D1BitmapBrush"/>, the brush's content is the brush's bitmap.
    /// For an <see cref="ID2D1LinearGradientBrush"/>, the brush's content area is the gradient axis.
    /// For an <see cref="ID2D1RadialGradientBrush"/>, the brush's content is the area within the gradient ellipse.
    /// </remarks>
    public enum D2D1_EXTEND_MODE : uint
    {
        /// <summary>
        /// Repeat the edge pixels of the brush's content for all regions outside the normal content area.
        /// </summary>
        D2D1_EXTEND_MODE_CLAMP = 0,

        /// <summary>
        /// Repeat the brush's content.
        /// </summary>
        D2D1_EXTEND_MODE_WRAP = 1,

        /// <summary>
        /// The same as <see cref="D2D1_EXTEND_MODE_WRAP"/>, except that alternate tiles of the brush's content are flipped.
        /// (The brush's normal content is drawn untransformed.)
        /// </summary>
        D2D1_EXTEND_MODE_MIRROR = 2,

        /// <summary>
        /// 
        /// </summary>
        D2D1_EXTEND_MODE_FORCE_DWORD = 0xffffffff
    }
}
